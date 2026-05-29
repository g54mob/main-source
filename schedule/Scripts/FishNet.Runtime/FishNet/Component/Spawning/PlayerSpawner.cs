using System;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using UnityEngine;
using UnityEngine.Serialization;

namespace FishNet.Component.Spawning
{
	[AddComponentMenu("FishNet/Component/PlayerSpawner")]
	public class PlayerSpawner : MonoBehaviour
	{
		[Tooltip("Prefab to spawn for the player.")]
		[SerializeField]
		private NetworkObject _playerPrefab;

		[Tooltip("True to add player to the active scene when no global scenes are specified through the SceneManager.")]
		[SerializeField]
		private bool _addToDefaultScene;

		[FormerlySerializedAs("_spawns")]
		[Tooltip("Areas in which players may spawn.")]
		public Transform[] Spawns;

		private NetworkManager _networkManager;

		private int _nextSpawn;

		public event Action<NetworkObject> OnSpawned
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializeOnce()
		{
		}

		private void SceneManager_OnClientLoadedStartScenes(NetworkConnection conn, bool asServer)
		{
		}

		private void SetSpawn(Transform prefab, out Vector3 pos, out Quaternion rot)
		{
			pos = default(Vector3);
			rot = default(Quaternion);
		}

		private void SetSpawnUsingPrefab(Transform prefab, out Vector3 pos, out Quaternion rot)
		{
			pos = default(Vector3);
			rot = default(Quaternion);
		}
	}
}
