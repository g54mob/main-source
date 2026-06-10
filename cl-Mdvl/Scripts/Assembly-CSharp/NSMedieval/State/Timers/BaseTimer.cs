using System;
using System.Runtime.CompilerServices;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.State.Timers
{
	[Serializable]
	[FVSerializableKey("BaseTimer", "")]
	public abstract class BaseTimer : IFVSerializable, IDisposable
	{
		[SerializeField]
		private float tickSpeed = 1f;

		[SerializeField]
		private float remainingTime;

		[SerializeField]
		private float cacheTotalTime;

		[SerializeField]
		private bool restartOnEnd;

		[SerializeField]
		protected bool paused;

		public bool Completed => remainingTime <= 0f;

		public Action Action => this.TimerJobCompleted;

		public bool Paused => paused;

		public float TickSpeed
		{
			get
			{
				return tickSpeed;
			}
			protected set
			{
				tickSpeed = value;
			}
		}

		public float RemainingTime => remainingTime;

		public float TotalTime => cacheTotalTime;

		public bool RestartOnEnd => restartOnEnd;

		public event Action<float> TimerTick;

		private event Action TimerJobCompleted;

		protected BaseTimer(float interval)
		{
			remainingTime = interval;
			cacheTotalTime = interval;
		}

		public virtual void Dispose()
		{
			StopAndDetachCallbacks();
		}

		public void SetTickSpeed(float tickSpeed)
		{
			this.tickSpeed = tickSpeed;
		}

		public void SetTotalTime(float totalTime)
		{
			cacheTotalTime = totalTime;
		}

		public void SetRestartOnEnd(bool value)
		{
			restartOnEnd = value;
		}

		public virtual void ForceComplete()
		{
			remainingTime = 0f;
		}

		public void AddCallback(Action callback)
		{
			TimerJobCompleted += callback;
		}

		public void DetachCallback(Action callback)
		{
			TimerJobCompleted -= callback;
		}

		public void DetachAllCallbacks()
		{
			this.TimerJobCompleted = null;
			this.TimerTick = null;
		}

		public virtual void Pause()
		{
			paused = true;
			tickSpeed = 0f;
		}

		public virtual void Resume()
		{
			paused = false;
			tickSpeed = 1f;
		}

		public virtual void StopAndDetachCallbacks()
		{
			this.TimerJobCompleted = null;
			this.TimerTick = null;
			paused = true;
			tickSpeed = 0f;
		}

		public virtual void RestartTimer()
		{
			remainingTime = cacheTotalTime;
			paused = false;
			tickSpeed = 1f;
		}

		public int GetCompletionPercentage()
		{
			return (int)(100f - remainingTime / cacheTotalTime * 100f);
		}

		public abstract void OnTimeTick(float deltaTime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void SubtractFromRemainingTime(float amount)
		{
			remainingTime -= amount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void TickTimer(float remainingTime)
		{
			this.TimerTick?.Invoke(remainingTime);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void TimerEnded()
		{
			this.TimerJobCompleted?.Invoke();
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.Write("tickSpeed", tickSpeed);
			serializer.Write("remainingTime", remainingTime);
			serializer.Write("cacheTotalTime", cacheTotalTime);
			serializer.Write("restartOnEnd", restartOnEnd);
			serializer.Write("paused", paused);
		}

		public BaseTimer(FVDeserializer deserializer)
		{
			tickSpeed = deserializer.ReadFloat("tickSpeed");
			remainingTime = deserializer.ReadFloat("remainingTime");
			cacheTotalTime = deserializer.ReadFloat("cacheTotalTime");
			restartOnEnd = deserializer.ReadBool("restartOnEnd");
			paused = deserializer.ReadBool("paused");
		}
	}
}
