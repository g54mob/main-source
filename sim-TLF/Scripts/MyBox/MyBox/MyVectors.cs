using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace MyBox
{
	[PublicAPI]
	public static class MyVectors
	{
		public static Vector3 SetX(this Vector3 vector, float x)
		{
			return new Vector3(x, vector.y, vector.z);
		}

		public static Vector2 SetX(this Vector2 vector, float x)
		{
			return new Vector2(x, vector.y);
		}

		public static void SetX(this Transform transform, float x)
		{
			transform.position = transform.position.SetX(x);
		}

		public static Vector3 SetY(this Vector3 vector, float y)
		{
			return new Vector3(vector.x, y, vector.z);
		}

		public static Vector2 SetY(this Vector2 vector, float y)
		{
			return new Vector2(vector.x, y);
		}

		public static void SetY(this Transform transform, float y)
		{
			transform.position = transform.position.SetY(y);
		}

		public static Vector3 SetZ(this Vector3 vector, float z)
		{
			return new Vector3(vector.x, vector.y, z);
		}

		public static Vector3 WithZ(this Vector2 vector, float z)
		{
			return new Vector3(vector.x, vector.y, z);
		}

		public static void SetZ(this Transform transform, float z)
		{
			transform.position = transform.position.SetZ(z);
		}

		public static Vector3 SetXY(this Vector3 vector, float x, float y)
		{
			return new Vector3(x, y, vector.z);
		}

		public static Vector3 SetXY(this Vector3 vector, Vector2 xy)
		{
			return new Vector3(xy.x, xy.y, vector.z);
		}

		public static void SetXY(this Transform transform, float x, float y)
		{
			transform.position = transform.position.SetXY(x, y);
		}

		public static void SetXY(this Transform transform, Vector2 xy)
		{
			transform.position = transform.position.SetXY(xy);
		}

		public static Vector3 SetXZ(this Vector3 vector, float x, float z)
		{
			return new Vector3(x, vector.y, z);
		}

		public static Vector3 SetXZ(this Vector3 vector, Vector2 xz)
		{
			return new Vector3(xz.x, vector.y, xz.y);
		}

		public static void SetXZ(this Transform transform, float x, float z)
		{
			transform.position = transform.position.SetXZ(x, z);
		}

		public static void SetXZ(this Transform transform, Vector2 xz)
		{
			transform.position = transform.position.SetXZ(xz);
		}

		public static Vector3 SetYZ(this Vector3 vector, float y, float z)
		{
			return new Vector3(vector.x, y, z);
		}

		public static Vector3 SetYZ(this Vector3 vector, Vector2 yz)
		{
			return new Vector3(vector.x, yz.x, yz.y);
		}

		public static void SetYZ(this Transform transform, float y, float z)
		{
			transform.position = transform.position.SetYZ(y, z);
		}

		public static void SetYZ(this Transform transform, Vector2 yz)
		{
			transform.position = transform.position.SetYZ(yz);
		}

		public static Vector3 Offset(this Vector3 vector, Vector2 offset)
		{
			return vector.OffsetXY(offset);
		}

		public static Vector3 OffsetX(this Vector3 vector, float x)
		{
			return new Vector3(vector.x + x, vector.y, vector.z);
		}

		public static Vector2 OffsetX(this Vector2 vector, float x)
		{
			return new Vector2(vector.x + x, vector.y);
		}

		public static void OffsetX(this Transform transform, float x)
		{
			transform.position = transform.position.OffsetX(x);
		}

		public static Vector3 OffsetY(this Vector3 vector, float y)
		{
			return new Vector3(vector.x, vector.y + y, vector.z);
		}

		public static Vector2 OffsetY(this Vector2 vector, float y)
		{
			return new Vector2(vector.x, vector.y + y);
		}

		public static void OffsetY(this Transform transform, float y)
		{
			transform.position = transform.position.OffsetY(y);
		}

		public static Vector3 OffsetZ(this Vector3 vector, float z)
		{
			return new Vector3(vector.x, vector.y, vector.z + z);
		}

		public static void OffsetZ(this Transform transform, float z)
		{
			transform.position = transform.position.OffsetZ(z);
		}

		public static Vector3 OffsetXY(this Vector3 vector, float x, float y)
		{
			return new Vector3(vector.x + x, vector.y + y, vector.z);
		}

		public static Vector3 OffsetXY(this Vector3 vector, Vector2 offset)
		{
			return vector.OffsetXY(offset.x, offset.y);
		}

		public static Vector2 OffsetXY(this Vector2 vector, float x, float y)
		{
			return new Vector2(vector.x + x, vector.y + y);
		}

		public static void OffsetXY(this Transform transform, float x, float y)
		{
			transform.position = transform.position.OffsetXY(x, y);
		}

		public static void OffsetXY(this Transform transform, Vector2 offset)
		{
			transform.position = transform.position.OffsetXY(offset);
		}

		public static Vector3 OffsetXZ(this Vector3 vector, float x, float z)
		{
			return new Vector3(vector.x + x, vector.y, vector.z + z);
		}

		public static Vector3 OffsetXZ(this Vector3 vector, Vector2 offset)
		{
			return vector.OffsetXZ(offset.x, offset.y);
		}

		public static void OffsetXZ(this Transform transform, float x, float z)
		{
			transform.position = transform.position.OffsetXZ(x, z);
		}

		public static void OffsetXZ(this Transform transform, Vector2 offset)
		{
			transform.position = transform.position.OffsetXZ(offset);
		}

		public static Vector3 OffsetYZ(this Vector3 vector, float y, float z)
		{
			return new Vector3(vector.x, vector.y + y, vector.z + z);
		}

		public static Vector3 OffsetYZ(this Vector3 vector, Vector2 offset)
		{
			return vector.OffsetYZ(offset.x, offset.y);
		}

		public static void OffsetYZ(this Transform transform, float y, float z)
		{
			transform.position = transform.position.OffsetYZ(y, z);
		}

		public static void OffsetYZ(this Transform transform, Vector2 offset)
		{
			transform.position = transform.position.OffsetYZ(offset);
		}

		public static Vector3 ClampX(this Vector3 vector, float min, float max)
		{
			return vector.SetX(Mathf.Clamp(vector.x, min, max));
		}

		public static Vector2 ClampX(this Vector2 vector, float min, float max)
		{
			return vector.SetX(Mathf.Clamp(vector.x, min, max));
		}

		public static void ClampX(this Transform transform, float min, float max)
		{
			transform.SetX(Mathf.Clamp(transform.position.x, min, max));
		}

		public static Vector3 ClampY(this Vector3 vector, float min, float max)
		{
			return vector.SetY(Mathf.Clamp(vector.y, min, max));
		}

		public static Vector2 ClampY(this Vector2 vector, float min, float max)
		{
			return vector.SetY(Mathf.Clamp(vector.y, min, max));
		}

		public static void ClampY(this Transform transform, float min, float max)
		{
			transform.SetY(Mathf.Clamp(transform.position.y, min, max));
		}

		public static Vector3 ClampZ(this Vector3 vector, float min, float max)
		{
			return vector.SetZ(Mathf.Clamp(vector.z, min, max));
		}

		public static void ClampZ(this Transform transform, float min, float max)
		{
			transform.SetZ(Mathf.Clamp(transform.position.z, min, max));
		}

		public static Vector3 InvertX(this Vector3 vector)
		{
			return vector.SetX(0f - vector.x);
		}

		public static Vector2 InvertX(this Vector2 vector)
		{
			return vector.SetX(0f - vector.x);
		}

		public static void InvertX(this Transform transform)
		{
			transform.SetX(0f - transform.position.x);
		}

		public static Vector3 InvertY(this Vector3 vector)
		{
			return vector.SetY(0f - vector.y);
		}

		public static Vector2 InvertY(this Vector2 vector)
		{
			return vector.SetY(0f - vector.y);
		}

		public static void InvertY(this Transform transform)
		{
			transform.SetY(0f - transform.position.y);
		}

		public static Vector3 InvertZ(this Vector3 vector)
		{
			return vector.SetZ(0f - vector.z);
		}

		public static void InvertZ(this Transform transform)
		{
			transform.SetZ(0f - transform.position.z);
		}

		public static Vector2 ToVector2(this Vector3 vector)
		{
			return new Vector2(vector.x, vector.y);
		}

		public static Vector3 ToVector3(this Vector2 vector)
		{
			return new Vector3(vector.x, vector.y);
		}

		public static Vector2 ToVector2(this Vector2Int vector)
		{
			return new Vector2(vector.x, vector.y);
		}

		public static Vector3 ToVector3(this Vector3Int vector)
		{
			return new Vector3(vector.x, vector.y, vector.z);
		}

		public static Vector2Int ToVector2Int(this Vector2 vector)
		{
			return new Vector2Int(vector.x.RoundToInt(), vector.y.RoundToInt());
		}

		public static Vector3Int ToVector3Int(this Vector3 vector)
		{
			return new Vector3Int(vector.x.RoundToInt(), vector.y.RoundToInt(), vector.z.RoundToInt());
		}

		public static Vector3 SnapValue(this Vector3 val, float snapValue)
		{
			return new Vector3(val.x.Snap(snapValue), val.y.Snap(snapValue), val.z.Snap(snapValue));
		}

		public static Vector2 SnapValue(this Vector2 val, float snapValue)
		{
			return new Vector2(val.x.Snap(snapValue), val.y.Snap(snapValue));
		}

		public static void SnapPosition(this Transform transform, float snapValue)
		{
			transform.position = transform.position.SnapValue(snapValue);
		}

		public static Vector2 SnapToOne(this Vector2 vector)
		{
			return new Vector2(vector.x.Round(), vector.y.Round());
		}

		public static Vector3 SnapToOne(this Vector3 vector)
		{
			return new Vector3(vector.x.Round(), vector.y.Round(), vector.z.Round());
		}

		public static Vector3 AverageVector(this Vector3[] vectors)
		{
			if (vectors.IsNullOrEmpty())
			{
				return Vector3.zero;
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < vectors.Length; i++)
			{
				num += vectors[i].x;
				num2 += vectors[i].y;
				num3 += vectors[i].z;
			}
			return new Vector3(num / (float)vectors.Length, num2 / (float)vectors.Length, num3 / (float)vectors.Length);
		}

		public static Vector2 AverageVector(this Vector2[] vectors)
		{
			if (vectors.IsNullOrEmpty())
			{
				return Vector2.zero;
			}
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < vectors.Length; i++)
			{
				num += vectors[i].x;
				num2 += vectors[i].y;
			}
			return new Vector2(num / (float)vectors.Length, num2 / (float)vectors.Length);
		}

		public static bool Approximately(this Vector3 vector, Vector3 compared, float threshold = 0.1f)
		{
			float num = Mathf.Abs(vector.x - compared.x);
			float num2 = Mathf.Abs(vector.y - compared.y);
			float num3 = Mathf.Abs(vector.z - compared.z);
			if (num <= threshold && num2 <= threshold)
			{
				return num3 <= threshold;
			}
			return false;
		}

		public static bool Approximately(this Vector2 vector, Vector2 compared, float threshold = 0.1f)
		{
			float num = Mathf.Abs(vector.x - compared.x);
			float num2 = Mathf.Abs(vector.y - compared.y);
			if (num <= threshold)
			{
				return num2 <= threshold;
			}
			return false;
		}

		public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions)
		{
			Vector3 result = Vector3.zero;
			float num = float.PositiveInfinity;
			foreach (Vector3 otherPosition in otherPositions)
			{
				float sqrMagnitude = (position - otherPosition).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					result = otherPosition;
					num = sqrMagnitude;
				}
			}
			return result;
		}

		public static Vector3 GetClosest(this IEnumerable<Vector3> positions, Vector3 position)
		{
			return position.GetClosest(positions);
		}

		public static Vector4 To(this Vector4 source, Vector4 destination)
		{
			return destination - source;
		}

		public static Vector3 To(this Vector3 source, Vector3 destination)
		{
			return destination - source;
		}

		public static Vector2 To(this Vector2 source, Vector2 destination)
		{
			return destination - source;
		}

		public static Vector3 To(this Component source, Component target)
		{
			return source.transform.position.To(target.transform.position);
		}

		public static Vector3 To(this Component source, GameObject target)
		{
			return source.transform.position.To(target.transform.position);
		}

		public static Vector3 To(this GameObject source, Component target)
		{
			return source.transform.position.To(target.transform.position);
		}

		public static Vector3 To(this GameObject source, GameObject target)
		{
			return source.transform.position.To(target.transform.position);
		}

		public static Vector3 To(this Vector3 source, GameObject target)
		{
			return source.To(target.transform.position);
		}

		public static Vector3 To(this Vector3 source, Component target)
		{
			return source.To(target.transform.position);
		}

		public static Vector3 To(this GameObject source, Vector3 destination)
		{
			return source.transform.position.To(destination);
		}

		public static Vector3 To(this Component source, Vector3 destination)
		{
			return source.transform.position.To(destination);
		}

		public static Vector2 Pow(this Vector2 source, float exponent)
		{
			return new Vector2(Mathf.Pow(source.x, exponent), Mathf.Pow(source.y, exponent));
		}

		public static Vector3 Pow(this Vector3 source, float exponent)
		{
			return new Vector3(Mathf.Pow(source.x, exponent), Mathf.Pow(source.y, exponent), Mathf.Pow(source.z, exponent));
		}

		public static Vector4 Pow(this Vector4 source, float exponent)
		{
			return new Vector4(Mathf.Pow(source.x, exponent), Mathf.Pow(source.y, exponent), Mathf.Pow(source.z, exponent), Mathf.Pow(source.w, exponent));
		}

		public static Vector2 ScaleBy(this Vector2 source, Vector2 right)
		{
			return Vector2.Scale(source, right);
		}

		public static Vector3 ScaleBy(this Vector3 source, Vector3 right)
		{
			return Vector3.Scale(source, right);
		}

		public static Vector4 ScaleBy(this Vector4 source, Vector4 right)
		{
			return Vector4.Scale(source, right);
		}
	}
}
