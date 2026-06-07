using ModApi.Planet;
using ModApi.Settings;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Effects
{
	public class LaunchPadLightScript : MonoBehaviour, IDynamicStructureMaterial
	{
		private float _baseAngle;

		private float _baseIntensity;

		private float _baseRange;

		private Light _launchLight;

		[SerializeField]
		private bool _nightOnly = true;

		private Light _sunLight;

		[SerializeField]
		private bool _supportsShadows = true;

		public void UpdateMaterial(float tiling, Color color)
		{
			_launchLight.color = color;
			_launchLight.range = _baseRange * base.transform.localScale.x;
			_launchLight.intensity = _baseIntensity * base.transform.localScale.y;
			_launchLight.spotAngle = _baseAngle * base.transform.localScale.z;
		}

		protected virtual void Awake()
		{
			_launchLight = GetComponent<Light>();
			_baseRange = _launchLight.range;
			_baseIntensity = _launchLight.intensity;
			_baseAngle = _launchLight.spotAngle;
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.QualitySettings.Shadows.Changed -= OnShadowSettingsChanged;
		}

		protected virtual void Start()
		{
			if (!Game.InFlightScene)
			{
				base.enabled = false;
				return;
			}
			if (_nightOnly)
			{
				_sunLight = Game.Instance.FlightScene.ViewManager.GameView.SunLight;
				_launchLight.enabled = false;
			}
			else
			{
				base.enabled = false;
			}
			if (_supportsShadows)
			{
				ShadowQualitySettings shadows = Game.Instance.QualitySettings.Shadows;
				shadows.Changed += OnShadowSettingsChanged;
				ApplyShadowQualitySettings(shadows);
			}
		}

		protected virtual void Update()
		{
			if (_launchLight.enabled == _sunLight.enabled)
			{
				_launchLight.enabled = !_sunLight.enabled;
			}
		}

		private void ApplyShadowQualitySettings(ShadowQualitySettings quality)
		{
			quality.ConfigureLight(_launchLight, ShadowQualitySettings.LightType.PrimaryLight);
		}

		private void OnShadowSettingsChanged(object sender, SettingsChangedEventArgs<ShadowQualitySettings> e)
		{
			ApplyShadowQualitySettings(e.Category);
		}
	}
}
