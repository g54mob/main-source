using System;
using System.Collections.Generic;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct InfoManagerResponseData : IResponseData, IViewResponseData
	{
		[Key(0)]
		public List<InfoManagerResponseUpdate> Updates;
	}
}
