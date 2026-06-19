using UnityEngine;

namespace TH20
{
	public static class BoundsExtension
	{
		private static float Min(float f0, float f1, float f2, float f3, float f4, float f5, float f6, float f7)
		{
			return Mathf.Min(f0, Mathf.Min(f1, Mathf.Min(f2, Mathf.Min(f3, Mathf.Min(f4, Mathf.Min(f5, Mathf.Min(f6, f7)))))));
		}

		private static float Max(float f0, float f1, float f2, float f3, float f4, float f5, float f6, float f7)
		{
			return Mathf.Max(f0, Mathf.Max(f1, Mathf.Max(f2, Mathf.Max(f3, Mathf.Max(f4, Mathf.Max(f5, Mathf.Max(f6, f7)))))));
		}

		public static Bounds Transform(this Bounds bounds, Vector3 translation, Quaternion rotation)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			Vector3 vector = rotation * new Vector3(min.x, min.y, min.z);
			Vector3 vector2 = rotation * new Vector3(max.x, max.y, max.z);
			Vector3 vector3 = rotation * new Vector3(min.x, min.y, max.z);
			Vector3 vector4 = rotation * new Vector3(min.x, max.y, min.z);
			Vector3 vector5 = rotation * new Vector3(max.x, min.y, min.z);
			Vector3 vector6 = rotation * new Vector3(min.x, max.y, max.z);
			Vector3 vector7 = rotation * new Vector3(max.x, min.y, max.z);
			Vector3 vector8 = rotation * new Vector3(max.x, max.y, min.z);
			Vector3 vector9 = new Vector3(Min(vector.x, vector2.x, vector3.x, vector4.x, vector5.x, vector6.x, vector7.x, vector8.x), Min(vector.y, vector2.y, vector3.y, vector4.y, vector5.y, vector6.y, vector7.y, vector8.y), Min(vector.z, vector2.z, vector3.z, vector4.z, vector5.z, vector6.z, vector7.z, vector8.z));
			Vector3 vector10 = new Vector3(Max(vector.x, vector2.x, vector3.x, vector4.x, vector5.x, vector6.x, vector7.x, vector8.x), Max(vector.y, vector2.y, vector3.y, vector4.y, vector5.y, vector6.y, vector7.y, vector8.y), Max(vector.z, vector2.z, vector3.z, vector4.z, vector5.z, vector6.z, vector7.z, vector8.z));
			return new Bounds
			{
				min = vector9 + translation,
				max = vector10 + translation
			};
		}

		public static Rect GetScreenRect(this Bounds bounds)
		{
			Vector3 center = bounds.center;
			Vector3 extents = bounds.extents;
			Camera main = Camera.main;
			Vector2 vector = main.WorldToScreenPoint(new Vector3(center.x - extents.x, center.y - extents.y, center.z - extents.z));
			Vector2 vector2 = vector;
			Vector2 vector3 = vector;
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x + extents.x, center.y - extents.y, center.z - extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x - extents.x, center.y - extents.y, center.z + extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x + extents.x, center.y - extents.y, center.z + extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x - extents.x, center.y + extents.y, center.z - extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x + extents.x, center.y + extents.y, center.z - extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x - extents.x, center.y + extents.y, center.z + extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x + extents.x, center.y + extents.y, center.z + extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			return new Rect(vector.x, vector.y, vector2.x - vector.x, vector2.y - vector.y);
		}

		public static Bounds Rotate(this Bounds b, Quaternion quat)
		{
			Vector3 extents = b.extents;
			Vector3 vector = new Vector3(0f - extents.x, extents.y, extents.z);
			extents = quat * extents;
			vector = quat * vector;
			extents.x = Mathf.Abs(extents.x);
			extents.z = Mathf.Abs(extents.z);
			vector.x = Mathf.Abs(vector.x);
			vector.z = Mathf.Abs(vector.z);
			Vector3 extents2 = new Vector3(Mathf.Max(extents.x, vector.x), extents.y, Mathf.Max(extents.z, vector.z));
			b.extents = extents2;
			return b;
		}
	}
}
