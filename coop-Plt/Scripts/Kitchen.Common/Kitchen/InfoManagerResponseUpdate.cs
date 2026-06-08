using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct InfoManagerResponseUpdate
	{
		[Key(0)]
		public int PlayerID;

		[Key(1)]
		public PlayerProfile Profile;
	}
}
