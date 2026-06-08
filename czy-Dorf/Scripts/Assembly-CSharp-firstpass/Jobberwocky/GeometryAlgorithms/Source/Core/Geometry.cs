using UnityEngine;
using UnityEngine.Rendering;

namespace Jobberwocky.GeometryAlgorithms.Source.Core
{
	public class Geometry
	{
		private Vertex[] _003CVertices_003Ek__BackingField;

		private int[] _003CIndices_003Ek__BackingField;

		private MeshTopology _003CTopology_003Ek__BackingField;

		private Geometry[] _003CCells_003Ek__BackingField;

		public Vertex[] Vertices
		{
			get
			{
				return _003CVertices_003Ek__BackingField;
			}
			set
			{
				_003CVertices_003Ek__BackingField = value;
			}
		}

		public int[] Indices
		{
			get
			{
				return _003CIndices_003Ek__BackingField;
			}
			set
			{
				_003CIndices_003Ek__BackingField = value;
			}
		}

		public MeshTopology Topology
		{
			get
			{
				return _003CTopology_003Ek__BackingField;
			}
			set
			{
				_003CTopology_003Ek__BackingField = value;
			}
		}

		public Geometry[] Cells
		{
			get
			{
				return _003CCells_003Ek__BackingField;
			}
			set
			{
				_003CCells_003Ek__BackingField = value;
			}
		}

		public Geometry()
		{
			Topology = MeshTopology.Triangles;
		}

		public Mesh ToUnityMesh()
		{
			Mesh mesh = new Mesh();
			if (Vertices != null)
			{
				Vector3[] array = new Vector3[Vertices.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Vertices[i].Position;
				}
				mesh.vertices = array;
				if (Indices != null)
				{
					if (Indices.Length > 65535)
					{
						mesh.indexFormat = IndexFormat.UInt32;
					}
					mesh.SetIndices(Indices, Topology, 0);
					if (Topology == MeshTopology.Triangles)
					{
						mesh.RecalculateNormals();
					}
				}
			}
			return mesh;
		}
	}
}
