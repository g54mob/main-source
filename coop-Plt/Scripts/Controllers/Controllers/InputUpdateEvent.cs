using System;
using MessagePack;

namespace Controllers
{
	[Serializable]
	[MessagePackObject(false)]
	public struct InputUpdateEvent
	{
		[Key(0)]
		public int User;

		[Key(1)]
		public InputState State;
	}
}
