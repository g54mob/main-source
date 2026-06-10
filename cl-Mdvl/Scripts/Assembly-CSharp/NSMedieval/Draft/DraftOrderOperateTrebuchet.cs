using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;

namespace NSMedieval.Draft
{
	public class DraftOrderOperateTrebuchet : DraftOrder
	{
		private SiegeWeaponComponentInstance componentInstance;

		public DraftOrderOperateTrebuchet(SiegeWeaponComponentInstance componentInstance)
			: base(DraftOrderType.ForceAttackTarget)
		{
			this.componentInstance = componentInstance;
		}

		public override bool CheckRequirements(HumanoidInstance instance, DraftOrder lastDraftOrder)
		{
			return true;
		}

		public override void Execute(HumanoidInstance humanoidInstance)
		{
			if (componentInstance == null || componentInstance.HasDisposed)
			{
				return;
			}
			MonoSingleton<ReservationManager>.Instance.ReleaseAll((IGoapAgentOwner)humanoidInstance);
			if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(componentInstance, humanoidInstance))
			{
				if (humanoidInstance.WorkerBehaviour.CombatMode == UnitCombatModeType.DraftedHoldGround)
				{
					humanoidInstance.WorkerBehaviour.SetCombatMode(UnitCombatModeType.DraftedDefault);
				}
				humanoidInstance.CombatAi.SetState(CombatAiState.OperatingTrebuchet, componentInstance);
				humanoidInstance.GetGoapAgent().ForceNextGoal("OperateTrebuchetGoal");
			}
		}

		public override void OnNewOrder(HumanoidInstance humanoidInstance, DraftOrder newOrder)
		{
			humanoidInstance.CombatAi.SetState(CombatAiState.OperatingTrebuchet, null);
			MonoSingleton<ReservationManager>.Instance.ReleaseAll((IGoapAgentOwner)humanoidInstance);
		}

		public override void OnDraftEnd(HumanoidInstance humanoidInstance)
		{
			humanoidInstance.CombatAi.SetState(CombatAiState.OperatingTrebuchet, null);
			MonoSingleton<ReservationManager>.Instance.ReleaseAll((IGoapAgentOwner)humanoidInstance);
		}
	}
}
