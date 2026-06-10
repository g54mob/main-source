using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(MapTableComponent))]
	public class MapTableViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private MapTableComponent caravanPostComponent;

		[SerializeField]
		private GameObject map;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			caravanPostComponent = GetComponent<MapTableComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			map.SetActive(value: true);
			BaseBuildingViewComponent.BuildingOcclusionCullingChangedEvent += OnOcclusionCullingChanged;
		}

		private void OnOcclusionCullingChanged(bool isCulled)
		{
			map.SetActive(!isCulled);
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			map.SetActive(value: false);
		}
	}
}
