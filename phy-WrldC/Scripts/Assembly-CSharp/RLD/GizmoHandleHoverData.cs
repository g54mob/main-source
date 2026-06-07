using UnityEngine;

namespace RLD
{
	public class GizmoHandleHoverData
	{
		private int _handleId;

		private Gizmo _gizmo;

		private GizmoDimension _handleDimension;

		private Ray _hoverRay;

		private Vector3 _hoverPoint;

		private float _hoverEnter3D;

		public int HandleId => _handleId;

		public Gizmo Gizmo => _gizmo;

		public GizmoDimension HandleDimension => _handleDimension;

		public Ray HoverRay => _hoverRay;

		public Vector3 HoverPoint => _hoverPoint;

		public float HoverEnter3D => _hoverEnter3D;

		public GizmoHandleHoverData(Ray hoverRay, IGizmoHandle gizmoHandle, float hoverEnter3D)
		{
			_handleId = gizmoHandle.Id;
			_gizmo = gizmoHandle.Gizmo;
			_handleDimension = GizmoDimension.Dim3D;
			_hoverRay = hoverRay;
			_hoverEnter3D = hoverEnter3D;
			_hoverPoint = _hoverRay.GetPoint(_hoverEnter3D);
		}

		public GizmoHandleHoverData(Ray hoverRay, IGizmoHandle gizmoHandle, Vector2 hoverPt2D)
		{
			_handleId = gizmoHandle.Id;
			_gizmo = gizmoHandle.Gizmo;
			_handleDimension = GizmoDimension.Dim2D;
			_hoverRay = hoverRay;
			_hoverPoint = hoverPt2D;
		}
	}
}
