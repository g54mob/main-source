using System;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	public class ShotFeatureRecoil
	{
		[NonSerialized]
		private readonly ShotCamera m_ShotCamera;

		[NonSerialized]
		private float m_StartTime;

		[NonSerialized]
		private float m_Duration;

		[NonSerialized]
		private bool m_HasRecoil;

		[NonSerialized]
		private Vector2 m_Recoil;

		public ShotFeatureRecoil(ShotCamera shotCamera)
		{
			m_ShotCamera = shotCamera;
		}

		public void Run(float duration, Vector2 recoil)
		{
			m_StartTime = m_ShotCamera.TimeMode.Time;
			m_Duration = duration;
			m_Recoil = recoil;
			m_HasRecoil = true;
		}

		public void Update(out float pitch, out float yaw)
		{
			pitch = 0f;
			yaw = 0f;
			bool hasRecoil = m_HasRecoil;
			m_HasRecoil = false;
			if (m_Duration <= 0f)
			{
				if (hasRecoil)
				{
					pitch = m_Recoil.y;
					yaw = m_Recoil.x;
				}
			}
			else if (!(m_ShotCamera.TimeMode.Time - m_StartTime > m_Duration))
			{
				pitch = m_Recoil.y * m_ShotCamera.TimeMode.DeltaTime;
				yaw = m_Recoil.x * m_ShotCamera.TimeMode.DeltaTime;
			}
		}
	}
}
