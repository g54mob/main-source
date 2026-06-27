using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace DistantLands.Cozy.Data
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/FX/Post Processing FX", order = 361)]
	public class VisualFX : FXProfile
	{
		public int layer;

		public float priority = 100f;

		public VolumeProfile effectSettings;

		private Volume _volume;

		public override void PlayEffect(float i)
		{
			if ((bool)_volume || InitializeEffect(weatherSphere))
			{
				_volume.weight = Mathf.Clamp01(transitionTimeModifier.Evaluate(i));
			}
		}

		public override bool InitializeEffect(CozyWeather weather)
		{
			if (!Application.isPlaying)
			{
				return false;
			}
			base.InitializeEffect(weather);
			if ((bool)_volume)
			{
				return true;
			}
			if (_volume == null)
			{
				if ((bool)weather.GetFXRuntimeRef<Volume>(base.name))
				{
					_volume = weather.GetFXRuntimeRef<Volume>(base.name);
				}
				if ((bool)_volume)
				{
					return true;
				}
				_volume = new GameObject().AddComponent<Volume>();
				_volume.gameObject.name = base.name;
				_volume.transform.parent = weather.visualFXParent;
				_volume.transform.position = Vector3.zero;
				_volume.transform.rotation = Quaternion.identity;
				_volume.profile = effectSettings;
				_volume.priority = priority;
				_volume.weight = 0f;
				_volume.isGlobal = true;
				_volume.gameObject.layer = layer;
				return true;
			}
			return false;
		}
	}
}
