using Pinwheel.Jupiter;
using UnityEngine;
using UnityEngine.Rendering;

namespace WorldEnvironment.DayCycle
{
	[ExecuteAlways]
	[RequireComponent(typeof(JDayNightCycle))]
	public class VolumetricCloudsDimmerCycle : MonoBehaviour
	{
		[SerializeField]
		private Volume _globalVolume;

		[SerializeField]
		private JDayNightCycle _cycle;

		[SerializeField]
		private AnimationCurve _dimmer;

		public void Update()
		{
			if (_cycle != null && _globalVolume.profile.TryGet<VolumetricClouds>(out var component))
			{
				VolumeParameter<float> volumeParameter = new VolumeParameter<float>();
				volumeParameter.value = _dimmer.Evaluate(_cycle.Time / 24f);
				component.ambientLightProbeDimmer.SetValue(volumeParameter);
			}
		}
	}
}
