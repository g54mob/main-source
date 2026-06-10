using System;
using System.Collections.Generic;
using System.Linq;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	public class RoofMeshVariationManager : AutomaticMeshVariationManagerBase
	{
		private const string RoofDefaultVariation = "default";

		private const string RoofEdgeVariation = "end_01";

		private readonly Dictionary<NInfo, MeshVariationRules> roofRules = new Dictionary<NInfo, MeshVariationRules>();

		protected override BuildingType BuildingType => BuildingType.Roof;

		public RoofMeshVariationManager(VillageMap map)
			: base(map)
		{
		}

		protected override MeshVariationRules GetMeshVariationRules(BaseBuildingInstance building, NInfo neighboursInfo)
		{
			if (!roofRules.TryGetValue(neighboursInfo, out var value))
			{
				return default(MeshVariationRules);
			}
			return value;
		}

		public override void Dispose()
		{
			roofRules.Clear();
			base.Dispose();
		}

		protected override void InitializeRules()
		{
			InitializeRoofRules();
		}

		public void RefreshNeighbors(BaseBuildingInstance destroyedRoof)
		{
			using (PooledList<BaseBuildingInstance> pooledList = ListPool<BaseBuildingInstance>.GetJanitor())
			{
				pooledList.AddIfNotNull(GetNeighbouringRoof(destroyedRoof.GridDataPosition + Vec3Int.forward));
				pooledList.AddIfNotNull(GetNeighbouringRoof(destroyedRoof.GridDataPosition + Vec3Int.right));
				pooledList.AddIfNotNull(GetNeighbouringRoof(destroyedRoof.GridDataPosition + Vec3Int.back));
				pooledList.AddIfNotNull(GetNeighbouringRoof(destroyedRoof.GridDataPosition + Vec3Int.left));
				if (pooledList.Count != 0)
				{
					Run(pooledList);
				}
			}
			BaseBuildingInstance GetNeighbouringRoof(Vec3Int pos)
			{
				BaseBuildingInstance building = buildingsManagerMain.GetBuilding(pos, (BaseBuildingInstance x) => x.BuildingType == BuildingType);
				if (destroyedRoof == building)
				{
					return null;
				}
				return building;
			}
		}

		protected override NInfo GetBuildingNeighboursFlags(Vec3Int centerPos, BaseBuildingInstance baseBuildingInstance, BuildingsManagerMain buildingsManager)
		{
			return GetRoofNeighboursMapFlag(baseBuildingInstance);
		}

		protected override bool LoadAndRotateBuildingMeshVariation(BaseBuildingInstance targetBuilding, MeshVariationRules rules)
		{
			if (targetBuilding == null || targetBuilding.HasDisposed || !targetBuilding.AutomaticMeshVariationLoading)
			{
				return false;
			}
			RoofComponentInstance componentInstance = targetBuilding.GetComponentInstance<RoofComponentInstance>();
			if (componentInstance == null || componentInstance.HasDisposed)
			{
				return false;
			}
			bool shouldFlipRoof = rules.ShouldFlipRoof;
			string variationId = rules.VariationId;
			bool result = false;
			if (shouldFlipRoof)
			{
				if (componentInstance.RoofDirection == RoofDirection.WestEast)
				{
					if (!componentInstance.Blueprint.HalfRoof)
					{
						if (targetBuilding.RotateMeshVariation == 0f)
						{
							targetBuilding.AddToMeshRotation(180f);
							result = true;
						}
					}
					else if (!targetBuilding.FlipZMeshVariation)
					{
						targetBuilding.MeshVariationFlipZ();
						result = true;
					}
				}
				else if (componentInstance.RoofDirection == RoofDirection.NorthSouth)
				{
					if (!componentInstance.Blueprint.HalfRoof)
					{
						if (!targetBuilding.FlipZMeshVariation)
						{
							targetBuilding.MeshVariationFlipZ();
							result = true;
						}
					}
					else if (!targetBuilding.FlipZMeshVariation)
					{
						targetBuilding.MeshVariationFlipZ();
						result = true;
					}
				}
			}
			if (targetBuilding.CurrentMeshVariation != variationId)
			{
				result = true;
			}
			MeshVariation variation = targetBuilding.Blueprint.VariationLists[0].Variations.FirstOrDefault((MeshVariation x) => x.Name == variationId);
			targetBuilding.ApplyMeshVariation(variation);
			return result;
		}

		private void InitializeRoofRules()
		{
			roofRules.Add(NInfo.HalfRoof, new MeshVariationRules(0, "default", shouldFlipRoof: false));
			roofRules.Add(NInfo.WholeRoof, new MeshVariationRules(0, "default", shouldFlipRoof: false));
			roofRules.Add(NInfo.North | NInfo.ShouldFlip | NInfo.WholeRoof, new MeshVariationRules(0, "end_01", shouldFlipRoof: true));
			roofRules.Add(NInfo.North | NInfo.DontFlip | NInfo.WholeRoof, new MeshVariationRules(0, "end_01", shouldFlipRoof: false));
			roofRules.Add(NInfo.North | NInfo.ShouldFlip | NInfo.HalfRoof, new MeshVariationRules(180, "end_01", shouldFlipRoof: true));
			roofRules.Add(NInfo.North | NInfo.DontFlip | NInfo.HalfRoof, new MeshVariationRules(180, "end_01", shouldFlipRoof: false));
			roofRules.Add(NInfo.East | NInfo.ShouldFlip | NInfo.WholeRoof, new MeshVariationRules(90, "end_01", shouldFlipRoof: true));
			roofRules.Add(NInfo.East | NInfo.DontFlip | NInfo.WholeRoof, new MeshVariationRules(90, "end_01", shouldFlipRoof: false));
			roofRules.Add(NInfo.East | NInfo.ShouldFlip | NInfo.HalfRoof, new MeshVariationRules(270, "end_01", shouldFlipRoof: true));
			roofRules.Add(NInfo.East | NInfo.DontFlip | NInfo.HalfRoof, new MeshVariationRules(270, "end_01", shouldFlipRoof: false));
			roofRules.Add(NInfo.South | NInfo.ShouldFlip | NInfo.WholeRoof, new MeshVariationRules(180, "end_01", shouldFlipRoof: true));
			roofRules.Add(NInfo.South | NInfo.DontFlip | NInfo.WholeRoof, new MeshVariationRules(180, "end_01", shouldFlipRoof: false));
			roofRules.Add(NInfo.South | NInfo.ShouldFlip | NInfo.HalfRoof, new MeshVariationRules(0, "end_01", shouldFlipRoof: true));
			roofRules.Add(NInfo.South | NInfo.DontFlip | NInfo.HalfRoof, new MeshVariationRules(0, "end_01", shouldFlipRoof: false));
			roofRules.Add(NInfo.West | NInfo.ShouldFlip | NInfo.WholeRoof, new MeshVariationRules(270, "end_01", shouldFlipRoof: true));
			roofRules.Add(NInfo.West | NInfo.DontFlip | NInfo.WholeRoof, new MeshVariationRules(270, "end_01", shouldFlipRoof: false));
			roofRules.Add(NInfo.West | NInfo.ShouldFlip | NInfo.HalfRoof, new MeshVariationRules(90, "end_01", shouldFlipRoof: true));
			roofRules.Add(NInfo.West | NInfo.DontFlip | NInfo.HalfRoof, new MeshVariationRules(90, "end_01", shouldFlipRoof: false));
			roofRules.Add(NInfo.North | NInfo.South | NInfo.WholeRoof, new MeshVariationRules(0, "default", shouldFlipRoof: false));
			roofRules.Add(NInfo.West | NInfo.East | NInfo.WholeRoof, new MeshVariationRules(0, "default", shouldFlipRoof: false));
			roofRules.Add(NInfo.North | NInfo.South | NInfo.HalfRoof, new MeshVariationRules(0, "default", shouldFlipRoof: false));
			roofRules.Add(NInfo.West | NInfo.East | NInfo.HalfRoof, new MeshVariationRules(0, "default", shouldFlipRoof: false));
		}

		private static NInfo GetRoofNeighboursMapFlag(BaseBuildingInstance ownerBuilding)
		{
			NInfo nInfo = NInfo.None;
			if (ownerBuilding == null || ownerBuilding.HasDisposed)
			{
				return nInfo;
			}
			RoofComponentInstance roofComponentInstance = ownerBuilding.GetComponentInstance<RoofComponentInstance>();
			if (roofComponentInstance.RoofDirection == RoofDirection.None)
			{
				return nInfo;
			}
			nInfo |= GetRoofType();
			VillageMap map = ownerBuilding.Map;
			PooledDictionary<NInfo, RoofComponentInstance> neighboursMap = DictionaryPool<NInfo, RoofComponentInstance>.GetJanitor();
			try
			{
				if (roofComponentInstance.RoofDirection == RoofDirection.WestEast)
				{
					AddToDictionary(NInfo.North, ownerBuilding.GridDataPosition + Vec3Int.forward);
					AddToDictionary(NInfo.South, ownerBuilding.GridDataPosition + Vec3Int.back);
				}
				else
				{
					AddToDictionary(NInfo.West, ownerBuilding.GridDataPosition + Vec3Int.left);
					AddToDictionary(NInfo.East, ownerBuilding.GridDataPosition + Vec3Int.right);
				}
				if (neighboursMap.Count == 0)
				{
					return nInfo;
				}
				if (neighboursMap.Count == 2)
				{
					if (neighboursMap.ContainsKey(NInfo.East) && neighboursMap.ContainsKey(NInfo.West))
					{
						return nInfo | (NInfo.West | NInfo.East);
					}
					if (neighboursMap.ContainsKey(NInfo.North) && neighboursMap.ContainsKey(NInfo.South))
					{
						return nInfo | (NInfo.North | NInfo.South);
					}
				}
				if (roofComponentInstance.RoofDirection == RoofDirection.WestEast)
				{
					RoofComponentInstance componentInstance = map.RoofComponentManager.GetComponentInstance(ownerBuilding.GridDataPosition + Vec3Int.forward);
					if (componentInstance != null && AreRoofsAligned(roofComponentInstance, componentInstance))
					{
						nInfo |= NInfo.North;
						bool flag = (roofComponentInstance.Blueprint.HalfRoof ? (roofComponentInstance.Angle == 180f) : (roofComponentInstance.Angle == 0f));
						nInfo = (NInfo)((ulong)nInfo | (ulong)(flag ? 137438953472L : 274877906944L));
					}
					RoofComponentInstance componentInstance2 = map.RoofComponentManager.GetComponentInstance(ownerBuilding.GridDataPosition + Vec3Int.back);
					if (componentInstance2 != null && AreRoofsAligned(roofComponentInstance, componentInstance2))
					{
						nInfo |= NInfo.South;
						bool flag = (roofComponentInstance.Blueprint.HalfRoof ? (roofComponentInstance.Angle == 0f) : (roofComponentInstance.Angle == 180f));
						nInfo = (NInfo)((ulong)nInfo | (ulong)(flag ? 137438953472L : 274877906944L));
					}
				}
				else
				{
					RoofComponentInstance componentInstance3 = map.RoofComponentManager.GetComponentInstance(ownerBuilding.GridDataPosition + Vec3Int.left);
					if (componentInstance3 != null && AreRoofsAligned(roofComponentInstance, componentInstance3))
					{
						nInfo |= NInfo.West;
						bool flag = (roofComponentInstance.Blueprint.HalfRoof ? (roofComponentInstance.Angle == 90f) : (roofComponentInstance.Angle == 270f));
						nInfo = (NInfo)((ulong)nInfo | (ulong)(flag ? 137438953472L : 274877906944L));
					}
					RoofComponentInstance componentInstance4 = map.RoofComponentManager.GetComponentInstance(ownerBuilding.GridDataPosition + Vec3Int.right);
					if (componentInstance4 != null && AreRoofsAligned(roofComponentInstance, componentInstance4))
					{
						nInfo |= NInfo.East;
						bool flag = (roofComponentInstance.Blueprint.HalfRoof ? (roofComponentInstance.Angle == 270f) : (roofComponentInstance.Angle == 90f));
						nInfo = (NInfo)((ulong)nInfo | (ulong)(flag ? 137438953472L : 274877906944L));
					}
				}
				return nInfo;
			}
			finally
			{
				((IDisposable)neighboursMap/*cast due to .constrained prefix*/).Dispose();
			}
			void AddToDictionary(NInfo location, Vec3Int neighbourSearchPos)
			{
				RoofComponentInstance componentInstance5 = map.RoofComponentManager.GetComponentInstance(neighbourSearchPos);
				if (componentInstance5 != null && AreRoofsAligned(roofComponentInstance, componentInstance5))
				{
					neighboursMap.Add(location, componentInstance5);
				}
			}
			static bool AreRoofsAligned(RoofComponentInstance first, RoofComponentInstance second)
			{
				if (first.Blueprint.HalfRoof != second.Blueprint.HalfRoof)
				{
					return false;
				}
				if (first.Blueprint.HalfRoof && !Mathf.Approximately(first.Angle, second.Angle))
				{
					return false;
				}
				if (first.Length != second.Length)
				{
					return false;
				}
				if (first.RoofDirection != second.RoofDirection)
				{
					return false;
				}
				if (first.RoofDirection == RoofDirection.WestEast)
				{
					if (first.Start.x == second.Start.x)
					{
						return true;
					}
					if (first.Start.x == second.End.x)
					{
						return true;
					}
				}
				else if (first.RoofDirection == RoofDirection.NorthSouth)
				{
					if (first.Start.z == second.Start.z)
					{
						return true;
					}
					if (first.Start.z == second.End.z)
					{
						return true;
					}
				}
				return false;
			}
			NInfo GetRoofType()
			{
				if (!roofComponentInstance.Blueprint.HalfRoof)
				{
					return NInfo.WholeRoof;
				}
				return NInfo.HalfRoof;
			}
		}
	}
}
