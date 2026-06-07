using Presentation.Buildings;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class BuildingsHighlightOutline : HighlightOutline
	{
		[SerializeField]
		private MonoBehaviour _buildingView;

		private BuildingViewEvents buildingViewEvents;

		protected override void Initialize()
		{
			base.Initialize();
			buildingViewEvents = _buildingView as BuildingViewEvents;
			buildingViewEvents.OnBuildingPreviewInit += OnBuildingPreviewInit;
			buildingViewEvents.OnBuildingInit += OnBuildingInit;
		}

		private void OnBuildingInit()
		{
			AutofillRenderers();
			FillRendOriginalLayers();
		}

		private void OnBuildingPreviewInit()
		{
			OnBuildingInit();
			Show();
		}

		protected override void UnInitialize()
		{
			base.UnInitialize();
			buildingViewEvents.OnBuildingPreviewInit -= OnBuildingPreviewInit;
			buildingViewEvents.OnBuildingInit -= OnBuildingInit;
		}
	}
}
