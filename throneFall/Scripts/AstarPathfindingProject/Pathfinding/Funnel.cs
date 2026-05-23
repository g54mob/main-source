using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding
{
	[BurstCompile]
	public static class Funnel
	{
		public struct FunnelPortals
		{
			public List<Vector3> left;

			public List<Vector3> right;
		}

		public enum PartType
		{
			OffMeshLink = 0,
			NodeSequence = 1
		}

		public struct PathPart
		{
			public int startIndex;

			public int endIndex;

			public Vector3 startPoint;

			public Vector3 endPoint;

			public PartType type;
		}

		[BurstCompile]
		public struct FunnelState
		{
			public delegate void PushStart_00000942_0024PostfixBurstDelegate(ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref NativeCircularBuffer<float4> unwrappedPortals, ref float3 newLeftPortal, ref float3 newRightPortal, ref float3 projectionAxis);

			internal static class PushStart_00000942_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(PushStart_00000942_0024PostfixBurstDelegate).TypeHandle);
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public static void Constructor()
				{
					DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
				}

				public static void Initialize()
				{
				}

				static PushStart_00000942_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static void Invoke(ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref NativeCircularBuffer<float4> unwrappedPortals, ref float3 newLeftPortal, ref float3 newRightPortal, ref float3 projectionAxis)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref NativeCircularBuffer<float3>, ref NativeCircularBuffer<float3>, ref NativeCircularBuffer<float4>, ref float3, ref float3, ref float3, void>)functionPointer)(ref leftPortals, ref rightPortals, ref unwrappedPortals, ref newLeftPortal, ref newRightPortal, ref projectionAxis);
							return;
						}
					}
					PushStart_0024BurstManaged(ref leftPortals, ref rightPortals, ref unwrappedPortals, ref newLeftPortal, ref newRightPortal, ref projectionAxis);
				}
			}

			public delegate void ConvertCornerIndicesToPathProjected_0000094C_0024PostfixBurstDelegate(ref FunnelState funnelState, ref UnsafeSpan<int> indices, bool splitAtEveryPortal, in float3 startPoint, in float3 endPoint, bool lastCorner, in float3 projectionAxis, ref UnsafeSpan<float3> result, in float3 up);

			internal static class ConvertCornerIndicesToPathProjected_0000094C_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(ConvertCornerIndicesToPathProjected_0000094C_0024PostfixBurstDelegate).TypeHandle);
					}
					P_0 = Pointer;
				}

				private static IntPtr GetFunctionPointer()
				{
					nint result = 0;
					GetFunctionPointerDiscard(ref result);
					return result;
				}

				public static void Constructor()
				{
					DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
				}

				public static void Initialize()
				{
				}

				static ConvertCornerIndicesToPathProjected_0000094C_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static void Invoke(ref FunnelState funnelState, ref UnsafeSpan<int> indices, bool splitAtEveryPortal, in float3 startPoint, in float3 endPoint, bool lastCorner, in float3 projectionAxis, ref UnsafeSpan<float3> result, in float3 up)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							((delegate* unmanaged[Cdecl]<ref FunnelState, ref UnsafeSpan<int>, bool, ref float3, ref float3, bool, ref float3, ref UnsafeSpan<float3>, ref float3, void>)functionPointer)(ref funnelState, ref indices, splitAtEveryPortal, ref startPoint, ref endPoint, lastCorner, ref projectionAxis, ref result, ref up);
							return;
						}
					}
					ConvertCornerIndicesToPathProjected_0024BurstManaged(ref funnelState, ref indices, splitAtEveryPortal, in startPoint, in endPoint, lastCorner, in projectionAxis, ref result, in up);
				}
			}

			public NativeCircularBuffer<float3> leftFunnel;

			public NativeCircularBuffer<float3> rightFunnel;

			public NativeCircularBuffer<float4> unwrappedPortals;

			public float3 projectionAxis;

			public FunnelState(int initialCapacity, Allocator allocator)
			{
				leftFunnel = new NativeCircularBuffer<float3>(initialCapacity, allocator);
				rightFunnel = new NativeCircularBuffer<float3>(initialCapacity, allocator);
				unwrappedPortals = new NativeCircularBuffer<float4>(initialCapacity, allocator);
				projectionAxis = float3.zero;
			}

			public FunnelState(FunnelPortals portals, Allocator allocator)
				: this(portals.left.Count, allocator)
			{
				if (portals.left.Count != portals.right.Count)
				{
					throw new ArgumentException("portals.left.Count != portals.right.Count");
				}
				for (int i = 0; i < portals.left.Count; i++)
				{
					PushEnd(portals.left[i], portals.right[i]);
				}
			}

			public FunnelState Clone()
			{
				return new FunnelState
				{
					leftFunnel = leftFunnel.Clone(),
					rightFunnel = rightFunnel.Clone(),
					unwrappedPortals = unwrappedPortals.Clone(),
					projectionAxis = projectionAxis
				};
			}

			public void Clear()
			{
				leftFunnel.Clear();
				rightFunnel.Clear();
				unwrappedPortals.Clear();
				projectionAxis = float3.zero;
			}

			public void PopStart()
			{
				leftFunnel.PopStart();
				rightFunnel.PopStart();
				if (unwrappedPortals.Length > 0)
				{
					unwrappedPortals.PopStart();
				}
			}

			public void PopEnd()
			{
				leftFunnel.PopEnd();
				rightFunnel.PopEnd();
				unwrappedPortals.TrimTo(leftFunnel.Length);
			}

			public void Pop(bool fromStart)
			{
				if (fromStart)
				{
					PopStart();
				}
				else
				{
					PopEnd();
				}
			}

			public void PushStart(float3 newLeftPortal, float3 newRightPortal)
			{
				PushStart(ref leftFunnel, ref rightFunnel, ref unwrappedPortals, ref newLeftPortal, ref newRightPortal, ref projectionAxis);
			}

			private static bool DifferentSidesOfLine(float3 start, float3 end, float3 a, float3 b)
			{
				float3 float5 = math.normalizesafe(end - start);
				float3 x = a - start;
				float3 float6 = b - start;
				x -= float5 * math.dot(x, float5);
				float6 -= float5 * math.dot(float6, float5);
				return math.dot(x, float6) < 0f;
			}

			public bool IsReasonableToPopStart(float3 startPoint, float3 endPoint)
			{
				if (leftFunnel.Length == 0)
				{
					return false;
				}
				int i;
				for (i = 1; i < leftFunnel.Length && VectorMath.IsColinear(leftFunnel.First, rightFunnel.First, leftFunnel[i]); i++)
				{
				}
				return !DifferentSidesOfLine(leftFunnel.First, rightFunnel.First, startPoint, (i < leftFunnel.Length) ? leftFunnel[i] : endPoint);
			}

			public bool IsReasonableToPopEnd(float3 startPoint, float3 endPoint)
			{
				if (leftFunnel.Length == 0)
				{
					return false;
				}
				int num = leftFunnel.Length - 1;
				while (num >= 0 && VectorMath.IsColinear(leftFunnel.Last, rightFunnel.Last, leftFunnel[num]))
				{
					num--;
				}
				return !DifferentSidesOfLine(leftFunnel.Last, rightFunnel.Last, endPoint, (num >= 0) ? leftFunnel[num] : startPoint);
			}

			[BurstCompile]
			private static void PushStart(ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref NativeCircularBuffer<float4> unwrappedPortals, ref float3 newLeftPortal, ref float3 newRightPortal, ref float3 projectionAxis)
			{
				PushStart_00000942_0024BurstDirectCall.Invoke(ref leftPortals, ref rightPortals, ref unwrappedPortals, ref newLeftPortal, ref newRightPortal, ref projectionAxis);
			}

			public void Splice(int startIndex, int toRemove, List<float3> newLeftPortal, List<float3> newRightPortal)
			{
				leftFunnel.Splice(startIndex, toRemove, newLeftPortal);
				rightFunnel.Splice(startIndex, toRemove, newRightPortal);
				unwrappedPortals.TrimTo(startIndex);
			}

			public void PushEnd(Vector3 newLeftPortal, Vector3 newRightPortal)
			{
				leftFunnel.PushEnd(newLeftPortal);
				rightFunnel.PushEnd(newRightPortal);
			}

			public void Push(bool toStart, Vector3 newLeftPortal, Vector3 newRightPortal)
			{
				if (toStart)
				{
					PushStart(newLeftPortal, newRightPortal);
				}
				else
				{
					PushEnd(newLeftPortal, newRightPortal);
				}
			}

			public void Dispose()
			{
				leftFunnel.Dispose();
				rightFunnel.Dispose();
				unwrappedPortals.Dispose();
			}

			public int CalculateNextCornerIndices(int maxCorners, NativeArray<int> result, float3 startPoint, float3 endPoint, out bool lastCorner)
			{
				if (result.Length < math.min(maxCorners, leftFunnel.Length))
				{
					throw new ArgumentException("result array may not be large enough to hold all corners");
				}
				UnsafeSpan<int> funnelPath = result.AsUnsafeSpan();
				return Calculate(ref unwrappedPortals, ref leftFunnel, ref rightFunnel, ref startPoint, ref endPoint, ref funnelPath, maxCorners, ref projectionAxis, out lastCorner);
			}

			public void CalculateNextCorners(int maxCorners, bool splitAtEveryPortal, float3 startPoint, float3 endPoint, NativeList<float3> result)
			{
				NativeArray<int> nativeArray = new NativeArray<int>(math.min(maxCorners, leftFunnel.Length), Allocator.Temp);
				bool lastCorner;
				int numCorners = CalculateNextCornerIndices(maxCorners, nativeArray, startPoint, endPoint, out lastCorner);
				ConvertCornerIndicesToPath(nativeArray, numCorners, splitAtEveryPortal, startPoint, endPoint, lastCorner, result);
				nativeArray.Dispose();
			}

			public void ConvertCornerIndicesToPath(NativeArray<int> indices, int numCorners, bool splitAtEveryPortal, float3 startPoint, float3 endPoint, bool lastCorner, NativeList<float3> result)
			{
				if (result.Capacity < numCorners)
				{
					result.Capacity = numCorners;
				}
				result.Add(in startPoint);
				if (leftFunnel.Length == 0)
				{
					if (lastCorner)
					{
						result.Add(in endPoint);
					}
				}
				else if (splitAtEveryPortal)
				{
					float2 float5 = Unwrap(leftFunnel[0], rightFunnel[0], unwrappedPortals[0].xy, unwrappedPortals[0].zw, startPoint, -1f, projectionAxis);
					int num = 0;
					for (int i = 0; i < numCorners; i++)
					{
						int num2 = indices[i] & 0x3FFFFFFF;
						bool flag = (indices[i] & 0x40000000) != 0;
						float2 float6 = (flag ? unwrappedPortals[num2].zw : unwrappedPortals[num2].xy);
						CalculatePortalIntersections(num + 1, num2 - 1, leftFunnel, rightFunnel, unwrappedPortals, float5, float6, result);
						num = math.abs(num2);
						float5 = float6;
						result.Add(flag ? rightFunnel[num2] : leftFunnel[num2]);
					}
					if (lastCorner)
					{
						float2 to = Unwrap(leftFunnel.Last, rightFunnel.Last, unwrappedPortals.Last.xy, unwrappedPortals.Last.zw, endPoint, 1f, projectionAxis);
						CalculatePortalIntersections(num + 1, unwrappedPortals.Length - 1, leftFunnel, rightFunnel, unwrappedPortals, float5, to, result);
						result.Add(in endPoint);
					}
				}
				else
				{
					for (int j = 0; j < numCorners; j++)
					{
						int num3 = indices[j];
						result.Add(((num3 & 0x40000000) != 0) ? rightFunnel[num3 & 0x3FFFFFFF] : leftFunnel[num3 & 0x3FFFFFFF]);
					}
					if (lastCorner)
					{
						result.Add(in endPoint);
					}
				}
			}

			public void ConvertCornerIndicesToPathProjected(UnsafeSpan<int> indices, bool splitAtEveryPortal, float3 startPoint, float3 endPoint, bool lastCorner, NativeList<float3> result, float3 up)
			{
				int num = indices.Length + 1 + (lastCorner ? 1 : 0);
				if (result.Capacity < num)
				{
					result.Capacity = num;
				}
				result.ResizeUninitialized(num);
				UnsafeSpan<float3> result2 = result.AsUnsafeSpan();
				ConvertCornerIndicesToPathProjected(ref this, ref indices, splitAtEveryPortal, in startPoint, in endPoint, lastCorner, in projectionAxis, ref result2, in up);
			}

			public float4x3 UnwrappedPortalsToWorldMatrix(float3 up)
			{
				int i;
				for (i = 0; i < unwrappedPortals.Length && math.lengthsq(unwrappedPortals[i].xy - unwrappedPortals[i].zw) <= 1E-05f; i++)
				{
				}
				if (i >= unwrappedPortals.Length)
				{
					return new float4x3(1f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 1f);
				}
				float2 xy = unwrappedPortals[i].xy;
				float2 zw = unwrappedPortals[i].zw;
				float3 float5 = leftFunnel[i];
				float3 obj = rightFunnel[i];
				float2 float6 = zw - xy;
				float3 float7 = obj - float5;
				float2 float8 = float6 * math.rcp(math.lengthsq(float6));
				float2x2 a = new float2x2(new float2(float8.x, 0f - float8.y), new float2(float8.y, float8.x));
				float2 float9 = math.mul(a, -xy);
				return math.mul(b: new float4x3(new float4(a.c0.x, 0f, a.c0.y, 0f), new float4(a.c1.x, 0f, a.c1.y, 0f), new float4(float9.x, 0f, float9.y, 1f)), a: new float4x4(new float4(float7, 0f), new float4(up, 0f), new float4(math.cross(float7, up), 0f), new float4(float5, 1f)));
			}

			[BurstCompile]
			public static void ConvertCornerIndicesToPathProjected(ref FunnelState funnelState, ref UnsafeSpan<int> indices, bool splitAtEveryPortal, in float3 startPoint, in float3 endPoint, bool lastCorner, in float3 projectionAxis, ref UnsafeSpan<float3> result, in float3 up)
			{
				ConvertCornerIndicesToPathProjected_0000094C_0024BurstDirectCall.Invoke(ref funnelState, ref indices, splitAtEveryPortal, in startPoint, in endPoint, lastCorner, in projectionAxis, ref result, in up);
			}

			private static void CalculatePortalIntersections(int startIndex, int endIndex, NativeCircularBuffer<float3> leftPortals, NativeCircularBuffer<float3> rightPortals, NativeCircularBuffer<float4> unwrappedPortals, float2 from, float2 to, NativeList<float3> result)
			{
				for (int i = startIndex; i < endIndex; i++)
				{
					float4 float5 = unwrappedPortals[i];
					float2 xy = float5.xy;
					float2 zw = float5.zw;
					if (!VectorMath.LineLineIntersectionFactor(xy, zw - xy, from, to - from, out var t))
					{
						t = 0.5f;
					}
					result.Add(math.lerp(leftPortals[i], rightPortals[i], t));
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			public static void PushStart_0024BurstManaged(ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref NativeCircularBuffer<float4> unwrappedPortals, ref float3 newLeftPortal, ref float3 newRightPortal, ref float3 projectionAxis)
			{
				if (unwrappedPortals.Length == 0)
				{
					leftPortals.PushStart(newLeftPortal);
					rightPortals.PushStart(newRightPortal);
					return;
				}
				float4 first = unwrappedPortals.First;
				float2 float5 = Unwrap(leftPortals.First, rightPortals.First, first.xy, first.zw, newRightPortal, -1f, projectionAxis);
				float2 xy = Unwrap(leftPortals.First, newRightPortal, first.xy, float5, newLeftPortal, -1f, projectionAxis);
				leftPortals.PushStart(newLeftPortal);
				rightPortals.PushStart(newRightPortal);
				unwrappedPortals.PushStart(new float4(xy, float5));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile]
			public static void ConvertCornerIndicesToPathProjected_0024BurstManaged(ref FunnelState funnelState, ref UnsafeSpan<int> indices, bool splitAtEveryPortal, in float3 startPoint, in float3 endPoint, bool lastCorner, in float3 projectionAxis, ref UnsafeSpan<float3> result, in float3 up)
			{
				int num = 0;
				result[num++] = startPoint;
				if (funnelState.leftFunnel.Length == 0)
				{
					if (lastCorner)
					{
						result[num++] = endPoint;
					}
					return;
				}
				float4x3 a = funnelState.UnwrappedPortalsToWorldMatrix(up);
				if (splitAtEveryPortal)
				{
					throw new NotImplementedException();
				}
				for (int i = 0; i < indices.Length; i++)
				{
					int num2 = indices[i];
					float2 xy = (((num2 & 0x40000000) != 0) ? funnelState.unwrappedPortals[num2 & 0x3FFFFFFF].zw : funnelState.unwrappedPortals[num2 & 0x3FFFFFFF].xy);
					result[num++] = math.mul(a, new float3(xy, 1f)).xyz;
				}
				if (lastCorner)
				{
					float2 xy2 = Unwrap(funnelState.leftFunnel.Last, funnelState.rightFunnel.Last, funnelState.unwrappedPortals.Last.xy, funnelState.unwrappedPortals.Last.zw, endPoint, 1f, projectionAxis);
					result[num++] = math.mul(a, new float3(xy2, 1f)).xyz;
				}
			}
		}

		public delegate int Calculate_00000936_0024PostfixBurstDelegate(ref NativeCircularBuffer<float4> unwrappedPortals, ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref float3 startPoint, ref float3 endPoint, ref UnsafeSpan<int> funnelPath, int maxCorners, ref float3 projectionAxis, out bool lastCorner);

		internal static class Calculate_00000936_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(Calculate_00000936_0024PostfixBurstDelegate).TypeHandle);
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public static void Constructor()
			{
				DeferredCompilation = BurstCompiler.CompileILPPMethod2((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/);
			}

			public static void Initialize()
			{
			}

			static Calculate_00000936_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static int Invoke(ref NativeCircularBuffer<float4> unwrappedPortals, ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref float3 startPoint, ref float3 endPoint, ref UnsafeSpan<int> funnelPath, int maxCorners, ref float3 projectionAxis, out bool lastCorner)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<ref NativeCircularBuffer<float4>, ref NativeCircularBuffer<float3>, ref NativeCircularBuffer<float3>, ref float3, ref float3, ref UnsafeSpan<int>, int, ref float3, ref bool, int>)functionPointer)(ref unwrappedPortals, ref leftPortals, ref rightPortals, ref startPoint, ref endPoint, ref funnelPath, maxCorners, ref projectionAxis, ref lastCorner);
					}
				}
				return Calculate_0024BurstManaged(ref unwrappedPortals, ref leftPortals, ref rightPortals, ref startPoint, ref endPoint, ref funnelPath, maxCorners, ref projectionAxis, out lastCorner);
			}
		}

		public const int RightSideBit = 1073741824;

		public const int FunnelPortalIndexMask = 1073741823;

		public static List<PathPart> SplitIntoParts(Path path)
		{
			List<GraphNode> path2 = path.path;
			List<PathPart> list = ListPool<PathPart>.Claim();
			if (path2 == null || path2.Count == 0)
			{
				return list;
			}
			int i;
			for (i = 0; i < path2.Count; i++)
			{
				GraphNode graphNode = path2[i];
				if (graphNode is TriangleMeshNode || graphNode is GridNodeBase)
				{
					int num = i;
					for (uint graphIndex = graphNode.GraphIndex; i < path2.Count && (path2[i].GraphIndex == graphIndex || path2[i] is NodeLink3Node); i++)
					{
					}
					i--;
					int num2 = i;
					list.Add(new PathPart
					{
						type = PartType.NodeSequence,
						startIndex = num,
						endIndex = num2,
						startPoint = ((num == 0) ? path.vectorPath[0] : ((Vector3)path2[num - 1].position)),
						endPoint = ((num2 == path2.Count - 1) ? path.vectorPath[path.vectorPath.Count - 1] : ((Vector3)path2[num2 + 1].position))
					});
				}
				else
				{
					if (!(graphNode is LinkNode))
					{
						throw new Exception("Unsupported node type or null node");
					}
					int num3 = i;
					for (uint graphIndex2 = graphNode.GraphIndex; i < path2.Count && path2[i].GraphIndex == graphIndex2; i++)
					{
					}
					i--;
					if (i - num3 == 0)
					{
						if (num3 > 0 && num3 + 1 < path2.Count && path2[num3 - 1] == path2[num3 + 1])
						{
							path2.RemoveRange(num3, 2);
							i--;
							throw new Exception("Link node connected back to the previous node in the path. This should not happen.");
						}
						path2.RemoveAt(num3);
						i--;
					}
					else
					{
						if (i - num3 != 1)
						{
							throw new Exception("Off mesh link included more than two nodes: " + (i - num3 + 1));
						}
						list.Add(new PathPart
						{
							type = PartType.OffMeshLink,
							startIndex = num3,
							endIndex = i,
							startPoint = (Vector3)path2[num3].position,
							endPoint = (Vector3)path2[i].position
						});
					}
				}
			}
			if (list[0].type == PartType.OffMeshLink)
			{
				list.RemoveAt(0);
			}
			if (list[list.Count - 1].type == PartType.OffMeshLink)
			{
				list.RemoveAt(list.Count - 1);
			}
			return list;
		}

		public static void Simplify(List<PathPart> parts, ref List<GraphNode> nodes)
		{
			List<GraphNode> list = ListPool<GraphNode>.Claim();
			for (int i = 0; i < parts.Count; i++)
			{
				PathPart pathPart = parts[i];
				PathPart value = pathPart;
				value.startIndex = list.Count;
				if (pathPart.type == PartType.NodeSequence && nodes[pathPart.startIndex].Graph is IRaycastableGraph graph)
				{
					Simplify(pathPart, graph, nodes, list, Path.ZeroTagPenalties, -1);
					value.endIndex = list.Count - 1;
					parts[i] = value;
					continue;
				}
				for (int j = pathPart.startIndex; j <= pathPart.endIndex; j++)
				{
					list.Add(nodes[j]);
				}
				value.endIndex = list.Count - 1;
				parts[i] = value;
			}
			ListPool<GraphNode>.Release(ref nodes);
			nodes = list;
		}

		public static void Simplify(PathPart part, IRaycastableGraph graph, List<GraphNode> nodes, List<GraphNode> result, int[] tagPenalties, int traversableTags)
		{
			int num = part.startIndex;
			int endIndex = part.endIndex;
			Vector3 startPoint = part.startPoint;
			Vector3 endPoint = part.endPoint;
			if (graph == null)
			{
				throw new ArgumentNullException("graph");
			}
			if (num > endIndex)
			{
				throw new ArgumentException("start > end");
			}
			if (!graph.Linecast(startPoint, endPoint, out var hit) && hit.node == nodes[endIndex])
			{
				graph.Linecast(startPoint, endPoint, out hit, result);
				long num2 = 0L;
				long num3 = 0L;
				for (int i = num; i <= endIndex; i++)
				{
					num2 += nodes[i].Penalty + tagPenalties[nodes[i].Tag];
				}
				bool flag = true;
				for (int j = 0; j < result.Count; j++)
				{
					num3 += result[j].Penalty + tagPenalties[result[j].Tag];
					flag &= ((traversableTags >> (int)result[j].Tag) & 1) == 1;
				}
				if (flag && !((double)num2 * 1.4 * (double)result.Count < (double)(num3 * (endIndex - num + 1))))
				{
					return;
				}
				result.Clear();
			}
			int num4 = num;
			int num5 = 0;
			while (true)
			{
				if (num5++ > 1000)
				{
					Debug.LogError("Was the path really long or have we got cought in an infinite loop?");
					return;
				}
				if (num == endIndex)
				{
					break;
				}
				int count = result.Count;
				int num6 = endIndex + 1;
				int num7 = num + 1;
				bool flag2 = false;
				while (num6 > num7 + 1)
				{
					int num8 = (num6 + num7) / 2;
					Vector3 start = ((num == num4) ? startPoint : ((Vector3)nodes[num].position));
					Vector3 end = ((num8 == endIndex) ? endPoint : ((Vector3)nodes[num8].position));
					if (graph.Linecast(start, end, out var hit2) || hit2.node != nodes[num8])
					{
						num6 = num8;
						continue;
					}
					flag2 = true;
					num7 = num8;
				}
				if (!flag2)
				{
					result.Add(nodes[num]);
					num = num7;
					continue;
				}
				Vector3 start2 = ((num == num4) ? startPoint : ((Vector3)nodes[num].position));
				Vector3 end2 = ((num7 == endIndex) ? endPoint : ((Vector3)nodes[num7].position));
				graph.Linecast(start2, end2, out var _, result);
				long num9 = 0L;
				long num10 = 0L;
				for (int k = num; k <= num7; k++)
				{
					num9 += nodes[k].Penalty + tagPenalties[nodes[k].Tag];
				}
				bool flag3 = true;
				for (int l = count; l < result.Count; l++)
				{
					num10 += result[l].Penalty + tagPenalties[result[l].Tag];
					flag3 &= ((traversableTags >> (int)result[l].Tag) & 1) == 1;
				}
				if (!flag3 || (double)num9 * 1.4 * (double)(result.Count - count) < (double)(num10 * (num7 - num + 1)) || result[result.Count - 1] != nodes[num7])
				{
					result.RemoveRange(count, result.Count - count);
					result.Add(nodes[num]);
					num++;
				}
				else
				{
					result.RemoveAt(result.Count - 1);
					num = num7;
				}
			}
			result.Add(nodes[endIndex]);
		}

		public static FunnelPortals ConstructFunnelPortals(List<GraphNode> nodes, PathPart part)
		{
			if (nodes == null || nodes.Count == 0)
			{
				return new FunnelPortals
				{
					left = ListPool<Vector3>.Claim(0),
					right = ListPool<Vector3>.Claim(0)
				};
			}
			if (part.endIndex < part.startIndex || part.startIndex < 0 || part.endIndex > nodes.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			List<Vector3> list = ListPool<Vector3>.Claim(nodes.Count + 1);
			List<Vector3> list2 = ListPool<Vector3>.Claim(nodes.Count + 1);
			list.Add(part.startPoint);
			list2.Add(part.startPoint);
			for (int i = part.startIndex; i < part.endIndex; i++)
			{
				if (nodes[i].GetPortal(nodes[i + 1], out var left, out var right))
				{
					list.Add(left);
					list2.Add(right);
					continue;
				}
				list.Add((Vector3)nodes[i].position);
				list2.Add((Vector3)nodes[i].position);
				list.Add((Vector3)nodes[i + 1].position);
				list2.Add((Vector3)nodes[i + 1].position);
			}
			list.Add(part.endPoint);
			list2.Add(part.endPoint);
			return new FunnelPortals
			{
				left = list,
				right = list2
			};
		}

		private static float2 Unwrap(float3 leftPortal, float3 rightPortal, float2 leftUnwrappedPortal, float2 rightUnwrappedPortal, float3 point, float sideMultiplier, float3 projectionAxis)
		{
			if (!math.all(projectionAxis == 0f))
			{
				leftPortal -= projectionAxis * math.dot(leftPortal, projectionAxis);
				rightPortal -= projectionAxis * math.dot(rightPortal, projectionAxis);
				point -= projectionAxis * math.dot(point, projectionAxis);
			}
			float3 float5 = rightPortal - leftPortal;
			float num = 1f / math.lengthsq(float5);
			if (float.IsPositiveInfinity(num))
			{
				return leftUnwrappedPortal + new float2(0f - math.length(point - leftPortal), 0f);
			}
			float num2 = math.length(math.cross(point - leftPortal, float5)) * num;
			float num3 = math.dot(point - leftPortal, float5) * num;
			if (num2 < 0.002f)
			{
				if (math.abs(num3) < 0.002f)
				{
					return leftUnwrappedPortal;
				}
				if (math.abs(num3 - 1f) < 0.002f)
				{
					return rightUnwrappedPortal;
				}
			}
			float2 a = rightUnwrappedPortal - leftUnwrappedPortal;
			return leftUnwrappedPortal + math.mad(c: new float2(0f - a.y, a.x) * (num2 * sideMultiplier), a: a, b: num3);
		}

		private static bool RightOrColinear(Vector2 a, Vector2 b)
		{
			return a.x * b.y - b.x * a.y <= 0f;
		}

		private static bool LeftOrColinear(Vector2 a, Vector2 b)
		{
			return a.x * b.y - b.x * a.y >= 0f;
		}

		public static List<Vector3> Calculate(FunnelPortals funnel, bool splitAtEveryPortal)
		{
			FunnelState funnelState = new FunnelState(funnel, Allocator.Temp);
			float3 first = funnelState.leftFunnel.First;
			float3 last = funnelState.leftFunnel.Last;
			funnelState.PopStart();
			funnelState.PopEnd();
			NativeList<float3> result = new NativeList<float3>(Allocator.Temp);
			funnelState.CalculateNextCorners(int.MaxValue, splitAtEveryPortal, first, last, result);
			funnelState.Dispose();
			List<Vector3> list = ListPool<Vector3>.Claim(result.Length);
			for (int i = 0; i < result.Length; i++)
			{
				list.Add(result[i]);
			}
			result.Dispose();
			return list;
		}

		[BurstCompile]
		private static int Calculate(ref NativeCircularBuffer<float4> unwrappedPortals, ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref float3 startPoint, ref float3 endPoint, ref UnsafeSpan<int> funnelPath, int maxCorners, ref float3 projectionAxis, out bool lastCorner)
		{
			return Calculate_00000936_0024BurstDirectCall.Invoke(ref unwrappedPortals, ref leftPortals, ref rightPortals, ref startPoint, ref endPoint, ref funnelPath, maxCorners, ref projectionAxis, out lastCorner);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static int Calculate_0024BurstManaged(ref NativeCircularBuffer<float4> unwrappedPortals, ref NativeCircularBuffer<float3> leftPortals, ref NativeCircularBuffer<float3> rightPortals, ref float3 startPoint, ref float3 endPoint, ref UnsafeSpan<int> funnelPath, int maxCorners, ref float3 projectionAxis, out bool lastCorner)
		{
			lastCorner = false;
			if (leftPortals.Length <= 0)
			{
				lastCorner = true;
				return 0;
			}
			if (maxCorners <= 0)
			{
				return 0;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			if (unwrappedPortals.Length == 0)
			{
				unwrappedPortals.PushEnd(new float4(new float2(0f, 0f), new float2(math.length(rightPortals[0] - leftPortals[0]))));
			}
			float2 float5 = Unwrap(leftPortals[0], rightPortals[0], unwrappedPortals[0].xy, unwrappedPortals[0].zw, startPoint, -1f, projectionAxis);
			float2 float6 = float2.zero;
			float2 float7 = float2.zero;
			for (int i = 0; i <= leftPortals.Length; i++)
			{
				float2 float8;
				float2 float9;
				if (i == unwrappedPortals.Length)
				{
					if (i == leftPortals.Length)
					{
						float8 = (float9 = Unwrap(leftPortals[i - 1], rightPortals[i - 1], unwrappedPortals[i - 1].xy, unwrappedPortals[i - 1].zw, endPoint, 1f, projectionAxis) - float5);
					}
					else
					{
						float2 float10 = Unwrap(leftPortals[i - 1], rightPortals[i - 1], unwrappedPortals[i - 1].xy, unwrappedPortals[i - 1].zw, leftPortals[i], 1f, projectionAxis);
						float2 float11 = Unwrap(leftPortals[i], rightPortals[i - 1], float10, unwrappedPortals[i - 1].zw, rightPortals[i], 1f, projectionAxis);
						unwrappedPortals.PushEnd(new float4(float10, float11));
						float8 = float10 - float5;
						float9 = float11 - float5;
					}
				}
				else
				{
					float8 = unwrappedPortals[i].xy - float5;
					float9 = unwrappedPortals[i].zw - float5;
				}
				if (LeftOrColinear(float7, float9))
				{
					if (!RightOrColinear(float6, float9))
					{
						float7 = (float6 = float2.zero);
						i = (num = (num2 = num3));
						float5 = unwrappedPortals[i].xy;
						funnelPath[num4++] = num;
						if (num4 >= maxCorners)
						{
							return num4;
						}
						continue;
					}
					float7 = float9;
					num2 = i;
				}
				if (!RightOrColinear(float6, float8))
				{
					continue;
				}
				if (LeftOrColinear(float7, float8))
				{
					float6 = float8;
					num3 = i;
					continue;
				}
				float7 = (float6 = float2.zero);
				i = (num = (num3 = num2));
				float5 = unwrappedPortals[i].zw;
				funnelPath[num4++] = num | 0x40000000;
				if (num4 < maxCorners)
				{
					continue;
				}
				return num4;
			}
			lastCorner = true;
			return num4;
		}
	}
}
