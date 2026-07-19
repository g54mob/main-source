using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UnityEngine;

namespace VRM
{
	public class PreviewSceneManager : MonoBehaviour
	{
		public GameObject Prefab;

		private MeshPreviewItem[] m_meshes;

		private MeshPreviewItem[] m_blendShapeMeshes;

		private Dictionary<string, MaterialItem> m_materialMap = new Dictionary<string, MaterialItem>();

		private string[] m_rendererPathList;

		private string[] m_skinnedMeshRendererPathList;

		public Transform m_target;

		public IEnumerable<MeshPreviewItem> EnumRenderItems
		{
			get
			{
				if (m_meshes != null)
				{
					MeshPreviewItem[] meshes = m_meshes;
					for (int i = 0; i < meshes.Length; i++)
					{
						yield return meshes[i];
					}
				}
			}
		}

		public string[] MaterialNames { get; private set; }

		public string[] RendererPathList => m_rendererPathList;

		public string[] SkinnedMeshRendererPathList => m_skinnedMeshRendererPathList;

		public Vector3 TargetPosition
		{
			get
			{
				if (m_target == null)
				{
					return new Vector3(0f, 1.4f, 0f);
				}
				return m_target.position + new Vector3(0f, 0.1f, 0f);
			}
		}

		public void Clean()
		{
			foreach (KeyValuePair<string, MaterialItem> item in m_materialMap)
			{
				UnityEngine.Object.DestroyImmediate(item.Value.Material);
			}
		}

		private void Initialize(GameObject prefab)
		{
			Prefab = prefab;
			List<string> materialNames = new List<string>();
			Dictionary<Material, Material> map = new Dictionary<Material, Material>();
			Func<Material, Material> getOrCreateMaterial = delegate(Material src)
			{
				if (src == null)
				{
					return (Material)null;
				}
				if (string.IsNullOrEmpty(src.name))
				{
					return (Material)null;
				}
				if (!map.TryGetValue(src, out var value))
				{
					value = new Material(src);
					map.Add(src, value);
					materialNames.Add(src.name);
					m_materialMap.Add(src.name, MaterialItem.Create(value));
				}
				return value;
			};
			m_meshes = (from x in base.transform.Traverse()
				select MeshPreviewItem.Create(x, base.transform, getOrCreateMaterial) into x
				where x != null
				select x).ToArray();
			MaterialNames = materialNames.ToArray();
			m_blendShapeMeshes = m_meshes.Where((MeshPreviewItem x) => x.SkinnedMeshRenderer != null && x.SkinnedMeshRenderer.sharedMesh.blendShapeCount > 0).ToArray();
			m_rendererPathList = m_meshes.Select((MeshPreviewItem x) => x.Path).ToArray();
			m_skinnedMeshRendererPathList = (from x in m_meshes
				where x.SkinnedMeshRenderer != null
				select x.Path).ToArray();
			Animator component = GetComponent<Animator>();
			if (component != null)
			{
				Transform boneTransform = component.GetBoneTransform(HumanBodyBones.Head);
				if (boneTransform != null)
				{
					m_target = boneTransform;
				}
			}
		}

		public string[] GetBlendShapeNames(int blendShapeMeshIndex)
		{
			if (blendShapeMeshIndex >= 0 && blendShapeMeshIndex < m_blendShapeMeshes.Length)
			{
				return m_blendShapeMeshes[blendShapeMeshIndex].BlendShapeNames;
			}
			return null;
		}

		public MaterialItem GetMaterialItem(string materialName)
		{
			if (!m_materialMap.TryGetValue(materialName, out var value))
			{
				return null;
			}
			return value;
		}

		public void SetupCamera(Camera camera, Vector3 target, float yaw, float pitch, Vector3 position)
		{
			camera.backgroundColor = Color.gray;
			camera.clearFlags = CameraClearFlags.Color;
			camera.fieldOfView = 27f;
			camera.nearClipPlane = 0.3f;
			camera.farClipPlane = (0f - position.z) * 2.1f;
			Matrix4x4 matrix4x = Matrix4x4.Translate(position);
			Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(pitch, yaw, 0f), Vector3.one) * matrix4x;
			camera.transform.position = target + matrix.ExtractPosition();
			camera.transform.rotation = matrix.ExtractRotation();
		}
	}
}
