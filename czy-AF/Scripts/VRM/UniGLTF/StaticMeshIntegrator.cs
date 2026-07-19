using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniGLTF
{
	public static class StaticMeshIntegrator
	{
		private class Integrator
		{
			private List<Vector3> m_positions = new List<Vector3>();

			private List<Vector3> m_normals = new List<Vector3>();

			private List<Vector2> m_uv = new List<Vector2>();

			private List<int[]> m_subMeshes = new List<int[]>();

			private List<Material> m_materials = new List<Material>();

			public List<Material> Materials => m_materials;

			public void Push(Matrix4x4 localToRoot, Mesh mesh, Material[] materials)
			{
				int offset = m_positions.Count;
				bool flag = m_normals.Count == m_positions.Count;
				bool flag2 = m_uv.Count == m_positions.Count;
				m_positions.AddRange(mesh.vertices.Select((Vector3 x) => localToRoot.MultiplyPoint(x)));
				if (mesh.normals != null && mesh.normals.Length == mesh.vertexCount)
				{
					if (!flag)
					{
						for (int num = m_normals.Count; num < m_positions.Count; num++)
						{
							m_normals.Add(Vector3.zero);
						}
					}
					m_normals.AddRange(mesh.normals.Select((Vector3 x) => localToRoot.MultiplyVector(x)));
				}
				if (mesh.uv != null && mesh.uv.Length == mesh.vertexCount)
				{
					if (!flag2)
					{
						for (int num2 = m_uv.Count; num2 < m_positions.Count; num2++)
						{
							m_uv.Add(Vector2.zero);
						}
					}
					m_uv.AddRange(mesh.uv);
				}
				for (int num3 = 0; num3 < mesh.subMeshCount; num3++)
				{
					m_subMeshes.Add((from x in mesh.GetIndices(num3)
						select offset + x).ToArray());
				}
				m_materials.AddRange(materials);
			}

			public Mesh ToMesh()
			{
				Mesh mesh = new Mesh();
				mesh.name = "integrated";
				mesh.vertices = m_positions.ToArray();
				if (m_normals.Count > 0)
				{
					if (m_normals.Count < m_positions.Count)
					{
						for (int i = m_normals.Count; i < m_positions.Count; i++)
						{
							m_normals.Add(Vector3.zero);
						}
					}
					mesh.normals = m_normals.ToArray();
				}
				if (m_uv.Count > 0)
				{
					if (m_uv.Count < m_positions.Count)
					{
						for (int j = m_uv.Count; j < m_positions.Count; j++)
						{
							m_uv.Add(Vector2.zero);
						}
					}
					mesh.uv = m_uv.ToArray();
				}
				mesh.subMeshCount = m_subMeshes.Count;
				for (int k = 0; k < m_subMeshes.Count; k++)
				{
					mesh.SetIndices(m_subMeshes[k], MeshTopology.Triangles, k);
				}
				return mesh;
			}
		}

		public struct MeshWithMaterials
		{
			public Mesh Mesh;

			public Material[] Materials;
		}

		private const string ASSET_SUFFIX = ".mesh.asset";

		public static MeshWithMaterials Integrate(Transform root)
		{
			Integrator integrator = new Integrator();
			foreach (Transform item in root.Traverse())
			{
				MeshRenderer component = item.GetComponent<MeshRenderer>();
				MeshFilter component2 = item.GetComponent<MeshFilter>();
				if (component != null && component2 != null && component2.sharedMesh != null && component.sharedMaterials != null && component.sharedMaterials.Length == component2.sharedMesh.subMeshCount)
				{
					integrator.Push(root.worldToLocalMatrix * item.localToWorldMatrix, component2.sharedMesh, component.sharedMaterials);
				}
			}
			return new MeshWithMaterials
			{
				Mesh = integrator.ToMesh(),
				Materials = integrator.Materials.ToArray()
			};
		}
	}
}
