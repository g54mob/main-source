using System.Collections.Generic;
using UnityEngine;

namespace JSAM.Example.Shmup2D
{
	public class ObjectPool : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The reference object to pool")]
		private GameObject prefab;

		[SerializeField]
		[Tooltip("Spawn this many objects on start")]
		private int objectsToSpawn = 100;

		private List<GameObject> pool = new List<GameObject>();

		private void Start()
		{
			for (int i = 0; i < objectsToSpawn; i++)
			{
				pool.Add(Object.Instantiate(prefab, base.transform));
				pool[i].SetActive(value: false);
			}
		}

		public GameObject GetObject()
		{
			foreach (GameObject item in pool)
			{
				if (!item.activeSelf)
				{
					return item;
				}
			}
			return null;
		}
	}
}
