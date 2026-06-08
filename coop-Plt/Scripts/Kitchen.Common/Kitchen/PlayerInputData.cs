using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct PlayerInputData
	{
		[Key(0)]
		public int PlayerID;

		[Key(1)]
		public CInputData Input;
	}
}
