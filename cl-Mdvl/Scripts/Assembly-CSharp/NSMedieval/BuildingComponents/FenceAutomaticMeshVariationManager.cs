using System.Collections.Generic;
using NSMedieval.Enums;
using NSMedieval.Village.Map;

namespace NSMedieval.BuildingComponents
{
	public class FenceAutomaticMeshVariationManager : AutomaticMeshVariationManagerBase
	{
		private const string FenceDefaultVariation = "default";

		private const string FenceCornerVariation = "corner";

		private const string FenceTJunctionVariation = "t_cross";

		private const string FenceCrossVariation = "cross";

		private const string FenceEdgeVariation = "edge";

		private readonly Dictionary<NInfo, MeshVariationRules> fenceRules = new Dictionary<NInfo, MeshVariationRules>();

		protected override BuildingType BuildingType => BuildingType.Fence;

		public FenceAutomaticMeshVariationManager(VillageMap map)
			: base(map)
		{
		}

		public override void Dispose()
		{
			fenceRules.Clear();
			base.Dispose();
		}

		protected override void InitializeRules()
		{
			InitializeFenceRules();
		}

		protected override NInfo GetBuildingNeighboursFlags(Vec3Int centerPos, BaseBuildingInstance baseBuildingInstance, BuildingsManagerMain buildingsManager)
		{
			NInfo result = NInfo.None;
			AddToFlag(NInfo.West, centerPos + Vec3Int.left);
			AddToFlag(NInfo.North, centerPos + Vec3Int.forward);
			AddToFlag(NInfo.East, centerPos + Vec3Int.right);
			AddToFlag(NInfo.South, centerPos + Vec3Int.back);
			AddGatesToFlag(NInfo.West, centerPos + Vec3Int.left);
			AddGatesToFlag(NInfo.North, centerPos + Vec3Int.forward);
			AddGatesToFlag(NInfo.East, centerPos + Vec3Int.right);
			AddGatesToFlag(NInfo.South, centerPos + Vec3Int.back);
			return result;
			void AddGatesToFlag(NInfo location, Vec3Int position)
			{
				if (buildingsManager.GetBuildingInstance(position, BuildingType.FenceGate) != null)
				{
					result |= location;
				}
			}
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
			if (fenceRules.TryGetValue(neighboursInfo, out var value))
			{
				return value;
			}
			return default(MeshVariationRules);
		}

		private void InitializeFenceRules()
		{
			fenceRules.Add(NInfo.None, new MeshVariationRules(0, "default"));
			fenceRules.Add(NInfo.North, new MeshVariationRules(0, "edge"));
			fenceRules.Add(NInfo.East, new MeshVariationRules(90, "edge"));
			fenceRules.Add(NInfo.South, new MeshVariationRules(180, "edge"));
			fenceRules.Add(NInfo.West, new MeshVariationRules(270, "edge"));
			fenceRules.Add(NInfo.North | NInfo.South, new MeshVariationRules(0, "default"));
			fenceRules.Add(NInfo.West | NInfo.East, new MeshVariationRules(90, "default"));
			fenceRules.Add(NInfo.North | NInfo.East, new MeshVariationRules(0, "corner"));
			fenceRules.Add(NInfo.South | NInfo.East, new MeshVariationRules(90, "corner"));
			fenceRules.Add(NInfo.South | NInfo.West, new MeshVariationRules(180, "corner"));
			fenceRules.Add(NInfo.North | NInfo.West, new MeshVariationRules(270, "corner"));
			fenceRules.Add(NInfo.North | NInfo.West | NInfo.East, new MeshVariationRules(0, "t_cross"));
			fenceRules.Add(NInfo.North | NInfo.South | NInfo.East, new MeshVariationRules(90, "t_cross"));
			fenceRules.Add(NInfo.South | NInfo.West | NInfo.East, new MeshVariationRules(180, "t_cross"));
			fenceRules.Add(NInfo.North | NInfo.South | NInfo.West, new MeshVariationRules(270, "t_cross"));
			fenceRules.Add(NInfo.North | NInfo.South | NInfo.West | NInfo.East, new MeshVariationRules(0, "cross"));
		}
	}
}
