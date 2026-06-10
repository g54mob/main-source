using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.CombatAi;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class SleepGoal : LayDownBaseGoal
	{
		private const int BedSearchLimit = 50;

		private Vec3Int creatureGridPosition = Vec3Int.zero;

		private AnimalInstance animal;

		private readonly Dictionary<BedComponentInstance, int> bedsWithScore = new Dictionary<BedComponentInstance, int>();

		private readonly bool cannotSleepOnWater;

		private CreatureBase creature;

		private List<MapNode> nonWaterNodes;

		private readonly HashSet<MapNode> outOfRangeRoofedNodes;

		private readonly List<MapNode> possibleRoofedNodes;

		public SleepGoal(Agent selfAgent)
			: base("SleepGoal", selfAgent)
		{
			possibleRoofedNodes = new List<MapNode>();
			outOfRangeRoofedNodes = new HashSet<MapNode>();
			nonWaterNodes = new List<MapNode>();
			animal = base.AgentOwner as AnimalInstance;
			creature = base.AgentOwner as CreatureBase;
			cannotSleepOnWater = true;
			AddInitStep(new ThreadSequenceStep(CanSleep, FindSleepingSpot));
		}

		public override void Dispose()
		{
			base.Dispose();
			animal = null;
			creature = null;
			animal = null;
			bedsWithScore.Clear();
			nonWaterNodes.Clear();
			outOfRangeRoofedNodes.Clear();
			possibleRoofedNodes.Clear();
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is ISleepAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (creature?.Map?.RoomDetection == null)
			{
				return false;
			}
			if (animal != null && animal.AnimalType == AnimalType.Pet && animal.PetOwner != null && animal.PetOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
			{
				return humanoidInstance.IsSleeping;
			}
			if (creature is HumanoidInstance humanoidInstance2 && humanoidInstance2.IsCaptive())
			{
				CaptiveNpcBehaviour captiveNpcBehaviour = humanoidInstance2.CaptiveNpcBehaviour;
				if (captiveNpcBehaviour.Owner != null)
				{
					return captiveNpcBehaviour.Owner.IsSleeping;
				}
			}
			return !creature.IsOnFire;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (!MonoSingleton<LifeController>.IsInstantiated())
			{
				return;
			}
			CreatureBase creatureBase = base.AgentOwner as CreatureBase;
			if (creatureBase != null)
			{
				creature.IsSleeping = false;
			}
			if (condition != GoalCondition.Succeeded)
			{
				Log.Debug("Sleep goal ended with condition " + condition.ToString() + " Action: " + base.CurrentAction?.Id + " Status: " + (base.CurrentAction?.CompletionStatus).ToString() + " " + base.AgentOwner, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\SleepGoal.cs");
			}
			if (base.State == GoalState.Running && base.AgentOwner is HumanoidInstance { HasDisposed: false, ActiveBehaviour: not null } humanoidInstance)
			{
				HandleHumanoidEffectors(humanoidInstance);
			}
			if (creatureBase != null && !creatureBase.HasFainted)
			{
				MonoSingleton<LifeController>.Instance.WakeUp(creatureBase.Stats);
			}
			if (creatureBase is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance2)
			{
				string text = humanoidInstance2.CurrentHumanType.SleepEffectors.FirstOrDefault((StringStringPair item) => item.Key.Equals("sleeping"))?.Value;
				if (!string.IsNullOrEmpty(text))
				{
					humanoidInstance2.Stats.EndEffector(text);
				}
				humanoidInstance2.WorkerBehaviour.WorkerInteraction.FireGarmentEvent();
			}
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			ISleepAgent agent = (ISleepAgent)base.AgentOwner;
			GoapAction goapAction = MoveToBed(TargetIndex.A);
			if (goapAction != null)
			{
				yield return goapAction;
			}
			else if (GetTarget(TargetIndex.C).IsInitialized)
			{
				yield return GoToActions.GoToTarget(TargetIndex.C, PathCompleteMode.ExactPosition).FailAtCondition(delegate
				{
					if (animal == null)
					{
						return false;
					}
					TargetObject target = GetTarget(TargetIndex.C);
					MapNode node = animal.Map.GetNode(target.ReachablePosition);
					return node != null && node.CreaturesCount >= 2;
				});
			}
			GoapAction action = LayDownAction("Sleep", recoverSleepStat: true, TargetIndex.A);
			action.OnInit = delegate
			{
				if (CombatUtils.IsNullOrDisposed(agent))
				{
					action.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					agent.IsSleeping = true;
					if (base.AgentOwner is CreatureBase creatureBase)
					{
						creatureBase.CanReceiveWoundTreatment = true;
					}
					agent.Map.ProtectorCreatureManager.CreatureStateChanged(agent as CreatureBase, agent.GetNode(), agent.GetNode());
					if (agent is HumanoidInstance { ActiveBehaviour: not null, HasDisposed: false } humanoidInstance)
					{
						string value = humanoidInstance.CurrentHumanType.SleepEffectors.FirstOrDefault((StringStringPair item) => item.Key.Equals("sleeping")).Value;
						if (!string.IsNullOrEmpty(value))
						{
							humanoidInstance.Stats.StartEffector(value);
						}
						TargetObject target = GetTarget(TargetIndex.A);
						if (!target.IsInitialized)
						{
							foreach (string sleepingOnGroundEffector in humanoidInstance.CurrentHumanType.SleepingOnGroundEffectors)
							{
								if (!string.IsNullOrEmpty(sleepingOnGroundEffector))
								{
									humanoidInstance.Stats.StartEffector(sleepingOnGroundEffector);
								}
							}
						}
						else
						{
							action.FailIfTargetDisposed(TargetIndex.A);
							BedComponentBlueprint bedComponentBlueprint = target.GetObjectAs<BedComponentInstance>()?.Blueprint;
							if (bedComponentBlueprint != null)
							{
								foreach (string workerEffector in bedComponentBlueprint.WorkerEffectors)
								{
									if (!string.IsNullOrEmpty(workerEffector))
									{
										humanoidInstance.Stats.StartEffector(workerEffector);
										bool isEnabled;
										FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\SleepGoal.cs");
										if (isEnabled)
										{
											messageBuilder.AppendLiteral("Starting ");
											messageBuilder.AppendFormatted(bedComponentBlueprint.GetID());
											messageBuilder.AppendLiteral(" sleep effector: ");
											messageBuilder.AppendFormatted(workerEffector);
										}
										Log.Info(messageBuilder);
									}
								}
							}
						}
					}
					if (animal != null)
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseAll(agent);
					}
					MonoSingleton<LifeController>.Instance.FallAsleep(agent.Stats);
					LifeController.UpdateLifeDelegate fun = null;
					fun = delegate(StatsInstance stats)
					{
						if (stats == agent.Stats)
						{
							agent.IsSleeping = false;
							MonoSingleton<LifeController>.Instance.WakeUpEvent -= fun;
						}
					};
					MonoSingleton<LifeController>.Instance.WakeUpEvent += fun;
				}
			};
			action.CompleteAtCondition(delegate
			{
				if (!agent.IsSleeping || agent.HasDisposed)
				{
					return true;
				}
				if (agent is CreatureBase { IsOnFire: not false })
				{
					return true;
				}
				if (!(agent is HumanoidInstance { WorkerBehaviour: not null, CombatAi: not null } humanoidInstance))
				{
					return false;
				}
				TargetObject target = GetTarget(TargetIndex.A);
				if (target.IsInitialized)
				{
					BedComponentInstance objectAs = target.GetObjectAs<BedComponentInstance>();
					if (objectAs != null && (objectAs.Underwater || objectAs.IsOnFire))
					{
						return true;
					}
				}
				return humanoidInstance.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles)?.Any((IDamageDealAgent item) => (item as HumanoidInstance)?.IsEnemy() ?? false) ?? false;
			});
			action.OnComplete = delegate
			{
				if (base.AgentOwner is CreatureBase creatureBase)
				{
					creatureBase.CanReceiveWoundTreatment = false;
				}
			};
			action.FailAtCondition(() => GetTarget(TargetIndex.A).GetObjectAs<BedComponentInstance>()?.IsUnavailable ?? false);
			yield return action;
		}

		private bool CanSleep()
		{
			if (!(base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance))
			{
				return true;
			}
			IDamageDealAgent damageDealAgent = humanoidInstance.CombatAi.GetState<IDamageDealAgent>(CombatAiState.NearestHostile);
			if (damageDealAgent == null)
			{
				return true;
			}
			if (damageDealAgent.GetType() == base.AgentOwner.GetType())
			{
				return true;
			}
			if (damageDealAgent is HumanoidInstance humanoidInstance2 && !humanoidInstance2.IsEnemy())
			{
				return true;
			}
			return false;
		}

		private bool FindSleepingSpot()
		{
			HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
			if (humanoidInstance != null && CombatUtils.IsNullOrDisposed(humanoidInstance))
			{
				return false;
			}
			if (HasValidPreferedTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				BedComponentInstance objectAs = target.GetObjectAs<BedComponentInstance>();
				if (!objectAs.IsUnavailable && IsBedValid(objectAs) && objectAs.OwnerBuilding.BuildingOwnershipInfo != null && objectAs.OwnerBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance) && !objectAs.IsOnFire && !objectAs.Underwater && objectAs.OwnerBuilding.OwnedByPlayer() && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					SetTarget(TargetIndex.A, target);
					return true;
				}
			}
			if (animal != null)
			{
				if (animal.AnimalType == AnimalType.Wild || animal.AnimalType == AnimalType.WildAggressive)
				{
					IdlePointManager.AnimalIdlePoint idlePoint;
					MapNode idlePointForAnimal = creature.Map.IdlePoints.GetIdlePointForAnimal(animal, out idlePoint);
					if (idlePointForAnimal != null)
					{
						SetTarget(TargetIndex.C, new TargetObject(idlePointForAnimal.Position));
					}
					else
					{
						SetTarget(TargetIndex.C, new TargetObject(animal.GetGridPosition()));
					}
					return true;
				}
				FindRoofedNodes();
				return true;
			}
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			creatureGridPosition = creatureBase.GetGridPosition();
			ClearTargets();
			List<BedComponentInstance> list = ListPool<BedComponentInstance>.Get();
			if (Map.BedComponentManager.ComponentCount <= MonoSingleton<WorkerManager>.Instance.AllWorkers.Count && Map.BedComponentManager.OwnsABed(creatureBase as HumanoidInstance))
			{
				foreach (BedComponentInstance bed in Map.BedComponentManager.GetBeds(BedType.Basic))
				{
					if (!bed.HasDisposed)
					{
						BuildingOwnershipInfo buildingOwnershipInfo = bed.OwnerBuilding.BuildingOwnershipInfo;
						if (buildingOwnershipInfo != null && buildingOwnershipInfo.IsOwner(humanoidInstance))
						{
							list.Add(bed);
							break;
						}
					}
				}
			}
			else
			{
				list.AddRange(Map.BedComponentManager.GetBeds(BedType.Basic).Where(delegate(BedComponentInstance bed)
				{
					bool num = bed.OwnerBuilding.OwnedByPlayer();
					bool flag2 = bed.OwnerBuilding.BuildingOwnershipInfo?.IsOwner(humanoidInstance) ?? false;
					BuildingOwnershipInfo buildingOwnershipInfo2 = bed.OwnerBuilding.BuildingOwnershipInfo;
					bool flag3 = buildingOwnershipInfo2 != null && !buildingOwnershipInfo2.Occupied;
					bool flag4 = bed.OwnerBuilding.BuildingOwnershipInfo?.HasTempOwner() ?? false;
					return num && !bed.HasDisposed && (flag2 || flag3) && !flag4;
				}));
			}
			bedsWithScore.Clear();
			foreach (BedComponentInstance item in list)
			{
				bedsWithScore.Add(item, (int)(1000f * GetBedScore(item, humanoidInstance)));
			}
			list = list.OrderByDescending((BedComponentInstance x) => bedsWithScore[x]).ToList();
			ReservationManager instance = MonoSingleton<ReservationManager>.Instance;
			MapNode node = creatureBase.GetNode();
			HashSet<HumanoidInstance> faintedWorkers = MonoSingleton<WorkerManager>.Instance.FaintedWorkers;
			foreach (BedComponentInstance item2 in list)
			{
				if (item2.IsUnavailable || !IsBedValid(item2))
				{
					continue;
				}
				if (!PathfinderUtil.IsPathPossible(creatureBase.WalkableModel, node, item2.GetNode()))
				{
					if (item2.OwnerBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance))
					{
						item2.OwnerBuilding.BuildingOwnershipInfo.ClearOwner();
					}
					continue;
				}
				if (faintedWorkers.Count > 0)
				{
					bool flag = false;
					foreach (Vec3Int position in item2.Positions)
					{
						MapNode bedNode = item2.Map.GetNode(position);
						if (!faintedWorkers.All((HumanoidInstance faintedWorker) => !CombatUtils.IsNullOrDisposed(faintedWorker) && faintedWorker.GetNode() != bedNode))
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						continue;
					}
				}
				if (instance.IsReserved(item2) && !instance.TryReserveObject(item2, base.AgentOwner))
				{
					continue;
				}
				SetTarget(TargetIndex.A, new TargetObject(item2));
				ListPool<BedComponentInstance>.Return(list);
				return true;
			}
			ListPool<BedComponentInstance>.Return(list);
			FindRoofedNodes();
			return true;
		}

		private bool IsBedValid(BedComponentInstance bedToValidate)
		{
			if (!(creature is HumanoidInstance human))
			{
				return false;
			}
			if (!CommonGoalMethods.CheckPrisonConditions(human, bedToValidate.OwnerBuilding.GetRoom()))
			{
				return false;
			}
			return true;
		}

		protected override float GetBedScore(BedComponentInstance bed, HumanoidInstance humanoidInstance)
		{
			float num = Vec3Int.Distance(bed.GridDataPosition, in creatureGridPosition);
			float num2 = ((bed.BaseBuildingBlueprint != null) ? bed.BaseBuildingBlueprint.WealthPoints : 0f);
			float temperature = bed.Map.TemperatureManager.GetTemperature(bed.GetNode().Position);
			bool flag = temperature > humanoidInstance.OptimalNodeTemperatureRangeMin && temperature < humanoidInstance.OptimalNodeTemperatureRangeMax;
			float num3 = num2 * 2f;
			float num4 = 0f;
			if (bed?.OwnerBuilding.BuildingOwnershipInfo?.IsOwner(humanoidInstance) == true)
			{
				num4 = num3 * 60f;
			}
			num3 += num4;
			if (flag)
			{
				num3 *= 2f;
			}
			else
			{
				float value = ((temperature <= humanoidInstance.OptimalNodeTemperatureRangeMin) ? Mathf.Abs(humanoidInstance.OptimalNodeTemperatureRangeMin - temperature) : Mathf.Abs(temperature - humanoidInstance.OptimalNodeTemperatureRangeMax));
				value = Mathf.Clamp(value, 0f, num3);
				num3 -= Mathf.Lerp(num3, value, 0.5f);
			}
			if (num > 150f)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\SleepGoal.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Bed at position ");
					messageBuilder.AppendFormatted(bed.GridDataPosition);
					messageBuilder.AppendLiteral(" too far, set score to 0.");
				}
				Log.Info(messageBuilder);
				return 0f;
			}
			switch (bed.GetNode().Coverage)
			{
			case CoverageType.Roofed:
				if (creature.Map.RoomDetection.GetRoom(bed.GridDataPosition) == null)
				{
					num3 *= 0.5f;
				}
				break;
			case CoverageType.Outside:
				num3 -= num4;
				num3 *= 0.25f;
				break;
			}
			return num3;
		}

		private bool FindRoofedNodes()
		{
			if (CombatUtils.IsNullOrDisposed(creature))
			{
				return false;
			}
			if (GetTargetQueue(TargetIndex.A).Count > 0)
			{
				return true;
			}
			bool isPetWithOwner = animal != null && animal.PetOwner != null;
			Vec3Int ownerPos = (isPetWithOwner ? animal.PetOwner.GetGridPosition() : Vec3Int.zero);
			CreatureBase agent = (CreatureBase)base.AgentOwner;
			float minScore = float.MaxValue;
			int optimalNodes = 0;
			System.Random random = new System.Random();
			possibleRoofedNodes.Clear();
			outOfRangeRoofedNodes.Clear();
			nonWaterNodes.Clear();
			HomeArea homeArea = creature.Map.HomeArea;
			MapNode creatureStandingOnNode = creature.GetNode();
			FloodFillUtil.FloodFillConnections(agent.Map, agent.GetGridPosition(), 60f, delegate(MapNode node)
			{
				if ((node.Tag & MapNodeTags.Ladder) != MapNodeTags.None)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (!agent.PathTraversalProvider.CanStandOnNode(node))
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				if (node.CreaturesCount > 0 && node != creatureStandingOnNode)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (node.Map.FireSimLogic.GetFireData(node.Index) > 0f)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (creature is HumanoidInstance human && !CommonGoalMethods.CheckPrisonConditions(human, node.Map.RoomDetection.GetRoom(node)))
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (!homeArea.IsHomeArea(node.Index))
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (cannotSleepOnWater && (creature.Map.WaterManager.GetWaterDepthLevel(node.Index) & (WaterDepthLevel.Medium | WaterDepthLevel.High)) != 0)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if (animal != null && !PathfinderUtil.IsPathPossible(agent, node))
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				GridDataType gridDataType = GridDataType.SlopeOrStairs | GridDataType.BuildingUnfinished | GridDataType.OthersUnfinished | GridDataType.Furniture | GridDataType.ProductionBuilding | GridDataType.Trap | GridDataType.Grave;
				if ((node.DataType & gridDataType) != GridDataType.None)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				if ((node.Tag & (MapNodeTags.WaterLevelLow | MapNodeTags.WaterLevelMedium | MapNodeTags.WaterLevelHigh | MapNodeTags.WaterDepthHigh)) != MapNodeTags.None)
				{
					return FloodFillUtil.ScanStatus.Continue;
				}
				nonWaterNodes.Add(node);
				if (isPetWithOwner)
				{
					float num = (ownerPos - node.Position).sqrMagnitude;
					if (num < minScore && num > 0f)
					{
						minScore = num;
						SetTarget(TargetIndex.C, new TargetObject(node.Position));
						if (num < 2f)
						{
							return FloodFillUtil.ScanStatus.Abort;
						}
					}
				}
				else
				{
					if (node.Coverage != CoverageType.Roofed || (node.DataType & (GridDataType.SlopeOrStairs | GridDataType.Roof)) != GridDataType.None)
					{
						return FloodFillUtil.ScanStatus.Continue;
					}
					switch (node.Map.TemperatureManager.GetNodeTemperaturePriority(creature, node))
					{
					case 0:
						possibleRoofedNodes.Insert(random.Next(optimalNodes), node);
						optimalNodes++;
						break;
					case 1:
						possibleRoofedNodes.Insert(random.Next(optimalNodes, possibleRoofedNodes.Count), node);
						break;
					default:
						outOfRangeRoofedNodes.Add(node);
						break;
					}
					if (possibleRoofedNodes.Count >= 10)
					{
						return FloodFillUtil.ScanStatus.Abort;
					}
				}
				return FloodFillUtil.ScanStatus.Continue;
			});
			MapNode mapNode;
			if (possibleRoofedNodes.Count > 0)
			{
				mapNode = possibleRoofedNodes[0];
			}
			else if (outOfRangeRoofedNodes.Count > 0)
			{
				mapNode = outOfRangeRoofedNodes.First();
			}
			else
			{
				if (nonWaterNodes.Count <= 0)
				{
					return false;
				}
				mapNode = nonWaterNodes[0];
			}
			QueueTarget(TargetIndex.C, new TargetObject(mapNode.Position));
			SelectTarget(TargetIndex.C, GetTargetQueue(TargetIndex.C).First());
			return true;
		}

		private void HandleHumanoidEffectors(HumanoidInstance humanoid)
		{
			Worker baseWorker = Repository<WorkerBaseRepository, Worker>.Instance.BaseWorker;
			if (base.TotalTickingTime < baseWorker.MinSleepEffectorTime * (float)GlobalSaveController.CurrentVillageData.DateAndTime.MinutesInHour)
			{
				return;
			}
			Room room = humanoid.Room;
			TargetObject target = GetTarget(TargetIndex.A);
			BedComponentInstance objectAs = target.GetObjectAs<BedComponentInstance>();
			if (!target.IsInitialized)
			{
				string value = humanoid.CurrentHumanType.SleepEffectors.FirstOrDefault((StringStringPair item) => item.Key.Equals("ground")).Value;
				humanoid.Stats.StartEffector(value);
				foreach (string sleepingOnGroundEffector in humanoid.CurrentHumanType.SleepingOnGroundEffectors)
				{
					if (!string.IsNullOrEmpty(sleepingOnGroundEffector))
					{
						humanoid.Stats.EndEffector(sleepingOnGroundEffector);
					}
				}
			}
			else
			{
				List<string> list = room?.RoomType?.GetSleepEffectors(room.Impressiveness);
				bool isEnabled;
				if (list != null && list.Count > 0)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(38, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\SleepGoal.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Humanoid ");
						messageBuilder.AppendFormatted(humanoid);
						messageBuilder.AppendLiteral(" slept in ");
						messageBuilder.AppendFormatted(room.RoomType?.NameLocalized);
						messageBuilder.AppendLiteral(". Firing effectors ");
						messageBuilder.AppendFormatted(string.Join(", ", list));
					}
					Log.Info(messageBuilder);
					humanoid.Stats.StartEffectors(list);
				}
				else
				{
					string bedId = objectAs.Blueprint.GetID();
					string value2 = humanoid.CurrentHumanType.SleepEffectors.FirstOrDefault((StringStringPair item) => item.Key.Equals(bedId)).Value;
					if (value2 != string.Empty)
					{
						humanoid.Stats.StartEffector(value2);
					}
					BedComponentBlueprint bedComponentBlueprint = objectAs?.Blueprint;
					if (bedComponentBlueprint != null)
					{
						foreach (string workerEffector in bedComponentBlueprint.WorkerEffectors)
						{
							if (!string.IsNullOrEmpty(workerEffector))
							{
								humanoid.Stats.EndEffector(workerEffector);
								FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\SleepGoal.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Ending ");
									messageBuilder.AppendFormatted(bedComponentBlueprint.GetID());
									messageBuilder.AppendLiteral(" sleep effector: ");
									messageBuilder.AppendFormatted(workerEffector);
								}
								Log.Info(messageBuilder);
							}
						}
					}
				}
			}
			bool num = room == null;
			bool flag = MonoSingleton<WeatherManager>.Instance.IsEventRunning("rain") || MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning("game_event_thunderstorm") || MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.IsEventRunning("game_event_hailstorm");
			bool flag2 = MonoSingleton<WeatherManager>.Instance.IsEventRunning("snow");
			if (!humanoid.IsRoofed())
			{
				if (flag2)
				{
					string value3 = humanoid.CurrentHumanType.SleepEffectors.FirstOrDefault((StringStringPair item) => item.Key.Equals("snow")).Value;
					humanoid.Stats.StartEffector(value3);
				}
				if (flag)
				{
					string value4 = humanoid.CurrentHumanType.SleepEffectors.FirstOrDefault((StringStringPair item) => item.Key.Equals("rain")).Value;
					humanoid.Stats.StartEffector(value4);
				}
			}
			if (num)
			{
				string value5 = humanoid.CurrentHumanType.SleepEffectors.FirstOrDefault((StringStringPair item) => item.Key.Equals("outside")).Value;
				humanoid.Stats.StartEffector(value5);
			}
			string iD = humanoid.CurrentHumanType.WakeUpEffectors.GetRandomByWeight((KeyIntPair e) => e.Value).GetID();
			if (!iD.Equals("none"))
			{
				humanoid.Stats.StartEffector(iD);
			}
			if (humanoid.WorkerBehaviour != null)
			{
				if (objectAs != null)
				{
					humanoid.WorkerBehaviour.WorkerInteraction.FireBedInteractionEvent(objectAs, iD);
				}
				humanoid.WorkerBehaviour.WorkerInteraction.FireInteractionEvent("slept_in_same_room");
			}
		}
	}
}
