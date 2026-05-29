using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object;
using FishNet.Serializing.Helping;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Predicting
{
	[AddComponentMenu("FishNet/Manager/PredictionManager")]
	[DisallowMultipleComponent]
	public sealed class PredictionManager : MonoBehaviour
	{
		private bool _isReplaying;

		[Tooltip("Number of inputs to keep in queue should the server miss receiving an input update from the client. Higher values will increase the likeliness of the server always having input from the client while lower values will allow the client input to run on the server faster. This value cannot be higher than MaximumServerReplicates.")]
		[Range(1f, 15f)]
		[SerializeField]
		private ushort _queuedInputs;

		[SerializeField]
		[Tooltip("True to drop replicates from clients which are being received excessively. This can help with attacks but may cause client to temporarily desynchronize during connectivity issues. When false the server will hold at most up to 3 seconds worth of replicates, consuming multiple per tick to clear out the buffer quicker. This is good to ensure all inputs are executed but potentially could allow speed hacking.")]
		private bool _dropExcessiveReplicates;

		[SerializeField]
		[Tooltip("Maximum number of replicates a server can queue per object. Higher values will put more load on the server and add replicate latency for the client.")]
		private ushort _maximumServerReplicates;

		[SerializeField]
		[Tooltip("Maximum number of excessive replicates which can be consumed per tick. Consumption count will scale up to this value automatically.")]
		private byte _maximumConsumeCount;

		[Tooltip("Maximum number of past inputs which may send.")]
		[SerializeField]
		[Range(2f, 15f)]
		private byte _redundancyCount;

		[Tooltip("True to allow clients to use predicted spawning and despawning. While true, each NetworkObject prefab you wish to predicted spawn must be marked as to allow this feature.")]
		[SerializeField]
		private bool _allowPredictedSpawning;

		[SerializeField]
		[Tooltip("Maximum number of Ids to reserve on clients for predicted spawning. Higher values will allow clients to send more predicted spawns per second but may reduce availability of ObjectIds with high player counts.")]
		[Range(1f, 100f)]
		private byte _reservedObjectIds;

		[NonSerialized]
		private HashSet<UnityEngine.Component> _rigidbodies;

		[NonSerialized]
		private HashSet<UnityEngine.Component> _componentCache;

		private HashSet<Scene> _replayingScenes;

		private NetworkManager _networkManager;

		private const byte MINIMUM_PAST_INPUTS = 2;

		internal const byte MAXIMUM_PAST_INPUTS = 15;

		private const ushort MINIMUM_REPLICATE_QUEUE_SIZE = 10;

		private const ushort MAXIMUM_REPLICATE_QUEUE_SIZE = 500;

		public uint LastReconcileTick { get; internal set; }

		public uint LastReplicateTick { get; internal set; }

		internal bool UsingRigidbodies => false;

		public ushort QueuedInputs => 0;

		internal bool DropExcessiveReplicates => false;

		internal byte MaximumReplicateConsumeCount => 0;

		internal ushort MaximumClientReplicates => 0;

		internal byte RedundancyCount => 0;

		public event Action<NetworkBehaviour> OnPreReconcile
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

		public event Action<NetworkBehaviour> OnPostReconcile
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

		public event Action<uint, PhysicsScene, PhysicsScene2D> OnPreReplicateReplay
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

		public event Action<uint, PhysicsScene, PhysicsScene2D> OnPostReplicateReplay
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

		public event Action<NetworkBehaviour> OnPreServerReconcile
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

		public event Action<NetworkBehaviour> OnPostServerReconcile
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

		public bool IsReplaying()
		{
			return false;
		}

		public bool IsReplaying(Scene scene)
		{
			return false;
		}

		public ushort GetMaximumServerReplicates()
		{
			return 0;
		}

		public void SetMaximumServerReplicates(ushort value)
		{
		}

		internal bool GetAllowPredictedSpawning()
		{
			return false;
		}

		internal byte GetReservedObjectIds()
		{
			return 0;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		internal void InitializeOnce(NetworkManager manager)
		{
		}

		private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs obj)
		{
		}

		internal void InvokeServerReconcile(NetworkBehaviour caller, bool before)
		{
		}

		[APIExclude]
		public void AddRigidbodyCount(UnityEngine.Component c)
		{
		}

		[APIExclude]
		public void RemoveRigidbodyCount(UnityEngine.Component c)
		{
		}

		[APIExclude]
		[CodegenMakePublic]
		public void InvokeOnReconcile(NetworkBehaviour nb, bool before)
		{
		}

		[APIExclude]
		internal void InvokeOnReplicateReplay(Scene scene, uint tick, PhysicsScene ps, PhysicsScene2D ps2d, bool before)
		{
		}

		private void SceneManager_sceneUnloaded(Scene s)
		{
		}
	}
}
