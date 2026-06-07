using UnityEngine;

namespace RLD
{
	public class GizmoTransformAxisMap2D
	{
		private Vector2 _freeAxis = Vector2.right;

		private AxisDescriptor _mappedAxisDesc = new AxisDescriptor(0, AxisSign.Positive);

		private GizmoTransform _transform;

		public AxisDescriptor MappedAxisDesc => _mappedAxisDesc;

		public int MappedAxisIndex => _mappedAxisDesc.Index;

		public AxisSign MappedAxisSign => _mappedAxisDesc.Sign;

		public bool IsMapped => _transform != null;

		public Vector2 Axis
		{
			get
			{
				if (IsMapped)
				{
					return _transform.GetAxis2D(_mappedAxisDesc);
				}
				return _freeAxis;
			}
		}

		public GizmoTransform Transform => _transform;

		public void Map(GizmoTransform transform, int axisIndex, AxisSign axisSign)
		{
			if (transform != null && axisIndex <= 1)
			{
				_mappedAxisDesc = new AxisDescriptor(axisIndex, axisSign);
				_transform = transform;
			}
		}

		public void Unmap()
		{
			_transform = null;
		}

		public void SetAxis(Vector2 axis)
		{
			if (IsMapped)
			{
				SetMappedAxis(axis);
			}
			else
			{
				SetFreeAxis(axis);
			}
		}

		public void SetMappedAxis(Vector2 axis)
		{
			if (IsMapped)
			{
				_transform.Rotate2D(QuaternionEx.FromToRotation2D(Axis, axis));
			}
		}

		public void SetFreeAxis(Vector2 axis)
		{
			_freeAxis = axis.normalized;
		}
	}
}
