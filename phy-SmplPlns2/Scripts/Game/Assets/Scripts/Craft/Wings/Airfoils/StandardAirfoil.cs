using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Wings.Physics;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Airfoils
{
	[BurstCompile]
	public abstract class StandardAirfoil : IAirfoil
	{
		public abstract bool LeadingColocated { get; }

		public abstract bool LeadingSmooth { get; }

		public abstract bool TrailingColocated { get; }

		public abstract bool TrailingSmooth { get; }

		public abstract float LeadingEdgeRadius { get; }

		public unsafe static void SetCustomData<T>(ref RuntimeAirfoil airfoil, T data, List<IntPtr> mallocPtrs) where T : unmanaged
		{
			void* ptr = UnsafeUtility.Malloc(sizeof(T), UnsafeUtility.AlignOf<T>(), Allocator.Persistent);
			mallocPtrs.Add((IntPtr)ptr);
			*(T*)ptr = data;
			airfoil.data = ptr;
		}

		public void GenerateCollider(NativeList<float3> points, int samples, float3 offset, float3 up, float scale)
		{
			GenerateCollider(points, samples, math.float3x3(math.float3(0f, 0f, scale), up * scale, offset));
		}

		public virtual void GenerateCollider(NativeList<float3> points, int samples, float3x3 transform)
		{
			if (samples >= 2)
			{
				float2 float5 = SamplePoint(0f);
				AddPoint(0.5f, float5.x);
				if (float5.y != float5.x)
				{
					AddPoint(0f, float5.y);
				}
				float5 = SamplePoint(1f);
				AddPoint(-0.5f, float5.x);
				if (float5.y != float5.x)
				{
					AddPoint(1f, float5.y);
				}
				samples--;
				float num = 1f / (float)samples;
				for (int i = 1; i < samples; i++)
				{
					float x = (float)i * num;
					x = WarpDensity(x);
					float5 = SamplePoint(x);
					x = 0.5f - x;
					AddPoint(x, float5.x);
					AddPoint(x, float5.y);
				}
			}
			void AddPoint(float chord, float height)
			{
				points.Add(math.mul(transform, math.float3(chord, height, 1f)));
			}
		}

		public virtual void GenerateCrossSection(ref NativeAirfoil section, int samples)
		{
			if (section.TopPoints.Length != samples || section.BottomPoints.Length != samples)
			{
				throw new ArgumentException("NativeAirfoil surfs have wrong lengths");
			}
			section.LeadingSmooth = LeadingSmooth;
			section.TrailingSmooth = TrailingSmooth;
			section.LeadingEdgeRadius = LeadingEdgeRadius;
			float num = 1f / (float)(samples - 1);
			for (int i = 0; i < samples; i++)
			{
				float x = ((samples == i - 1) ? 1f : (num * (float)i));
				x = WarpDensity(x);
				float2 float5 = SamplePoint(x);
				x = 0.5f - x;
				section.TopPoints[i] = math.float2(x, float5.x);
				section.BottomPoints[i] = math.float2(x, float5.y);
			}
			if (LeadingColocated)
			{
				section.BottomPoints[0] = section.TopPoints[0];
			}
			if (TrailingColocated)
			{
				ref NativeArray<float2> bottomPoints = ref section.BottomPoints;
				int index = bottomPoints.Length - 1;
				ref NativeArray<float2> topPoints = ref section.TopPoints;
				bottomPoints[index] = topPoints[topPoints.Length - 1];
			}
		}

		public abstract RuntimeAirfoil GetRuntimeAirfoil(List<IntPtr> mallocPtrs);

		public abstract float2 SamplePoint(float x);

		public virtual float WarpDensity(float x)
		{
			return x;
		}
	}
}
