using System;
using System.Collections.Generic;

namespace GRP
{
	[Serializable]
	public class RattleBankImpactVolume
	{
		public float volume;

		public List<RattleBankImpactVelocity> items;
	}
}
