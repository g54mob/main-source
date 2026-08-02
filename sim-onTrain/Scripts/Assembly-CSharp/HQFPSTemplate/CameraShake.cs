using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class CameraShake
	{
		private CameraShakeSettings m_Settings;

		private Spring m_PositionSpring;

		private Spring m_RotationSpring;

		private float m_Speed;

		private float m_Scale;

		private float xSign;

		private float ySign;

		private float zSign;

		private float m_EndTime;

		public bool IsDone => Time.time > m_EndTime;

		public CameraShake(CameraShakeSettings settings, Spring positionSpring, Spring rotationSpring, float scale)
		{
			m_Settings = settings;
			m_PositionSpring = positionSpring;
			m_RotationSpring = rotationSpring;
			m_Speed = m_Settings.Speed;
			m_Scale = scale;
			xSign = ((UnityEngine.Random.Range(0, 100) > 50) ? 1f : (-1f));
			ySign = ((UnityEngine.Random.Range(0, 100) > 50) ? 1f : (-1f));
			zSign = ((UnityEngine.Random.Range(0, 100) > 50) ? 1f : (-1f));
			m_EndTime = Time.time + settings.Duration;
		}

		public void Update()
		{
			if (!IsDone)
			{
				UpdateShake(m_PositionSpring, m_Settings.PositionAmplitude);
				UpdateShake(m_RotationSpring, m_Settings.RotationAmplitude);
			}
		}

		private void UpdateShake(Spring spring, Vector3 amplitude)
		{
			float f = (m_EndTime - Time.time) * m_Speed;
			Vector3 vector = new Vector3(xSign * Mathf.Sin(f) * amplitude.x * m_Scale, ySign * Mathf.Cos(f) * amplitude.y * m_Scale, zSign * Mathf.Sin(f) * amplitude.z * m_Scale);
			spring.AddForce(vector * m_Settings.Decay.Evaluate(1f - (m_EndTime - Time.time) / m_Settings.Duration));
		}
	}
}
