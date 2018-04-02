﻿using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Kingdom.Collections
{
    using CombinatorialValuesAttribute = ValuesAttribute; // xunit bridge

    public class SpecificIntValuesAttribute : CombinatorialValuesAttribute
    {
        private static IEnumerable<object> GetValues()
        {
            const uint nibble = 0x0001;
            yield return nibble;
            yield return nibble << 8;
            yield return nibble << 16;
            yield return nibble << 24;
        }

        private static Lazy<object[]> LazyValues { get; }
            = new Lazy<object[]>(() => GetValues().ToArray());

        internal SpecificIntValuesAttribute()
            : base(LazyValues.Value)
        {
        }
    }
}