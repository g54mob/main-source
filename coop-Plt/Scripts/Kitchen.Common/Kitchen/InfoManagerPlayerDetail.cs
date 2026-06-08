using System;
using Controllers;
using KitchenData;
using MessagePack;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct InfoManagerPlayerDetail
	{
		[Key(0)]
		public int ID;

		[Key(1)]
		public SourceIdentifier Identifier;

		[Key(2)]
		public string MainName;

		[Key(3)]
		public string SubName;

		[Key(4)]
		public int Index;

		[Key(5)]
		public float JoinProgress;

		[Key(6)]
		public Color Colour;

		[Key(7)]
		public DataObjectList Cosmetics;

		[IgnoreMember]
		public SourceIdentifier Source => Identifier;

		[IgnoreMember]
		public bool IsLocalUser => Identifier == InputSourceIdentifier.Identifier;

		public bool IsChangedFrom(InfoManagerPlayerDetail other)
		{
			if (ID == other.ID && !(Identifier != other.Identifier) && !(MainName != other.MainName) && !(SubName != other.SubName) && Index == other.Index && !(Math.Abs(JoinProgress - other.JoinProgress) > 0.001f) && !(Colour != other.Colour))
			{
				return !Cosmetics.IsEquivalent(other.Cosmetics);
			}
			return true;
		}
	}
}
