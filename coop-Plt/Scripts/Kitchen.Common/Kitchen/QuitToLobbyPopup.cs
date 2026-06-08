using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class QuitToLobbyPopup : GenericChoicePopupManager
	{
		public override PopupType ManagedType => PopupType.QuitToLobby;

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			if (decision == GenericChoiceDecision.Accept)
			{
				StartSceneTransition(SceneType.Franchise);
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
