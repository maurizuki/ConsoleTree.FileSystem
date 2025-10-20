# ConsoleTree.FileSystem

A tool to write the directory tree to the console standard output stream, with colors support and a lot of customization options.

## Getting started

To add ConsoleTree.FileSystem to your project, you can use the following NuGet Package Manager command:

```PowerShell
Install-Package ConsoleTree.FileSystem
```

More options are available on the [ConsoleTree.FileSystem page](https://www.nuget.org/packages/ConsoleTree.FileSystem) of the NuGet Gallery website.

## Usage
Instantiate a ```FileSystemNode``` specifying the root directory and, optionally, if files must be included and a sort order. To write the directory tree to the console standard output stream, call the ```ConsoleTree.Tree.Write``` method specifying the ```FileSystemNode``` instance as parameter.

```csharp
using ConsoleTree;
using ConsoleTree.FileSystem;

Tree.Write(new FileSystemNode(docsDirectory, new SearchSettings
{
    IncludeFiles = true,
    Comparer = new DirectoriesFirstComparer()
}), new DisplaySettings {IndentSize = 2});

// Output:
//
// docs\
// ├──ConsoleTree.FileSystem\
// │  ├──DirectoriesFirstComparer\
// │  │  ├──Compare.md
// │  │  └──DirectoriesFirstComparer.md
// │  ├──FileSystemNode\
// │  │  ├──FileSystemInfo.md
// │  │  ├──FileSystemNode.md
// │  │  ├──GetNodes.md
// │  │  └──ToString.md
// │  ├──SearchSettings\
// │  │  ├──Comparer.md
// │  │  ├──IncludeFiles.md
// │  │  └──SearchSettings.md
// │  ├──DirectoriesFirstComparer.md
// │  ├──FileSystemNode.md
// │  └──SearchSettings.md
// └──ConsoleTree.FileSystem.md
```

## Resources

See the [API reference](https://github.com/maurizuki/ConsoleTree.FileSystem/blob/v1.0.0/docs/ConsoleTree.FileSystem.md) and the [ConsoleTree.FileSystem.Demo](https://github.com/maurizuki/ConsoleTree.FileSystem/tree/v1.0.0/src/ConsoleTree.FileSystem.Demo) application for further informations. See also the [ConsoleTree API reference](https://github.com/maurizuki/ConsoleTree/blob/main/docs/ConsoleTree.md) to learn how to customize indentation, maximum depth, type of connectors and colors.
