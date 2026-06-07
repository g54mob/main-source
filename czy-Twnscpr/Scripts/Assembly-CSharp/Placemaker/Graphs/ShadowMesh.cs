using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Graphs
{
	[SelectionBase]
	public class ShadowMesh : MonoBehaviour
	{
		public List<Vector3> shadowMeshVerts;

		public List<Vector2> shadowMeshUvs;

		public List<int> shadowMeshTris;

		public bool dirty;

		public Mesh mesh;
	}
}
