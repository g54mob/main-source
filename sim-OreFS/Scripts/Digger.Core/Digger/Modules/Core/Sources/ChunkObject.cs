using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Digger.Modules.Core.Sources
{
	public class ChunkObject : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer meshRenderer;

		[SerializeField]
		private MeshFilter filter;

		[SerializeField]
		private MeshCollider meshCollider;

		[SerializeField]
		private bool hasCollider;

		[SerializeField]
		private bool isStatic;

		[SerializeField]
		private Terrain terrain;

		[SerializeField]
		private DiggerSystem digger;

		[SerializeField]
		private Mesh mesh1;

		[SerializeField]
		private Mesh mesh2;

		[SerializeField]
		private bool nextMeshIsMesh1;

		[NonSerialized]
		private Mesh mesh1PlayingInEditor;

		[NonSerialized]
		private Mesh mesh2PlayingInEditor;

		[NonSerialized]
		private bool nextMeshIsMesh1PlayingInEditor;

		public Mesh Mesh => filter.sharedMesh;

		public Terrain Terrain => terrain;

		public DiggerSystem Digger => digger;

		internal static ChunkObject Create(int lod, Vector3i chunkPosition, ChunkLODGroup chunkLodGroup, bool hasCollider, DiggerSystem digger, Terrain terrain, Material[] materials, int layer, string tag)
		{
			GameObject gameObject = new GameObject(GetName(chunkPosition));
			gameObject.layer = layer;
			gameObject.tag = tag;
			gameObject.hideFlags = ((!digger.ShowDebug) ? (HideFlags.HideInHierarchy | HideFlags.HideInInspector) : HideFlags.None);
			gameObject.transform.parent = chunkLodGroup.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			ChunkObject chunkObject = gameObject.AddComponent<ChunkObject>();
			chunkObject.enabled = false;
			chunkObject.terrain = terrain;
			chunkObject.digger = digger;
			chunkObject.hasCollider = hasCollider;
			chunkObject.meshRenderer = gameObject.AddComponent<MeshRenderer>();
			chunkObject.meshRenderer.lightmapScaleOffset = digger.Terrain.lightmapScaleOffset;
			chunkObject.meshRenderer.realtimeLightmapScaleOffset = digger.Terrain.realtimeLightmapScaleOffset;
			chunkObject.meshRenderer.sharedMaterials = materials ?? new Material[0];
			SetupMeshRenderer(digger.Terrain, chunkObject.meshRenderer);
			gameObject.GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.On;
			gameObject.GetComponent<Renderer>().receiveShadows = true;
			chunkObject.filter = gameObject.AddComponent<MeshFilter>();
			chunkObject.meshRenderer.enabled = false;
			chunkObject.mesh1 = new Mesh();
			chunkObject.mesh2 = new Mesh();
			chunkObject.nextMeshIsMesh1 = true;
			if (hasCollider)
			{
				chunkObject.meshCollider = gameObject.AddComponent<MeshCollider>();
				TerrainCollider component = terrain.GetComponent<TerrainCollider>();
				if ((bool)component)
				{
					chunkObject.meshCollider.sharedMaterial = component.sharedMaterial;
				}
			}
			chunkObject.UpdateStaticEditorFlags(digger.EnableOcclusionCulling, digger.EnableContributeGI);
			digger.onChunkObjectCreated?.Invoke(chunkObject);
			return chunkObject;
		}

		public void UpdateStaticEditorFlags(bool enableOcclusionCulling, bool enableContributeGI)
		{
		}

		public void GenerateSecondaryUVSet()
		{
		}

		private static void SetupMeshRenderer(Terrain terrain, MeshRenderer meshRenderer)
		{
			meshRenderer.renderingLayerMask = terrain.renderingLayerMask;
		}

		public static string GetName(Vector3i chunkPosition)
		{
			return $"ChunkObject_{chunkPosition.x}_{chunkPosition.y}_{chunkPosition.z}";
		}

		public Mesh NextMesh()
		{
			if (Application.isEditor && Application.isPlaying)
			{
				if (!mesh1PlayingInEditor)
				{
					mesh1PlayingInEditor = new Mesh();
				}
				if (!mesh2PlayingInEditor)
				{
					mesh2PlayingInEditor = new Mesh();
				}
				if (!nextMeshIsMesh1PlayingInEditor)
				{
					return mesh2PlayingInEditor;
				}
				return mesh1PlayingInEditor;
			}
			if (!mesh1)
			{
				mesh1 = new Mesh();
			}
			if (!mesh2)
			{
				mesh2 = new Mesh();
			}
			if (!nextMeshIsMesh1)
			{
				return mesh2;
			}
			return mesh1;
		}

		public void ClearOldMesh()
		{
			if (Application.isEditor && Application.isPlaying)
			{
				(nextMeshIsMesh1PlayingInEditor ? mesh2PlayingInEditor : mesh1PlayingInEditor).Clear();
				nextMeshIsMesh1PlayingInEditor = !nextMeshIsMesh1PlayingInEditor;
			}
			else
			{
				(nextMeshIsMesh1 ? mesh2 : mesh1).Clear();
				nextMeshIsMesh1 = !nextMeshIsMesh1;
			}
		}

		public bool PostBuild(bool withCollision)
		{
			Mesh mesh = NextMesh();
			bool result = false;
			if (mesh.vertexCount > 0)
			{
				filter.sharedMesh = mesh;
				meshRenderer.enabled = true;
				result = true;
			}
			else
			{
				filter.sharedMesh = null;
				meshRenderer.enabled = false;
			}
			if (hasCollider)
			{
				if (mesh.vertexCount > 0 && withCollision)
				{
					meshCollider.sharedMesh = mesh;
					meshCollider.enabled = true;
				}
				else
				{
					meshCollider.sharedMesh = null;
					meshCollider.enabled = false;
				}
			}
			ClearOldMesh();
			return result;
		}
	}
}
