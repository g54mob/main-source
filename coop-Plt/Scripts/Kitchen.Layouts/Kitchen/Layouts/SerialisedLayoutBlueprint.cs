using System;
using Kitchen.Serialisation;
using MessagePack;

namespace Kitchen.Layouts
{
	[Serializable]
	[MessagePackObject(false)]
	public struct SerialisedLayoutBlueprint : IEquatable<SerialisedLayoutBlueprint>
	{
		[Key(0)]
		public byte[] Data;

		public bool Equals(SerialisedLayoutBlueprint other)
		{
			return object.Equals(Data, other.Data);
		}

		public override bool Equals(object obj)
		{
			if (obj is SerialisedLayoutBlueprint other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (Data == null)
			{
				return 0;
			}
			return Data.GetHashCode();
		}

		public static bool operator ==(SerialisedLayoutBlueprint left, SerialisedLayoutBlueprint right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(SerialisedLayoutBlueprint left, SerialisedLayoutBlueprint right)
		{
			return !left.Equals(right);
		}

		[SerializationConstructor]
		public SerialisedLayoutBlueprint(byte[] data)
		{
			Data = data;
		}

		public SerialisedLayoutBlueprint(LayoutBlueprint blueprint)
		{
			Data = MessagePackUtility.Serialize(blueprint);
		}

		public LayoutBlueprint Deserialise()
		{
			return MessagePackUtility.Deserialize<LayoutBlueprint>(Data);
		}
	}
}
