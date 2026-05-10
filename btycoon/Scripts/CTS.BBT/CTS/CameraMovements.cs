using System;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	[DefaultExecutionOrder(-40)]
	public class CameraMovements : MonoBehaviour, ILockable
	{
		[SerializeField]
		private float _speed;

		[SerializeField]
		private Bounds _movementBounds;

		private Vector2 _inputDirection;

		private Vector4 _bounds;

		private MainCamera _cameraRef;

		private float _speedSettingModifier = 1f;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public event Action<float> OnValueChanged;

		private void Awake()
		{
			_cameraRef = GetComponent<MainCamera>();
			Vector2 vector = _movementBounds.center.ToHorizontal2D();
			Vector2 vector2 = _movementBounds.extents.ToHorizontal2D();
			_bounds = new Vector4(vector.x + vector2.x, vector.y + vector2.y, vector.x - vector2.x, vector.y - vector2.y);
		}

		public void ParamsForThisScene(CameraMovementStruct cameraMovementStruct)
		{
			ChangingBoundAndSpeed(cameraMovementStruct.Bounds, cameraMovementStruct.speed);
			base.enabled = cameraMovementStruct.IsNeedToMove;
		}

		public void ChangingBoundAndSpeed(Bounds bounds, float speed)
		{
			_speed = speed;
			Vector2 vector = bounds.center.ToHorizontal2D();
			Vector2 vector2 = bounds.extents.ToHorizontal2D();
			_movementBounds = bounds;
			_bounds = new Vector4(vector.x + vector2.x, vector.y + vector2.y, vector.x - vector2.x, vector.y - vector2.y);
			SetCameraInBounds();
		}

		public CameraMovementStruct GetCameraMovementStruct()
		{
			return new CameraMovementStruct
			{
				IsNeedToMove = base.enabled,
				speed = _speed,
				Bounds = _movementBounds
			};
		}

		private void LateUpdate()
		{
			MoveCamera();
		}

		private void OnEnable()
		{
			SubscribeInputs();
		}

		private void OnDisable()
		{
			UnsubscribeInputs();
		}

		public void SetSpeedModifier(float value)
		{
			_speedSettingModifier = value;
		}

		private void SubscribeInputs()
		{
			InputManager.game.cameraMovement.onComplete += OnInputMove;
			InputManager.game.cameraMovement.onUp += OnInputMove;
		}

		private void UnsubscribeInputs()
		{
			_inputDirection = Vector2.zero;
			InputManager.game.cameraMovement.onComplete -= OnInputMove;
			InputManager.game.cameraMovement.onUp -= OnInputMove;
		}

		private void MoveCamera()
		{
			if (_inputDirection.sqrMagnitude > 0.0001f && !UIUtility.InInputField())
			{
				MoveCameraInDirection(_inputDirection);
			}
		}

		public void MoveCameraInDirection(Vector2 p_localDirection)
		{
			Vector3 vector = _cameraRef.Rotation * p_localDirection.ToHorizontal3D();
			Move(vector * (Time.unscaledDeltaTime * _speed * _speedSettingModifier));
		}

		public void Move(Vector3 p_worldDirection)
		{
			if (!ObjectLock.IsLocked() && base.isActiveAndEnabled)
			{
				p_worldDirection = ClampDirectionIfNeeded(p_worldDirection);
				Vector3 position = base.transform.position;
				base.transform.position += p_worldDirection;
				this.OnValueChanged?.Invoke((position - base.transform.position).magnitude);
			}
		}

		private Vector3 ClampDirectionIfNeeded(Vector3 p_direction)
		{
			Vector3 groundPoint = _cameraRef.GroundPoint;
			return ClampPosition(groundPoint + p_direction) - groundPoint;
		}

		public void SetCameraInBounds()
		{
			Vector3 groundPoint = _cameraRef.GroundPoint;
			Vector3 vector = ClampPosition(groundPoint) - groundPoint;
			base.transform.position += vector;
		}

		private Vector3 ClampPosition(Vector3 targetPosition)
		{
			if (targetPosition.x > _bounds.x)
			{
				targetPosition.x = _bounds.x;
			}
			if (targetPosition.x < _bounds.z)
			{
				targetPosition.x = _bounds.z;
			}
			if (targetPosition.z > _bounds.y)
			{
				targetPosition.z = _bounds.y;
			}
			if (targetPosition.z < _bounds.w)
			{
				targetPosition.z = _bounds.w;
			}
			return targetPosition;
		}

		private void OnInputMove(InputAction.CallbackContext ctx)
		{
			Vector2 inputDirection = ctx.ReadValue<Vector2>();
			_inputDirection = inputDirection;
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
