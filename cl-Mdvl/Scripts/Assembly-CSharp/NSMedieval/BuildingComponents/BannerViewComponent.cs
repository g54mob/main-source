using NSEipix.Base;
using NSMedieval.Heraldry;
using NSMedieval.Village;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(DecorationComponent))]
	public class BannerViewComponent : DecorationViewComponent
	{
		protected override void OnComponentEnterFoundationState()
		{
			base.OnComponentEnterFoundationState();
			if (BaseBuildingViewComponent.BaseBuildingInstance.FactionOwnership == FactionOwnership.Enemy)
			{
				MonoSingleton<HeraldryManager>.Instance.TrySetHeraldry(BaseBuildingViewComponent.FinishedMeshRenderers, GlobalSaveController.CurrentVillageData.WorldMapPlace.FactionInstance);
			}
			else
			{
				MonoSingleton<HeraldryManager>.Instance.TrySetPlayerHeraldry(BaseBuildingViewComponent.FinishedMeshRenderers);
			}
		}
	}
}
