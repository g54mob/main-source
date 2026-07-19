using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniGLTF
{
	public class gltfExporter : IDisposable
	{
		private const string CONVERT_HUMANOID_KEY = "VRM/UniGLTF-1.28/Export";

		private glTF glTF;

		public TextureExportManager TextureManager;

		public bool UseSparseAccessorForBlendShape { get; set; }

		public bool ExportOnlyBlendShapePosition { get; set; }

		public bool RemoveVertexColor { get; set; }

		public GameObject Copy { get; protected set; }

		public List<Mesh> Meshes { get; private set; }

		public Dictionary<Mesh, Dictionary<int, int>> MeshBlendShapeIndexMap { get; private set; }

		public List<Transform> Nodes { get; private set; }

		public List<Material> Materials { get; private set; }

		protected virtual IEnumerable<string> ExtensionUsed
		{
			get
			{
				yield return glTF_KHR_materials_unlit.ExtensionName;
				yield return glTF_KHR_texture_transform.ExtensionName;
			}
		}

		protected virtual IMaterialExporter CreateMaterialExporter()
		{
			return new MaterialExporter();
		}

		public gltfExporter(glTF gltf)
		{
			glTF = gltf;
			glTF.extensionsUsed.AddRange(ExtensionUsed);
			glTF.asset = new glTFAssets
			{
				generator = "UniGLTF-1.28",
				version = "2.0"
			};
		}

		public static glTF Export(GameObject go)
		{
			glTF glTF2 = new glTF();
			using gltfExporter gltfExporter2 = new gltfExporter(glTF2);
			gltfExporter2.Prepare(go);
			gltfExporter2.Export();
			return glTF2;
		}

		public virtual void Prepare(GameObject go)
		{
			Copy = UnityEngine.Object.Instantiate(go);
			Copy.transform.ReverseZRecursive();
		}

		public void Export()
		{
			FromGameObject(glTF, Copy, UseSparseAccessorForBlendShape, RemoveVertexColor);
		}

		public void Dispose()
		{
			if (Application.isEditor)
			{
				UnityEngine.Object.DestroyImmediate(Copy);
			}
			else
			{
				UnityEngine.Object.Destroy(Copy);
			}
		}

		private static glTFNode ExportNode(Transform x, List<Transform> nodes, List<Renderer> renderers, List<SkinnedMeshRenderer> skins)
		{
			glTFNode glTFNode2 = new glTFNode
			{
				name = x.name,
				children = (from y in x.transform.GetChildren()
					select nodes.IndexOf(y)).ToArray(),
				rotation = x.transform.localRotation.ToArray(),
				translation = x.transform.localPosition.ToArray(),
				scale = x.transform.localScale.ToArray()
			};
			if (x.gameObject.activeInHierarchy)
			{
				MeshRenderer component = x.GetComponent<MeshRenderer>();
				if (component != null)
				{
					glTFNode2.mesh = renderers.IndexOf(component);
				}
				SkinnedMeshRenderer component2 = x.GetComponent<SkinnedMeshRenderer>();
				if (component2 != null)
				{
					glTFNode2.mesh = renderers.IndexOf(component2);
					glTFNode2.skin = skins.IndexOf(component2);
				}
			}
			return glTFNode2;
		}

		private void FromGameObject(glTF gltf, GameObject go, bool useSparseAccessorForMorphTarget = false, bool removeVertexColor = false)
		{
			ArrayByteBuffer bytesBuffer = new ArrayByteBuffer(new byte[52428800]);
			int bufferIndex = gltf.AddBuffer(bytesBuffer);
			GameObject gameObject = null;
			if (go.transform.childCount == 0)
			{
				gameObject = new GameObject("tmpParent");
				go.transform.SetParent(gameObject.transform, worldPositionStays: true);
				go = gameObject;
			}
			try
			{
				Nodes = go.transform.Traverse().Skip(1).ToList();
				Materials = (from material in Nodes.SelectMany((Transform t) => t.GetSharedMaterials())
					where material != null
					select material).Distinct().ToList();
				List<TextureIO.TextureExportItem> list = (from textureExportItem2 in Materials.SelectMany((Material m) => TextureIO.GetTextures(m))
					where textureExportItem2.Texture != null
					select textureExportItem2).Distinct().ToList();
				TextureManager = new TextureExportManager(list.Select((TextureIO.TextureExportItem textureExportItem2) => textureExportItem2.Texture));
				IMaterialExporter materialExporter = CreateMaterialExporter();
				gltf.materials = Materials.Select((Material m) => materialExporter.ExportMaterial(m, TextureManager)).ToList();
				for (int num = 0; num < list.Count; num++)
				{
					TextureIO.TextureExportItem textureExportItem = list[num];
					TextureIO.ExportTexture(gltf, bufferIndex, TextureManager.GetExportTexture(num), textureExportItem.TextureType);
				}
				List<MeshWithRenderer> unityMeshes = Nodes.Select((Transform transform) => new MeshWithRenderer
				{
					Mesh = transform.GetSharedMesh(),
					Renderer = transform.GetComponent<Renderer>()
				}).Where(delegate(MeshWithRenderer meshWithRenderer)
				{
					if (meshWithRenderer.Mesh == null)
					{
						return false;
					}
					return (meshWithRenderer.Renderer.sharedMaterials != null && meshWithRenderer.Renderer.sharedMaterials.Length != 0) ? true : false;
				}).ToList();
				MeshBlendShapeIndexMap = new Dictionary<Mesh, Dictionary<int, int>>();
				foreach (var (key, item, value) in MeshExporter.ExportMeshes(gltf, bufferIndex, unityMeshes, Materials, useSparseAccessorForMorphTarget, ExportOnlyBlendShapePosition, removeVertexColor))
				{
					gltf.meshes.Add(item);
					if (!MeshBlendShapeIndexMap.ContainsKey(key))
					{
						MeshBlendShapeIndexMap.Add(key, value);
					}
				}
				Meshes = unityMeshes.Select((MeshWithRenderer meshWithRenderer) => meshWithRenderer.Mesh).ToList();
				List<SkinnedMeshRenderer> unitySkins = (from transform in Nodes
					select transform.GetComponent<SkinnedMeshRenderer>() into skinnedMeshRenderer
					where skinnedMeshRenderer != null && skinnedMeshRenderer.bones != null && skinnedMeshRenderer.bones.Length != 0
					select skinnedMeshRenderer).ToList();
				gltf.nodes = Nodes.Select((Transform x2) => ExportNode(x2, Nodes, unityMeshes.Select((MeshWithRenderer y) => y.Renderer).ToList(), unitySkins)).ToList();
				gltf.scenes = new List<gltfScene>
				{
					new gltfScene
					{
						nodes = (from item3 in go.transform.GetChildren()
							select Nodes.IndexOf(item3)).ToArray()
					}
				};
				foreach (SkinnedMeshRenderer x in unitySkins)
				{
					Matrix4x4[] array = x.sharedMesh.bindposes.Select((Matrix4x4 y) => y.ReverseZ()).ToArray();
					int inverseBindMatrices = gltf.ExtendBufferAndGetAccessorIndex(bufferIndex, array);
					glTFSkin item2 = new glTFSkin
					{
						inverseBindMatrices = inverseBindMatrices,
						joints = x.bones.Select((Transform y) => Nodes.IndexOf(y)).ToArray(),
						skeleton = Nodes.IndexOf(x.rootBone)
					};
					int count = gltf.skins.Count;
					gltf.skins.Add(item2);
					foreach (Transform item3 in Nodes.Where((Transform y) => y.Has(x)))
					{
						int index = Nodes.IndexOf(item3);
						gltf.nodes[index].skin = count;
					}
				}
			}
			finally
			{
				if (gameObject != null)
				{
					gameObject.transform.GetChild(0).SetParent(null);
					if (Application.isPlaying)
					{
						UnityEngine.Object.Destroy(gameObject);
					}
					else
					{
						UnityEngine.Object.DestroyImmediate(gameObject);
					}
				}
			}
		}
	}
}
