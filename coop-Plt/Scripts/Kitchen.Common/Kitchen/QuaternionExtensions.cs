using UnityEngine;

namespace Kitchen
{
	public static class QuaternionExtensions
	{
		public static bool IsChangedFrom(this Quaternion q, Quaternion other)
		{
			if (!(Mathf.Abs(q.w - other.w) > 0.001f) && !(Mathf.Abs(q.x - other.x) > 0.001f) && !(Mathf.Abs(q.y - other.y) > 0.001f))
			{
				return Mathf.Abs(q.z - other.z) > 0.001f;
			}
			return true;
		}
	}
}
