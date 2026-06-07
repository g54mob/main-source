using System;
using UnityEngine;

public class Math3d : MonoBehaviour
{
	private static Transform tempChild;

	private static Transform tempParent;

	public static Vector3d AddVectorLength(Vector3d vector, double size)
	{
		double num = Vector3d.Magnitude(vector);
		num += size;
		return Vector3d.Scale(Vector3d.Normalize(vector), new Vector3d(num, num, num));
	}

	public static double AngleVectorPlane(Vector3d vector, Vector3d normal)
	{
		double num = Math.Acos(Vector3d.Dot(vector, normal));
		return 1.5707963705062866 - num;
	}

	public static bool AreLineSegmentsCrossing(Vector3d pointA1, Vector3d pointA2, Vector3d pointB1, Vector3d pointB2)
	{
		Vector3d vector3d = pointA2 - pointA1;
		Vector3d vector3d2 = pointB2 - pointB1;
		if (ClosestPointsOnTwoLines(out var closestPointLine, out var closestPointLine2, pointA1, vector3d.normalized, pointB1, vector3d2.normalized))
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

	public static bool ClosestPointsOnTwoLines(out Vector3d closestPointLine1, out Vector3d closestPointLine2, Vector3d linePoint1, Vector3d lineVec1, Vector3d linePoint2, Vector3d lineVec2)
	{
		closestPointLine1 = Vector3d.zero;
		closestPointLine2 = Vector3d.zero;
		double num = Vector3d.Dot(lineVec1, lineVec1);
		double num2 = Vector3d.Dot(lineVec1, lineVec2);
		double num3 = Vector3d.Dot(lineVec2, lineVec2);
		double num4 = num * num3 - num2 * num2;
		if (num4 != 0.0)
		{
			Vector3d rhs = linePoint1 - linePoint2;
			double num5 = Vector3d.Dot(lineVec1, rhs);
			double num6 = Vector3d.Dot(lineVec2, rhs);
			double num7 = (num2 * num6 - num5 * num3) / num4;
			double num8 = (num * num6 - num5 * num2) / num4;
			closestPointLine1 = linePoint1 + lineVec1 * num7;
			closestPointLine2 = linePoint2 + lineVec2 * num8;
			return true;
		}
		return false;
	}

	public static double DotProductAngle(Vector3d vec1, Vector3d vec2)
	{
		double num = Vector3d.Dot(vec1, vec2);
		if (num < -1.0)
		{
			num = -1.0;
		}
		if (num > 1.0)
		{
			num = 1.0;
		}
		return Math.Acos(num);
	}

	public static Vector3d GetForwardVector(Quaterniond q)
	{
		return q * Vector3d.forward;
	}

	public static Vector3d GetRightVector(Quaterniond q)
	{
		return q * Vector3d.right;
	}

	public static Vector3d GetUpVector(Quaterniond q)
	{
		return q * Vector3d.up;
	}

	public static void Init()
	{
		tempChild = new GameObject("Math3d_TempChild").transform;
		tempParent = new GameObject("Math3d_TempParent").transform;
		tempChild.gameObject.hideFlags = HideFlags.HideAndDontSave;
		UnityEngine.Object.DontDestroyOnLoad(tempChild.gameObject);
		tempParent.gameObject.hideFlags = HideFlags.HideAndDontSave;
		UnityEngine.Object.DontDestroyOnLoad(tempParent.gameObject);
		tempChild.parent = tempParent;
	}

	public static bool IsLineInRectangle(Vector3d linePoint1, Vector3d linePoint2, Vector3d rectA, Vector3d rectB, Vector3d rectC, Vector3d rectD)
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

	public static bool IsPointInRectangle(Vector3d point, Vector3d rectA, Vector3d rectC, Vector3d rectB, Vector3d rectD)
	{
		Vector3d vector = rectC - rectA;
		double size = 0.0 - vector.magnitude / 2.0;
		vector = AddVectorLength(vector, size);
		Vector3d linePoint = rectA + vector;
		Vector3d vector3d = rectB - rectA;
		double num = vector3d.magnitude / 2.0;
		Vector3d vector3d2 = rectD - rectA;
		double num2 = vector3d2.magnitude / 2.0;
		double magnitude = (ProjectPointOnLine(linePoint, vector3d.normalized, point) - point).magnitude;
		if ((ProjectPointOnLine(linePoint, vector3d2.normalized, point) - point).magnitude <= num && magnitude <= num2)
		{
			return true;
		}
		return false;
	}

	public static bool LineLineIntersection(out Vector3d intersection, Vector3d linePoint1, Vector3d lineVec1, Vector3d linePoint2, Vector3d lineVec2)
	{
		intersection = Vector3d.zero;
		Vector3d lhs = linePoint2 - linePoint1;
		Vector3d rhs = Vector3d.Cross(lineVec1, lineVec2);
		Vector3d lhs2 = Vector3d.Cross(lhs, lineVec2);
		double num = Vector3d.Dot(lhs, rhs);
		if (num >= 9.999999747378752E-06 || num <= -9.999999747378752E-06)
		{
			return false;
		}
		double num2 = Vector3d.Dot(lhs2, rhs) / rhs.sqrMagnitude;
		if (num2 >= 0.0 && num2 <= 1.0)
		{
			intersection = linePoint1 + lineVec1 * num2;
			return true;
		}
		return false;
	}

	public static bool LinePlaneIntersection(out Vector3d intersection, Vector3d linePoint, Vector3d lineVec, Vector3d planeNormal, Vector3d planePoint)
	{
		intersection = Vector3d.zero;
		double num = Vector3d.Dot(planePoint - linePoint, planeNormal);
		double num2 = Vector3d.Dot(lineVec, planeNormal);
		if (num2 != 0.0)
		{
			double size = num / num2;
			Vector3d vector3d = SetVectorLength(lineVec, size);
			intersection = linePoint + vector3d;
			return true;
		}
		return false;
	}

	public static void LookRotationExtended(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 customForward, Vector3 customUp)
	{
		Quaternion quaternion = Quaternion.LookRotation(alignWithVector, alignWithNormal);
		Quaternion rotation = Quaternion.LookRotation(customForward, customUp);
		gameObjectInOut.transform.rotation = quaternion * Quaternion.Inverse(rotation);
	}

	public static double MouseDistanceToCircle(Vector3 point, double radius)
	{
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = main.WorldToScreenPoint(point);
		vector = new Vector3(vector.x, vector.y, 0f);
		return (double)(vector - mousePosition).magnitude - radius;
	}

	public static double MouseDistanceToLine(Vector3 linePoint1, Vector3 linePoint2)
	{
		Camera main = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 vector = main.WorldToScreenPoint(linePoint1);
		Vector3 vector2 = main.WorldToScreenPoint(linePoint2);
		Vector3 vector3 = (Vector3)ProjectPointOnLineSegment(vector, vector2, mousePosition);
		vector3 = new Vector3(vector3.x, vector3.y, 0f);
		return (vector3 - mousePosition).magnitude;
	}

	public static void PlaneFrom3Points(out Vector3d planeNormal, out Vector3d planePoint, Vector3d pointA, Vector3d pointB, Vector3d pointC)
	{
		planeNormal = Vector3d.zero;
		planePoint = Vector3d.zero;
		Vector3d vector3d = pointB - pointA;
		Vector3d vector3d2 = pointC - pointA;
		planeNormal = Vector3d.Normalize(Vector3d.Cross(vector3d, vector3d2));
		Vector3d vector3d3 = pointA + vector3d / 2.0;
		Vector3d vector3d4 = pointA + vector3d2 / 2.0;
		Vector3d lineVec = pointC - vector3d3;
		Vector3d lineVec2 = pointB - vector3d4;
		ClosestPointsOnTwoLines(out planePoint, out var _, vector3d3, lineVec, vector3d4, lineVec2);
	}

	public static bool PlanePlaneIntersection(out Vector3d linePoint, out Vector3d lineVec, Vector3d plane1Normal, Vector3d plane1Position, Vector3d plane2Normal, Vector3d plane2Position)
	{
		linePoint = Vector3d.zero;
		lineVec = Vector3d.zero;
		lineVec = Vector3d.Cross(plane1Normal, plane2Normal);
		Vector3d vector3d = Vector3d.Cross(plane2Normal, lineVec);
		double num = Vector3d.Dot(plane1Normal, vector3d);
		if (Mathd.Abs(num) > 0.006000000052154064)
		{
			Vector3d rhs = plane1Position - plane2Position;
			double num2 = Vector3d.Dot(plane1Normal, rhs) / num;
			linePoint = plane2Position + num2 * vector3d;
			return true;
		}
		return false;
	}

	public static bool RayPlaneIntersection(out Vector3d intersection, Vector3d rayOrigin, Vector3d rayDirection, Vector3d planeNormal, Vector3d planePoint)
	{
		bool flag = LinePlaneIntersection(out intersection, rayOrigin, rayDirection, planeNormal, planePoint);
		if (flag && Vector3d.Dot(rayDirection, intersection - rayOrigin) < 0.0)
		{
			flag = false;
		}
		return flag;
	}

	public static int PointOnWhichSideOfLineSegment(Vector3d linePoint1, Vector3d linePoint2, Vector3d point)
	{
		Vector3d rhs = linePoint2 - linePoint1;
		Vector3d lhs = point - linePoint1;
		if (Vector3d.Dot(lhs, rhs) > 0.0)
		{
			if (lhs.magnitude <= rhs.magnitude)
			{
				return 0;
			}
			return 2;
		}
		return 1;
	}

	public static Vector3d PositionFromMatrix(Matrix4x4 m)
	{
		Vector4 column = m.GetColumn(3);
		return new Vector3d(column.x, column.y, column.z);
	}

	public static void PreciseAlign(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 alignWithPosition, Vector3 triangleForward, Vector3 triangleNormal, Vector3 trianglePosition)
	{
		LookRotationExtended(ref gameObjectInOut, alignWithVector, alignWithNormal, triangleForward, triangleNormal);
		Vector3 vector = gameObjectInOut.transform.TransformPoint(trianglePosition);
		Vector3 translation = alignWithPosition - vector;
		gameObjectInOut.transform.Translate(translation, Space.World);
	}

	public static Vector3d ProjectPointOnLine(Vector3d linePoint, Vector3d lineVec, Vector3d point)
	{
		double num = Vector3d.Dot(point - linePoint, lineVec);
		return linePoint + lineVec * num;
	}

	public static Vector3d ProjectPointOnLineSegment(Vector3d linePoint1, Vector3d linePoint2, Vector3d point)
	{
		Vector3d vector3d = ProjectPointOnLine(linePoint1, (linePoint2 - linePoint1).normalized, point);
		return PointOnWhichSideOfLineSegment(linePoint1, linePoint2, vector3d) switch
		{
			0 => vector3d, 
			1 => linePoint1, 
			2 => linePoint2, 
			_ => Vector3d.zero, 
		};
	}

	public static Vector3 ProjectPointOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		float num = SignedDistancePlanePoint(planeNormal, planePoint, point);
		num *= -1f;
		Vector3 vector = SetVectorLength(planeNormal, num);
		return point + vector;
	}

	public static Vector3d ProjectPointOnPlane(Vector3d planeNormal, Vector3d planePoint, Vector3d point)
	{
		double num = SignedDistancePlanePoint(planeNormal, planePoint, point);
		num *= -1.0;
		Vector3d vector3d = SetVectorLength(planeNormal, num);
		return point + vector3d;
	}

	public static Vector3d ProjectVectorOnPlane(Vector3d planeNormal, Vector3d vector)
	{
		return vector - Vector3d.Dot(vector, planeNormal) * planeNormal;
	}

	public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		return Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));
	}

	public static Vector3 SetVectorLength(Vector3 vector, float size)
	{
		return Vector3.Normalize(vector) * size;
	}

	public static Vector3d SetVectorLength(Vector3d vector, double size)
	{
		return Vector3d.Normalize(vector) * size;
	}

	public static double SignedDistancePlanePoint(Vector3d planeNormal, Vector3d planePoint, Vector3d point)
	{
		return Vector3d.Dot(planeNormal, point - planePoint);
	}

	public static float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		return Vector3.Dot(planeNormal, point - planePoint);
	}

	public static double SignedDotProduct(Vector3d vectorA, Vector3d vectorB, Vector3d normal)
	{
		return Vector3d.Dot(Vector3d.Cross(normal, vectorA), vectorB);
	}

	public static double SignedVectorAngle(Vector3d referenceVector, Vector3d otherVector, Vector3d normal)
	{
		Vector3d lhs = Vector3d.Cross(normal, referenceVector);
		return Vector3d.Angle(referenceVector, otherVector) * Mathd.Sign(Vector3d.Dot(lhs, otherVector));
	}

	public static Quaternion SubtractRotation(Quaternion B, Quaternion A)
	{
		return Quaternion.Inverse(A) * B;
	}

	public static void TransformWithParent(out Quaternion childRotation, out Vector3 childPosition, Quaternion parentRotation, Vector3 parentPosition, Quaternion startParentRotation, Vector3 startParentPosition, Quaternion startChildRotation, Vector3 startChildPosition)
	{
		childRotation = Quaternion.identity;
		childPosition = Vector3.zero;
		tempParent.rotation = startParentRotation;
		tempParent.position = startParentPosition;
		tempParent.localScale = Vector3.one;
		tempChild.rotation = startChildRotation;
		tempChild.position = startChildPosition;
		tempChild.localScale = Vector3.one;
		tempParent.rotation = parentRotation;
		tempParent.position = parentPosition;
		childRotation = tempChild.rotation;
		childPosition = tempChild.position;
	}

	private void VectorsToTransform(ref GameObject gameObjectInOut, Vector3 positionVector, Vector3 directionVector, Vector3 normalVector)
	{
		gameObjectInOut.transform.position = positionVector;
		gameObjectInOut.transform.rotation = Quaternion.LookRotation(directionVector, normalVector);
	}
}
