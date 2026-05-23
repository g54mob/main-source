using System.Collections.Generic;

namespace LVA.Limbs
{
	public struct LimbPhysicsInternalReferences
	{
		public readonly xj rbProvider;

		public readonly IReadOnlyCollection<xg> limbColliders;

		public LimbPhysicsInternalReferences(xj rbProvider, IReadOnlyCollection<xg> limbColliders)
		{
			this.rbProvider = null;
			this.limbColliders = null;
		}
	}
}
