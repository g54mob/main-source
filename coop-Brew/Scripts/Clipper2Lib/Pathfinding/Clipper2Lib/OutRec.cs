using System.Collections.Generic;

namespace Pathfinding.Clipper2Lib
{
	internal class OutRec
	{
		public int idx;

		public OutRec? owner;

		public Active? frontEdge;

		public Active? backEdge;

		public OutPt? pts;

		public PolyPathBase? polypath;

		public Rect64 bounds;

		public List<Point64> path;

		public bool isOpen;

		public List<int>? splits;

		public OutRec? recursiveSplit;
	}
}
