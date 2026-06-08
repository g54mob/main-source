using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct DestroyViewData : IViewData, IViewResponseData
	{
		[Key(0)]
		public bool PurgeCacheOnly;
	}
}
