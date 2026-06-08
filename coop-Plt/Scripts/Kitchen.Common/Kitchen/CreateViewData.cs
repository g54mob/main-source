using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CreateViewData : IViewData, IViewResponseData
	{
		[Key(0)]
		public ViewType ViewType;

		[Key(1)]
		public ViewMode ViewMode;

		[Key(2)]
		public bool IsRedraw;
	}
}
