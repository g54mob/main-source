using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.ProtocolDef
{
	public interface IEntityMessage : IBaseRequest
	{
		Entity Entity { get; set; }

		MessageTarget Routing { get; set; }

		uint Sender { get; set; }

		uint GetComponentType();

		IEntityMessage Clone();

		IEntityMapper.Error MapToAbsolute(IEntityMapper mapper, Logger logger);

		IEntityMapper.Error MapToRelative(IEntityMapper mapper, Logger logger);

		HashSet<Entity> GetEntityRefs();

		void NullEntityRefs(Entity entity);
	}
}
