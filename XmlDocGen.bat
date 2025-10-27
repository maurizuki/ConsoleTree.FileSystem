dotnet build src\XmlDocGen\XmlDocGen.csproj -c Release -o bin
bin\XmlDocGen.exe bin\ConsoleTree.FileSystem.dll docs --clean
