using System;

namespace Kitchen
{
	public abstract class ResponsiveObjectView<TViewData, TResp> : UpdatableObjectView<TViewData>, IResponsiveObject where TViewData : IViewData
	{
		public virtual Type ResponseType => typeof(TResp);

		public abstract bool HasStateUpdate(out IResponseData state);
	}
}
