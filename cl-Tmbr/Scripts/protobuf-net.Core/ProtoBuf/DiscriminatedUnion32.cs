using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ProtoBuf
{
	[Serializable]
	[StructLayout(LayoutKind.Explicit)]
	public readonly struct DiscriminatedUnion32 : ISerializable
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

		public int Discriminator => _discriminator;

		private DiscriminatedUnion32(int discriminator)
		{
			this = default(DiscriminatedUnion32);
			_discriminator = discriminator;
		}

		public bool Is(int discriminator)
		{
			return _discriminator == discriminator;
		}

		public DiscriminatedUnion32(int discriminator, int value)
			: this(discriminator)
		{
			Int32 = value;
		}

		public DiscriminatedUnion32(int discriminator, uint value)
			: this(discriminator)
		{
			UInt32 = value;
		}

		public DiscriminatedUnion32(int discriminator, float value)
			: this(discriminator)
		{
			Single = value;
		}

		public DiscriminatedUnion32(int discriminator, bool value)
			: this(discriminator)
		{
			Boolean = value;
		}

		public static void Reset(ref DiscriminatedUnion32 value, int discriminator)
		{
			if (value.Discriminator == discriminator)
			{
				value = default(DiscriminatedUnion32);
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
		}

		private DiscriminatedUnion32(SerializationInfo info, StreamingContext context)
		{
			this = default(DiscriminatedUnion32);
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				string name = current.Name;
				if (!(name == "d"))
				{
					if (name == "i")
					{
						Int32 = (int)current.Value;
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
