using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace UniJSON
{
	[StructLayout(LayoutKind.Explicit)]
	public struct Utf8String4 : IEquatable<Utf8String4>, IUtf8String, IEnumerable<byte>, IEnumerable
	{
		[FieldOffset(0)]
		private uint _value;

		[FieldOffset(0)]
		private byte _byte0;

		[FieldOffset(1)]
		private byte _byte1;

		[FieldOffset(2)]
		private byte _byte2;

		[FieldOffset(3)]
		private byte _byte3;

		public int ByteLength
		{
			get
			{
				if (_byte0 == 0)
				{
					return 0;
				}
				if (_byte1 == 0)
				{
					return 1;
				}
				if (_byte2 == 0)
				{
					return 2;
				}
				if (_byte3 == 0)
				{
					return 3;
				}
				return 4;
			}
		}

		private static Utf8String4 Create(uint value)
		{
			return new Utf8String4
			{
				_value = value
			};
		}

		public static Utf8String4 Create(IEnumerable<byte> bytes)
		{
			Utf8String4 result = default(Utf8String4);
			IEnumerator<byte> enumerator = bytes.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return result;
			}
			result._byte0 = enumerator.Current;
			if (!enumerator.MoveNext())
			{
				return result;
			}
			result._byte1 = enumerator.Current;
			if (!enumerator.MoveNext())
			{
				return result;
			}
			result._byte2 = enumerator.Current;
			if (!enumerator.MoveNext())
			{
				return result;
			}
			result._byte3 = enumerator.Current;
			if (!enumerator.MoveNext())
			{
				throw new ArgumentOutOfRangeException();
			}
			return result;
		}

		public static Utf8String4 Create(string src)
		{
			return Create(Utf8String.Encoding.GetBytes(src));
		}

		public bool Equals(Utf8String4 other)
		{
			return _value == other._value;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is Utf8String4)
			{
				return Equals((Utf8String4)obj);
			}
			if (obj is string text)
			{
				return ToString() == text;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _value.GetHashCode();
		}

		public override string ToString()
		{
			return Utf8String.Encoding.GetString(this.ToArray());
		}

		public IEnumerator<byte> GetEnumerator()
		{
			if (_byte0 == 0)
			{
				yield break;
			}
			yield return _byte0;
			if (_byte1 == 0)
			{
				yield break;
			}
			yield return _byte1;
			if (_byte2 != 0)
			{
				yield return _byte2;
				if (_byte3 != 0)
				{
					yield return _byte3;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
