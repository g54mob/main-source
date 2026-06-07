using UnityEngine;

namespace RLD
{
	public class GizmoDblAxisScaleDrag3D : GizmoPlaneDrag3D
	{
		public struct WorkData
		{
			public int AxisIndex0;

			public int AxisIndex1;

			public Vector3 DragOrigin;

			public Vector3 Axis0;

			public Vector3 Axis1;

			public float SnapStep;
		}

		private WorkData _workData;

		private float _accumSnapDrag0;

		private float _accumSnapDrag1;

		private float _scale0;

		private float _scale1;

		private float _relativeScale0 = 1f;

		private float _relativeScale1 = 1f;

		private float _totalScale0 = 1f;

		private float _totalScale1 = 1f;

		private Vector3 _scaleDragAxis;

		public override GizmoDragChannel DragChannel => GizmoDragChannel.Scale;

		public int AxisIndex0 => _workData.AxisIndex0;

		public int AxisIndex1 => _workData.AxisIndex1;

		public float RelativeScale0 => _relativeScale0;

		public float RelativeScale1 => _relativeScale1;

		public float TotalScale0 => _totalScale0;

		public float TotalScale1 => _totalScale1;

		public void SetWorkData(WorkData workData)
		{
			if (!IsActive)
			{
				_workData = workData;
				_scale0 = 1f;
				_scale1 = 1f;
				_scaleDragAxis = ((workData.Axis0 + workData.Axis1) * 0.5f).normalized;
			}
		}

		protected override Plane CalculateDragPlane()
		{
			return new Plane(Vector3.Cross(_workData.Axis0, _workData.Axis1).normalized, _workData.DragOrigin);
		}

		protected override void CalculateDragValues()
		{
			float num = _planeDragSession.DragDelta.Dot(_scaleDragAxis);
			float num2 = num;
			float snapStep2;
			float snapStep = (snapStep2 = _workData.SnapStep);
			float num4;
			float num3 = (num4 = 1f);
			if (CanSnap())
			{
				_relativeDragScale = Vector3.one;
				_accumSnapDrag0 += num;
				if (SnapMath.CanExtractSnap(snapStep, _accumSnapDrag0))
				{
					float scale = _scale0;
					_scale0 += SnapMath.ExtractSnap(snapStep, ref _accumSnapDrag0);
					_totalScale0 = _scale0 / num3;
					_relativeScale0 = _scale0 / scale;
					_relativeDragScale[_workData.AxisIndex0] = _relativeScale0;
				}
				_accumSnapDrag1 += num2;
				if (SnapMath.CanExtractSnap(snapStep2, _accumSnapDrag1))
				{
					float scale2 = _scale1;
					_scale1 += SnapMath.ExtractSnap(snapStep2, ref _accumSnapDrag1);
					_totalScale1 = _scale1 / num4;
					_relativeScale1 = _scale1 / scale2;
					_relativeDragScale[_workData.AxisIndex1] = _relativeScale1;
				}
			}
			else
			{
				_accumSnapDrag0 = 0f;
				_accumSnapDrag1 = 0f;
				float scale3 = _scale0;
				_scale0 += num * base.Sensitivity;
				_totalScale0 = _scale0 / num3;
				_relativeScale0 = _scale0 / scale3;
				_relativeDragScale[_workData.AxisIndex0] = _relativeScale0;
				scale3 = _scale1;
				_scale1 += num2 * base.Sensitivity;
				_totalScale1 = _scale1 / num4;
				_relativeScale1 = _scale1 / scale3;
				_relativeDragScale[_workData.AxisIndex1] = _relativeScale1;
			}
			_totalDragScale[_workData.AxisIndex0] = _totalScale0;
			_totalDragScale[_workData.AxisIndex1] = _totalScale1;
		}

		protected override void OnSessionEnd()
		{
			_accumSnapDrag0 = 0f;
			_accumSnapDrag1 = 0f;
			_relativeScale0 = 1f;
			_relativeScale1 = 1f;
			_totalScale0 = 1f;
			_totalScale1 = 1f;
		}
	}
}
