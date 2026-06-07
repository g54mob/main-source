using UnityEngine;

public class Math3d : MonoBehaviour
{
	private static Transform tempChild;

	private static Transform tempParent;

	public static void Init()
	{
	}

	public static Vector3 AddVectorLength(Vector3 vector, float size)
	{
		return default(Vector3);
	}

	public static Vector3 SetVectorLength(Vector3 vector, float size)
	{
		return default(Vector3);
	}

	public static Quaternion SubtractRotation(Quaternion B, Quaternion A)
	{
		return default(Quaternion);
	}

	public static bool PlanePlaneIntersection(out Vector3 linePoint, out Vector3 lineVec, Vector3 plane1Normal, Vector3 plane1Position, Vector3 plane2Normal, Vector3 plane2Position)
	{
		linePoint = default(Vector3);
		lineVec = default(Vector3);
		return false;
	}

	public static bool LinePlaneIntersection(out Vector3 intersection, Vector3 linePoint, Vector3 lineVec, Vector3 planeNormal, Vector3 planePoint)
	{
		intersection = default(Vector3);
		return false;
	}

	public static bool LineLineIntersection(out Vector3 intersection, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
	{
		intersection = default(Vector3);
		return false;
	}

	public static bool ClosestPointsOnTwoLines(out Vector3 closestPointLine1, out Vector3 closestPointLine2, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
	{
		closestPointLine1 = default(Vector3);
		closestPointLine2 = default(Vector3);
		return false;
	}

	public static Vector3 ProjectPointOnLine(Vector3 linePoint, Vector3 lineVec, Vector3 point)
	{
		return default(Vector3);
	}

	public static Vector3 ProjectPointOnLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		return default(Vector3);
	}

	public static Vector3 ProjectPointOnPlane(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		return default(Vector3);
	}

	public static Vector3 ProjectVectorOnPlane(Vector3 planeNormal, Vector3 vector)
	{
		return default(Vector3);
	}

	public static float SignedDistancePlanePoint(Vector3 planeNormal, Vector3 planePoint, Vector3 point)
	{
		return 0f;
	}

	public static float SignedDotProduct(Vector3 vectorA, Vector3 vectorB, Vector3 normal)
	{
		return 0f;
	}

	public static float SignedVectorAngle(Vector3 referenceVector, Vector3 otherVector, Vector3 normal)
	{
		return 0f;
	}

	public static float AngleVectorPlane(Vector3 vector, Vector3 normal)
	{
		return 0f;
	}

	public static float DotProductAngle(Vector3 vec1, Vector3 vec2)
	{
		return 0f;
	}

	public static void PlaneFrom3Points(out Vector3 planeNormal, out Vector3 planePoint, Vector3 pointA, Vector3 pointB, Vector3 pointC)
	{
		planeNormal = default(Vector3);
		planePoint = default(Vector3);
	}

	public static Vector3 GetForwardVector(Quaternion q)
	{
		return default(Vector3);
	}

	public static Vector3 GetUpVector(Quaternion q)
	{
		return default(Vector3);
	}

	public static Vector3 GetRightVector(Quaternion q)
	{
		return default(Vector3);
	}

	public static Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		return default(Quaternion);
	}

	public static Vector3 PositionFromMatrix(Matrix4x4 m)
	{
		return default(Vector3);
	}

	public static void LookRotationExtended(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 customForward, Vector3 customUp)
	{
	}

	public static void TransformWithParent(out Quaternion childRotation, out Vector3 childPosition, Quaternion parentRotation, Vector3 parentPosition, Quaternion startParentRotation, Vector3 startParentPosition, Quaternion startChildRotation, Vector3 startChildPosition)
	{
		childRotation = default(Quaternion);
		childPosition = default(Vector3);
	}

	public static void PreciseAlign(ref GameObject gameObjectInOut, Vector3 alignWithVector, Vector3 alignWithNormal, Vector3 alignWithPosition, Vector3 triangleForward, Vector3 triangleNormal, Vector3 trianglePosition)
	{
	}

	private void VectorsToTransform(ref GameObject gameObjectInOut, Vector3 positionVector, Vector3 directionVector, Vector3 normalVector)
	{
	}

	public static int PointOnWhichSideOfLineSegment(Vector3 linePoint1, Vector3 linePoint2, Vector3 point)
	{
		return 0;
	}

	public static float MouseDistanceToLine(Vector3 linePoint1, Vector3 linePoint2)
	{
		return 0f;
	}

	public static float MouseDistanceToCircle(Vector3 point, float radius)
	{
		return 0f;
	}

	public static bool IsLineInRectangle(Vector3 linePoint1, Vector3 linePoint2, Vector3 rectA, Vector3 rectB, Vector3 rectC, Vector3 rectD)
	{
		return false;
	}

	public static bool IsPointInRectangle(Vector3 point, Vector3 rectA, Vector3 rectC, Vector3 rectB, Vector3 rectD)
	{
		return false;
	}

	public static bool AreLineSegmentsCrossing(Vector3 pointA1, Vector3 pointA2, Vector3 pointB1, Vector3 pointB2)
	{
		return false;
	}
}
