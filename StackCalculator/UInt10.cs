using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    public struct UInt10
    {
        private UInt10(ushort value)
        {
            if (value >= (1 << 10))
                throw new ArgumentOutOfRangeException(nameof(value));

            this.value = value;
        }

        private readonly ushort value;

        public static implicit operator UInt10(ushort value)
        {
            return new UInt10(value);
        }

        public static explicit operator UInt10(string value)
        {
            return new UInt10(Convert.ToUInt16(value));
        }

        public static explicit operator ushort(UInt10 uint10)
        {
            return uint10.value;
        }

        public static UInt10 operator +(UInt10 a, UInt10 b)
        {
            var result = a.value + b.value;

            if (result >= (1 << 10))
                return (UInt10)(result - (1 << 10));

            return (UInt10)result;
        }
        
        public static UInt10 operator -(UInt10 a, UInt10 b)
        {
            var result = a.value - b.value;

            if (result < 0)
                return (UInt10)((1 << 10) + result);

            return (UInt10)(a.value - b.value);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
