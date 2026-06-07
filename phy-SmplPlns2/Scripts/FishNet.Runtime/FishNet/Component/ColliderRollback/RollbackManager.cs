using System;
using System.Collections.Generic;
using FishNet.Managing;
using FishNet.Managing.Timing;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Component.ColliderRollback
{
	public class RollbackManager : MonoBehaviour
	{
		private int? _boundingBoxLayerNumber;

		[Tooltip("Layer to use when creating and checking against bounding boxes. This should be different from any layer used.")]
		[SerializeField]
		private LayerMask _boundingBoxLayer = 0;

		[Tooltip("Maximum time in the past colliders can be rolled back to.")]
		[SerializeField]
		private float _maximumRollbackTime = 1.25f;

		[Tooltip("Interpolation value for the NetworkTransforms or objects being rolled back.")]
		[Range(0f, 250f)]
		[SerializeField]
		internal ushort Interpolation = 2;

		private RollbackPhysicsType _rollbackPhysics;

		private NetworkManager _networkManager;

		private List<ColliderRollback> _allRollbacks = new List<ColliderRollback>();

		private RaycastHit[] _hitsCache = new RaycastHit[50];

		private RaycastHit2D[] _hitsCache2d = new RaycastHit2D[50];

		internal int? BoundingBoxLayerNumber
		{
			get
			{
				if (!_boundingBoxLayerNumber.HasValue)
				{
					for (int i = 0; i < 32; i++)
					{
						if (1 << i == BoundingBoxLayer.value)
						{
							_boundingBoxLayerNumber = i;
							break;
						}
					}
				}
				return _boundingBoxLayerNumber;
			}
		}

		internal LayerMask BoundingBoxLayer => _boundingBoxLayer;

		internal float MaximumRollbackTime => _maximumRollbackTime;

		private void TimeManager_OnPostTick()
		{
			CreateSnapshots();
		}

		internal void InitializeOnce_Internal(NetworkManager manager)
		{
			_networkManager = manager;
			_networkManager.ServerManager.OnServerConnectionState += ServerManager_OnServerConnectionState;
		}

		private bool IsBoundingBoxLayerSet(bool warn)
		{
			bool hasValue = BoundingBoxLayerNumber.HasValue;
			if (!hasValue && warn)
			{
				_networkManager.LogWarning("RollbackManager BoundingBoxLayer is unset or mixed. Bounding box rollbacks will not function. This value must be changed outside of play mode.");
			}
			return hasValue;
		}

		private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
		{
			if (obj.ConnectionState == LocalConnectionState.Started)
			{
				if (_networkManager.ServerManager.IsOnlyOneServerStarted())
				{
					_networkManager.TimeManager.OnPostTick += TimeManager_OnPostTick;
				}
			}
			else if (!_networkManager.ServerManager.IsAnyServerStarted())
			{
				_networkManager.TimeManager.OnPostTick -= TimeManager_OnPostTick;
			}
		}

		internal void RegisterColliderRollback(ColliderRollback cr)
		{
			_allRollbacks.Add(cr);
		}

		internal void UnregisterColliderRollback(ColliderRollback cr)
		{
			_allRollbacks.Remove(cr);
		}

		private void CreateSnapshots()
		{
			List<ColliderRollback> allRollbacks = _allRollbacks;
			int count = allRollbacks.Count;
			for (int i = 0; i < count; i++)
			{
				allRollbacks[i].CreateSnapshot();
			}
		}

		[Obsolete("Use Rollback(Vector3, Vector3, float, PreciseTick, RollbackPhysicsType.Physics, bool) instead.")]
		public void Rollback(Vector3 origin, Vector3 normalizedDirection, float distance, PreciseTick pt, bool asOwnerAndClientHost = false)
		{
			Rollback(0, origin, normalizedDirection, distance, pt, RollbackPhysicsType.Physics, asOwnerAndClientHost);
		}

		[Obsolete("Use Rollback(Scene, Vector3, Vector3, float, PreciseTick, RollbackPhysicsType.Physics, bool) instead.")]
		public void Rollback(Scene scene, Vector3 origin, Vector3 normalizedDirection, float distance, PreciseTick pt, bool asOwnerAndClientHost = false)
		{
			Rollback(scene.handle, origin, normalizedDirection, distance, pt, RollbackPhysicsType.Physics, asOwnerAndClientHost);
		}

		[Obsolete("Use Rollback(int, Vector3, Vector3, float, PreciseTick, RollbackPhysicsType.Physics, bool) instead.")]
		public void Rollback(int sceneHandle, Vector3 origin, Vector3 normalizedDirection, float distance, PreciseTick pt, bool asOwnerAndClientHost = false)
		{
			Rollback(sceneHandle, origin, normalizedDirection, distance, pt, RollbackPhysicsType.Physics, asOwnerAndClientHost);
		}

		[Obsolete("Use Rollback(Scene, Vector3, Vector3, float, PreciseTick, RollbackPhysicsType.Physics2D, bool) instead.")]
		public void Rollback(Scene scene, Vector2 origin, Vector2 normalizedDirection, float distance, PreciseTick pt, bool asOwnerAndClientHost = false)
		{
			Rollback(scene.handle, origin, normalizedDirection, distance, pt, RollbackPhysicsType.Physics2D, asOwnerAndClientHost);
		}

		[Obsolete("Use Rollback(Vector3, Vector3, float, PreciseTick, RollbackPhysicsType.Physics2D, bool) instead.")]
		public void Rollback(Vector2 origin, Vector2 normalizedDirection, float distance, PreciseTick pt, bool asOwnerAndClientHost = false)
		{
			Rollback(0, origin, normalizedDirection, distance, pt, RollbackPhysicsType.Physics2D, asOwnerAndClientHost);
		}

		public void Rollback(PreciseTick pt, RollbackPhysicsType physicsType, bool asOwnerAndClientHost = false)
		{
			Rollback(0, pt, physicsType, asOwnerAndClientHost);
		}

		public void Rollback(Scene scene, PreciseTick pt, RollbackPhysicsType physicsType, bool asOwnerAndClientHost = false)
		{
			Rollback(scene.handle, pt, physicsType, asOwnerAndClientHost);
		}

		public void Rollback(int sceneHandle, PreciseTick pt, RollbackPhysicsType physicsType, bool asOwnerAndClientHost = false)
		{
			TryUnsetAsOwnerAndClientHost(ref asOwnerAndClientHost);
			float rollbackTime = GetRollbackTime(pt, asOwnerAndClientHost);
			List<ColliderRollback> allRollbacks = _allRollbacks;
			if (sceneHandle != 0)
			{
				foreach (ColliderRollback item in allRollbacks)
				{
					if (item.gameObject.scene.handle == sceneHandle)
					{
						item.Rollback(rollbackTime);
					}
				}
			}
			else
			{
				foreach (ColliderRollback item2 in allRollbacks)
				{
					item2.Rollback(rollbackTime);
				}
			}
			_rollbackPhysics = physicsType;
			SyncTransforms(physicsType);
		}

		public void Rollback(Vector3 origin, Vector3 normalizedDirection, float distance, PreciseTick pt, RollbackPhysicsType physicsType, bool asOwnerAndClientHost = false)
		{
			Rollback(0, origin, normalizedDirection, distance, pt, physicsType, asOwnerAndClientHost);
		}

		public void Rollback(Scene scene, Vector3 origin, Vector3 normalizedDirection, float distance, PreciseTick pt, RollbackPhysicsType physicsType, bool asOwnerAndClientHost = false)
		{
			Rollback(scene.handle, origin, normalizedDirection, distance, pt, physicsType, asOwnerAndClientHost);
		}

		public void Rollback(int sceneHandle, Vector3 origin, Vector3 normalizedDirection, float distance, PreciseTick pt, RollbackPhysicsType physicsType, bool asOwnerAndClientHost = false)
		{
			if (!IsBoundingBoxLayerSet(warn: true))
			{
				return;
			}
			TryUnsetAsOwnerAndClientHost(ref asOwnerAndClientHost);
			float time = GetRollbackTime(pt, asOwnerAndClientHost);
			if (physicsType == RollbackPhysicsType.Physics)
			{
				int num = Physics.RaycastNonAlloc(origin, normalizedDirection, _hitsCache, distance, _boundingBoxLayer);
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = _hitsCache[i].transform.gameObject;
					if (sceneHandle == 0 || gameObject.scene.handle == sceneHandle)
					{
						TryRollback(gameObject);
					}
				}
				if (num == _hitsCache.Length)
				{
					Array.Resize(ref _hitsCache, num * 3);
				}
			}
			else
			{
				int num2 = Physics2D.RaycastNonAlloc(origin, normalizedDirection, _hitsCache2d, distance, BoundingBoxLayer);
				for (int j = 0; j < num2; j++)
				{
					GameObject gameObject2 = _hitsCache2d[j].transform.gameObject;
					if (sceneHandle == 0 || gameObject2.scene.handle == sceneHandle)
					{
						TryRollback(gameObject2);
					}
				}
				if (num2 == _hitsCache2d.Length)
				{
					Array.Resize(ref _hitsCache2d, num2 * 3);
				}
			}
			_rollbackPhysics |= physicsType;
			SyncTransforms(physicsType);
			void TryRollback(GameObject go)
			{
				if (go.TryGetComponent<ColliderRollback>(out var component))
				{
					component.Rollback(time);
				}
			}
		}

		private void TryUnsetAsOwnerAndClientHost(ref bool asOwnerAndClientHost)
		{
			if (asOwnerAndClientHost && _networkManager.IsHostStarted)
			{
				asOwnerAndClientHost = false;
			}
		}

		public void Return()
		{
			List<ColliderRollback> allRollbacks = _allRollbacks;
			int count = allRollbacks.Count;
			for (int i = 0; i < count; i++)
			{
				allRollbacks[i].Return();
			}
			SyncTransforms(_rollbackPhysics);
		}

		private float GetRollbackTime(PreciseTick pt, bool asOwner = false)
		{
			if (_networkManager == null)
			{
				return 0f;
			}
			TimeManager timeManager = _networkManager.TimeManager;
			float result = 0f;
			float num = (float)timeManager.TickDelta;
			if (!asOwner)
			{
				ulong num2 = timeManager.Tick - pt.Tick + Interpolation;
				if (num2 >= 0)
				{
					if (num2 > 65535)
					{
						num2 = 65535uL;
					}
					result = (float)num2 * num;
					result += (float)pt.PercentAsDouble * num;
				}
			}
			else
			{
				ulong num3 = timeManager.Tick - pt.Tick;
				if (num3 >= 0)
				{
					result = (float)num3 * num * 0.5f;
					double tickPercentAsDouble = timeManager.GetTickPercentAsDouble();
					result -= (float)tickPercentAsDouble * num;
				}
			}
			return result;
		}

		private void SyncTransforms(RollbackPhysicsType physicsType)
		{
			switch (physicsType)
			{
			case RollbackPhysicsType.Physics:
				Physics.SyncTransforms();
				break;
			case RollbackPhysicsType.Physics2D:
				Physics2D.SyncTransforms();
				break;
			}
		}
	}
}
