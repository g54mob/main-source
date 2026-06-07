using UnityEngine;

namespace Digger.Modules.Core.Sources
{
	public class ChunkLODGroup : MonoBehaviour
	{
		[SerializeField]
		private LODGroup lodGroup;

		[SerializeField]
		private ChunkObject[] chunks;

		public int LODCount => chunks.Length;

		internal static ChunkLODGroup Create(Vector3i chunkPosition, Chunk chunk, DiggerSystem digger, Terrain terrain, Material[] materials, int layer, string tag)
		{
			GameObject gameObject = new GameObject(GetName(chunkPosition));
			gameObject.layer = layer;
			gameObject.tag = tag;
			gameObject.transform.parent = chunk.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = Vector3.one;
			ChunkLODGroup chunkLODGroup = gameObject.AddComponent<ChunkLODGroup>();
			if (digger.CreateLODs)
			{
				LODGroup lODGroup = gameObject.AddComponent<LODGroup>();
				chunkLODGroup.chunks = new ChunkObject[3]
				{
					ChunkObject.Create(1, chunkPosition, chunkLODGroup, digger.ColliderLodIndex == 0, digger, terrain, materials, layer, tag),
					ChunkObject.Create(2, chunkPosition, chunkLODGroup, digger.ColliderLodIndex == 1, digger, terrain, materials, layer, tag),
					ChunkObject.Create(4, chunkPosition, chunkLODGroup, digger.ColliderLodIndex == 2, digger, terrain, materials, layer, tag)
				};
				Renderer[] array = new Renderer[chunkLODGroup.chunks.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = chunkLODGroup.chunks[i].GetComponent<MeshRenderer>();
				}
				LOD[] lODs = new LOD[3]
				{
					new LOD(digger.ScreenRelativeTransitionHeightLod0, new Renderer[1] { array[0] }),
					new LOD(digger.ScreenRelativeTransitionHeightLod1, new Renderer[1] { array[1] }),
					new LOD(0f, new Renderer[1] { array[2] })
				};
				lODGroup.SetLODs(lODs);
				chunkLODGroup.lodGroup = lODGroup;
			}
			else
			{
				chunkLODGroup.chunks = new ChunkObject[1] { ChunkObject.Create(1, chunkPosition, chunkLODGroup, hasCollider: true, digger, terrain, materials, layer, tag) };
			}
			return chunkLODGroup;
		}

		public Mesh GetMeshForNavigation()
		{
			return chunks[0].Mesh;
		}

		public void UpdateStaticEditorFlags(bool enableOcclusionCulling, bool enableContributeGI)
		{
			for (int i = 0; i < chunks.Length; i++)
			{
				chunks[i].UpdateStaticEditorFlags(enableOcclusionCulling, enableContributeGI);
			}
		}

		private static string GetName(Vector3i chunkPosition)
		{
			return $"ChunkLODGroup_{chunkPosition.x}_{chunkPosition.y}_{chunkPosition.z}";
		}

		public Mesh NextMesh(int lodIndex)
		{
			return chunks[lodIndex].NextMesh();
		}

		public bool PostBuild(int lodIndex, bool withCollision)
		{
			bool result = chunks[lodIndex].PostBuild(withCollision);
			if (LODCount > 1)
			{
				lodGroup.RecalculateBounds();
			}
			return result;
		}

		public static int IndexToLod(int lod)
		{
			return 1 << lod;
		}
	}
}
