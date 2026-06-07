using UnityEngine;

namespace RLD
{
	public class GizmoUniformScaleDrag3D : GizmoPlaneDrag3D
	{
		public struct WorkData
		{
			public Vector3 CameraRight;

			public Vector3 CameraUp;

			public Vector3 DragOrigin;

			public float SnapStep;
		}

		private WorkData _workData;

		private Vector3 _planeAxis0;

		private Vector3 _planeAxis1;

		private float _accumSnapDrag;

		private float _scale;

		private float _relativeScale = 1f;

		private float _totalScale = 1f;

		private Vector3 _scaleDragAxis;

		public override GizmoDragChannel DragChannel => GizmoDragChannel.Scale;

		public float TotalScale => _totalScale;

		public float RelativeScale => _relativeScale;

		public void SetWorkData(WorkData workData)
		{
			if (!IsActive)
			{
				_workData = workData;
				_scale = 1f;
				_scaleDragAxis = ((workData.CameraRight + workData.CameraUp) * 0.5f).normalized;
			}
		}

		protected override Plane CalculateDragPlane()
		{
			_planeAxis0 = _workData.CameraRight;
			_planeAxis1 = _workData.CameraUp;
			return new Plane(Vector3.Cross(_planeAxis0, _planeAxis1).normalized, _workData.DragOrigin);
		}

		protected override void CalculateDragValues()
		{
			if (CanSnap())
			{
				_relativeDragScale = Vector3.one;
				_accumSnapDrag += _planeDragSession.DragDelta.Dot(_scaleDragAxis);
				if (SnapMath.CanExtractSnap(_workData.SnapStep, _accumSnapDrag))
				{
					float num = SnapMath.ExtractSnap(_workData.SnapStep, ref _accumSnapDrag);
					float scale = _scale;
					_scale += num;
					_relativeScale = _scale / scale;
					_totalScale = _scale / 1f;
					_relativeDragScale = Vector3Ex.FromValue(_relativeScale);
				}
			}
			else
			{
				_accumSnapDrag = 0f;
				float scale2 = _scale;
				_scale += _planeDragSession.DragDelta.Dot(_scaleDragAxis) * base.Sensitivity;
				_relativeScale = _scale / scale2;
				_totalScale = _scale / 1f;
				_relativeDragScale = Vector3Ex.FromValue(_relativeScale);
			}
			_totalDragScale = Vector3Ex.FromValue(_totalScale);
		}

		protected override void OnSessionEnd()
		{
			_relativeScale = 1f;
			_totalScale = 1f;
		}
	}
}
