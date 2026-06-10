using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.Goap.Goals
{
	public class UninstallBuildingGoal : Goal
	{
		private const float DefaultUninstallMultiplier = 0.3f;

		public UninstallBuildingGoal(Agent selfAgent)
			: base("UninstallBuildingGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<BaseBuildingInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData, ReserveTargets));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IToolAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!MonoSingleton<ConstructablesGoapUninstallManager>.IsInstantiated())
			{
				return false;
			}
			return MonoSingleton<ConstructablesGoapUninstallManager>.Instance.ObjectsToUninstall.Count > 0;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			((IToolAgent)base.AgentOwner).HideTool();
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			IToolAgent agent = (IToolAgent)base.AgentOwner;
			BaseBuildingInstance building = null;
			float totalTime = 0f;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetIsNotType<BaseBuildingInstance>(TargetIndex.A)
				.FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => !MonoSingleton<ConstructablesGoapUninstallManager>.Instance.ObjectsToUninstall.Contains(GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>()));
			GoapAction uninstallAction = null;
			ConstructionParameters parameters;
			uninstallAction = new GoapAction("UninstallAction")
			{
				CompleteMode = ActionCompleteMode.Never,
				OnInit = delegate
				{
					agent.SetTool("hammer_item");
					building = GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>();
					parameters = building.Blueprint.ConstructionParameters;
					float attributeValue = agent.GetAttributeValue(parameters.DurationStat);
					float num = building.Blueprint.BuildTime;
					float num2 = ((building.Blueprint.InstallationMultiplier > 0f) ? building.Blueprint.InstallationMultiplier : 0.3f);
					totalTime = num * num2 / attributeValue;
					IProductionAgent obj = (IProductionAgent)base.AgentOwner;
					float attributeValue2 = obj.GetAttributeValue(AttributeType.GlobalWorkSpeed);
					if (attributeValue2 != 0f)
					{
						totalTime /= attributeValue2;
					}
					float attributeValue3 = obj.GetAttributeValue(AttributeType.MotorFunction);
					if (attributeValue3 != 0f)
					{
						totalTime /= attributeValue3;
					}
					uninstallAction.CompleteAfterTimeExpires(totalTime);
					agent.GetGoapAgent().GetView().SetAudioEventParameter("HammerHit", new KeyValuePair<string, float>("Material", (float)building.Blueprint.SoundMaterialCategory));
					uninstallAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => uninstallAction.TotalTickingTime / totalTime).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
				},
				OnTick = delegate
				{
					building.SetRemainingTime(totalTime - uninstallAction.TotalTickingTime);
				},
				OnComplete = delegate
				{
					agent.HideTool();
					if (building != null && !building.HasDisposed && MonoSingleton<ConstructablesGoapUninstallManager>.Instance.ObjectsToUninstall.Contains(building))
					{
						MonoSingleton<ConstructionController>.Instance.BuildingUninstalled(building, agent.GetPosition(), base.AgentOwner as HumanoidInstance);
						building.Map.BuildingsManagerMain.BuildingDeconstructed(building);
					}
				}
			};
			yield return uninstallAction.FailIfTargetDisposedForbidenOrNull(TargetIndex.A).TriggerAnimation("Build", ActionAnimationMode.Interrupt).FailAtCondition(() => !MonoSingleton<ConstructablesGoapUninstallManager>.Instance.ObjectsToUninstall.Contains(GetTarget(TargetIndex.A).GetObjectAs<BaseBuildingInstance>()));
		}

		private bool PrepareData()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				BaseBuildingInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<BaseBuildingInstance>();
				if (objectAs.MarkedForMoving || objectAs.MarkedForUninstall)
				{
					QueueTarget(TargetIndex.A, base.PreferredReservableHandler.GetTarget());
					return true;
				}
			}
			List<TargetObject> list = PathfinderBuilding.FindAllMarkedForUninstall((IPathfindingAgent)base.AgentOwner);
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			return true;
		}

		private bool ReserveTargets()
		{
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}
	}
}
