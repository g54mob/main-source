using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Draft;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.Timers;
using NSMedieval.StorageUniversal;
using NSMedieval.View;

namespace NSMedieval.Controllers
{
	public class DraftController : MonoSingleton<DraftController>
	{
		[NonSerialized]
		private readonly HashSet<HumanoidInstance> draftedWorkers = new HashSet<HumanoidInstance>();

		private Timer updateTimer;

		public HashSet<HumanoidInstance> DraftedWorkers => draftedWorkers;

		public event Action<HumanoidInstance> OnStartDraftEvent;

		public event Action<HumanoidInstance> OnEndDraftEvent;

		public void OnStartDraft(HumanoidInstance humanoid)
		{
			if (humanoid == null || humanoid.HasDisposed || humanoid.WorkerBehaviour.IsBanished || humanoid.IsFallingDown)
			{
				return;
			}
			if (humanoid.HasFainted)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("has_fainted", humanoid) ?? "");
				return;
			}
			WorkerGoapAgent workerGoapAgent = (WorkerGoapAgent)humanoid.GetGoapAgent();
			WorkerView agentView = humanoid.GetAgentView<WorkerView>();
			if (agentView == null || workerGoapAgent == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(57, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\DraftController.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Could not draft humanoid ");
					messageBuilder.AppendFormatted(humanoid.Info.GetFullName());
					messageBuilder.AppendLiteral(". View or GoapAgent is/are gone.");
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				humanoid.WorkerBehaviour.ForceWorkHour(HourType.Draft);
				workerGoapAgent.Abort();
				humanoid.SetTarget(null);
				MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(humanoid);
				CombatUtils.SetWeaponVisibility(humanoid, isVisible: true);
				agentView.GenerateInDraftOverlayElement();
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(agentView.HumanoidInstance);
				MonoSingleton<ReservationManager>.Instance.ReleaseAll((IGoapAgentOwner)humanoid);
				MonoSingleton<StorageCommonManager>.Instance.ReleaseAllStorageReservations(humanoid);
				draftedWorkers.Add(humanoid);
				this.OnStartDraftEvent?.Invoke(humanoid);
				humanoid.GetNode()?.RefreshTags();
			}
		}

		public void OnEndDraft(HumanoidInstance humanoid)
		{
			if (humanoid == null || humanoid.HasDisposed || humanoid.HasDied || humanoid.WorkerBehaviour == null)
			{
				return;
			}
			if (humanoid.WorkerBehaviour != null)
			{
				humanoid.WorkerBehaviour.ForceWorkHour(HourType.None);
				if (humanoid.WorkerBehaviour.LastDraftOrder != null)
				{
					humanoid.WorkerBehaviour.LastDraftOrder.OnDraftEnd(humanoid);
					humanoid.WorkerBehaviour.LastDraftOrder = null;
				}
			}
			(humanoid.GetGoapAgent() as WorkerGoapAgent)?.Abort();
			MonoSingleton<CombatTargetManager>.Instance.RemovePreferredTarget(humanoid);
			CombatUtils.SetWeaponVisibility(humanoid, isVisible: false);
			MonoSingleton<WorkerManager>.Instance.GetView(humanoid)?.DestroyInDraftOverlayElement();
			draftedWorkers.Remove(humanoid);
			this.OnEndDraftEvent?.Invoke(humanoid);
		}

		public void ExecuteDraftOrder(HumanoidInstance humanoid, DraftOrder order)
		{
			if (!humanoid.WorkerBehaviour.IsBanished)
			{
				MonoSingleton<DraftManager>.Instance.ExecuteOrder(humanoid, order);
			}
		}

		private void DraftTick()
		{
			foreach (HumanoidInstance draftedWorker in draftedWorkers)
			{
				draftedWorker?.WorkerBehaviour?.DraftedTick();
			}
		}

		private void Start()
		{
			updateTimer = new Timer(0.5f);
			updateTimer.SetRestartOnEnd(value: true);
			updateTimer.AddCallback(DraftTick);
		}

		protected override void OnDestroy()
		{
			draftedWorkers.Clear();
			updateTimer.Dispose();
			updateTimer = null;
			this.OnEndDraftEvent = null;
			this.OnStartDraftEvent = null;
			base.OnDestroy();
		}
	}
}
