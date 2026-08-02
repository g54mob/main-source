using FishingGameTool.CustomAttribute;
using UnityEngine;

namespace FishingGameTool.Example
{
	[RequireComponent(typeof(Animator), typeof(CharacterController))]
	public class CharacterMovement : MonoBehaviour
	{
		public enum WitchCamera
		{
			TPP = 0,
			FPP = 1
		}

		[BetterHeader("Character Movement Settings", 20)]
		[Space]
		public float _moveSpeed;

		public float _turnSmoothTime;

		public float _gravity;

		public float _gravityAccel;

		[Space]
		public LayerMask _groundMask;

		public Vector3 _groundCheckerSize;

		[Space]
		[BetterHeader("Camera Settings", 20)]
		public Transform _tppCamera;

		public Transform _fppCamera;

		public WitchCamera _witchCamera;

		private Vector2 _moveInput;

		private Vector3 _moveVel;

		private Vector3 _gravityVel;

		private float _currentGravityAccel;

		private float _turnSmoothVelocity;

		private CharacterController _characterController;

		private Animator _animator;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_animator = GetComponent<Animator>();
			WitchCameraControl();
		}

		private void Update()
		{
			WitchCameraControl();
			HandleInput();
		}

		private void WitchCameraControl()
		{
			if (_witchCamera == WitchCamera.TPP)
			{
				_fppCamera.gameObject.SetActive(value: false);
				_tppCamera.gameObject.SetActive(value: true);
			}
			else
			{
				_tppCamera.gameObject.SetActive(value: false);
				_fppCamera.gameObject.SetActive(value: true);
			}
		}

		private void FixedUpdate()
		{
			Movement();
			Gravity();
		}

		private void Gravity()
		{
			if (IsGrounded())
			{
				_currentGravityAccel = 0f;
				float num = 2f;
				_gravityVel = Vector3.up * (0f - num);
			}
			else
			{
				_currentGravityAccel = Mathf.Lerp(_currentGravityAccel, 1f, _gravityAccel * Time.fixedDeltaTime);
				_gravityVel += Vector3.up * _gravity * _currentGravityAccel * Time.fixedDeltaTime;
			}
			_characterController.Move(_gravityVel * Time.fixedDeltaTime);
		}

		private void Movement()
		{
			if (_witchCamera == WitchCamera.TPP)
			{
				Vector3 dir = new Vector3(_moveInput.x, 0f, _moveInput.y);
				AnimationControl(dir);
				if (dir.magnitude >= 0.1f)
				{
					float num = Mathf.Atan2(dir.x, dir.z) * 57.29578f + _tppCamera.eulerAngles.y;
					float y = Mathf.SmoothDampAngle(base.transform.eulerAngles.y, num, ref _turnSmoothVelocity, _turnSmoothTime * Time.fixedDeltaTime);
					base.transform.rotation = Quaternion.Euler(0f, y, 0f);
					_moveVel = Quaternion.Euler(0f, num, 0f) * Vector3.forward;
					_characterController.Move(_moveVel.normalized * _moveSpeed * Time.fixedDeltaTime);
				}
			}
			else
			{
				Vector3 vector = base.transform.right * _moveInput.x + base.transform.forward * _moveInput.y;
				AnimationControl(vector);
				_characterController.Move(vector * _moveSpeed * Time.fixedDeltaTime);
			}
		}

		private void AnimationControl(Vector3 dir)
		{
		}

		private bool IsGrounded()
		{
			return Physics.CheckBox(base.transform.position, new Vector3(_groundCheckerSize.x / 2f, _groundCheckerSize.y / 2f, _groundCheckerSize.z / 2f), base.transform.rotation, _groundMask);
		}

		private void HandleInput()
		{
			_moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		}

		public Transform GetCurrentCam()
		{
			if (_witchCamera != WitchCamera.TPP)
			{
				return _fppCamera;
			}
			return _tppCamera;
		}

		public void ChangeCamera()
		{
			if (_witchCamera == WitchCamera.TPP)
			{
				_witchCamera = WitchCamera.FPP;
			}
			else
			{
				_witchCamera = WitchCamera.TPP;
			}
		}
	}
}
