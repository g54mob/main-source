using System;
using DG.Tweening;
using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.CommonServices;
using Restory.Utils;
using Rewired;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Restory.Gameplay.Disassemble
{
	public class DisassembleRotationController : MonoBehaviour, IInitializable, IDisposable
	{
		[Header("General settings")]
		[SerializeField]
		private Transform targetTransform;

		[FormerlySerializedAs("ease")]
		[SerializeField]
		private Ease resetRotationEase = Ease.Linear;

		[FormerlySerializedAs("rotateDuration")]
		[SerializeField]
		private float resetRotationDuration = 0.5f;

		[SerializeField]
		private float dragRotationSpeed = 1f;

		[SerializeField]
		private float joystickDragRotationSpeed = 5f;

		[FormerlySerializedAs("resetRotation")]
		[SerializeField]
		private Button resetRotationButton;

		[RewiredActionsDropdown]
		public int rotateHorizontalAxisAction = -1;

		[RewiredActionsDropdown]
		public int rotateVerticalAxisAction = -1;

		[RewiredActionsDropdown]
		[Tooltip("Button, which needs to be held for rotation to trigger - intended to be used with a mouse button, not required to be held when using a gamepad.")]
		public int holdToRotateButtonAction = -1;

		private Sequence rotationSequence;

		private Quaternion initRotation;

		[SerializeField]
		private bool useRound;

		[SerializeField]
		[Range(0f, 10f)]
		private float round = 1f;

		[SerializeField]
		private bool invertY;

		private IPlayerInput playerInput;

		private ControlsManager controlsManager;

		private TweenSequencesService tweenSequences;

		private Camera gameCamera;

		private float xAxisRotation;

		private float yAxisRotation;

		private bool isRotationButtonPressed;

		public bool IsRotating
		{
			get
			{
				if (xAxisRotation == 0f && (yAxisRotation == 0f || Blocked))
				{
					return IsInProcess;
				}
				return true;
			}
		}

		public bool IsRotationButtonPressed
		{
			get
			{
				if (controlsManager.ControlType != InputControlsType.Joystick)
				{
					return playerInput.GetButton(holdToRotateButtonAction);
				}
				return true;
			}
		}

		public bool Blocked { get; set; }

		public Transform TargetTransform
		{
			get
			{
				return targetTransform;
			}
			set
			{
				targetTransform = value;
				if ((bool)value)
				{
					initRotation = targetTransform.rotation;
				}
			}
		}

		private bool IsInProcess
		{
			get
			{
				if (rotationSequence != null)
				{
					return rotationSequence.IsPlaying();
				}
				return false;
			}
		}

		[Inject]
		private void Construct(IPlayerInput playerInput, TweenSequencesService tweenSequences, ControlsManager controlsManager, [Inject(Id = "GameCamera")] Camera gameCamera)
		{
			this.playerInput = playerInput;
			this.tweenSequences = tweenSequences;
			this.controlsManager = controlsManager;
			this.gameCamera = gameCamera;
		}

		public void Initialize()
		{
			if ((bool)resetRotationButton)
			{
				resetRotationButton.onClick.AddListener(ResetLocalRotation);
			}
			playerInput.AddInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 29);
			playerInput.AddInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 29);
		}

		public void Dispose()
		{
			if ((bool)resetRotationButton)
			{
				resetRotationButton.onClick.RemoveListener(ResetLocalRotation);
			}
			playerInput?.RemoveInputEventDelegate(ResolveButtonJustPressed, InputActionEventType.ButtonJustPressed, 29);
			playerInput?.RemoveInputEventDelegate(ResolveButtonJustReleased, InputActionEventType.ButtonJustReleased, 29);
		}

		public void OnUpdate()
		{
			if (isRotationButtonPressed || controlsManager.ControlType == InputControlsType.Joystick)
			{
				Rotate();
			}
		}

		public void ResetLocalRotation(float duration)
		{
			if (!IsInProcess)
			{
				rotationSequence = tweenSequences.Create();
				rotationSequence.Append(targetTransform.DORotateQuaternion(initRotation, duration).SetEase(resetRotationEase));
			}
		}

		private void ResolveButtonJustPressed(InputActionEventData eventData)
		{
			isRotationButtonPressed = true;
		}

		private void ResolveButtonJustReleased(InputActionEventData eventData)
		{
			isRotationButtonPressed = false;
			Reset();
		}

		private void Rotate()
		{
			if (!targetTransform || IsInProcess || !isRotationButtonPressed || Blocked)
			{
				Reset();
				return;
			}
			CalculateAxis();
			if (useRound)
			{
				Round();
			}
			ApplyRotation();
		}

		private void CalculateAxis()
		{
			xAxisRotation = 0f - playerInput.GetAxis(rotateHorizontalAxisAction);
			yAxisRotation = 0f - playerInput.GetAxis(rotateVerticalAxisAction);
			if (controlsManager.ControlType == InputControlsType.Joystick)
			{
				xAxisRotation *= joystickDragRotationSpeed;
				yAxisRotation *= joystickDragRotationSpeed;
			}
			else
			{
				xAxisRotation *= dragRotationSpeed;
				yAxisRotation *= dragRotationSpeed;
			}
			if (invertY)
			{
				yAxisRotation *= -1f;
			}
		}

		private void ApplyRotation()
		{
			Vector3 right = gameCamera.transform.right;
			Vector3 up = gameCamera.transform.up;
			targetTransform.Rotate(right, 0f - yAxisRotation, Space.World);
			targetTransform.Rotate(up, xAxisRotation, Space.World);
		}

		private void Assert()
		{
		}

		private void Round()
		{
			float num = Math.Abs(xAxisRotation);
			float num2 = Math.Abs(yAxisRotation);
			if (num < round && num < num2)
			{
				xAxisRotation = 0f;
			}
			else if (num2 < round && num2 < num)
			{
				yAxisRotation = 0f;
			}
		}

		private void ResetLocalRotation()
		{
			ResetLocalRotation(resetRotationDuration);
		}

		private void Reset()
		{
			xAxisRotation = 0f;
			yAxisRotation = 0f;
		}

		public void ApplyRotationWithConcreteAxis(Vector2 inputAxis)
		{
			xAxisRotation = inputAxis.x;
			yAxisRotation = inputAxis.y;
			ApplyRotation();
		}
	}
}
