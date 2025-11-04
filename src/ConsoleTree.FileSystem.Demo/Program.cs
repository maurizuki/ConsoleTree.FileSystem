// Copyright (c) 2022+ Maurizio Basaglia
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

using ConsoleTree;
using ConsoleTree.FileSystem;

var settings = new SearchSettings();

if (args.Length >= 1)
{
	var options = args.Skip(1).ToArray();

	if (HasOption("-d"))
	{
		settings.Comparer = new DirectoriesFirstComparer();
	}

	settings.IncludeFiles = HasOption("-f");

	var skipAttributes = FileAttributes.None;

	if (!HasOption("-h"))
	{
		skipAttributes |= FileAttributes.Hidden;
	}

	if (!HasOption("-s"))
	{
		skipAttributes |= FileAttributes.System;
	}

	if (skipAttributes != FileAttributes.None) 
	{
		settings.Predicate = fsi => (fsi.Attributes & skipAttributes) == FileAttributes.None;
	}

	Tree.Write(new FileSystemNode(args[0], settings), new DisplaySettings {IndentSize = 2});

	return;

	bool HasOption(string option)
	{
		return options.Contains(option, StringComparer.InvariantCultureIgnoreCase);
	}
}

Console.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} <directory_path> [<options>]");
Console.WriteLine();
Console.WriteLine("Where <options> are:");
Console.WriteLine();
Console.WriteLine("-d    Sort directories first.");
Console.WriteLine("-f    Include files in search.");
Console.WriteLine("-h    Include hidden files and directories in search.");
Console.WriteLine("-s    Include system files and directories in search.");
