using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
	[Serializable]
	public class MouseLook
	{
		public bool clampVerticalRotation;

		public float MinimumX;

		public float MaximumX;

		public bool lockCursor;

		public Quaternion charMovementThisFrame;

		public Quaternion camMovementThisFrame;

		private Quaternion m_CharacterTargetRot;

		private Quaternion m_CameraTargetRot;

		private float _controllerInputX;

		private float _controllerInputY;

		private float _controllerXRot;

		private bool _invertY;

		public void Init(Transform character, Transform camera)
		{
		}

		public void LookRotation(Transform character, Transform camera, bool disableClamp = false)
		{
		}

		public void UpdateCursorLock()
		{
		}

		public Quaternion ClampRotationAroundXAxis(Quaternion q)
		{
			return default(Quaternion);
		}

		public Quaternion ClampRotationAroundYAxis(Quaternion q)
		{
			return default(Quaternion);
		}
	}
}
