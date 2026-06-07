using Coherence.Entities;

namespace Coherence.RSL.EntityManager.Query
{
	public struct TagQuery : IFilter
	{
		private string tag;

		public string Tag => null;

		public TagQuery(string tag)
		{
			this.tag = null;
		}

		public bool Contains(Entity _, EntityMeta meta)
		{
			return false;
		}

		public void Update(ICoherenceComponentData comp, IExtendedDefinition root)
		{
		}
	}
}
