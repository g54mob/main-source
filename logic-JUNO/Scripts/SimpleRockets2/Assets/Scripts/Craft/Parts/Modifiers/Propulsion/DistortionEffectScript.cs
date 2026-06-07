using ModApi.Settings;
using ModApi.Settings.Core;
using ModApi.Settings.Core.Events;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class DistortionEffectScript : MonoBehaviour
	{
		private bool _active;

		private Material _material;

		[SerializeField]
		private float _maxDistortion = 250f;

		[SerializeField]
		private float _minDistortion = 100f;

		private ParticleSystem _ps;

		private bool _qualityEnabled;

		private bool _requested;

		public void Activate()
		{
			_requested = true;
			UpdateActiveState();
		}

		public void Deactivate()
		{
			_requested = false;
			UpdateActiveState();
		}

		public void FlightUpdate(float intensity)
		{
			if (_active)
			{
				float value = Mathf.Lerp(_minDistortion, _maxDistortion, intensity);
				_material.SetFloat("_Distortion", value);
			}
		}

		public void Initialize()
		{
			_ps = GetComponent<ParticleSystem>();
			ParticleSystem.EmissionModule emission = _ps.emission;
			emission.enabled = false;
			_ps.gameObject.SetActive(value: false);
			_ps.gameObject.layer = 0;
			ParticleSystemRenderer component = _ps.GetComponent<ParticleSystemRenderer>();
			_material = component.material;
			EnumSetting<VisualEffectsQualitySettings.HeatDistortionQuality> heatDistortion = Game.Instance.QualitySettings.VisualEffects.HeatDistortion;
			heatDistortion.Changed += OnHeatDistortionQualityChanged;
			UpdateFromQuality(heatDistortion.Value);
		}

		private void OnDestroy()
		{
			Game.Instance.QualitySettings.VisualEffects.HeatDistortion.Changed -= OnHeatDistortionQualityChanged;
		}

		private void OnHeatDistortionQualityChanged(object sender, SettingChangedEventArgs<VisualEffectsQualitySettings.HeatDistortionQuality> e)
		{
			UpdateFromQuality(e.Setting.Value);
			UpdateActiveState();
		}

		private void UpdateActiveState()
		{
			bool flag = _requested && _qualityEnabled;
			if (_active != flag)
			{
				_active = flag;
				if (flag)
				{
					_ps.gameObject.SetActive(value: true);
					ParticleSystem.EmissionModule emission = _ps.emission;
					emission.enabled = true;
				}
				else
				{
					_ps.gameObject.SetActive(value: false);
					ParticleSystem.EmissionModule emission2 = _ps.emission;
					emission2.enabled = true;
				}
			}
		}

		private void UpdateFromQuality(VisualEffectsQualitySettings.HeatDistortionQuality value)
		{
			_qualityEnabled = value == VisualEffectsQualitySettings.HeatDistortionQuality.On;
		}
	}
}
