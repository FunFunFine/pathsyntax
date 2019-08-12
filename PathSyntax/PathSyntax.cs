using JetBrains.Annotations;
using System;
using System.IO;

namespace PathSyntax
{
    [PublicAPI]
    public sealed class PathSyntax : IEquatable<PathSyntax>
    {
        private string Part { get; }

        public static PathSyntax CDrive => "C:";
        public static PathSyntax Empty => "";
        public static PathSyntax CurrentDirectory => ".";
        public static PathSyntax BackDirectory => "..";

        private PathSyntax(string path) => Part = path;

        public static PathSyntax operator /(PathSyntax first, PathSyntax second) => Path.Combine(first, second);
        public static PathSyntax operator /(PathSyntax first, string second) => Path.Combine(first, second);
        public static PathSyntax operator /(string first, PathSyntax second) => Path.Combine(first, second);

        public static implicit operator string(PathSyntax value) => value.Part;

        public static implicit operator PathSyntax(string value) => new PathSyntax(value);

        public bool Equals(PathSyntax other) => !(other is null) && (ReferenceEquals(this, other) || string.Equals(Part, other.Part));

        public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj is PathSyntax other && Equals(other);

        public override int GetHashCode() => Part?.GetHashCode() ?? 0;

        public override string ToString() => Part;
    }
}