using System.Collections.Generic;
using Mirror;
using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package.Net
{
	[AddComponentMenu("Polarith AI » Examples/Network/Enemy Spawner")]
	public sealed class EnemySpawner : NetworkBehaviour
	{
		[Tooltip("The template for the spawned object.")]
		public GameObject Spawnable;

		[Tooltip("Limits how many objects can be active at the same time.")]
		public int MaximumEnemies = 7;

		[Tooltip("Contains possible spawn points.")]
		public List<GameObject> SpawnPoints = new List<GameObject>();

		[Tooltip("Spawned objects are added to this environment such that Polarith.AI can perceiver the objects.")]
		public AIMEnvironment Environment;

		[Tooltip("A possible empty object which acts as the spawned objects parent. This is used to organize the objects.")]
		public GameObject EnemyParent;

		[Tooltip("The tag of the EnemyParent, if not assigned the, tag is used to find the object at start.")]
		public string EnemyParentTag = "EnemyPool";

		[Tooltip("The spawn delay in seconds.")]
		public float Delay = 0.5f;

		private float currentTime;

		private void Start()
		{
			if (EnemyParent == null)
			{
				EnemyParent = GameObject.FindWithTag(EnemyParentTag);
			}
			UpdateEnvironment();
		}

		private void Update()
		{
			UpdateEnvironment();
			if (!base.isServer)
			{
				return;
			}
			if (SpawnPoints.Count == 0)
			{
				Debug.LogError(base.gameObject.name + ", EnemySpawner: SpawnPoints need at least one entry.");
				return;
			}
			if (currentTime >= Delay)
			{
				if (Environment.GameObjects.Count < MaximumEnemies)
				{
					int num = (int)Random.Range(0f, SpawnPoints.Count);
					if (num > SpawnPoints.Count - 1)
					{
						num = SpawnPoints.Count - 1;
					}
					GameObject obj = Object.Instantiate(Spawnable, SpawnPoints[num].transform.position, Quaternion.identity);
					obj.transform.parent = EnemyParent.transform;
					NetworkServer.Spawn(obj);
				}
				currentTime = 0f;
			}
			currentTime += Time.deltaTime;
		}

		private void UpdateEnvironment()
		{
			Environment.GameObjects.Clear();
			for (int i = 0; i < EnemyParent.transform.childCount; i++)
			{
				Environment.GameObjects.Add(EnemyParent.transform.GetChild(i).gameObject);
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
