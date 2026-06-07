using System.Collections.Generic;
using UnityEngine;

namespace CompassNavigatorPro
{
	public static class MeshUtils
	{
		private static Mesh _quadMesh;

		public static Mesh quadMesh
		{
			get
			{
				if (_quadMesh != null)
				{
					return _quadMesh;
				}
				_quadMesh = new Mesh();
				_quadMesh.SetVertices(new List<Vector3>
				{
					new Vector3(-1f, -1f, 0f),
					new Vector3(-1f, 1f, 0f),
					new Vector3(1f, -1f, 0f),
					new Vector3(1f, 1f, 0f)
				});
				_quadMesh.SetUVs(0, new List<Vector2>
				{
					new Vector2(0f, 0f),
					new Vector2(0f, 1f),
					new Vector2(1f, 0f),
					new Vector2(1f, 1f)
				});
				_quadMesh.SetIndices(new int[6] { 0, 1, 2, 2, 1, 3 }, MeshTopology.Triangles, 0, calculateBounds: false);
				_quadMesh.UploadMeshData(markNoLongerReadable: true);
				return _quadMesh;
			}
		}
	}
}
