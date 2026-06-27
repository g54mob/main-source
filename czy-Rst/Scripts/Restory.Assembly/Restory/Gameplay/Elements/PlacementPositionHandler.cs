using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class PlacementPositionHandler : MonoBehaviour
	{
		[SerializeField]
		private Transform placementPivot;

		[SerializeField]
		private Transform markerPivot;

		[SerializeField]
		private Transform markerPoint;

		private Vector3 markerOffset;

		public ElementPlacementPositionData PlacementPositionData { get; private set; }

		public Vector3 LastPlacementPosition { get; set; } = Vector3.zero;

		public Vector3 MarkerPosition => base.transform.position + PlacementPositionData.BoxColliderCenter + markerOffset;

		public void Init(BoxCollider boxCollider)
		{
			PlacementPositionData = new ElementPlacementPositionData(base.transform, placementPivot, boxCollider);
			SetMarkerPivotPosition(boxCollider);
		}

		private void SetMarkerPivotPosition(BoxCollider boxCollider)
		{
			Vector3 position = Vector3.zero;
			float num = float.NegativeInfinity;
			for (int i = 0; i < 8; i++)
			{
				Vector3 a = new Vector3(((i & 1) != 0) ? 1f : (-1f), ((i & 2) != 0) ? 1f : (-1f), ((i & 4) != 0) ? 1f : (-1f));
				Vector3 position2 = boxCollider.center + Vector3.Scale(a, boxCollider.size * 0.5f);
				Vector3 vector = boxCollider.transform.TransformPoint(position2);
				float num2 = Vector3.Dot(placementPivot.InverseTransformPoint(vector), Vector3.one);
				if (num2 > num)
				{
					num = num2;
					position = vector;
				}
			}
			markerPivot.position = position;
			Vector3 vector2 = boxCollider.transform.TransformPoint(boxCollider.center);
			markerOffset = placementPivot.InverseTransformDirection(markerPoint.position - vector2);
		}

		private void OnDrawGizmos()
		{
			if (PlacementPositionData != null)
			{
				Gizmos.color = Color.red;
				Matrix4x4 matrix = Gizmos.matrix;
				Gizmos.matrix = Matrix4x4.TRS(base.transform.position + PlacementPositionData.BoxColliderCenter, PlacementPositionData.PlacementRotation, Vector3.one);
				Gizmos.DrawWireCube(Vector3.zero, PlacementPositionData.BoxColliderSize);
				Gizmos.matrix = matrix;
				if ((bool)markerPoint && markerPivot.localPosition != Vector3.zero)
				{
					Gizmos.color = Color.red;
					Gizmos.DrawSphere(MarkerPosition, 0.008f);
				}
			}
		}
	}
}
