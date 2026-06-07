using System;
using System.Collections.Generic;
using System.Linq;

namespace ReedSolomon
{
	internal sealed class ReedSolomonEncoder
	{
		private readonly GenericGF field;

		private readonly IList<GenericGFPoly> cachedGenerators;

		public ReedSolomonEncoder(GenericGF field)
		{
			this.field = field;
			cachedGenerators = new List<GenericGFPoly>();
			cachedGenerators.Add(new GenericGFPoly(field, new int[1] { 1 }));
		}

		private GenericGFPoly BuildGenerator(int degree)
		{
			if (degree >= cachedGenerators.Count)
			{
				GenericGFPoly genericGFPoly = cachedGenerators[cachedGenerators.Count - 1];
				for (int i = cachedGenerators.Count; i <= degree; i++)
				{
					GenericGFPoly genericGFPoly2 = genericGFPoly.Multiply(new GenericGFPoly(field, new int[2]
					{
						1,
						field.Exp(i - 1 + field.GeneratorBase)
					}));
					cachedGenerators.Add(genericGFPoly2);
					genericGFPoly = genericGFPoly2;
				}
			}
			return cachedGenerators[degree];
		}

		public void Encode(int[] toEncode, int ecBytes)
		{
			if (ecBytes == 0)
			{
				throw new ArgumentException("No error correction bytes");
			}
			int num = toEncode.Length - ecBytes;
			if (num <= 0)
			{
				throw new ArgumentException("No data bytes provided");
			}
			GenericGFPoly other = BuildGenerator(ecBytes);
			int[] array = new int[num];
			Array.Copy(toEncode, 0, array, 0, num);
			int[] coefficients = new GenericGFPoly(field, array).MultiplyByMonomial(ecBytes, 1).Divide(other)[1].Coefficients;
			int num2 = ecBytes - coefficients.Length;
			for (int i = 0; i < num2; i++)
			{
				toEncode[num + i] = 0;
			}
			Array.Copy(coefficients, 0, toEncode, num + num2, coefficients.Length);
		}

		public byte[] EncodeEx(byte[] toEncode, int ecBytes)
		{
			if (ecBytes == 0)
			{
				throw new ArgumentException("No error correction bytes");
			}
			if (toEncode.Length - ecBytes <= 0)
			{
				throw new ArgumentException("No data bytes provided");
			}
			GenericGFPoly other = BuildGenerator(ecBytes);
			int[] coefficients = ((IEnumerable<byte>)toEncode).Select((Func<byte, int>)((byte x) => x)).ToArray();
			int[] coefficients2 = new GenericGFPoly(field, coefficients).MultiplyByMonomial(ecBytes, 1).Divide(other)[1].Coefficients;
			int count = ecBytes - coefficients2.Length;
			return Enumerable.Repeat((byte)0, count).Concat(coefficients2.Select((int x) => (byte)x)).ToArray();
		}
	}
}
