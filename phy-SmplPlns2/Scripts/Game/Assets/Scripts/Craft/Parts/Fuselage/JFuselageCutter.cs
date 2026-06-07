using Assets.Scripts.Bindings.Manifold;
using Assets.Scripts.Craft.MeshGen;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Fuselage
{
	public static class JFuselageCutter
	{
		public static Manifold<Vertex> MakeCutVolume(int materialId, float zOffset, float2 min1, float2 max1, float2 min2, float2 max2)
		{
			if (zOffset < 1.4E-44f || math.all(math.float4(max1, max2) - math.float4(min1, min2) <= float.Epsilon))
			{
				return null;
			}
			float num = zOffset * 2f;
			float num2 = 0f - num;
			float2 float5 = 0.5f * (min1 + min2);
			float2 float6 = 0.5f * (max1 + max2);
			float2 float7 = 0.5f * (min2 - min1) / zOffset;
			float2 float8 = 0.5f * (max2 - max1) / zOffset;
			float2 float9 = float8 - float7;
			float2 float10 = (float6 - float5) / -float9;
			_ = float5 + float7 * float10;
			if (math.any(math.isnan(float10)))
			{
				return null;
			}
			if (float9.x > float.Epsilon)
			{
				num2 = math.max(num2, float10.x);
				num = math.max(num, float10.x);
			}
			else if (float9.x < -1E-45f)
			{
				num2 = math.min(num2, float10.x);
				num = math.min(num, float10.x);
			}
			if (float9.y > float.Epsilon)
			{
				num2 = math.max(num2, float10.y);
				num = math.max(num, float10.y);
			}
			else if (float9.y < -1E-45f)
			{
				num2 = math.min(num2, float10.y);
				num = math.min(num, float10.y);
			}
			float2 float11 = float5 + float7 * num2;
			float2 float12 = math.max(float11, float6 + float8 * num2);
			float2 float13 = float5 + float7 * num;
			float2 float14 = math.max(float13, float6 + float8 * num);
			float2 falseValue = float12 - float11;
			float2 falseValue2 = float14 - float13;
			float11 = math.select(float11, float12, num2 == float10);
			float13 = math.select(float13, float14, num == float10);
			falseValue = math.select(falseValue, 0f, num2 == float10);
			falseValue2 = math.select(falseValue2, 0f, num == float10);
			if (num2 >= num || math.any((falseValue == 0f) & (falseValue2 == 0f)))
			{
				return null;
			}
			NativeMesh nativeMesh = new NativeMesh(24, 12, Allocator.Temp, materialId);
			if (math.all(falseValue > 0f))
			{
				nativeMesh.RQuad(math.float3(float11.x, float11.y, num2), math.float3(float12.x, float11.y, num2), math.float3(float12.x, float12.y, num2), math.float3(float11.x, float12.y, num2));
			}
			if (math.all(falseValue2 > 0f))
			{
				nativeMesh.Quad(math.float3(float13.x, float13.y, num), math.float3(float14.x, float13.y, num), math.float3(float14.x, float14.y, num), math.float3(float13.x, float14.y, num));
			}
			if (falseValue.x > 0f)
			{
				if (falseValue2.x > 0f)
				{
					nativeMesh.RQuad(math.float3(float11.x, float12.y, num2), math.float3(float12.x, float12.y, num2), math.float3(float14.x, float14.y, num), math.float3(float13.x, float14.y, num));
					nativeMesh.Quad(math.float3(float11.x, float11.y, num2), math.float3(float12.x, float11.y, num2), math.float3(float14.x, float13.y, num), math.float3(float13.x, float13.y, num));
				}
				else
				{
					nativeMesh.RTri(math.float3(float11.x, float12.y, num2), math.float3(float12.x, float12.y, num2), math.float3(float14.x, float14.y, num));
					nativeMesh.Tri(math.float3(float11.x, float11.y, num2), math.float3(float12.x, float11.y, num2), math.float3(float14.x, float13.y, num));
				}
			}
			else if (falseValue2.x > 0f)
			{
				nativeMesh.RTri(math.float3(float11.x, float12.y, num2), math.float3(float14.x, float14.y, num), math.float3(float13.x, float14.y, num));
				nativeMesh.Tri(math.float3(float11.x, float11.y, num2), math.float3(float14.x, float13.y, num), math.float3(float13.x, float13.y, num));
			}
			if (falseValue.y > 0f)
			{
				if (falseValue2.y > 0f)
				{
					nativeMesh.RQuad(math.float3(float12.x, float11.y, num2), math.float3(float14.x, float13.y, num), math.float3(float14.x, float14.y, num), math.float3(float12.x, float12.y, num2));
					nativeMesh.Quad(math.float3(float11.x, float11.y, num2), math.float3(float13.x, float13.y, num), math.float3(float13.x, float14.y, num), math.float3(float11.x, float12.y, num2));
				}
				else
				{
					nativeMesh.RTri(math.float3(float12.x, float11.y, num2), math.float3(float14.x, float13.y, num), math.float3(float12.x, float12.y, num2));
					nativeMesh.Tri(math.float3(float11.x, float11.y, num2), math.float3(float13.x, float13.y, num), math.float3(float11.x, float12.y, num2));
				}
			}
			else if (falseValue2.y > 0f)
			{
				nativeMesh.RTri(math.float3(float12.x, float11.y, num2), math.float3(float14.x, float13.y, num), math.float3(float14.x, float14.y, num));
				nativeMesh.Tri(math.float3(float11.x, float11.y, num2), math.float3(float13.x, float13.y, num), math.float3(float13.x, float14.y, num));
			}
			Error status;
			Manifold<Vertex> manifold = nativeMesh.ToManifold(Allocator.Temp, out status);
			if (manifold == null || status != Error.NO_ERROR)
			{
				Debug.LogError($"Failed to build cutting box manifold: {status}");
				manifold?.Dispose();
				return null;
			}
			return manifold;
		}
	}
}
