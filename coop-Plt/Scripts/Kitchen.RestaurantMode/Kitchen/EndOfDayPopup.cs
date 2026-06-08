using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class EndOfDayPopup : PopupManager
	{
		public override PopupType ManagedType => PopupType.EndDayPopup;

		public override bool UpdatePopup(Entity popup)
		{
			return false;
		}

		public override Entity CreateNewPopup(Entity request)
		{
			Entity entity = base.PopupUtilities.CreatePopup(ViewType.EndOfDayPopup, PopupLocation.Centre, PopupType.EndDayPopup);
			CopyData<CPopupEndDayData>(request, entity);
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
