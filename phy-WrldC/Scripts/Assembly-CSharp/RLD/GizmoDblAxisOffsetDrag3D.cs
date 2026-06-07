using UnityEngine;

namespace RLD
{
	public class GizmoDblAxisOffsetDrag3D : GizmoPlaneDrag3D
	{
		public struct WorkData
		{
			public Vector3 DragOrigin;

			public Vector3 Axis0;

			public Vector3 Axis1;

			public float SnapStep0;

			public float SnapStep1;
		}

		private float _accumSnapDrag0;

		private float _accumSnapDrag1;

		private WorkData _workData;

		public override GizmoDragChannel DragChannel => GizmoDragChannel.Offset;

		public void SetWorkData(WorkData workData)
		{
			if (!IsActive)
			{
				_workData = workData;
			}
		}

		protected override Plane CalculateDragPlane()
		{
			return new Plane(Vector3.Normalize(Vector3.Cross(_workData.Axis0, _workData.Axis1)), _workData.DragOrigin);
		}

		protected override void CalculateDragValues()
		{
			float num = _planeDragSession.DragDelta.Dot(_workData.Axis0);
			float num2 = _planeDragSession.DragDelta.Dot(_workData.Axis1);
			if (CanSnap())
			{
				_relativeDragOffset = Vector3.zero;
				_accumSnapDrag0 += num;
				_accumSnapDrag1 += num2;
				if (SnapMath.CanExtractSnap(_workData.SnapStep0, _accumSnapDrag0))
				{
					float num3 = SnapMath.ExtractSnap(_workData.SnapStep0, ref _accumSnapDrag0);
					_relativeDragOffset += _workData.Axis0 * num3;
				}
				if (SnapMath.CanExtractSnap(_workData.SnapStep1, _accumSnapDrag1))
				{
					float num4 = SnapMath.ExtractSnap(_workData.SnapStep1, ref _accumSnapDrag1);
					_relativeDragOffset += _workData.Axis1 * num4;
				}
			}
			else
			{
				_accumSnapDrag0 = 0f;
				_accumSnapDrag1 = 0f;
				_relativeDragOffset = _planeDragSession.DragDelta * base.Sensitivity;
			}
			_totalDragOffset += _relativeDragOffset;
		}

		protected override void OnSessionEnd()
		{
			_accumSnapDrag0 = 0f;
			_accumSnapDrag1 = 0f;
		}
	}
}
