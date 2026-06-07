using System.Collections.Generic;
using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Requests
{
	public class RemoveComponentsRequest : RequestInfo
	{
		private List<uint> compTypes;

		public RemoveComponentsRequest(Entity entity, uint participant, FloatingOrigin origin, EntityMeta meta, bool isInternal, IReadOnlyList<uint> compTypes)
			: base(default(Entity), 0u, default(FloatingOrigin), default(EntityMeta), isInternal: false)
		{
		}

		public List<uint> GetComponentTypes()
		{
			return null;
		}

		public void RemoveComponentType(int index)
		{
		}

		public void AppendComponentTypes(IReadOnlyList<uint> newTypes)
		{
		}
	}
}
