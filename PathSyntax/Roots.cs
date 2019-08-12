using JetBrains.Annotations;

namespace PathSyntax
{
    [PublicAPI]
    public static class Roots
    {
        public static PathTo CDrive => "C:";
        public static PathTo DDrive => "D:";
        public static PathTo Empty => "";
        public static PathTo CurrentDirectory => ".";
        public static PathTo Dot => CurrentDirectory;
        public static PathTo PreviousDirectory => "..";
    }
}