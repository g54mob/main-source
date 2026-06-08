using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class EndOfDemoPopup : GenericChoicePopupManager
	{
		public override PopupType ManagedType => PopupType.EndDemoPopup;

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			return true;
		}

		public override Entity CreateNewPopup(Entity request)
		{
			return base.PopupUtilities.CreateGenericPopup(GenericChoiceType.OnlyAccept, ManagedType, PopupLocation.Centre);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
