using UnityEngine;

namespace Gh.Tk
{
	public class MoveableWindowHandle3DUIView : BaseInteractable3DUIView
	{
		public Transform moveableParent;

		private Vector3 _previousMousePosition;

		public float minHandleSize;

		private Vector3[] _ourCorners;

		private Vector3[] _boundryCorners;

		public bool IsDragging { get; private set; }

		private Vector3 OurBottomLeftCorner => default(Vector3);

		private Vector3 OurTopRightCorner => default(Vector3);

		private Vector3 BoundryBottomLeftCorner => default(Vector3);

		private Vector3 BoundryTopRightCorner => default(Vector3);

		private float MaxDragAreaWidth => 0f;

		private float MinDragAreaWidth => 0f;

		private float MaxDragAreaHeight => 0f;

		private float MinDragAreaHeight => 0f;

		protected override void UpdateIsPressed()
		{
		}

		private void Update()
		{
		}

		public bool CanDrag()
		{
			return false;
		}

		private void BeginDrag()
		{
		}

		protected override void OnDisable()
		{
		}

		private Vector3 GetMouseWorldPosition()
		{
			return default(Vector3);
		}

		private void UpdateBoundryData()
		{
		}

		private void OnDrag()
		{
		}

		private void EndDrag()
		{
		}
	}
}
