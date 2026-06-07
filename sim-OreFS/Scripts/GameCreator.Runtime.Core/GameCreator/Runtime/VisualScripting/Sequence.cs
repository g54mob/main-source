using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	public abstract class Sequence : ISequence, ICancellable
	{
		[SerializeReference]
		private Track[] m_Tracks = Array.Empty<Track>();

		[NonSerialized]
		private float m_StartTime;

		[NonSerialized]
		private bool m_IsRunning;

		[NonSerialized]
		private bool m_IsCancelled;

		public TimeMode.UpdateMode UpdateMode => TimeMode.UpdateTime;

		public float T => Mathf.Clamp01(Time / Duration);

		public float Time => TimeMode.Time - m_StartTime;

		public bool IsRunning => m_IsRunning;

		public bool IsCancelled
		{
			get
			{
				if (!AsyncManager.ExitRequest && !m_IsCancelled)
				{
					return CancellationToken?.IsCancelled ?? false;
				}
				return true;
			}
		}

		protected virtual ICancellable CancellationToken => null;

		public abstract float Duration { get; }

		public float Speed { get; protected set; }

		public abstract TimeMode TimeMode { get; }

		public event Action EventStart;

		public event Action EventBeforeUpdate;

		public event Action EventAfterUpdate;

		public event Action EventComplete;

		public event Action EventCancel;

		protected Sequence()
		{
			m_StartTime = 0f;
			Speed = 1f;
		}

		protected Sequence(Track[] tracks)
			: this()
		{
			m_Tracks = tracks;
		}

		float ISequence.Dilate(float t)
		{
			return GetDilated(t);
		}

		public T GetTrack<T>() where T : ITrack
		{
			Track[] tracks = m_Tracks;
			foreach (Track track in tracks)
			{
				if (track is T)
				{
					return (T)(object)((track is T) ? track : null);
				}
			}
			return default(T);
		}

		protected async Task DoRun(Args args)
		{
			if (!Application.isPlaying || IsRunning)
			{
				return;
			}
			OnStart(args);
			while (IsRunning)
			{
				if (IsCancelled)
				{
					OnCancel(args);
					break;
				}
				if (OnRun(args))
				{
					break;
				}
				await Task.Yield();
			}
		}

		protected void DoCancel(Args args)
		{
			if (IsRunning)
			{
				OnCancel(args);
			}
		}

		protected virtual float GetDilated(float t)
		{
			return t;
		}

		private bool OnRun(Args args)
		{
			OnUpdate(args);
			if (IsRunning && Time >= Duration)
			{
				OnComplete(args);
			}
			return !IsRunning;
		}

		private void OnStart(Args args)
		{
			m_StartTime = TimeMode.Time;
			m_IsRunning = true;
			m_IsCancelled = false;
			Track[] tracks = m_Tracks;
			for (int i = 0; i < tracks.Length; i++)
			{
				((ITrack)tracks[i])?.OnStart((ISequence)this, args);
			}
			this.EventStart?.Invoke();
		}

		private void OnUpdate(Args args)
		{
			this.EventBeforeUpdate?.Invoke();
			Track[] tracks = m_Tracks;
			for (int i = 0; i < tracks.Length; i++)
			{
				((ITrack)tracks[i])?.OnUpdate((ISequence)this, args);
			}
			this.EventAfterUpdate?.Invoke();
		}

		private void OnComplete(Args args)
		{
			m_IsRunning = false;
			Track[] tracks = m_Tracks;
			for (int i = 0; i < tracks.Length; i++)
			{
				((ITrack)tracks[i])?.OnComplete((ISequence)this, args);
			}
			this.EventComplete?.Invoke();
		}

		private void OnCancel(Args args)
		{
			m_IsCancelled = true;
			m_IsRunning = false;
			Track[] tracks = m_Tracks;
			for (int i = 0; i < tracks.Length; i++)
			{
				((ITrack)tracks[i])?.OnCancel((ISequence)this, args);
			}
			this.EventCancel?.Invoke();
		}
	}
}
