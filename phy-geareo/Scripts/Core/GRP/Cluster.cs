using System.Collections.Generic;

namespace GRP
{
	public class Cluster
	{
		public PhysicsBody body;

		public SimShape anchor;

		public List<ClusterItem> group;

		public List<ClusterItem> others;
	}
}
