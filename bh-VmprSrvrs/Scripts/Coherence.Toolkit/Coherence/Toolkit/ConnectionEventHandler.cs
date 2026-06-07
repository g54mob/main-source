using System;
using Coherence.Connection;
using UnityEngine;
using UnityEngine.Events;

namespace Coherence.Toolkit
{
	[NonBindable]
	[Obsolete("ConnectionEventHandler is being deprecated, and will be completely removed in future releases.")]
	[Deprecated("17/03/2024", 1, 6, 0)]
	public sealed class ConnectionEventHandler : CoherenceBehaviour
	{
		[Tooltip("Additionally registers the CoherenceBridge associated by the CoherenceScene (in the target scene)")]
		public CoherenceSceneLoader loader;

		private CoherenceBridge bridge;

		[Header("Client")]
		public GameObject[] deactivateOnClientConnected;

		public GameObject[] destroyOnClientConnected;

		public UnityEvent<CoherenceBridge> onClientConnected;

		public UnityEvent<CoherenceBridge, ConnectionCloseReason> onClientDisconnected;

		[Header("Simulator")]
		public GameObject[] deactivateOnSimulatorConnected;

		public GameObject[] destroyOnSimulatorConnected;

		public UnityEvent<CoherenceBridge> onSimulatorConnected;

		public UnityEvent<CoherenceBridge, ConnectionCloseReason> onSimulatorDisconnected;

		[Header("Global")]
		public GameObject[] deactivateOnConnected;

		public GameObject[] destroyOnConnected;

		public UnityEvent<CoherenceBridge> onConnected;

		public UnityEvent<CoherenceBridge, ConnectionCloseReason> onDisconnected;

		private ConnectionEventHandler()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Register(CoherenceBridge bridge)
		{
		}

		private void Unregister(CoherenceBridge bridge)
		{
		}

		private void OnConnected(CoherenceBridge bridge)
		{
		}

		private void OnDisconnected(CoherenceBridge bridge, ConnectionCloseReason closeReason)
		{
		}

		private void OnClientConnected(CoherenceBridge bridge)
		{
		}

		private void OnClientDisconnected(CoherenceBridge bridge, ConnectionCloseReason closeReason)
		{
		}

		private void OnSimulatorConnected(CoherenceBridge bridge)
		{
		}

		private void OnSimulatorDisconnected(CoherenceBridge bridge, ConnectionCloseReason closeReason)
		{
		}
	}
}
