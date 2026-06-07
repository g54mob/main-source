using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods
{
	public class SurfacePlacement : SpawnMethod
	{
		[MinMaxSlider(0f, 45f, false)]
		public Vector2Int SectorAngle = new Vector2Int(0, 45);

		[MinMaxSlider(0f, 100f, false)]
		public Vector2Int MetersAboveSurface;

		public bool AllowSpawnInAir;

		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn, ESpawnSectorType sector, ESpawnRegion region)
		{
			int num = RandomGenerator.Next(SectorAngle.x, SectorAngle.y);
			int num2 = RandomGenerator.Next(MetersAboveSurface.x, MetersAboveSurface.y);
			float angle = SpawnTransformHelper.ConvertToGlobalAngle(num, sector);
			float regionMax = SpawnTransformHelper.GetRegionMax(region, ClimateZone.SelectedSettings.PlanetSize);
			float regionMin = SpawnTransformHelper.GetRegionMin(region, ClimateZone.SelectedSettings.PlanetSize);
			Vector3 pos;
			Vector3 n;
			if (TransformHelper.GetSurfacePosition(angle, regionMax, regionMax - regionMin, out pos, out n))
			{
				Vector3 vector = pos + n * num2;
				return InstantiateSpawnObject(objectToSpawn, vector, SpawnTransformHelper.NormalToRotation(n));
			}
			if (AllowSpawnInAir)
			{
				Vector2 direction = TransformHelper.GetDirection(angle);
				return InstantiateSpawnObject(objectToSpawn, GetPosition(sector, region, num, num2), SpawnTransformHelper.NormalToRotation(direction));
			}
			return null;
		}
	}
}
