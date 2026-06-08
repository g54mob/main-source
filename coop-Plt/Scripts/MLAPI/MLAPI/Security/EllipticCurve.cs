using System;
using System.Collections.Generic;
using MLAPI.Serialization;

namespace MLAPI.Security
{
	internal class EllipticCurve
	{
		public enum CurveType
		{
			Weierstrass = 0,
			Montgomery = 1
		}

		protected readonly BigInteger a;

		protected readonly BigInteger b;

		protected readonly BigInteger modulo;

		protected readonly CurveType type;

		public EllipticCurve(BigInteger a, BigInteger b, BigInteger modulo, CurveType type = CurveType.Weierstrass)
		{
			if ((type == CurveType.Weierstrass && 4 * a * a * a + 27 * b * b == 0) || (type == CurveType.Montgomery && b * (a * a - 4) == 0))
			{
				throw new Exception("Unfavourable curve");
			}
			this.a = a;
			this.b = b;
			this.modulo = modulo;
			this.type = type;
		}

		public CurvePoint Add(CurvePoint p1, CurvePoint p2)
		{
			if (p1 == CurvePoint.POINT_AT_INFINITY && p2 == CurvePoint.POINT_AT_INFINITY)
			{
				return CurvePoint.POINT_AT_INFINITY;
			}
			if (p1 == CurvePoint.POINT_AT_INFINITY)
			{
				return p2;
			}
			if (p2 == CurvePoint.POINT_AT_INFINITY)
			{
				return p1;
			}
			if (p1.X == p2.X && p1.Y == Inverse(p2).Y)
			{
				return CurvePoint.POINT_AT_INFINITY;
			}
			BigInteger bigInteger = 0;
			BigInteger y = 0;
			if (type == CurveType.Weierstrass)
			{
				BigInteger bigInteger2 = ((p1.X == p2.X && p1.Y == p2.Y) ? Mod((3 * p1.X * p1.X + a) * MulInverse(2 * p1.Y)) : Mod(Mod(p2.Y - p1.Y) * MulInverse(p2.X - p1.X)));
				bigInteger = Mod(bigInteger2 * bigInteger2 - p1.X - p2.X);
				y = Mod(-(bigInteger2 * bigInteger + p1.Y - bigInteger2 * p1.X));
			}
			else if (type == CurveType.Montgomery)
			{
				if (p1.X == p2.X && p1.Y == p2.Y)
				{
					BigInteger bigInteger3 = 3 * p1.X;
					BigInteger bigInteger4 = bigInteger3 * p1.X;
					BigInteger bigInteger5 = 2 * a;
					BigInteger bigInteger6 = bigInteger5 * p1.X;
					BigInteger bigInteger7 = 2 * b;
					BigInteger eq = bigInteger7 * p1.Y;
					BigInteger bigInteger8 = MulInverse(eq);
					BigInteger bigInteger9 = bigInteger4 + bigInteger5 + 1;
					BigInteger bigInteger10 = bigInteger9 * bigInteger8;
				}
				BigInteger bigInteger11 = ((p1.X == p2.X && p1.Y == p2.Y) ? Mod((3 * p1.X * p1.X + 2 * a * p1.X + 1) * MulInverse(2 * b * p1.Y)) : Mod(Mod(p2.Y - p1.Y) * MulInverse(p2.X - p1.X)));
				bigInteger = Mod(b * bigInteger11 * bigInteger11 - a - p1.X - p2.X);
				y = Mod((2 * p1.X + p2.X + a) * bigInteger11 - b * bigInteger11 * bigInteger11 * bigInteger11 - p1.Y);
			}
			return new CurvePoint(bigInteger, y);
		}

		public CurvePoint Multiply(CurvePoint p, BigInteger scalar)
		{
			if (scalar <= 0)
			{
				throw new Exception("Cannot multiply by a scalar which is <= 0");
			}
			if (p == CurvePoint.POINT_AT_INFINITY)
			{
				return CurvePoint.POINT_AT_INFINITY;
			}
			CurvePoint curvePoint = new CurvePoint(p.X, p.Y);
			uint[] internalState = scalar.GetInternalState();
			long num = -1L;
			int num2 = internalState.Length - 1;
			while (num2 >= 0)
			{
				int num3;
				if (internalState[num2] != 0)
				{
					num3 = 31;
					while (num3 >= 0)
					{
						if ((internalState[num2] & (1 << num3)) == 0L)
						{
							num3--;
							continue;
						}
						goto IL_0065;
					}
				}
				num2--;
				continue;
				IL_0065:
				num = num3 + num2 * 32;
				break;
			}
			while (num >= 0)
			{
				curvePoint = Add(curvePoint, curvePoint);
				if (internalState.BitAt(num))
				{
					curvePoint = Add(curvePoint, p);
				}
				num--;
			}
			return curvePoint;
		}

		protected BigInteger MulInverse(BigInteger eq)
		{
			return MulInverse(eq, modulo);
		}

		public static BigInteger MulInverse(BigInteger eq, BigInteger modulo)
		{
			eq = Mod(eq, modulo);
			Stack<BigInteger> stack = new Stack<BigInteger>();
			BigInteger bigInteger = modulo;
			BigInteger bigInteger2;
			while ((bigInteger2 = bigInteger % eq) != 0)
			{
				stack.Push(-bigInteger / eq);
				bigInteger = eq;
				eq = bigInteger2;
			}
			if (stack.Count == 0)
			{
				return 1;
			}
			bigInteger = 1;
			bigInteger2 = stack.Pop();
			while (stack.Count > 0)
			{
				eq = bigInteger2;
				bigInteger2 = bigInteger + bigInteger2 * stack.Pop();
				bigInteger = eq;
			}
			return Mod(bigInteger2, modulo);
		}

		public CurvePoint Inverse(CurvePoint p)
		{
			return Inverse(p, modulo);
		}

		protected static CurvePoint Inverse(CurvePoint p, BigInteger modulo)
		{
			return new CurvePoint(p.X, Mod(-p.Y, modulo));
		}

		public bool IsOnCurve(CurvePoint p)
		{
			try
			{
				CheckOnCurve(p);
			}
			catch
			{
				return false;
			}
			return true;
		}

		protected void CheckOnCurve(CurvePoint p)
		{
			if ((p != CurvePoint.POINT_AT_INFINITY && type == CurveType.Weierstrass && Mod(p.Y * p.Y) != Mod(p.X * p.X * p.X + p.X * a + b)) || (type == CurveType.Montgomery && Mod(b * p.Y * p.Y) != Mod(p.X * p.X * p.X + p.X * p.X * a + p.X)))
			{
				throw new Exception("Point is not on curve");
			}
		}

		protected BigInteger Mod(BigInteger b)
		{
			return Mod(b, modulo);
		}

		private static BigInteger Mod(BigInteger x, BigInteger m)
		{
			BigInteger bigInteger = ((x.Abs() > m) ? (x % m) : x);
			if (!(bigInteger < 0))
			{
				return bigInteger;
			}
			return bigInteger + m;
		}

		protected static BigInteger ModPow(BigInteger x, BigInteger power, BigInteger prime)
		{
			BigInteger result = 1;
			bool flag = false;
			while (power > 0)
			{
				x %= prime;
				flag = (power & 1) == 1;
				power >>= 1;
				if (flag)
				{
					result *= x;
				}
				x *= x;
			}
			return result;
		}
	}
}
