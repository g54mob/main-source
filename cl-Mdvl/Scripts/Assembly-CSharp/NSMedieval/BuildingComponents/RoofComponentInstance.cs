using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Map;
using NSMedieval.Serialization;
using NSMedieval.Terrain;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	[FVSerializableKey("RoofComponentInstance", "")]
	public class RoofComponentInstance : BaseComponentInstance
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private int length;

		[SerializeField]
		private Vec3Int start;

		[SerializeField]
		private Vec3Int end;

		[SerializeField]
		private Vec3Int scale;

		[NonSerialized]
		private readonly RoofComponentBlueprint blueprint;

		[NonSerialized]
		private readonly List<Vec3Int> reachablePoints = new List<Vec3Int>();

		[NonSerialized]
		private List<Vec3Int> edgeLowPoints = new List<Vec3Int>();

		public RoofComponentBlueprint Blueprint => blueprint;

		public List<Vec3Int> EdgeLowPoints => edgeLowPoints;

		public RoofDirection RoofDirection { get; private set; }

		public int Length => length;

		public Vec3Int Scale => scale;

		public Vec3Int Start => start;

		public Vec3Int End => end;

		public RoofComponentInstance(BaseBuildingInstance ownerBuilding, RoofComponentBlueprint blueprint, Vec3Int scale)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			id = blueprint.GetID();
			this.blueprint = blueprint;
			this.scale = scale;
			length = scale.x;
		}

		public void SetStartEndPositions(Vec3Int start, Vec3Int end)
		{
			this.start = start;
			this.end = end;
			reachablePoints.Add(this.start);
			reachablePoints.Add(this.end);
			UpdateObjectSize();
			base.OwnerBuilding.CalculateReachabilityTemp();
			base.OwnerBuilding.GetReachablePointsEvent += GetReachablePoints;
			base.Map.BeamComponentManager.BeamDestroyedEvent += OnBeamDestroyed;
			base.OwnerBuilding.RequestHasStabilityToBuildEvent += OnRequestHasStabilityToBuild;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyedSingle;
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent += OnGroundDestroyed;
			if (base.Map.BeamComponentManager.BeamExists(this.start + Vec3Int.down, onlyFinished: false) || base.Map.BeamComponentManager.BeamExists(this.end + Vec3Int.down, onlyFinished: false))
			{
				base.OwnerBuilding.SetPlacedOnBeam();
			}
			CalculateDirection();
		}

		public void SetScale(Vec3Int scale)
		{
			this.scale = scale;
		}

		public void SetLength(int length)
		{
			this.length = length;
		}

		private List<Vec3Int> GetReachablePoints()
		{
			return reachablePoints;
		}

		private void UpdateObjectSize()
		{
			Vec3Int vec3Int = end.Max(start) + Vec3Int.one - end.Min(start);
			base.OwnerBuilding.SetObjectSize(new Vec3Int(vec3Int.x, 1, vec3Int.z));
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.BeamComponentManager.BeamDestroyedEvent -= OnBeamDestroyed;
				base.Map.RoofComponentManager.RemoveFromCache(this);
				if (MonoSingleton<GroundController>.IsInstantiated())
				{
					MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyedSingle;
					MonoSingleton<GroundController>.Instance.OnGroundDestroyedEvent -= OnGroundDestroyed;
				}
				if (MonoSingleton<ConstructionController>.IsInstantiated())
				{
					MonoSingleton<ConstructionController>.Instance.RoofDestroyed(this);
				}
				base.Dispose();
			}
		}

		public override void SetupAfterLoading(BaseBuildingInstance baseBuildingInstance)
		{
			base.SetupAfterLoading(baseBuildingInstance);
			SetupPositionsAfterLoading();
			UpdateObjectSize();
			base.OwnerBuilding.GetReachablePointsEvent += GetReachablePoints;
			base.Map.BeamComponentManager.BeamDestroyedEvent += OnBeamDestroyed;
			base.OwnerBuilding.RequestHasStabilityToBuildEvent += OnRequestHasStabilityToBuild;
			CalculateEdgeLowPoints();
			base.OwnerBuilding.SetHasStabilityToBuild(HasStabilityToBuild());
			CalculateDirection();
		}

		public void UpdateStabilityTest(Vec3Int position, int stability)
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "RoofStabilityUpdate", delegate
			{
				if (base.OwnerBuilding.ConstructionPhase != ConstructionPhase.Finished)
				{
					base.OwnerBuilding.HasStabilityToBuild = HasStabilityToBuild();
					UpdateBuildingReachability();
				}
				Vec3Int gridPos = start + Vec3Int.down;
				Vec3Int gridPos2 = end + Vec3Int.down;
				if (gridPos.Equals(position) || gridPos2.Equals(position))
				{
					if (base.OwnerBuilding.ConstructionPhase == ConstructionPhase.Finished)
					{
						base.OwnerBuilding.SetStability(Mathf.Min(base.Map.StabilityManager.GetFinishedStability(gridPos), base.Map.StabilityManager.GetFinishedStability(gridPos2)));
					}
					else
					{
						base.OwnerBuilding.SetStability(Mathf.Min(base.Map.StabilityManager.GetBlueprintStability(gridPos), base.Map.StabilityManager.GetBlueprintStability(gridPos2)));
					}
				}
			});
		}

		public void UpdateBuildingReachability()
		{
			base.OwnerBuilding.SetReachability(new ReachabilityInfo(new IntRange(-1, 0)));
			base.OwnerBuilding.CalculateReachabilityTemp();
		}

		public void CalculateEdgeLowPoints()
		{
			if (!(blueprint == null))
			{
				if (blueprint.HalfRoof)
				{
					CalculateHalfRoofEdges();
					base.Map.RoofComponentManager.CacheRoofEdgeLowPoints(this);
				}
				else
				{
					CalculateWholeRoofEdges();
					base.Map.RoofComponentManager.CacheRoofEdgeLowPoints(this);
				}
			}
		}

		public bool HasStabilityToBuild()
		{
			BuildingsManagerMain buildingsManagerMain = base.OwnerBuilding.Map.BuildingsManagerMain;
			BeamComponentManager beamComponentManager = base.OwnerBuilding.Map.BeamComponentManager;
			bool flag = MonoSingleton<GroundManager>.Instance.GroundExists(Start + Vec3Int.down);
			bool flag2 = MonoSingleton<GroundManager>.Instance.GroundExists(End + Vec3Int.down);
			bool flag3 = buildingsManagerMain.BuildingExists(Start + Vec3Int.down, BuildingType.Wall, onlyConstructed: true);
			bool flag4 = buildingsManagerMain.BuildingExists(End + Vec3Int.down, BuildingType.Wall, onlyConstructed: true);
			bool flag5 = buildingsManagerMain.BuildingExists(Start + Vec3Int.down, BuildingType.Window, onlyConstructed: true);
			bool flag6 = buildingsManagerMain.BuildingExists(End + Vec3Int.down, BuildingType.Window, onlyConstructed: true);
			bool flag7 = buildingsManagerMain.BuildingExists(Start + Vec3Int.down, BuildingType.Door, onlyConstructed: true);
			bool flag8 = buildingsManagerMain.BuildingExists(End + Vec3Int.down, BuildingType.Door, onlyConstructed: true);
			bool flag9 = buildingsManagerMain.BuildingExists(Start + Vec3Int.down, BuildingType.BarnDoor, onlyConstructed: true);
			bool flag10 = buildingsManagerMain.BuildingExists(End + Vec3Int.down, BuildingType.BarnDoor, onlyConstructed: true);
			bool flag11 = beamComponentManager.BeamExists(Start + Vec3Int.down, onlyFinished: true);
			bool flag12 = beamComponentManager.BeamExists(End + Vec3Int.down, onlyFinished: true);
			bool flag13 = buildingsManagerMain.BuildingExists(Start, BuildingType.Floor, onlyConstructed: true);
			bool flag14 = buildingsManagerMain.BuildingExists(End, BuildingType.Floor, onlyConstructed: true);
			if (flag || flag3 || flag11 || flag5 || flag7 || flag9 || flag13)
			{
				return flag2 || flag4 || flag12 || flag6 || flag8 || flag10 || flag14;
			}
			return false;
		}

		private void SetupPositionsAfterLoading()
		{
			using PooledList<Vec3Int> pooledList = ListPool<Vec3Int>.GetJanitor();
			if (Mathf.Approximately(base.Angle, 90f) || Mathf.Approximately(base.Angle, 270f))
			{
				if (Start.z > End.z)
				{
					for (int num = Start.z; num >= End.z; num--)
					{
						pooledList.Add(new Vec3Int(Start.x, Start.y, num));
					}
				}
				else
				{
					for (int i = Start.z; i <= End.z; i++)
					{
						pooledList.Add(new Vec3Int(Start.x, Start.y, i));
					}
				}
			}
			if (Mathf.Approximately(base.Angle, 0f) || Mathf.Approximately(base.Angle, 180f))
			{
				if (Start.x > End.x)
				{
					for (int num2 = Start.x; num2 >= End.x; num2--)
					{
						pooledList.Add(new Vec3Int(num2, Start.y, Start.z));
					}
				}
				else
				{
					for (int j = Start.x; j <= End.x; j++)
					{
						pooledList.Add(new Vec3Int(j, Start.y, Start.z));
					}
				}
			}
			if (pooledList.Count != base.Positions.Count || !pooledList.All(base.Positions.Contains))
			{
				base.Map.BuildingsManagerMain.RemoveBuggyRoof(this);
				base.Positions.Clear();
				base.Positions.AddRange(pooledList);
				base.Map.BuildingsManagerMain.ReCacheFixedRoof(this);
			}
			else
			{
				base.Positions.Clear();
				base.Positions.AddRange(pooledList);
			}
		}

		protected override void OnStabilityCarrierDestroyed(BaseBuildingInstance buildingInstance, bool replaced)
		{
			if (!replaced && buildingInstance.Blueprint.CanSupportRoof())
			{
				CheckRoofSupport(buildingInstance.GridDataPosition);
			}
		}

		private void CheckRoofSupport(Vec3Int gridPosition)
		{
			if (base.HasDisposed || base.OwnerBuilding == null || base.OwnerBuilding.HasDisposed)
			{
				return;
			}
			Vec3Int vec3Int = gridPosition + Vec3Int.up;
			if (start.Equals(vec3Int) || end.Equals(vec3Int) || start.Equals(gridPosition) || end.Equals(gridPosition))
			{
				Vec3Int vec3Int2 = start + Vec3Int.down;
				Vec3Int vec3Int3 = end + Vec3Int.down;
				bool onlyFinished = base.OwnerBuilding.ConstructionPhase != ConstructionPhase.Blueprint;
				bool flag = MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int2);
				bool flag2 = MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int3);
				if (!(base.Map.BuildingsManagerMain.RoofSupportExists(vec3Int2, onlyFinished) || flag) || !(base.Map.BuildingsManagerMain.RoofSupportExists(vec3Int3, onlyFinished) || flag2))
				{
					base.Map.BuildingsManagerMain.DestroyBuilding(base.OwnerBuilding);
				}
			}
		}

		private void CalculateDirection()
		{
			if (length > 1)
			{
				if (start.x == end.x)
				{
					RoofDirection = RoofDirection.NorthSouth;
				}
				else
				{
					RoofDirection = RoofDirection.WestEast;
				}
				return;
			}
			float angle = base.OwnerBuilding.Angle;
			if (angle == 0f || angle == 180f)
			{
				RoofDirection = RoofDirection.WestEast;
			}
			else
			{
				RoofDirection = RoofDirection.NorthSouth;
			}
		}

		private void CalculateWholeRoofEdges()
		{
			if (start == end)
			{
				float angle = base.Angle;
				if (angle <= 90f)
				{
					if (angle != 0f)
					{
						if (angle == 90f)
						{
							edgeLowPoints.Add(start + Vec3Int.back);
							edgeLowPoints.Add(start + Vec3Int.forward);
						}
					}
					else
					{
						edgeLowPoints.Add(start + Vec3Int.right);
						edgeLowPoints.Add(start + Vec3Int.left);
					}
				}
				else if (angle != 180f)
				{
					if (angle == 270f)
					{
						edgeLowPoints.Add(start + Vec3Int.back);
						edgeLowPoints.Add(start + Vec3Int.forward);
					}
				}
				else
				{
					edgeLowPoints.Add(start + Vec3Int.right);
					edgeLowPoints.Add(start + Vec3Int.left);
				}
			}
			else if (start.z == end.z)
			{
				if (start.x < end.x)
				{
					edgeLowPoints.Add(start + Vec3Int.left);
					edgeLowPoints.Add(end + Vec3Int.right);
				}
				else if (start.x > end.x)
				{
					edgeLowPoints.Add(start + Vec3Int.right);
					edgeLowPoints.Add(end + Vec3Int.left);
				}
			}
			else if (start.x == end.x)
			{
				if (start.z < end.z)
				{
					edgeLowPoints.Add(start + Vec3Int.back);
					edgeLowPoints.Add(end + Vec3Int.forward);
				}
				else if (start.z > end.z)
				{
					edgeLowPoints.Add(start + Vec3Int.forward);
					edgeLowPoints.Add(end + Vec3Int.back);
				}
			}
		}

		private void CalculateHalfRoofEdges()
		{
			if (start == end)
			{
				float angle = base.Angle;
				if (angle <= 90f)
				{
					if (angle != 0f)
					{
						if (angle == 90f)
						{
							edgeLowPoints.Add(start + Vec3Int.back);
						}
					}
					else
					{
						edgeLowPoints.Add(start + Vec3Int.right);
					}
				}
				else if (angle != 180f)
				{
					if (angle == 270f)
					{
						edgeLowPoints.Add(start + Vec3Int.forward);
					}
				}
				else
				{
					edgeLowPoints.Add(start + Vec3Int.left);
				}
				return;
			}
			Vec3Int a = ((start == base.GridPosition) ? end : start);
			if (start.z == end.z)
			{
				if (a.x < base.GridPosition.x)
				{
					a += Vec3Int.left;
					edgeLowPoints.Add(a);
					return;
				}
				if (a.x > base.GridPosition.x)
				{
					a += Vec3Int.right;
					edgeLowPoints.Add(a);
					return;
				}
			}
			if (start.x == end.x)
			{
				if (a.z < base.GridPosition.z)
				{
					a += Vec3Int.back;
					edgeLowPoints.Add(a);
				}
				else if (a.z > base.GridPosition.z)
				{
					a += Vec3Int.forward;
					edgeLowPoints.Add(a);
				}
			}
		}

		private void OnRequestHasStabilityToBuild()
		{
			base.OwnerBuilding.SetHasStabilityToBuild(HasStabilityToBuild());
		}

		private void OnBeamDestroyed(BeamComponentInstance beamComponentInstance)
		{
			if (LoadingController.IsLeavingMainScene || LoadingController.IsSceneTransition || beamComponentInstance == null || base.HasDisposed)
			{
				return;
			}
			foreach (Vec3Int position in beamComponentInstance.Positions)
			{
				CheckRoofSupport(position);
			}
		}

		private void OnGroundDestroyed(List<Vec3Int> positions)
		{
			foreach (Vec3Int position in positions)
			{
				CheckRoofSupport(position);
			}
		}

		private void OnGroundDestroyedSingle(Vec3Int position)
		{
			CheckRoofSupport(position);
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("length", length);
			serializer.Write("start", start);
			serializer.Write("end", end);
			serializer.Write("scale", scale);
		}

		public RoofComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<RoofComponentRepository, RoofComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Roofs\\RoofComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in RoofComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
				return;
			}
			length = deserializer.ReadInt("length");
			start = deserializer.ReadVec3Int("start");
			end = deserializer.ReadVec3Int("end");
			scale = deserializer.ReadVec3Int("scale");
			if (reachablePoints == null)
			{
				reachablePoints = new List<Vec3Int>();
			}
			reachablePoints.Add(start);
			reachablePoints.Add(end);
		}
	}
}
