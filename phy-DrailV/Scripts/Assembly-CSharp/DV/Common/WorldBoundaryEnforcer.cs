using DV.Utils;
using UnityEngine;

namespace DV.Common
{
	[DisallowMultipleComponent]
	public class WorldBoundaryEnforcer : MonoBehaviour
	{
		private Vector3 lastPosition = Vector3.zero;

		private bool skipFrame;

		private void Awake()
		{
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.AboutToMoveWorld += OnWorldAboutToMove;
			}
		}

		private void OnWorldAboutToMove(Vector3 newMove, Vector3 moveVector)
		{
			lastPosition -= moveVector;
			skipFrame = true;
		}

		private void OnDestroy()
		{
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.AboutToMoveWorld -= OnWorldAboutToMove;
			}
		}

		private void LateUpdate()
		{
			if (skipFrame)
			{
				skipFrame = false;
				return;
			}
			Vector3 position = base.transform.position;
			if (LoadingScreenManager.IsLoading || FastTravelController.IsFastTravelling)
			{
				lastPosition = position;
				return;
			}
			if (lastPosition == Vector3.zero)
			{
				lastPosition = position;
				return;
			}
			Vector3 vector = ClampVector(lastPosition, position);
			if (vector != position)
			{
				base.transform.position = vector;
			}
			lastPosition = ClampPoint(vector, 0.1f);
		}

		public static Vector3 ClampPoint(Vector3 point, float additionalPadding = 0f)
		{
			if (!LevelInfo.EnforceBoundary)
			{
				return point;
			}
			float worldBoundaryMargin = LevelInfo.WorldBoundaryMargin;
			Vector3 worldBoundarySize = LevelInfo.WorldBoundarySize;
			Vector3 worldBoundaryOffset = LevelInfo.WorldBoundaryOffset;
			Vector3 vector = new Vector3(worldBoundaryMargin + additionalPadding, 0f, worldBoundaryMargin + additionalPadding) + WorldMover.currentMove;
			Vector3 vector2 = new Vector3(worldBoundarySize.x - worldBoundaryMargin - additionalPadding, worldBoundarySize.y, worldBoundarySize.z - worldBoundaryMargin - additionalPadding) + WorldMover.currentMove;
			vector += worldBoundaryOffset;
			vector2 += worldBoundaryOffset;
			point.x = Mathf.Clamp(point.x, vector.x, vector2.x);
			point.z = Mathf.Clamp(point.z, vector.z, vector2.z);
			return point;
		}

		public static Vector3 ClampPointAndAltitude(Vector3 point, float maxAltitude, float additionalPadding = 0f)
		{
			if (!LevelInfo.EnforceBoundary)
			{
				return point;
			}
			float worldBoundaryMargin = LevelInfo.WorldBoundaryMargin;
			Vector3 worldBoundarySize = LevelInfo.WorldBoundarySize;
			Vector3 worldBoundaryOffset = LevelInfo.WorldBoundaryOffset;
			Vector3 vector = new Vector3(worldBoundaryMargin + additionalPadding, 0f, worldBoundaryMargin + additionalPadding) + WorldMover.currentMove;
			Vector3 vector2 = new Vector3(worldBoundarySize.x - worldBoundaryMargin - additionalPadding, worldBoundarySize.y, worldBoundarySize.z - worldBoundaryMargin - additionalPadding) + WorldMover.currentMove;
			vector += worldBoundaryOffset;
			vector2 += worldBoundaryOffset;
			point.x = Mathf.Clamp(point.x, vector.x, vector2.x);
			point.y = Mathf.Min(point.y, maxAltitude - additionalPadding);
			point.z = Mathf.Clamp(point.z, vector.z, vector2.z);
			return point;
		}

		public static Vector3 ClampVector(Vector3 start, Vector3 end, bool usingWorldShift = true, float additionalPadding = 0f)
		{
			if (!LevelInfo.EnforceBoundary)
			{
				return end;
			}
			float worldBoundaryMargin = LevelInfo.WorldBoundaryMargin;
			Vector3 worldBoundarySize = LevelInfo.WorldBoundarySize;
			Vector3 worldBoundaryOffset = LevelInfo.WorldBoundaryOffset;
			Vector3 vector = (usingWorldShift ? WorldMover.currentMove : Vector3.zero);
			vector += worldBoundaryOffset;
			end = ClampX(start, end, worldBoundaryMargin + vector.x + additionalPadding);
			end = ClampX(start, end, worldBoundarySize.x - worldBoundaryMargin + vector.x - additionalPadding);
			end = ClampZ(start, end, worldBoundaryMargin + vector.z + additionalPadding);
			end = ClampZ(start, end, worldBoundarySize.z - worldBoundaryMargin + vector.z - additionalPadding);
			return end;
		}

		public static Vector3 ClampVectorAndAltitude(Vector3 start, Vector3 end, float maxAltitude = 1000f, bool usingWorldShift = true, float additionalPadding = 0f)
		{
			if (!LevelInfo.EnforceBoundary)
			{
				return end;
			}
			float worldBoundaryMargin = LevelInfo.WorldBoundaryMargin;
			Vector3 worldBoundarySize = LevelInfo.WorldBoundarySize;
			Vector3 worldBoundaryOffset = LevelInfo.WorldBoundaryOffset;
			Vector3 vector = (usingWorldShift ? WorldMover.currentMove : Vector3.zero);
			vector += worldBoundaryOffset;
			end = ClampX(start, end, worldBoundaryMargin + vector.x + additionalPadding);
			end = ClampX(start, end, worldBoundarySize.x - worldBoundaryMargin + vector.x - additionalPadding);
			end = ClampZ(start, end, worldBoundaryMargin + vector.z + additionalPadding);
			end = ClampZ(start, end, worldBoundarySize.z - worldBoundaryMargin + vector.z - additionalPadding);
			end.y = Mathf.Min(end.y, maxAltitude + vector.y - additionalPadding);
			return end;
		}

		private static Vector3 ClampX(Vector3 start, Vector3 end, float x)
		{
			float f = start.x - x;
			float f2 = end.x - x;
			if (Mathf.Sign(f) != Mathf.Sign(f2))
			{
				float t = Mathf.InverseLerp(start.x, end.x, x);
				return Vector3.Lerp(start, end, t);
			}
			return end;
		}

		private static Vector3 ClampY(Vector3 start, Vector3 end, float y)
		{
			float f = start.y - y;
			float f2 = end.y - y;
			if (Mathf.Sign(f) != Mathf.Sign(f2))
			{
				float t = Mathf.InverseLerp(start.y, end.y, y);
				return Vector3.Lerp(start, end, t);
			}
			return end;
		}

		private static Vector3 ClampZ(Vector3 start, Vector3 end, float z)
		{
			float f = start.z - z;
			float f2 = end.z - z;
			if (Mathf.Sign(f) != Mathf.Sign(f2))
			{
				float t = Mathf.InverseLerp(start.z, end.z, z);
				return Vector3.Lerp(start, end, t);
			}
			return end;
		}
	}
}
