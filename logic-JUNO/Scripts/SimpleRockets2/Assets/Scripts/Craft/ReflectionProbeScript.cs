using Assets.Scripts.Flight;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Settings;
using Assets.Scripts.Terrain.Rendering;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Planet;
using ModApi.Planet.Events;
using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft
{
	public class ReflectionProbeScript : MonoBehaviour
	{
		private Texture _defaultTexture;

		private IMapViewManager _mapViewManager;

		private IPlanet _planet;

		private ReflectionProbe _probe;

		private int _quadsphereCullingMask = 603979793;

		[SerializeField]
		private bool _realtimeReflections;

		private int _scaledSpaceCullingMask = 257;

		protected virtual void Awake()
		{
			_probe = GetComponent<ReflectionProbe>();
			_defaultTexture = _probe.customBakedTexture;
			EnumSetting<CraftQualitySettings.CraftReflectionsQuality> reflections = Game.Instance.QualitySettings.Crafts.Reflections;
			reflections.Changed += OnReflectionQualityChanged;
			_realtimeReflections = reflections.Value == CraftQualitySettings.CraftReflectionsQuality.Realtime;
			if (Game.InFlightScene)
			{
				_planet = Game.Instance.FlightScene?.ViewManager.GameView.Planet;
			}
			else if (Game.InPlanetStudioScene)
			{
				_planet = PlanetStudioScript.Instance.CelestialBodyDesignerScript.CelestialBodyViewer.PlanetScript;
			}
			if (_planet != null)
			{
				_planet.QuadSphereEnabledStateChanged += QuadSphereEnabledChanged;
			}
			Update(quadsphereVisible: true);
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.Crafts.Reflections.Changed -= OnReflectionQualityChanged;
			if (_mapViewManager != null)
			{
				_mapViewManager.ForegroundStateChanged -= OnMapViewForegroundStateChanged;
			}
			if (_planet != null)
			{
				_planet.QuadSphereEnabledStateChanged -= QuadSphereEnabledChanged;
			}
		}

		protected virtual void Start()
		{
			_mapViewManager = Game.Instance.FlightScene.ViewManager.MapViewManager;
			_mapViewManager.ForegroundStateChanged += OnMapViewForegroundStateChanged;
		}

		protected virtual void Update()
		{
			if (_realtimeReflections && Game.InFlightScene && !_mapViewManager.IsInForeground)
			{
				double altitudeAgl = FlightSceneScript.Instance.CraftNode.AltitudeAgl;
				IPlanetData planetData = Game.Instance.FlightScene.ViewManager.GameView.Planet.PlanetData;
				double num = planetData.Radius + planetData.AtmosphereData.Height;
				_probe.nearClipPlane = Mathf.Max(1f, 0.5f * (float)altitudeAgl - 1000f);
				_probe.farClipPlane = (float)(altitudeAgl + num);
			}
		}

		private void ApplyQualitySettings(CraftQualitySettings.CraftReflectionsQuality qualitySetting)
		{
			_realtimeReflections = qualitySetting == CraftQualitySettings.CraftReflectionsQuality.Realtime;
			if (_planet != null)
			{
				Update(_planet.QuadSphereEnabled);
			}
		}

		private void OnMapViewForegroundStateChanged(bool foreground)
		{
			_probe.enabled = !foreground;
		}

		private void OnReflectionQualityChanged(object sender, SettingChangedEventArgs<CraftQualitySettings.CraftReflectionsQuality> e)
		{
			ApplyQualitySettings(e.Setting.Value);
		}

		private void OnValidate()
		{
			if (_probe != null && Device.IsUnityEditor)
			{
				ApplicationSettings settings = Game.Instance.Settings;
				EnumSetting<CraftQualitySettings.CraftReflectionsQuality> reflections = settings.Quality.Crafts.Reflections;
				reflections.Category.SetPreset(SettingsCategoryPreset.Custom);
				reflections.Value = ((!_realtimeReflections) ? CraftQualitySettings.CraftReflectionsQuality.Static : CraftQualitySettings.CraftReflectionsQuality.Realtime);
				reflections.CommitChanges();
				settings.Save();
				((GameViewScript)Game.Instance.FlightScene.ViewManager.GameView).GetComponentInChildren<QuadSphereRenderer>(includeInactive: true).RefreshDataAndUpdateRenderer();
				Update(Game.Instance.FlightScene.ViewManager.GameView.Planet.QuadSphereEnabled);
			}
		}

		private void QuadSphereEnabledChanged(object sender, PlanetQuadSphereEventArgs e)
		{
			if (_realtimeReflections)
			{
				Update(e.Planet.QuadSphereEnabled);
			}
		}

		private void Update(bool quadsphereVisible)
		{
			if (_realtimeReflections)
			{
				_probe.mode = ReflectionProbeMode.Realtime;
				_probe.refreshMode = ReflectionProbeRefreshMode.EveryFrame;
				_probe.cullingMask = (quadsphereVisible ? _quadsphereCullingMask : _scaledSpaceCullingMask);
				Transform parent = (quadsphereVisible ? Game.Instance.FlightScene.ViewManager.GameView.GameCamera.FarCamera.transform.parent.parent : ScaledSpaceScript.Instance.Camera.transform);
				base.transform.SetParent(parent, worldPositionStays: false);
			}
			else
			{
				_probe.mode = ReflectionProbeMode.Custom;
				_probe.customBakedTexture = _defaultTexture;
				Transform parent2 = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.FarCamera.transform.parent.parent;
				base.transform.SetParent(parent2, worldPositionStays: false);
			}
		}
	}
}
