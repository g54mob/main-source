using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	[Serializable]
	public class MeshPreviewItem
	{
		private Transform m_transform;

		public string Path { get; private set; }

		public SkinnedMeshRenderer SkinnedMeshRenderer { get; private set; }

		public Mesh Mesh { get; private set; }

		public string[] BlendShapeNames { get; private set; }

		public int BlendShapeCount => BlendShapeNames.Length;

		public Material[] Materials { get; private set; }

		public Vector3 Position => m_transform.position;

		public Quaternion Rotation => m_transform.rotation;

		private MeshPreviewItem(string path, Transform transform, Material[] materials)
		{
			Path = path;
			m_transform = transform;
			Materials = materials;
		}

		public void Bake(IEnumerable<BlendShapeBinding> values, float weight)
		{
			if (SkinnedMeshRenderer == null)
			{
				return;
			}
			if (values != null)
			{
				for (int i = 0; i < BlendShapeCount; i++)
				{
					SkinnedMeshRenderer.SetBlendShapeWeight(i, 0f);
				}
				foreach (BlendShapeBinding value in values)
				{
					if (value.RelativePath == Path)
					{
						if (value.Index >= 0 && value.Index < SkinnedMeshRenderer.sharedMesh.blendShapeCount)
						{
							SkinnedMeshRenderer.SetBlendShapeWeight(value.Index, value.Weight * weight);
							continue;
						}
						Debug.LogWarningFormat("Out of range {0}: 0 <= {1} < {2}", SkinnedMeshRenderer.name, value.Index, SkinnedMeshRenderer.sharedMesh.blendShapeCount);
					}
				}
			}
			SkinnedMeshRenderer.BakeMesh(Mesh);
		}

		public static MeshPreviewItem Create(Transform t, Transform root, Func<Material, Material> getOrCreateMaterial)
		{
			MeshFilter component = t.GetComponent<MeshFilter>();
			MeshRenderer component2 = t.GetComponent<MeshRenderer>();
			SkinnedMeshRenderer component3 = t.GetComponent<SkinnedMeshRenderer>();
			if (component != null && component2 != null)
			{
				component2.sharedMaterials = component2.sharedMaterials.Select((Material x) => getOrCreateMaterial(x)).ToArray();
				return new MeshPreviewItem(t.RelativePathFrom(root), t, component2.sharedMaterials)
				{
					Mesh = component.sharedMesh
				};
			}
			if (component3 != null)
			{
				component3.sharedMaterials = component3.sharedMaterials.Select((Material x) => getOrCreateMaterial(x)).ToArray();
				if (component3.sharedMesh.blendShapeCount > 0)
				{
					Mesh sharedMesh = component3.sharedMesh;
					return new MeshPreviewItem(t.RelativePathFrom(root), t, component3.sharedMaterials)
					{
						SkinnedMeshRenderer = component3,
						Mesh = new Mesh(),
						BlendShapeNames = (from x in Enumerable.Range(0, sharedMesh.blendShapeCount)
							select sharedMesh.GetBlendShapeName(x)).ToArray()
					};
				}
				return new MeshPreviewItem(t.RelativePathFrom(root), t, component3.sharedMaterials)
				{
					Mesh = component3.sharedMesh
				};
			}
			return null;
		}
	}
}
