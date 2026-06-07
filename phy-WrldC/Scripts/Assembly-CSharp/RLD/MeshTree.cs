using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class MeshTree
	{
		private RTMesh _mesh;

		private SphereTree<MeshTriangle> _tree = new SphereTree<MeshTriangle>(2);

		private bool _isBuilt;

		public bool IsBuilt => _isBuilt;

		public MeshTree(RTMesh mesh)
		{
			_mesh = mesh;
		}

		public void Build()
		{
			if (!_isBuilt)
			{
				for (int i = 0; i < _mesh.NumTriangles; i++)
				{
					MeshTriangle triangle = _mesh.GetTriangle(i);
					_tree.AddNode(triangle, new Sphere(triangle.Vertices));
				}
				_isBuilt = true;
			}
		}

		public List<Vector3> OverlapVerts(OBB obb, MeshTransform meshTransform)
		{
			if (!_isBuilt)
			{
				Build();
			}
			OBB box = meshTransform.InverseTransformOBB(obb);
			HashSet<int> hashSet = new HashSet<int>();
			List<SphereTreeNode<MeshTriangle>> list = _tree.OverlapBox(box);
			if (list.Count == 0)
			{
				return new List<Vector3>();
			}
			List<Vector3> list2 = new List<Vector3>(50);
			foreach (SphereTreeNode<MeshTriangle> item in list)
			{
				int triangleIndex = item.Data.TriangleIndex;
				MeshTriangle triangle = _mesh.GetTriangle(triangleIndex);
				Vector3[] vertices = triangle.Vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					int vertIndex = triangle.GetVertIndex(i);
					if (!hashSet.Contains(vertIndex))
					{
						Vector3 point = vertices[i];
						if (BoxMath.ContainsPoint(point, box.Center, box.Size, box.Rotation))
						{
							list2.Add(meshTransform.TransformPoint(point));
							hashSet.Add(vertIndex);
						}
					}
				}
			}
			return list2;
		}

		public List<Vector3> OverlapModelVerts(OBB modelOBB)
		{
			if (!_isBuilt)
			{
				Build();
			}
			HashSet<int> hashSet = new HashSet<int>();
			List<SphereTreeNode<MeshTriangle>> list = _tree.OverlapBox(modelOBB);
			if (list.Count == 0)
			{
				return new List<Vector3>();
			}
			List<Vector3> list2 = new List<Vector3>(50);
			foreach (SphereTreeNode<MeshTriangle> item in list)
			{
				int triangleIndex = item.Data.TriangleIndex;
				MeshTriangle triangle = _mesh.GetTriangle(triangleIndex);
				Vector3[] vertices = triangle.Vertices;
				for (int i = 0; i < vertices.Length; i++)
				{
					int vertIndex = triangle.GetVertIndex(i);
					if (!hashSet.Contains(vertIndex))
					{
						Vector3 vector = vertices[i];
						if (BoxMath.ContainsPoint(vector, modelOBB.Center, modelOBB.Size, modelOBB.Rotation))
						{
							list2.Add(vector);
							hashSet.Add(vertIndex);
						}
					}
				}
			}
			return list2;
		}

		public MeshRayHit RaycastClosest(Ray ray, Matrix4x4 meshTransform)
		{
			if (!_isBuilt)
			{
				Build();
			}
			Ray ray2 = ray.InverseTransform(meshTransform);
			List<SphereTreeNodeRayHit<MeshTriangle>> list = _tree.RaycastAll(ray2);
			if (list.Count == 0)
			{
				return null;
			}
			float num = float.MaxValue;
			MeshTriangle meshTriangle = null;
			bool flag = false;
			foreach (SphereTreeNodeRayHit<MeshTriangle> item in list)
			{
				MeshTriangle data = item.HitNode.Data;
				if (TriangleMath.Raycast(ray2, out var t, data.Vertex0, data.Vertex1, data.Vertex2) && Vector3.Dot(ray2.direction, data.Normal) < 0f && t < num)
				{
					num = t;
					meshTriangle = data;
					flag = true;
				}
			}
			if (flag)
			{
				Vector3 vector = meshTransform.MultiplyPoint(ray2.GetPoint(num));
				num = (ray.origin - vector).magnitude / ray.direction.magnitude;
				Vector3 normalized = meshTransform.inverse.transpose.MultiplyVector(meshTriangle.Normal).normalized;
				return new MeshRayHit(ray, meshTriangle.TriangleIndex, num, normalized);
			}
			return null;
		}

		public void DebugDraw()
		{
			_tree.DebugDraw();
		}
	}
}
