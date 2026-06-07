using System;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class DistortionEffectScript : MonoBehaviour
	{
		private bool _active;

		private BoolSetting _heatDistortionQuality;

		private Material _material;

		[SerializeField]
		private float _maxDistortion = 250f;

		[SerializeField]
		private float _minDistortion = 100f;

		private PartScript _part;

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
			_ps.gameObject.layer = 18;
			_part = GetComponentInParent<PartScript>(includeInactive: true);
			if (_part != null)
			{
				_part.LayerAssignmentsCompleted += OnPartLayerAssignmentsComplete;
			}
			_heatDistortionQuality = Game.Instance.Settings.Quality.Craft.HeatDistortion;
			_heatDistortionQuality.Changed += OnHeatDistortionQualityChanged;
			_qualityEnabled = _heatDistortionQuality.Value;
		}

		protected virtual void OnDestroy()
		{
			_heatDistortionQuality.Changed -= OnHeatDistortionQualityChanged;
			if (_part != null)
			{
				_part.LayerAssignmentsCompleted -= OnPartLayerAssignmentsComplete;
			}
			if (_material != null)
			{
				UnityEngine.Object.Destroy(_material);
				_material = null;
			}
		}

		private void OnHeatDistortionQualityChanged(object sender, SettingChangedEventArgs<bool> e)
		{
			_qualityEnabled = e.Setting.Value;
			UpdateActiveState();
		}

		private void OnPartLayerAssignmentsComplete(object sender, EventArgs e)
		{
			_ps.gameObject.layer = 18;
		}

		private void UpdateActiveState()
		{
			bool flag = _requested && _qualityEnabled;
			if (_active == flag)
			{
				return;
			}
			_active = flag;
			if (flag)
			{
				if (_material == null)
				{
					ParticleSystemRenderer component = _ps.GetComponent<ParticleSystemRenderer>();
					_material = component.material;
				}
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
}
