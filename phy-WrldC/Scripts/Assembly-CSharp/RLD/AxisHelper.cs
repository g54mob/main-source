using UnityEngine;

namespace RLD
{
	public static class AxisHelper
	{
		public static Vector3 GetWorldAxis(Axis axis)
		{
			switch (axis)
			{
			case Axis.X:
				return Vector3.right;
			case Axis.Y:
				return Vector3.up;
			default:
				return Vector3.forward;
			}
		}

		public static Vector3 GetWorldAxis(Axis axis, AxisSign axisSign)
		{
			switch (axis)
			{
			case Axis.X:
				if (axisSign != AxisSign.Positive)
				{
					return -Vector3.right;
				}
				return Vector3.right;
			case Axis.Y:
				if (axisSign != AxisSign.Positive)
				{
					return -Vector3.up;
				}
				return Vector3.up;
			default:
				if (axisSign != AxisSign.Positive)
				{
					return -Vector3.forward;
				}
				return Vector3.forward;
			}
		}
	}
}
