using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.EntityManager.Query
{
	public interface IClientQueryHandler
	{
		QueryResponse HandleClientQuery(ClientQuery clientQuery);

		IRequestManager RequestManager();
	}
}
