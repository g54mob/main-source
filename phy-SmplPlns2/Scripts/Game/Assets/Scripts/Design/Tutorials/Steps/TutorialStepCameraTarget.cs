using UnityEngine;

namespace Assets.Scripts.Design.Tutorials.Steps
{
	public class TutorialStepCameraTarget
	{
		public float Distance { get; }

		public Vector3 Position { get; }

		public Quaternion Rotation { get; }

		public TutorialStepCameraTarget(Vector3 position, Quaternion rotation, float distance)
		{
			Position = position;
			Rotation = rotation;
			Distance = distance;
		}

		public void MoveCameraToTarget()
		{
			Camera main = Camera.main;
			MoveObjectScript component = main.GetComponent<MoveObjectScript>();
			component.ResetPanning();
			component.DestinationPanUp = Vector3.up;
			component.PanningFocus = Position;
			component.TimeToFinishPanning = 1f;
			component.IsPanningFocusACameraTarget = true;
			component.CameraTarget = main.transform.parent;
			component.DestinationPanPosition = Position + Rotation * (Vector3.forward * Distance);
		}
	}
}
