using UnityEngine;

namespace CTS
{
	public class WallCutter : MonoBehaviour
	{
		[SerializeField]
		private Vector2 _cutterPosition;

		[SerializeField]
		private Vector2 _cutterSize;

		public Vector4 GetCutterPosition => new Vector4(0f, _cutterPosition.y, _cutterPosition.x, 0f);

		public Vector2 GetCutterSize => new Vector2(_cutterSize.x / 2f, _cutterSize.y);

		private Vector3 GetCutterPositionGizmo => new Vector3(_cutterPosition.x, _cutterPosition.y, 0f);

		private Vector3 GetCutterSizeGizmo => new Vector3(_cutterSize.x, _cutterSize.y, 1f);

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			if (!(base.transform.parent == null))
			{
				Gizmos.matrix = base.transform.parent.localToWorldMatrix;
				Gizmos.DrawWireCube(GetCutterPositionGizmo, GetCutterSizeGizmo);
			}
		}
	}
}
