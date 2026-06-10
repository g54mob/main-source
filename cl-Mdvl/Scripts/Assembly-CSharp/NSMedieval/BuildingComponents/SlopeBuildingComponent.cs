using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class SlopeBuildingComponent : BaseComponent
	{
		protected override void OnBaseBuildingEnterFinishedState(bool afterLoading = false)
		{
			MonoSingleton<SlopeManager>.Instance.ConvertStairsToSlope(base.OwnerBuilding);
			base.OwnerBuilding.Map.BuildingsManagerMain.DestroyVoxelBuilding(base.OwnerBuilding);
		}
	}
}
