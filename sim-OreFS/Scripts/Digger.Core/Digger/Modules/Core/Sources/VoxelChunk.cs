using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Digger.Modules.Core.Sources.Jobs;
using Digger.Modules.Core.Sources.Polygonizers;
using Digger.Modules.Core.Sources.TerrainInterface;
using Digger.Modules.Core.Sources.VoxelPhysics;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources
{
	public class VoxelChunk : MonoBehaviour
	{
		[SerializeField]
		private DiggerSystem digger;

		[SerializeField]
		private int sizeVox;

		[SerializeField]
		private int sizeOfMesh;

		[SerializeField]
		private Vector3i chunkPosition;

		[SerializeField]
		private Vector3i voxelPosition;

		[SerializeField]
		private Vector3 worldPosition;

		[NonSerialized]
		private Voxel[] voxelArray;

		[NonSerialized]
		private float[] heightArray;

		[NonSerialized]
		private float3[] normalArray;

		[NonSerialized]
		private float[] alphamapArray;

		[NonSerialized]
		private int[] labelArray;

		[NonSerialized]
		private readonly Dictionary<int, ConnectedComponentLabeling.AABB> labelMap = new Dictionary<int, ConnectedComponentLabeling.AABB>();

		[NonSerialized]
		private readonly HashSet<int> labelsConnectedToTheGround = new HashSet<int>();

		[NonSerialized]
		private readonly HashSet<int> labelsConnectedToTheGroundThroughNeighbors = new HashSet<int>();

		[NonSerialized]
		private readonly Dictionary<int, HashSet<int>> linksToRight = new Dictionary<int, HashSet<int>>();

		[NonSerialized]
		private readonly Dictionary<int, HashSet<int>> linksToLeft = new Dictionary<int, HashSet<int>>();

		[NonSerialized]
		private readonly Dictionary<int, HashSet<int>> linksToTop = new Dictionary<int, HashSet<int>>();

		[NonSerialized]
		private readonly Dictionary<int, HashSet<int>> linksToBottom = new Dictionary<int, HashSet<int>>();

		[NonSerialized]
		private readonly Dictionary<int, HashSet<int>> linksToBack = new Dictionary<int, HashSet<int>>();

		[NonSerialized]
		private readonly Dictionary<int, HashSet<int>> linksToFront = new Dictionary<int, HashSet<int>>();

		[NonSerialized]
		private int3 alphamapArraySize;

		[NonSerialized]
		private int2 alphamapArrayOrigin;

		[NonSerialized]
		private Voxel[] voxelArrayBeforeOperation;

		[NonSerialized]
		private JobHandle? currentJobHandle;

		[NonSerialized]
		private IJobParallelFor currentJob;

		[NonSerialized]
		private int currentJobStartFrame;

		[NonSerialized]
		private ConnectedComponentLabelingJob? currentLabelizationJob;

		[NonSerialized]
		private NativeArray<Voxel> voxels;

		[NonSerialized]
		private NativeArray<float> heights;

		[NonSerialized]
		private NativeArray<int> holes;

		[NonSerialized]
		private NativeParallelHashSet<int> chunkOnSurfaceY;

		[NonSerialized]
		private readonly Dictionary<int, IPolygonizer> polygonizersPerLod = new Dictionary<int, IPolygonizer>();

		[NonSerialized]
		private int needToBakePhysicMeshInstanceID;

		[NonSerialized]
		private ModificationResult lastOperationResult;

		public bool IsLoaded
		{
			get
			{
				Voxel[] array = VoxelArray;
				if (array != null)
				{
					return array.Length > 0;
				}
				return false;
			}
		}

		public Vector3i ChunkPosition => chunkPosition;

		public Vector3i VoxelPosition => voxelPosition;

		private float Altitude => (float)voxelPosition.y * digger.HeightmapScale.y;

		public float3 WorldPosition => worldPosition;

		public float3 AbsoluteWorldPosition => digger.transform.TransformPoint(worldPosition);

		public int3 AbsoluteVoxelPosition => Utils.UnityToVoxelPosition(digger.transform.TransformPoint(worldPosition), HeightmapScale);

		public int SizeVox => sizeVox;

		public int SizeOfMesh => sizeOfMesh;

		public float3 HeightmapScale => digger.HeightmapScale;

		public Voxel[] VoxelArray => voxelArray;

		public float[] HeightArray => heightArray;

		public float3[] NormalArray => normalArray;

		public float[] AlphamapArray => alphamapArray;

		public int[] LabelArray => labelArray;

		public int[] HolesArray => digger.Cutter.GetHoles(chunkPosition, voxelPosition);

		public float3 CutMargin => digger.CutMargin;

		public TerrainCutter Cutter => digger.Cutter;

		public DiggerSystem Digger => digger;

		public int3 AlphamapArraySize => alphamapArraySize;

		public int2 AlphamapArrayOrigin => alphamapArrayOrigin;

		public HashSet<int> LabelsConnectedToTheGround => labelsConnectedToTheGround;

		public Dictionary<int, HashSet<int>> LinksToRight => linksToRight;

		public Dictionary<int, HashSet<int>> LinksToLeft => linksToLeft;

		public Dictionary<int, HashSet<int>> LinksToTop => linksToTop;

		public Dictionary<int, HashSet<int>> LinksToBottom => linksToBottom;

		public Dictionary<int, HashSet<int>> LinksToBack => linksToBack;

		public Dictionary<int, HashSet<int>> LinksToFront => linksToFront;

		public HashSet<int> LabelsConnectedToTheGroundThroughNeighbors => labelsConnectedToTheGroundThroughNeighbors;

		public Dictionary<int, ConnectedComponentLabeling.AABB> LabelMap => labelMap;

		private IPolygonizer GetPolygonizer(int lod)
		{
			if (polygonizersPerLod.TryGetValue(lod, out var value))
			{
				return value;
			}
			IPolygonizer polygonizer2;
			if (!digger.PolygonizerProvider)
			{
				IPolygonizer polygonizer = new MarchingCubesPolygonizer();
				polygonizer2 = polygonizer;
			}
			else
			{
				polygonizer2 = digger.PolygonizerProvider.NewPolygonizer(digger);
			}
			value = polygonizer2;
			polygonizersPerLod.Add(lod, value);
			return value;
		}

		internal static VoxelChunk Create(DiggerSystem digger, Chunk chunk)
		{
			GameObject obj = new GameObject("VoxelChunk");
			obj.hideFlags = HideFlags.DontSaveInBuild;
			obj.transform.parent = chunk.transform;
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
			VoxelChunk voxelChunk = obj.AddComponent<VoxelChunk>();
			voxelChunk.digger = digger;
			voxelChunk.sizeVox = digger.SizeVox;
			voxelChunk.sizeOfMesh = digger.SizeOfMesh;
			voxelChunk.chunkPosition = chunk.ChunkPosition;
			voxelChunk.voxelPosition = chunk.VoxelPosition;
			voxelChunk.worldPosition = chunk.WorldPosition;
			voxelChunk.Load();
			return voxelChunk;
		}

		private static void GenerateVoxels(DiggerSystem digger, float[] heightArray, Vector3i chunkVoxelPosition, ref Voxel[] voxelArray, bool refreshOnly)
		{
			int num = digger.SizeVox;
			if (voxelArray == null)
			{
				voxelArray = new Voxel[num * num * num];
			}
			NativeArray<float> nativeArray = new NativeArray<float>(heightArray, Allocator.TempJob);
			NativeArray<Voxel> nativeArray2 = (refreshOnly ? new NativeArray<Voxel>(voxelArray, Allocator.TempJob) : new NativeArray<Voxel>(num * num * num, Allocator.TempJob, NativeArrayOptions.UninitializedMemory));
			digger.VoxelGenerator.GenerateVoxels(heightArray, chunkVoxelPosition.ToInt3(), num, digger.HeightmapScale, nativeArray, nativeArray2, refreshOnly).Complete();
			nativeArray2.CopyTo(voxelArray);
			nativeArray.Dispose();
			nativeArray2.Dispose();
		}

		public void RefreshVoxels()
		{
			GenerateVoxels(digger, HeightArray, voxelPosition, ref voxelArray, refreshOnly: true);
		}

		public void PrepareOperationJob<T>(IOperation<T> operation) where T : struct, IJobParallelFor
		{
			T val = operation.Do(this);
			currentJob = val;
		}

		public void ScheduleOperationJob<T>() where T : struct, IJobParallelFor
		{
			currentJobHandle = IJobParallelForExtensions.Schedule((T)currentJob, VoxelArray.Length, digger.SizeVox);
		}

		public void CompleteOperation<T>(IOperation<T> operation) where T : struct, IJobParallelFor
		{
			CompleteBackgroundJob();
			lastOperationResult = operation.Complete((T)currentJob, this);
		}

		public ModificationResult GetAndClearOperationResult()
		{
			ModificationResult result = lastOperationResult;
			lastOperationResult = ModificationResult.Empty;
			return result;
		}

		public void LabelizeVoxels()
		{
			ConnectedComponentLabelingJob connectedComponentLabelingJob = ConnectedComponentLabeling.Do(this);
			currentLabelizationJob = connectedComponentLabelingJob;
			currentJobHandle = connectedComponentLabelingJob.Schedule();
		}

		public void CompleteLabelizeVoxels()
		{
			CompleteBackgroundJob();
			ConnectedComponentLabeling.Complete(currentLabelizationJob.Value, this);
			currentLabelizationJob = null;
		}

		public void HandleFloatingVoxels()
		{
			RemoveFloatingVoxelsJob removeFloatingVoxelsJob = RemoveFloatingVoxels.Do(this);
			currentJob = removeFloatingVoxelsJob;
			currentJobHandle = IJobParallelForExtensions.Schedule(removeFloatingVoxelsJob, VoxelArray.Length, 512);
		}

		public void CompleteHandleFloatingVoxels()
		{
			CompleteBackgroundJob();
			RemoveFloatingVoxels.Complete((RemoveFloatingVoxelsJob)(object)currentJob, this);
			currentJob = null;
		}

		public void UpdateVoxelsOnSurface()
		{
			if (VoxelArray != null)
			{
				heights = new NativeArray<float>(HeightArray, Allocator.Persistent);
				voxels = new NativeArray<Voxel>(VoxelArray, Allocator.Persistent);
				TerrainCutter cutter = digger.Cutter;
				holes = new NativeArray<int>(cutter.GetHoles(chunkPosition, voxelPosition), Allocator.Persistent);
				VoxelFillSurfaceJob jobData = new VoxelFillSurfaceJob
				{
					ChunkAltitude = Altitude,
					Heights = heights,
					Voxels = voxels,
					Holes = holes,
					SizeVox = SizeVox,
					SizeVox2 = SizeVox * SizeVox,
					HeightmapScale = digger.HeightmapScale
				};
				currentJobHandle = IJobParallelForExtensions.Schedule(jobData, voxels.Length, 64);
			}
		}

		public void CompleteUpdateVoxelsOnSurface()
		{
			CompleteBackgroundJob();
			voxels.CopyTo(VoxelArray);
			heights.Dispose();
			voxels.Dispose();
			holes.Dispose();
		}

		public void GetSurfaceChunksOnHoles()
		{
			if (VoxelArray != null)
			{
				heights = new NativeArray<float>(HeightArray, Allocator.Persistent);
				chunkOnSurfaceY = new NativeParallelHashSet<int>(100, Allocator.Persistent);
				TerrainCutter cutter = digger.Cutter;
				holes = new NativeArray<int>(cutter.GetHoles(chunkPosition, voxelPosition), Allocator.Persistent);
				GetSurfaceChunksJob jobData = new GetSurfaceChunksJob
				{
					ChunkOnSurfaceY = chunkOnSurfaceY.AsParallelWriter(),
					Heights = heights,
					Holes = holes,
					SizeVox = SizeVox,
					SizeOfMesh = SizeOfMesh,
					HeightmapScaleY = digger.HeightmapScale.y
				};
				currentJobHandle = IJobParallelForExtensions.Schedule(jobData, holes.Length, 64);
			}
		}

		private void CompleteBackgroundJob()
		{
			if (currentJobHandle.HasValue)
			{
				currentJobHandle.Value.Complete();
				currentJobHandle = null;
			}
		}

		private void CompleteJobSync()
		{
			if (currentJobHandle.HasValue)
			{
				currentJobHandle.Value.Complete();
				currentJobHandle = null;
			}
		}

		public HashSet<int3> CompleteGetSurfaceChunksOnHoles()
		{
			CompleteBackgroundJob();
			HashSet<int3> hashSet = new HashSet<int3>();
			foreach (int item in chunkOnSurfaceY)
			{
				hashSet.Add(new int3(chunkPosition.x, item, chunkPosition.z));
			}
			chunkOnSurfaceY.Dispose();
			heights.Dispose();
			holes.Dispose();
			return hashSet;
		}

		public bool HasAlteredVoxels()
		{
			if (VoxelArray != null)
			{
				return VoxelArray.Any((Voxel voxel) => voxel.Alteration != 0);
			}
			return false;
		}

		public void BuildMesh(int lod)
		{
			currentJobHandle = GetPolygonizer(lod).BuildMesh(this, lod);
		}

		public bool BuildMeshSync(int lod, Mesh mesh)
		{
			currentJobHandle = GetPolygonizer(lod).BuildMesh(this, lod);
			CompleteJobSync();
			return GetPolygonizer(lod).CompleteBuildMesh(mesh, Digger.GetChunkBounds());
		}

		public void CompleteBuildMeshJob()
		{
			CompleteBackgroundJob();
		}

		public void CompleteBuildMesh(Mesh mesh, int lod)
		{
			needToBakePhysicMeshInstanceID = (GetPolygonizer(lod).CompleteBuildMesh(mesh, Digger.GetChunkBounds()) ? mesh.GetInstanceID() : 0);
		}

		public void BakePhysicMesh()
		{
			if (needToBakePhysicMeshInstanceID != 0)
			{
				PhysicsBakeMeshJob jobData = new PhysicsBakeMeshJob
				{
					MeshInstanceId = needToBakePhysicMeshInstanceID
				};
				currentJobHandle = jobData.Schedule();
			}
		}

		public void CompleteBakePhysicMesh()
		{
			CompleteBackgroundJob();
		}

		public void RecordUndoIfNeeded()
		{
		}

		public void Persist()
		{
			if (VoxelArray == null || VoxelArray.Length == 0)
			{
				Debug.LogError("Voxel array should not be null in saving");
				return;
			}
			string pathVoxelFile = digger.GetPathVoxelFile(chunkPosition, forPersistence: true);
			NativeArray<Voxel> array = new NativeArray<Voxel>(VoxelArray, Allocator.Temp);
			File.WriteAllBytes(pathVoxelFile, new NativeSlice<Voxel>(array).SliceConvert<byte>().ToArray());
			array.Dispose();
			string pathLabelFile = digger.GetPathLabelFile(chunkPosition, forPersistence: true);
			NativeArray<int> array2 = new NativeArray<int>(LabelArray, Allocator.Temp);
			File.WriteAllBytes(pathLabelFile, new NativeSlice<int>(array2).SliceConvert<byte>().ToArray());
			array2.Dispose();
			using FileStream output = new FileStream(digger.GetPathVoxelMetadataFile(chunkPosition, forPersistence: true), FileMode.Create, FileAccess.Write, FileShare.Write, 4096, FileOptions.Asynchronous);
			using BinaryWriter writer = new BinaryWriter(output, Encoding.ASCII);
			PersistHashSet(writer, labelsConnectedToTheGround);
			PersistHashSet(writer, labelsConnectedToTheGroundThroughNeighbors);
			PersistDictionary(writer, linksToRight);
			PersistDictionary(writer, linksToLeft);
			PersistDictionary(writer, linksToTop);
			PersistDictionary(writer, linksToBottom);
			PersistDictionary(writer, linksToBack);
			PersistDictionary(writer, linksToFront);
		}

		private void PersistDictionary(BinaryWriter writer, Dictionary<int, HashSet<int>> dico)
		{
			writer.Write(dico.Count);
			foreach (KeyValuePair<int, HashSet<int>> item in dico)
			{
				writer.Write(item.Key);
				PersistHashSet(writer, item.Value);
			}
		}

		private void ReadDictionary(BinaryReader reader, Dictionary<int, HashSet<int>> dico)
		{
			dico.Clear();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				int key = reader.ReadInt32();
				HashSet<int> hashSet = new HashSet<int>();
				ReadHashSet(reader, hashSet);
				dico.Add(key, hashSet);
			}
		}

		private void PersistHashSet(BinaryWriter writer, HashSet<int> set)
		{
			writer.Write(set.Count);
			foreach (int item in set)
			{
				writer.Write(item);
			}
		}

		private void ReadHashSet(BinaryReader reader, HashSet<int> set)
		{
			set.Clear();
			int num = reader.ReadInt32();
			for (int i = 0; i < num; i++)
			{
				set.Add(reader.ReadInt32());
			}
		}

		public void Load()
		{
			heightArray = digger.HeightsFeeder.GetHeights(chunkPosition, voxelPosition);
			normalArray = digger.NormalsFeeder.GetNormals(chunkPosition, voxelPosition);
			AlphamapsFeeder.AlphamapInfo alphamaps = digger.AlphamapsFeeder.GetAlphamaps(chunkPosition, worldPosition, SizeOfMesh);
			alphamapArray = alphamaps.AlphamapArray;
			alphamapArraySize = alphamaps.AlphamapArraySize;
			alphamapArrayOrigin = alphamaps.AlphamapArrayOrigin;
			digger.Cutter.GetHoles(chunkPosition, voxelPosition);
			byte[] bytes = Utils.GetBytes(digger.GetPathVoxelFile(chunkPosition, forPersistence: false));
			if (bytes == null)
			{
				if (VoxelArray == null)
				{
					GenerateVoxels(digger, heightArray, voxelPosition, ref voxelArray, refreshOnly: false);
					labelArray = new int[voxelArray.Length];
					labelMap.Clear();
					labelsConnectedToTheGround.Clear();
					labelsConnectedToTheGroundThroughNeighbors.Clear();
					linksToRight.Clear();
					linksToLeft.Clear();
					linksToTop.Clear();
					linksToBottom.Clear();
					linksToBack.Clear();
					linksToFront.Clear();
					digger.EnsureChunkWillBePersisted(this);
				}
				return;
			}
			ReadVoxelFile(SizeVox, bytes, ref voxelArray);
			byte[] bytes2 = Utils.GetBytes(digger.GetPathLabelFile(chunkPosition, forPersistence: false));
			if (bytes2 == null)
			{
				Debug.LogError($"Could not read label file of chunk {chunkPosition}");
				return;
			}
			ReadLabelFile(SizeVox, bytes2, ref labelArray);
			_ = digger.HeightmapScale;
			bytes = Utils.GetBytes(digger.GetPathVoxelMetadataFile(chunkPosition, forPersistence: false));
			if (bytes == null)
			{
				Debug.LogError($"Could not read metadata file of chunk {chunkPosition}");
				return;
			}
			using Stream input = new MemoryStream(bytes);
			using BinaryReader reader = new BinaryReader(input, Encoding.ASCII);
			ReadHashSet(reader, labelsConnectedToTheGround);
			ReadHashSet(reader, labelsConnectedToTheGroundThroughNeighbors);
			ReadDictionary(reader, linksToRight);
			ReadDictionary(reader, linksToLeft);
			ReadDictionary(reader, linksToTop);
			ReadDictionary(reader, linksToBottom);
			ReadDictionary(reader, linksToBack);
			ReadDictionary(reader, linksToFront);
		}

		public void InitVoxelArrayBeforeOperation()
		{
			voxelArrayBeforeOperation = new Voxel[VoxelArray.Length];
			Array.Copy(VoxelArray, voxelArrayBeforeOperation, VoxelArray.Length);
		}

		internal void ResetVoxelArrayBeforeOperation()
		{
			voxelArrayBeforeOperation = null;
		}

		private static void ReadVoxelFile(int sizeVox, byte[] rawBytes, ref Voxel[] voxelArray)
		{
			if (voxelArray == null)
			{
				voxelArray = new Voxel[sizeVox * sizeVox * sizeVox];
			}
			NativeArray<byte> array = new NativeArray<byte>(rawBytes, Allocator.Temp);
			DirectNativeCollectionsAccess.CopyTo(new NativeSlice<byte>(array).SliceConvert<Voxel>(), voxelArray);
			array.Dispose();
		}

		private void ReadLabelFile(int sizeVox, byte[] rawBytes, ref int[] labelArray)
		{
			if (labelArray == null)
			{
				labelArray = new int[sizeVox * sizeVox * sizeVox];
			}
			NativeArray<byte> array = new NativeArray<byte>(rawBytes, Allocator.Temp);
			DirectNativeCollectionsAccess.CopyTo(new NativeSlice<byte>(array).SliceConvert<int>(), labelArray);
			array.Dispose();
		}

		public static NativeArray<Voxel> LoadVoxels(DiggerSystem digger, Vector3i chunkPosition)
		{
			if (!digger.IsChunkBelongingToMe(chunkPosition))
			{
				DiggerSystem neighborAt = digger.GetNeighborAt(chunkPosition);
				if ((bool)neighborAt)
				{
					Vector3i vector3i = neighborAt.ToChunkPosition(digger.ToWorldPosition(chunkPosition));
					if (!neighborAt.IsChunkBelongingToMe(vector3i))
					{
						Debug.LogError($"neighborChunkPosition {vector3i} should always belong to neighbor");
						return new NativeArray<Voxel>(1, Allocator.Persistent);
					}
					return LoadVoxels(neighborAt, vector3i);
				}
			}
			if (digger.GetChunk(chunkPosition, out var chunk))
			{
				if (chunk.VoxelChunk.voxelArrayBeforeOperation != null)
				{
					return new NativeArray<Voxel>(chunk.VoxelChunk.voxelArrayBeforeOperation, Allocator.Persistent);
				}
				chunk.LazyLoad();
				return new NativeArray<Voxel>(chunk.VoxelChunk.VoxelArray, Allocator.Persistent);
			}
			return new NativeArray<Voxel>(1, Allocator.Persistent);
		}
	}
}
