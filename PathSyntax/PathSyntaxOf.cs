using System;
using JetBrains.Annotations;

namespace PathSyntax
{
    [PublicAPI]
    public static class PathSyntaxOf
    {
        public static PathTo AsPath(this string part) => part;
    }
}
