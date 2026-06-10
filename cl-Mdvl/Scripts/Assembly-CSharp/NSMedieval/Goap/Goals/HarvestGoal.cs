using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Crops;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Water;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class HarvestGoal : Goal
	{
		private bool cropStateChanged;

		private List<TargetObject> plantsToHarvest = new List<TargetObject>();

		public HarvestGoal(Agent selfAgent)
			: base("HarvestGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<PlantMapResourceInstance>());
			AddInitStep(new ThreadSequenceStep(null, PrepareData, PickPlant));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IHarvestAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			foreach (MapResourceInstance item in MonoSingleton<PlantResourceManager>.Instance.ResourcesWithOrders[OrderType.Harvesting])
			{
				if (!item.IsOnFire)
				{
					return true;
				}
			}
			return false;
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			PlantMapResourceInstance plantMapResourceInstance = GetTarget(TargetIndex.A).GetObjectAs<PlantMapResourceInstance>();
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => FailCondition(plantMapResourceInstance) || CropConfigChanged(plantMapResourceInstance));
			GoapAction goapAction = MapResourceActions.StartObtaining(TargetIndex.A, OrderType.Harvesting).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).TriggerAnimation("Harvest", ActionAnimationMode.Interrupt)
				.FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => FailCondition(plantMapResourceInstance) || CropConfigChanged(plantMapResourceInstance));
			goapAction.OnComplete = delegate
			{
				if (base.State == GoalState.Ended && !cropStateChanged)
				{
					DamagePopup.Create(((IHarvestAgent)base.AgentOwner).GetPosition(), MonoSingleton<LocalizationController>.Instance.GetText("harvest_failed"), Color.red);
					if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
					{
						humanoidInstance.WorkerBehaviour.WorkerProximity.OnChopFailed();
					}
				}
			};
			yield return goapAction;
			yield return MapResourceActions.SpawnHarvestedResources(TargetIndex.A, OrderType.Harvesting);
		}

		private bool PrepareData()
		{
			cropStateChanged = false;
			if (plantsToHarvest == null)
			{
				plantsToHarvest = new List<TargetObject>();
			}
			plantsToHarvest.Clear();
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				PlantMapResourceInstance objectAs = target.GetObjectAs<PlantMapResourceInstance>();
				if ((objectAs.CurrentOrder & OrderType.Harvesting) == OrderType.Harvesting && objectAs.HarvestPhase > 0 && !FailCondition(objectAs))
				{
					plantsToHarvest.Add(target);
					return true;
				}
			}
			plantsToHarvest = PathfinderMedieval.FindMedievalObjects<PlantMapResourceInstance>((IPathfindingAgent)base.AgentOwner, PathfinderCore.FetchList(GridDataType.PlantMapResource), CheckValidity);
			if (plantsToHarvest != null)
			{
				return plantsToHarvest.Count != 0;
			}
			return false;
			bool CheckValidity(PlantMapResourceInstance plant)
			{
				if ((plant.CurrentOrder & OrderType.Harvesting) != OrderType.None && !CropConfigChanged(plant))
				{
					return !FailCondition(plant);
				}
				return false;
			}
		}

		private bool PickPlant()
		{
			if (plantsToHarvest.Count == 0)
			{
				return false;
			}
			plantsToHarvest = plantsToHarvest.OrderByDescending((TargetObject x) => (int)x.GetObjectAs<PlantMapResourceInstance>().Priority).ToList();
			ClearTargetsQueue(TargetIndex.A);
			QueueTargets(TargetIndex.A, plantsToHarvest);
			while (SelectNextTarget(TargetIndex.A))
			{
				TargetObject target = GetTarget(TargetIndex.A);
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					return true;
				}
			}
			return false;
		}

		private bool CropConfigChanged(PlantMapResourceInstance plantMapResourceInstance)
		{
			if (!plantMapResourceInstance.Domestic)
			{
				return false;
			}
			if (plantMapResourceInstance.PlayerOrder)
			{
				return false;
			}
			CropfieldInstance cropfieldInstance = MonoSingleton<CropsManager>.Instance.GetCropfieldInstance(plantMapResourceInstance.GridDataPosition);
			if (cropfieldInstance == null)
			{
				return false;
			}
			if (cropfieldInstance.FactionOwnership != FactionOwnership.Player)
			{
				return true;
			}
			if (cropfieldInstance.HarvestPhase < 0)
			{
				cropStateChanged = true;
				return true;
			}
			return false;
		}

		private bool FailCondition(PlantMapResourceInstance plantMapResourceInstance)
		{
			if (plantMapResourceInstance == null || plantMapResourceInstance.HasDisposed)
			{
				return false;
			}
			if (plantMapResourceInstance.IsOnFire)
			{
				return true;
			}
			WaterDepthLevel waterDepthLevel = plantMapResourceInstance.WaterDepthLevel;
			if (waterDepthLevel != WaterDepthLevel.Medium)
			{
				return waterDepthLevel == WaterDepthLevel.High;
			}
			return true;
		}
	}
}
