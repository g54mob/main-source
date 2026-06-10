using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Goap.Actions;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class FaithGoal : Goal
	{
		private readonly List<string> prayEffectorsStarted = new List<string>();

		private VillageMap map;

		private ReservablePosition reservablePosition;

		private RugComponentInstance rugInstance;

		private HumanoidInstance humanoid;

		public FaithGoal(Agent selfAgent)
			: base("FaithGoal", selfAgent, GoalInterruptMode.HigherPriority)
		{
			map = VillageManager.ActiveVillage.Map;
			humanoid = (HumanoidInstance)base.AgentOwner;
			AddInitStep(new ThreadSequenceStep(null, FindShrine));
		}

		public override void Dispose()
		{
			base.Dispose();
			map = null;
			humanoid = null;
			rugInstance = null;
			reservablePosition = null;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (map == null)
			{
				return false;
			}
			if (map.ShrineComponentManager.ComponentCount == 0)
			{
				return false;
			}
			ReligionConfig religionConfig = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(humanoid.Stats.GetStat(StatType.ReligiousAlignment).Current);
			bool isEnabled;
			if (religionConfig == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FaithGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Religion config not found for ");
					messageBuilder.AppendFormatted(humanoid);
				}
				Log.Error(messageBuilder);
				return false;
			}
			if (religionConfig.Shrines == null || religionConfig.Shrines.Length == 0)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FaithGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No shrines specified for religion ");
					messageBuilder.AppendFormatted(religionConfig.GetID());
				}
				Log.Error(messageBuilder);
				return false;
			}
			return map.ShrineComponentManager.ComponentInstances.Any((ShrineComponentInstance shrine) => religionConfig.Shrines.Contains(shrine.OwnerBuildingID));
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A).FailAtCondition(FailAtCondition);
			GoapAction prayAction = new GoapAction("PrayAction")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			prayAction.OnInit = delegate
			{
				if (humanoid.HasDisposed || humanoid.Stats.HasDisposed)
				{
					EndGoalWith(GoalCondition.Error);
				}
				else
				{
					prayEffectorsStarted.Clear();
					bool isEnabled;
					if (humanoid.ActiveBehaviour.Blueprint != null)
					{
						IEnumerable<string> prayEffectors = humanoid.CurrentHumanType.PrayEffectors;
						if (prayEffectors != null)
						{
							FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(35, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FaithGoal.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("Humanoid ");
								messageBuilder.AppendFormatted(humanoid);
								messageBuilder.AppendLiteral(" prayed. Firing effectors ");
								messageBuilder.AppendFormatted(string.Join(", ", prayEffectors));
							}
							Log.Info(messageBuilder);
							foreach (string item in prayEffectors)
							{
								FaithModifier modifier = new FaithModifier();
								humanoid.Stats.AddAttributeModifier(modifier);
								humanoid.Stats.StartEffector(item);
								prayEffectorsStarted.Add(item);
							}
						}
					}
					ShrineComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ShrineComponentInstance>();
					ShrineComponent component = map.ShrineComponentManager.GetComponent(objectAs);
					if (component != null)
					{
						humanoid.FaceObject(component.ReservablePositionsComponent.GetUsePositionTransform(reservablePosition.Position));
					}
					prayAction.TriggerAnimation("Pray", ActionAnimationMode.Interrupt);
					Vec3Int position = reservablePosition.Position;
					rugInstance = map.RugComponentManager.GetComponentInstance(position);
					RugComponentBlueprint rugComponentBlueprint = rugInstance?.Blueprint;
					if (rugComponentBlueprint != null)
					{
						foreach (string workerEffector in rugComponentBlueprint.WorkerEffectors)
						{
							if (!string.IsNullOrEmpty(workerEffector))
							{
								humanoid?.Stats.StartEffector(workerEffector);
								FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FaithGoal.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Starting ");
									messageBuilder.AppendFormatted(rugComponentBlueprint.GetID());
									messageBuilder.AppendLiteral(" effector: ");
									messageBuilder.AppendFormatted(workerEffector);
								}
								Log.Info(messageBuilder);
							}
						}
					}
				}
			};
			prayAction.OnComplete = delegate
			{
				if (!humanoid.HasDisposed && !humanoid.Stats.HasDisposed)
				{
					humanoid.Stats.RemoveAttributeModifier(ModifierType.Praying, string.Empty);
					foreach (string item2 in prayEffectorsStarted)
					{
						humanoid.Stats.EndEffector(item2);
					}
					RugComponentBlueprint rugComponentBlueprint = rugInstance?.Blueprint;
					if (rugComponentBlueprint != null)
					{
						foreach (string workerEffector2 in rugComponentBlueprint.WorkerEffectors)
						{
							if (!string.IsNullOrEmpty(workerEffector2))
							{
								humanoid?.Stats.EndEffector(workerEffector2);
								bool isEnabled;
								FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(18, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FaithGoal.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Ending ");
									messageBuilder.AppendFormatted(rugComponentBlueprint.GetID());
									messageBuilder.AppendLiteral(" effector: ");
									messageBuilder.AppendFormatted(workerEffector2);
								}
								Log.Info(messageBuilder);
							}
						}
					}
				}
			};
			prayAction.TickOnInterval(1f, delegate
			{
				if (!humanoid.HasDisposed && !humanoid.Stats.HasDisposed)
				{
					StatInstance stat = humanoid.Stats.GetStat(StatType.Faith);
					if (stat == null || !(stat.Current < 99f))
					{
						prayAction.Complete(ActionCompletionStatus.Success);
					}
				}
			});
			prayAction.FailIfTargetDisposedOrNull(TargetIndex.A).FailAtCondition(FailAtCondition);
			yield return prayAction;
		}

		private bool FindShrine()
		{
			ReligionConfig configForFaith = Repository<ReligionRepository, ReligionConfig>.Instance.GetConfigForFaith(humanoid.Stats.GetStat(StatType.ReligiousAlignment).Current);
			bool isEnabled;
			if (configForFaith == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FaithGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Religion config not found for ");
					messageBuilder.AppendFormatted(humanoid);
				}
				Log.Error(messageBuilder);
				return false;
			}
			if (configForFaith.Shrines == null || configForFaith.Shrines.Length == 0)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\FaithGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("No shrines specified for religion ");
					messageBuilder.AppendFormatted(configForFaith.GetID());
				}
				Log.Error(messageBuilder);
				return false;
			}
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			List<WorldObject> targets = map.ShrineComponentManager.IterateComponentWorldObjects().ToList();
			List<TargetObject> list = PathfinderMedieval.FindMedievalObjects(pathfindingAgent, targets, delegate(BaseBuildingInstance building)
			{
				Room room = building.GetRoom();
				return room == null || !room.RoomType.Prison;
			});
			if (list == null || list.Count <= 0)
			{
				return false;
			}
			TargetObject[] array = list.ToArray();
			foreach (TargetObject targetObject in array)
			{
				WorldObject objectAs = targetObject.GetObjectAs<WorldObject>();
				if (objectAs == null || objectAs.HasDisposed || !objectAs.OwnedByPlayer())
				{
					continue;
				}
				ShrineComponentInstance componentInstance = map.ShrineComponentManager.GetComponentInstance(objectAs);
				if (componentInstance == null || componentInstance.HasDisposed || componentInstance.Underwater || componentInstance.IsOnFire || !configForFaith.Shrines.Contains(componentInstance.OwnerBuildingID) || componentInstance.ReservablePositionsComponentInstance.FreeSpace <= 0 || componentInstance.ReservablePositionsComponentInstance.ReservablePositions.All((ReservablePosition x) => x.Reserved))
				{
					continue;
				}
				foreach (ReservablePosition reservablePosition in componentInstance.ReservablePositionsComponentInstance.ReservablePositions)
				{
					if (!reservablePosition.Reserved && PathfinderUtil.IsPathPossible(pathfindingAgent, reservablePosition.Position))
					{
						this.reservablePosition = reservablePosition;
						reservablePosition.Reserve(base.AgentOwner);
						SetTarget(TargetIndex.A, new TargetObject(componentInstance, reservablePosition.Position));
						isEnabled = true;
						return isEnabled;
					}
				}
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			base.EndGoalWith(condition);
			reservablePosition?.Release(base.AgentOwner);
			reservablePosition = null;
			humanoid?.WorkerBehaviour?.WorkerInteraction.FireInteractionEvent("prayed_together");
		}

		private bool FailAtCondition()
		{
			ShrineComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<ShrineComponentInstance>();
			if (objectAs != null && !objectAs.HasDisposed && !objectAs.Underwater && !objectAs.IsOnFire)
			{
				return !CommonGoalMethods.CheckPrisonConditions(humanoid, objectAs.GetRoom());
			}
			return true;
		}
	}
}
