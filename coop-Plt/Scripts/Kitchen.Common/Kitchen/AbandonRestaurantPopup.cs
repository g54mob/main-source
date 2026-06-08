using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class AbandonRestaurantPopup : GenericChoicePopupManager
	{
		public override PopupType ManagedType => PopupType.AbandonRestaurant;

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			if (decision == GenericChoiceDecision.Accept)
			{
				base.World.Add<CRequestQuitEvent>();
			}
			return true;
		}

		public override Entity CreateNewPopup(Entity request)
		{
			return base.PopupUtilities.CreateGenericPopup(GenericChoiceType.AcceptOrCancel, ManagedType, PopupLocation.Centre);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
