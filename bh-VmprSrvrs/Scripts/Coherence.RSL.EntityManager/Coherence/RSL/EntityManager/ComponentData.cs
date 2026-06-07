using System.Collections.Generic;
using Coherence.Entities;
using Coherence.Log;

namespace Coherence.RSL.EntityManager
{
	public class ComponentData
	{
		private Dictionary<uint, ICoherenceComponentData> components;

		public void Update(ICoherenceComponentData[] comps, Logger logger)
		{
		}

		public bool TryGetComponent(uint compType, out ICoherenceComponentData comp)
		{
			comp = null;
			return false;
		}

		public void Remove(IReadOnlyList<uint> compTypes)
		{
		}

		public ICoherenceComponentData[] GetComponents()
		{
			return null;
		}
	}
}
