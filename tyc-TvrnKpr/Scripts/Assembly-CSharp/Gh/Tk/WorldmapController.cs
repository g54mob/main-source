using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class WorldmapController : SingletonMonoBehaviour<WorldmapController>
	{
		public AnimationCurve deliveryEffortByTime;

		public GameObject mapMarkerGlowPrefab;

		public List<WorldMapRegion3DUIView> defaultUnlockedRegions;

		[SerializeField]
		private GameObject _lighting;

		[SerializeField]
		private GameObject _enviroment;

		[SerializeField]
		private GameObject _markersParent;

		public List<MapVisual> MapVisuals { get; private set; }

		public List<MapMarker> MapMarkers { get; private set; }

		public List<WorldMapRegion3DUIView> Regions { get; private set; }

		public TavernMapMarker CurrentTavern => null;

		public string MapMode { get; private set; }

		public bool IsMapVisible { get; private set; }

		public bool IsOpening { get; private set; }

		public bool IsClosing { get; private set; }

		public static event EventHandler BeforeWorldMapToggled
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler AfterWorldMapToggled
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public IEnumerable<T> GetMapMarkers<T>()
		{
			return null;
		}

		public TavernMapMarker GetTavernMapMarker(string levelId)
		{
			return null;
		}

		public override void Awake()
		{
		}

		private void OnPlayerProfileChanged(object sender, EventArgs<PlayerProfile> eventArgs)
		{
		}

		public void RefreshRegionUnlockStates()
		{
		}

		public void Init()
		{
		}

		public void OnLevelChanged()
		{
		}

		private void CheckMapVisualVisibility()
		{
		}

		public void ToggleMap()
		{
		}

		public void ShowWorldMap(string mode, DirectorsToolbar3DUIView.CameraPresetData presetPosition, bool skipTransition = false, string levelId = null)
		{
		}

		public void ShowWorldMap(string mode, Vector3? focusOnPosition = null, bool skipTransition = false, string levelId = null)
		{
		}

		private void ShowWorldMapInternal(string mode, Action onPositionCamera = null, bool skipTransition = false)
		{
		}

		private void FocusOnMapPosition(Vector3? focusOnPosition)
		{
		}

		public void HideWorldMap(bool skipTransition = false)
		{
		}

		public void SetWorldMapVisuals(bool isEnabled)
		{
		}
	}
}
