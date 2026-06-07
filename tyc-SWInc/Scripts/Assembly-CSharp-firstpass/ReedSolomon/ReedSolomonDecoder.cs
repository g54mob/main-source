using System;
using System.Collections.Generic;
using System.Linq;

namespace ReedSolomon
{
	internal sealed class ReedSolomonDecoder
	{
		private readonly GenericGF field;

		public ReedSolomonDecoder(GenericGF field)
		{
			this.field = field;
		}

		public bool Decode(int[] received, int twoS)
		{
			GenericGFPoly genericGFPoly = new GenericGFPoly(field, received);
			int[] array = new int[twoS];
			bool flag = true;
			for (int i = 0; i < twoS; i++)
			{
				int num = genericGFPoly.EvaluateAt(field.Exp(i + field.GeneratorBase));
				array[array.Length - 1 - i] = num;
				if (num != 0)
				{
					flag = false;
				}
			}
			if (flag)
			{
				return true;
			}
			GenericGFPoly b = new GenericGFPoly(field, array);
			GenericGFPoly[] array2 = RunEuclideanAlgorithm(field.BuildMonomial(twoS, 1), b, twoS);
			if (array2 == null)
			{
				return false;
			}
			GenericGFPoly errorLocator = array2[0];
			int[] array3 = FindErrorLocations(errorLocator);
			if (array3 == null)
			{
				return false;
			}
			GenericGFPoly errorEvaluator = array2[1];
			int[] array4 = FindErrorMagnitudes(errorEvaluator, array3);
			for (int j = 0; j < array3.Length; j++)
			{
				int num2 = received.Length - 1 - field.Log(array3[j]);
				if (num2 < 0)
				{
					return false;
				}
				received[num2] = GenericGF.AddOrSubtract(received[num2], array4[j]);
			}
			return true;
		}

		public byte[] DecodeEx(byte[] message, byte[] ecc)
		{
			int[] array = ((IEnumerable<byte>)message).Select((Func<byte, int>)((byte x) => x)).Concat(((IEnumerable<byte>)ecc).Select((Func<byte, int>)((byte x) => x))).ToArray();
			if (!Decode(array, ecc.Length))
			{
				return null;
			}
			return (from x in array.Take(message.Length)
				select (byte)x).ToArray();
		}

		internal GenericGFPoly[] RunEuclideanAlgorithm(GenericGFPoly a, GenericGFPoly b, int R)
		{
			if (a.Degree < b.Degree)
			{
				GenericGFPoly genericGFPoly = a;
				a = b;
				b = genericGFPoly;
			}
			GenericGFPoly genericGFPoly2 = a;
			GenericGFPoly genericGFPoly3 = b;
			GenericGFPoly genericGFPoly4 = field.Zero;
			GenericGFPoly genericGFPoly5 = field.One;
			int num = R / 2;
			while (genericGFPoly3.Degree >= num)
			{
				GenericGFPoly genericGFPoly6 = genericGFPoly2;
				GenericGFPoly other = genericGFPoly4;
				genericGFPoly2 = genericGFPoly3;
				genericGFPoly4 = genericGFPoly5;
				if (genericGFPoly2.IsZero)
				{
					return null;
				}
				genericGFPoly3 = genericGFPoly6;
				GenericGFPoly genericGFPoly7 = field.Zero;
				int coefficient = genericGFPoly2.GetCoefficient(genericGFPoly2.Degree);
				int b2 = field.Inverse(coefficient);
				while (genericGFPoly3.Degree >= genericGFPoly2.Degree && !genericGFPoly3.IsZero)
				{
					int degree = genericGFPoly3.Degree - genericGFPoly2.Degree;
					int coefficient2 = field.Multiply(genericGFPoly3.GetCoefficient(genericGFPoly3.Degree), b2);
					genericGFPoly7 = genericGFPoly7.AddOrSubtract(field.BuildMonomial(degree, coefficient2));
					genericGFPoly3 = genericGFPoly3.AddOrSubtract(genericGFPoly2.MultiplyByMonomial(degree, coefficient2));
				}
				genericGFPoly5 = genericGFPoly7.Multiply(genericGFPoly4).AddOrSubtract(other);
				if (genericGFPoly3.Degree >= genericGFPoly2.Degree)
				{
					return null;
				}
			}
			int coefficient3 = genericGFPoly5.GetCoefficient(0);
			if (coefficient3 == 0)
			{
				return null;
			}
			int scalar = field.Inverse(coefficient3);
			GenericGFPoly genericGFPoly8 = genericGFPoly5.Multiply(scalar);
			GenericGFPoly genericGFPoly9 = genericGFPoly3.Multiply(scalar);
			return new GenericGFPoly[2] { genericGFPoly8, genericGFPoly9 };
		}

		private int[] FindErrorLocations(GenericGFPoly errorLocator)
		{
			int degree = errorLocator.Degree;
			if (degree == 1)
			{
				return new int[1] { errorLocator.GetCoefficient(1) };
			}
			int[] array = new int[degree];
			int num = 0;
			for (int i = 1; i < field.Size; i++)
			{
				if (num >= degree)
				{
					break;
				}
				if (errorLocator.EvaluateAt(i) == 0)
				{
					array[num] = field.Inverse(i);
					num++;
				}
			}
			if (num != degree)
			{
				return null;
			}
			return array;
		}

		private int[] FindErrorMagnitudes(GenericGFPoly errorEvaluator, int[] errorLocations)
		{
			int num = errorLocations.Length;
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = field.Inverse(errorLocations[i]);
				int a = 1;
				for (int j = 0; j < num; j++)
				{
					if (i != j)
					{
						int num3 = field.Multiply(errorLocations[j], num2);
						int b = (((num3 & 1) == 0) ? (num3 | 1) : (num3 & -2));
						a = field.Multiply(a, b);
					}
				}
				array[i] = field.Multiply(errorEvaluator.EvaluateAt(num2), field.Inverse(a));
				if (field.GeneratorBase != 0)
				{
					array[i] = field.Multiply(array[i], num2);
				}
			}
			return array;
		}
	}
}
