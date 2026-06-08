using System;
using KitchenData;
using MessagePack;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct PlayerProfile : IEquatable<PlayerProfile>
	{
		[Key(0)]
		public string Name;

		[Key(1)]
		public Color Colour;

		[Key(2)]
		public PlayerOutfit Outfit;

		[Key(3)]
		public bool RequiresTutorial;

		[Key(4)]
		public DataObjectList Cosmetics;

		[Key(5)]
		public ProfileFlags Flags;

		[IgnoreMember]
		public ProfileIdentifier Identifier;

		public static PlayerProfile Default => new PlayerProfile
		{
			Name = "New Chef",
			Identifier = (ProfileIdentifier)"New Chef",
			Colour = Color.HSVToRGB(0f, 0.75f, 0.75f)
		};

		[IgnoreMember]
		public bool IsRealProfile => !string.IsNullOrEmpty(Name);

		public bool Equals(PlayerProfile other)
		{
			if (Name == other.Name && Identifier == other.Identifier && Colour.Equals(other.Colour) && Cosmetics.IsEquivalent(other.Cosmetics) && RequiresTutorial == other.RequiresTutorial)
			{
				return Flags == other.Flags;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is PlayerProfile other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((((((((((Name != null) ? Name.GetHashCode() : 0) * 397) ^ Identifier.GetHashCode()) * 397) ^ Colour.GetHashCode()) * 397) ^ Cosmetics.GetHashCode()) * 397) ^ RequiresTutorial.GetHashCode()) * 397) ^ (int)Flags;
		}

		public static bool operator ==(PlayerProfile left, PlayerProfile right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(PlayerProfile left, PlayerProfile right)
		{
			return !left.Equals(right);
		}
	}
}
