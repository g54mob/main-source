using System.Runtime.InteropServices;
using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Query
{
	[StructLayout((LayoutKind)0, Size = 1)]
	public struct GlobalQuery : IFilter
	{
		public bool Contains(Entity _, EntityMeta meta)
		{
			return false;
		}

		public void Update(ICoherenceComponentData comp, IExtendedDefinition root)
		{
		}
	}
}
