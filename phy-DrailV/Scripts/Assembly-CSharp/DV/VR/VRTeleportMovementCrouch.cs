using UnityEngine;
using VRTK;

namespace DV.VR
{
	public class VRTeleportMovementCrouch : MonoBehaviour
	{
		private LocomotionInputVr inputVr;

		private bool wasCrouched;

		private Transform playArea;

		private void Start()
		{
			inputVr = new LocomotionInputVr();
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			LocomotionSetup.LocomotionChanged += LocomotionChanged;
			LocomotionChanged(LocomotionSetup.CurrentLocomotion);
		}

		private void OnDestroy()
		{
			LocomotionSetup.LocomotionChanged -= LocomotionChanged;
			inputVr?.Dispose();
		}

		private void TeleportFinished()
		{
			wasCrouched = false;
			UpdatePosition();
		}

		private void Update()
		{
			UpdatePosition();
		}

		private void UpdatePosition()
		{
			if ((bool)playArea)
			{
				inputVr.UpdateFrame();
				bool crouchRequested = inputVr.CrouchRequested;
				if (crouchRequested != wasCrouched)
				{
					Vector3 vector = (crouchRequested ? Vector3.down : Vector3.up);
					playArea.transform.position += vector * 0.9f;
				}
				wasCrouched = crouchRequested;
			}
		}

		private void LocomotionChanged(LocomotionType loco)
		{
			base.enabled = loco == LocomotionType.Teleport;
			PlayerManager.PlayerTeleportFinished -= TeleportFinished;
			if (base.enabled)
			{
				PlayerManager.PlayerTeleportFinished += TeleportFinished;
			}
		}
	}
}
