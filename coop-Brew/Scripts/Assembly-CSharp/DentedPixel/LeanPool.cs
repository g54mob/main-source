using System.Collections.Generic;
using UnityEngine;

namespace DentedPixel
{
	public class LeanPool
	{
		private GameObject[] array;

		private Queue<GameObject> oldestItems;

		private int retrieveIndex;

		public GameObject[] init(GameObject prefab, int count, Transform parent = null, bool retrieveOldestItems = true)
		{
			return null;
		}

		public void init(GameObject[] array, bool retrieveOldestItems = true)
		{
		}

		public void giveup(GameObject go)
		{
		}

		public GameObject retrieve()
		{
			return null;
		}
	}
}
