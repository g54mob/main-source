using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public class DefsElement : SVGElement
	{
		public override bool Triangulate(CascadeContext parentCascadeContext, ImportSettings options, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors)
		{
			return true;
		}
	}
}
