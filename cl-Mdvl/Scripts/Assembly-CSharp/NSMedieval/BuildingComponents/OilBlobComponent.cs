using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Fire;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class OilBlobComponent : BaseComponent
	{
		protected override void OnBaseBuildingEnterFoundationState(bool afterLoading = false)
		{
			FireSimLogic fireSimLogic = VillageManager.ActiveVillage.Map.FireSimLogic;
			foreach (Vec3Int position in base.OwnerBuilding.Positions)
			{
				MapNode node = base.OwnerBuilding.Map.GetNode(position);
				if (node != null)
				{
					OilBlobComponentBlueprint byID = Repository<OilBlobComponentRepository, OilBlobComponentBlueprint>.Instance.GetByID(base.OwnerBuilding.Blueprint.OilBlobComponentID);
					if (byID != null)
					{
						fireSimLogic?.SetOilBlobHealth(node.Index, 1f, (byte)byID.OilBlobType);
					}
				}
			}
			base.OwnerBuilding.Storage.ClearAll(isSilent: true);
			MonoSingleton<ConstructionController>.Instance.BlobConstructionCompleted(base.OwnerBuilding);
			base.OwnerBuilding.Map.BuildingsManagerMain.DestroyVoxelBuilding(base.OwnerBuilding);
		}
	}
}
