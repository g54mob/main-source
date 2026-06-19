using System.Collections.Generic;
using UnityEngine;

namespace SimplySVG
{
	public interface Triangulatable
	{
		bool Triangulate(CascadeContext parentCascadeContext, ImportSettings options, ref List<Vector3> meshVertices, ref List<int> meshTriangles, ref List<Color> meshVertexColors);
	}
}
