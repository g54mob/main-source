using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Connection;
using Coherence.Log;
using UnityEngine;
using UnityEngine.Serialization;

namespace Coherence.Toolkit
{
	public abstract class CoherenceInputSimulation<TState> : MonoBehaviour
	{
		[FormerlySerializedAs("monoBridge")]
		[Tooltip("Bridge used by the SimulationCore. If null, will be searched for using the resolver function and a CoherenceBridgeStore.")]
		public CoherenceBridge coherenceBridge;

		[Tooltip("If set to true, the simulation will automatically handle pausing, stopping the fixed simulation updates when needed.")]
		public bool PauseAutomatically;

		private CoherenceInputManager inputManager;

		private readonly Coherence.Log.Logger logger;

		private readonly SortedList<ClientID, CoherenceClientConnection> allClients;

		private readonly Dictionary<ClientID, CoherenceClientConnection> clientById;

		protected IClient CoherenceClient => null;

		protected CoherenceClientConnection LocalClient { get; private set; }

		protected IList<CoherenceClientConnection> AllClients => null;

		protected SimulationStateStore<TState> StateStore { get; }

		protected float FixedTimeStep => 0f;

		protected long CurrentSimulationFrame => 0L;

		protected bool SimulationEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected CoherenceInputDebugger Debugger { get; private set; }

		public event CoherenceBridgeResolver<CoherenceInputSimulation<TState>> BridgeResolve
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

		protected abstract void SetInputs(CoherenceClientConnection client);

		protected abstract void Simulate(long simulationFrame);

		protected abstract void Rollback(long toFrame, TState state);

		protected abstract TState CreateState();

		protected virtual void OnClientJoined(CoherenceClientConnection client)
		{
		}

		protected virtual void OnClientLeft(CoherenceClientConnection client)
		{
		}

		protected virtual void OnBeforeSimulate()
		{
		}

		protected virtual void OnConnected()
		{
		}

		protected virtual void OnDisconnected()
		{
		}

		protected virtual void OnPauseChange(bool isPaused)
		{
		}

		protected virtual void OnStart()
		{
		}

		protected virtual void Destroy()
		{
		}

		protected bool TryGetClient(ClientID clientId, out CoherenceClientConnection client)
		{
			client = null;
			return false;
		}

		protected void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void HandleConnected(ClientID _)
		{
		}

		private void HandleDisconnected(ConnectionCloseReason unused)
		{
		}

		private void HandlePauseChange(bool isPaused)
		{
		}

		private void FixedNetworkUpdate()
		{
		}

		private void LateFixedNetworkUpdate()
		{
		}

		private void SaveState(long simulationFrame)
		{
		}

		private void HandleConnectionCreated(CoherenceClientConnection connection)
		{
		}

		private void HandleConnectionDestroyed(CoherenceClientConnection connection)
		{
		}
	}
}
