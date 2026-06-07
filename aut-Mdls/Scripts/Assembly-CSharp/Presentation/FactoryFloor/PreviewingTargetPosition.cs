using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class PreviewingTargetPosition
	{
		public Vector3 TargetPosition;

		public Quaternion TargetRotation;

		public float Random;

		public PreviewingTargetPosition(Vector3 targetPosition, Quaternion targetRotation, float random)
		{
			TargetPosition = targetPosition;
			TargetRotation = targetRotation;
			Random = random;
		}
	}
}
