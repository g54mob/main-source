using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem
{
	public static class SpawnTransformHelper
	{
		public static float ConvertToGlobalAngle(float angle, ESpawnSectorType sector)
		{
			return (float)((int)(sector - 1) * 45) - 22.5f + angle;
		}

		public static Vector2 GetCoordinates(float angle, float radius)
		{
			float x = radius * Mathf.Sin(angle * ((float)Math.PI / 180f));
			float y = radius * Mathf.Cos(angle * ((float)Math.PI / 180f));
			return new Vector2(x, y);
		}

		public static float GetRegionMax(ESpawnRegion region, float planetradius)
		{
			switch (region)
			{
			case ESpawnRegion.Core:
				return 50f;
			case ESpawnRegion.Underground:
				return planetradius;
			case ESpawnRegion.Surface:
				return planetradius * 2f;
			case ESpawnRegion.Sky:
				return planetradius * 3f;
			case ESpawnRegion.CloseToSurface:
				return planetradius * 0.975f;
			default:
				return planetradius * 3f;
			}
		}

		public static float GetRegionMin(ESpawnRegion region, float planetradius)
		{
			switch (region)
			{
			case ESpawnRegion.Core:
				return 0f;
			case ESpawnRegion.Underground:
				return GetRegionMax(ESpawnRegion.Core, planetradius);
			case ESpawnRegion.Surface:
				return GetRegionMax(ESpawnRegion.Underground, planetradius);
			case ESpawnRegion.Sky:
				return GetRegionMax(ESpawnRegion.Surface, planetradius);
			case ESpawnRegion.CloseToSurface:
				return planetradius * 0.8f;
			default:
				return 0f;
			}
		}

		public static Quaternion NormalToRotation(Vector3 normal)
		{
			Vector3 vector = -normal;
			return Quaternion.AngleAxis(Mathf.Atan2(vector.y, vector.x) * 57.29578f + 90f, Vector3.forward);
		}
	}
}
