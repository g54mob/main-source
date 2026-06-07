using System;
using Digger.Modules.Core.Sources.NativeCollections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct VoxelKernelModificationJob : IJobParallelFor
	{
		public int SizeVox;

		public int SizeOfMesh;

		public int SizeVox2;

		public int LowInd;

		public ActionType Action;

		public float3 HeightmapScale;

		public float3 Center;

		public float Radius;

		public float Intensity;

		public float ChunkAltitude;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> Voxels;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> Heights;

		[WriteOnly]
		public NativeArray<Voxel> VoxelsOut;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsLBB;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsLBF;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsLB_;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxels_BB;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxels_BF;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxels_B_;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsRBB;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsRBF;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsRB_;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsL_B;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsL_F;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsL__;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxels__B;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxels__F;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsR_B;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsR_F;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsR__;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsLUB;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsLUF;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsLU_;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxels_UB;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxels_UF;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxels_U_;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsRUB;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsRUF;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> NeighborVoxelsRU_;

		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> Holes;

		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> NewHolesConcurrentCounter;

		public void Execute(int index)
		{
			int3 int5 = Utils.IndexToXYZ(index, SizeVox, SizeVox2);
			float3 p = int5 * HeightmapScale;
			float num = Heights[Utils.XYZToHeightIndex(int5, SizeVox)];
			float terrainHeightValue = p.y + ChunkAltitude - num;
			float distance = ComputeSphereDistance(p);
			Voxel voxel;
			switch (Action)
			{
			default:
				return;
			case ActionType.Smooth:
				voxel = ApplySmooth(index, int5, distance, terrainHeightValue);
				break;
			case ActionType.BETA_Sharpen:
				voxel = ApplySharpen(index, int5, distance, terrainHeightValue);
				break;
			}
			if (voxel.Alteration != 0)
			{
				voxel = Utils.AdjustAlteration(voxel, int5, HeightmapScale.y, p.y + ChunkAltitude, terrainHeightValue, SizeVox, Heights);
			}
			if (voxel.IsAlteredNearBelowSurface || voxel.IsAlteredNearAboveSurface)
			{
				Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(NewHolesConcurrentCounter, 0);
				Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Utils.XZToHoleIndex(int5.x, int5.z, SizeVox));
				if (int5.x >= 1)
				{
					Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Utils.XZToHoleIndex(int5.x - 1, int5.z, SizeVox));
					if (int5.z >= 1)
					{
						Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Utils.XZToHoleIndex(int5.x - 1, int5.z - 1, SizeVox));
					}
				}
				if (int5.z >= 1)
				{
					Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(Holes, Utils.XZToHoleIndex(int5.x, int5.z - 1, SizeVox));
				}
			}
			VoxelsOut[index] = voxel;
		}

		public void DisposeNeighbors()
		{
			NeighborVoxelsLBB.Dispose();
			NeighborVoxelsLBF.Dispose();
			NeighborVoxelsLB_.Dispose();
			NeighborVoxels_BB.Dispose();
			NeighborVoxels_BF.Dispose();
			NeighborVoxels_B_.Dispose();
			NeighborVoxelsRBB.Dispose();
			NeighborVoxelsRBF.Dispose();
			NeighborVoxelsRB_.Dispose();
			NeighborVoxelsL_B.Dispose();
			NeighborVoxelsL_F.Dispose();
			NeighborVoxelsL__.Dispose();
			NeighborVoxels__B.Dispose();
			NeighborVoxels__F.Dispose();
			NeighborVoxelsR_B.Dispose();
			NeighborVoxelsR_F.Dispose();
			NeighborVoxelsR__.Dispose();
			NeighborVoxelsLUB.Dispose();
			NeighborVoxelsLUF.Dispose();
			NeighborVoxelsLU_.Dispose();
			NeighborVoxels_UB.Dispose();
			NeighborVoxels_UF.Dispose();
			NeighborVoxels_U_.Dispose();
			NeighborVoxelsRUB.Dispose();
			NeighborVoxelsRUF.Dispose();
			NeighborVoxelsRU_.Dispose();
		}

		private float ComputeSphereDistance(float3 p)
		{
			float3 float5 = p - Center;
			float num = (float)Math.Sqrt(float5.x * float5.x + float5.y * float5.y + float5.z * float5.z);
			return Radius - num;
		}

		private Voxel ApplySmooth(int index, int3 pi, float distance, float terrainHeightValue)
		{
			Voxel voxel = Voxels[index];
			float num = 0f;
			uint num2 = 0u;
			for (int i = pi.x - 1; i <= pi.x + 1; i++)
			{
				for (int j = pi.y - 1; j <= pi.y + 1; j++)
				{
					for (int k = pi.z - 1; k <= pi.z + 1; k++)
					{
						Voxel voxelAt = GetVoxelAt(i, j, k);
						num += voxelAt.Value;
						if (voxelAt.Alteration > num2)
						{
							num2 = voxelAt.Alteration;
						}
					}
				}
			}
			num *= 1f / 27f;
			if (math.abs(num - terrainHeightValue) < 0.1f)
			{
				return voxel;
			}
			if (voxel.IsAlteredFarOrNearSurface)
			{
				num2 = voxel.Alteration;
			}
			return ComputeAltered(distance, voxel, num, num2);
		}

		private Voxel ApplySharpen(int index, int3 pi, float distance, float terrainHeightValue)
		{
			Voxel voxel = Voxels[index];
			if (!voxel.IsAlteredFarOrNearSurface)
			{
				return voxel;
			}
			float num = 0f;
			uint alterationNeighbour = 0u;
			num += VoxelValue(pi.x - 1, pi.y, pi.z, -1f, ref alterationNeighbour);
			num += VoxelValue(pi.x + 1, pi.y, pi.z, -1f, ref alterationNeighbour);
			num += VoxelValue(pi.x, pi.y - 1, pi.z, -1f, ref alterationNeighbour);
			num += VoxelValue(pi.x, pi.y + 1, pi.z, -1f, ref alterationNeighbour);
			num += VoxelValue(pi.x, pi.y, pi.z - 1, -1f, ref alterationNeighbour);
			num += VoxelValue(pi.x, pi.y, pi.z + 1, -1f, ref alterationNeighbour);
			num += voxel.Value * 7f;
			if (math.abs(num - terrainHeightValue) < 0.1f)
			{
				return voxel;
			}
			if (voxel.IsAlteredFarOrNearSurface)
			{
				alterationNeighbour = voxel.Alteration;
			}
			if (alterationNeighbour <= 1 || (num <= 0f && voxel.Value >= 0f) || (num >= 0f && voxel.Value <= 0f) || Math.Abs(num) < 0.001f || Math.Abs(num) > Math.Max(Math.Abs(voxel.Value) * 2f, 4f))
			{
				return voxel;
			}
			return ComputeAltered(distance, voxel, num, alterationNeighbour);
		}

		private float VoxelValue(int x, int y, int z, float weight, ref uint alterationNeighbour)
		{
			Voxel voxelAt = GetVoxelAt(x, y, z);
			if (voxelAt.Alteration > alterationNeighbour)
			{
				alterationNeighbour = voxelAt.Alteration;
			}
			return weight * voxelAt.Value;
		}

		private Voxel ComputeAltered(float distance, Voxel voxel, float voxelValue, uint alterationNeighbour)
		{
			if (distance >= 0f)
			{
				voxel.SetValue(Mathf.Lerp(voxel.Value, voxelValue, Intensity), HeightmapScale.y);
				voxel.Alteration = alterationNeighbour;
			}
			return voxel;
		}

		private Voxel GetVoxelAt(int x, int y, int z)
		{
			if (x == -1)
			{
				if (y == -1)
				{
					if (z == -1)
					{
						return GetSafe(NeighborVoxelsLBB, LowInd * SizeVox2 + LowInd * SizeVox + LowInd);
					}
					if (z > SizeOfMesh)
					{
						return GetSafe(NeighborVoxelsLBF, LowInd * SizeVox2 + LowInd * SizeVox + (z - SizeOfMesh));
					}
					return GetSafe(NeighborVoxelsLB_, LowInd * SizeVox2 + LowInd * SizeVox + z);
				}
				if (y > SizeOfMesh)
				{
					if (z == -1)
					{
						return GetSafe(NeighborVoxelsLUB, LowInd * SizeVox2 + (y - SizeOfMesh) * SizeVox + LowInd);
					}
					if (z > SizeOfMesh)
					{
						return GetSafe(NeighborVoxelsLUF, LowInd * SizeVox2 + (y - SizeOfMesh) * SizeVox + (z - SizeOfMesh));
					}
					return GetSafe(NeighborVoxelsLU_, LowInd * SizeVox2 + (y - SizeOfMesh) * SizeVox + z);
				}
				if (z == -1)
				{
					return GetSafe(NeighborVoxelsL_B, LowInd * SizeVox2 + y * SizeVox + LowInd);
				}
				if (z > SizeOfMesh)
				{
					return GetSafe(NeighborVoxelsL_F, LowInd * SizeVox2 + y * SizeVox + (z - SizeOfMesh));
				}
				return GetSafe(NeighborVoxelsL__, LowInd * SizeVox2 + y * SizeVox + z);
			}
			if (x > SizeOfMesh)
			{
				if (y == -1)
				{
					if (z == -1)
					{
						return GetSafe(NeighborVoxelsRBB, (x - SizeOfMesh) * SizeVox2 + LowInd * SizeVox + LowInd);
					}
					if (z > SizeOfMesh)
					{
						return GetSafe(NeighborVoxelsRBF, (x - SizeOfMesh) * SizeVox2 + LowInd * SizeVox + (z - SizeOfMesh));
					}
					return GetSafe(NeighborVoxelsRB_, (x - SizeOfMesh) * SizeVox2 + LowInd * SizeVox + z);
				}
				if (y > SizeOfMesh)
				{
					if (z == -1)
					{
						return GetSafe(NeighborVoxelsRUB, (x - SizeOfMesh) * SizeVox2 + (y - SizeOfMesh) * SizeVox + LowInd);
					}
					if (z > SizeOfMesh)
					{
						return GetSafe(NeighborVoxelsRUF, (x - SizeOfMesh) * SizeVox2 + (y - SizeOfMesh) * SizeVox + (z - SizeOfMesh));
					}
					return GetSafe(NeighborVoxelsRU_, (x - SizeOfMesh) * SizeVox2 + (y - SizeOfMesh) * SizeVox + z);
				}
				if (z == -1)
				{
					return GetSafe(NeighborVoxelsR_B, (x - SizeOfMesh) * SizeVox2 + y * SizeVox + LowInd);
				}
				if (z > SizeOfMesh)
				{
					return GetSafe(NeighborVoxelsR_F, (x - SizeOfMesh) * SizeVox2 + y * SizeVox + (z - SizeOfMesh));
				}
				return GetSafe(NeighborVoxelsR__, (x - SizeOfMesh) * SizeVox2 + y * SizeVox + z);
			}
			if (y == -1)
			{
				if (z == -1)
				{
					return GetSafe(NeighborVoxels_BB, x * SizeVox2 + LowInd * SizeVox + LowInd);
				}
				if (z > SizeOfMesh)
				{
					return GetSafe(NeighborVoxels_BF, x * SizeVox2 + LowInd * SizeVox + (z - SizeOfMesh));
				}
				return GetSafe(NeighborVoxels_B_, x * SizeVox2 + LowInd * SizeVox + z);
			}
			if (y > SizeOfMesh)
			{
				if (z == -1)
				{
					return GetSafe(NeighborVoxels_UB, x * SizeVox2 + (y - SizeOfMesh) * SizeVox + LowInd);
				}
				if (z > SizeOfMesh)
				{
					return GetSafe(NeighborVoxels_UF, x * SizeVox2 + (y - SizeOfMesh) * SizeVox + (z - SizeOfMesh));
				}
				return GetSafe(NeighborVoxels_U_, x * SizeVox2 + (y - SizeOfMesh) * SizeVox + z);
			}
			if (z == -1)
			{
				return GetSafe(NeighborVoxels__B, x * SizeVox2 + y * SizeVox + LowInd);
			}
			if (z > SizeOfMesh)
			{
				return GetSafe(NeighborVoxels__F, x * SizeVox2 + y * SizeVox + (z - SizeOfMesh));
			}
			return Voxels[x * SizeVox2 + y * SizeVox + z];
		}

		private Voxel GetSafe(NativeArray<Voxel> array, int index)
		{
			if (array.Length > 1)
			{
				return array[index];
			}
			return default(Voxel);
		}

		private Voxel GetVoxelAtDebug(int x, int y, int z)
		{
			x = Mathf.Max(0, Mathf.Min(x, LowInd));
			y = Mathf.Max(0, Mathf.Min(y, LowInd));
			z = Mathf.Max(0, Mathf.Min(z, LowInd));
			return Voxels[x * SizeVox2 + y * SizeVox + z];
		}
	}
}
