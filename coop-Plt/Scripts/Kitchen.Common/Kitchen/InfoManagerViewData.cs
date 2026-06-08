using System;
using System.Collections.Generic;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct InfoManagerViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<InfoManagerViewData>
	{
		[Key(0)]
		public List<InfoManagerPlayerDetail> Players;

		[Key(1)]
		public List<InfoManagerPeerDetail> Peers;

		public bool IsChangedFrom(InfoManagerViewData check)
		{
			return true;
		}
	}
}
