﻿using System;
using Xunit;

namespace Lessons._06
{
    /// <summary>
    /// Let Money implement IConvertible.
    /// Implement only methods from the convertions below.
    /// Write unit tests to cover the cases.
    /// 
    /// Convert.ToDecimal(new Money(1234.50M, "USD"));   // 1234.50M 
    /// Convert.ToInt32(new Money(1234.50M, "USD"));     // InvalidCastException
    /// Convert.ToInt32(new Money(1234, "USD"));     // 1234
    /// Convert.ToBoolean(new Money(1234, "USD"));  // InvalidCastException
    /// </summary>
    public class TaskB
    {
        [Fact]
        public void ToDecimal_ForAnyValidMoney_ShouldReturnItsAmount()
        {
            var result = Convert.ToDecimal(new Money(1234.50M, "USD"));
            Assert.Equal(1234.50M, result);
        }

        [Fact]
        public void ToInt32_ForDecimalValues_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToInt32(new Money(1234.50M, "USD")));   
        }

        [Fact]
        public void ToInt32_ForNumberWithoutDecimalPart_ShouldReturnInteger()
        {
            var result = Convert.ToInt32(new Money(1234, "USD"));
            Assert.Equal(1234, result);
        }

        [Fact]
        public void ToBoolean_ForDecimalValue_ShouldThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(new Money(1234, "USD")));
        }

        // Implement missing tests

        class Money : IConvertible
        {
            public Money(decimal amount, string currency)
            {
                Amount = amount;
                Currency = currency;
            }

            decimal Amount { get; }
            string Currency { get; }

            public TypeCode GetTypeCode()
            {
                throw new NotImplementedException();
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new InvalidCastException();
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                if (Math.Round(Amount) != Amount) throw new InvalidCastException();
                return (int) Amount;
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public long ToInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                return Amount;
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public string ToString(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                throw new NotImplementedException();
            }
        }
    }
}