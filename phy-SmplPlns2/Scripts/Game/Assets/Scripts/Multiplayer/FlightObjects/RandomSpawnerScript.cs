using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects
{
	public class RandomSpawnerScript : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker Spawn = new ProfilerMarker("RandomSpawnerScript.Spawn");

			public static readonly ProfilerMarker Start = new ProfilerMarker("RandomSpawnerScript.Start");

			public static readonly ProfilerMarker UseLeafsAsChildren = new ProfilerMarker("RandomSpawnerScript.UseLeafsAsChildren");
		}

		[SerializeField]
		private GameObject[] _prefabs;

		[SerializeField]
		private Vector3[] _randomRotations;

		[SerializeField]
		private int _spawnCount;

		[SerializeField]
		private bool _spawnNetworkedAreaObjects = true;

		[SerializeField]
		private Transform[] _spawnTargets;

		[SerializeField]
		private bool _useLeafsAsSpawnTargets;

		public void Spawn(int seed)
		{
			using (Profile.Spawn.Auto())
			{
				NetworkedAreaScript networkedAreaScript = (_spawnNetworkedAreaObjects ? GetComponentInParent<NetworkedAreaScript>() : null);
				List<Transform> list = _spawnTargets.ToList();
				System.Random random = new System.Random(seed);
				for (int i = 0; i < _spawnCount; i++)
				{
					Transform transform = list[random.Next(list.Count)];
					GameObject prefab = _prefabs[random.Next(_prefabs.Length)];
					byte? networkedAreaItemId = (_spawnNetworkedAreaObjects ? new byte?(networkedAreaScript.AsyncRegistrationBegin()) : ((byte?)null));
					SpawnPrefab(prefab, transform, random, i, networkedAreaItemId).Forget();
					list.Remove(transform);
				}
			}
		}

		protected virtual void Start()
		{
			using (Profile.Start.Auto())
			{
				if (_useLeafsAsSpawnTargets)
				{
					UseLeafsAsChildren();
				}
				int seed = 0;
				Spawn(seed);
			}
		}

		private static void FindLeafs(Transform t, List<Transform> transforms)
		{
			if (t.childCount == 0)
			{
				transforms.Add(t);
				return;
			}
			foreach (Transform item in t)
			{
				FindLeafs(item, transforms);
			}
		}

		private async UniTaskVoid SpawnPrefab(GameObject prefab, Transform spawnTarget, System.Random random, int spawnIndex, byte? networkedAreaItemId)
		{
			GameObject gameObject = (await UnityEngine.Object.InstantiateAsync(prefab, spawnTarget))?.FirstOrDefault();
			if (!(this == null) && !(spawnTarget == null) && !(gameObject == null))
			{
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localEulerAngles = _randomRotations[random.Next(_randomRotations.Length)];
				gameObject.GetComponentInChildren<IRandomSpawnHandler>()?.OnSpawned(random, spawnIndex, networkedAreaItemId);
			}
		}

		private void UseLeafsAsChildren()
		{
			using (Profile.UseLeafsAsChildren.Auto())
			{
				List<Transform> list = new List<Transform>();
				FindLeafs(base.transform, list);
				_spawnTargets = list.ToArray();
			}
		}
	}
}
