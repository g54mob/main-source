using DG.Tweening;
using Data.FactoryFloor;
using Data.FactoryFloor.Freighter;
using Logic.Factory;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.FreightHub
{
	public class FreighterMovementBehaviourView : FreighterBehaviourView<FreighterMovementBehaviour>
	{
		private Vector3 _startPosition;

		private Vector3 _targetPosition;

		private Quaternion _targetRotation;

		private Vector3 _previousPosition;

		private bool _rotatingToHub;

		public override void Enter(IFreighterObjectStateBehaviour freighterObjectStateBehaviour, FreighterObject freighterObject, FreighterView freighterView)
		{
			base.Enter(freighterObjectStateBehaviour, freighterObject, freighterView);
			_rotatingToHub = false;
			_freighter.Movement.MoveToTargetEvent.RegisterMainThread(OnStartMoveToTarget);
			OnStartMoveToTarget(_freighter.Movement.StartPos, _freighter.Movement.EndPos);
		}

		public override void Exit()
		{
			_freighter.Movement.MoveToTargetEvent.UnRegisterMainThread(OnStartMoveToTarget);
		}

		public override void Update()
		{
			UpdateDronePosition();
			UpdateDroneRotation();
			float magnitude = (_view.transform.position - _previousPosition).magnitude;
			_previousPosition = _view.transform.position;
			if (_view.LoopSFXInstance.isValid())
			{
				_view.AudioManagerLocator.AudioManager.SetFreighterFlyingSpeed(_view.LoopSFXInstance, Mathf.Clamp01(magnitude));
			}
		}

		private void OnStartMoveToTarget(Vector3 startPosition, Vector3 endPosition)
		{
			_targetPosition = endPosition;
			_startPosition = startPosition;
			UpdateDroneTargetRotations();
			MoveToHub(instant: false);
		}

		private void UpdateDroneTargetRotations()
		{
			Vector3 vector = _startPosition - _targetPosition;
			vector.y = 0f;
			if (!(vector == Vector3.zero))
			{
				_targetRotation = Quaternion.LookRotation(vector);
			}
		}

		private void MoveToHub(bool instant)
		{
			_view.transform.DOKill();
			_view.transform.localScale = Vector3.one;
			RotateDrone(_targetRotation, _view.RotationDuration, instant);
			UpdateDronePosition();
		}

		private void RotateDrone(Quaternion targetRot, float duration, bool instantRotation)
		{
			if (instantRotation)
			{
				_view.transform.rotation = targetRot;
			}
			else
			{
				_view.transform.DORotateQuaternion(targetRot, duration).SetEase(Ease.InOutCubic);
			}
		}

		private void UpdateDronePosition()
		{
			if (FactoryUpdater.Instance.GetStepsPerSecond() > 0 && !_freighter.IsPaused)
			{
				Vector3 position = _freighter.Movement.Position;
				Vector3 nextProcessPosition = _freighter.Movement.GetNextProcessPosition();
				_view.transform.position = Vector3.Lerp(position, nextProcessPosition, _freighter.GetDeltaTime01());
			}
		}

		private void UpdateDroneRotation()
		{
			if (FactoryUpdater.Instance.GetStepsPerSecond() > 0 && !_freighter.IsPaused)
			{
				Quaternion rotation = _view.RotationPivot.rotation;
				Quaternion rotation2 = ((_freighter.Movement.CurrentVelocity != Vector3.zero) ? Quaternion.LookRotation(_freighter.Movement.CurrentVelocity) : _view.RotationPivot.rotation);
				_view.RotationPivot.rotation = rotation2;
				Vector3 right = _view.RotationPivot.right;
				_view.RotationPivot.localRotation = Quaternion.identity;
				_view.RotationPivot.Rotate(right, (0f - _view.TiltAmount) * _freighter.Movement.CurrentSpeed01, Space.World);
				Quaternion rotation3 = _view.RotationPivot.rotation;
				_view.RotationPivot.rotation = rotation;
				_view.RotationPivot.rotation = Quaternion.Slerp(_view.RotationPivot.rotation, rotation3, Time.deltaTime * _view.TiltSpeed);
				if ((float)_freighter.Movement.StepsUntilEnd <= (float)FactoryUpdater.Instance.GetStepsPerSecond() * _view.RotationDuration && !_rotatingToHub)
				{
					RotateToHub();
				}
			}
		}

		private void RotateToHub()
		{
			if (_freighter.Path.GetNextFactoryObject() != null)
			{
				_rotatingToHub = true;
				_view.transform.DOKill();
				FactoryObject nextFactoryObject = _freighter.Path.GetNextFactoryObject();
				int num = nextFactoryObject.Rotation - 90 + (nextFactoryObject.Mirrored ? 180 : 0);
				_view.transform.DORotateQuaternion(Quaternion.Euler(0f, num, 0f), _view.RotationDuration).SetEase(Ease.InOutCubic);
			}
		}
	}
}
