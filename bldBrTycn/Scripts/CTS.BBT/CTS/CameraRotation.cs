using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	[DefaultExecutionOrder(-40)]
	public class CameraRotation : MonoBehaviour, ILockable
	{
		[SerializeField]
		private float _speed = 1f;

		private float _speedModifier = 1f;

		private float _rotateInput;

		private MainCamera _cameraRef;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public event Action<float> CameraRotated;

		private void Awake()
		{
			_cameraRef = GetComponent<MainCamera>();
		}

		private void Update()
		{
			RotateCamera();
		}

		private void RotateCamera()
		{
			if (!(Math.Abs(_rotateInput) < 0.001f) && !UIUtility.InInputField())
			{
				RotateByStrength(_rotateInput);
			}
		}

		public void RotateByStrength(float p_strength)
		{
			if (!ObjectLock.IsLocked())
			{
				float num = p_strength * Time.unscaledDeltaTime * _speed * _speedModifier;
				_cameraRef.transform.RotateAround(_cameraRef.GroundPoint, Vector3.up, num);
				this.CameraRotated?.Invoke(Mathf.Abs(num));
			}
		}

		public void ParamsForThisScene(CameraRotationStruct cameraRotationStruct)
		{
			if (cameraRotationStruct.IsNeedToRotate)
			{
				base.enabled = true;
				_speed = cameraRotationStruct.speedRotation;
			}
			else
			{
				base.enabled = false;
			}
		}

		public CameraRotationStruct GetParams()
		{
			return new CameraRotationStruct
			{
				IsNeedToRotate = base.enabled,
				speedRotation = _speed
			};
		}

		private void OnEnable()
		{
			SubscribeInputs();
		}

		public void SetSpeedModifier(float modifier)
		{
			_speedModifier = modifier;
		}

		private void OnDisable()
		{
			UnsubscribeInputs();
		}

		private void SubscribeInputs()
		{
			InputManager.game.cameraRotation.onComplete += OnInputRotate;
			InputManager.game.cameraRotation.onUp += OnInputRotate;
		}

		private void UnsubscribeInputs()
		{
			_rotateInput = 0f;
			InputManager.game.cameraRotation.onComplete -= OnInputRotate;
			InputManager.game.cameraRotation.onUp -= OnInputRotate;
		}

		private void OnInputRotate(InputAction.CallbackContext ctx)
		{
			_rotateInput = ctx.ReadValue<float>();
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
