using UnityEngine;

namespace Gh.Tk
{
	public static class DirtController
	{
		private const float _yOffset = 0f;

		public static int World => 0;

		public static float ApplyDirtAmountAdjustments(float value)
		{
			return 0f;
		}

		public static Dirt Spawn(DirtType dirtType, Vector3 position, Quaternion? rotation = null, int strength = 1, float minDistanceFromOthers = -1f, bool ignoreDirtBlocking = false, string uniqueKeyFilterOverride = null)
		{
			return null;
		}

		private static Dirt GetDirt(Vector3 position, float minDistanceFromOthers)
		{
			return null;
		}

		private static Dirt CreateDirt(Vector3 position)
		{
			return null;
		}

		private static Vector3 EnsurePositionIsNotAtTheEdgeOfARoom(Vector3 floorPosition)
		{
			return default(Vector3);
		}

		public static Dirt SpawnRoomDirt(Room room, DirtType type)
		{
			return null;
		}

		private static Vector3 RandomizePositionInSameRoom(Vector3 origPosition, float maxDiff)
		{
			return default(Vector3);
		}
	}
}
