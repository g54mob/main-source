using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Pug.Conversion
{
	internal static class Math
	{
		private static float3 ToEuler(quaternion q, math.RotationOrder order = math.RotationOrder.ZXY)
		{
			float4 value = q.value;
			float4 float5 = value * value.wwww * new float4(2f);
			float4 float6 = value * value.yzxw * new float4(2f);
			float4 float7 = value * value;
			float3 euler = new float3(0f);
			switch (order)
			{
			case math.RotationOrder.ZYX:
			{
				float num5 = float6.z + float5.y;
				if (num5 * num5 < 0.99999595f)
				{
					float y13 = 0f - float6.x + float5.z;
					float x13 = float7.x + float7.w - float7.y - float7.z;
					float y14 = 0f - float6.y + float5.x;
					float x14 = float7.z + float7.w - float7.y - float7.x;
					euler = new float3(math.atan2(y13, x13), math.asin(num5), math.atan2(y14, x14));
				}
				else
				{
					num5 = math.clamp(num5, -1f, 1f);
					float4 float12 = new float4(float6.z, float5.y, float6.y, float5.x);
					float y15 = 2f * (float12.x * float12.w + float12.y * float12.z);
					float x15 = math.csum(float12 * float12 * new float4(-1f, 1f, -1f, 1f));
					euler = new float3(math.atan2(y15, x15), math.asin(num5), 0f);
				}
				break;
			}
			case math.RotationOrder.ZXY:
			{
				float num3 = float6.y - float5.x;
				if (num3 * num3 < 0.99999595f)
				{
					float y7 = float6.x + float5.z;
					float x7 = float7.y + float7.w - float7.x - float7.z;
					float y8 = float6.z + float5.y;
					float x8 = float7.z + float7.w - float7.x - float7.y;
					euler = new float3(math.atan2(y7, x7), 0f - math.asin(num3), math.atan2(y8, x8));
				}
				else
				{
					num3 = math.clamp(num3, -1f, 1f);
					float4 float10 = new float4(float6.z, float5.y, float6.y, float5.x);
					float y9 = 2f * (float10.x * float10.w + float10.y * float10.z);
					float x9 = math.csum(float10 * float10 * new float4(-1f, 1f, -1f, 1f));
					euler = new float3(math.atan2(y9, x9), 0f - math.asin(num3), 0f);
				}
				break;
			}
			case math.RotationOrder.YXZ:
			{
				float num6 = float6.y + float5.x;
				if (num6 * num6 < 0.99999595f)
				{
					float y16 = 0f - float6.z + float5.y;
					float x16 = float7.z + float7.w - float7.x - float7.y;
					float y17 = 0f - float6.x + float5.z;
					float x17 = float7.y + float7.w - float7.z - float7.x;
					euler = new float3(math.atan2(y16, x16), math.asin(num6), math.atan2(y17, x17));
				}
				else
				{
					num6 = math.clamp(num6, -1f, 1f);
					float4 float13 = new float4(float6.x, float5.z, float6.y, float5.x);
					float y18 = 2f * (float13.x * float13.w + float13.y * float13.z);
					float x18 = math.csum(float13 * float13 * new float4(-1f, 1f, -1f, 1f));
					euler = new float3(math.atan2(y18, x18), math.asin(num6), 0f);
				}
				break;
			}
			case math.RotationOrder.YZX:
			{
				float num2 = float6.x - float5.z;
				if (num2 * num2 < 0.99999595f)
				{
					float y4 = float6.z + float5.y;
					float x4 = float7.x + float7.w - float7.z - float7.y;
					float y5 = float6.y + float5.x;
					float x5 = float7.y + float7.w - float7.x - float7.z;
					euler = new float3(math.atan2(y4, x4), 0f - math.asin(num2), math.atan2(y5, x5));
				}
				else
				{
					num2 = math.clamp(num2, -1f, 1f);
					float4 float9 = new float4(float6.x, float5.z, float6.y, float5.x);
					float y6 = 2f * (float9.x * float9.w + float9.y * float9.z);
					float x6 = math.csum(float9 * float9 * new float4(-1f, 1f, -1f, 1f));
					euler = new float3(math.atan2(y6, x6), 0f - math.asin(num2), 0f);
				}
				break;
			}
			case math.RotationOrder.XZY:
			{
				float num4 = float6.x + float5.z;
				if (num4 * num4 < 0.99999595f)
				{
					float y10 = 0f - float6.y + float5.x;
					float x10 = float7.y + float7.w - float7.z - float7.x;
					float y11 = 0f - float6.z + float5.y;
					float x11 = float7.x + float7.w - float7.y - float7.z;
					euler = new float3(math.atan2(y10, x10), math.asin(num4), math.atan2(y11, x11));
				}
				else
				{
					num4 = math.clamp(num4, -1f, 1f);
					float4 float11 = new float4(float6.x, float5.z, float6.z, float5.y);
					float y12 = 2f * (float11.x * float11.w + float11.y * float11.z);
					float x12 = math.csum(float11 * float11 * new float4(-1f, 1f, -1f, 1f));
					euler = new float3(math.atan2(y12, x12), math.asin(num4), 0f);
				}
				break;
			}
			case math.RotationOrder.XYZ:
			{
				float num = float6.z - float5.y;
				if (num * num < 0.99999595f)
				{
					float y = float6.y + float5.x;
					float x = float7.z + float7.w - float7.y - float7.x;
					float y2 = float6.x + float5.z;
					float x2 = float7.x + float7.w - float7.y - float7.z;
					euler = new float3(math.atan2(y, x), 0f - math.asin(num), math.atan2(y2, x2));
				}
				else
				{
					num = math.clamp(num, -1f, 1f);
					float4 float8 = new float4(float6.z, float5.y, float6.x, float5.z);
					float y3 = 2f * (float8.x * float8.w + float8.y * float8.z);
					float x3 = math.csum(float8 * float8 * new float4(-1f, 1f, -1f, 1f));
					euler = new float3(math.atan2(y3, x3), 0f - math.asin(num), 0f);
				}
				break;
			}
			}
			return EulerReorderBack(euler, order);
		}

		private static float3 EulerReorderBack(float3 euler, math.RotationOrder order)
		{
			return order switch
			{
				math.RotationOrder.XZY => euler.xzy, 
				math.RotationOrder.YZX => euler.zxy, 
				math.RotationOrder.YXZ => euler.yxz, 
				math.RotationOrder.ZXY => euler.yzx, 
				math.RotationOrder.ZYX => euler.zyx, 
				_ => euler, 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float3 ToEulerAngles(this quaternion q, math.RotationOrder order = math.RotationOrder.XYZ)
		{
			return ToEuler(q, order);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static RigidTransform DecomposeRigidBodyTransform(in float4x4 localToWorld)
		{
			return new RigidTransform(DecomposeRigidBodyOrientation(in localToWorld), localToWorld.c3.xyz);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static quaternion DecomposeRigidBodyOrientation(in float4x4 localToWorld)
		{
			return quaternion.LookRotationSafe(localToWorld.c2.xyz, localToWorld.c1.xyz);
		}
	}
}
