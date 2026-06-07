using System;
using Digger.Modules.Core.Sources.Jobs;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources
{
	[AddComponentMenu("Digger/Custom Brush")]
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteInEditMode]
	public class CustomBrush : MonoBehaviour
	{
		[SerializeField]
		private string id;

		[NonSerialized]
		private Voxel[] inputVoxels;

		[NonSerialized]
		private int3 inputSizeVox;

		[NonSerialized]
		private int3 inputOriginVox;

		[NonSerialized]
		private Mesh usedMesh;

		[NonSerialized]
		private float3 usedRotation;

		[NonSerialized]
		private float3 usedScale;

		[SerializeField]
		public bool autoRefresh = true;

		public string Id => id;

		public Voxel[] InputVoxels => inputVoxels;

		public int3 InputSizeVox => inputSizeVox;

		public int3 InputOriginVox => inputOriginVox;

		private void OnEnable()
		{
			if (string.IsNullOrEmpty(id))
			{
				id = Guid.NewGuid().ToString();
			}
		}

		private void Update()
		{
			if ((autoRefresh && usedMesh != GetComponent<MeshFilter>().sharedMesh) || !Utils.Approximately(usedRotation, new float3(base.transform.localEulerAngles)) || !Utils.Approximately(usedScale, new float3(base.transform.localScale)))
			{
				ComputeVoxels();
			}
		}

		public void ComputeVoxels()
		{
			DiggerSystem diggerSystem = UnityEngine.Object.FindFirstObjectByType<DiggerSystem>();
			if ((bool)diggerSystem)
			{
				TerrainData terrainData = diggerSystem.Terrain.terrainData;
				float3 float5 = new float3(1f, 1f, 1f) * diggerSystem.ResolutionMult / terrainData.heightmapScale.x;
				if (!diggerSystem.AutoVoxelHeight)
				{
					float5.y = 1f / diggerSystem.VoxelHeight;
				}
				usedMesh = GetComponent<MeshFilter>().sharedMesh;
				usedRotation = new float3(base.transform.localEulerAngles);
				usedScale = new float3(base.transform.localScale);
				NativeArray<float3> vertices = new NativeArray<float3>(usedMesh.vertexCount, Allocator.TempJob);
				Bounds bounds = default(Bounds);
				Vector3 position = base.transform.position;
				base.transform.position = Vector3.zero;
				for (int i = 0; i < usedMesh.vertices.Length; i++)
				{
					vertices[i] = base.transform.TransformPoint(usedMesh.vertices[i]) * float5;
					bounds.Encapsulate(vertices[i]);
				}
				base.transform.position = position;
				NativeArray<ushort> triangles = new NativeArray<ushort>(usedMesh.triangles.Length, Allocator.TempJob);
				for (int j = 0; j < usedMesh.triangles.Length; j++)
				{
					triangles[j] = (ushort)usedMesh.triangles[j];
				}
				int3 int5 = (inputSizeVox = new int3((int3)math.round(bounds.size) + new int3(4, 4, 4)));
				inputOriginVox = int5 / 2;
				NativeArray<Voxel> voxels = new NativeArray<Voxel>(int5.x * int5.y * int5.z, Allocator.TempJob);
				IJobParallelForExtensions.Schedule(new MeshToVoxelsJob
				{
					SizeVox = int5,
					Origin = inputOriginVox,
					Vertices = vertices,
					Triangles = triangles,
					Voxels = voxels
				}, voxels.Length, 64).Complete();
				inputVoxels = voxels.ToArray();
				voxels.Dispose();
				vertices.Dispose();
				triangles.Dispose();
			}
		}
	}
}
