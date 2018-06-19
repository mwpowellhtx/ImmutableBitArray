﻿using System.Collections.Generic;

namespace Kingdom.Collections.Bitwises
{
    using Xunit;
    using Xunit.Abstractions;
    using static CardinalDirection;

    public class CardinalDirectionTests : BitwiseEnumerationTestsBase<CardinalDirection>
    {
        /// <summary>
        /// Life cycle management is critical here, especially with subtle differences between
        /// XUnit and NUnit run time approaches. XUnit will manage the life cycles of the
        /// injected parameters for us. Whereas, with NUnit, we should provide new'ed up
        /// instances to the base class ourselves.
        /// </summary>
        /// <param name="outputHelper"></param>
        /// <param name="reporter"></param>
        /// <inheritdoc />
        public CardinalDirectionTests(ITestOutputHelper outputHelper
            , EnumerationCoverageReporter<CardinalDirection> reporter)
            : base(outputHelper, reporter)
        {
        }

        public static readonly IEnumerable<object[]> TestValues;

        private static IEnumerable<object[]> GetTestValues()
        {
            /* Yay for C# 7 goodness! Function implemented LOCAL FUNCTIONS! Also, note the
             subtle changes; just accept the referenced Index 'x' and do the incremental
             progress within. */
            byte[] NextBytes(ref int x) => new[] {(byte) (1 << ++x)};

            // Make sure that these Extension methods are Internals Visible to this assembly.
            string GetDisplayName(string s) => s.GetHumanReadableCamelCase();

            var shift = -1;

            yield return new object[] {NextBytes(ref shift), nameof(North), nameof(North)};
            yield return new object[] {NextBytes(ref shift), nameof(NorthWest), GetDisplayName(nameof(NorthWest))};
            yield return new object[] {NextBytes(ref shift), nameof(West), nameof(West)};
            yield return new object[] {NextBytes(ref shift), nameof(SouthWest), GetDisplayName(nameof(SouthWest))};
            yield return new object[] {NextBytes(ref shift), nameof(South), nameof(South)};
            yield return new object[] {NextBytes(ref shift), nameof(SouthEast), GetDisplayName(nameof(SouthEast))};
            yield return new object[] {NextBytes(ref shift), nameof(East), nameof(East)};
            yield return new object[] {NextBytes(ref shift), nameof(NorthEast), GetDisplayName(nameof(NorthEast))};
        }

        static CardinalDirectionTests()
        {
            TestValues = GetTestValues();
        }

#pragma warning disable xUnit1008 // Test data attribute should only be used on a Theory
        [MemberData(nameof(TestValues))]
        public override void Verify_Bitwise_Enumeration_bits(byte[] bytes, string name, string displayName)
        {
            base.Verify_Bitwise_Enumeration_bits(bytes, name, displayName);
        }
#pragma warning restore xUnit1008 // Test data attribute should only be used on a Theory

    }
}
