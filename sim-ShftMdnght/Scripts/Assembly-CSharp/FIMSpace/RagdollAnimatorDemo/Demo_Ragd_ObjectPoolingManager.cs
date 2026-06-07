using System.Collections.Generic;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_ObjectPoolingManager : MonoBehaviour
	{
		public static Demo_Ragd_ObjectPoolingManager Get;

		public GameObject ToSpawn;

		public int InitialSpawnCount = 10;

		public int InitialPoolSize = 20;

		public Vector2 SpawnArea = new Vector2(4f, 4f);

		private List<GameObject> availableList = new List<GameObject>();

		private List<GameObject> activeSpawnedList = new List<GameObject>();

		private void Start()
		{
			Get = this;
			for (int i = 0; i < InitialPoolSize; i++)
			{
				GenerateObjectForThePool();
			}
			for (int j = 0; j < InitialSpawnCount; j++)
			{
				SpawnNewObject();
			}
		}

		public void SpawnObjects(int count)
		{
			for (int i = 0; i < count; i++)
			{
				SpawnNewObject();
			}
		}

		private void SpawnNewObject()
		{
			if (availableList.Count == 0)
			{
				GenerateObjectForThePool();
			}
			GameObject obj = availableList[availableList.Count - 1];
			availableList.RemoveAt(availableList.Count - 1);
			obj.transform.SetParent(null);
			obj.transform.position = GetSpawnPosition();
			obj.transform.rotation = Quaternion.identity;
			obj.SetActive(value: true);
			obj.SendMessage("ResetOnStart");
		}

		private Vector3 GetSpawnPosition()
		{
			Vector3 position = base.transform.position;
			position.x += Random.Range(0f - SpawnArea.x, SpawnArea.x) * 0.5f;
			position.z += Random.Range(0f - SpawnArea.y, SpawnArea.y) * 0.5f;
			return position;
		}

		private void GenerateObjectForThePool()
		{
			GameObject gameObject = Object.Instantiate(ToSpawn);
			GiveBackObject(gameObject);
		}

		internal void GiveBackObject(GameObject gameObject)
		{
			gameObject.SetActive(value: false);
			gameObject.transform.SetParent(base.transform, worldPositionStays: true);
			availableList.Add(gameObject);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.DrawWireCube(base.transform.position, new Vector3(SpawnArea.x, 0f, SpawnArea.y));
		}
	}
}
