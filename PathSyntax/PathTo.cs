using JetBrains.Annotations;
using System;
using System.IO;

namespace PathSyntax
{
    [PublicAPI]
    public sealed class PathTo : IEquatable<PathTo>
    {
        private string Path { get; }



        private PathTo(string path) => Path = path;

        public static PathTo operator /(PathTo first, PathTo second) => System.IO.Path.Combine(first, second);
        public static PathTo operator /(PathTo first, string second) => System.IO.Path.Combine(first, second);
        public static PathTo operator /(string first, PathTo second) => System.IO.Path.Combine(first, second);

        public static implicit operator string(PathTo value) => value.Path;

        public static implicit operator PathTo(string value) => new PathTo(value);

        public bool Equals(PathTo other) => !(other is null) && (ReferenceEquals(this, other) || string.Equals(Path, other.Path));

        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj is PathTo other && Equals(other);

        public override int GetHashCode() => Path?.GetHashCode() ?? 0;

        public override string ToString() => Path;
    }
}