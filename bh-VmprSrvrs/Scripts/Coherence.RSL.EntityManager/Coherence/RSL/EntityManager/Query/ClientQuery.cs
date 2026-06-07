using System.Collections.Generic;
using Coherence.RSL.EntityManager.Requests;

namespace Coherence.RSL.EntityManager.Query
{
	public struct ClientQuery
	{
		public uint Participant;

		public List<IFilter> Queries;

		public FloatingOrigin Origin;
	}
}
