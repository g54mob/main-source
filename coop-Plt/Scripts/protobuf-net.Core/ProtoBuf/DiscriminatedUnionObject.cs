using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace ProtoBuf
{
	[Serializable]
	[StructLayout(LayoutKind.Auto)]
	public readonly struct DiscriminatedUnionObject : ISerializable
	{
		public readonly object Object;

		public int Discriminator { get; }

		public bool Is(int discriminator)
		{
			return Discriminator == discriminator;
		}

		public DiscriminatedUnionObject(int discriminator, object value)
		{
			Discriminator = discriminator;
			Object = value;
		}

		public static void Reset(ref DiscriminatedUnionObject value, int discriminator)
		{
			if (value.Discriminator == discriminator)
			{
				value = default(DiscriminatedUnionObject);
			}
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (Discriminator != 0)
			{
				info.AddValue("d", Discriminator);
			}
			if (Object != null)
			{
				info.AddValue("o", Object);
			}
		}

		private DiscriminatedUnionObject(SerializationInfo info, StreamingContext context)
		{
			this = default(DiscriminatedUnionObject);
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SerializationEntry current = enumerator.Current;
				string name = current.Name;
				if (!(name == "d"))
				{
					if (name == "o")
					{
						Object = current.Value;
					}
				}
				else
				{
					Discriminator = (int)current.Value;
				}
			}
		}
	}
}
