using UnityEngine;

namespace OffroadExplorer.Lobby
{
	public class CameraPositionMarker : MonoBehaviour
	{
		[Header("Visualization")]
		[Tooltip("Color of the gizmo in the editor")]
		[SerializeField]
		private Color gizmoColor;

		[Tooltip("Size of the camera frustum visualization")]
		[SerializeField]
		private float frustumSize;

		[Tooltip("Field of view for frustum visualization")]
		[SerializeField]
		private float previewFOV;

		[Tooltip("Label to display in scene view")]
		[SerializeField]
		private string label;
	}
}
