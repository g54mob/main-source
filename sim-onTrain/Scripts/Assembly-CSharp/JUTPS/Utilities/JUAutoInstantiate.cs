using System.Collections.Generic;
using JUTPSEditor.JUHeader;
using UnityEngine;
using UnityEngine.Events;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/Utilities/Auto Instantiate")]
	public class JUAutoInstantiate : MonoBehaviour
	{
		[JUHeader("Auto Instantiate Prefab")]
		public GameObject Prefab;

		public bool StartInstantiateOnAwake = true;

		public float TimeToSpawn = 2f;

		public bool Repeat;

		public float RepeatingTime = 1f;

		public float InstanceLifeTime = -1f;

		[JUHeader("Random Options")]
		public bool SwitchToRandomInstantiate;

		public GameObject[] PrefabsToInstantiate;

		public Vector3 SpawnArea;

		public Vector3 PositionOffset;

		public bool RandomRotation = true;

		public int Quantity = 1;

		public int InstancesLimit = 32;

		[Range(0f, 100f)]
		public float EmptyInstantiatePorcentage;

		public UnityEvent OnInstantiate;

		private List<GameObject> Spawneds = new List<GameObject>();

		private void Start()
		{
			if (StartInstantiateOnAwake)
			{
				if (Repeat)
				{
					InvokeRepeating("InstantiatePrefab", TimeToSpawn, RepeatingTime);
				}
				else
				{
					Invoke("InstantiatePrefab", TimeToSpawn);
				}
			}
		}

		public void InstantiatePrefab()
		{
			ClearEmpty();
			if (EmptyInstantiatePorcentage == 100f || (EmptyInstantiatePorcentage > 0f && (float)Random.Range(0, 100) < EmptyInstantiatePorcentage) || (Spawneds.Count - 1 > InstancesLimit && InstancesLimit > 0))
			{
				return;
			}
			if (!SwitchToRandomInstantiate)
			{
				GameObject gameObject = Object.Instantiate(Prefab, base.transform.position, base.transform.rotation);
				if (InstanceLifeTime > 0f)
				{
					Object.Destroy(gameObject, InstanceLifeTime);
				}
				Spawneds.Add(gameObject);
			}
			else
			{
				Quantity = Mathf.Clamp(Quantity, 0, InstancesLimit);
				for (int i = 0; i < Quantity; i++)
				{
					Vector3 position = base.transform.position;
					position.x += Random.Range(0f - SpawnArea.x, SpawnArea.x);
					position.y += Random.Range(0f - SpawnArea.y, SpawnArea.y);
					position.z += Random.Range(0f - SpawnArea.z, SpawnArea.z);
					int num = Random.Range(0, PrefabsToInstantiate.Length - 1);
					GameObject gameObject2 = Object.Instantiate(PrefabsToInstantiate[num], position + PositionOffset, RandomRotation ? Quaternion.Euler(0f, Random.Range(-360, 360), 0f) : PrefabsToInstantiate[num].transform.rotation);
					if (InstanceLifeTime > 0f)
					{
						Object.Destroy(gameObject2, InstanceLifeTime);
					}
					Spawneds.Add(gameObject2);
				}
			}
			if (Spawneds.Count - 1 > InstancesLimit && InstancesLimit > 0)
			{
				for (int j = InstancesLimit; j < Spawneds.Count - 1; j++)
				{
					Object.Destroy(Spawneds[j]);
					Spawneds.RemoveAt(j);
				}
			}
			OnInstantiate.Invoke();
		}

		private void ClearEmpty()
		{
			GameObject[] array = Spawneds.ToArray();
			foreach (GameObject gameObject in array)
			{
				if (gameObject == null)
				{
					Spawneds.Remove(gameObject);
				}
			}
		}

		public void SetRepeatingTime(float time)
		{
			RepeatingTime = time;
			CancelInvoke("InstantiatePrefab");
			InvokeRepeating("InstantiatePrefab", RepeatingTime, RepeatingTime);
		}

		public void AddTime(float time)
		{
			SetRepeatingTime(RepeatingTime + time);
		}

		public void AddQuantity(int Quantitites)
		{
			Quantity += Quantitites;
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(base.transform.position + PositionOffset, SpawnArea);
		}
	}
}
