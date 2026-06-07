namespace Dhs5.Utility.Updates
{
	public struct UpdateTimelineInstanceHandle
	{
		public static UpdateTimelineInstanceHandle Empty;

		public readonly ulong key;

		public readonly bool IsValid => Updater.Instance.TimelineInstanceExist(key);

		public readonly bool IsActive
		{
			get
			{
				if (TryGetInstance(out var instance))
				{
					return instance.IsActive;
				}
				return false;
			}
		}

		public readonly float Time
		{
			get
			{
				if (TryGetInstance(out var instance))
				{
					return instance.Time;
				}
				return -1f;
			}
		}

		public readonly float NormalizedTime
		{
			get
			{
				if (TryGetInstance(out var instance))
				{
					return instance.NormalizedTime;
				}
				return -1f;
			}
		}

		public readonly float Duration
		{
			get
			{
				if (TryGetInstance(out var instance))
				{
					return instance.duration;
				}
				return 0f;
			}
		}

		public readonly bool Loop
		{
			get
			{
				if (TryGetInstance(out var instance))
				{
					return instance.Loop;
				}
				return false;
			}
			set
			{
				if (TryGetInstance(out var instance))
				{
					instance.Loop = value;
				}
			}
		}

		public readonly float Timescale
		{
			get
			{
				if (TryGetInstance(out var instance))
				{
					return instance.Timescale;
				}
				return -1f;
			}
			set
			{
				if (value >= 0f && TryGetInstance(out var instance))
				{
					instance.Timescale = value;
				}
			}
		}

		public event UpdateCallback Updated
		{
			add
			{
				if (TryGetInstance(out var instance))
				{
					instance.Updated += value;
				}
			}
			remove
			{
				if (TryGetInstance(out var instance))
				{
					instance.Updated -= value;
				}
			}
		}

		public event UpdateTimelineEvent EventTriggered
		{
			add
			{
				if (TryGetInstance(out var instance))
				{
					instance.EventTriggered += value;
				}
			}
			remove
			{
				if (TryGetInstance(out var instance))
				{
					instance.EventTriggered -= value;
				}
			}
		}

		public UpdateTimelineInstanceHandle(ulong key)
		{
			this.key = key;
		}

		private readonly bool TryGetInstance(out UpdateTimelineInstance instance)
		{
			return Updater.Instance.TryGetUpdateTimelineInstance(key, out instance);
		}

		public readonly void Play()
		{
			if (TryGetInstance(out var instance))
			{
				instance.Play();
			}
		}

		public readonly void Pause()
		{
			if (TryGetInstance(out var instance))
			{
				instance.Pause();
			}
		}

		public readonly void SetTime(float time, bool triggerCustomEvents = false)
		{
			if (TryGetInstance(out var instance))
			{
				instance.SetTime(time, triggerCustomEvents);
			}
		}

		public readonly void SetNormalizedTime(float normalizedTime, bool triggerCustomEvents = false)
		{
			if (TryGetInstance(out var instance))
			{
				instance.SetNormalizedTime(normalizedTime, triggerCustomEvents);
			}
		}

		public readonly void Complete(bool triggerCustomEvents = false)
		{
			if (TryGetInstance(out var instance))
			{
				instance.Complete(triggerCustomEvents);
			}
		}

		public readonly void Restart(bool complete = false)
		{
			if (TryGetInstance(out var instance))
			{
				instance.Restart(complete);
			}
		}

		public readonly void Reset()
		{
			if (TryGetInstance(out var instance))
			{
				instance.Reset();
			}
		}

		public readonly void Kill()
		{
			if (key != 0)
			{
				Updater.KillTimelineInstance(this);
			}
		}
	}
}
