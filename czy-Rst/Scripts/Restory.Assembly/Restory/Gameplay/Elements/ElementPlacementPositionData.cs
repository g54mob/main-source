using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementPlacementPositionData
	{
		public Quaternion PlacementPivotRotation { get; private set; }

		public Quaternion PlacementRotation { get; private set; }

		public Vector3 PlacementDirection { get; private set; }

		public Vector3 PlacementPositionOffset { get; private set; }

		public Vector3 BoxColliderSize { get; private set; }

		public Vector3 BoxColliderCenter { get; private set; }

		public ElementPlacementPositionData(Transform elementTransform, Transform placementPivot, BoxCollider collider)
		{
			SetPlacementData(elementTransform, placementPivot);
			SetColliderData(collider, elementTransform);
		}

		private void SetPlacementData(Transform elementTransform, Transform placementPivot)
		{
			PlacementPivotRotation = placementPivot.localRotation;
			PlacementRotation = Quaternion.Inverse(PlacementPivotRotation);
			PlacementDirection = PlacementRotation * Vector3.forward;
			PlacementPositionOffset = PlacementRotation * Vector3.Scale(placementPivot.localPosition, elementTransform.lossyScale);
		}

		private void SetColliderData(BoxCollider collider, Transform elementTransform)
		{
			BoxColliderSize = Vector3.Scale(collider.size, elementTransform.lossyScale);
			BoxColliderCenter = PlacementRotation * Vector3.Scale(collider.center, elementTransform.lossyScale);
		}
	}
}
