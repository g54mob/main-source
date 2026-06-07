using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
	[Serializable]
	public class MouseLook
	{
		public InputController inputctrl;

		private float yRot;

		private float xRot;

		public float XSensitivity;

		public float YSensitivity;

		public bool invertY;

		[SerializeField]
		private bool clampVerticalRotation;

		[SerializeField]
		private float MinimumX;

		[SerializeField]
		private float MaximumX;

		[SerializeField]
		private bool smooth;

		[SerializeField]
		private float smoothTime;

		[SerializeField]
		private float rotateToLaddersmoothTime;

		public bool lockCursor;

		[SerializeField]
		private float sittingMinimumX;

		[SerializeField]
		private float sittingMaximumX;

		[SerializeField]
		private float sittingMinimumY;

		[SerializeField]
		private float sittingMaximumY;

		private Quaternion m_CharacterTargetRot;

		private Quaternion m_CameraTargetRot;

		private bool m_cursorIsLocked;

		private Vector2 rotation;

		public float isLockedOnDistance;

		public void Init(Transform character, Transform camera)
		{
		}

		public void ResetRotation(Transform character)
		{
		}

		public void MouseLookOnDisable()
		{
		}

		public void LookRotation(Transform character, Transform camera, Quaternion externalRotation, Transform ladderTrigger)
		{
		}

		public void SetCursorLock(bool value)
		{
		}

		public void UpdateCursorLock()
		{
		}

		private void InternalLockUpdate()
		{
		}

		private Quaternion ClampRotationAroundXAxis(Quaternion q)
		{
			return default(Quaternion);
		}

		private Vector2 SittingClampRotation(Vector2 q)
		{
			return default(Vector2);
		}
	}
}
