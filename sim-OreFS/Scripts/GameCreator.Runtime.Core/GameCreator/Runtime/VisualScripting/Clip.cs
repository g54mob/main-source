using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	public abstract class Clip : IClip, ISerializationCallbackReceiver
	{
		protected const float DEFAULT_PAD = 0.1f;

		protected const float DEFAULT_TIME = 0.3f;

		protected const float DEFAULT_DURATION = 0.3f;

		[SerializeField]
		private float m_Time;

		[SerializeField]
		private float m_Duration;

		[NonSerialized]
		private bool m_IsStart;

		[NonSerialized]
		private bool m_IsComplete;

		public float TimeStart => m_Time;

		public float TimeEnd => TimeStart + Duration;

		public float Duration => m_Duration;

		public float DurationToStart => m_Time;

		public float DurationToEnd => 1f - TimeEnd;

		public bool IsStart => m_IsStart;

		public bool IsComplete => m_IsComplete;

		protected virtual float MinDuration => 0f;

		protected Clip()
		{
			m_Time = 0.3f;
			m_Duration = 0.3f;
		}

		protected Clip(float time)
			: this()
		{
			m_Time = time;
		}

		protected Clip(float time, float duration)
			: this(time)
		{
			m_Duration = duration;
		}

		void IClip.Reset(ITrack track, Args args)
		{
			m_IsStart = false;
			m_IsComplete = false;
			OnReset(track, args);
		}

		void IClip.Start(ITrack track, Args args)
		{
			m_IsStart = true;
			OnStart(track, args);
		}

		void IClip.Complete(ITrack track, Args args)
		{
			m_IsComplete = true;
			OnComplete(track, args);
		}

		void IClip.Cancel(ITrack track, Args args)
		{
			m_IsComplete = true;
			OnCancel(track, args);
		}

		void IClip.Update(ITrack track, Args args, float t)
		{
			OnUpdate(track, args, t);
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (!AssemblyUtils.IsReloading)
			{
				ValidateTimes();
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (!AssemblyUtils.IsReloading)
			{
				ValidateTimes();
			}
		}

		private void ValidateTimes()
		{
			m_Time = Mathf.Clamp01(m_Time);
			m_Duration = Mathf.Clamp(m_Duration, MinDuration, Mathf.Max(MinDuration, 1f - m_Time));
		}

		protected virtual void OnReset(ITrack track, Args args)
		{
		}

		protected virtual void OnStart(ITrack track, Args args)
		{
		}

		protected virtual void OnComplete(ITrack track, Args args)
		{
		}

		protected virtual void OnCancel(ITrack track, Args args)
		{
		}

		protected virtual void OnUpdate(ITrack track, Args args, float t)
		{
		}
	}
}
