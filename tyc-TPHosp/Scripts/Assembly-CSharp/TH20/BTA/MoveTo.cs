using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class MoveTo : CharacterAction
	{
		[BehaviorDesigner.Runtime.Tasks.Tooltip("The destination the agent is moving towards")]
		public SharedVector3 _targetPosition;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The rotation the agent should end at")]
		public SharedFloat _targetRotation;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("The destination object the agent is moving towards")]
		public SharedItemRef _targetObject;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("How close we need to get to the target. Set to 0 for perfect arrival, 1 or so if you don't care so much, e.g. for wandering.")]
		public SharedFloat _arrivalDistance;

		public bool _restartPathOnInterrupted;

		private bool _recalculatePath;

		protected TaskStatus _status = TaskStatus.Running;

		private float _coolDownTime;

		public override void OnStart()
		{
			base.OnStart();
			_status = TaskStatus.Running;
			_coolDownTime = 0f;
			_recalculatePath = false;
			CalculatePath();
		}

		public override void OnEnd()
		{
			if (_status == TaskStatus.Running)
			{
				base.Character.NavPath.Halt();
				_status = TaskStatus.Inactive;
			}
			base.OnEnd();
		}

		public override void OnReset()
		{
			base.OnReset();
			CalculatePath();
		}

		public override TaskStatus OnUpdate()
		{
			if (_status == TaskStatus.Failure)
			{
				if (_coolDownTime <= 0f || _coolDownTime + GameAlgorithms.Config.NavFailCoolDownTime < GameTime.time)
				{
					return TaskStatus.Failure;
				}
				return TaskStatus.Running;
			}
			if (base.Character.NavPathComplete)
			{
				OnPathComplete(base.Character.NavPathResult);
			}
			if (_recalculatePath)
			{
				CalculatePath();
				_recalculatePath = false;
			}
			return _status;
		}

		private void OnPathComplete(EPathStatus pathStatus)
		{
			switch (pathStatus)
			{
			case EPathStatus.Success:
				_status = TaskStatus.Success;
				return;
			case EPathStatus.Interrupted:
				if (_restartPathOnInterrupted)
				{
					_recalculatePath = true;
					_status = TaskStatus.Running;
					return;
				}
				break;
			}
			_status = TaskStatus.Failure;
			if (pathStatus == EPathStatus.Failure)
			{
				_coolDownTime = GameTime.time;
			}
		}

		private void CalculatePath()
		{
			NavPath navPath = base.Character.NavPath;
			Vector3 position = (_targetObject.IsValid() ? _targetObject.Value.Get.WorldPosition : _targetPosition.Value);
			_status = TaskStatus.Running;
			if (!_targetRotation.IsShared)
			{
				navPath.MoveTo(position, base.Character, _arrivalDistance.Value);
			}
			else
			{
				navPath.MoveTo(position, _targetRotation.Value, base.Character, _arrivalDistance.Value);
			}
		}
	}
}
