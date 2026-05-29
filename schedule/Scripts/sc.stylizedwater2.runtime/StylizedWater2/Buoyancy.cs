using System;
using Unity.Mathematics;
using UnityEngine;

namespace StylizedWater2
{
	public static class Buoyancy
	{
		private static WaveParameters waveParameters;

		private static Material lastMaterial;

		private static readonly int TimeParametersID;

		private static float4 sine;

		private static float4 cosine;

		private static float4 dotABCD;

		private static float4 AB;

		private static float4 CD;

		private static float4 direction1;

		private static float4 direction2;

		private static float4 TIME;

		private static float2 planarPosition;

		private static float4 amp;

		private static float4 freq;

		private static float4 speed;

		private static float4 dir1;

		private static float4 dir2;

		private static float4 steepness;

		private static float4 frequency;

		private static float3 offsets;

		private static RaycastHit hit;

		private static Vector3 m_offset;

		private static float _TimeParameters => 0f;

		private static void GetMaterialParameters(Material mat)
		{
		}

		[Obsolete("Set the static 'WaterObject.CustomTime' parameter instead.", false)]
		public static void SetCustomTime(float value)
		{
		}

		public static float3 FindWaterLevelIntersection(float3 origin, float3 direction, float waterLevel)
		{
			return default(float3);
		}

		public static void Raycast(WaterObject waterObject, float3 origin, float3 direction, bool dynamicMaterial, out RaycastHit hit)
		{
			hit = default(RaycastHit);
		}

		public static void Raycast(Material waterMat, float waterLevel, float3 origin, float3 direction, bool dynamicMaterial, out RaycastHit hit)
		{
			hit = default(RaycastHit);
		}

		public static float SampleWaves(Vector3 position, WaterObject waterObject, float rollStrength, bool dynamicMaterial, out Vector3 normal)
		{
			normal = default(Vector3);
			return 0f;
		}

		private static void RecalculateParameters()
		{
		}

		private static void SampleWaves(Vector3 position, Material waterMat, float waterLevel, float rollStrength, bool dynamicMaterial, out Vector3 offset, out Vector3 normal)
		{
			offset = default(Vector3);
			normal = default(Vector3);
		}

		public static float SampleWaves(Vector3 position, Material waterMat, float waterLevel, float rollStrength, bool dynamicMaterial, out Vector3 normal)
		{
			normal = default(Vector3);
			return 0f;
		}

		public static bool CanTouchWater(float3 position, WaterObject waterObject)
		{
			return false;
		}

		public static bool CanTouchWater(float3 position, Material waterMaterial, float waterLevel)
		{
			return false;
		}
	}
}
