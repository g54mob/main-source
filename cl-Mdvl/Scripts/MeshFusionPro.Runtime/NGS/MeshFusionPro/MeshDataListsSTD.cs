using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class MeshDataListsSTD : CombinedMeshDataInternal
	{
		private CombinedMesh _root;

		private List<Vector3> _vertices;

		private List<Vector3> _normals;

		private List<Vector4> _tangents;

		private List<Color32> _colors;

		private List<Bounds> _partsBounds;

		private List<Bounds> _partsBoundsLocal;

		public List<Vector3> Vertices => _vertices;

		public List<Vector3> Normals => _normals;

		public List<Vector4> Tangents => _tangents;

		public List<Color32> Colors => _colors;

		public List<Bounds> PartsBounds => _partsBounds;

		public List<Bounds> PartsBoundsLocal => _partsBoundsLocal;

		public Bounds Bounds { get; set; }

		public override Bounds GetBounds()
		{
			return Bounds;
		}

		public override Bounds GetBounds(CombinedMeshPart part)
		{
			return _partsBounds[part.Index];
		}

		public void ApplyDataToMesh()
		{
			Mesh mesh = _root.Mesh;
			mesh.SetVertices(_vertices);
			mesh.SetNormals(_normals);
			mesh.SetTangents(_tangents);
			mesh.SetColors(_colors);
			mesh.bounds = Bounds;
		}

		protected override void OnInitialized()
		{
			_root = base.Root;
			_vertices = new List<Vector3>();
			_normals = new List<Vector3>();
			_tangents = new List<Vector4>();
			_colors = new List<Color32>();
			_partsBounds = new List<Bounds>();
			_partsBoundsLocal = new List<Bounds>();
		}

		protected override void OnAddPart(CombinedMeshPart part, Mesh mesh, Matrix4x4 transform)
		{
			Bounds bounds = mesh.bounds;
			Bounds item = bounds.Transform(transform);
			_partsBounds.Add(item);
			_partsBoundsLocal.Add(bounds);
		}

		protected override void OnRemovePart(CombinedMeshPart part)
		{
			_partsBounds.RemoveAt(part.Index);
			_partsBoundsLocal.RemoveAt(part.Index);
		}

		protected override void OnMeshUpdated()
		{
			Mesh mesh = _root.Mesh;
			mesh.GetVertices(_vertices);
			mesh.GetNormals(_normals);
			mesh.GetTangents(_tangents);
			mesh.GetColors(_colors);
			Bounds = mesh.bounds;
		}
	}
}
