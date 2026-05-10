using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Serialization;

namespace Photon.Pun.UtilityScripts
{
	public class OnJoinedInstantiate : MonoBehaviour, IMatchmakingCallbacks
	{
		public enum SpawnSequence
		{
			Connection = 0,
			Random = 1,
			RoundRobin = 2
		}

		[HideInInspector]
		private Transform SpawnPosition;

		[HideInInspector]
		public SpawnSequence Sequence;

		[HideInInspector]
		public List<Transform> SpawnPoints;

		[Tooltip("Add a random variance to a spawn point position. GetRandomOffset() can be overridden with your own method for producing offsets.")]
		[HideInInspector]
		public bool UseRandomOffset;

		[Tooltip("Radius of the RandomOffset.")]
		[FormerlySerializedAs("PositionOffset")]
		[HideInInspector]
		public float RandomOffset;

		[Tooltip("Disables the Y axis of RandomOffset. The Y value of the spawn point will be used.")]
		[HideInInspector]
		public bool ClampY;

		[HideInInspector]
		public List<GameObject> PrefabsToInstantiate;

		[FormerlySerializedAs("autoSpawnObjects")]
		[HideInInspector]
		public bool AutoSpawnObjects;

		public Stack<GameObject> SpawnedObjects;

		protected int spawnedAsActorId;

		protected int lastUsedSpawnPointIndex;

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnJoinedRoom()
		{
		}

		public virtual void SpawnObjects()
		{
		}

		public virtual void DespawnObjects(bool localOnly)
		{
		}

		public virtual void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		public virtual void OnCreatedRoom()
		{
		}

		public virtual void OnCreateRoomFailed(short returnCode, string message)
		{
		}

		public virtual void OnJoinRoomFailed(short returnCode, string message)
		{
		}

		public virtual void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public virtual void OnLeftRoom()
		{
		}

		public virtual void GetSpawnPoint(out Vector3 spawnPos, out Quaternion spawnRot)
		{
			spawnPos = default(Vector3);
			spawnRot = default(Quaternion);
		}

		protected virtual Transform GetSpawnPoint()
		{
			return null;
		}

		protected virtual Vector3 GetRandomOffset()
		{
			return default(Vector3);
		}
	}
}
