using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public struct ShakeEffect
	{
		public const float COEF_SHAKE_POSITION = 1f;

		public const float COEF_SHAKE_ROTATION = 25f;

		private const int SEED_MIN = 0;

		private const int SEED_MAX = 999;

		[SerializeField]
		private bool m_ShakePosition;

		[SerializeField]
		private bool m_ShakeRotation;

		[SerializeField]
		private float m_Magnitude;

		[SerializeField]
		private float m_Roughness;

		[SerializeField]
		private Transform m_Transform;

		[SerializeField]
		private float m_Radius;

		private bool m_IsInitialized;

		private Vector3 m_Seed;

		private float m_Time;

		public Vector3 Value { get; private set; }

		public float PositionWeight
		{
			get
			{
				if (!m_ShakePosition)
				{
					return 0f;
				}
				return 1f;
			}
		}

		public float RotationWeight
		{
			get
			{
				if (!m_ShakeRotation)
				{
					return 0f;
				}
				return 1f;
			}
		}

		public static ShakeEffect Create => new ShakeEffect(1f, 1f);

		private ShakeEffect(float magnitude, float roughness)
		{
			m_Magnitude = magnitude;
			m_Roughness = roughness;
			m_ShakePosition = true;
			m_ShakeRotation = true;
			m_Transform = null;
			m_Radius = 10f;
			m_IsInitialized = false;
			m_Seed = Vector3.zero;
			m_Time = 0f;
			Value = Vector3.zero;
		}

		public void Update(TCamera camera)
		{
			if (!m_IsInitialized)
			{
				m_Seed = new Vector3(UnityEngine.Random.Range(0, 999), UnityEngine.Random.Range(0, 999), UnityEngine.Random.Range(0, 999));
				m_Time = 0f;
				m_IsInitialized = true;
			}
			m_Time += camera.Time.DeltaTime * m_Roughness;
			Vector3 perlinNoise = GetPerlinNoise(m_Time);
			float num = Vector3.Distance((m_Transform != null) ? m_Transform.position : camera.transform.position, camera.transform.position);
			float num2 = 1f - Mathf.Clamp01(num / m_Radius);
			Value = perlinNoise * (m_Magnitude * num2);
		}

		private Vector3 GetPerlinNoise(float time)
		{
			return new Vector3(PerlinNoiseUtils.Get(time, m_Seed.x), PerlinNoiseUtils.Get(time, m_Seed.y), PerlinNoiseUtils.Get(time, m_Seed.z));
		}
	}
}
