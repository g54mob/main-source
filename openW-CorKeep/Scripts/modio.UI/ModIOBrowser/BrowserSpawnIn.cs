using UnityEngine;

namespace ModIOBrowser
{
	public class BrowserSpawnIn : MonoBehaviour
	{
		public GameObject browserPrefab;

		private GameObject spawnedBrowser;

		private bool hasSpawned => spawnedBrowser != null;

		public void SpawnIn()
		{
			if (!hasSpawned)
			{
				spawnedBrowser = Object.Instantiate(browserPrefab);
			}
			Browser.Open(null);
		}
	}
}
