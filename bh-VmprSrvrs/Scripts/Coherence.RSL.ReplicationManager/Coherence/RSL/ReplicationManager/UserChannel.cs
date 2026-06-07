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
	public class UserChannel : IDisposable
	{
		private IUserConnection userConnection;

		private EntityMapper mapper;

		private InConnection inConnection;

		private OutConnection outConnection;

		private Logger logger;

		private readonly CacheList<InternalDestroy> internalDestroys;

		public ConnectionID CID => default(ConnectionID);

		public uint Participant => 0u;

		public ConnectionType Type => default(ConnectionType);

		public UserChannel(ClientID clientID, int sendFrequency, double minQueryDistance, IUserConnection userConnection, Coherence.RSL.EntityManager.EntityManager entityManager, IExtendedDefinition root, Logger logger, List<ResponseInfo> responses, List<IClientMessage> generatedMessages, ITickProviderFactory tickProviderFactory = null)
		{
		}

		public void Dispose()
		{
		}

		public void UpdateReceiving(List<IBaseRequest> requestBuffer)
		{
		}

		public void UpdateSending()
		{
		}

		public IReadOnlyList<IBaseRequest> HandleWorldResponse(IReadOnlyList<ResponseInfo> responses)
		{
			return null;
		}

		public void HandleCommand(IEntityMessage command)
		{
		}

		public void HandleInput(IEntityMessage input)
		{
		}

		public void HandleClientMessage(IClientMessage message)
		{
		}
	}
}
