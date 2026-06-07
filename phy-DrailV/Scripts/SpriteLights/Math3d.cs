using System;
using UnityEngine;

public class Math3d : MonoBehaviour
{
	private static Transform tempChild;

	private static Transform tempParent;

	private static void Init()
	{
		tempChild = new GameObject("Math3d_TempChild").transform;
		tempParent = new GameObject("Math3d_TempParent").transform;
		tempChild.gameObject.hideFlags = HideFlags.HideAndDontSave;
		UnityEngine.Object.DontDestroyOnLoad(tempChild.gameObject);
		tempParent.gameObject.hideFlags = HideFlags.HideAndDontSave;
		UnityEngine.Object.DontDestroyOnLoad(tempParent.gameObject);
		tempChild.parent = tempParent;
	}

	public static float LinearFunction(float x, float Px, float Py, float Qx, float Qy)
	{
		float num = Qy - Py;
		float num2 = Qx - Px;
		float num3 = num / num2;
		return Py + num3 * (x - Px);
	}

	public static float NormalizeComplex(float input, float lowest, float highest)
	{
		return (input - lowest) / (highest - lowest);
	}

	public static float NormalizeSimple(float input, float highest)
	{
		return input / highest;
	}

	public static float NormalizeInvert(float input)
	{
		return 0f - input + 1f;
	}

	public static Vector3 AddVectorLength(Vector3 vector, float size)
	{
		float num = Vector3.Magnitude(vector);
		num += size;
		return Vector3.Scale(Vector3.Normalize(vector), new Vector3(num, num, num));
	}

	public static Vector3 SetVectorLength(Vector3 vector, float size)
	{
		return Vector3.Normalize(vector) * size;
	}

	public static Quaternion SubtractRotation(Quaternion B, Quaternion A)
	{
		return Quaternion.Inverse(A) * B;
	}

	public static Quaternion AddRotation(Quaternion A, Quaternion B)
	{
		return A * B;
	}

	public static Vector3 TransformDirectionMath(Quaternion rotation, Vector3 vector)
	{
		return rotation * vector;
	}

	public static Vector3 InverseTransformDirectionMath(Quaternion rotation, Vector3 vector)
	{
		return Quaternion.Inverse(rotation) * vector;
	}

	public static Vector3 RotateVectorFromTo(Quaternion from, Quaternion to, Vector3 vector)
	{
		Quaternion quaternion = SubtractRotation(to, from);
		Vector3 vector2 = InverseTransformDirectionMath(from, vector);
		Vector3 vector3 = quaternion * vector2;
		return TransformDirectionMath(from, vector3);
	}

	public static bool PlanePlaneIntersection(out Vector3 linePoint, out Vector3 lineVec, Vector3 plane1Normal, Vector3 plane1Position, Vector3 plane2Normal, Vector3 plane2Position)
	{
		linePoint = Vector3.zero;
		lineVec = Vector3.zero;
		lineVec = Vector3.Cross(plane1Normal, plane2Normal);
		Vector3 vector = Vector3.Cross(plane2Normal, lineVec);
		float num = Vector3.Dot(plane1Normal, vector);
		if (Mathf.Abs(num) > 0.006f)
		{
			Vector3 rhs = plane1Position - plane2Position;
			float num2 = Vector3.Dot(plane1Normal, rhs) / num;
			linePoint = plane2Position + num2 * vector;
			return true;
		}
		return false;
	}

	public static bool LinePlaneIntersection(out Vector3 intersection, Vector3 linePoint, Vector3 lineVec, Vector3 planeNormal, Vector3 planePoint)
	{
		intersection = Vector3.zero;
		float num = Vector3.Dot(planePoint - linePoint, planeNormal);
		float num2 = Vector3.Dot(lineVec, planeNormal);
		if (num2 != 0f)
		{
			float size = num / num2;
			Vector3 vector = SetVectorLength(lineVec, size);
			intersection = linePoint + vector;
			return true;
		}
		return false;
	}

	public static bool LineLineIntersection(out Vector3 intersection, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
	{
		intersection = Vector3.zero;
		Vector3 lhs = linePoint2 - linePoint1;
		Vector3 rhs = Vector3.Cross(lineVec1, lineVec2);
		Vector3 lhs2 = Vector3.Cross(lhs, lineVec2);
		float num = Vector3.Dot(lhs, rhs);
		if (num >= 1E-05f || num <= -1E-05f)
		{
			return false;
		}
		float num2 = Vector3.Dot(lhs2, rhs) / rhs.sqrMagnitude;
		if (num2 >= 0f && num2 <= 1f)
		{
			intersection = linePoint1 + lineVec1 * num2;
			return true;
		}
		return false;
	}

	public static bool ClosestPointsOnTwoLines(out Vector3 closestPointLine1, out Vector3 closestPointLine2, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
	{
		closestPointLine1 = Vector3.zero;
		closestPointLine2 = Vector3.zero;
		float num = Vector3.Dot(lineVec1, lineVec1);
		float num2 = Vector3.Dot(lineVec1, lineVec2);
		float num3 = Vector3.Dot(lineVec2, lineVec2);
		float num4 = num * num3 - num2 * num2;
		if (num4 != 0f)
		{
			Vector3 rhs = linePoint1 - linePoint2;
			float num5 = Vector3.Dot(lineVec1, rhs);
			float num6 = Vector3.Dot(lineVec2, rhs);
			float num7 = (num2 * num6 - num5 * num3) / num4;
			float num8 = (num * num6 - num5 * num2) / num4;
			closestPointLine1 = linePoint1 + lineVec1 * num7;
			closestPointLine2 = linePoint2 + lineVec2 * num8;
			return true;
		}
		return false;
	}

	public static Vector3 ProjectPointOnLine(Vector3 linePoint, Vector3 lineVec, Vector3 point)
	{
		float num = Vector3.Dot(point - linePoint, lineVec);
		return linePoint + lineVec * num;
	}

	public static Vector3 ProjectPointOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		float num = SignedDistancePlanePoint(planeNormal, planePoint, point);
		num *= -1f;
		Vector3 vector = SetVectorLength(planeNormal, num);
		return point + vector;
	}

	public static Vector3 ProjectVectorOnPlane(Vector3 planeNormal, Vector3 vector)
	{
		return vector - Vector3.Dot(vector, planeNormal) * planeNormal;
	}

	public static float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		return Vector3.Dot(planeNormal, point - planePoint);
	}

	public static float SignedDotProduct(Vector3 vectorA, Vector3 vectorB, Vector3 normal)
	{
		return Vector3.Dot(Vector3.Cross(normal, vectorA), vectorB);
	}

	public static float AngleVectorPlane(Vector3 vector, Vector3 normal)
	{
		float num = (float)Math.Acos(Vector3.Dot(vector, normal));
		return (float)Math.PI / 2f - num;
	}

	public static float DotProductAngle(Vector3 vec1, Vector3 vec2)
	{
		double num = Vector3.Dot(vec1, vec2);
		if (num < -1.0)
		{
			num = -1.0;
		}
		if (num > 1.0)
		{
			num = 1.0;
		}
		return (float)Math.Acos(num);
	}

	public static void PlaneFrom3Points(out Vector3 planeNormal, out Vector3 planePoint, Vector3 pointA, Vector3 pointB, Vector3 pointC)
	{
		planeNormal = Vector3.zero;
		planePoint = Vector3.zero;
		Vector3 vector = pointB - pointA;
		Vector3 vector2 = pointC - pointA;
		planeNormal = Vector3.Normalize(Vector3.Cross(vector, vector2));
		Vector3 vector3 = pointA + vector / 2f;
		Vector3 vector4 = pointA + vector2 / 2f;
		Vector3 lineVec = pointC - vector3;
		Vector3 lineVec2 = pointB - vector4;
		ClosestPointsOnTwoLines(out planePoint, out var _, vector3, lineVec, vector4, lineVec2);
	}

	public static Vector3 GetForwardVector(Quaternion q)
	{
		return q * Vector3.forward;
	}

	public static Vector3 GetUpVector(Quaternion q)
	{
		return q * Vector3.up;
	}

	public static Vector3 GetRightVector(Quaternion q)
	{
		return q * Vector3.right;
	}

	public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		return Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));
	}

	public static Vector3 PositionFromMatrix(Matrix4x4 m)
	{
		Vector4 column = m.GetColumn(3);
		return new Vector3(column.x, column.y, column.z);
	}

	public static void LookRotationExtended(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 customForward, Vector3 customUp)
	{
		Quaternion quaternion = Quaternion.LookRotation(alignWithVector, alignWithNormal);
		Quaternion rotation = Quaternion.LookRotation(customForward, customUp);
		gameObjectInOut.transform.rotation = quaternion * Quaternion.Inverse(rotation);
	}

	public static void TransformWithParent(out Quaternion childRotation, out Vector3 childPosition, Quaternion parentRotation, Vector3 parentPosition, Quaternion startParentRotation, Vector3 startParentPosition, Quaternion startChildRotation, Vector3 startChildPosition)
	{
		childRotation = Quaternion.identity;
		childPosition = Vector3.zero;
		if (tempParent == null)
		{
			Init();
		}
		tempParent.transform.rotation = startParentRotation;
		tempParent.transform.position = startParentPosition;
		tempParent.transform.localScale = Vector3.one;
		tempChild.transform.rotation = startChildRotation;
		tempChild.transform.position = startChildPosition;
		tempChild.transform.localScale = Vector3.one;
		tempParent.transform.rotation = parentRotation;
		tempParent.transform.position = parentPosition;
		childRotation = tempChild.transform.rotation;
		childPosition = tempChild.transform.position;
	}

	public static void PreciseAlign(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 alignWithPosition, Vector3 triangleDirection, Vector3 triangleNormal, Vector3 trianglePosition)
	{
		LookRotationExtended(ref gameObjectInOut, alignWithVector, alignWithNormal, triangleDirection, triangleNormal);
		Vector3 vector = gameObjectInOut.transform.TransformPoint(trianglePosition);
		Vector3 translation = alignWithPosition - vector;
		gameObjectInOut.transform.Translate(translation, Space.World);
	}

	public static Vector4 QuaternionToVector4(Quaternion q)
	{
		return new Vector4(q.x, q.y, q.z, q.w);
	}

	public static Quaternion Vector4ToQuaternion(Vector4 v)
	{
		return new Quaternion(v.x, v.y, v.z, v.w);
	}

	public static Quaternion NormalizeQuaternion(float x, float y, float z, float w)
	{
		float num = 1f / (w * w + x * x + y * y + z * z);
		w *= num;
		x *= num;
		y *= num;
		z *= num;
		return new Quaternion(x, y, z, w);
	}

	public static Quaternion InverseSignQuaternion(Quaternion q)
	{
		return new Quaternion(0f - q.x, 0f - q.y, 0f - q.z, 0f - q.w);
	}

	public static bool AreQuaternionsClose(Quaternion q1, Quaternion q2)
	{
		if (Quaternion.Dot(q1, q2) < 0f)
		{
			return false;
		}
		return true;
	}

	public static Quaternion AverageQuaternion(ref Vector4 cumulative, Quaternion newRotation, Quaternion firstRotation, int addAmount)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		if (!AreQuaternionsClose(newRotation, firstRotation))
		{
			newRotation = InverseSignQuaternion(newRotation);
		}
		float num4 = 1f / (float)addAmount;
		cumulative.w += newRotation.w;
		num = cumulative.w * num4;
		cumulative.x += newRotation.x;
		float x = cumulative.x * num4;
		cumulative.y += newRotation.y;
		num2 = cumulative.y * num4;
		cumulative.z += newRotation.z;
		num3 = cumulative.z * num4;
		return NormalizeQuaternion(x, num2, num3, num);
	}

	public static Quaternion VectorsToQuaternion(Vector3 direction, Vector3 normal)
	{
		return Quaternion.LookRotation(direction, normal);
	}

	public static Vector3[] PointsToSpace(Vector3[] points, GameObject referenceObject, Space space)
	{
		Vector3[] array = new Vector3[points.Length];
		if (space == Space.Self)
		{
			for (int i = 0; i < points.Length; i++)
			{
				array[i] = referenceObject.transform.InverseTransformPoint(points[i]);
			}
		}
		if (space == Space.World)
		{
			for (int j = 0; j < points.Length; j++)
			{
				array[j] = referenceObject.transform.TransformPoint(points[j]);
			}
		}
		return array;
	}

	public static int PointOnWhichSideOfLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		Vector3 rhs = linePoint2 - linePoint1;
		Vector3 lhs = point - linePoint1;
		if (Vector3.Dot(lhs, rhs) > 0f)
		{
			if (lhs.magnitude <= rhs.magnitude)
			{
				return 0;
			}
			return 2;
		}
		return 1;
	}

	public static bool IsLineInRectangle(Vector3 linePoint1, Vector3 linePoint2, Vector3 rectA, Vector3 rectB, Vector3 rectC, Vector3 rectD)
	{
		bool flag = false;
		bool num = IsPointInRectangle(linePoint1, rectA, rectC, rectB, rectD);
		if (!num)
		{
			flag = IsPointInRectangle(linePoint2, rectA, rectC, rectB, rectD);
		}
		if (!num && !flag)
		{
			bool num2 = AreLineSegmentsCrossing(linePoint1, linePoint2, rectA, rectB);
			bool flag2 = AreLineSegmentsCrossing(linePoint1, linePoint2, rectB, rectC);
			bool flag3 = AreLineSegmentsCrossing(linePoint1, linePoint2, rectC, rectD);
			bool flag4 = AreLineSegmentsCrossing(linePoint1, linePoint2, rectD, rectA);
			if (num2 || flag2 || flag3 || flag4)
			{
				return true;
			}
			return false;
		}
		return true;
	}

	public static bool IsPointInRectangle(Vector3 point, Vector3 rectA, Vector3 rectC, Vector3 rectB, Vector3 rectD)
	{
		Vector3 vector = rectC - rectA;
		float size = 0f - vector.magnitude / 2f;
		vector = AddVectorLength(vector, size);
		Vector3 linePoint = rectA + vector;
		Vector3 vector2 = rectB - rectA;
		float num = vector2.magnitude / 2f;
		Vector3 vector3 = rectD - rectA;
		float num2 = vector3.magnitude / 2f;
		float magnitude = (ProjectPointOnLine(linePoint, vector2.normalized, point) - point).magnitude;
		if ((ProjectPointOnLine(linePoint, vector3.normalized, point) - point).magnitude <= num && magnitude <= num2)
		{
			return true;
		}
		return false;
	}

	public static bool AreLineSegmentsCrossing(Vector3 pointA1, Vector3 pointA2, Vector3 pointB1, Vector3 pointB2)
	{
		Vector3 vector = pointA2 - pointA1;
		Vector3 vector2 = pointB2 - pointB1;
		if (ClosestPointsOnTwoLines(out var closestPointLine, out var closestPointLine2, pointA1, vector.normalized, pointB1, vector2.normalized))
		{
			int num = PointOnWhichSideOfLineSegment(pointA1, pointA2, closestPointLine);
			int num2 = PointOnWhichSideOfLineSegment(pointB1, pointB2, closestPointLine2);
			if (num == 0 && num2 == 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public static Vector3 ProjectPointOnLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		Vector3 vector = ProjectPointOnLine(linePoint1, (linePoint2 - linePoint1).normalized, point);
		switch (PointOnWhichSideOfLineSegment(linePoint1, linePoint2, vector))
		{
		case 0:
			return vector;
		case 1:
			return linePoint1;
		case 2:
			return linePoint2;
		default:
			return Vector3.zero;
		}
	}

	public static Vector3 GetThirdVector(Vector3 A, Vector3 B)
	{
		return Vector3.Cross(A, B);
	}

	public static float MouseDistanceToLine(Vector3 linePoint1, Vector3 linePoint2)
	{
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 linePoint3 = main.WorldToScreenPoint(linePoint1);
		Vector3 linePoint4 = main.WorldToScreenPoint(linePoint2);
		Vector3 vector = ProjectPointOnLineSegment(linePoint3, linePoint4, mousePosition);
		vector = new Vector3(vector.x, vector.y, 0f);
		return (vector - mousePosition).magnitude;
	}

	public static float MouseDistanceToCircle(Vector3 point, float radius)
	{
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = main.WorldToScreenPoint(point);
		vector = new Vector3(vector.x, vector.y, 0f);
		return (vector - mousePosition).magnitude - radius;
	}
}
