using System;
using NGS.MeshFusionPro;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Terrain;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(BaseBuildingViewComponent))]
	public class MerlonViewComponent : BasicBuildingBlockViewComponent
	{
		[SerializeField]
		private MeshFusionSource merlonSupport;

		protected override void OnBaseBuildingEnterFoundationState()
		{
			base.OnBaseBuildingEnterFoundationState();
			RefreshMerlonSupportVisibility();
		}

		protected override void OnObjectPlacedOnMap(bool afterLoading = false)
		{
			base.OnObjectPlacedOnMap(afterLoading);
			base.BaseBuildingInstance.StabilityUpdatedRefreshVisualsEvent += RefreshMerlonSupportVisibility;
			base.BaseBuildingInstance.BuildingMeshVariationRotatedEvent += RefreshMerlonSupportVisibility;
			if (afterLoading)
			{
				RefreshMerlonSupportVisibility();
			}
		}

		protected override void OnBaseBuildingEnterFinishedState()
		{
			RefreshMerlonSupportVisibility();
			base.OnBaseBuildingEnterFinishedState();
		}

		private void RefreshMerlonSupportVisibility()
		{
			if (!(merlonSupport != null))
			{
				return;
			}
			VillageMap map = base.BaseBuildingInstance.Map;
			Vec3Int a = base.BaseBuildingInstance.GridDataPosition + Vec3Int.down;
			Vec3Int vec3Int = a + GetDirectionToCheck();
			if (map.BuildingsManagerMain.BuildingTypesExist(a, BuildingType.Wall) || MonoSingleton<GroundManager>.Instance.GroundExists(a) || (!map.BuildingsManagerMain.BuildingTypesExist(vec3Int, BuildingType.Wall) && !MonoSingleton<GroundManager>.Instance.GroundExists(vec3Int)))
			{
				if (LoadingController.IsLoadingComplete)
				{
					merlonSupport.UndoCombine();
				}
				merlonSupport.gameObject.SetActive(value: false);
			}
			else
			{
				if (LoadingController.IsLoadingComplete)
				{
					merlonSupport.AssignToController();
				}
				merlonSupport.gameObject.SetActive(value: true);
			}
		}

		private Vec3Int GetDirectionToCheck()
		{
			float num = MathF.PI / 180f * base.BaseBuildingInstance.GetAngle();
			float num2 = MathF.PI / 180f * base.BaseBuildingInstance.RotateMeshVariation;
			float f = 0f - num + num2;
			return new Vec3Int(Mathf.RoundToInt(Mathf.Cos(f)), 0, Mathf.RoundToInt(Mathf.Sin(f)));
		}
	}
}
