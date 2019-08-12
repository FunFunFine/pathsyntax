# PathSyntax library
Think about path separator no more! Use compile-time checked path building with this library;
This library converts C# operator `/` to "/" or "\\" depending on system it runs on;
# Examples
* Building path from scratch
```csharp
using PathSyntax;

var path = (PathTo) "some" / "nested" / "file.f";
```
or without cast
```csharp
using PathSyntax;

var pathWithoutCast =  "some".AsPath() / "path" / "to.file";
```

* Using built-in usual roots
```csharp
using static PathSyntax.Roots;

var pathFromC = CDrive / "Users"; //C:\Users or C:/Users at UNIX

var pathFromCurrentDirectory = CurrentDirectory / "file.f"
// OR
var pathStartingWithDot = Dot / "file.f"

// both of the above gives ./file.f

```
