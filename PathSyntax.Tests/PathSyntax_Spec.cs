using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using static PathSyntax.PathSyntax;
namespace PathSyntax.Tests
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PathSyntax_Spec
    {
        private static readonly char Separator = Path.DirectorySeparatorChar;
        [TestCase("C:", "","C:")]
        [TestCase("", "Users","Users")]
        public void ShouldCombineSimplePaths_WhenOneIsEmpty(string first, string second, string expected)
        {
            (first.AsPath() / second).Should().BeEquivalentTo(expected.AsPath());
        }

        [Test]
        public void ShouldCombinePaths_WhenBothHaveSeparators()
        {
            ($"C:{Separator}".AsPath() / $"allUsers{Separator}users").Should().BeEquivalentTo($"C:{Separator}allUsers{Separator}users".AsPath());
        }
        [Test]
        public void ShouldCombinePaths_WhenOneHasSeparators()
        {
            ($"C:{Separator}".AsPath() / "users").Should().BeEquivalentTo($"C:{Separator}users".AsPath());
        }

        [TestCase()]
        public void ShouldUseStaticRoots()
        {
            //see "using static PathSyntax.PathSyntax;" in the beginning of the file;
            (CDrive / "users" / "user" / "file").Should().BeEquivalentTo($"C:{Separator}users{Separator}user{Separator}file".AsPath());
        }
        [TestCase()]
        public void ShouldCombineSimpleSequences()
        {
            (".".AsPath() / "users" / "user" / "file").Should().BeEquivalentTo($".{Separator}users{Separator}user{Separator}file".AsPath());
        }

    }
}