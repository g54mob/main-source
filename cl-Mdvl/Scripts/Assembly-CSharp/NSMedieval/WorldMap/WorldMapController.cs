using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	public class WorldMapController : MonoSingleton<WorldMapController>
	{
		public delegate void WorldPlaceHandler(Vector2Int villagePlace);

		public delegate void BoolHandler(bool isEnabled);

		private bool isHoveringOverUI;

		public bool IsHoveringOverUI => isHoveringOverUI;

		public event WorldPlaceHandler PlaceSelectedEvent;

		public event BoolHandler WorldMapVisibilitySetEvent;

		public event Action WorldMapGeneratedFromHomeSceneEvent;

		public event Action WorldMapLoadedFromMainSceneEvent;

		public event Action FinalizeWorldMapSettingsEvent;

		public event Action<string, int> MapTypeDropdownChangedEvent;

		public event Action<WorldMapPlace> PlaceClickedEvent;

		public event Action PlaceDeselectClickedEvent;

		public event Action<CaravanInstance> CaravanClickedEvent;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.PlaceSelectedEvent = null;
			this.WorldMapVisibilitySetEvent = null;
			this.WorldMapGeneratedFromHomeSceneEvent = null;
			this.WorldMapLoadedFromMainSceneEvent = null;
			this.FinalizeWorldMapSettingsEvent = null;
			this.MapTypeDropdownChangedEvent = null;
			this.PlaceClickedEvent = null;
			this.PlaceDeselectClickedEvent = null;
			this.CaravanClickedEvent = null;
		}

		public void PlaceSelected(Vector2Int placePosition)
		{
			this.PlaceSelectedEvent?.Invoke(placePosition);
		}

		public void WorldMapVisibilitySet(bool isWorldMapVisible)
		{
			this.WorldMapVisibilitySetEvent?.Invoke(isWorldMapVisible);
		}

		public void WorldMapGeneratedFromHomeScene()
		{
			this.WorldMapGeneratedFromHomeSceneEvent?.Invoke();
		}

		public void WorldMapLoadedFromMainScene()
		{
			this.WorldMapLoadedFromMainSceneEvent?.Invoke();
		}

		public void FinalizeWorldMapSettings()
		{
			this.FinalizeWorldMapSettingsEvent?.Invoke();
		}

		public void MapTypeDropdownChanged(string mapType, int indexInDropdownList)
		{
			this.MapTypeDropdownChangedEvent?.Invoke(mapType, indexInDropdownList);
		}

		public void PlaceClicked(WorldMapPlace place)
		{
			this.PlaceClickedEvent?.Invoke(place);
		}

		public void PlaceDeselectClicked()
		{
			this.PlaceDeselectClickedEvent?.Invoke();
		}

		public void SetHoveringOverUI(bool isHoveringOverUI)
		{
			this.isHoveringOverUI = isHoveringOverUI;
		}

		public void CaravanClicked(CaravanInstance caravanInstance)
		{
			this.CaravanClickedEvent?.Invoke(caravanInstance);
		}
	}
}
