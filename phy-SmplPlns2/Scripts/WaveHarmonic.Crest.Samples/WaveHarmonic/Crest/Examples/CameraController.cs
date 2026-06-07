using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	internal sealed class CameraController : CustomBehaviour
	{
		[Serializable]
		private sealed class DebugFields
		{
			[Tooltip("Allows the camera to roll (rotating on the z axis).")]
			public bool _EnableCameraRoll;

			[Tooltip("Disables the XR occlusion mesh for debugging purposes. Only works with legacy XR.")]
			public bool _DisableOcclusionMesh;

			[Tooltip("Sets the XR occlusion mesh scale. Useful for debugging refractions. Only works with legacy XR.")]
			[RangeAttribute(1f, 2f)]
			public float _OcclusionMeshScale = 1f;
		}

		[SerializeField]
		private float _LinearSpeed = 10f;

		[SerializeField]
		private float _AngularSpeed = 70f;

		[SerializeField]
		private bool _SimulateForwardInput;

		[SerializeField]
		private bool _RequireLeftMouseButtonToMove;

		[SerializeField]
		private float _FixedDeltaTime = 1f / 60f;

		[SpaceAttribute(10f)]
		[SerializeField]
		private DebugFields _Debug = new DebugFields();

		private Vector2 _LastMousePosition = -Vector2.one;

		private bool _Dragging;

		private Transform _TargetTransform;

		private Camera _Camera;

		private protected override void Awake()
		{
			base.Awake();
			_TargetTransform = base.transform;
			if (!TryGetComponent<Camera>(out _Camera))
			{
				base.enabled = false;
			}
			else if (XRSettings.enabled)
			{
				XRSettings.useOcclusionMesh = !_Debug._DisableOcclusionMesh;
				XRSettings.occlusionMaskScale = _Debug._OcclusionMeshScale;
			}
		}

		private void Update()
		{
			float dt = Time.deltaTime;
			if (_FixedDeltaTime > 0f)
			{
				dt = _FixedDeltaTime;
			}
			UpdateMovement(dt);
			if (!XRSettings.enabled || XRSettings.loadedDeviceName.Contains("MockHMD"))
			{
				UpdateDragging(dt);
				UpdateKillRoll();
			}
			if (XRSettings.enabled)
			{
				if (XRSettings.useOcclusionMesh == _Debug._DisableOcclusionMesh)
				{
					XRSettings.useOcclusionMesh = !_Debug._DisableOcclusionMesh;
				}
				XRSettings.occlusionMaskScale = _Debug._OcclusionMeshScale;
			}
		}

		private void UpdateMovement(float dt)
		{
			if (Application.isFocused && (Mouse.current.leftButton.isPressed || !_RequireLeftMouseButtonToMove))
			{
				float num = (Keyboard.current.wKey.isPressed ? 1 : 0) - (Keyboard.current.sKey.isPressed ? 1 : 0);
				if (_SimulateForwardInput)
				{
					num = 1f;
				}
				float num2 = _LinearSpeed;
				if (Keyboard.current.leftShiftKey.isPressed)
				{
					num2 *= 3f;
				}
				_TargetTransform.position += dt * num * num2 * _TargetTransform.forward;
				_TargetTransform.position += (float)(Keyboard.current.eKey.isPressed ? 1 : 0) * dt * _LinearSpeed * _TargetTransform.up;
				_TargetTransform.position -= (float)(Keyboard.current.qKey.isPressed ? 1 : 0) * dt * _LinearSpeed * _TargetTransform.up;
				_TargetTransform.position -= (float)(Keyboard.current.aKey.isPressed ? 1 : 0) * dt * _LinearSpeed * _TargetTransform.right;
				_TargetTransform.position += (float)(Keyboard.current.dKey.isPressed ? 1 : 0) * dt * _LinearSpeed * _TargetTransform.right;
				_TargetTransform.position += (float)(Keyboard.current.eKey.isPressed ? 1 : 0) * dt * num2 * _TargetTransform.up;
				_TargetTransform.position -= (float)(Keyboard.current.qKey.isPressed ? 1 : 0) * dt * num2 * _TargetTransform.up;
				_TargetTransform.position -= (float)(Keyboard.current.aKey.isPressed ? 1 : 0) * dt * num2 * _TargetTransform.right;
				_TargetTransform.position += (float)(Keyboard.current.dKey.isPressed ? 1 : 0) * dt * num2 * _TargetTransform.right;
				float num3 = 0f;
				num3 += (float)(Keyboard.current.rightArrowKey.isPressed ? 1 : 0);
				num3 -= (float)(Keyboard.current.leftArrowKey.isPressed ? 1 : 0);
				num3 *= 5f;
				Vector3 eulerAngles = _TargetTransform.eulerAngles;
				eulerAngles.y += 0.1f * _AngularSpeed * num3 * dt;
				_TargetTransform.eulerAngles = eulerAngles;
			}
		}

		private void UpdateDragging(float dt)
		{
			if (Application.isFocused)
			{
				Vector2 vector = Mouse.current.position.ReadValue();
				bool wasPressedThisFrame = Mouse.current.leftButton.wasPressedThisFrame;
				if (!_Dragging && wasPressedThisFrame && _Camera.rect.Contains(_Camera.ScreenToViewportPoint(vector)) && !DebugGUI.OverGUI(vector))
				{
					_Dragging = true;
					_LastMousePosition = vector;
				}
				if (_Dragging && Mouse.current.leftButton.wasReleasedThisFrame)
				{
					_Dragging = false;
					_LastMousePosition = -Vector2.one;
				}
				if (_Dragging)
				{
					Vector2 vector2 = vector - _LastMousePosition;
					Vector3 eulerAngles = _TargetTransform.eulerAngles;
					eulerAngles.x += -0.1f * _AngularSpeed * vector2.y * dt;
					eulerAngles.y += 0.1f * _AngularSpeed * vector2.x * dt;
					_TargetTransform.eulerAngles = eulerAngles;
					_LastMousePosition = vector;
				}
			}
		}

		private void UpdateKillRoll()
		{
			if (!_Debug._EnableCameraRoll)
			{
				Vector3 eulerAngles = _TargetTransform.eulerAngles;
				eulerAngles.z = 0f;
				base.transform.eulerAngles = eulerAngles;
			}
		}
	}
}
