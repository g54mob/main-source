using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods
{
	public class AbsolutePlacement : SpawnMethod
	{
		[MinMaxSlider(0f, 45f, false)]
		public Vector2Int SectorAngle;

		[MinMaxSlider(0f, 100f, false)]
		public Vector2Int SectorHeightPercentage;

		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn, ESpawnSectorType sector, ESpawnRegion region)
		{
			int num = RandomGenerator.Next(SectorAngle.x, SectorAngle.y);
			int height = RandomGenerator.Next(SectorHeightPercentage.x, SectorHeightPercentage.y);
			Vector2 direction = TransformHelper.GetDirection(SpawnTransformHelper.ConvertToGlobalAngle(num, sector));
			return InstantiateSpawnObject(objectToSpawn, GetPosition(sector, region, num, height), SpawnTransformHelper.NormalToRotation(direction));
		}
	}
}
