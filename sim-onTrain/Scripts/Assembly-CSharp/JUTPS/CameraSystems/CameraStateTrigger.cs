using UnityEngine;

namespace JUTPS.CameraSystems
{
	[AddComponentMenu("JU TPS/Third Person System/Cameras/Camera State Trigger")]
	public class CameraStateTrigger : MonoBehaviour
	{
		public float TransitionSpeed = 8f;

		public string CustomStateName = "";

		public CameraState CameraState = new CameraState("Camera State");

		private bool IsTransitioning;

		private JUCameraController mCameraController;

		private void Awake()
		{
			mCameraController = Object.FindObjectOfType<JUCameraController>();
		}

		private void Update()
		{
			if (IsCameraInsideBounds(mCameraController.transform.position))
			{
				if (CameraState == null || CustomStateName != "")
				{
					mCameraController.SetCustomCameraStateTransition(mCameraController.GetCurrentCameraState, CustomStateName, TransitionSpeed);
				}
				else
				{
					mCameraController.IsTransitioningToCustomState = true;
					mCameraController.SetCameraStateTransition(mCameraController.GetCurrentCameraState, CameraState, TransitionSpeed);
				}
				IsTransitioning = true;
			}
			else if (IsTransitioning)
			{
				mCameraController.DisableCustomStateTransitioningState();
			}
		}

		public bool IsCameraInsideBounds(Vector3 CameraPosition)
		{
			return new Bounds(base.transform.position, base.transform.localScale).Contains(CameraPosition);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.lossyScale);
			Gizmos.color = Color.white;
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
		}

		private void OnDrawGizmos()
		{
			Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.lossyScale);
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
			Color yellow = Color.yellow;
			yellow.a = 0.2f;
			Gizmos.color = yellow;
			Gizmos.DrawCube(Vector3.zero, Vector3.one);
		}
	}
}
