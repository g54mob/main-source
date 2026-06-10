using System;
using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[RequireComponent(typeof(PenMarkerComponent))]
	public class PenMarkerViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private PenMarkerComponent penMarkerComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			penMarkerComponent = GetComponent<PenMarkerComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			base.OnComponentEnterFinishedState(afterLoading);
			BaseBuildingViewComponent.BuildingSelectedEvent += OnBuildingSelected;
			BaseBuildingViewComponent.BuildingDeselectedEvent += OnBuildingDeselected;
		}

		private void OnBuildingSelected()
		{
			MonoSingleton<PenViewManager>.Instance.OnSelected(BaseBuildingViewComponent);
		}

		private void OnBuildingDeselected()
		{
			MonoSingleton<PenViewManager>.Instance.OnDeSelected(BaseBuildingViewComponent);
		}
	}
}
