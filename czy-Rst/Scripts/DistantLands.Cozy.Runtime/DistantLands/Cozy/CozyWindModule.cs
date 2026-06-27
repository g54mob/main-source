using System.Collections.Generic;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyWindModule : CozyModule
	{
		[CozySearchable(new string[] { })]
		public WindFX defaultWindProfile;

		[CozySearchable(new string[] { })]
		public WindZone windZone;

		public float windSpeed;

		public float windChangeSpeed;

		public float windAmount;

		public float windGusting;

		private Vector3 m_WindDirection;

		private float m_Seed;

		[Tooltip("Multiplies the total wind power by a coefficient.")]
		[Range(0f, 2f)]
		[CozySearchable(new string[] { })]
		public float windMultiplier = 1f;

		[CozySearchable(new string[] { })]
		public bool useWindzone = true;

		[CozySearchable(new string[] { })]
		public bool useShaderWind = true;

		private float m_WindTime;

		public List<WindFX> windFXes = new List<WindFX>();

		public Vector3 WindDirection
		{
			get
			{
				return m_WindDirection;
			}
			set
			{
				m_WindDirection = WindDirection;
			}
		}

		public float WindSpeedInKnots => windAmount * windSpeed * windMultiplier * 10f;

		private void Start()
		{
			base.weatherSphere.windModule = this;
			if (!defaultWindProfile)
			{
				defaultWindProfile = (WindFX)Resources.Load("Default Profiles/Default Wind");
			}
			m_WindTime = 0f;
			m_Seed = Random.value * 1000f;
		}

		public override void CozyUpdateLoop()
		{
			if (defaultWindProfile == null)
			{
				Debug.LogWarning("Default wind profile is required for the COZY Wind Module");
				return;
			}
			float f = 360f * Mathf.PerlinNoise(m_Seed, Time.time * windChangeSpeed / 100000f);
			m_WindDirection = new Vector3(Mathf.Sin(f), 0f, Mathf.Cos(f));
			if (useWindzone && (bool)windZone)
			{
				windZone.transform.LookAt(windZone.transform.position + m_WindDirection, Vector3.up);
				windZone.windMain = windAmount * windMultiplier;
				windZone.windPulseMagnitude = windGusting;
				windZone.windPulseFrequency = windSpeed;
			}
			m_WindTime += Time.deltaTime * windSpeed;
			if (useShaderWind)
			{
				Shader.SetGlobalFloat("CZY_WindTime", m_WindTime);
				Shader.SetGlobalVector("CZY_WindDirection", m_WindDirection * windAmount * windMultiplier);
			}
		}

		public override void FrameReset()
		{
			if ((bool)defaultWindProfile)
			{
				windSpeed = defaultWindProfile.windSpeed;
				windAmount = defaultWindProfile.windAmount;
				windGusting = defaultWindProfile.windGusting;
				windChangeSpeed = defaultWindProfile.windChangeSpeed;
			}
		}

		public override void DeinitializeModule()
		{
			base.DeinitializeModule();
			Shader.SetGlobalFloat("CZY_WindTime", 0f);
			Shader.SetGlobalVector("CZY_WindDirection", Vector3.zero);
		}
	}
}
