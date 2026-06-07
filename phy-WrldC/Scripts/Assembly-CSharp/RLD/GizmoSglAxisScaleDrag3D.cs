using UnityEngine;

namespace RLD
{
	public class GizmoSglAxisScaleDrag3D : GizmoPlaneDrag3D
	{
		public struct WorkData
		{
			public int AxisIndex;

			public Vector3 DragOrigin;

			public Vector3 Axis;

			public float SnapStep;

			public float EntityScale;
		}

		private float _accumSnapDrag;

		private WorkData _workData;

		private float _scale;

		private float _relativeScale = 1f;

		private float _totalScale = 1f;

		public override GizmoDragChannel DragChannel => GizmoDragChannel.Scale;

		public int AxisIndex => _workData.AxisIndex;

		public float RelativeScale => _relativeScale;

		public float TotalScale => _totalScale;

		public void SetWorkData(WorkData workData)
		{
			if (!IsActive)
			{
				_workData = workData;
				_scale = _workData.EntityScale;
			}
		}

		protected override Plane CalculateDragPlane()
		{
			return PlaneEx.GetCameraFacingAxisSlicePlane(_workData.DragOrigin, _workData.Axis, MonoSingleton<RTFocusCamera>.Get.TargetCamera);
		}

		protected override void CalculateDragValues()
		{
			float num = _planeDragSession.DragDelta.Dot(_workData.Axis);
			if (CanSnap())
			{
				_relativeDragScale = Vector3.one;
				_accumSnapDrag += num;
				if (SnapMath.CanExtractSnap(_workData.SnapStep, _accumSnapDrag))
				{
					float num2 = SnapMath.ExtractSnap(_workData.SnapStep, ref _accumSnapDrag);
					float scale = _scale;
					_scale += num2;
					_totalScale = _scale / _workData.EntityScale;
					_relativeScale = _scale / scale;
					_relativeDragScale[_workData.AxisIndex] = _relativeScale;
				}
			}
			else
			{
				_accumSnapDrag = 0f;
				float scale2 = _scale;
				_scale += num * base.Sensitivity;
				_totalScale = _scale / _workData.EntityScale;
				_relativeScale = _scale / scale2;
				_relativeDragScale[_workData.AxisIndex] = _relativeScale;
			}
			_totalDragScale[_workData.AxisIndex] = _totalScale;
		}

		protected override void OnSessionEnd()
		{
			_accumSnapDrag = 0f;
			_relativeScale = 1f;
			_totalScale = 1f;
			_scale = 1f;
		}
	}
}
