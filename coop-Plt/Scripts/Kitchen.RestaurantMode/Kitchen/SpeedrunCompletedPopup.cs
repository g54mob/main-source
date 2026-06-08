using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class SpeedrunCompletedPopup : GenericChoicePopupManager
	{
		public override PopupType ManagedType => PopupType.SpeedrunCompleted;

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			return true;
		}

		public override Entity CreateNewPopup(Entity request)
		{
			Entity entity = base.PopupUtilities.CreateGenericPopup(GenericChoiceType.OnlyAccept, ManagedType, PopupLocation.Centre);
			CopyData<CPopupSpeedrunCompleted>(request, entity);
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
