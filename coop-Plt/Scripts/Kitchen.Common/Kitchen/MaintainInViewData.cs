using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct MaintainInViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<MaintainInViewData>
	{
		[Key(0)]
		public ViewIdentifier View;

		[Key(1)]
		public float Radius;

		[Key(2)]
		public bool ShouldMaintain;

		public bool IsChangedFrom(MaintainInViewData check)
		{
			if (!(View != check.View) && !(Math.Abs(Radius - check.Radius) > 0.01f))
			{
				return ShouldMaintain != check.ShouldMaintain;
			}
			return true;
		}
	}
}
