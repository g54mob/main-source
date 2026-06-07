using UnityEngine;

namespace Brewery.Map
{
	[ExecuteAlways]
	public class MapBoundaryGizmo : MonoBehaviour
	{
		[Tooltip("The MapCameraSettings asset to visualize boundaries for")]
		[SerializeField]
		private MapCameraSettings settings;

		[Header("Gizmo Appearance")]
		[Tooltip("Color for boundary wireframe")]
		[SerializeField]
		private Color wireColor;

		[Tooltip("Semi-transparent fill color")]
		[SerializeField]
		private Color fillColor;

		[Tooltip("Height of the boundary walls drawn in Scene view")]
		[SerializeField]
		private float wallHeight;

		private void OnDrawGizmos()
		{
		}

		private void DrawSimpleBoxBoundary()
		{
		}

		private void DrawColliderBoundaries()
		{
		}
	}
}
