using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class ActivateFullSavePopup : GenericChoicePopupManager
	{
		public override PopupType ManagedType => PopupType.LoadPreviousSave;

		public override Entity CreateNewPopup(Entity request)
		{
			Entity entity = base.PopupUtilities.CreateGenericPopup(GenericChoiceType.AcceptOrCancel, ManagedType, PopupLocation.Centre);
			CopyData<CLocationPopupRequest>(request, entity);
			return entity;
		}

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			if (!Require<CLocationPopupRequest>(popup, out CLocationPopupRequest comp))
			{
				return true;
			}
			if (decision != GenericChoiceDecision.Accept)
			{
				return true;
			}
			Set(new SSelectedLocation
			{
				Valid = true,
				Selected = comp.Location
			});
			Entity entity = base.EntityManager.CreateEntity(typeof(SPerformSceneTransition), typeof(CDoNotPersist));
			base.EntityManager.SetComponentData(entity, new SPerformSceneTransition
			{
				NextScene = SceneType.LoadFullAutosave
			});
			return true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
