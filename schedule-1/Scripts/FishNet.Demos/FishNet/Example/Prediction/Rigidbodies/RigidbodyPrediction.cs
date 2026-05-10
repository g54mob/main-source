using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Prediction;
using FishNet.Object.Prediction.Delegating;
using FishNet.Serializing;
using FishNet.Transporting;
using FishNet.Utility.Performance;
using UnityEngine;

namespace FishNet.Example.Prediction.Rigidbodies
{
	public class RigidbodyPrediction : NetworkBehaviour
	{
		public struct MoveData : IReplicateData
		{
			public bool Jump;

			public float Horizontal;

			public float Vertical;

			private uint _tick;

			public MoveData(bool jump, float horizontal, float vertical)
			{
				Jump = false;
				Horizontal = 0f;
				Vertical = 0f;
				_tick = 0u;
			}

			public void Dispose()
			{
			}

			public uint GetTick()
			{
				return 0u;
			}

			public void SetTick(uint value)
			{
			}
		}

		public struct ReconcileData : IReconcileData
		{
			public Vector3 Position;

			public Quaternion Rotation;

			public Vector3 Velocity;

			public Vector3 AngularVelocity;

			private uint _tick;

			public ReconcileData(Vector3 position, Quaternion rotation, Vector3 velocity, Vector3 angularVelocity)
			{
				Position = default(Vector3);
				Rotation = default(Quaternion);
				Velocity = default(Vector3);
				AngularVelocity = default(Vector3);
				_tick = 0u;
			}

			public void Dispose()
			{
			}

			public uint GetTick()
			{
				return 0u;
			}

			public void SetTick(uint value)
			{
			}
		}

		[SerializeField]
		private float _jumpForce;

		[SerializeField]
		private float _moveRate;

		private Rigidbody _rigidbody;

		private float _nextJumpTime;

		private bool _jump;

		public NetworkObject BulletPrefab;

		private bool _spawnBullet;

		private bool _despawnBullet;

		private NetworkObject _lastSpawnedBullet;

		private ReplicateUserLogicDelegate<MoveData> _replicateULDelegate___Move;

		private ReconcileUserLogicDelegate<ReconcileData> _reconcileULDelegate___Reconciliation;

		private BasicQueue<MoveData> _serverReplicates___Move;

		private List<MoveData> _clientReplicates___Move;

		private ReconcileData _reconcileData___Move;

		private MoveData[] Move___serverReplicateReadBuffer;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002EPrediction_002ERigidbodies_002ERigidbodyPredictionFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002EPrediction_002ERigidbodies_002ERigidbodyPredictionFishNet_002EDemos_002Edll_Excuted;

		public virtual void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		private void Update()
		{
		}

		private void PredictionManager_OnPreReplicateReplay(uint arg1, PhysicsScene arg2, PhysicsScene2D arg3)
		{
		}

		private void TimeManager_OnTick()
		{
		}

		private void TimeManager_OnPostTick()
		{
		}

		private void BuildMoveData(out MoveData md)
		{
			md = default(MoveData);
		}

		private void TrySpawnBullet()
		{
		}

		private void TryDespawnBullet()
		{
		}

		private void AddGravity()
		{
		}

		[Replicate]
		private void Move(MoveData md, bool asServer, Channel channel = Channel.Unreliable, bool replaying = false)
		{
		}

		[Reconcile]
		private void Reconciliation(ReconcileData rd, bool asServer, Channel channel = Channel.Unreliable)
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void Move___UL(MoveData md, bool asServer, Channel channel = Channel.Unreliable, bool replaying = false)
		{
		}

		private void Reconciliation___UL(ReconcileData rd, bool asServer, Channel channel = Channel.Unreliable)
		{
		}

		public override void ClearReplicateCache_Virtual(bool asServer)
		{
		}

		private void Reader_Replicate___Move(PooledReader PooledReader0, NetworkConnection NetworkConnection1, Channel Channel2)
		{
		}

		private void Reader_Reconcile___Reconciliation(PooledReader PooledReader0, Channel Channel1)
		{
		}

		private void Awake_UserLogic_FishNet_002EExample_002EPrediction_002ERigidbodies_002ERigidbodyPrediction_FishNet_002EDemos_002Edll()
		{
		}
	}
}
