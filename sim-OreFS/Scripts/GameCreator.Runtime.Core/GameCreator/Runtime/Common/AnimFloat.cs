using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class AnimFloat
	{
		public struct Transient
		{
			[NonSerialized]
			private readonly float m_StartTime;

			[NonSerialized]
			private readonly float m_Value;

			[NonSerialized]
			private readonly float m_SmoothIn;

			[NonSerialized]
			private readonly float m_SmoothOut;

			[NonSerialized]
			private readonly float m_Duration;

			public bool IsActive
			{
				get
				{
					float num = m_SmoothIn + m_Duration + m_SmoothOut;
					return Time.time - m_StartTime < num;
				}
			}

			public Transient(float value, float smoothIn, float duration, float smoothOut)
			{
				m_StartTime = Time.time;
				m_Value = value;
				m_SmoothIn = smoothIn;
				m_Duration = duration;
				m_SmoothOut = smoothOut;
			}

			public float Update(float current, float target)
			{
				if (Time.time <= m_StartTime + m_SmoothIn)
				{
					float t = (Time.time - m_StartTime) / m_SmoothIn;
					return Mathf.LerpUnclamped(current, m_Value, Easing.BackOut(0f, 1f, t));
				}
				if (Time.time <= m_StartTime + m_SmoothIn + m_Duration)
				{
					return m_Value;
				}
				float num = m_StartTime + m_SmoothIn + m_Duration;
				float t2 = (Time.time - num) / m_SmoothOut;
				return Mathf.LerpUnclamped(m_Value, target, Easing.QuadOut(0f, 1f, t2));
			}
		}

		private const float SMOOTH_FACTOR = 0.5f;

		private const float SMOOTH = 0.1f;

		[NonSerialized]
		private Transient m_Transient;

		[NonSerialized]
		private float m_Velocity;

		[field: NonSerialized]
		public float Current { get; set; }

		[field: NonSerialized]
		public float Target { get; set; }

		[field: NonSerialized]
		public float Smooth { get; set; }

		public AnimFloat(float value, float smooth = 0.1f)
		{
			Current = value;
			Target = value;
			Smooth = smooth;
		}

		public AnimFloat(float value, float target, float smooth)
			: this(value, smooth)
		{
			Target = target;
		}

		public void UpdateWithDelta(float deltaTime)
		{
			if (m_Transient.IsActive)
			{
				m_Velocity = 0f;
				Current = m_Transient.Update(Current, Target);
			}
			else
			{
				Current = Mathf.SmoothDamp(Current, Target, ref m_Velocity, Smooth * 0.5f, float.PositiveInfinity, deltaTime);
			}
		}

		public void UpdateWithDelta(float target, float deltaTime)
		{
			Target = target;
			UpdateWithDelta(deltaTime);
		}

		public void UpdateWithDelta(float target, float smooth, float deltaTime)
		{
			Smooth = smooth;
			UpdateWithDelta(target, deltaTime);
		}

		public void UpdateWithDelta(bool target, float deltaTime)
		{
			UpdateWithDelta(target ? 1f : 0f, deltaTime);
		}

		public void UpdateWithDelta(bool target, float smooth, float deltaTime)
		{
			UpdateWithDelta(target ? 1f : 0f, smooth, deltaTime);
		}

		public void Update()
		{
			UpdateWithDelta(Time.deltaTime);
		}

		public void Update(float target)
		{
			Target = target;
			Update();
		}

		public void Update(bool target)
		{
			Update(target ? 1f : 0f);
		}

		public void Update(float target, float smooth)
		{
			Smooth = smooth;
			Update(target);
		}

		public void Update(bool target, float smooth)
		{
			Smooth = smooth;
			Update(target);
		}

		public void SetTransient(Transient transient)
		{
			m_Transient = transient;
		}
	}
}
