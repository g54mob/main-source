using UnityEngine;

namespace Dorfromantik
{
	public class TutorialEvent_MoveCameraTowards : TutorialEvent
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private Vector2 cameraMovementThreshold = new Vector2(0.4f, 0.4f);

		[SerializeField]
		private float cameraSpeedMultiplier = 1f;

		private CameraMovement cameraMovement;

		public void SetTarget(Component newTarget)
		{
			target = newTarget.transform;
		}

		public override void Begin()
		{
			cameraMovement = OverwritingSingleton<IngameUi>.Instance.cameraContainer.GetComponentInChildren<CameraMovement>();
			cameraMovement.MoveCameraUntilInView(target.position, cameraMovementThreshold, cameraSpeedMultiplier);
		}

		public override void Finish()
		{
		}

		public override void Skip()
		{
		}
	}
}
