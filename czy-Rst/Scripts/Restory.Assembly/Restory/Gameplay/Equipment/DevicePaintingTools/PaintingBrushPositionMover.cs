using UnityEngine;

namespace Restory.Gameplay.Equipment.DevicePaintingTools
{
	public class PaintingBrushPositionMover : MonoBehaviour
	{
		[SerializeField]
		private PaintingBrush paintingBrush;

		[SerializeField]
		private ConcentricCirclesPaintingBrushMultiRaycaster ringsRaycaster;

		[SerializeField]
		private float smoothingDistanceMultiplier = 1f;

		[SerializeField]
		private float smoothFollowSpeed = 2f;

		private Vector2 currentScreenPosition;

		public Vector2 CurrentScreenPosition => currentScreenPosition;

		public void SetInitialPaintingScreenPosition(Vector2 initialScreenPosition)
		{
			currentScreenPosition = initialScreenPosition;
		}

		public void MoveTowardsPosition(Vector2 targetScreenPosition)
		{
			if (Vector3.Distance(targetScreenPosition, currentScreenPosition) < ringsRaycaster.FarthestRingRadius * smoothingDistanceMultiplier)
			{
				currentScreenPosition = targetScreenPosition;
				return;
			}
			Vector3 vector = Vector2.Lerp(currentScreenPosition, targetScreenPosition, Time.deltaTime * smoothFollowSpeed);
			currentScreenPosition = vector;
		}
	}
}
