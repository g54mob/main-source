using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Elements
{
	public class AssemblePositionAdjuster
	{
		private readonly Transform cameraTransform;

		private Transform elementTransform;

		private float positionAdjustmentInterval;

		private Vector3 cameraPosition;

		[Inject]
		public AssemblePositionAdjuster([Inject(Id = "GameCamera")] Camera gameCamera)
		{
			cameraTransform = gameCamera.transform;
		}

		public void Init(Transform elementTransform, float positionAdjustmentInterval)
		{
			this.elementTransform = elementTransform;
			this.positionAdjustmentInterval = positionAdjustmentInterval;
			cameraPosition = cameraTransform.position;
		}

		public void AdjustPosition(Vector3 assemblePosition, Vector3 installPosition, float installDistance)
		{
			if ((bool)elementTransform)
			{
				float num = Mathf.Clamp01(installDistance / positionAdjustmentInterval);
				float sqrMagnitude = (cameraPosition - installPosition).sqrMagnitude;
				float sqrMagnitude2 = (cameraPosition - assemblePosition).sqrMagnitude;
				float num2 = (sqrMagnitude - sqrMagnitude2) * num;
				float num3 = Mathf.Sqrt(sqrMagnitude - num2);
				Vector3 vector = assemblePosition - cameraPosition;
				vector.Normalize();
				elementTransform.position = cameraPosition + vector * num3;
			}
		}

		public void Clear()
		{
			elementTransform = null;
		}
	}
}
