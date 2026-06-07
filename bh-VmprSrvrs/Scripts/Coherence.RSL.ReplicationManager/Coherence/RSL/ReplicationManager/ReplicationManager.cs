using System;
using System.Collections.Generic;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.RSL.Brisk.Connection;
using Coherence.RSL.EntityManager;
using Coherence.RSL.EntityManager.Commands;
using Coherence.RSL.EntityManager.Requests;
using Coherence.RSL.Tickers;
using Coherence.RSL.Transport;

namespace Coherence.RSL.ReplicationManager
{
	public class ReplicationManager : IReplicationManager, IDisposable
	{
		private IExtendedDefinition root;

		private List<UserChannel> userChannels;

		private Dictionary<uint, UserChannel> userChannelByParticipant;

		private Coherence.RSL.EntityManager.EntityManager entityManager;

		private double minQueryDistance;

		private int sendFrequency;

		private ITickProviderFactory tickProviderFactory;

		private Logger logger;

		private bool persistenceReady;

		private List<ResponseInfo> responsesBuffer;

		private List<CommandResponse> commandResponsesBuffer;

		private List<IClientMessage> generatedMessagesBuffer;

		private readonly CacheList<IBaseRequest> requestBuffer;

		public bool PersistenceReady => false;

		public ReplicationManager(double minQueryDistance, int sendFrequency, IExtendedDefinition root, HostAuthority hostAuthority, Logger logger, ITickProviderFactory tickProviderFactory = null)
		{
		}

		public void Dispose()
		{
		}

		public void AddClient(IUserConnection userConnection, ClientID clientID)
		{
		}

		public void RemoveClient(ConnectionID CID)
		{
		}

		public void Tick()
		{
		}

		private void HandleRequestResponses(List<IBaseRequest> requestBuffer, List<ResponseInfo> responses)
		{
		}

		private void HandlePersistenceReadyCommand(CommandResponse response)
		{
		}

		private void HandleCommandResponses(List<CommandResponse> responses)
		{
		}

		private void HandleInputResponse(CommandResponse response)
		{
		}

		private void HandleClientMessages(List<IClientMessage> messages)
		{
		}
	}
}
