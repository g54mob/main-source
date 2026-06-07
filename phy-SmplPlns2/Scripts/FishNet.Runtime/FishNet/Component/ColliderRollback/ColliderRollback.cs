using System;
using System.Collections.Generic;
using FishNet.Managing;
using FishNet.Object;
using GameKit.Dependencies.Utilities;
using UnityEngine;

namespace FishNet.Component.ColliderRollback
{
	public class ColliderRollback : NetworkBehaviour
	{
		internal enum BoundingBoxType
		{
			Disabled = 0,
			Manual = 1
		}

		internal enum FrameRollbackTypes
		{
			LerpFirst = 0,
			LerpMiddle = 1,
			Exact = 2
		}

		internal struct ColliderSnapshot
		{
			public Vector3 WorldPosition;

			public Quaternion WorldRotation;

			public ColliderSnapshot(Transform t)
			{
				WorldPosition = t.position;
				WorldRotation = t.rotation;
			}

			public void UpdateValues(Transform t)
			{
				WorldPosition = t.position;
				WorldRotation = t.rotation;
			}
		}

		internal class RollingCollider : IResettable
		{
			private ColliderSnapshot[] _snapshots;

			private int _writeIndex;

			private bool _recycleSnapshots;

			private int _maxSnapshots;

			private Transform _transform;

			private Vector3 _localPosition;

			private Quaternion _localRotation;

			public void Return()
			{
				_transform.localPosition = _localPosition;
				_transform.localRotation = _localRotation;
			}

			public void Rollback(FrameRollbackTypes rollbackType, int endFrame, float percent)
			{
				switch (rollbackType)
				{
				case FrameRollbackTypes.Exact:
				{
					int snapshotIndex4 = GetSnapshotIndex(endFrame);
					_transform.SetPositionAndRotation(_snapshots[snapshotIndex4].WorldPosition, _snapshots[snapshotIndex4].WorldRotation);
					break;
				}
				case FrameRollbackTypes.LerpFirst:
				{
					int snapshotIndex3 = GetSnapshotIndex(endFrame);
					_transform.position = Vector3.Lerp(_transform.position, _snapshots[snapshotIndex3].WorldPosition, percent);
					_transform.rotation = Quaternion.Lerp(_transform.rotation, _snapshots[snapshotIndex3].WorldRotation, percent);
					break;
				}
				case FrameRollbackTypes.LerpMiddle:
				{
					int snapshotIndex = GetSnapshotIndex(endFrame - 1);
					int snapshotIndex2 = GetSnapshotIndex(endFrame);
					_transform.position = Vector3.Lerp(_snapshots[snapshotIndex].WorldPosition, _snapshots[snapshotIndex2].WorldPosition, percent);
					_transform.rotation = Quaternion.Lerp(_snapshots[snapshotIndex].WorldRotation, _snapshots[snapshotIndex2].WorldRotation, percent);
					break;
				}
				}
			}

			public void AddSnapshot()
			{
				if (!_recycleSnapshots)
				{
					_snapshots[_writeIndex] = new ColliderSnapshot(_transform);
				}
				else
				{
					_snapshots[_writeIndex].UpdateValues(_transform);
				}
				_writeIndex++;
				if (_writeIndex >= _maxSnapshots)
				{
					_writeIndex = 0;
					_recycleSnapshots = true;
				}
			}

			private int GetSnapshotIndex(int historyCount)
			{
				int num = _writeIndex - 1 - historyCount;
				if (num < 0)
				{
					if (!_recycleSnapshots)
					{
						return 0;
					}
					return _maxSnapshots + num;
				}
				return num;
			}

			public void Initialize(Transform t, int maxSnapshots)
			{
				_transform = t;
				_localPosition = t.localPosition;
				_localRotation = t.localRotation;
				_maxSnapshots = maxSnapshots;
				_snapshots = CollectionCaches<ColliderSnapshot>.RetrieveArray();
				if (_snapshots.Length < maxSnapshots)
				{
					Array.Resize(ref _snapshots, maxSnapshots);
				}
			}

			public void ResetState()
			{
				CollectionCaches<ColliderSnapshot>.StoreAndDefault(ref _snapshots, _maxSnapshots);
				_writeIndex = 0;
				_maxSnapshots = 0;
				_recycleSnapshots = false;
				_transform = null;
				_localPosition = default(Vector3);
				_localRotation = default(Quaternion);
			}

			public void InitializeState()
			{
			}
		}

		[Tooltip("How to configure the bounding box check.")]
		[SerializeField]
		private BoundingBoxType _boundingBox;

		[Tooltip("Physics type to generate a bounding box for.")]
		[SerializeField]
		private RollbackPhysicsType _physicsType = RollbackPhysicsType.Physics;

		[Tooltip("Size for the bounding box.. This is only used when BoundingBox is set to Manual.")]
		[SerializeField]
		private Vector3 _boundingBoxSize = new Vector3(3f, 3f, 3f);

		[Tooltip("Objects holding colliders which can rollback.")]
		[SerializeField]
		private GameObject[] _colliderParents = new GameObject[0];

		private List<RollingCollider> _rollingColliders;

		private bool _rolledBack;

		private int _maxSnapshots;

		private bool _boundingBoxCreated;

		private byte _lerpSnapshotCounter;

		private bool NetworkInitialize___EarlyFishNet_002EComponent_002EColliderRollback_002EColliderRollbackFishNet_002ERuntime_002Edll_Excuted;

		private bool NetworkInitialize___LateFishNet_002EComponent_002EColliderRollback_002EColliderRollbackFishNet_002ERuntime_002Edll_Excuted;

		public override void OnStartNetwork()
		{
			if (base.IsServerStarted)
			{
				_maxSnapshots = Mathf.CeilToInt(base.RollbackManager.MaximumRollbackTime / (float)base.TimeManager.TickDelta);
				if (_maxSnapshots < 2)
				{
					_maxSnapshots = 2;
				}
			}
		}

		public override void OnStartServer()
		{
			base.OnStartServer();
			CreateBoundingBox();
			ChangeEventSubscriptions(subscribe: true);
			InitializeRollingColliders();
		}

		public override void OnStopServer()
		{
			base.OnStopServer();
			ChangeEventSubscriptions(subscribe: false);
			DeinitializeRollingColliders();
		}

		private void CreateBoundingBox()
		{
			if (_boundingBoxCreated)
			{
				return;
			}
			_boundingBoxCreated = true;
			if (_boundingBox == BoundingBoxType.Disabled)
			{
				return;
			}
			int? boundingBoxLayerNumber = base.RollbackManager.BoundingBoxLayerNumber;
			if (!boundingBoxLayerNumber.HasValue)
			{
				return;
			}
			GameObject gameObject = new GameObject("Rollback Bounding Box");
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			if (_boundingBox == BoundingBoxType.Manual)
			{
				gameObject.layer = boundingBoxLayerNumber.Value;
				if (_physicsType == RollbackPhysicsType.Physics)
				{
					gameObject.AddComponent<BoxCollider>();
				}
				else if (_physicsType == RollbackPhysicsType.Physics2D)
				{
					gameObject.AddComponent<BoxCollider2D>();
				}
				gameObject.transform.localScale = _boundingBoxSize;
			}
		}

		private void ChangeEventSubscriptions(bool subscribe)
		{
			RollbackManager rollbackManager = base.RollbackManager;
			if (!(rollbackManager == null))
			{
				if (subscribe)
				{
					rollbackManager.RegisterColliderRollback(this);
				}
				else
				{
					rollbackManager.UnregisterColliderRollback(this);
				}
			}
		}

		internal void CreateSnapshot()
		{
			if (!_rolledBack)
			{
				if (_lerpSnapshotCounter < _maxSnapshots)
				{
					_lerpSnapshotCounter++;
				}
				int count = _rollingColliders.Count;
				for (int i = 0; i < count; i++)
				{
					_rollingColliders[i].AddSnapshot();
				}
			}
		}

		internal void Rollback(float time)
		{
			if (_rolledBack)
			{
				base.NetworkManager.LogWarning("Colliders are already rolled back. Returning colliders forward first.");
				Return();
			}
			else if (_lerpSnapshotCounter == 0)
			{
				return;
			}
			float num = time / (float)base.TimeManager.TickDelta;
			FrameRollbackTypes rollbackType;
			float percent;
			int endFrame;
			if (num > (float)(int)_lerpSnapshotCounter)
			{
				rollbackType = FrameRollbackTypes.Exact;
				endFrame = _lerpSnapshotCounter - 1;
				percent = 1f;
			}
			else
			{
				percent = num % 1f;
				endFrame = Mathf.CeilToInt(num);
				if (endFrame >= 1)
				{
					rollbackType = FrameRollbackTypes.LerpMiddle;
					endFrame = Mathf.CeilToInt(num);
				}
				else
				{
					endFrame = 0;
					rollbackType = FrameRollbackTypes.LerpFirst;
				}
			}
			int count = _rollingColliders.Count;
			for (int i = 0; i < count; i++)
			{
				_rollingColliders[i].Rollback(rollbackType, endFrame, percent);
			}
			_rolledBack = true;
		}

		internal void Return()
		{
			if (_rolledBack)
			{
				int count = _rollingColliders.Count;
				for (int i = 0; i < count; i++)
				{
					_rollingColliders[i].Return();
				}
				_rolledBack = false;
			}
		}

		private void InitializeRollingColliders()
		{
			_rollingColliders = ResettableCollectionCaches<RollingCollider>.RetrieveList();
			GameObject[] colliderParents = _colliderParents;
			foreach (GameObject gameObject in colliderParents)
			{
				if (!(gameObject.gameObject == null))
				{
					RollingCollider rollingCollider = ResettableObjectCaches<RollingCollider>.Retrieve();
					rollingCollider.Initialize(gameObject.transform, _maxSnapshots);
					_rollingColliders.Add(rollingCollider);
				}
			}
		}

		private void DeinitializeRollingColliders()
		{
			_lerpSnapshotCounter = 0;
			ResettableCollectionCaches<RollingCollider>.StoreAndDefault(ref _rollingColliders);
		}

		public override void NetworkInitialize___Early()
		{
			if (!NetworkInitialize___EarlyFishNet_002EComponent_002EColliderRollback_002EColliderRollbackFishNet_002ERuntime_002Edll_Excuted)
			{
				NetworkInitialize___EarlyFishNet_002EComponent_002EColliderRollback_002EColliderRollbackFishNet_002ERuntime_002Edll_Excuted = true;
				base.NetworkInitialize___Early();
			}
		}

		public override void NetworkInitialize___Late()
		{
			if (!NetworkInitialize___LateFishNet_002EComponent_002EColliderRollback_002EColliderRollbackFishNet_002ERuntime_002Edll_Excuted)
			{
				NetworkInitialize___LateFishNet_002EComponent_002EColliderRollback_002EColliderRollbackFishNet_002ERuntime_002Edll_Excuted = true;
				base.NetworkInitialize___Late();
			}
		}

		public override void NetworkInitializeIfDisabled()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}

		public virtual void Awake()
		{
			NetworkInitialize___Early();
			NetworkInitialize___Late();
		}
	}
}
