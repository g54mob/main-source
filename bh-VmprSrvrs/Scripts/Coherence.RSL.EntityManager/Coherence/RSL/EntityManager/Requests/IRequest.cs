using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;

namespace Coherence.RSL.EntityManager.Requests
{
	public interface IRequest : IBaseRequest
	{
		Entity GetEntity();

		uint GetParticipant();

		FloatingOrigin GetFloatingOrigin();

		void SetFloatingOrigin(FloatingOrigin origin);

		EntityMeta GetMeta();

		bool GetIsInternal();

		IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Logger logger);

		RefsInfo GetReferenceInfo();
	}
}
