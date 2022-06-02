# FileSystemNode class

Represents a node of the file system tree structure.

```csharp
public class FileSystemNode : ITreeNode
```

## Public Members

| name | description |
| --- | --- |
| [FileSystemNode](FileSystemNode/FileSystemNode.md)(…) | Initializes a new instance of the [`FileSystemNode`](./FileSystemNode.md) class with the specified directory path. (2 constructors) |
| [FileSystemInfo](FileSystemNode/FileSystemInfo.md) { get; } | Gets the `FileSystemInfo` relative to the node of the file system tree structure. |
| [GetNodes](FileSystemNode/GetNodes.md)() | Returns a collection of the subnodes of the node. |
| override [ToString](FileSystemNode/ToString.md)() | Returns the name of the directory with a trailing directory separator character or the name of the file. |

## See Also

* namespace [ConsoleTree.FileSystem](../ConsoleTree.FileSystem.md)

<!-- DO NOT EDIT: generated by xmldocmd for ConsoleTree.FileSystem.dll -->