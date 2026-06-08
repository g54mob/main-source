using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class SpawnRandomBasedOnSeed : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> potentialGameObjects;

		[SerializeField]
		private int seedOffset;

		private Tile parentTile;

		[SerializeField]
		private GameObject spawnedObject;

		public void Initialize()
		{
			if (!spawnedObject)
			{
				parentTile = GetComponentInParent<Tile>();
				Random.InitState(parentTile.Seed + seedOffset);
				spawnedObject = Object.Instantiate(potentialGameObjects[Random.Range(0, potentialGameObjects.Count)], base.transform);
				spawnedObject.transform.SetAsFirstSibling();
				Randomizer.RandomizeSeed();
			}
		}
	}
}
