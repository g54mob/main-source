using JUTPS.CameraSystems;
using JUTPS.JUInputSystem;
using JUTPSActions;
using UnityEngine;

namespace JUTPS.ActionScripts
{
	public class AimOnRightJoystickDirection : JUTPSAction
	{
		[HideInInspector]
		public static Vector3 AimPosition;

		[HideInInspector]
		private JUCameraController cameraController;

		[Header("Settings")]
		public bool Enabled = true;

		public float DistanceFromCenter = 5f;

		public float UpOffset;

		public bool FireModeWhenHasJoystickDirection = true;

		[Header("Aim Mode Settings")]
		public bool SidescrollerAimMode;

		private float Xinput;

		private float Yinput;

		[HideInInspector]
		public bool IsUsingJoystick;

		private void Start()
		{
			cameraController = Object.FindObjectOfType<JUCameraController>();
		}

		private void Update()
		{
			if (!Enabled)
			{
				return;
			}
			float num = Mathf.Clamp(Mathf.Abs(JUInput.GetAxis(JUInput.Axis.RotateHorizontal)), -1f, 1f);
			if (Mathf.Clamp(Mathf.Abs(JUInput.GetAxis(JUInput.Axis.RotateVertical)), -1f, 1f) > 0.1f || num > 0.1f)
			{
				IsUsingJoystick = true;
				Yinput = JUInput.GetAxis(JUInput.Axis.RotateVertical);
				Xinput = JUInput.GetAxis(JUInput.Axis.RotateHorizontal);
				if (FireModeWhenHasJoystickDirection)
				{
					if (TPSCharacter.HoldableItemInUseRightHand == null)
					{
						TPSCharacter.CurrentTimeToDisableFireMode = 0f;
						TPSCharacter.FiringMode = true;
						TPSCharacter.FiringModeIK = true;
					}
					else if (!TPSCharacter.HoldableItemInUseRightHand.BlockFireMode)
					{
						TPSCharacter.CurrentTimeToDisableFireMode = 0f;
						TPSCharacter.FiringMode = true;
						TPSCharacter.FiringModeIK = true;
					}
				}
			}
			else if (FireModeWhenHasJoystickDirection && IsUsingJoystick)
			{
				TPSCharacter.FiringMode = false;
				TPSCharacter.FiringModeIK = false;
				IsUsingJoystick = false;
			}
			if (SidescrollerAimMode)
			{
				Vector3 vector = new Vector3(Xinput, Yinput);
				AimPosition = TPSCharacter.PivotItemRotation.transform.position + vector.normalized * DistanceFromCenter;
				TPSCharacter.LookAtPosition = AimPosition;
			}
			else
			{
				Vector3 normalized = new Vector3(Xinput, 0f, Yinput).normalized;
				Quaternion quaternion = Quaternion.Euler(0f, cameraController.mCamera.transform.eulerAngles.y, 0f);
				Quaternion quaternion2 = Quaternion.LookRotation(normalized, Vector3.up) * quaternion;
				AimPosition = TPSCharacter.PivotItemRotation.transform.position + quaternion2 * Vector3.forward * DistanceFromCenter + base.transform.up * UpOffset;
				TPSCharacter.LookAtPosition = AimPosition;
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			if (SidescrollerAimMode)
			{
				Gizmos.DrawWireCube(AimPosition, new Vector3(0.1f, 0.1f, 0f));
				Gizmos.DrawWireCube(AimPosition, new Vector3(0.5f, 0.5f, 0f));
			}
			else
			{
				Gizmos.DrawWireCube(AimPosition, new Vector3(0.1f, 0f, 0.1f));
				Gizmos.DrawWireCube(AimPosition, new Vector3(0.5f, 0f, 0.5f));
			}
		}
	}
}
