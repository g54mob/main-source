using Pinwheel.Jupiter;
using UnityEngine;

namespace WorldEnvironment.DayCycle
{
	[ExecuteAlways]
	public class GlobalLightIntencityCycle : MonoBehaviour
	{
		[SerializeField]
		private JDayNightCycle _cycle;

		[SerializeField]
		private AnimationCurve _intensity;

		public void LateUpdate()
		{
			RenderSettings.ambientIntensity = _intensity.Evaluate(_cycle.Time / 24f);
		}
	}
}
