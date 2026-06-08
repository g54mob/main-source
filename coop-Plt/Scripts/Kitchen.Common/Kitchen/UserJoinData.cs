using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct UserJoinData : ICommandData
	{
		[Key(0)]
		public string Version;
	}
}
