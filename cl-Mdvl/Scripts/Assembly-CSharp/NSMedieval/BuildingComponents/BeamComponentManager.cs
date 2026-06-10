using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class BeamComponentManager : ComponentBaseManager<BeamComponent, BeamComponentInstance>
	{
		private int minLength;

		private int maxLength;

		public event Action<BeamComponentInstance> BeamConstructedEvent;

		public event Action<BeamComponentInstance> BeamDestroyedEvent;

		public event Action<BeamComponentInstance> BeamPlacedEvent;

		public BeamComponentManager(VillageMap map)
			: base(map)
		{
			minLength = Repository<StabilityRepository, Stability>.Instance.GetByID("basic_stability").MinBeamLength;
			maxLength = Repository<StabilityRepository, Stability>.Instance.GetByID("basic_stability").MaxBeamLength;
			MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent += OnConstructionCompleted;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
		}

		public bool BeamExistsForBlueprints(Vec3Int gridPosition)
		{
			if (PositionInstanceDictionary.TryGetValue(gridPosition, out var value))
			{
				return !value.HasDisposed;
			}
			return false;
		}

		public bool BeamExists(Vec3Int gridPosition, bool onlyFinished)
		{
			if (!PositionInstanceDictionary.ContainsKey(gridPosition))
			{
				return false;
			}
			BeamComponentInstance beamComponentInstance = PositionInstanceDictionary[gridPosition];
			if (onlyFinished)
			{
				if (!beamComponentInstance.HasDisposed)
				{
					return beamComponentInstance.OwnerBuilding.ConstructionPhase.Equals(ConstructionPhase.Finished);
				}
				return false;
			}
			return !beamComponentInstance.HasDisposed;
		}

		public bool BeamExistsForFinished(Vec3Int gridPosition)
		{
			if (PositionInstanceDictionary.TryGetValue(gridPosition, out var value))
			{
				if (!value.HasDisposed)
				{
					return value.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished;
				}
				return false;
			}
			return false;
		}

		public BeamComponentInstance CreateBeamComponentInstance(BeamComponentBlueprint blueprint, BaseBuildingInstance owner, BeamViewComponent beamViewComponent, BeamComponent beamComponent)
		{
			BeamComponentInstance beamComponentInstance = ComponentFactory.CreateComponentInstance(owner, blueprint);
			beamComponent.CacheInstance(beamComponentInstance);
			return beamComponentInstance;
		}

		public void AllBeamCollidersEnabled(bool value)
		{
			foreach (KeyValuePair<BeamComponentInstance, BeamComponent> item in InstanceComponentDictionary)
			{
				item.Value.EnableColliders(value);
			}
		}

		private void CheckForBeamSplitting(BaseBuildingInstance buildingInstance)
		{
			if ((buildingInstance.BuildingType.Equals(BuildingType.Wall) || buildingInstance.BuildingType.Equals(BuildingType.Voxel)) && PositionInstanceDictionary.TryGetValue(buildingInstance.GridDataPosition, out var value) && (buildingInstance.ConstructionPhase != ConstructionPhase.Blueprint || value.OwnerBuilding.ConstructionPhase == ConstructionPhase.Blueprint))
			{
				SplitBeam(value, buildingInstance);
			}
		}

		public void BeamComponentDestroyed(BeamComponentInstance beamComponentInstance)
		{
			if (!beamComponentInstance.BeamWasSplit)
			{
				this.BeamDestroyedEvent?.Invoke(beamComponentInstance);
			}
		}

		public void BeamPlaced(BeamComponentInstance beamComponentInstance)
		{
			this.BeamPlacedEvent?.Invoke(beamComponentInstance);
		}

		public void BeamConstructed(BeamComponentInstance beamComponentInstance)
		{
			this.BeamConstructedEvent?.Invoke(beamComponentInstance);
		}

		private void SplitBeam(BeamComponentInstance beamToSplit, BaseBuildingInstance middleWall)
		{
			Vec3Int gridDataPosition = middleWall.GridDataPosition;
			ConstructionPhase constructionPhase = beamToSplit.OwnerBuilding.ConstructionPhase;
			BaseBuildingInstance startBuilding = beamToSplit.StartBuilding;
			BaseBuildingInstance endBuilding = beamToSplit.EndBuilding;
			Vec3Int startSocketGridPosition = beamToSplit.StartSocketGridPosition;
			Vec3Int endSocketGridPosition = beamToSplit.EndSocketGridPosition;
			bool flag = false;
			bool flag2 = false;
			if (beamToSplit.StartPoint.Equals(ObjectSide.Front))
			{
				if (Mathf.Abs(startSocketGridPosition.z - gridDataPosition.z) > minLength)
				{
					flag = true;
				}
				if (Mathf.Abs(endSocketGridPosition.z - gridDataPosition.z) > minLength)
				{
					flag2 = true;
				}
			}
			if (beamToSplit.StartPoint.Equals(ObjectSide.Right))
			{
				if (Mathf.Abs(startSocketGridPosition.x - gridDataPosition.x) > minLength)
				{
					flag = true;
				}
				if (Mathf.Abs(endSocketGridPosition.x - gridDataPosition.x) > minLength)
				{
					flag2 = true;
				}
			}
			beamToSplit.BeamWasSplit = true;
			BaseBuildingBlueprint baseBuildingBlueprint = beamToSplit.BaseBuildingBlueprint;
			Map.BuildingsManagerMain.DestroyBuilding(beamToSplit.OwnerBuilding, replaced: true);
			object start = ((startBuilding != null) ? startBuilding : ((object)startSocketGridPosition));
			object end = ((endBuilding != null) ? endBuilding : ((object)endSocketGridPosition));
			if (flag)
			{
				BaseBuildingInstance baseBuildingInstance = null;
				if (beamToSplit.StartPoint.Equals(ObjectSide.Front))
				{
					baseBuildingInstance = MonoSingleton<BuildingPlacementManager>.Instance.SpawnBeamAxisZ(baseBuildingBlueprint, start, middleWall)?.OwnerBuilding;
				}
				if (beamToSplit.StartPoint.Equals(ObjectSide.Right))
				{
					baseBuildingInstance = MonoSingleton<BuildingPlacementManager>.Instance.SpawnBeamAxisX(baseBuildingBlueprint, start, middleWall)?.OwnerBuilding;
				}
				if (baseBuildingInstance != null)
				{
					switch (constructionPhase)
					{
					case ConstructionPhase.Finished:
						baseBuildingInstance.AutoConstructSequence();
						break;
					case ConstructionPhase.Foundation:
						baseBuildingInstance.EnterFinishedState();
						break;
					}
				}
			}
			if (!flag2)
			{
				return;
			}
			BaseBuildingInstance baseBuildingInstance2 = null;
			if (beamToSplit.StartPoint.Equals(ObjectSide.Front))
			{
				baseBuildingInstance2 = MonoSingleton<BuildingPlacementManager>.Instance.SpawnBeamAxisZ(baseBuildingBlueprint, middleWall, end)?.OwnerBuilding;
			}
			if (beamToSplit.StartPoint.Equals(ObjectSide.Right))
			{
				baseBuildingInstance2 = MonoSingleton<BuildingPlacementManager>.Instance.SpawnBeamAxisX(baseBuildingBlueprint, middleWall, end)?.OwnerBuilding;
			}
			if (baseBuildingInstance2 != null)
			{
				switch (constructionPhase)
				{
				case ConstructionPhase.Finished:
					baseBuildingInstance2.AutoConstructSequence();
					break;
				case ConstructionPhase.Foundation:
					baseBuildingInstance2.EnterFoundationState();
					break;
				}
			}
		}

		public override void Dispose()
		{
			if (MonoSingleton<ConstructionController>.IsInstantiated())
			{
				MonoSingleton<ConstructionController>.Instance.ConstructionCompletedEvent -= OnConstructionCompleted;
				MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlaced;
			}
			this.BeamConstructedEvent = null;
			this.BeamDestroyedEvent = null;
			this.BeamPlacedEvent = null;
			base.Dispose();
		}

		private void OnBlueprintPlaced(BaseBuildingInstance baseBuildingInstance)
		{
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(delegate
			{
				CheckForBeamSplitting(baseBuildingInstance);
			});
		}

		private void OnConstructionCompleted(BaseBuildingInstance baseBuildingInstance)
		{
			CheckForBeamSplitting(baseBuildingInstance);
		}
	}
}
