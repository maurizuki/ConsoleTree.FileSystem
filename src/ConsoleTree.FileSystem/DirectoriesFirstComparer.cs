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

namespace ConsoleTree.FileSystem;

/// <summary>
///     Represents a comparison operation between two objects of type <c>FileSystemInfo</c> that makes directories come
///     first.
/// </summary>
public class DirectoriesFirstComparer : Comparer<FileSystemInfo>
{
	/// <summary>
	///     Performs a comparison of two objects of type <c>FileSystemInfo</c> and returns a value indicating whether one
	///     object is less than, equal to, or greater than the other.
	/// </summary>
	/// <param name="x">The first object to compare.</param>
	/// <param name="y">The second object to compare.</param>
	/// <returns>
	///     A signed integer that is less than zero if <c>x</c> is less than <c>y</c>, zero if <c>x</c> equals <c>y</c>,
	///     greater than zero if <c>x</c> is greater than <c>y</c>.
	/// </returns>
	public override int Compare(FileSystemInfo x, FileSystemInfo y)
	{
		if ((x?.Attributes & FileAttributes.Directory) == (y?.Attributes & FileAttributes.Directory))
		{
			return string.Compare(x?.Name, y?.Name, StringComparison.InvariantCulture);
		}

		return (x?.Attributes & FileAttributes.Directory) == FileAttributes.Directory ? -1 : 1;
	}
}
