using System;
using Coherence.Connection;
using Coherence.Entities;
using Coherence.Log;
using UnityEngine;

namespace Coherence.Toolkit
{
	public class CoherenceClientConnection
	{
		private NetworkEntityState networkEntity;

		private ICoherenceBridge bridge;

		private readonly Entity entityId;

		private Coherence.Log.Logger logger;

		public bool IsMyConnection { get; }

		public ClientID ClientId { get; }

		public ConnectionType Type { get; }

		public GameObject GameObject => null;

		public Entity EntityId => default(Entity);

		public ICoherenceBridge CoherenceBridge => null;

		public CoherenceSync Sync => null;

		public NetworkEntityState NetworkEntity => null;

		internal CoherenceClientConnection(ICoherenceBridge bridge, Entity entityId, ClientID clientId, ConnectionType type, bool isMine)
		{
		}

		internal CoherenceClientConnection(ICoherenceBridge bridge, NetworkEntityState networkEntity, Entity entityId, ClientID clientId, ConnectionType type)
		{
		}

		private void PrintConditionalWarning(string prop)
		{
		}

		public bool SendClientMessage<TTarget>(string methodName, MessageTarget target, params object[] args) where TTarget : Component
		{
			return false;
		}

		public bool SendClientMessage(Type targetType, string methodName, MessageTarget target, params object[] args)
		{
			return false;
		}

		public bool SendClientMessage<TTarget>(string methodName, Entity entityID, MessageTarget target, params object[] args) where TTarget : Component
		{
			return false;
		}

		public bool SendClientMessage(Type targetType, string methodName, Entity entityID, MessageTarget target, params object[] args)
		{
			return false;
		}

		public bool SendClientMessage<TTarget>(string methodName, ClientID clientID, MessageTarget target, params object[] args) where TTarget : Component
		{
			return false;
		}

		public bool SendClientMessage(Type targetType, string methodName, ClientID clientID, MessageTarget target, params object[] args)
		{
			return false;
		}

		internal void SendConnectionSceneUpdate(uint newSceneIndex)
		{
		}
	}
}
