using UnityEngine;

namespace MalbersAnimations
{
	public class FreeLockCameraManager : ScriptableObject
	{
		[Header("Aim States")]
		public FreeLookCameraState AimRight;

		public FreeLookCameraState AimLeft;

		internal MFreeLookCamera mCamera;

		public void SetCamera(MFreeLookCamera Freecamera)
		{
			mCamera = Freecamera;
		}

		public void SetAimLeft(FreeLookCameraState state)
		{
			AimLeft = state;
		}

		public void SetAimRight(FreeLookCameraState state)
		{
			AimRight = state;
		}

		public void Target_Set(Transform tranform)
		{
			mCamera?.Target_Set(tranform);
		}

		public void Target_Set_Temporal(Transform tranform)
		{
			mCamera?.Target_Set_Temporal(tranform);
		}

		public void Target_Restore()
		{
			mCamera?.Target_Restore();
		}

		public void ChangeFOV(float newFOV)
		{
			mCamera?.ChangeFOV(newFOV);
		}

		public void ToggleFOV(bool val)
		{
			mCamera?.ToggleSprintFOV(val);
		}

		public virtual void ForceUpdateMode(bool val)
		{
			if ((bool)mCamera)
			{
				mCamera.updateType = (val ? UpdateType.LateUpdate : mCamera.defaultUpdate);
			}
		}

		public virtual void SetAim(int ID)
		{
			if ((bool)mCamera)
			{
				switch (ID)
				{
				case -1:
					SetTemporalState(AimLeft);
					break;
				case 1:
					SetTemporalState(AimRight);
					break;
				default:
					SetState(mCamera.DefaultState);
					break;
				}
			}
		}

		public virtual void SetState(FreeLookCameraState state)
		{
			SetState(state, temporal: false);
		}

		public virtual void SetStateInstant(FreeLookCameraState state)
		{
			mCamera?.SetState_Instant(state, temporal: false);
		}

		public virtual void SetTemporalState(FreeLookCameraState state)
		{
			SetState(state, temporal: true);
		}

		public virtual void MobileMovement(Vector2 input)
		{
			if ((bool)mCamera)
			{
				mCamera.MovementAxis.Value = input;
			}
		}

		public virtual void Camera_EnableInput(bool enabled)
		{
			mCamera?.EnableInput(enabled);
		}

		private void SetState(FreeLookCameraState state, bool temporal)
		{
			mCamera?.SetState(state, temporal);
		}
	}
}
