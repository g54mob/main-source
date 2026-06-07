using System.Collections.Generic;

namespace External.Zalgo2462.VoronoiLib.Structures
{
	public class FortuneSite
	{
		public double X { get; protected set; }

		public double Y { get; protected set; }

		public List<VEdge> Cell { get; private set; }

		public List<FortuneSite> Neighbors { get; private set; }

		public FortuneSite(double x, double y)
		{
			X = x;
			Y = y;
			Cell = new List<VEdge>();
			Neighbors = new List<FortuneSite>();
		}
	}
}
