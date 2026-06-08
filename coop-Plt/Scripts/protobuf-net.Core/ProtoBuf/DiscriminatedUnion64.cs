using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ProtoBuf
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct DiscriminatedUnion64 : ISerializable
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

		public int Discriminator => _discriminator;

		private DiscriminatedUnion64(int discriminator)
		{
			this = default(DiscriminatedUnion64);
			_discriminator = discriminator;
		}

		public bool Is(int discriminator)
		{
			return _discriminator == discriminator;
		}

		public DiscriminatedUnion64(int discriminator, long value)
			: this(discriminator)
		{
			Int64 = value;
		}

		public DiscriminatedUnion64(int discriminator, int value)
			: this(discriminator)
		{
			Int32 = value;
		}

		public DiscriminatedUnion64(int discriminator, ulong value)
			: this(discriminator)
		{
			UInt64 = value;
		}

		public DiscriminatedUnion64(int discriminator, uint value)
			: this(discriminator)
		{
			UInt32 = value;
		}

		public DiscriminatedUnion64(int discriminator, float value)
			: this(discriminator)
		{
			Single = value;
		}

		public DiscriminatedUnion64(int discriminator, double value)
			: this(discriminator)
		{
			Double = value;
		}

		public DiscriminatedUnion64(int discriminator, bool value)
			: this(discriminator)
		{
			Boolean = value;
		}

		public DiscriminatedUnion64(int discriminator, DateTime? value)
			: this(value.HasValue ? discriminator : 0)
		{
			DateTime = value.GetValueOrDefault();
		}

		public DiscriminatedUnion64(int discriminator, TimeSpan? value)
			: this(value.HasValue ? discriminator : 0)
		{
			TimeSpan = value.GetValueOrDefault();
		}

		public static void Reset(ref DiscriminatedUnion64 value, int discriminator)
		{
			if (value.Discriminator == discriminator)
			{
				value = default(DiscriminatedUnion64);
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (_discriminator != 0)
			{
				info.AddValue("d", _discriminator);
			}
			if (Int64 != 0L)
			{
				info.AddValue("i", Int64);
			}
		}

		private DiscriminatedUnion64(SerializationInfo info, StreamingContext context)
		{
			this = default(DiscriminatedUnion64);
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				string name = current.Name;
				if (!(name == "d"))
				{
					if (name == "i")
					{
						Int64 = (long)current.Value;
					}
				}
				else
				{
					_discriminator = (int)current.Value;
				}
			}
		}
	}
}
