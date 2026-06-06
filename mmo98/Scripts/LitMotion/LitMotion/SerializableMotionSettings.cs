using System;
using UnityEngine;

namespace LitMotion
{
	[Serializable]
	public sealed record SerializableMotionSettings<TValue, TOptions> : MotionSettings<TValue, TOptions>, ISerializationCallbackReceiver where TValue : unmanaged where TOptions : unmanaged, IMotionOptions
	{
		[SerializeField]
		private SchedulerType schedulerType;

		public void OnBeforeSerialize()
		{
			SetScheduler(base.Scheduler);
		}

		public void OnAfterDeserialize()
		{
			scheduler = schedulerType switch
			{
				SchedulerType.Initialization => MotionScheduler.Initialization, 
				SchedulerType.InitializationIgnoreTimeScale => MotionScheduler.InitializationIgnoreTimeScale, 
				SchedulerType.InitializationRealtime => MotionScheduler.InitializationRealtime, 
				SchedulerType.EarlyUpdate => MotionScheduler.EarlyUpdate, 
				SchedulerType.EarlyUpdateIgnoreTimeScale => MotionScheduler.EarlyUpdateIgnoreTimeScale, 
				SchedulerType.EarlyUpdateRealtime => MotionScheduler.EarlyUpdateRealtime, 
				SchedulerType.FixedUpdate => MotionScheduler.FixedUpdate, 
				SchedulerType.PreUpdate => MotionScheduler.PreUpdate, 
				SchedulerType.PreUpdateIgnoreTimeScale => MotionScheduler.PreUpdateIgnoreTimeScale, 
				SchedulerType.PreUpdateRealtime => MotionScheduler.PreUpdateRealtime, 
				SchedulerType.Update => MotionScheduler.Update, 
				SchedulerType.UpdateIgnoreTimeScale => MotionScheduler.UpdateIgnoreTimeScale, 
				SchedulerType.UpdateRealtime => MotionScheduler.UpdateRealtime, 
				SchedulerType.PreLateUpdate => MotionScheduler.PreLateUpdate, 
				SchedulerType.PreLateUpdateIgnoreTimeScale => MotionScheduler.PreLateUpdateIgnoreTimeScale, 
				SchedulerType.PreLateUpdateRealtime => MotionScheduler.PreLateUpdateRealtime, 
				SchedulerType.PostLateUpdate => MotionScheduler.PostLateUpdate, 
				SchedulerType.PostLateUpdateIgnoreTimeScale => MotionScheduler.PostLateUpdateIgnoreTimeScale, 
				SchedulerType.PostLateUpdateRealtime => MotionScheduler.PostLateUpdateRealtime, 
				SchedulerType.TimeUpdate => MotionScheduler.TimeUpdate, 
				SchedulerType.TimeUpdateIgnoreTimeScale => MotionScheduler.TimeUpdateIgnoreTimeScale, 
				SchedulerType.TimeUpdateRealtime => MotionScheduler.TimeUpdateRealtime, 
				SchedulerType.Manual => MotionScheduler.Manual, 
				_ => null, 
			};
		}

		private void SetScheduler(IMotionScheduler value)
		{
			if (value == null)
			{
				schedulerType = SchedulerType.Default;
			}
			else if (value == MotionScheduler.Update)
			{
				schedulerType = SchedulerType.Update;
			}
			else if (value == MotionScheduler.UpdateIgnoreTimeScale)
			{
				schedulerType = SchedulerType.UpdateIgnoreTimeScale;
			}
			else if (value == MotionScheduler.UpdateRealtime)
			{
				schedulerType = SchedulerType.UpdateRealtime;
			}
			else if (value == MotionScheduler.FixedUpdate)
			{
				schedulerType = SchedulerType.FixedUpdate;
			}
			else if (value == MotionScheduler.Manual)
			{
				schedulerType = SchedulerType.Manual;
			}
			else if (value == MotionScheduler.Initialization)
			{
				schedulerType = SchedulerType.Initialization;
			}
			else if (value == MotionScheduler.InitializationIgnoreTimeScale)
			{
				schedulerType = SchedulerType.InitializationIgnoreTimeScale;
			}
			else if (value == MotionScheduler.InitializationRealtime)
			{
				schedulerType = SchedulerType.InitializationRealtime;
			}
			else if (value == MotionScheduler.EarlyUpdate)
			{
				schedulerType = SchedulerType.EarlyUpdate;
			}
			else if (value == MotionScheduler.EarlyUpdateIgnoreTimeScale)
			{
				schedulerType = SchedulerType.EarlyUpdateIgnoreTimeScale;
			}
			else if (value == MotionScheduler.EarlyUpdateRealtime)
			{
				schedulerType = SchedulerType.EarlyUpdateRealtime;
			}
			else if (value == MotionScheduler.PreUpdate)
			{
				schedulerType = SchedulerType.PreUpdate;
			}
			else if (value == MotionScheduler.PreUpdateIgnoreTimeScale)
			{
				schedulerType = SchedulerType.PreUpdateIgnoreTimeScale;
			}
			else if (value == MotionScheduler.PreUpdateRealtime)
			{
				schedulerType = SchedulerType.PreUpdateRealtime;
			}
			else if (value == MotionScheduler.PreLateUpdate)
			{
				schedulerType = SchedulerType.PreLateUpdate;
			}
			else if (value == MotionScheduler.PreLateUpdateIgnoreTimeScale)
			{
				schedulerType = SchedulerType.PreLateUpdateIgnoreTimeScale;
			}
			else if (value == MotionScheduler.PreLateUpdateRealtime)
			{
				schedulerType = SchedulerType.PreLateUpdateRealtime;
			}
			else if (value == MotionScheduler.PostLateUpdate)
			{
				schedulerType = SchedulerType.PostLateUpdate;
			}
			else if (value == MotionScheduler.PostLateUpdateIgnoreTimeScale)
			{
				schedulerType = SchedulerType.PostLateUpdateIgnoreTimeScale;
			}
			else if (value == MotionScheduler.PostLateUpdateRealtime)
			{
				schedulerType = SchedulerType.PostLateUpdateRealtime;
			}
			else if (value == MotionScheduler.TimeUpdate)
			{
				schedulerType = SchedulerType.TimeUpdate;
			}
			else if (value == MotionScheduler.TimeUpdateIgnoreTimeScale)
			{
				schedulerType = SchedulerType.TimeUpdateIgnoreTimeScale;
			}
			else if (value == MotionScheduler.TimeUpdateRealtime)
			{
				schedulerType = SchedulerType.TimeUpdateRealtime;
			}
		}
	}
}
