using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MLAPI.Security
{
	internal class BigInteger
	{
		private const int MaxLength = 70;

		public static readonly int[] PrimesBelow2000 = new int[303]
		{
			2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
			31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
			73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
			127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
			179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
			233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
			283, 293, 307, 311, 313, 317, 331, 337, 347, 349,
			353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
			419, 421, 431, 433, 439, 443, 449, 457, 461, 463,
			467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
			547, 557, 563, 569, 571, 577, 587, 593, 599, 601,
			607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
			661, 673, 677, 683, 691, 701, 709, 719, 727, 733,
			739, 743, 751, 757, 761, 769, 773, 787, 797, 809,
			811, 821, 823, 827, 829, 839, 853, 857, 859, 863,
			877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
			947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013,
			1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069,
			1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151,
			1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223,
			1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291,
			1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373,
			1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451,
			1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511,
			1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583,
			1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657,
			1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733,
			1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811,
			1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889,
			1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987,
			1993, 1997, 1999
		};

		private uint[] _data;

		public int DataLength;

		public BigInteger()
		{
			_data = new uint[70];
			DataLength = 1;
		}

		public BigInteger(long value)
		{
			_data = new uint[70];
			long num = value;
			DataLength = 0;
			while (value != 0L && DataLength < 70)
			{
				_data[DataLength] = (uint)(value & 0xFFFFFFFFu);
				value >>= 32;
				DataLength++;
			}
			if (num > 0)
			{
				if (value != 0L || (_data[69] & 0x80000000u) != 0)
				{
					throw new ArithmeticException("Positive overflow in constructor.");
				}
			}
			else if (num < 0 && (value != -1 || (_data[DataLength - 1] & 0x80000000u) == 0))
			{
				throw new ArithmeticException("Negative underflow in constructor.");
			}
			if (DataLength == 0)
			{
				DataLength = 1;
			}
		}

		public BigInteger(ulong value)
		{
			_data = new uint[70];
			DataLength = 0;
			while (value != 0L && DataLength < 70)
			{
				_data[DataLength] = (uint)(value & 0xFFFFFFFFu);
				value >>= 32;
				DataLength++;
			}
			if (value != 0L || (_data[69] & 0x80000000u) != 0)
			{
				throw new ArithmeticException("Positive overflow in constructor.");
			}
			if (DataLength == 0)
			{
				DataLength = 1;
			}
		}

		public BigInteger(BigInteger bi)
		{
			_data = new uint[70];
			DataLength = bi.DataLength;
			for (int i = 0; i < DataLength; i++)
			{
				_data[i] = bi._data[i];
			}
		}

		public BigInteger(string value, int radix = 10)
		{
			BigInteger bigInteger = new BigInteger(1L);
			BigInteger bigInteger2 = new BigInteger();
			value = value.ToUpper().Trim();
			int num = 0;
			if (value[0] == '-')
			{
				num = 1;
			}
			for (int num2 = value.Length - 1; num2 >= num; num2--)
			{
				int num3 = value[num2];
				num3 = ((num3 >= 48 && num3 <= 57) ? (num3 - 48) : ((num3 < 65 || num3 > 90) ? 9999999 : (num3 - 65 + 10)));
				if (num3 >= radix)
				{
					throw new ArithmeticException("Invalid string in constructor.");
				}
				if (value[0] == '-')
				{
					num3 = -num3;
				}
				bigInteger2 += bigInteger * num3;
				if (num2 - 1 >= num)
				{
					bigInteger *= (BigInteger)radix;
				}
			}
			if (value[0] == '-')
			{
				if ((bigInteger2._data[69] & 0x80000000u) == 0)
				{
					throw new ArithmeticException("Negative underflow in constructor.");
				}
			}
			else if ((bigInteger2._data[69] & 0x80000000u) != 0)
			{
				throw new ArithmeticException("Positive overflow in constructor.");
			}
			_data = new uint[70];
			for (int i = 0; i < bigInteger2.DataLength; i++)
			{
				_data[i] = bigInteger2._data[i];
			}
			DataLength = bigInteger2.DataLength;
		}

		public BigInteger(byte[] inData)
			: this(inData, -1, 0)
		{
		}

		public BigInteger(IList<byte> inData, int length = -1, int offset = 0)
		{
			int num = ((length == -1) ? (inData.Count - offset) : length);
			DataLength = num >> 2;
			int num2 = num & 3;
			if (num2 != 0)
			{
				DataLength++;
			}
			if (DataLength > 70 || num > inData.Count - offset)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			_data = new uint[70];
			int num3 = num - 1;
			int num4 = 0;
			while (num3 >= 3)
			{
				_data[num4] = (uint)((inData[offset + num3 - 3] << 24) + (inData[offset + num3 - 2] << 16) + (inData[offset + num3 - 1] << 8) + inData[offset + num3]);
				num3 -= 4;
				num4++;
			}
			switch (num2)
			{
			case 1:
				_data[DataLength - 1] = inData[offset];
				break;
			case 2:
				_data[DataLength - 1] = (uint)((inData[offset] << 8) + inData[offset + 1]);
				break;
			case 3:
				_data[DataLength - 1] = (uint)((inData[offset] << 16) + (inData[offset + 1] << 8) + inData[offset + 2]);
				break;
			}
			if (DataLength == 0)
			{
				DataLength = 1;
			}
			while (DataLength > 1 && _data[DataLength - 1] == 0)
			{
				DataLength--;
			}
		}

		public BigInteger(uint[] inData)
		{
			DataLength = inData.Length;
			if (DataLength > 70)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			_data = new uint[70];
			int num = DataLength - 1;
			int num2 = 0;
			while (num >= 0)
			{
				_data[num2] = inData[num];
				num--;
				num2++;
			}
			while (DataLength > 1 && _data[DataLength - 1] == 0)
			{
				DataLength--;
			}
		}

		public static implicit operator BigInteger(long value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(ulong value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(int value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(uint value)
		{
			return new BigInteger((ulong)value);
		}

		public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger
			{
				DataLength = ((bi1.DataLength > bi2.DataLength) ? bi1.DataLength : bi2.DataLength)
			};
			long num = 0L;
			for (int i = 0; i < bigInteger.DataLength; i++)
			{
				long num2 = (long)bi1._data[i] + (long)bi2._data[i] + num;
				num = num2 >> 32;
				bigInteger._data[i] = (uint)(num2 & 0xFFFFFFFFu);
			}
			if (num != 0L && bigInteger.DataLength < 70)
			{
				bigInteger._data[bigInteger.DataLength] = (uint)num;
				bigInteger.DataLength++;
			}
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			int num3 = 69;
			if ((bi1._data[num3] & 0x80000000u) == (bi2._data[num3] & 0x80000000u) && (bigInteger._data[num3] & 0x80000000u) != (bi1._data[num3] & 0x80000000u))
			{
				throw new ArithmeticException();
			}
			return bigInteger;
		}

		public static BigInteger operator ++(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			long num = 1L;
			int num2 = 0;
			while (num != 0L && num2 < 70)
			{
				long num3 = bigInteger._data[num2];
				num3++;
				bigInteger._data[num2] = (uint)(num3 & 0xFFFFFFFFu);
				num = num3 >> 32;
				num2++;
			}
			if (num2 > bigInteger.DataLength)
			{
				bigInteger.DataLength = num2;
			}
			else
			{
				while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
				{
					bigInteger.DataLength--;
				}
			}
			int num4 = 69;
			if ((bi1._data[num4] & 0x80000000u) == 0 && (bigInteger._data[num4] & 0x80000000u) != (bi1._data[num4] & 0x80000000u))
			{
				throw new ArithmeticException("Overflow in ++.");
			}
			return bigInteger;
		}

		public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger
			{
				DataLength = ((bi1.DataLength > bi2.DataLength) ? bi1.DataLength : bi2.DataLength)
			};
			long num = 0L;
			for (int i = 0; i < bigInteger.DataLength; i++)
			{
				long num2 = (long)bi1._data[i] - (long)bi2._data[i] - num;
				bigInteger._data[i] = (uint)(num2 & 0xFFFFFFFFu);
				num = ((num2 >= 0) ? 0 : 1);
			}
			if (num != 0L)
			{
				for (int j = bigInteger.DataLength; j < 70; j++)
				{
					bigInteger._data[j] = uint.MaxValue;
				}
				bigInteger.DataLength = 70;
			}
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			int num3 = 69;
			if ((bi1._data[num3] & 0x80000000u) != (bi2._data[num3] & 0x80000000u) && (bigInteger._data[num3] & 0x80000000u) != (bi1._data[num3] & 0x80000000u))
			{
				throw new ArithmeticException();
			}
			return bigInteger;
		}

		public static BigInteger operator --(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bool flag = true;
			int num = 0;
			while (flag && num < 70)
			{
				long num2 = bigInteger._data[num];
				num2--;
				bigInteger._data[num] = (uint)(num2 & 0xFFFFFFFFu);
				if (num2 >= 0)
				{
					flag = false;
				}
				num++;
			}
			if (num > bigInteger.DataLength)
			{
				bigInteger.DataLength = num;
			}
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			int num3 = 69;
			if ((bi1._data[num3] & 0x80000000u) != 0 && (bigInteger._data[num3] & 0x80000000u) != (bi1._data[num3] & 0x80000000u))
			{
				throw new ArithmeticException("Underflow in --.");
			}
			return bigInteger;
		}

		public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
		{
			int num = 69;
			bool flag = false;
			bool flag2 = false;
			try
			{
				if ((bi1._data[num] & 0x80000000u) != 0)
				{
					flag = true;
					bi1 = -bi1;
				}
				if ((bi2._data[num] & 0x80000000u) != 0)
				{
					flag2 = true;
					bi2 = -bi2;
				}
			}
			catch (Exception)
			{
			}
			BigInteger bigInteger = new BigInteger();
			try
			{
				for (int i = 0; i < bi1.DataLength; i++)
				{
					if (bi1._data[i] != 0)
					{
						ulong num2 = 0uL;
						int num3 = 0;
						int num4 = i;
						while (num3 < bi2.DataLength)
						{
							ulong num5 = (ulong)((long)bi1._data[i] * (long)bi2._data[num3] + bigInteger._data[num4]) + num2;
							bigInteger._data[num4] = (uint)(num5 & 0xFFFFFFFFu);
							num2 = num5 >> 32;
							num3++;
							num4++;
						}
						if (num2 != 0L)
						{
							bigInteger._data[i + bi2.DataLength] = (uint)num2;
						}
					}
				}
			}
			catch (Exception)
			{
				throw new ArithmeticException("Multiplication overflow.");
			}
			bigInteger.DataLength = bi1.DataLength + bi2.DataLength;
			if (bigInteger.DataLength > 70)
			{
				bigInteger.DataLength = 70;
			}
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			if ((bigInteger._data[num] & 0x80000000u) != 0)
			{
				if (flag != flag2 && bigInteger._data[num] == 2147483648u)
				{
					if (bigInteger.DataLength == 1)
					{
						return bigInteger;
					}
					bool flag3 = true;
					for (int j = 0; j < bigInteger.DataLength - 1 && flag3; j++)
					{
						if (bigInteger._data[j] != 0)
						{
							flag3 = false;
						}
					}
					if (flag3)
					{
						return bigInteger;
					}
				}
				throw new ArithmeticException("Multiplication overflow.");
			}
			if (flag != flag2)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		public static BigInteger operator <<(BigInteger bi1, int shiftVal)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bigInteger.DataLength = ShiftLeft(bigInteger._data, shiftVal);
			return bigInteger;
		}

		private static int ShiftLeft(uint[] buffer, int shiftVal)
		{
			int num = 32;
			int num2 = buffer.Length;
			while (num2 > 1 && buffer[num2 - 1] == 0)
			{
				num2--;
			}
			for (int num3 = shiftVal; num3 > 0; num3 -= num)
			{
				if (num3 < num)
				{
					num = num3;
				}
				ulong num4 = 0uL;
				for (int i = 0; i < num2; i++)
				{
					ulong num5 = (ulong)buffer[i] << num;
					num5 |= num4;
					buffer[i] = (uint)(num5 & 0xFFFFFFFFu);
					num4 = num5 >> 32;
				}
				if (num4 != 0L && num2 + 1 <= buffer.Length)
				{
					buffer[num2] = (uint)num4;
					num2++;
				}
			}
			return num2;
		}

		public static BigInteger operator >>(BigInteger bi1, int shiftVal)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bigInteger.DataLength = ShiftRight(bigInteger._data, shiftVal);
			if ((bi1._data[69] & 0x80000000u) != 0)
			{
				for (int num = 69; num >= bigInteger.DataLength; num--)
				{
					bigInteger._data[num] = uint.MaxValue;
				}
				uint num2 = 2147483648u;
				for (int i = 0; i < 32; i++)
				{
					if ((bigInteger._data[bigInteger.DataLength - 1] & num2) != 0)
					{
						break;
					}
					bigInteger._data[bigInteger.DataLength - 1] |= num2;
					num2 >>= 1;
				}
				bigInteger.DataLength = 70;
			}
			return bigInteger;
		}

		private static int ShiftRight(uint[] buffer, int shiftVal)
		{
			int num = 32;
			int num2 = 0;
			int num3 = buffer.Length;
			while (num3 > 1 && buffer[num3 - 1] == 0)
			{
				num3--;
			}
			for (int num4 = shiftVal; num4 > 0; num4 -= num)
			{
				if (num4 < num)
				{
					num = num4;
					num2 = 32 - num;
				}
				ulong num5 = 0uL;
				for (int num6 = num3 - 1; num6 >= 0; num6--)
				{
					ulong num7 = (ulong)buffer[num6] >> num;
					num7 |= num5;
					num5 = ((ulong)buffer[num6] << num2) & 0xFFFFFFFFu;
					buffer[num6] = (uint)num7;
				}
			}
			while (num3 > 1 && buffer[num3 - 1] == 0)
			{
				num3--;
			}
			return num3;
		}

		public static BigInteger operator ~(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			for (int i = 0; i < 70; i++)
			{
				bigInteger._data[i] = ~bi1._data[i];
			}
			bigInteger.DataLength = 70;
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			return bigInteger;
		}

		public static BigInteger operator -(BigInteger bi1)
		{
			if (bi1.DataLength == 1 && bi1._data[0] == 0)
			{
				return new BigInteger();
			}
			BigInteger bigInteger = new BigInteger(bi1);
			for (int i = 0; i < 70; i++)
			{
				bigInteger._data[i] = ~bi1._data[i];
			}
			long num = 1L;
			int num2 = 0;
			while (num != 0L && num2 < 70)
			{
				long num3 = bigInteger._data[num2];
				num3++;
				bigInteger._data[num2] = (uint)(num3 & 0xFFFFFFFFu);
				num = num3 >> 32;
				num2++;
			}
			if ((bi1._data[69] & 0x80000000u) == (bigInteger._data[69] & 0x80000000u))
			{
				throw new ArithmeticException("Overflow in negation.\n");
			}
			bigInteger.DataLength = 70;
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			return bigInteger;
		}

		public static bool operator ==(BigInteger bi1, BigInteger bi2)
		{
			if ((object)bi1 != bi2)
			{
				return bi1.Equals(bi2);
			}
			return true;
		}

		public static bool operator !=(BigInteger bi1, BigInteger bi2)
		{
			if ((object)bi1 != bi2)
			{
				return !bi1.Equals(bi2);
			}
			return false;
		}

		public override bool Equals(object o)
		{
			if (o == null)
			{
				return false;
			}
			BigInteger bigInteger = (BigInteger)o;
			if (DataLength != bigInteger.DataLength)
			{
				return false;
			}
			for (int i = 0; i < DataLength; i++)
			{
				if (_data[i] != bigInteger._data[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public static bool operator >(BigInteger bi1, BigInteger bi2)
		{
			int num = 69;
			if ((bi1._data[num] & 0x80000000u) != 0 && (bi2._data[num] & 0x80000000u) == 0)
			{
				return false;
			}
			if ((bi1._data[num] & 0x80000000u) == 0 && (bi2._data[num] & 0x80000000u) != 0)
			{
				return true;
			}
			int num2 = ((bi1.DataLength > bi2.DataLength) ? bi1.DataLength : bi2.DataLength);
			num = num2 - 1;
			while (num >= 0 && bi1._data[num] == bi2._data[num])
			{
				num--;
			}
			if (num >= 0)
			{
				if (bi1._data[num] > bi2._data[num])
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool operator <(BigInteger bi1, BigInteger bi2)
		{
			int num = 69;
			if ((bi1._data[num] & 0x80000000u) != 0 && (bi2._data[num] & 0x80000000u) == 0)
			{
				return true;
			}
			if ((bi1._data[num] & 0x80000000u) == 0 && (bi2._data[num] & 0x80000000u) != 0)
			{
				return false;
			}
			int num2 = ((bi1.DataLength > bi2.DataLength) ? bi1.DataLength : bi2.DataLength);
			num = num2 - 1;
			while (num >= 0 && bi1._data[num] == bi2._data[num])
			{
				num--;
			}
			if (num >= 0)
			{
				if (bi1._data[num] < bi2._data[num])
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool operator >=(BigInteger bi1, BigInteger bi2)
		{
			if (!(bi1 == bi2))
			{
				return bi1 > bi2;
			}
			return true;
		}

		public static bool operator <=(BigInteger bi1, BigInteger bi2)
		{
			if (!(bi1 == bi2))
			{
				return bi1 < bi2;
			}
			return true;
		}

		private static void MultiByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
		{
			uint[] array = new uint[70];
			int num = bi1.DataLength + 1;
			uint[] array2 = new uint[num];
			uint num2 = 2147483648u;
			uint num3 = bi2._data[bi2.DataLength - 1];
			int num4 = 0;
			int dataLength = 0;
			while (num2 != 0 && (num3 & num2) == 0)
			{
				num4++;
				num2 >>= 1;
			}
			for (int i = 0; i < bi1.DataLength; i++)
			{
				array2[i] = bi1._data[i];
			}
			ShiftLeft(array2, num4);
			bi2 <<= num4;
			int num5 = num - bi2.DataLength;
			int num6 = num - 1;
			ulong num7 = bi2._data[bi2.DataLength - 1];
			ulong num8 = bi2._data[bi2.DataLength - 2];
			int num9 = bi2.DataLength + 1;
			uint[] array3 = new uint[num9];
			while (num5 > 0)
			{
				ulong num10 = ((ulong)array2[num6] << 32) + array2[num6 - 1];
				ulong num11 = num10 / num7;
				ulong num12 = num10 % num7;
				bool flag = false;
				while (!flag)
				{
					flag = true;
					if (num11 == 4294967296L || num11 * num8 > (num12 << 32) + array2[num6 - 2])
					{
						num11--;
						num12 += num7;
						if (num12 < 4294967296L)
						{
							flag = false;
						}
					}
				}
				for (int j = 0; j < num9; j++)
				{
					array3[j] = array2[num6 - j];
				}
				BigInteger bigInteger = new BigInteger(array3);
				BigInteger bigInteger2;
				for (bigInteger2 = bi2 * (long)num11; bigInteger2 > bigInteger; bigInteger2 -= bi2)
				{
					num11--;
				}
				BigInteger bigInteger3 = bigInteger - bigInteger2;
				for (int k = 0; k < num9; k++)
				{
					array2[num6 - k] = bigInteger3._data[bi2.DataLength - k];
				}
				array[dataLength++] = (uint)num11;
				num6--;
				num5--;
			}
			outQuotient.DataLength = dataLength;
			int l = 0;
			int num13 = outQuotient.DataLength - 1;
			while (num13 >= 0)
			{
				outQuotient._data[l] = array[num13];
				num13--;
				l++;
			}
			for (; l < 70; l++)
			{
				outQuotient._data[l] = 0u;
			}
			while (outQuotient.DataLength > 1 && outQuotient._data[outQuotient.DataLength - 1] == 0)
			{
				outQuotient.DataLength--;
			}
			if (outQuotient.DataLength == 0)
			{
				outQuotient.DataLength = 1;
			}
			outRemainder.DataLength = ShiftRight(array2, num4);
			for (l = 0; l < outRemainder.DataLength; l++)
			{
				outRemainder._data[l] = array2[l];
			}
			for (; l < 70; l++)
			{
				outRemainder._data[l] = 0u;
			}
		}

		private static void SingleByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
		{
			uint[] array = new uint[70];
			int dataLength = 0;
			for (int i = 0; i < 70; i++)
			{
				outRemainder._data[i] = bi1._data[i];
			}
			outRemainder.DataLength = bi1.DataLength;
			while (outRemainder.DataLength > 1 && outRemainder._data[outRemainder.DataLength - 1] == 0)
			{
				outRemainder.DataLength--;
			}
			ulong num = bi2._data[0];
			int num2 = outRemainder.DataLength - 1;
			ulong num3 = outRemainder._data[num2];
			if (num3 >= num)
			{
				ulong num4 = num3 / num;
				array[dataLength++] = (uint)num4;
				outRemainder._data[num2] = (uint)(num3 % num);
			}
			num2--;
			while (num2 >= 0)
			{
				num3 = ((ulong)outRemainder._data[num2 + 1] << 32) + outRemainder._data[num2];
				ulong num5 = num3 / num;
				array[dataLength++] = (uint)num5;
				outRemainder._data[num2 + 1] = 0u;
				outRemainder._data[num2--] = (uint)(num3 % num);
			}
			outQuotient.DataLength = dataLength;
			int j = 0;
			int num6 = outQuotient.DataLength - 1;
			while (num6 >= 0)
			{
				outQuotient._data[j] = array[num6];
				num6--;
				j++;
			}
			for (; j < 70; j++)
			{
				outQuotient._data[j] = 0u;
			}
			while (outQuotient.DataLength > 1 && outQuotient._data[outQuotient.DataLength - 1] == 0)
			{
				outQuotient.DataLength--;
			}
			if (outQuotient.DataLength == 0)
			{
				outQuotient.DataLength = 1;
			}
			while (outRemainder.DataLength > 1 && outRemainder._data[outRemainder.DataLength - 1] == 0)
			{
				outRemainder.DataLength--;
			}
		}

		public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			BigInteger outRemainder = new BigInteger();
			int num = 69;
			bool flag = false;
			bool flag2 = false;
			if ((bi1._data[num] & 0x80000000u) != 0)
			{
				bi1 = -bi1;
				flag2 = true;
			}
			if ((bi2._data[num] & 0x80000000u) != 0)
			{
				bi2 = -bi2;
				flag = true;
			}
			if (bi1 < bi2)
			{
				return bigInteger;
			}
			if (bi2.DataLength == 1)
			{
				SingleByteDivide(bi1, bi2, bigInteger, outRemainder);
			}
			else
			{
				MultiByteDivide(bi1, bi2, bigInteger, outRemainder);
			}
			if (flag2 != flag)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
		{
			BigInteger outQuotient = new BigInteger();
			BigInteger bigInteger = new BigInteger(bi1);
			int num = 69;
			bool flag = false;
			if ((bi1._data[num] & 0x80000000u) != 0)
			{
				bi1 = -bi1;
				flag = true;
			}
			if ((bi2._data[num] & 0x80000000u) != 0)
			{
				bi2 = -bi2;
			}
			if (bi1 < bi2)
			{
				return bigInteger;
			}
			if (bi2.DataLength == 1)
			{
				SingleByteDivide(bi1, bi2, outQuotient, bigInteger);
			}
			else
			{
				MultiByteDivide(bi1, bi2, outQuotient, bigInteger);
			}
			if (flag)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		public static BigInteger operator &(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = ((bi1.DataLength > bi2.DataLength) ? bi1.DataLength : bi2.DataLength);
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1._data[i] & bi2._data[i];
				bigInteger._data[i] = num2;
			}
			bigInteger.DataLength = 70;
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			return bigInteger;
		}

		public static BigInteger operator |(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = ((bi1.DataLength > bi2.DataLength) ? bi1.DataLength : bi2.DataLength);
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1._data[i] | bi2._data[i];
				bigInteger._data[i] = num2;
			}
			bigInteger.DataLength = 70;
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			return bigInteger;
		}

		public static BigInteger operator ^(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = ((bi1.DataLength > bi2.DataLength) ? bi1.DataLength : bi2.DataLength);
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1._data[i] ^ bi2._data[i];
				bigInteger._data[i] = num2;
			}
			bigInteger.DataLength = 70;
			while (bigInteger.DataLength > 1 && bigInteger._data[bigInteger.DataLength - 1] == 0)
			{
				bigInteger.DataLength--;
			}
			return bigInteger;
		}

		public BigInteger Max(BigInteger bi)
		{
			if (this > bi)
			{
				return new BigInteger(this);
			}
			return new BigInteger(bi);
		}

		public BigInteger Min(BigInteger bi)
		{
			if (this < bi)
			{
				return new BigInteger(this);
			}
			return new BigInteger(bi);
		}

		public BigInteger Abs()
		{
			if ((_data[69] & 0x80000000u) != 0)
			{
				return -this;
			}
			return new BigInteger(this);
		}

		public override string ToString()
		{
			return ToString(10);
		}

		public string ToString(int radix)
		{
			if (radix < 2 || radix > 36)
			{
				throw new ArgumentException("Radix must be >= 2 and <= 36");
			}
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string text2 = "";
			BigInteger bigInteger = this;
			bool flag = false;
			if ((bigInteger._data[69] & 0x80000000u) != 0)
			{
				flag = true;
				try
				{
					bigInteger = -bigInteger;
				}
				catch (Exception)
				{
				}
			}
			BigInteger bigInteger2 = new BigInteger();
			BigInteger bigInteger3 = new BigInteger();
			BigInteger bi = new BigInteger(radix);
			if (bigInteger.DataLength == 1 && bigInteger._data[0] == 0)
			{
				text2 = "0";
			}
			else
			{
				while (bigInteger.DataLength > 1 || (bigInteger.DataLength == 1 && bigInteger._data[0] != 0))
				{
					SingleByteDivide(bigInteger, bi, bigInteger2, bigInteger3);
					text2 = ((bigInteger3._data[0] >= 10) ? (text[(int)(bigInteger3._data[0] - 10)] + text2) : (bigInteger3._data[0] + text2));
					bigInteger = bigInteger2;
				}
				if (flag)
				{
					text2 = "-" + text2;
				}
			}
			return text2;
		}

		public string ToHexString()
		{
			string text = _data[DataLength - 1].ToString("X");
			for (int num = DataLength - 2; num >= 0; num--)
			{
				text += _data[num].ToString("X8");
			}
			return text;
		}

		public BigInteger ModPow(BigInteger exp, BigInteger n)
		{
			if ((exp._data[69] & 0x80000000u) != 0)
			{
				throw new ArithmeticException("Positive exponents only.");
			}
			BigInteger bigInteger = 1;
			bool flag = false;
			BigInteger bigInteger2;
			if ((_data[69] & 0x80000000u) != 0)
			{
				bigInteger2 = -this % n;
				flag = true;
			}
			else
			{
				bigInteger2 = this % n;
			}
			if ((n._data[69] & 0x80000000u) != 0)
			{
				n = -n;
			}
			BigInteger bigInteger3 = new BigInteger();
			int num = n.DataLength << 1;
			bigInteger3._data[num] = 1u;
			bigInteger3.DataLength = num + 1;
			bigInteger3 /= n;
			int num2 = exp.BitCount();
			int num3 = 0;
			for (int i = 0; i < exp.DataLength; i++)
			{
				uint num4 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((exp._data[i] & num4) != 0)
					{
						bigInteger = BarrettReduction(bigInteger * bigInteger2, n, bigInteger3);
					}
					num4 <<= 1;
					bigInteger2 = BarrettReduction(bigInteger2 * bigInteger2, n, bigInteger3);
					if (bigInteger2.DataLength == 1 && bigInteger2._data[0] == 1)
					{
						if (flag && (exp._data[0] & 1) != 0)
						{
							return -bigInteger;
						}
						return bigInteger;
					}
					num3++;
					if (num3 == num2)
					{
						break;
					}
				}
			}
			if (flag && (exp._data[0] & 1) != 0)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		private BigInteger BarrettReduction(BigInteger x, BigInteger n, BigInteger constant)
		{
			int dataLength = n.DataLength;
			int num = dataLength + 1;
			int num2 = dataLength - 1;
			BigInteger bigInteger = new BigInteger();
			int num3 = num2;
			int num4 = 0;
			while (num3 < x.DataLength)
			{
				bigInteger._data[num4] = x._data[num3];
				num3++;
				num4++;
			}
			bigInteger.DataLength = x.DataLength - num2;
			if (bigInteger.DataLength <= 0)
			{
				bigInteger.DataLength = 1;
			}
			BigInteger bigInteger2 = bigInteger * constant;
			BigInteger bigInteger3 = new BigInteger();
			int num5 = num;
			int num6 = 0;
			while (num5 < bigInteger2.DataLength)
			{
				bigInteger3._data[num6] = bigInteger2._data[num5];
				num5++;
				num6++;
			}
			bigInteger3.DataLength = bigInteger2.DataLength - num;
			if (bigInteger3.DataLength <= 0)
			{
				bigInteger3.DataLength = 1;
			}
			BigInteger bigInteger4 = new BigInteger();
			int num7 = ((x.DataLength > num) ? num : x.DataLength);
			for (int i = 0; i < num7; i++)
			{
				bigInteger4._data[i] = x._data[i];
			}
			bigInteger4.DataLength = num7;
			BigInteger bigInteger5 = new BigInteger();
			for (int j = 0; j < bigInteger3.DataLength; j++)
			{
				if (bigInteger3._data[j] != 0)
				{
					ulong num8 = 0uL;
					int num9 = j;
					int num10 = 0;
					while (num10 < n.DataLength && num9 < num)
					{
						ulong num11 = (ulong)((long)bigInteger3._data[j] * (long)n._data[num10] + bigInteger5._data[num9]) + num8;
						bigInteger5._data[num9] = (uint)(num11 & 0xFFFFFFFFu);
						num8 = num11 >> 32;
						num10++;
						num9++;
					}
					if (num9 < num)
					{
						bigInteger5._data[num9] = (uint)num8;
					}
				}
			}
			bigInteger5.DataLength = num;
			while (bigInteger5.DataLength > 1 && bigInteger5._data[bigInteger5.DataLength - 1] == 0)
			{
				bigInteger5.DataLength--;
			}
			bigInteger4 -= bigInteger5;
			if ((bigInteger4._data[69] & 0x80000000u) != 0)
			{
				BigInteger bigInteger6 = new BigInteger();
				bigInteger6._data[num] = 1u;
				bigInteger6.DataLength = num + 1;
				bigInteger4 += bigInteger6;
			}
			for (; bigInteger4 >= n; bigInteger4 -= n)
			{
			}
			return bigInteger4;
		}

		public BigInteger Gcd(BigInteger bi)
		{
			BigInteger bigInteger = (((_data[69] & 0x80000000u) == 0) ? this : (-this));
			BigInteger bigInteger2 = (((bi._data[69] & 0x80000000u) == 0) ? bi : (-bi));
			BigInteger bigInteger3 = bigInteger2;
			while (bigInteger.DataLength > 1 || (bigInteger.DataLength == 1 && bigInteger._data[0] != 0))
			{
				bigInteger3 = bigInteger;
				bigInteger = bigInteger2 % bigInteger;
				bigInteger2 = bigInteger3;
			}
			return bigInteger3;
		}

		public void GenRandomBits(int bits, Random rand)
		{
			int num = bits >> 5;
			int num2 = bits & 0x1F;
			if (num2 != 0)
			{
				num++;
			}
			if (num > 70 || bits <= 0)
			{
				throw new ArithmeticException("Number of required bits is not valid.");
			}
			byte[] array = new byte[num * 4];
			rand.NextBytes(array);
			for (int i = 0; i < num; i++)
			{
				_data[i] = BitConverter.ToUInt32(array, i * 4);
			}
			for (int j = num; j < 70; j++)
			{
				_data[j] = 0u;
			}
			if (num2 != 0)
			{
				uint num3;
				if (bits != 1)
				{
					num3 = (uint)(1 << num2 - 1);
					_data[num - 1] |= num3;
				}
				num3 = uint.MaxValue >> 32 - num2;
				_data[num - 1] &= num3;
			}
			else
			{
				_data[num - 1] |= 2147483648u;
			}
			DataLength = num;
			if (DataLength == 0)
			{
				DataLength = 1;
			}
		}

		public void GenRandomBits(int bits, RNGCryptoServiceProvider rng)
		{
			int num = bits >> 5;
			int num2 = bits & 0x1F;
			if (num2 != 0)
			{
				num++;
			}
			if (num > 70 || bits <= 0)
			{
				throw new ArithmeticException("Number of required bits is not valid.");
			}
			byte[] array = new byte[num * 4];
			rng.GetBytes(array);
			for (int i = 0; i < num; i++)
			{
				_data[i] = BitConverter.ToUInt32(array, i * 4);
			}
			for (int j = num; j < 70; j++)
			{
				_data[j] = 0u;
			}
			if (num2 != 0)
			{
				uint num3;
				if (bits != 1)
				{
					num3 = (uint)(1 << num2 - 1);
					_data[num - 1] |= num3;
				}
				num3 = uint.MaxValue >> 32 - num2;
				_data[num - 1] &= num3;
			}
			else
			{
				_data[num - 1] |= 2147483648u;
			}
			DataLength = num;
			if (DataLength == 0)
			{
				DataLength = 1;
			}
		}

		public int BitCount()
		{
			while (DataLength > 1 && _data[DataLength - 1] == 0)
			{
				DataLength--;
			}
			uint num = _data[DataLength - 1];
			uint num2 = 2147483648u;
			int num3 = 32;
			while (num3 > 0 && (num & num2) == 0)
			{
				num3--;
				num2 >>= 1;
			}
			num3 += DataLength - 1 << 5;
			if (num3 != 0)
			{
				return num3;
			}
			return 1;
		}

		public bool FermatLittleTest(int confidence)
		{
			BigInteger bigInteger = (((_data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.DataLength == 1)
			{
				if (bigInteger._data[0] == 0 || bigInteger._data[0] == 1)
				{
					return false;
				}
				if (bigInteger._data[0] == 2 || bigInteger._data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger._data[0] & 1) == 0)
			{
				return false;
			}
			int num = bigInteger.BitCount();
			BigInteger bigInteger2 = new BigInteger();
			BigInteger exp = bigInteger - new BigInteger(1L);
			Random random = new Random();
			for (int i = 0; i < confidence; i++)
			{
				bool flag = false;
				while (!flag)
				{
					int num2;
					for (num2 = 0; num2 < 2; num2 = (int)(random.NextDouble() * (double)num))
					{
					}
					bigInteger2.GenRandomBits(num2, random);
					int dataLength = bigInteger2.DataLength;
					if (dataLength > 1 || (dataLength == 1 && bigInteger2._data[0] != 1))
					{
						flag = true;
					}
				}
				BigInteger bigInteger3 = bigInteger2.Gcd(bigInteger);
				if (bigInteger3.DataLength == 1 && bigInteger3._data[0] != 1)
				{
					return false;
				}
				BigInteger bigInteger4 = bigInteger2.ModPow(exp, bigInteger);
				int dataLength2 = bigInteger4.DataLength;
				if (dataLength2 > 1 || (dataLength2 == 1 && bigInteger4._data[0] != 1))
				{
					return false;
				}
			}
			return true;
		}

		public bool RabinMillerTest(int confidence)
		{
			BigInteger bigInteger = (((_data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.DataLength == 1)
			{
				if (bigInteger._data[0] == 0 || bigInteger._data[0] == 1)
				{
					return false;
				}
				if (bigInteger._data[0] == 2 || bigInteger._data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger._data[0] & 1) == 0)
			{
				return false;
			}
			BigInteger bigInteger2 = bigInteger - new BigInteger(1L);
			int num = 0;
			for (int i = 0; i < bigInteger2.DataLength; i++)
			{
				uint num2 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((bigInteger2._data[i] & num2) != 0)
					{
						i = bigInteger2.DataLength;
						break;
					}
					num2 <<= 1;
					num++;
				}
			}
			BigInteger exp = bigInteger2 >> num;
			int num3 = bigInteger.BitCount();
			BigInteger bigInteger3 = new BigInteger();
			Random random = new Random();
			for (int k = 0; k < confidence; k++)
			{
				bool flag = false;
				while (!flag)
				{
					int num4;
					for (num4 = 0; num4 < 2; num4 = (int)(random.NextDouble() * (double)num3))
					{
					}
					bigInteger3.GenRandomBits(num4, random);
					int dataLength = bigInteger3.DataLength;
					if (dataLength > 1 || (dataLength == 1 && bigInteger3._data[0] != 1))
					{
						flag = true;
					}
				}
				BigInteger bigInteger4 = bigInteger3.Gcd(bigInteger);
				if (bigInteger4.DataLength == 1 && bigInteger4._data[0] != 1)
				{
					return false;
				}
				BigInteger bigInteger5 = bigInteger3.ModPow(exp, bigInteger);
				bool flag2 = false;
				if (bigInteger5.DataLength == 1 && bigInteger5._data[0] == 1)
				{
					flag2 = true;
				}
				int num5 = 0;
				while (!flag2 && num5 < num)
				{
					if (bigInteger5 == bigInteger2)
					{
						flag2 = true;
						break;
					}
					bigInteger5 = bigInteger5 * bigInteger5 % bigInteger;
					num5++;
				}
				if (!flag2)
				{
					return false;
				}
			}
			return true;
		}

		public bool SolovayStrassenTest(int confidence)
		{
			BigInteger bigInteger = (((_data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.DataLength == 1)
			{
				if (bigInteger._data[0] == 0 || bigInteger._data[0] == 1)
				{
					return false;
				}
				if (bigInteger._data[0] == 2 || bigInteger._data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger._data[0] & 1) == 0)
			{
				return false;
			}
			int num = bigInteger.BitCount();
			BigInteger bigInteger2 = new BigInteger();
			BigInteger bigInteger3 = bigInteger - 1;
			BigInteger exp = bigInteger3 >> 1;
			Random random = new Random();
			for (int i = 0; i < confidence; i++)
			{
				bool flag = false;
				while (!flag)
				{
					int num2;
					for (num2 = 0; num2 < 2; num2 = (int)(random.NextDouble() * (double)num))
					{
					}
					bigInteger2.GenRandomBits(num2, random);
					int dataLength = bigInteger2.DataLength;
					if (dataLength > 1 || (dataLength == 1 && bigInteger2._data[0] != 1))
					{
						flag = true;
					}
				}
				BigInteger bigInteger4 = bigInteger2.Gcd(bigInteger);
				if (bigInteger4.DataLength == 1 && bigInteger4._data[0] != 1)
				{
					return false;
				}
				BigInteger bigInteger5 = bigInteger2.ModPow(exp, bigInteger);
				if (bigInteger5 == bigInteger3)
				{
					bigInteger5 = -1;
				}
				BigInteger bigInteger6 = Jacobi(bigInteger2, bigInteger);
				if (bigInteger5 != bigInteger6)
				{
					return false;
				}
			}
			return true;
		}

		public bool LucasStrongTest()
		{
			BigInteger bigInteger = (((_data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.DataLength == 1)
			{
				if (bigInteger._data[0] == 0 || bigInteger._data[0] == 1)
				{
					return false;
				}
				if (bigInteger._data[0] == 2 || bigInteger._data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger._data[0] & 1) == 0)
			{
				return false;
			}
			return LucasStrongTestHelper(bigInteger);
		}

		private bool LucasStrongTestHelper(BigInteger thisVal)
		{
			long num = 5L;
			long num2 = -1L;
			long num3 = 0L;
			for (bool flag = false; !flag; num3++)
			{
				switch (Jacobi(num, thisVal))
				{
				case -1:
					flag = true;
					continue;
				case 0:
					if (Math.Abs(num) < thisVal)
					{
						return false;
					}
					break;
				}
				if (num3 == 20)
				{
					BigInteger bigInteger = thisVal.Sqrt();
					if (bigInteger * bigInteger == thisVal)
					{
						return false;
					}
				}
				num = (Math.Abs(num) + 2) * num2;
				num2 = -num2;
			}
			long num4 = 1 - num >> 2;
			BigInteger bigInteger2 = thisVal + 1;
			int num5 = 0;
			for (int i = 0; i < bigInteger2.DataLength; i++)
			{
				uint num6 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((bigInteger2._data[i] & num6) != 0)
					{
						i = bigInteger2.DataLength;
						break;
					}
					num6 <<= 1;
					num5++;
				}
			}
			BigInteger k = bigInteger2 >> num5;
			BigInteger bigInteger3 = new BigInteger();
			int num7 = thisVal.DataLength << 1;
			bigInteger3._data[num7] = 1u;
			bigInteger3.DataLength = num7 + 1;
			bigInteger3 /= thisVal;
			BigInteger[] array = LucasSequenceHelper(1, num4, k, thisVal, bigInteger3, 0);
			bool flag2 = false;
			if ((array[0].DataLength == 1 && array[0]._data[0] == 0) || (array[1].DataLength == 1 && array[1]._data[0] == 0))
			{
				flag2 = true;
			}
			for (int l = 1; l < num5; l++)
			{
				if (!flag2)
				{
					array[1] = thisVal.BarrettReduction(array[1] * array[1], thisVal, bigInteger3);
					array[1] = (array[1] - (array[2] << 1)) % thisVal;
					if (array[1].DataLength == 1 && array[1]._data[0] == 0)
					{
						flag2 = true;
					}
				}
				array[2] = thisVal.BarrettReduction(array[2] * array[2], thisVal, bigInteger3);
			}
			if (flag2)
			{
				BigInteger bigInteger4 = thisVal.Gcd(num4);
				if (bigInteger4.DataLength == 1 && bigInteger4._data[0] == 1)
				{
					if ((array[2]._data[69] & 0x80000000u) != 0)
					{
						BigInteger[] array2 = array;
						array2[2] += thisVal;
					}
					BigInteger bigInteger5 = num4 * Jacobi(num4, thisVal) % thisVal;
					if ((bigInteger5._data[69] & 0x80000000u) != 0)
					{
						bigInteger5 += thisVal;
					}
					if (array[2] != bigInteger5)
					{
						flag2 = false;
					}
				}
			}
			return flag2;
		}

		public bool IsProbablePrime(int confidence)
		{
			BigInteger bigInteger = (((_data[69] & 0x80000000u) == 0) ? this : (-this));
			for (int i = 0; i < PrimesBelow2000.Length; i++)
			{
				BigInteger bigInteger2 = PrimesBelow2000[i];
				if (bigInteger2 >= bigInteger)
				{
					break;
				}
				BigInteger bigInteger3 = bigInteger % bigInteger2;
				if (bigInteger3.IntValue() == 0)
				{
					return false;
				}
			}
			if (bigInteger.RabinMillerTest(confidence))
			{
				return true;
			}
			return false;
		}

		public bool IsProbablePrime()
		{
			BigInteger bigInteger = (((_data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.DataLength == 1)
			{
				if (bigInteger._data[0] == 0 || bigInteger._data[0] == 1)
				{
					return false;
				}
				if (bigInteger._data[0] == 2 || bigInteger._data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger._data[0] & 1) == 0)
			{
				return false;
			}
			for (int i = 0; i < PrimesBelow2000.Length; i++)
			{
				BigInteger bigInteger2 = PrimesBelow2000[i];
				if (bigInteger2 >= bigInteger)
				{
					break;
				}
				BigInteger bigInteger3 = bigInteger % bigInteger2;
				if (bigInteger3.IntValue() == 0)
				{
					return false;
				}
			}
			BigInteger bigInteger4 = bigInteger - new BigInteger(1L);
			int num = 0;
			for (int j = 0; j < bigInteger4.DataLength; j++)
			{
				uint num2 = 1u;
				for (int k = 0; k < 32; k++)
				{
					if ((bigInteger4._data[j] & num2) != 0)
					{
						j = bigInteger4.DataLength;
						break;
					}
					num2 <<= 1;
					num++;
				}
			}
			BigInteger exp = bigInteger4 >> num;
			int num3 = bigInteger.BitCount();
			BigInteger bigInteger5 = 2;
			BigInteger bigInteger6 = bigInteger5.ModPow(exp, bigInteger);
			bool flag = false;
			if (bigInteger6.DataLength == 1 && bigInteger6._data[0] == 1)
			{
				flag = true;
			}
			int num4 = 0;
			while (!flag && num4 < num)
			{
				if (bigInteger6 == bigInteger4)
				{
					flag = true;
					break;
				}
				bigInteger6 = bigInteger6 * bigInteger6 % bigInteger;
				num4++;
			}
			if (flag)
			{
				flag = LucasStrongTestHelper(bigInteger);
			}
			return flag;
		}

		public int IntValue()
		{
			return (int)_data[0];
		}

		public long LongValue()
		{
			long num = 0L;
			num = _data[0];
			try
			{
				num |= (long)((ulong)_data[1] << 32);
			}
			catch (Exception)
			{
				if ((_data[0] & 0x80000000u) != 0)
				{
					num = (int)_data[0];
				}
			}
			return num;
		}

		public static int Jacobi(BigInteger a, BigInteger b)
		{
			if ((b._data[0] & 1) == 0)
			{
				throw new ArgumentException("Jacobi defined only for odd integers.");
			}
			if (a >= b)
			{
				a %= b;
			}
			if (a.DataLength == 1 && a._data[0] == 0)
			{
				return 0;
			}
			if (a.DataLength == 1 && a._data[0] == 1)
			{
				return 1;
			}
			if (a < 0)
			{
				if (((b - 1)._data[0] & 2) == 0)
				{
					return Jacobi(-a, b);
				}
				return -Jacobi(-a, b);
			}
			int num = 0;
			for (int i = 0; i < a.DataLength; i++)
			{
				uint num2 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((a._data[i] & num2) != 0)
					{
						i = a.DataLength;
						break;
					}
					num2 <<= 1;
					num++;
				}
			}
			BigInteger bigInteger = a >> num;
			int num3 = 1;
			if ((num & 1) != 0 && ((b._data[0] & 7) == 3 || (b._data[0] & 7) == 5))
			{
				num3 = -1;
			}
			if ((b._data[0] & 3) == 3 && (bigInteger._data[0] & 3) == 3)
			{
				num3 = -num3;
			}
			if (bigInteger.DataLength == 1 && bigInteger._data[0] == 1)
			{
				return num3;
			}
			return num3 * Jacobi(b % bigInteger, bigInteger);
		}

		public static BigInteger GenPseudoPrime(int bits, int confidence, Random rand)
		{
			BigInteger bigInteger = new BigInteger();
			bool flag = false;
			while (!flag)
			{
				bigInteger.GenRandomBits(bits, rand);
				bigInteger._data[0] |= 1u;
				flag = bigInteger.IsProbablePrime(confidence);
			}
			return bigInteger;
		}

		public static BigInteger GenPseudoPrime(int bits, int confidence, RNGCryptoServiceProvider rand)
		{
			BigInteger bigInteger = new BigInteger();
			bool flag = false;
			while (!flag)
			{
				bigInteger.GenRandomBits(bits, rand);
				bigInteger._data[0] |= 1u;
				flag = bigInteger.IsProbablePrime(confidence);
			}
			return bigInteger;
		}

		public BigInteger GenCoPrime(int bits, Random rand)
		{
			bool flag = false;
			BigInteger bigInteger = new BigInteger();
			while (!flag)
			{
				bigInteger.GenRandomBits(bits, rand);
				BigInteger bigInteger2 = bigInteger.Gcd(this);
				if (bigInteger2.DataLength == 1 && bigInteger2._data[0] == 1)
				{
					flag = true;
				}
			}
			return bigInteger;
		}

		public BigInteger GenCoPrime(int bits, RNGCryptoServiceProvider rand)
		{
			bool flag = false;
			BigInteger bigInteger = new BigInteger();
			while (!flag)
			{
				bigInteger.GenRandomBits(bits, rand);
				BigInteger bigInteger2 = bigInteger.Gcd(this);
				if (bigInteger2.DataLength == 1 && bigInteger2._data[0] == 1)
				{
					flag = true;
				}
			}
			return bigInteger;
		}

		public BigInteger ModInverse(BigInteger modulus)
		{
			BigInteger[] array = new BigInteger[2] { 0, 1 };
			BigInteger[] array2 = new BigInteger[2];
			BigInteger[] array3 = new BigInteger[2] { 0, 0 };
			int num = 0;
			BigInteger bi = modulus;
			BigInteger bigInteger = this;
			while (bigInteger.DataLength > 1 || (bigInteger.DataLength == 1 && bigInteger._data[0] != 0))
			{
				BigInteger bigInteger2 = new BigInteger();
				BigInteger bigInteger3 = new BigInteger();
				if (num > 1)
				{
					BigInteger bigInteger4 = (array[0] - array[1] * array2[0]) % modulus;
					array[0] = array[1];
					array[1] = bigInteger4;
				}
				if (bigInteger.DataLength == 1)
				{
					SingleByteDivide(bi, bigInteger, bigInteger2, bigInteger3);
				}
				else
				{
					MultiByteDivide(bi, bigInteger, bigInteger2, bigInteger3);
				}
				array2[0] = array2[1];
				array3[0] = array3[1];
				array2[1] = bigInteger2;
				array3[1] = bigInteger3;
				bi = bigInteger;
				bigInteger = bigInteger3;
				num++;
			}
			if (array3[0].DataLength > 1 || (array3[0].DataLength == 1 && array3[0]._data[0] != 1))
			{
				throw new ArithmeticException("No inverse!");
			}
			BigInteger bigInteger5 = (array[0] - array[1] * array2[0]) % modulus;
			if ((bigInteger5._data[69] & 0x80000000u) != 0)
			{
				bigInteger5 += modulus;
			}
			return bigInteger5;
		}

		public byte[] GetBytes()
		{
			int num = BitCount();
			int num2 = num >> 3;
			if ((num & 7) != 0)
			{
				num2++;
			}
			byte[] array = new byte[num2];
			int num3 = 0;
			uint num4 = _data[DataLength - 1];
			uint num5;
			if ((num5 = (num4 >> 24) & 0xFF) != 0)
			{
				array[num3++] = (byte)num5;
			}
			if ((num5 = (num4 >> 16) & 0xFF) != 0)
			{
				array[num3++] = (byte)num5;
			}
			else if (num3 > 0)
			{
				num3++;
			}
			if ((num5 = (num4 >> 8) & 0xFF) != 0)
			{
				array[num3++] = (byte)num5;
			}
			else if (num3 > 0)
			{
				num3++;
			}
			if ((num5 = num4 & 0xFF) != 0)
			{
				array[num3++] = (byte)num5;
			}
			else if (num3 > 0)
			{
				num3++;
			}
			int num6 = DataLength - 2;
			while (num6 >= 0)
			{
				num4 = _data[num6];
				array[num3 + 3] = (byte)(num4 & 0xFF);
				num4 >>= 8;
				array[num3 + 2] = (byte)(num4 & 0xFF);
				num4 >>= 8;
				array[num3 + 1] = (byte)(num4 & 0xFF);
				num4 >>= 8;
				array[num3] = (byte)(num4 & 0xFF);
				num6--;
				num3 += 4;
			}
			return array;
		}

		public uint[] GetInternalState()
		{
			uint[] array = new uint[_data.Length];
			_data.CopyTo(array, 0);
			return array;
		}

		public void SetBit(uint bitNum)
		{
			uint num = bitNum >> 5;
			byte b = (byte)(bitNum & 0x1F);
			uint num2 = (uint)(1 << (int)b);
			_data[num] |= num2;
			if (num >= DataLength)
			{
				DataLength = (int)(num + 1);
			}
		}

		public void UnsetBit(uint bitNum)
		{
			uint num = bitNum >> 5;
			if (num < DataLength)
			{
				byte b = (byte)(bitNum & 0x1F);
				uint num2 = (uint)(1 << (int)b);
				uint num3 = 0xFFFFFFFFu ^ num2;
				_data[num] &= num3;
				if (DataLength > 1 && _data[DataLength - 1] == 0)
				{
					DataLength--;
				}
			}
		}

		public BigInteger Sqrt()
		{
			uint num = (uint)BitCount();
			num = (((num & 1) == 0) ? (num >> 1) : ((num >> 1) + 1));
			uint num2 = num >> 5;
			byte b = (byte)(num & 0x1F);
			BigInteger bigInteger = new BigInteger();
			uint num3;
			if (b == 0)
			{
				num3 = 2147483648u;
			}
			else
			{
				num3 = (uint)(1 << (int)b);
				num2++;
			}
			bigInteger.DataLength = (int)num2;
			for (int num4 = (int)(num2 - 1); num4 >= 0; num4--)
			{
				while (num3 != 0)
				{
					bigInteger._data[num4] ^= num3;
					if (bigInteger * bigInteger > this)
					{
						bigInteger._data[num4] ^= num3;
					}
					num3 >>= 1;
				}
				num3 = 2147483648u;
			}
			return bigInteger;
		}

		public static BigInteger[] LucasSequence(BigInteger p, BigInteger q, BigInteger k, BigInteger n)
		{
			if (k.DataLength == 1 && k._data[0] == 0)
			{
				return new BigInteger[3]
				{
					0,
					2 % n,
					1 % n
				};
			}
			BigInteger bigInteger = new BigInteger();
			int num = n.DataLength << 1;
			bigInteger._data[num] = 1u;
			bigInteger.DataLength = num + 1;
			bigInteger /= n;
			int num2 = 0;
			for (int i = 0; i < k.DataLength; i++)
			{
				uint num3 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((k._data[i] & num3) != 0)
					{
						i = k.DataLength;
						break;
					}
					num3 <<= 1;
					num2++;
				}
			}
			BigInteger k2 = k >> num2;
			return LucasSequenceHelper(p, q, k2, n, bigInteger, num2);
		}

		private static BigInteger[] LucasSequenceHelper(BigInteger p, BigInteger q, BigInteger k, BigInteger n, BigInteger constant, int s)
		{
			BigInteger[] array = new BigInteger[3];
			if ((k._data[0] & 1) == 0)
			{
				throw new ArgumentException("Argument k must be odd.");
			}
			int num = k.BitCount();
			uint num2 = (uint)(1 << (num & 0x1F) - 1);
			BigInteger bigInteger = 2 % n;
			BigInteger bigInteger2 = 1 % n;
			BigInteger bigInteger3 = p % n;
			BigInteger bigInteger4 = bigInteger2;
			bool flag = true;
			for (int num3 = k.DataLength - 1; num3 >= 0; num3--)
			{
				while (num2 != 0 && (num3 != 0 || num2 != 1))
				{
					if ((k._data[num3] & num2) != 0)
					{
						bigInteger4 = bigInteger4 * bigInteger3 % n;
						bigInteger = (bigInteger * bigInteger3 - p * bigInteger2) % n;
						bigInteger3 = n.BarrettReduction(bigInteger3 * bigInteger3, n, constant);
						bigInteger3 = (bigInteger3 - (bigInteger2 * q << 1)) % n;
						if (flag)
						{
							flag = false;
						}
						else
						{
							bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
						}
						bigInteger2 = bigInteger2 * q % n;
					}
					else
					{
						bigInteger4 = (bigInteger4 * bigInteger - bigInteger2) % n;
						bigInteger3 = (bigInteger * bigInteger3 - p * bigInteger2) % n;
						bigInteger = n.BarrettReduction(bigInteger * bigInteger, n, constant);
						bigInteger = (bigInteger - (bigInteger2 << 1)) % n;
						if (flag)
						{
							bigInteger2 = q % n;
							flag = false;
						}
						else
						{
							bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
						}
					}
					num2 >>= 1;
				}
				num2 = 2147483648u;
			}
			bigInteger4 = (bigInteger4 * bigInteger - bigInteger2) % n;
			bigInteger = (bigInteger * bigInteger3 - p * bigInteger2) % n;
			if (flag)
			{
				flag = false;
			}
			else
			{
				bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
			}
			bigInteger2 = bigInteger2 * q % n;
			for (int i = 0; i < s; i++)
			{
				bigInteger4 = bigInteger4 * bigInteger % n;
				bigInteger = (bigInteger * bigInteger - (bigInteger2 << 1)) % n;
				if (flag)
				{
					bigInteger2 = q % n;
					flag = false;
				}
				else
				{
					bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
				}
			}
			array[0] = bigInteger4;
			array[1] = bigInteger;
			array[2] = bigInteger2;
			return array;
		}
	}
}
