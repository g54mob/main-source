using System;
using System.Collections;

namespace MiscUtil.Text
{
	public sealed class Utf32String : IEnumerable, IComparable, ICloneable
	{
		private const int HighSurrogateStart = 55296;

		private const int HighSurrogateEnd = 56319;

		private const int LowSurrogateStart = 56320;

		private const int LowSurrogateEnd = 57343;

		private const int MaxUtf32Character = 1114111;

		private const int HashcodeSampleSize = 20;

		public static readonly Utf32String Empty = new Utf32String(new int[0]);

		private readonly int[] characters;

		public int Length => characters.Length;

		public int this[int index] => characters[index];

		public static bool IsValidUtf32Char(int value)
		{
			if (value >= 0)
			{
				return value <= 1114111;
			}
			return false;
		}

		private Utf32String(int[] characters, bool unused)
		{
			this.characters = characters;
		}

		public Utf32String(int[] characters)
		{
			characters = (int[])characters.Clone();
			int[] array = characters;
			foreach (int num in array)
			{
				if (!IsValidUtf32Char(num))
				{
					throw new ArgumentException("Invalid character in array: " + num, "characters");
				}
			}
			this.characters = characters;
		}

		public Utf32String(string utf16)
		{
			if (utf16 == null)
			{
				throw new ArgumentNullException("utf16");
			}
			characters = new int[utf16.Length];
			int num = -1;
			int num2 = 0;
			foreach (char c in utf16)
			{
				if (c >= '\ud800' && c <= '\udbff')
				{
					if (num != -1)
					{
						throw new ArgumentException("Invalid string: two high surrogates in a row", "utf16");
					}
					num = (c - 55296) * 1024;
				}
				else if (c >= '\udc00' && c <= '\udfff')
				{
					if (num == -1)
					{
						throw new ArgumentException("Invalid string: low surrogate not preceded by high surrogate");
					}
					characters[num2++] = num + (c - 56320) + 65536;
					num = -1;
				}
				else
				{
					if (num != -1)
					{
						throw new ArgumentException("Invalid string: high surrogates with no following low surrogate", "utf16");
					}
					characters[num2++] = c;
				}
			}
			if (num != -1)
			{
				throw new ArgumentException("Invalid string: final character is a high surrogate");
			}
			if (num2 != characters.Length)
			{
				int[] destinationArray = new int[num2];
				Array.Copy(characters, 0, destinationArray, 0, num2);
				characters = destinationArray;
			}
		}

		public Utf32String Substring(int start)
		{
			if (start < 0)
			{
				throw new ArgumentOutOfRangeException("start must be non-negative", "start");
			}
			if (start > Length)
			{
				throw new ArgumentOutOfRangeException("start must be less than or equal to the length of the string", "start");
			}
			if (start == Length)
			{
				return Empty;
			}
			return Substring(start, Length - start);
		}

		public Utf32String Substring(int start, int count)
		{
			if (start < 0)
			{
				throw new ArgumentOutOfRangeException("start must be non-negative", "start");
			}
			if (start > Length)
			{
				throw new ArgumentOutOfRangeException("start must be less than or equal to the length of the string", "start");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count must be non-negative", "count");
			}
			if (start + count > Length)
			{
				throw new ArgumentOutOfRangeException("start+count must be less than or equal to the length of the string");
			}
			if (count == 0)
			{
				return Empty;
			}
			int[] destinationArray = new int[count];
			Array.Copy(characters, start, destinationArray, 0, count);
			return new Utf32String(destinationArray, unused: true);
		}

		public int IndexOf(Utf32String value)
		{
			return IndexOf(value, 0, Length);
		}

		public int IndexOf(Utf32String value, int start)
		{
			if (start < 0 || start > Length)
			{
				throw new ArgumentOutOfRangeException("start must lie within the string bounds", "start");
			}
			return IndexOf(value, start, Length - start);
		}

		public int IndexOf(Utf32String value, int start, int count)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (start < 0 || start > Length)
			{
				throw new ArgumentOutOfRangeException("start must lie within the string bounds", "start");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count must be non-negative", "count");
			}
			if (start + count > Length)
			{
				throw new ArgumentOutOfRangeException("start+count must be less than or equal to the length of the string");
			}
			for (int i = start; i < start + count; i++)
			{
				if (i + value.Length > Length)
				{
					return -1;
				}
				int j;
				for (j = 0; j < value.Length && characters[i + j] == value.characters[j]; j++)
				{
				}
				if (j == value.Length)
				{
					return i;
				}
			}
			return -1;
		}

		public int IndexOf(int character)
		{
			return IndexOf(character, 0, Length);
		}

		public int IndexOf(int character, int start)
		{
			if (start < 0 || start > Length)
			{
				throw new ArgumentOutOfRangeException("start must lie within the string bounds", "start");
			}
			return IndexOf(character, start, Length - start);
		}

		public int IndexOf(int character, int start, int count)
		{
			if (!IsValidUtf32Char(character))
			{
				throw new ArgumentException("Invalid UTF-32 character specified", "character");
			}
			if (start < 0 || start > Length)
			{
				throw new ArgumentOutOfRangeException("start must lie within the string bounds", "start");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count must be non-negative", "count");
			}
			if (start + count > Length)
			{
				throw new ArgumentOutOfRangeException("start+count must be less than or equal to the length of the string");
			}
			for (int i = start; i < start + count; i++)
			{
				if (characters[i] == character)
				{
					return i;
				}
			}
			return -1;
		}

		public bool Equals(Utf32String other)
		{
			if (object.ReferenceEquals(this, other))
			{
				return true;
			}
			return CompareTo(other) == 0;
		}

		public static bool Equals(Utf32String strA, Utf32String strB)
		{
			return Compare(strA, strB) == 0;
		}

		public static int Compare(Utf32String strA, Utf32String strB)
		{
			if (object.ReferenceEquals(strA, strB))
			{
				return 0;
			}
			if ((object)strA == null || (object)strB == null)
			{
				if ((object)strA != null)
				{
					return 1;
				}
				return -1;
			}
			return strA.CompareTo(strB);
		}

		public static Utf32String Concat(params Utf32String[] strings)
		{
			if (strings == null)
			{
				throw new ArgumentNullException("strings");
			}
			int num = 0;
			foreach (Utf32String utf32String in strings)
			{
				if (utf32String != null)
				{
					num += utf32String.Length;
				}
			}
			if (num == 0)
			{
				return Empty;
			}
			int[] destinationArray = new int[num];
			int num2 = 0;
			foreach (Utf32String utf32String2 in strings)
			{
				if (utf32String2 != null)
				{
					Array.Copy(utf32String2.characters, 0, destinationArray, num2, utf32String2.Length);
					num2 += utf32String2.Length;
				}
			}
			return new Utf32String(destinationArray);
		}

		public static Utf32String Concat(Utf32String strA, Utf32String strB)
		{
			return Concat(new Utf32String[2] { strA, strB });
		}

		public static Utf32String Concat(Utf32String strA, Utf32String strB, Utf32String strC)
		{
			return Concat(new Utf32String[3] { strA, strB, strC });
		}

		public static Utf32String Concat(Utf32String strA, Utf32String strB, Utf32String strC, Utf32String strD)
		{
			return Concat(new Utf32String[4] { strA, strB, strC, strD });
		}

		public int[] ToInt32Array()
		{
			return (int[])characters.Clone();
		}

		public override string ToString()
		{
			int num = 0;
			int[] array = characters;
			foreach (int num2 in array)
			{
				if (num2 > 65535)
				{
					num++;
				}
			}
			char[] array2 = new char[Length + num];
			int num3 = 0;
			int[] array3 = characters;
			foreach (int num4 in array3)
			{
				if (num4 < 65536)
				{
					array2[num3++] = (char)num4;
					continue;
				}
				array2[num3++] = (char)((num4 - 65536) / 1024 + 55296);
				array2[num3++] = (char)((num4 - 65536) % 1024 + 56320);
			}
			return new string(array2);
		}

		public override bool Equals(object obj)
		{
			Utf32String utf32String = obj as Utf32String;
			if (utf32String == null)
			{
				return false;
			}
			return Equals(utf32String);
		}

		public override int GetHashCode()
		{
			int num = 0;
			int num2 = Math.Max(Length / 20, 1);
			for (int i = 0; i < Length; i += num2)
			{
				num ^= characters[i];
			}
			return num;
		}

		public static Utf32String operator +(Utf32String strA, Utf32String strB)
		{
			return Concat(strA, strB);
		}

		public static bool operator ==(Utf32String strA, Utf32String strB)
		{
			return Equals(strA, strB);
		}

		public static bool operator !=(Utf32String strA, Utf32String strB)
		{
			return !Equals(strA, strB);
		}

		public IEnumerator GetEnumerator()
		{
			return characters.GetEnumerator();
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			Utf32String utf32String = obj as Utf32String;
			if (utf32String == null)
			{
				throw new ArgumentException("Can only compare Utf32Strings", "obj");
			}
			int num = Math.Min(Length, utf32String.Length);
			for (int i = 0; i < num; i++)
			{
				int num2 = this[i] - utf32String[i];
				if (num2 != 0)
				{
					return num2;
				}
			}
			return Length - utf32String.Length;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
