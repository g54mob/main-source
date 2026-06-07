using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace DV.Simulation.Cars
{
	public class ExplosionLightAndPostProcessingController : MonoBehaviour
	{
		private enum LightState
		{
			DELAY = 0,
			FADE_IN = 1,
			FADE_OUT = 2
		}

		public Light explosionLight;

		public PostProcessVolume explosionPostProcessing;

		public Gradient lightFadeInColorGradient;

		public Gradient lightFadeOutColorGradient;

		public float lightDelay;

		public float lightFadeInLength = 1f;

		public float lightFadeOutLength = 1f;

		public float lightIntensityMax = 25f;

		private float elapsedTime;

		private bool postProcessingEnabled;

		private LightState state;

		private void OnEnable()
		{
			OnPreferenceChanged();
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				GamePreferences.RegisterToPreferenceUpdated(Preferences.PostProcessing, OnPreferenceChanged);
			}
			else
			{
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.PostProcessing, OnPreferenceChanged);
			}
		}

		private void OnPreferenceChanged()
		{
			postProcessingEnabled = GamePreferences.Get<bool>(Preferences.PostProcessing);
		}

		private void Update()
		{
			switch (state)
			{
			case LightState.DELAY:
				if (elapsedTime >= lightDelay)
				{
					state = LightState.FADE_IN;
					elapsedTime = 0f;
					explosionLight.enabled = true;
					if (explosionPostProcessing != null && postProcessingEnabled)
					{
						explosionPostProcessing.enabled = true;
					}
				}
				break;
			case LightState.FADE_IN:
			{
				if (elapsedTime >= lightFadeInLength)
				{
					state = LightState.FADE_OUT;
					elapsedTime = 0f;
					break;
				}
				float num2 = Mathf.Clamp01(elapsedTime / lightFadeInLength);
				explosionLight.intensity = InterpolateCubicInOut(0f, lightIntensityMax, num2);
				explosionLight.color = lightFadeInColorGradient.Evaluate(num2);
				if (explosionPostProcessing != null && explosionPostProcessing.enabled)
				{
					explosionPostProcessing.weight = InterpolateCubicInOut(0f, 1f, num2);
				}
				break;
			}
			case LightState.FADE_OUT:
			{
				if (elapsedTime >= lightFadeOutLength)
				{
					explosionLight.enabled = false;
					if (explosionPostProcessing != null)
					{
						explosionPostProcessing.enabled = false;
					}
					base.enabled = false;
					break;
				}
				float num = Mathf.Clamp01(elapsedTime / lightFadeOutLength);
				explosionLight.intensity = InterpolateCubicInOut(lightIntensityMax, 0f, num);
				explosionLight.color = lightFadeOutColorGradient.Evaluate(num);
				if (explosionPostProcessing != null && explosionPostProcessing.enabled)
				{
					explosionPostProcessing.weight = InterpolateCubicInOut(1f, 0f, num);
				}
				break;
			}
			default:
				Debug.LogError(string.Format("Unexpected state: Unhandled {0}: {1}", "LightState", state));
				break;
			}
			elapsedTime += Time.deltaTime;
		}

		private float InterpolateCubicInOut(float from, float to, float t)
		{
			if (t >= 1f)
			{
				return to;
			}
			if (t <= 0f)
			{
				return from;
			}
			float num = to - from;
			float num2 = t - 1f;
			return from + num * ((t < 0.5f) ? (4f * t * t * t) : (4f * num2 * num2 * num2 + 1f));
		}
	}
}
