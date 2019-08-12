using System;
using JetBrains.Annotations;

namespace PathSyntax
{
    [PublicAPI]
    public static class PathSyntaxOf
    {
        public static PathSyntax AsPath(this string part) => part;
    }
}
