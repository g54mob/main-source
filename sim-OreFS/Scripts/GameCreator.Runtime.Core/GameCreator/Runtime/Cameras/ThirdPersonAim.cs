using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	public class ThirdPersonAim
	{
		private const float EPSILON = 0.001f;

		[NonSerialized]
		private readonly ShotTypeThirdPerson m_System;

		[NonSerialized]
		private float m_TransitionTime;

		[NonSerialized]
		private float m_TransitionDuration;

		[NonSerialized]
		private float m_StartShoulder;

		[NonSerialized]
		private float m_StartLift;

		[NonSerialized]
		private float m_StartRadius;

		[NonSerialized]
		private Quaternion m_Aim;

		[NonSerialized]
		private float m_TargetShoulder;

		[NonSerialized]
		private float m_TargetLift;

		[NonSerialized]
		private float m_TargetRadius;

		[field: NonSerialized]
		private float T { get; set; }

		[field: NonSerialized]
		public float Shoulder { get; private set; }

		[field: NonSerialized]
		public float Lift { get; private set; }

		[field: NonSerialized]
		public float Radius { get; private set; }

		[field: NonSerialized]
		public Quaternion Aim { get; private set; }

		public ThirdPersonAim(ShotTypeThirdPerson system)
		{
			m_System = system;
		}

		public void Switch(float shoulder, float lift, float radius, Quaternion aim, float duration)
		{
			m_StartShoulder = Shoulder;
			m_StartLift = Lift;
			m_StartRadius = Radius;
			m_TargetShoulder = shoulder;
			m_TargetLift = lift;
			m_TargetRadius = radius;
			m_Aim = aim;
			Aim = aim;
			m_TransitionTime = m_System.ShotCamera.TimeMode.Time;
			m_TransitionDuration = duration;
		}

		public void Update(float shoulder, float lift, float radius)
		{
			float time = m_System.ShotCamera.TimeMode.Time;
			float t = ((m_TransitionDuration > 0.001f) ? ((time - m_TransitionTime) / m_TransitionDuration) : 1f);
			T = Easing.QuadOut(0f, 1f, t);
			Shoulder = Mathf.Lerp(m_StartShoulder, m_TargetShoulder, T) + shoulder;
			Lift = Mathf.Lerp(m_StartLift, m_TargetLift, T) + lift;
			Radius = Mathf.Lerp(m_StartRadius, m_TargetRadius, T) + radius;
			Aim = Quaternion.Euler(Mathf.Lerp(QuaternionUtils.Convert180(m_Aim.eulerAngles.x), 0f, T), Mathf.Lerp(QuaternionUtils.Convert180(m_Aim.eulerAngles.y), 0f, T), 0f);
		}
	}
}
