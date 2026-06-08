using System;
using System.Collections.Generic;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public class INetworkDataList
	{
		[Key(0)]
		public List<INetworkData> data;
	}
}
