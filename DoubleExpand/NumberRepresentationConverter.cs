using System.Runtime.InteropServices;

namespace DoubleExtend
{
    /// <summary>
    /// Converter of numbers
    /// </summary>
    public static class NumberRepresentationConverter
    {
        /// <summary>
        /// Number of bits in byte
        /// </summary>
        private const int BITS_IN_BYTE = 8;

        /// <summary>
        /// Converts from double to string of its binary representation
        /// </summary>
        /// <param name="number">
        /// Double number
        /// </param>
        /// <returns>
        /// Binary representation
        /// </returns>
        public static string DoubleToBinaryString(this double number)
        {           
            string binaryString = null;
            DoubleToLongStruct numberStruct = new DoubleToLongStruct(number);
            long numberLong = numberStruct.Long64bits;

            for (int i = 0; i < 8 * BITS_IN_BYTE; i++)
            {
                if ((numberLong & 1) == 1)
                {
                    binaryString += "1";
                }
                else
                {
                    binaryString += "0";
                }

                numberLong >>= 1;
            }

            return Reverse(binaryString);
        }

        private static string Reverse(string strait)
        {
            string reversed = null;
            for (int i = strait.Length - 1; i >= 0; i--)
            {
                reversed += strait[i];
            }

            return reversed;
        }

        /// <summary>
        /// Has Double and Long number at one field offset
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            /// <summary>
            /// Long number
            /// </summary>
            [FieldOffset(0)]
            private readonly long long64bits;

            /// <summary>
            /// Double number
            /// </summary>
            [FieldOffset(0)]
            private readonly double double64bits;

            /// <summary>
            /// Initializes a new instance of the <see cref="DoubleToLongStruct"/> struct.
            /// </summary>
            /// <param name="number">
            /// Double number
            /// </param>
            public DoubleToLongStruct(double number)
            {
                long64bits = 0;
                double64bits = number;
            }

            /// <summary>
            /// Gets long64bits 
            /// </summary>
            public long Long64bits
            {
                get
                {
                    return long64bits;
                }
            }
        }
    }
}
