using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Wings.Physics;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Airfoils
{
	public interface IAirfoil
	{
		bool LeadingColocated { get; }

		bool LeadingSmooth { get; }

		bool TrailingColocated { get; }

		bool TrailingSmooth { get; }

		float LeadingEdgeRadius { get; }

		void GenerateCrossSection(ref NativeAirfoil section, int samples);

		void GenerateCollider(NativeList<float3> points, int samples, float3 offset, float3 up, float scale);

		float2 SamplePoint(float x);

		float WarpDensity(float x);

		RuntimeAirfoil GetRuntimeAirfoil(List<IntPtr> mallocPtrs);
	}
}
