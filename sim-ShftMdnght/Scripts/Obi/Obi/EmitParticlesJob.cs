using System;
using System.Threading;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;

namespace Obi
{
	[BurstCompile]
	internal struct EmitParticlesJob : IJobParallelFor
	{
		[ReadOnly]
		[DeallocateOnJobCompletion]
		public NativeArray<int> activeParticles;

		[ReadOnly]
		public NativeArray<float4> positions;

		[ReadOnly]
		public NativeArray<float4> velocities;

		[ReadOnly]
		public NativeArray<float4> principalRadii;

		[NativeDisableParallelForRestriction]
		public NativeArray<float4> angularVelocities;

		[NativeDisableParallelForRestriction]
		public NativeArray<float4> outputPositions;

		[NativeDisableParallelForRestriction]
		public NativeArray<float4> outputVelocities;

		[NativeDisableParallelForRestriction]
		public NativeArray<float4> outputColors;

		[NativeDisableParallelForRestriction]
		public NativeArray<float4> outputAttributes;

		[NativeDisableParallelForRestriction]
		public NativeArray<int> dispatchBuffer;

		public float2 vorticityRange;

		public float2 velocityRange;

		public float potentialIncrease;

		public float potentialDiffusion;

		public float foamGenerationRate;

		public float lifetime;

		public float lifetimeRandom;

		public float particleSize;

		public float sizeRandom;

		public float buoyancy;

		public float drag;

		public float airdrag;

		public float airAging;

		public float isosurface;

		public float4 foamColor;

		public float deltaTime;

		private float3 hash33(float3 p3)
		{
			p3 = math.frac(p3 * new float3(0.1031f, 0.103f, 0.0973f));
			p3 += math.dot(p3, p3.yxz + 33.33f);
			return math.frac((p3.xxy + p3.yxx) * p3.zyx);
		}

		private float hash13(float3 p3)
		{
			p3 = math.frac(p3 * 0.1031f);
			p3 += math.dot(p3, p3.zyx + 31.32f);
			return math.frac((p3.x + p3.y) * p3.z);
		}

		private void RandomInCylinder(float seed, float4 pos1, float4 pos2, float radius, out float4 position, out float3 velocity)
		{
			float3 float5 = hash33(math.lerp(pos1.xyz, pos2.xyz, seed));
			float3 float6 = pos2.xyz - pos1.xyz;
			float num = math.length(float6);
			float3 float7 = ((num > 1E-07f) ? (float6 / num) : float6);
			float3 float8 = math.normalizesafe(math.cross(float7, new float3(1f, 0f, 0f)));
			float3 float9 = math.cross(float8, float7);
			float x = float5.y * 2f * MathF.PI;
			float2 float10 = radius * math.sqrt(float5.x) * new float2(math.cos(x), math.sin(x));
			velocity = float8 * float10.x + float9 * float10.y;
			position = new float4(pos1.xyz + float7 * num * float5.z + velocity, 0f);
		}

		public unsafe void Execute(int i)
		{
			int* unsafePtr = (int*)dispatchBuffer.GetUnsafePtr();
			int index = activeParticles[i];
			float4 value = angularVelocities[index];
			float2 enc = BurstMath.UnpackFloatRG(value.w);
			float num = BurstMath.Remap01(math.length(value.xyz), vorticityRange.x, vorticityRange.y);
			float num2 = BurstMath.Remap01(math.length(velocities[index].xyz), velocityRange.x, velocityRange.y);
			float num3 = num2 * num * deltaTime * potentialIncrease;
			enc.y = math.saturate(enc.y * potentialDiffusion + num3);
			enc.x += foamGenerationRate * enc.y * deltaTime;
			int num4 = (int)enc.x;
			enc.x -= num4;
			for (int j = 0; j < num4; j++)
			{
				int num5 = Interlocked.Add(ref unsafePtr[3], 1) - 1;
				if (num5 < outputPositions.Length)
				{
					RandomInCylinder(j, positions[index], positions[index] + velocities[index] * deltaTime, principalRadii[index].x, out var position, out var velocity);
					float num6 = num2 * (lifetime - hash13(positions[index].xyz) * lifetime * lifetimeRandom);
					float z = particleSize - hash13(positions[index].xyz + new float3(0.51f, 0.23f, 0.1f)) * particleSize * sizeRandom;
					outputPositions[num5] = position;
					outputVelocities[num5] = velocities[index] + new float4(velocity, buoyancy);
					outputColors[num5] = foamColor;
					outputAttributes[num5] = new float4(1f, 1f / num6, z, BurstMath.PackFloatRGBA(new float4(airAging / 50f, airdrag, drag, isosurface)));
				}
			}
			value.w = BurstMath.PackFloatRG(enc);
			angularVelocities[index] = value;
		}
	}
}
