using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Pathfinding.Collections;
using Pathfinding.Drawing;
using Unity.Burst;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	[StructLayout((LayoutKind)0, Size = 1)]
	[BurstCompile]
	internal struct DrawGizmosJobUtils
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DrawPath_000012CA_0024PostfixBurstDelegate(ref CommandBuilder draw, ref UnsafeSpan<float3> vertices, ref AgentCylinderShape shape);

		internal static class DrawPath_000012CA_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
			}

			private static IntPtr GetFunctionPointer()
			{
				return (IntPtr)0;
			}

			public static void Invoke(ref CommandBuilder draw, ref UnsafeSpan<float3> vertices, ref AgentCylinderShape shape)
			{
			}
		}

		[BurstCompile]
		[MonoPInvokeCallback(typeof(DrawPath_000012CA_0024PostfixBurstDelegate))]
		internal static void DrawPath(ref CommandBuilder draw, ref UnsafeSpan<float3> vertices, ref AgentCylinderShape shape)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void DrawPath_0024BurstManaged(ref CommandBuilder draw, ref UnsafeSpan<float3> vertices, ref AgentCylinderShape shape)
		{
		}
	}
}
