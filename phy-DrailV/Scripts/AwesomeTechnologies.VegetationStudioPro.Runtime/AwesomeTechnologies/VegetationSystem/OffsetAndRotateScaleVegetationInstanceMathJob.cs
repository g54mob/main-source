using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct OffsetAndRotateScaleVegetationInstanceMathJob : IJobParallelForDefer
	{
		public NativeArray<float3> Position;

		public NativeArray<int> RandomNumberIndex;

		public NativeArray<quaternion> Rotation;

		public NativeArray<float3> Scale;

		public NativeArray<float3> TerrainNormal;

		public NativeArray<byte> Excluded;

		[ReadOnly]
		public NativeArray<float> RandomNumbers;

		public VegetationRotationType VegetationRotationType;

		public float MinScale;

		public float MaxScale;

		public float3 Offset;

		public float3 RotationOffset;

		public float3 ScaleMultiplier;

		public float MinUpOffset;

		public float MaxUpOffset;

		public void Execute(int index)
		{
			if (Excluded[index] == 1)
			{
				return;
			}
			float3 float5 = new float3(0f, 1f, 0f);
			switch (VegetationRotationType)
			{
			case VegetationRotationType.RotateY:
				Rotation[index] = quaternion.Euler(new float3(0f, RandomRange(RandomNumberIndex[index], 0f, 6.28f), 0f));
				RandomNumberIndex[index]++;
				break;
			case VegetationRotationType.RotateXYZ:
				Rotation[index] = quaternion.Euler(new float3(RandomRange(RandomNumberIndex[index], 0f, 6.28f), RandomRange(RandomNumberIndex[index] + 1, 0f, 6.28f), RandomRange(RandomNumberIndex[index] + 2, 0f, 6.28f)));
				RandomNumberIndex[index] += 3;
				float5 = TerrainNormal[index];
				break;
			case VegetationRotationType.FollowTerrain:
			{
				Vector3 vector = math.cross(-TerrainNormal[index], new float3(1f, 0f, 0f));
				if (vector.y < 0f)
				{
					vector = -vector;
				}
				Rotation[index] = Quaternion.LookRotation(vector, TerrainNormal[index]);
				Rotation[index] = math.mul(Rotation[index], quaternion.AxisAngle(new float3(0f, 1f, 0f), RandomRange(RandomNumberIndex[index], 0f, 365f)));
				RandomNumberIndex[index]++;
				float5 = TerrainNormal[index];
				break;
			}
			case VegetationRotationType.FollowTerrainScale:
			{
				Vector3 vector = math.cross(-TerrainNormal[index], new float3(1f, 0f, 0f));
				if (vector.y < 0f)
				{
					vector = -vector;
				}
				Rotation[index] = Quaternion.LookRotation(vector, TerrainNormal[index]);
				Rotation[index] = math.mul(Rotation[index], quaternion.AxisAngle(new float3(0f, 1f, 0f), RandomRange(RandomNumberIndex[index], 0f, 365f)));
				RandomNumberIndex[index]++;
				float num = math.clamp(math.degrees(math.acos(math.dot(TerrainNormal[index], new float3(0f, 1f, 0f)))) / 45f, 0f, 1f);
				float3 float6 = new float3(num, 0f, num);
				Scale[index] += float6;
				float5 = TerrainNormal[index];
				break;
			}
			}
			float num2 = RandomRange(RandomNumberIndex[index], MinScale, MaxScale);
			RandomNumberIndex[index]++;
			float3 float7 = new float3(num2, num2, num2);
			Scale[index] *= float7;
			Scale[index] *= ScaleMultiplier;
			quaternion b = quaternion.Euler(math.radians(RotationOffset));
			Rotation[index] = math.mul(Rotation[index], b);
			quaternion q = Rotation[index];
			float3 v = Offset * Scale[index];
			Position[index] += math.mul(q, v);
			float y = Scale[index].y;
			float num3 = RandomRange(RandomNumberIndex[index], MinUpOffset * y, MaxUpOffset * y);
			RandomNumberIndex[index]++;
			Position[index] += float5 * num3;
		}

		public float RandomRange(int randomNumberIndex, float min, float max)
		{
			while (randomNumberIndex > 9999)
			{
				randomNumberIndex -= 10000;
			}
			return math.lerp(min, max, RandomNumbers[randomNumberIndex]);
		}
	}
}
