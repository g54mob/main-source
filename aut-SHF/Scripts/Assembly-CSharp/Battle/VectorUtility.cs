using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class VectorUtility
	{
		public static float GetAngle(Vector2 start, Vector2 target)
		{
			return 0f;
		}

		public static float GetEllipseAngle(Vector2 start, Vector2 target, Vector2 radius)
		{
			return 0f;
		}

		public static Vector2 GetRandomPositionInSquare(Vector2 topRightPosition, Vector2 bottomLeftPosition)
		{
			return default(Vector2);
		}

		public static Vector2 GetNormalVectorByDirection(eSpawnDirection _direction)
		{
			return default(Vector2);
		}

		public static Vector2 GetRotationSallyPosition(Vector2 position, float offsetRotation)
		{
			return default(Vector2);
		}

		public static Vector2 GetDirectionVectorNormalized(Vector2 target, Vector2 nowPosition)
		{
			return default(Vector2);
		}

		public static Vector3 GetDirectionVectorNormalized(Vector3 target, Vector3 nowPosition)
		{
			return default(Vector3);
		}

		public static bool CheckArrivedPosition(Vector2 target, Vector2 nowPosition)
		{
			return false;
		}

		public static bool CheckArrivedPosition(Vector2 target, Vector2 nowPosition, float radius)
		{
			return false;
		}

		public static bool CheckExitCircle(Vector2 origin, Vector2 now, float radius)
		{
			return false;
		}

		public static Vector3 CalcQuadraticBezierCurve(Vector3 start, Vector3 end, Vector3 control, float t)
		{
			return default(Vector3);
		}

		public static List<Vector2> ChangeToLocalPosition(Transform targetTransform, List<Vector3> positions)
		{
			return null;
		}

		public static float GetNormalizedAngle(float angle, float min, float max)
		{
			return 0f;
		}

		public static float[] GetSplitAngles(int splitCount, int[] baseAngles)
		{
			return null;
		}

		public static bool CircleCollisoin(Vector3 p1, Vector3 p2, float r1, float r2)
		{
			return false;
		}

		public static List<Vector3> CalcFanDir(Vector3 centerDir, int value, float angle)
		{
			return null;
		}

		public static int GetStepIndex(int step, int idx)
		{
			return 0;
		}

		public static Vector3 GetCirclePoint(float degree, float radius)
		{
			return default(Vector3);
		}

		public static Vector3 GetCirclePointRad(float rad, float r)
		{
			return default(Vector3);
		}

		public static Vector3 GetEllipsePoint(float degree, Vector2 radius)
		{
			return default(Vector3);
		}
	}
}
