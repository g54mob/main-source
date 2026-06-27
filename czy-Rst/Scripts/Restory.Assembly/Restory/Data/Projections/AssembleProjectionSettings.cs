using UnityEngine;

namespace Restory.Data.Projections
{
	[CreateAssetMenu(fileName = "AssembleProjectionSettings", menuName = "Restory/AssembleProjectionSettings")]
	public class AssembleProjectionSettings : ScriptableObject
	{
		[SerializeField]
		[Min(0.04f)]
		private float projectionAppearanceDistance = 0.1f;

		[SerializeField]
		[Min(0.01f)]
		private float projectionActivationDistance = 0.02f;

		[SerializeField]
		[Range(100f, 1000f)]
		private float elementRotationSpeed = 600f;

		public float ProjectionAppearanceDistance => projectionAppearanceDistance;

		public float ProjectionActivationDistance => projectionActivationDistance;

		public float ElementRotationSpeed => elementRotationSpeed;

		public float RotationAdjustmentInterval => ProjectionAppearanceDistance - ProjectionActivationDistance;
	}
}
