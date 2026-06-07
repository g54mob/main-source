using UnityEngine;

namespace RLD
{
	public abstract class GizmoCap : IGizmoCap
	{
		private Gizmo _gizmo;

		private GizmoHandle _handle;

		private bool _isVisible = true;

		private bool _isHoverable = true;

		protected GizmoHandle Handle => _handle;

		public Gizmo Gizmo => _gizmo;

		public int HandleId => _handle.Id;

		public bool IsVisible => _isVisible;

		public bool IsHoverable => _isHoverable;

		public bool IsHovered => _gizmo.HoverHandleId == HandleId;

		public Priority HoverPriority3D => Handle.HoverPriority3D;

		public Priority HoverPriority2D => Handle.HoverPriority2D;

		public Priority GenericHoverPriority => Handle.GenericHoverPriority;

		public GizmoCap(Gizmo gizmo, int handleId)
		{
			_gizmo = gizmo;
			_handle = Gizmo.CreateHandle(handleId);
		}

		public void SetVisible(bool isVisible)
		{
			if (_isVisible != isVisible)
			{
				_isVisible = isVisible;
				OnVisibilityStateChanged();
			}
		}

		public void SetHoverable(bool isHoverable)
		{
			if (_isHoverable != isHoverable)
			{
				_isHoverable = isHoverable;
				OnHoverableStateChanged();
			}
		}

		public abstract void Render(Camera camera);

		protected abstract void OnVisibilityStateChanged();

		protected abstract void OnHoverableStateChanged();
	}
}
