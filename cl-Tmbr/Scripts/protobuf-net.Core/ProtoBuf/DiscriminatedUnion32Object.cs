using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ProtoBuf
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct DiscriminatedUnion32Object : ISerializable
	{
		[FieldOffset(0)]
		private readonly int _discriminator;

		[FieldOffset(4)]
		public readonly int Int32;

		[FieldOffset(4)]
		public readonly uint UInt32;

		[FieldOffset(4)]
		public readonly bool Boolean;

		[FieldOffset(4)]
		public readonly float Single;

		[FieldOffset(8)]
		public readonly object Object;

		public int Discriminator => _discriminator;

		private DiscriminatedUnion32Object(int discriminator)
		{
			this = default(DiscriminatedUnion32Object);
			_discriminator = discriminator;
		}

		public bool Is(int discriminator)
		{
			return _discriminator == discriminator;
		}

		public DiscriminatedUnion32Object(int discriminator, int value)
			: this(discriminator)
		{
			Int32 = value;
		}

		public DiscriminatedUnion32Object(int discriminator, uint value)
			: this(discriminator)
		{
			UInt32 = value;
		}

		public DiscriminatedUnion32Object(int discriminator, float value)
			: this(discriminator)
		{
			Single = value;
		}

		public DiscriminatedUnion32Object(int discriminator, bool value)
			: this(discriminator)
		{
			Boolean = value;
		}

		public DiscriminatedUnion32Object(int discriminator, object value)
			: this((value != null) ? discriminator : 0)
		{
			Object = value;
		}

		public static void Reset(ref DiscriminatedUnion32Object value, int discriminator)
		{
			if (value.Discriminator == discriminator)
			{
				value = default(DiscriminatedUnion32Object);
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (_discriminator != 0)
			{
				info.AddValue("d", _discriminator);
			}
			if (Int32 != 0)
			{
				info.AddValue("i", Int32);
			}
			if (Object != null)
			{
				info.AddValue("o", Object);
			}
		}

		private DiscriminatedUnion32Object(SerializationInfo info, StreamingContext context)
		{
			this = default(DiscriminatedUnion32Object);
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				switch (current.Name)
				{
				case "d":
					_discriminator = (int)current.Value;
					break;
				case "i":
					Int32 = (int)current.Value;
					break;
				case "o":
					Object = current.Value;
					break;
				}
			}
		}
	}
}
