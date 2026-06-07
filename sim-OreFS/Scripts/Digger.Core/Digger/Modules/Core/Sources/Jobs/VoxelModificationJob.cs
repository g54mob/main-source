using System;
using Digger.Modules.Core.Sources.NativeCollections;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Digger.Modules.Core.Sources.Jobs
{
	[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
	public struct VoxelModificationJob : IJobParallelFor, IDisposable
	{
		private const long DoubleToLongMultiplier = 1000000L;

		public int SizeVox;

		public int SizeVox2;

		public BrushType Brush;

		public ActionType Action;

		public bool PaintWhileDigging;

		public bool BypassDestructability;

		public float3 HeightmapScale;

		public float3 Center;

		public float3 Size;

		public bool UpsideDown;

		public float Intensity;

		public bool IsTargetIntensity;

		public float ChunkAltitude;

		public uint TextureIndex;

		public bool IsIndestructible;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> Heights;

		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<Voxel> InputVoxels;

		public int3 InputSizeVox;

		public int3 InputOriginVox;

		public NativeArray<Voxel> Voxels;

		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> Holes;

		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> NewHolesConcurrentCounter;

		[NativeDisableParallelForRestriction]
		public NativeArray<long> RemovedMatterCounter;

		[NativeDisableParallelForRestriction]
		public NativeArray<long> AddedMatterCounter;

		[NativeDisableParallelForRestriction]
		public NativeArray<int> ModifiedVoxelCounter;

		private double coneAngle;

		private float upsideDownSign;

		public void PostConstruct()
		{
			if (Size.y > 0.1f)
			{
				coneAngle = Math.Atan((double)Size.x / (double)Size.y);
			}
			upsideDownSign = (UpsideDown ? (-1f) : 1f);
		}

		public void Execute(int index)
		{
			int3 int5 = Utils.IndexToXYZ(index, SizeVox, SizeVox2);
			float3 p = int5 * HeightmapScale;
			float num = Heights[Utils.XYZToHeightIndex(int5, SizeVox)];
			float terrainHeightValue = p.y + ChunkAltitude - num;
			float distance;
			switch (Brush)
			{
			default:
				return;
			case BrushType.Sphere:
				distance = ComputeSphereDistances(p);
				break;
			case BrushType.HalfSphere:
				distance = ComputeHalfSphereDistances(p);
				break;
			case BrushType.RoundedCube:
				distance = ComputeCubeDistances(p);
				break;
			case BrushType.Stalagmite:
				distance = ComputeConeDistances(p);
				break;
			case BrushType.Custom:
				distance = GetValueFromInputVoxels(int5);
				break;
			}
			Voxel voxel;
			switch (Action)
			{
			default:
				return;
			case ActionType.Dig:
			case ActionType.Add:
				voxel = ApplyDigAdd(index, Action == ActionType.Dig, distance);
				break;
			case ActionType.Paint:
				voxel = ApplyPaint(index, distance);
				break;
			case ActionType.PaintHoles:
				voxel = ApplyPaintHoles(index, int5, p, distance);
				break;
			case ActionType.Reset:
				voxel = ApplyResetBrush(index, int5, p, distance);
				break;
			}
			if (voxel.Alteration != 0)
			{
				voxel = Utils.AdjustAlteration(voxel, int5, HeightmapScale.y, p.y + ChunkAltitude, terrainHeightValue, SizeVox, Heights);
			}
			if (Action != ActionType.Reset && (voxel.IsAlteredNearBelowSurface || voxel.IsAlteredNearAboveSurface))
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
			Voxels[index] = voxel;
		}

		private float GetValueFromInputVoxels(int3 pi)
		{
			int3 int5 = (int3)math.round((pi - InputOriginVox) / Size);
			if (int5.x < 0 || int5.x >= InputSizeVox.x || int5.y < 0 || int5.y >= InputSizeVox.y || int5.z < 0 || int5.z >= InputSizeVox.z)
			{
				return -100f;
			}
			return InputVoxels[int5.x * InputSizeVox.y * InputSizeVox.z + int5.y * InputSizeVox.z + int5.z].Value;
		}

		private float ComputeSphereDistances(float3 p)
		{
			float x = Size.x;
			float num = x / math.max(Size.y, 0.01f);
			float3 float5 = p - Center;
			float num2 = math.sqrt(float5.x * float5.x + float5.y * float5.y * num * num + float5.z * float5.z);
			return x - num2;
		}

		private float ComputeHalfSphereDistances(float3 p)
		{
			float3 float5 = p - Center;
			float num = math.sqrt(float5.x * float5.x + float5.y * float5.y + float5.z * float5.z);
			return math.min(Size.x - num, float5.y);
		}

		private float ComputeCubeDistances(float3 p)
		{
			float3 float5 = p - Center;
			return math.min(math.min(Size.x - math.abs(float5.x), Size.y - math.abs(float5.y)), Size.z - math.abs(float5.z));
		}

		private float ComputeConeDistances(float3 p)
		{
			float3 float5 = Center + new float3(0f, upsideDownSign * Size.y * 0.95f, 0f);
			float3 float6 = p - float5;
			float num = math.sqrt(float6.x * float6.x + float6.y * float6.y + float6.z * float6.z);
			double num2 = Math.Asin((double)math.sqrt(float6.x * float6.x + float6.z * float6.z) / (double)num);
			return math.min(math.min((float)((double)(0f - num) * Math.Sin(math.abs(num2 - coneAngle)) * (double)Math.Sign(num2 - coneAngle)), Size.y + upsideDownSign * float6.y), (0f - upsideDownSign) * float6.y);
		}

		private Voxel ApplyDigAdd(int index, bool dig, float distance)
		{
			Voxel result = Voxels[index];
			float value = result.Value;
			if (dig && value <= 0.99f * HeightmapScale.y)
			{
				float maxValue = result.GetMaxValue(HeightmapScale.y);
				float value2 = math.select(math.max(value, math.min(value + Intensity * distance, maxValue)), math.max(value, value + Intensity * distance), BypassDestructability);
				result.SetValue(value2, HeightmapScale.y);
				if (distance >= 0f)
				{
					result.Alteration = 5u;
					if (PaintWhileDigging && (!result.IsIndestructible || BypassDestructability))
					{
						result.AddTexture(TextureIndex, 1f);
					}
				}
			}
			else if (!dig && value >= -0.9f * HeightmapScale.y)
			{
				float value3 = math.min(value, value - Intensity * distance);
				result.SetValue(value3, HeightmapScale.y);
				if (distance >= 0f)
				{
					result.Alteration = 5u;
					if (PaintWhileDigging)
					{
						result.AddTexture(TextureIndex, 1f);
						if (IsIndestructible)
						{
							result.SetMaxValue(result.Value, HeightmapScale.y);
						}
					}
				}
			}
			TrackMatterChange(value, result.Value);
			return result;
		}

		private Voxel ApplyPaint(int index, float distance)
		{
			Voxel result = Voxels[index];
			if (distance >= 0f)
			{
				if (IsTargetIntensity)
				{
					if (TextureIndex < 28)
					{
						result.SetTexture(TextureIndex, Intensity);
					}
					else if (TextureIndex == 28)
					{
						result.NormalizedWetnessWeight = Intensity;
					}
					else if (TextureIndex == 29)
					{
						result.NormalizedPuddlesWeight = Intensity;
					}
				}
				else if (TextureIndex < 28)
				{
					result.AddTexture(TextureIndex, Intensity);
				}
				else if (TextureIndex == 28)
				{
					result.NormalizedWetnessWeight += Intensity;
				}
				else if (TextureIndex == 29)
				{
					result.NormalizedPuddlesWeight += Intensity;
				}
				if (IsIndestructible)
				{
					result.SetMaxValue(result.Value, HeightmapScale.y);
				}
				else
				{
					result.ResetMaxValue();
				}
			}
			return result;
		}

		private Voxel ApplyPaintHoles(int index, int3 pi, float3 p, float distance)
		{
			Voxel result = Voxels[index];
			if (distance >= 0f && Intensity > 0f && result.Alteration != 0)
			{
				result.Alteration = 6u;
			}
			else if (distance >= 0f && Intensity < 0f && result.Alteration == 6)
			{
				bool flag = Utils.IsOnSurface(pi, HeightmapScale.y, p.y + ChunkAltitude, SizeVox, Heights);
				result.Alteration = (flag ? 1u : 5u);
			}
			return result;
		}

		private Voxel ApplyResetBrush(int index, int3 pi, float3 p, float distance)
		{
			if (distance >= 0f)
			{
				float num = Heights[Utils.XYZToHeightIndex(pi, SizeVox)];
				Voxel result = new Voxel(p.y + ChunkAltitude - num, HeightmapScale.y);
				if (Utils.IsOnSurface(pi, HeightmapScale.y, p.y + ChunkAltitude, SizeVox, Heights))
				{
					Digger.Modules.Core.Sources.NativeCollections.Utils.SetZeroAt(Holes, Utils.XZToHoleIndex(pi.x, pi.z, SizeVox));
				}
				return result;
			}
			return Voxels[index];
		}

		private void TrackMatterChange(float oldValue, float newValue)
		{
			if (oldValue != newValue)
			{
				Digger.Modules.Core.Sources.NativeCollections.Utils.IncrementAt(ModifiedVoxelCounter, 0);
				if (oldValue < 0f && newValue > oldValue)
				{
					double value = newValue - oldValue;
					Digger.Modules.Core.Sources.NativeCollections.Utils.InterlockedAddDouble(RemovedMatterCounter, 0, value, 1000000L);
				}
				else if (oldValue > 0f && newValue < oldValue)
				{
					double value2 = oldValue - newValue;
					Digger.Modules.Core.Sources.NativeCollections.Utils.InterlockedAddDouble(AddedMatterCounter, 0, value2, 1000000L);
				}
			}
		}

		public void Dispose()
		{
			Heights.Dispose();
			Voxels.Dispose();
			Holes.Dispose();
		}
	}
}
