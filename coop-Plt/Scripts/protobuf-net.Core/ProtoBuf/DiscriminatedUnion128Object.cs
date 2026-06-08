using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ProtoBuf
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct DiscriminatedUnion128Object : ISerializable
	{
		[FieldOffset(0)]
		private readonly int _discriminator;

		[FieldOffset(8)]
		public readonly long Int64;

		[FieldOffset(8)]
		public readonly ulong UInt64;

		[FieldOffset(8)]
		public readonly int Int32;

		[FieldOffset(8)]
		public readonly uint UInt32;

		[FieldOffset(8)]
		public readonly bool Boolean;

		[FieldOffset(8)]
		public readonly float Single;

		[FieldOffset(8)]
		public readonly double Double;

		[FieldOffset(8)]
		public readonly DateTime DateTime;

		[FieldOffset(8)]
		public readonly TimeSpan TimeSpan;

		[FieldOffset(8)]
		public readonly Guid Guid;

		[FieldOffset(24)]
		public readonly object Object;

		[FieldOffset(8)]
		private readonly long _lo;

		[FieldOffset(16)]
		private readonly long _hi;

		public int Discriminator => _discriminator;

		private DiscriminatedUnion128Object(int discriminator)
		{
			this = default(DiscriminatedUnion128Object);
			_discriminator = discriminator;
		}

		public bool Is(int discriminator)
		{
			return _discriminator == discriminator;
		}

		public DiscriminatedUnion128Object(int discriminator, long value)
			: this(discriminator)
		{
			Int64 = value;
		}

		public DiscriminatedUnion128Object(int discriminator, int value)
			: this(discriminator)
		{
			Int32 = value;
		}

		public DiscriminatedUnion128Object(int discriminator, ulong value)
			: this(discriminator)
		{
			UInt64 = value;
		}

		public DiscriminatedUnion128Object(int discriminator, uint value)
			: this(discriminator)
		{
			UInt32 = value;
		}

		public DiscriminatedUnion128Object(int discriminator, float value)
			: this(discriminator)
		{
			Single = value;
		}

		public DiscriminatedUnion128Object(int discriminator, double value)
			: this(discriminator)
		{
			Double = value;
		}

		public DiscriminatedUnion128Object(int discriminator, bool value)
			: this(discriminator)
		{
			Boolean = value;
		}

		public DiscriminatedUnion128Object(int discriminator, object value)
			: this((value != null) ? discriminator : 0)
		{
			Object = value;
		}

		public DiscriminatedUnion128Object(int discriminator, DateTime? value)
			: this(value.HasValue ? discriminator : 0)
		{
			DateTime = value.GetValueOrDefault();
		}

		public DiscriminatedUnion128Object(int discriminator, TimeSpan? value)
			: this(value.HasValue ? discriminator : 0)
		{
			TimeSpan = value.GetValueOrDefault();
		}

		public DiscriminatedUnion128Object(int discriminator, Guid? value)
			: this(value.HasValue ? discriminator : 0)
		{
			Guid = value.GetValueOrDefault();
		}

		public static void Reset(ref DiscriminatedUnion128Object value, int discriminator)
		{
			if (value.Discriminator == discriminator)
			{
				value = default(DiscriminatedUnion128Object);
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (_discriminator != 0)
			{
				info.AddValue("d", _discriminator);
			}
			if (_lo != 0L)
			{
				info.AddValue("l", _lo);
			}
			if (_hi != 0L)
			{
				info.AddValue("h", _hi);
			}
			if (Object != null)
			{
				info.AddValue("o", Object);
			}
		}

		private DiscriminatedUnion128Object(SerializationInfo info, StreamingContext context)
		{
			this = default(DiscriminatedUnion128Object);
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				switch (current.Name)
				{
				case "d":
					_discriminator = (int)current.Value;
					break;
				case "l":
					_lo = (long)current.Value;
					break;
				case "h":
					_hi = (long)current.Value;
					break;
				case "o":
					Object = current.Value;
					break;
				}
			}
		}
	}
}
