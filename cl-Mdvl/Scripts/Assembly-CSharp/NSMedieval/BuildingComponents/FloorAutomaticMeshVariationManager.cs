using System.Collections.Generic;
using NSMedieval.Enums;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class FloorAutomaticMeshVariationManager : AutomaticMeshVariationManagerBase
	{
		private const string FloorSingleVariation = "single";

		private const string FloorEndVariation = "end";

		private const string FloorCornerVariation = "corner";

		private const string FloorLineVariation = "line";

		private const string FloorEdgeVariation = "edge";

		private const string FloorDefaultVariation = "default";

		private readonly Dictionary<NInfo, MeshVariationRules> floorRules = new Dictionary<NInfo, MeshVariationRules>();

		protected override BuildingType BuildingType => BuildingType.Floor;

		public FloorAutomaticMeshVariationManager(VillageMap map)
			: base(map)
		{
		}

		public override void Dispose()
		{
			floorRules.Clear();
			base.Dispose();
		}

		protected override void InitializeRules()
		{
			InitializeFloorRules();
		}

		protected override NInfo GetBuildingNeighboursFlags(Vec3Int centerPos, BaseBuildingInstance baseBuildingInstance, BuildingsManagerMain buildingsManager)
		{
			NInfo result = NInfo.None;
			AddToFlag(NInfo.West, centerPos + Vec3Int.left);
			AddToFlag(NInfo.North, centerPos + Vec3Int.forward);
			AddToFlag(NInfo.East, centerPos + Vec3Int.right);
			AddToFlag(NInfo.South, centerPos + Vec3Int.back);
			return result;
			void AddToFlag(NInfo location, Vec3Int position)
			{
				if (buildingsManager.GetBuildingInstance(position, BuildingType) != null)
				{
					result |= location;
				}
			}
		}

		protected override MeshVariationRules GetMeshVariationRules(BaseBuildingInstance building, NInfo neighboursInfo)
		{
			if (floorRules.TryGetValue(neighboursInfo, out var value))
			{
				return value;
			}
			return default(MeshVariationRules);
		}

		private void InitializeFloorRules()
		{
			floorRules.Add(NInfo.None, new MeshVariationRules(0, "single"));
			floorRules.Add(NInfo.North, new MeshVariationRules(270, "end"));
			floorRules.Add(NInfo.East, new MeshVariationRules(0, "end"));
			floorRules.Add(NInfo.South, new MeshVariationRules(90, "end"));
			floorRules.Add(NInfo.West, new MeshVariationRules(180, "end"));
			floorRules.Add(NInfo.North | NInfo.South, new MeshVariationRules(90, "line"));
			floorRules.Add(NInfo.West | NInfo.East, new MeshVariationRules(0, "line"));
			floorRules.Add(NInfo.North | NInfo.East, new MeshVariationRules(270, "corner"));
			floorRules.Add(NInfo.South | NInfo.East, new MeshVariationRules(0, "corner"));
			floorRules.Add(NInfo.South | NInfo.West, new MeshVariationRules(90, "corner"));
			floorRules.Add(NInfo.North | NInfo.West, new MeshVariationRules(180, "corner"));
			floorRules.Add(NInfo.North | NInfo.West | NInfo.East, new MeshVariationRules(180, "edge"));
			floorRules.Add(NInfo.North | NInfo.South | NInfo.East, new MeshVariationRules(270, "edge"));
			floorRules.Add(NInfo.South | NInfo.West | NInfo.East, new MeshVariationRules(0, "edge"));
			floorRules.Add(NInfo.North | NInfo.South | NInfo.West, new MeshVariationRules(90, "edge"));
			floorRules.Add(NInfo.North | NInfo.South | NInfo.West | NInfo.East, new MeshVariationRules(0, "default"));
		}
	}
}
