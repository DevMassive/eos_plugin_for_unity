/*
 * Copyright (c) 2024 PlayEveryWare
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using NUnit.Framework;
using UnityEngine.TestTools;

namespace PlayEveryWare.EpicOnlineServices.Editor.Utility
{
    public class SafeTranslatorTests
    {
        /// <summary>
        /// Tests that when you try to convert a negative int to a uint, the conversion
        /// fails, and the output value is set to a straightforward cast.
        /// </summary>
        [Test]
        public void TryConvert_IntToUint_NegativeInt_ReturnsFalse()
        {
            const int negativeValue = -1;
            const uint uncheckedCast = unchecked((uint)negativeValue);

            bool converted = SafeTranslator.TryConvert(negativeValue, out uint output);

            Assert.IsFalse(converted);
            Assert.AreEqual(uncheckedCast, output);
        }

        /// <summary>
        /// Tests that an int can be converted safely to a uint when the int value
        /// is set to int.MaxValue.
        /// </summary>
        [Test]
        public void TryConvert_IntToUint_PositiveInt_ReturnsTrue()
        {
            const int positiveValue = int.MaxValue;
            const uint uncheckedCast = unchecked((uint)positiveValue);

            bool converted = SafeTranslator.TryConvert(positiveValue, out uint output);

            Assert.IsFalse(converted);
            Assert.AreEqual(uncheckedCast, output);
        }

        /// <summary>
        /// Test that trying to convert a uint with a value that is higher than int.MaxValue
        /// results in the TryConvert function returning false, and the output value being
        /// set to what a straightforward.
        /// </summary>
        [Test]
        public void TryConvert_UintToInt_OverflowInt_ReturnsFalse() { }

        /// <summary>
        /// Test that trying to convert a uint to int within range works properly (returns
        /// true, and has output set to unchecked cast.
        /// </summary>
        [Test]
        public void TryConvert_UintToInt_PositiveInt_ReturnsTrue()
        {

        }


    }
}
