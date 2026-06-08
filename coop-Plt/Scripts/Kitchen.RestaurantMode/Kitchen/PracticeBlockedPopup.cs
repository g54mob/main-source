using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class PracticeBlockedPopup : GenericChoicePopupManager
	{
		public override PopupType ManagedType => PopupType.PracticeBlockedByParcelOrHolding;

		public override Entity CreateNewPopup(Entity request)
		{
			return base.PopupUtilities.CreateGenericPopup(GenericChoiceType.AcceptOrCancel, PopupType.PracticeBlockedByParcelOrHolding, PopupLocation.Centre);
		}

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			return true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
