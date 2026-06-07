using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class TweenInput<T> : ITweenInput
	{
		private readonly float m_StartTime;

		private readonly T m_ValueSource;

		private readonly T m_ValueTarget;

		private readonly Easing.Type m_Easing;

		private readonly Action<T, T, float> m_Update;

		private readonly TimeMode m_TimeMode;

		public int Hash { get; }

		public float Duration { get; }

		public bool IsFinished { get; private set; }

		public bool IsComplete { get; private set; }

		public bool IsCanceled { get; private set; }

		public event Action<bool> EventFinish;

		public TweenInput(T source, T target, float duration, Action<T, T, float> update, int hash, Easing.Type easing = Easing.Type.QuadInOut, TimeMode.UpdateMode updateMode = TimeMode.UpdateMode.GameTime)
		{
			m_ValueSource = source;
			m_ValueTarget = target;
			m_Easing = easing;
			m_Update = update;
			m_TimeMode = new TimeMode(updateMode);
			m_StartTime = m_TimeMode.Time;
			Duration = duration;
			Hash = hash;
		}

		public TweenInput(T source, T target, float duration, int hash, Easing.Type easing = Easing.Type.QuadInOut, TimeMode.UpdateMode updateMode = TimeMode.UpdateMode.GameTime)
			: this(source, target, duration, (Action<T, T, float>)null, hash, easing, updateMode)
		{
		}

		public bool OnUpdate()
		{
			float num = m_TimeMode.Time - m_StartTime;
			float num2 = ((Duration > float.Epsilon) ? Mathf.Clamp01(num / Duration) : 1f);
			m_Update?.Invoke(m_ValueSource, m_ValueTarget, Easing.GetEase(m_Easing, 0f, 1f, num2));
			return num2 >= 1f;
		}

		public void OnComplete()
		{
			IsFinished = true;
			IsComplete = true;
			this.EventFinish?.Invoke(obj: true);
		}

		public void OnCancel()
		{
			IsFinished = true;
			IsCanceled = true;
			this.EventFinish?.Invoke(obj: false);
		}
	}
}
