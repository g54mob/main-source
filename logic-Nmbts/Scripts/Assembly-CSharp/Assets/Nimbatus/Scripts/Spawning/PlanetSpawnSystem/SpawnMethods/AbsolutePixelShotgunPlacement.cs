using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem.SpawnMethods
{
	public class AbsolutePixelShotgunPlacement : SpawnMethod
	{
		public float PositionX;

		public float PositionY;

		public float CheckDistance = 1000f;

		[MinMaxSlider(0f, 10f, false)]
		public Vector2Int MetersAboveSurface;

		public override InteractiveWorldObject TryToSpawn(InteractiveWorldObject objectToSpawn, ESpawnSectorType sector, ESpawnRegion region)
		{
			List<Vector3> obj = new List<Vector3>
			{
				new Vector3(PositionX, PositionY, 0f)
			};
			int num = RandomGenerator.Next(MetersAboveSurface.x, MetersAboveSurface.y);
			foreach (Vector3 item in obj)
			{
				Vector2 startPosition = new Vector2(item.x, item.y);
				int num2 = RandomGenerator.Next(0, 360);
				Vector3 pos;
				Vector3 n;
				if (TransformHelper.GetSurfacePosition(startPosition, num2, out pos, out n, CheckDistance))
				{
					Vector3 vector = pos + n * num;
					InteractiveWorldObject interactiveWorldObject = InstantiateSpawnObject(objectToSpawn, vector, SpawnTransformHelper.NormalToRotation(n));
					if (interactiveWorldObject != null)
					{
						return interactiveWorldObject;
					}
				}
			}
			return null;
		}
	}
}
