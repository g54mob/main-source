using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TH20.BTA
{
	[TaskDescription("Wait a specified amount of time. The task will return running until the task is done waiting. It will return success after the wait time has elapsed.")]
	[UnityEngine.HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=22")]
	[TaskCategory(" TH20")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	public class Wait : Action
	{
		public class SaveState : BaseSaveState
		{
			public float waitDuration;

			public float startTime;

			public float pauseTime;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[UnityEngine.Tooltip("Use scaled time")]
		public SharedBool useScaledTime = true;

		[UnityEngine.Tooltip("The amount of time to wait")]
		public SharedFloat waitTime = 1f;

		[UnityEngine.Tooltip("Should the wait be randomized?")]
		public SharedBool randomWait = false;

		[UnityEngine.Tooltip("The minimum wait time if random wait is enabled")]
		public SharedFloat randomWaitMin = 1f;

		[UnityEngine.Tooltip("The maximum wait time if random wait is enabled")]
		public SharedFloat randomWaitMax = 1f;

		private float waitDuration;

		private float startTime;

		private float pauseTime;

		private float GetTime()
		{
			if (!useScaledTime.Value)
			{
				return GameTime.unscaledTime;
			}
			return GameTime.time;
		}

		public override void OnStart()
		{
			startTime = GetTime();
			if (randomWait.Value)
			{
				waitDuration = Random.Range(randomWaitMin.Value, randomWaitMax.Value);
			}
			else
			{
				waitDuration = waitTime.Value;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (startTime + waitDuration < GetTime())
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}

		public override void OnPause(bool paused)
		{
			if (paused)
			{
				pauseTime = GetTime();
			}
			else
			{
				startTime += GetTime() - pauseTime;
			}
		}

		public override void OnReset()
		{
			waitTime = 1f;
			useScaledTime = true;
			randomWait = false;
			randomWaitMin = 1f;
			randomWaitMax = 1f;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				waitDuration = waitDuration,
				startTime = startTime,
				pauseTime = pauseTime
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			waitDuration = saveState.waitDuration;
			startTime = saveState.startTime;
			pauseTime = saveState.pauseTime;
		}
	}
}
