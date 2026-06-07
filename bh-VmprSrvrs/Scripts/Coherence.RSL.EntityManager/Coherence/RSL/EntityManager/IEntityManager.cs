using System.Collections.Generic;
using Coherence.ProtocolDef;
using Coherence.RSL.EntityManager.Commands;
using Coherence.RSL.EntityManager.Query;
using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.EntityManager
{
	public interface IEntityManager
	{
		void OnParticipantJoin(ParticipantInfo info, List<ResponseInfo> responses, List<IClientMessage> generatedMessages);

		void OnParticipantLeave(uint participant, List<ResponseInfo> responses, List<IClientMessage> generatedMessages);

		void HandleEntityRequests(List<IBaseRequest> requests, List<ResponseInfo> responses, List<CommandResponse> commandResponses, List<IClientMessage> generatedMessages);

		QueryResponse HandleClientQuery(ClientQuery clientQuery);

		IRequestManager RequestManager();
	}
}
