using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	public class WorldMapViewHomeScene : WorldMapView
	{
		private const string DefaultVillageType = "map_type_valley";

		private bool inputEnabled;

		[NonSerialized]
		private readonly List<WorldMapItemVillagePlace> selectableVillagePlaces = new List<WorldMapItemVillagePlace>();

		public List<WorldMapItemVillagePlace> SelectableVillagePlaces => selectableVillagePlaces;

		protected override bool InputEnabled => inputEnabled;

		public void OnShow()
		{
			MonoSingleton<WorldMap>.Instance.HeightmapContent.SetActive(value: true);
			MonoSingleton<WorldMap>.Instance.SetHomeSceneContentVisible(visible: true);
			OnStartSeasonChanged(MonoSingleton<GameStartController>.Instance.SelectedScenario.StartSeason);
		}

		public static void OnStartSeasonChanged(int season)
		{
			float value = ((float)season + 0.5f) / 4f;
			Shader.SetGlobalFloat("YearCycle", value);
			Shader.SetGlobalFloat("_YearCycle", value);
			Shader.SetGlobalFloat("_Snow_amount", (season == 3) ? 0.2f : 0f);
		}

		public void SetInputEnabled(bool inputEnabled)
		{
			this.inputEnabled = inputEnabled;
		}

		private void OnEnable()
		{
			StartCoroutine(ResizeWorldMapTexture());
		}

		protected new void Awake()
		{
			base.Awake();
			MonoSingleton<WorldMapController>.Instance.WorldMapGeneratedFromHomeSceneEvent += OnWorldMapGenerated;
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.MapTypeDropdownChangedEvent += OnMapTypeDropdownChanged;
			}
		}

		private void OnWorldMapGenerated()
		{
			PlacePossibleStartPositionMarkers();
			SelectDefaultStartingPosition();
		}

		private void OnDisable()
		{
			if (MonoSingleton<WorldMap>.IsInstantiated())
			{
				MonoSingleton<WorldMap>.Instance.SetHomeSceneContentVisible(visible: false);
				MonoSingleton<WorldMap>.Instance.HeightmapContent.SetActive(value: false);
			}
		}

		private void OnDestroy()
		{
			if (MonoSingleton<WorldMap>.IsInstantiated())
			{
				MonoSingleton<WorldMap>.Instance.DestroyGeneratedContent();
			}
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.WorldMapGeneratedFromHomeSceneEvent -= OnWorldMapGenerated;
			}
			if (MonoSingleton<WorldMapController>.IsInstantiated())
			{
				MonoSingleton<WorldMapController>.Instance.MapTypeDropdownChangedEvent -= OnMapTypeDropdownChanged;
			}
			WorldMapItemVillagePlace.SetSelected(null, silent: true);
		}

		private IEnumerator ResizeWorldMapTexture()
		{
			yield return new WaitForEndOfFrame();
			Rect rect = viewRect.rect;
			ResizeRenderTexture((int)rect.width, (int)rect.height);
		}

		public void ResizeRenderTexture(int width, int height)
		{
			if (WorldMapCamera.targetTexture.width != width || WorldMapCamera.targetTexture.height != height)
			{
				RenderTexture targetTexture = WorldMapCamera.targetTexture;
				targetTexture.Release();
				targetTexture.width = width;
				targetTexture.height = height;
				targetTexture.Create();
			}
			WorldMapCamera.aspect = (float)width / (float)height;
		}

		private void PlacePossibleStartPositionMarkers()
		{
			List<Vector2Int> possibleVillagePositions = MonoSingleton<WorldMap>.Instance.PossibleVillagePositions;
			selectableVillagePlaces.Clear();
			GameObject homeScenePossibleVillagePlaceMarker = MonoSingleton<WorldMap>.Instance.HomeScenePossibleVillagePlaceMarker;
			_ = Vector2Int.zero;
			foreach (Vector2Int item in possibleVillagePositions)
			{
				Vector2Int gridPosition = item;
				if (!homeScenePossibleVillagePlaceMarker.GetComponent<WorldMapItemVillagePlace>())
				{
					Log.Error("Cannot create possible village place: prefab has no WorldMapItemVillagePlace component.", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapViewHomeScene.cs");
					continue;
				}
				WorldMapItemVillagePlace component = UnityEngine.Object.Instantiate(homeScenePossibleVillagePlaceMarker, MonoSingleton<WorldMap>.Instance.HeightmapContent.transform, worldPositionStays: true).GetComponent<WorldMapItemVillagePlace>();
				component.SetGridPosition(gridPosition);
				component.name = $"Village_place_{selectableVillagePlaces.Count}_{MonoSingleton<WorldMap>.Instance.GetMapTypeName(in gridPosition)}";
				selectableVillagePlaces.Add(component);
			}
		}

		private void SelectDefaultStartingPosition()
		{
			string villageTypeToFind = MonoSingleton<GameStartController>.Instance.SelectedMapType;
			if (string.IsNullOrEmpty(villageTypeToFind))
			{
				villageTypeToFind = "map_type_valley";
			}
			WorldMapItemVillagePlace worldMapItemVillagePlace = selectableVillagePlaces.FirstOrDefault((WorldMapItemVillagePlace item) => item.GetMapTypeName().Equals(villageTypeToFind));
			if ((object)worldMapItemVillagePlace == null)
			{
				worldMapItemVillagePlace = selectableVillagePlaces.FirstOrDefault();
			}
			if ((object)worldMapItemVillagePlace != null)
			{
				MonoSingleton<WorldMap>.Instance.Data.VillagePosition = worldMapItemVillagePlace.GridPosition;
				worldMapItemVillagePlace.OnClick();
			}
		}

		private void OnMapTypeDropdownChanged(string mapType, int indexInDropdown)
		{
			if (this == null || selectableVillagePlaces == null)
			{
				return;
			}
			WorldMapItemVillagePlace worldMapItemVillagePlace = selectableVillagePlaces.FirstOrDefault((WorldMapItemVillagePlace item) => item.GetMapTypeName().Equals(mapType));
			foreach (WorldMapItemVillagePlace selectableVillagePlace in selectableVillagePlaces)
			{
				selectableVillagePlace.SetVillagePlace(selectableVillagePlace == worldMapItemVillagePlace);
				if (selectableVillagePlace == worldMapItemVillagePlace)
				{
					WorldMapItemVillagePlace.SetSelected(selectableVillagePlace, silent: false);
				}
			}
		}
	}
}
