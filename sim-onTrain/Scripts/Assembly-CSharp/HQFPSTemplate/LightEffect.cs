using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[RequireComponent(typeof(Light))]
	public class LightEffect : MonoBehaviour
	{
		public enum PlayMode
		{
			Once = 0,
			Loop = 1
		}

		[Serializable]
		public class PulseSettings
		{
			public bool Enabled;

			public PlayMode Mode;

			[Space]
			[Range(0f, 3f)]
			public float Duration;

			public Color Color;

			[Space]
			[Range(0f, 3f)]
			public float IntensityAmplitude;

			[Range(0f, 3f)]
			public float RangeAmplitude;

			[Range(0f, 3f)]
			public float ColorWeight;
		}

		[Serializable]
		public class NoiseSettings
		{
			public bool Enabled;

			[Range(0f, 1f)]
			public float Intensity = 0.05f;

			[Range(0f, 10f)]
			public float Speed = 1f;
		}

		[SerializeField]
		private bool m_PlayOnAwake;

		[SerializeField]
		private float m_Intensity = 1f;

		[SerializeField]
		[Range(0f, 10f)]
		private float m_Range = 1f;

		[SerializeField]
		private Color m_Color = Color.yellow;

		[Space]
		[SerializeField]
		[Range(0f, 2f)]
		private float m_FadeInTime = 0.5f;

		[SerializeField]
		[Range(0f, 2f)]
		private float m_FadeOutTime = 0.5f;

		[Header("Effects")]
		[SerializeField]
		private PulseSettings m_Pulse;

		[SerializeField]
		private NoiseSettings m_Noise;

		private bool m_IsPlaying;

		private bool m_LightsEnabled;

		private float m_Weight;

		private bool m_FadingIn;

		private bool m_FadingOut;

		private Light[] m_Lights;

		private bool m_PulseActive;

		private float m_PulseTimer;

		public bool IsPlaying => m_IsPlaying;

		public float IntensityMultiplier { get; set; }

		public void Play(bool fadeIn)
		{
			if (!m_IsPlaying)
			{
				m_IsPlaying = true;
				m_PulseActive = true;
				m_FadingIn = fadeIn;
				m_Weight = (m_FadingIn ? 0f : 1f);
				m_PulseTimer = 0f;
			}
		}

		public void Stop(bool fadeOut)
		{
			m_IsPlaying = false;
			m_FadingOut = fadeOut;
			m_PulseActive = false;
			if (!m_FadingOut)
			{
				m_Weight = 0f;
			}
		}

		private void Awake()
		{
			m_Lights = GetComponentsInChildren<Light>(includeInactive: true);
			EnableLights(enable: false);
			IntensityMultiplier = 1f;
			if (m_PlayOnAwake)
			{
				Play(fadeIn: true);
			}
		}

		private void Update()
		{
			float num = m_Intensity;
			float num2 = m_Range;
			Color color = m_Color;
			if (m_IsPlaying)
			{
				if (m_Pulse.Enabled && m_PulseActive)
				{
					float num3 = m_PulseTimer / Mathf.Max(m_Pulse.Duration, 0.001f);
					float num4 = (Mathf.Sin(MathF.PI * (2f * num3 - 0.5f)) + 1f) * 0.5f;
					num += m_Intensity * num4 * m_Pulse.IntensityAmplitude;
					num2 += m_Range * num4 * m_Pulse.RangeAmplitude;
					color = Color.Lerp(color, m_Pulse.Color, num4 * m_Pulse.ColorWeight);
					m_PulseTimer += Time.deltaTime;
					if (m_PulseTimer > m_Pulse.Duration)
					{
						if (m_Pulse.Mode == PlayMode.Once)
						{
							m_PulseActive = false;
						}
						m_PulseTimer = 0f;
					}
				}
				if (!m_PulseActive)
				{
					m_IsPlaying = false;
					m_FadingOut = true;
				}
			}
			if (m_LightsEnabled && m_Noise.Enabled)
			{
				float num5 = Mathf.PerlinNoise(Time.time * m_Noise.Speed, 0f) * m_Noise.Intensity;
				num += m_Intensity * num5;
				num2 += m_Range * num5;
			}
			if (m_FadingIn)
			{
				m_Weight = Mathf.MoveTowards(m_Weight, 1f, Time.deltaTime * (1f / m_FadeInTime));
				if (m_Weight == 1f)
				{
					m_FadingIn = false;
				}
			}
			else if (m_FadingOut)
			{
				m_Weight = Mathf.MoveTowards(m_Weight, 0f, Time.deltaTime * (1f / m_FadeOutTime));
				if (m_Weight == 0f)
				{
					EnableLights(enable: false);
					SetLightsIntensity(0f);
					m_FadingOut = false;
				}
			}
			if (!m_LightsEnabled && m_IsPlaying)
			{
				EnableLights(enable: true);
			}
			if (m_LightsEnabled)
			{
				SetLightsParameters(num * IntensityMultiplier * m_Weight, num2, color);
			}
		}

		private void EnableLights(bool enable)
		{
			for (int i = 0; i < m_Lights.Length; i++)
			{
				m_Lights[i].enabled = enable;
			}
			m_LightsEnabled = enable;
		}

		private void SetLightsIntensity(float intensity)
		{
			for (int i = 0; i < m_Lights.Length; i++)
			{
				m_Lights[i].intensity = intensity;
			}
		}

		private void SetLightsParameters(float intensity, float range, Color color)
		{
			for (int i = 0; i < m_Lights.Length; i++)
			{
				m_Lights[i].intensity = intensity;
				m_Lights[i].range = range;
				m_Lights[i].color = color;
			}
		}
	}
}
