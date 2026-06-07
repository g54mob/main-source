using UnityEngine;

namespace Cinemachine
{
	[ExecuteAlways]
	[SaveDuringPlay]
	[DisallowMultipleComponent]
	public class Cinemachine3rdPersonAim : CinemachineExtension
	{
		public LayerMask AimCollisionFilter;

		[TagField]
		public string IgnoreTag;

		public float AimDistance;

		public RectTransform AimTargetReticle;

		private void OnValidate()
		{
		}

		private void Reset()
		{
		}

		public override bool OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
		{
			return false;
		}

		private void DrawReticle(CinemachineBrain brain)
		{
		}

		private Vector3 GetLookAtPoint(Vector3 camPos)
		{
			return default(Vector3);
		}

		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}
	}
}
