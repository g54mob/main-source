using System.Collections.Generic;
using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Demos.B
{
	public class Spawner : MonoBehaviour
	{
		public Transform SpawnTop;

		public Transform SpawnBottom;

		public Transform SpawnLeft;

		public Transform SpawnRight;

		public float SpawnIntervall = 2f;

		public List<GameObject> ObjectsToSpawn;

		private void Start()
		{
			InvokeRepeating("Spawn", 0f, SpawnIntervall);
		}

		private void Spawn()
		{
			int num = Random.Range(0, 4);
			Vector3 position = Vector3.zero;
			Vector2 direction = Vector2.zero;
			float y = 0f;
			switch (num)
			{
			case 0:
				position = SpawnTop.position;
				direction = new Vector2(0f, -1f);
				y = 0f;
				break;
			case 1:
				position = SpawnBottom.position;
				direction = new Vector2(0f, 1f);
				y = 180f;
				break;
			case 2:
				position = SpawnLeft.position;
				direction = new Vector2(1f, 0f);
				y = -90f;
				break;
			case 3:
				position = SpawnRight.position;
				direction = new Vector2(-1f, 0f);
				y = 90f;
				break;
			}
			position += new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
			int index = Random.Range(0, ObjectsToSpawn.Count);
			GameObject obj = Object.Instantiate(ObjectsToSpawn[index], position, Quaternion.Euler(0f, y, 0f));
			obj.GetComponent<MovingCar>().Direction = direction;
			obj.GetComponent<MovingCar>().Speed = Random.Range(1f, 4f);
			obj.GetComponent<SizeBlockModelProvider>().Color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
		}
	}
}
