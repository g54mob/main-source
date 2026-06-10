using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("TrapComponentInstance", "")]
	public class TrapComponentInstance : BaseComponentInstance
	{
		[SerializeField]
		private bool operational;

		[NonSerialized]
		private TrapComponentBlueprint blueprint;

		public bool Operational => operational;

		public TrapComponentBlueprint Blueprint => blueprint;

		public event Action TriggerEvent;

		public event Action ReactivateEvent;

		public TrapComponentInstance(BaseBuildingInstance ownerBuilding, TrapComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			operational = true;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.TrapComponentsManager.RemoveFromCache(this);
				base.Dispose();
				this.ReactivateEvent = null;
				this.TriggerEvent = null;
			}
		}

		public void Trigger()
		{
			operational = false;
			base.OwnerBuilding.OverridePathfindingPenalty(blueprint.PathfindingPenaltyActive);
			base.OwnerBuilding.OverrideWalkSpeedMultiplier(blueprint.WalkSpeedMultiplierActive);
			TrySpawnOil();
			TrySpawnFire();
			this.TriggerEvent?.Invoke();
			if (UnityEngine.Random.Range(0f, 1f) <= blueprint.ChanceToDestroyAfterTriggering)
			{
				base.OwnerBuilding.Map.BuildingsManagerMain.DestroyVoxelBuilding(base.OwnerBuilding);
			}
		}

		private void TrySpawnFire()
		{
			if (!(blueprint.SpawnFire > 0f))
			{
				return;
			}
			MapNode node = GetNode();
			if (blueprint.SpawnFireRadius <= 1f)
			{
				base.Map.FireSimLogic.SetFireData(node.Index, blueprint.SpawnFire);
				return;
			}
			FloodFillUtil.FloodFillConnections(node, blueprint.SpawnFireRadius, delegate(MapNode mapNode)
			{
				if ((mapNode.Tag & MapNodeTags.Wall) != MapNodeTags.None || mapNode.VoxelType != null || !mapNode.IsWalkable)
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				base.Map.FireSimLogic.SetFireData(mapNode.Index, blueprint.SpawnFire);
				base.Map.FireSimLogic.SetFlameType(mapNode.Index, blueprint.FireType);
				return FloodFillUtil.ScanStatus.Continue;
			});
		}

		private void TrySpawnOil()
		{
			if (!(blueprint.SpawnOilRadius >= 1f))
			{
				return;
			}
			FloodFillUtil.FloodFillConnections(GetNode(), blueprint.SpawnOilRadius, delegate(MapNode node)
			{
				if ((node.Tag & MapNodeTags.Wall) != MapNodeTags.None || node.VoxelType != null || !node.IsWalkable)
				{
					return FloodFillUtil.ScanStatus.InvalidNode;
				}
				base.Map.FireSimLogic.SetOilBlobHealth(node.Index, 1f, blueprint.OilType);
				return FloodFillUtil.ScanStatus.Continue;
			});
		}

		public void Reactivate()
		{
			operational = true;
			base.OwnerBuilding.LoadDefaultPathfindingPenalty();
			base.OwnerBuilding.LoadDefaultWalkSpeedMultiplier();
			this.ReactivateEvent?.Invoke();
		}

		public float GetChanceToTrigger(IDamageTakingAgent target)
		{
			if (!(target is HumanoidInstance humanoidInstance))
			{
				if (target is AnimalInstance animalInstance)
				{
					if (animalInstance.AnimalType == AnimalType.Domestic || animalInstance.AnimalType == AnimalType.Pet || animalInstance.AnimalType == AnimalType.DomesticNpc)
					{
						return blueprint.AffectsDomesticAnimal;
					}
					return blueprint.AffectsAnimal;
				}
				return -1f;
			}
			if (humanoidInstance.WorkerBehaviour != null)
			{
				return blueprint.AffectsWorker;
			}
			return blueprint.AffectsEnemy;
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("operational", operational);
		}

		public TrapComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<TrapComponentRepository, TrapComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Traps\\TrapComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in TrapComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				operational = deserializer.ReadBool("operational");
			}
		}
	}
}
