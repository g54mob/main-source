using KitchenData;
using MessagePack;
using Unity.Entities;

namespace Kitchen
{
	public class RestartDayPopup : GenericChoicePopupManager
	{
		[MessagePackObject(false)]
		public struct SPopup : IManagedPopupData, IComponentData
		{
			[Key(0)]
			public LossReason Reason;
		}

		private EntityQuery RestartOffers;

		public override PopupType ManagedType => PopupType.RestartRestaurantAfterFailure;

		protected override void Initialise()
		{
			base.Initialise();
			RestartOffers = GetEntityQuery(typeof(COfferRestartDay));
		}

		public override Entity CreateNewPopup(Entity request)
		{
			Entity entity = base.PopupUtilities.CreateGenericPopup(GenericChoiceType.AcceptOrConsentCancel, ManagedType, PopupLocation.Centre);
			base.EntityManager.AddComponent<CGamePauseRequest>(entity);
			CopyData<SPopup>(request, entity);
			return entity;
		}

		protected override bool HandleDecision(Entity popup, GenericChoiceDecision decision)
		{
			if (!Require<SPopup>(popup, out SPopup comp))
			{
				return true;
			}
			if (decision == GenericChoiceDecision.Accept)
			{
				base.World.Add<CRestartDayEvent>();
			}
			else
			{
				base.World.Add(new SGameOver
				{
					Reason = comp.Reason
				});
			}
			return true;
		}

		protected override void OnUpdate()
		{
			if (!RestartOffers.IsEmpty)
			{
				COfferRestartDay cOfferRestartDay = RestartOffers.First<COfferRestartDay>();
				Entity entity = base.PopupUtilities.RequestManagedPopup(PopupType.RestartRestaurantAfterFailure);
				base.EntityManager.AddComponentData(entity, new SPopup
				{
					Reason = cOfferRestartDay.Reason
				});
				base.EntityManager.DestroyEntity(RestartOffers);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
