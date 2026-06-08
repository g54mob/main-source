using System;
using Controllers;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct InfoManagerPeerDetail
	{
		[Key(0)]
		public SourceIdentifier Identifier;

		[Key(1)]
		public string MainName;

		[Key(2)]
		public bool HasPlayers;

		[IgnoreMember]
		public SourceIdentifier Source => Identifier;

		public bool IsChangedFrom(InfoManagerPeerDetail other)
		{
			if (!(Identifier != other.Identifier) && !(MainName != other.MainName))
			{
				return HasPlayers != other.HasPlayers;
			}
			return true;
		}
	}
}
