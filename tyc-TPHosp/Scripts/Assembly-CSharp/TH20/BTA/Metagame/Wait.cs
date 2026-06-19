using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace TH20.BTA.Metagame
{
	[TaskCategory(" TH20/Metagame Script")]
	[TaskIcon("{SkinColor}WaitIcon.png")]
	public class Wait : MetagameAction
	{
		public class SaveState : BaseSaveState
		{
			public float _waitDuration;

			public float _startTime;

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

		private float _waitDuration;

		private float _startTime;

		private float GetTime()
		{
			if (!useScaledTime.Value)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public override void OnStart()
		{
			base.OnStart();
			_startTime = GetTime();
			_waitDuration = waitTime.Value;
		}

		public override TaskStatus OnUpdate()
		{
			if (_startTime + _waitDuration < GetTime())
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_waitDuration = _waitDuration,
				_startTime = _startTime
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_waitDuration = saveState._waitDuration;
			_startTime = saveState._startTime;
		}
	}
}
