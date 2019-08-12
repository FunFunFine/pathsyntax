using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using static PathSyntax.Roots;
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
            ((PathTo) first / second).Should().BeEquivalentTo(expected.AsPath());
        }

        [Test]
        public void ShouldCombinePaths_WhenBothHaveSeparators()
        {
            ((PathTo)$"C:{Separator}" / $"allUsers{Separator}users").Should().BeEquivalentTo($"C:{Separator}allUsers{Separator}users".AsPath());
        }
        [Test]
        public void ShouldCombinePaths_WhenOneHasSeparators()
        {
            ((PathTo)$"C:{Separator}" / "users").Should().BeEquivalentTo($"C:{Separator}users".AsPath());
        }

        [TestCase()]
        public void ShouldUseStaticRoots()
        {
            //see "using static PathTo.PathTo;" in the beginning of the file;
            (CDrive / "users" / "user" / "file").Should().BeEquivalentTo($"C:{Separator}users{Separator}user{Separator}file".AsPath());
        }
        [TestCase()]
        public void ShouldCombineSimpleSequences()
        {
            ((PathTo)"." / "users" / "user" / "file").Should().BeEquivalentTo($".{Separator}users{Separator}user{Separator}file".AsPath());
        }

    }
}