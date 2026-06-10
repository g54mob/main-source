using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.Terrain;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("BeamComponentInstance", "")]
	public class BeamComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private readonly BeamComponentBlueprint blueprint;

		[SerializeField]
		private Vec3Int startSocketGridPosition;

		[SerializeField]
		private Vec3Int endSocketGridPosition;

		[SerializeField]
		private ObjectSide startSide;

		[SerializeField]
		private ObjectSide endSide;

		[SerializeField]
		private Vector3 rightOffset;

		[SerializeField]
		private Vector3 leftOffset;

		[SerializeField]
		private Vector3 scale;

		[NonSerialized]
		private BaseBuildingInstance startBuilding;

		[NonSerialized]
		private BaseBuildingInstance endBuilding;

		[NonSerialized]
		private readonly List<Vec3Int> reachablePoints = new List<Vec3Int>();

		public bool BeamWasSplit { get; set; }

		public BaseBuildingInstance StartBuilding => startBuilding;

		public BaseBuildingInstance EndBuilding => endBuilding;

		public ObjectSide StartPoint => startSide;

		public ObjectSide EndPoint => endSide;

		public BeamComponentBlueprint Blueprint => blueprint;

		public Vec3Int StartSocketGridPosition => startSocketGridPosition;

		public Vec3Int EndSocketGridPosition => endSocketGridPosition;

		public BeamComponentInstance(BaseBuildingInstance ownerBuilding, BeamComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			base.Map.BeamComponentManager.BeamPlaced(this);
		}

		public override void Dispose()
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			base.Map.BeamComponentManager.RemoveFromCache(this);
			base.Map.BeamComponentManager.BeamComponentDestroyed(this);
			if (startBuilding != null)
			{
				base.Map.SocketComponentManager.GetSocketComponentInstance(startBuilding.GridDataPosition)?.RemoveFromSocket(base.OwnerBuilding);
			}
			else
			{
				MonoSingleton<GroundManager>.Instance.RemoveFromVoxelSocket(startSocketGridPosition, StartPoint);
			}
			if (endBuilding != null)
			{
				base.Map.SocketComponentManager.GetSocketComponentInstance(endBuilding.GridDataPosition)?.RemoveFromSocket(base.OwnerBuilding);
			}
			else
			{
				MonoSingleton<GroundManager>.Instance.RemoveFromVoxelSocket(endSocketGridPosition, EndPoint);
			}
			base.OwnerBuilding.MainBuildingStabilityChangedEvent -= OnMainBuildingStabilityChanged;
			if (!BeamWasSplit)
			{
				base.Map.StabilityManager.BeamDestroyed(this);
			}
			startBuilding = null;
			endBuilding = null;
			reachablePoints.Clear();
			base.Dispose();
		}

		public override void SetupAfterLoading(BaseBuildingInstance baseBuildingInstance)
		{
			base.SetupAfterLoading(baseBuildingInstance);
			if (MonoSingleton<MigrationManager>.Instance.BeamsToSetup.Contains(baseBuildingInstance))
			{
				MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoadedMigration;
			}
			else
			{
				MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			}
			base.OwnerBuilding.HasStabilityToBuild = HasStabilityToBuild();
			base.OwnerBuilding.GetReachablePointsEvent += GetReachablePoints;
			base.OwnerBuilding.RequestHasStabilityToBuildEvent += OnRequestHasStabilityToBuild;
			base.OwnerBuilding.MainBuildingStabilityChangedEvent += OnMainBuildingStabilityChanged;
			if (base.Positions.Count == 1)
			{
				Vec3Int vec3Int = base.Positions[0];
				SetPosition(new Vector3(vec3Int.x, vec3Int.y * World.MapBlockHeight, vec3Int.z));
				base.Map.StabilityManager.BeamPlaced(this);
			}
		}

		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			base.Map.StabilityManager.BeamConstructed(this, afterLoading);
			base.OnBaseBuildingEnterFinishedState(afterLoading);
			base.Map.BeamComponentManager.BeamConstructed(this);
		}

		public void Setup(BaseBuildingInstance startBuilding, BaseBuildingInstance endBuilding, ObjectSide startSide, ObjectSide endSide)
		{
			this.startBuilding = startBuilding;
			this.endBuilding = endBuilding;
			base.Map.SocketComponentManager.GetSocketComponentInstance(this.startBuilding.GridDataPosition)?.AttachToSocket(base.OwnerBuilding, startSide);
			base.Map.SocketComponentManager.GetSocketComponentInstance(this.endBuilding.GridDataPosition)?.AttachToSocket(base.OwnerBuilding, endSide);
			SetupCommon(this.startBuilding.GridDataPosition, this.endBuilding.GridDataPosition, startSide, endSide);
		}

		public void Setup(BaseBuildingInstance startBuilding, Vec3Int endVoxelPos, ObjectSide startSide, ObjectSide endSide)
		{
			this.startBuilding = startBuilding;
			base.Map.SocketComponentManager.GetSocketComponentInstance(this.startBuilding.GridDataPosition)?.AttachToSocket(base.OwnerBuilding, startSide);
			MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(base.OwnerBuilding, endSide, endVoxelPos);
			SetupCommon(this.startBuilding.GridDataPosition, endVoxelPos, startSide, endSide);
		}

		public void Setup(Vec3Int startVoxelPos, BaseBuildingInstance endBuilding, ObjectSide startSide, ObjectSide endSide)
		{
			MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(base.OwnerBuilding, startSide, startVoxelPos);
			this.endBuilding = endBuilding;
			base.Map.SocketComponentManager.GetSocketComponentInstance(this.endBuilding.GridDataPosition)?.AttachToSocket(base.OwnerBuilding, endSide);
			SetupCommon(startVoxelPos, this.endBuilding.GridDataPosition, startSide, endSide);
		}

		public void Setup(Vec3Int startVoxelPos, Vec3Int endVoxelPos, ObjectSide startSide, ObjectSide endSide)
		{
			MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(base.OwnerBuilding, startSide, startVoxelPos);
			MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(base.OwnerBuilding, endSide, endVoxelPos);
			SetupCommon(startVoxelPos, endVoxelPos, startSide, endSide);
		}

		private void SetupCommon(Vec3Int startPos, Vec3Int endPos, ObjectSide startSide, ObjectSide endSide)
		{
			startSocketGridPosition = startPos;
			endSocketGridPosition = endPos;
			this.startSide = startSide;
			this.endSide = endSide;
			base.OwnerBuilding.GetReachablePointsEvent += GetReachablePoints;
			base.OwnerBuilding.RequestHasStabilityToBuildEvent += OnRequestHasStabilityToBuild;
			base.OwnerBuilding.MainBuildingStabilityChangedEvent += OnMainBuildingStabilityChanged;
			if (base.Positions.Count == 1)
			{
				Vec3Int vec3Int = base.Positions[0];
				SetPosition(new Vector3(vec3Int.x, vec3Int.y * World.MapBlockHeight, vec3Int.z));
				base.Map.StabilityManager.BeamPlaced(this);
				return;
			}
			CalculateStartEndWorldObjectOffset(ref startPos, ref endPos);
			reachablePoints.Add(startPos);
			reachablePoints.Add(endPos);
			base.OwnerBuilding.HasStabilityToBuild = HasStabilityToBuild();
			if (startPos.x != endPos.x)
			{
				SetPosition(new Vector3(startPos.x, startPos.y * World.MapBlockHeight, startPos.z));
				base.Map.StabilityManager.BeamPlaced(this);
			}
			else
			{
				SetPosition(new Vector3(endPos.x, endPos.y * World.MapBlockHeight, endPos.z));
				base.Map.StabilityManager.BeamPlaced(this);
			}
		}

		private List<Vec3Int> GetReachablePoints()
		{
			return reachablePoints;
		}

		public void SetupOffsetAndScale(Vector3 rightOffset, Vector3 leftOffset, Vector3 scale)
		{
			this.rightOffset = rightOffset;
			this.leftOffset = leftOffset;
			this.scale = scale;
			base.OwnerBuilding.SetObjectSize(new Vec3Int((int)this.scale.x, 1, (int)this.scale.z));
		}

		private void SetPosition(Vector3 position)
		{
			base.OwnerBuilding.SetupWorldObject(position);
		}

		private void CalculateStartEndWorldObjectOffset(ref Vec3Int startPos, ref Vec3Int endPos)
		{
			if (startPos.x != endPos.x)
			{
				startPos.x++;
				endPos.x--;
			}
			else
			{
				startPos.z++;
				endPos.z--;
			}
		}

		public void BuildingToVoxelConversionRefresh(BaseBuildingInstance buildingToConvert)
		{
			if (startBuilding == buildingToConvert)
			{
				startBuilding = null;
			}
			if (endBuilding == buildingToConvert)
			{
				endBuilding = null;
			}
		}

		public void BeamCarriedStabilityChanged(int stability)
		{
			if (base.OwnerBuilding.ConstructionPhase != ConstructionPhase.Finished && (startBuilding != null || endBuilding != null))
			{
				base.OwnerBuilding.HasStabilityToBuild = HasStabilityToBuild();
				base.OwnerBuilding.UpdateBuildingReachability();
			}
			base.Map.StabilityManager.BeamStabilityChanged(this);
		}

		private void OnMapLoaded(bool fromSave)
		{
			if (!base.HasDisposed && base.OwnerBuilding != null && !base.OwnerBuilding.HasDisposed)
			{
				startBuilding = base.Map.BuildingsManagerMain.GetBuilding(startSocketGridPosition, (BaseBuildingInstance x) => x.BuildingType == BuildingType.Wall);
				if (startBuilding == null)
				{
					MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(base.OwnerBuilding, startSide, startSocketGridPosition);
				}
				else
				{
					base.Map.SocketComponentManager.GetSocketComponentInstance(startBuilding.GridDataPosition)?.AttachToSocket(base.OwnerBuilding, startSide, afterLoading: true);
				}
				endBuilding = base.Map.BuildingsManagerMain.GetBuilding(endSocketGridPosition, (BaseBuildingInstance x) => x.BuildingType == BuildingType.Wall);
				if (endBuilding == null)
				{
					MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(base.OwnerBuilding, endSide, endSocketGridPosition);
				}
				else
				{
					base.Map.SocketComponentManager.GetSocketComponentInstance(endBuilding.GridDataPosition)?.AttachToSocket(base.OwnerBuilding, endSide, afterLoading: true);
				}
				if (MonoSingleton<World>.IsInstantiated())
				{
					MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
				}
			}
		}

		private void OnMapLoadedMigration(bool fromSave)
		{
			if (base.OwnerBuilding == null)
			{
				FixOwnerBuildingMigration();
			}
			SetupAfterMigration();
			MonoSingleton<MigrationManager>.Instance.BeamsToSetup.Remove(base.OwnerBuilding);
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoadedMigration;
			}
		}

		private void OnRequestHasStabilityToBuild()
		{
			base.OwnerBuilding.SetHasStabilityToBuild(HasStabilityToBuild());
		}

		private void OnMainBuildingStabilityChanged()
		{
			if (!base.HasDisposed)
			{
				base.Map.StabilityManager.BeamStabilityChanged(this);
			}
		}

		public bool HasStabilityToBuild()
		{
			bool num = ((startBuilding == null) ? MonoSingleton<GroundManager>.Instance.GroundExists(startSocketGridPosition) : (!startBuilding.HasDisposed && startBuilding.ConstructionPhase.Equals(ConstructionPhase.Finished)));
			bool flag = ((endBuilding == null) ? MonoSingleton<GroundManager>.Instance.GroundExists(endSocketGridPosition) : (!endBuilding.HasDisposed && endBuilding.ConstructionPhase.Equals(ConstructionPhase.Finished)));
			return num && flag;
		}

		private void SetupAfterMigration()
		{
			if (startBuilding == null)
			{
				startBuilding = base.Map.BuildingsManagerMain.GetBuilding(startSocketGridPosition, (BaseBuildingInstance x) => x.BuildingType == BuildingType.Wall);
			}
			if (startBuilding != null)
			{
				base.Map.SocketComponentManager.GetSocketComponentInstance(startBuilding.GridDataPosition)?.AttachToSocket(base.OwnerBuilding, startSide);
			}
			else
			{
				MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(base.OwnerBuilding, startSide, startSocketGridPosition);
			}
			if (endBuilding == null)
			{
				endBuilding = base.Map.BuildingsManagerMain.GetBuilding(endSocketGridPosition, (BaseBuildingInstance x) => x.BuildingType == BuildingType.Wall);
			}
			if (endBuilding != null)
			{
				base.Map.SocketComponentManager.GetSocketComponentInstance(endBuilding.GridDataPosition)?.AttachToSocket(base.OwnerBuilding, endSide);
			}
			else
			{
				MonoSingleton<GroundManager>.Instance.AttachToVoxelSocket(base.OwnerBuilding, endSide, endSocketGridPosition);
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("startSocketGridPosition", startSocketGridPosition);
			serializer.Write("endSocketGridPosition", endSocketGridPosition);
			serializer.WriteEnum("startSide", startSide);
			serializer.WriteEnum("endSide", endSide);
			serializer.Write("rightOffset", rightOffset);
			serializer.Write("leftOffset", leftOffset);
			serializer.Write("scale", scale);
		}

		public BeamComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<BeamComponentRepository, BeamComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Beams\\BeamComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in BeamComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				startSocketGridPosition = deserializer.ReadVec3Int("startSocketGridPosition");
				endSocketGridPosition = deserializer.ReadVec3Int("endSocketGridPosition");
				startSide = deserializer.ReadEnum("startSide", (ObjectSide)0);
				endSide = deserializer.ReadEnum("endSide", (ObjectSide)0);
				rightOffset = deserializer.ReadVector3("rightOffset");
				leftOffset = deserializer.ReadVector3("leftOffset");
				scale = deserializer.ReadVector3("scale");
			}
		}
	}
}
