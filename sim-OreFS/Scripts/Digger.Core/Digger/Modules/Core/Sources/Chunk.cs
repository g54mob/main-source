using System.Collections.Generic;
using System.Globalization;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

namespace Digger.Modules.Core.Sources
{
	public class Chunk : MonoBehaviour
	{
		[SerializeField]
		private DiggerSystem digger;

		[SerializeField]
		private ChunkLODGroup chunkLodGroup;

		[SerializeField]
		private VoxelChunk voxelChunk;

		[SerializeField]
		private Vector3i chunkPosition;

		[SerializeField]
		private Vector3i voxelPosition;

		[SerializeField]
		private Vector3 worldPosition;

		[SerializeField]
		private Vector3 sizeInWorld;

		[SerializeField]
		private bool hasVisualMesh;

		public Vector3i ChunkPosition => chunkPosition;

		public Vector3i VoxelPosition => voxelPosition;

		public Vector3 WorldPosition => worldPosition;

		public DiggerSystem Digger => digger;

		public bool HasVisualMesh => hasVisualMesh;

		internal VoxelChunk VoxelChunk => voxelChunk;

		private bool IsLoaded
		{
			get
			{
				if (voxelChunk != null)
				{
					return voxelChunk.IsLoaded;
				}
				return false;
			}
		}

		internal NavMeshBuildSource NavMeshBuildSource => new NavMeshBuildSource
		{
			shape = NavMeshBuildSourceShape.Mesh,
			area = digger.DefaultNavMeshArea,
			transform = base.transform.localToWorldMatrix,
			sourceObject = chunkLodGroup.GetMeshForNavigation(),
			component = this,
			size = digger.GetChunkBounds().size
		};

		public static string GetName(Vector3i chunkPosition)
		{
			return $"Chunk_{chunkPosition.x}_{chunkPosition.y}_{chunkPosition.z}";
		}

		public static Vector3i GetPositionFromName(string chunkName)
		{
			string[] array = chunkName.Replace("Chunk_", "").Replace(".vox3", "").Split('_');
			return new Vector3i(int.Parse(array[0], CultureInfo.InvariantCulture), int.Parse(array[1], CultureInfo.InvariantCulture), int.Parse(array[2], CultureInfo.InvariantCulture));
		}

		internal static Chunk CreateChunk(Vector3i chunkPosition, DiggerSystem digger, Terrain terrain, Material[] materials, int layer, string tag)
		{
			Vector3i vector3i = GetVoxelPosition(digger, chunkPosition);
			Vector3 vector = vector3i;
			vector.x *= digger.HeightmapScale.x;
			vector.y *= digger.HeightmapScale.y;
			vector.z *= digger.HeightmapScale.z;
			GameObject obj = new GameObject(GetName(chunkPosition));
			obj.layer = layer;
			obj.hideFlags = ((!digger.ShowDebug) ? (HideFlags.HideInHierarchy | HideFlags.HideInInspector) : HideFlags.None);
			obj.transform.parent = digger.transform;
			obj.transform.localPosition = vector + Vector3.up * 0.001f;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
			Chunk chunk = obj.AddComponent<Chunk>();
			chunk.digger = digger;
			chunk.chunkPosition = chunkPosition;
			chunk.voxelPosition = vector3i;
			chunk.worldPosition = vector;
			chunk.sizeInWorld = digger.SizeOfMesh * digger.HeightmapScale;
			chunk.voxelChunk = VoxelChunk.Create(digger, chunk);
			chunk.chunkLodGroup = ChunkLODGroup.Create(chunkPosition, chunk, digger, terrain, materials, layer, tag);
			chunk.UpdateStaticEditorFlags();
			return chunk;
		}

		public void UpdateStaticEditorFlags()
		{
		}

		public void PrepareOperationJob<T>(IOperation<T> operation) where T : struct, IJobParallelFor
		{
			voxelChunk.PrepareOperationJob(operation);
		}

		public void ScheduleOperationJob<T>(IOperation<T> operation) where T : struct, IJobParallelFor
		{
			voxelChunk.ScheduleOperationJob<T>();
		}

		public void CompleteOperation<T>(IOperation<T> operation) where T : struct, IJobParallelFor
		{
			voxelChunk.CompleteOperation(operation);
		}

		public void RecordUndoIfNeeded()
		{
			voxelChunk.RecordUndoIfNeeded();
		}

		public void LabelizeVoxels()
		{
			voxelChunk.LabelizeVoxels();
		}

		public void CompleteLabelizeVoxels()
		{
			voxelChunk.CompleteLabelizeVoxels();
		}

		public void HandleFloatingVoxels()
		{
			voxelChunk.HandleFloatingVoxels();
		}

		public void CompleteHandleFloatingVoxels()
		{
			voxelChunk.CompleteHandleFloatingVoxels();
		}

		internal void BuildVisualMesh(int lod)
		{
			voxelChunk.BuildMesh(lod);
		}

		internal void CompleteBuildVisualMeshJob()
		{
			voxelChunk.CompleteBuildMeshJob();
		}

		internal void CompleteBuildVisualMesh(int lod, int lodIndex)
		{
			Mesh mesh = chunkLodGroup.NextMesh(lodIndex);
			voxelChunk.CompleteBuildMesh(mesh, lod);
		}

		internal void BakePhysicMesh()
		{
			voxelChunk.BakePhysicMesh();
		}

		internal void CompleteBakePhysicMesh()
		{
			voxelChunk.CompleteBakePhysicMesh();
		}

		internal void UpdateVoxelsOnSurface()
		{
			voxelChunk.UpdateVoxelsOnSurface();
		}

		internal void CompleteUpdateVoxelsOnSurface()
		{
			voxelChunk.CompleteUpdateVoxelsOnSurface();
		}

		internal void GetSurfaceChunksOnHoles()
		{
			voxelChunk.GetSurfaceChunksOnHoles();
		}

		internal HashSet<int3> CompleteGetSurfaceChunksOnHoles()
		{
			return voxelChunk.CompleteGetSurfaceChunksOnHoles();
		}

		internal void ApplyModify()
		{
			for (int i = 0; i < chunkLodGroup.LODCount; i++)
			{
				Mesh mesh = chunkLodGroup.NextMesh(i);
				bool flag = chunkLodGroup.PostBuild(i, mesh);
				if (i == 0)
				{
					hasVisualMesh = flag;
				}
			}
			ResetVoxelArrayBeforeOperation();
		}

		public bool LoadVoxels(bool syncVoxelsWithTerrain)
		{
			bool result = false;
			if (!voxelChunk)
			{
				voxelChunk = GetComponentInChildren<VoxelChunk>();
				if (!voxelChunk)
				{
					voxelChunk = VoxelChunk.Create(digger, this);
					result = true;
				}
			}
			voxelChunk.Load();
			if (syncVoxelsWithTerrain)
			{
				voxelChunk.RefreshVoxels();
			}
			return result;
		}

		public void RebuildMeshes()
		{
			for (int i = 0; i < chunkLodGroup.LODCount; i++)
			{
				int lod = ChunkLODGroup.IndexToLod(i);
				Mesh mesh = chunkLodGroup.NextMesh(i);
				if (voxelChunk.BuildMeshSync(lod, mesh))
				{
					voxelChunk.BakePhysicMesh();
				}
				bool flag = chunkLodGroup.PostBuild(i, i == digger.ColliderLodIndex || chunkLodGroup.LODCount == 1);
				if (i == 0)
				{
					hasVisualMesh = flag;
				}
			}
		}

		private static Vector3i GetVoxelPosition(DiggerSystem digger, Vector3i chunkPosition)
		{
			return chunkPosition * digger.SizeOfMesh;
		}

		internal void ResetVoxelArrayBeforeOperation()
		{
			voxelChunk.ResetVoxelArrayBeforeOperation();
		}

		internal void LazyLoad()
		{
			if (IsLoaded)
			{
				return;
			}
			if (!voxelChunk)
			{
				voxelChunk = GetComponentInChildren<VoxelChunk>();
				if (!voxelChunk)
				{
					Debug.LogError("VoxelChunk component is missing from Chunk children. Chunk " + base.name + " is in incoherent state. Creating a new VoxelChunk to fix this...");
					voxelChunk = VoxelChunk.Create(digger, this);
				}
			}
			LoadVoxels(syncVoxelsWithTerrain: false);
		}
	}
}
