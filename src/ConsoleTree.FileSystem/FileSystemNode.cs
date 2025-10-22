// Copyright (c) 2022 Maurizio Basaglia
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleTree.FileSystem;

/// <summary>
///     Represents a node of the file system tree structure.
/// </summary>
public class FileSystemNode : ITreeNode
{
	private readonly SearchSettings _searchSettings;

	/// <summary>
	///     Gets the <c>FileSystemInfo</c> relative to the node of the file system tree structure.
	/// </summary>
	public FileSystemInfo FileSystemInfo { get; }

	private FileSystemNode(FileSystemInfo fileSystemInfo, SearchSettings settings)
	{
		_searchSettings = settings;
		FileSystemInfo = fileSystemInfo;
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="FileSystemNode" /> class with the specified directory path.
	/// </summary>
	/// <param name="directoryPath">A string specifying the directory path on which to create the new instance.</param>
	/// <param name="settings">The <see cref="SearchSettings" /> used to look for files and subdirectories.</param>
	/// <exception cref="ArgumentNullException"><c>directoryPath</c> is <c>null</c>.</exception>
	public FileSystemNode(string directoryPath, SearchSettings settings = null)
		: this((FileSystemInfo) new DirectoryInfo(directoryPath), settings ?? new SearchSettings())
	{
		if (directoryPath == null) throw new ArgumentNullException(nameof(directoryPath));
	}

	/// <summary>
	///     Initializes a new instance of the <see cref="FileSystemNode" /> class with the specified <c>DirectoryInfo</c>.
	/// </summary>
	/// <param name="directoryInfo">The <c>DirectoryInfo</c> with which to create the new instance.</param>
	/// <param name="settings">The <see cref="SearchSettings" /> used to look for files and subdirectories.</param>
	/// <exception cref="ArgumentNullException"><c>directoryInfo</c> is <c>null</c>.</exception>
	public FileSystemNode(DirectoryInfo directoryInfo, SearchSettings settings = null)
		: this((FileSystemInfo) directoryInfo, settings ?? new SearchSettings())
	{
		if (directoryInfo == null) throw new ArgumentNullException(nameof(directoryInfo));
	}

	/// <summary>
	///     Returns a collection of the subnodes of the node.
	/// </summary>
	/// <returns>A collection of the subnodes of the node.</returns>
	public IEnumerable<ITreeNode> GetNodes()
	{
		if (FileSystemInfo is not DirectoryInfo directoryInfo) return Enumerable.Empty<ITreeNode>();

		var fileSystemInfos = _searchSettings.IncludeFiles
			? directoryInfo.EnumerateFileSystemInfos()
			: directoryInfo.EnumerateDirectories();

		if (_searchSettings.Comparer != null)
		{
			fileSystemInfos = fileSystemInfos.OrderBy(fsi => fsi, _searchSettings.Comparer);
		}

		return fileSystemInfos.Select(fsi => new FileSystemNode(fsi, _searchSettings));
	}

	/// <summary>
	///     Returns the name of the directory with a trailing directory separator character or the name of the file.
	/// </summary>
	/// <returns>A string with the directory/file name.</returns>
	public override string ToString()
	{
		return FileSystemInfo is DirectoryInfo
			? FileSystemInfo.Name + Path.DirectorySeparatorChar
			: FileSystemInfo.Name;
	}
}
