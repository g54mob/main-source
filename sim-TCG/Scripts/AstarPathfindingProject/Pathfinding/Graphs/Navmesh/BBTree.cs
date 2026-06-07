using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Pathfinding.Drawing;
using Pathfinding.Util;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
{
	[BurstCompile]
	public struct BBTree : IDisposable
	{
		[BurstCompile]
		public readonly struct ProjectionParams
		{
			public delegate float SquaredRectPointDistanceOnPlane_00000A99_0024PostfixBurstDelegate(in ProjectionParams projection, ref IntRect rect, ref float3 p);

			internal static class SquaredRectPointDistanceOnPlane_00000A99_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(SquaredRectPointDistanceOnPlane_00000A99_0024PostfixBurstDelegate).TypeHandle);
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

				static SquaredRectPointDistanceOnPlane_00000A99_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static float Invoke(in ProjectionParams projection, ref IntRect rect, ref float3 p)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							return ((delegate* unmanaged[Cdecl]<ref ProjectionParams, ref IntRect, ref float3, float>)functionPointer)(ref projection, ref rect, ref p);
						}
					}
					return SquaredRectPointDistanceOnPlane_0024BurstManaged(in projection, ref rect, ref p);
				}
			}

			public readonly float2x3 planeProjection;

			public readonly float2 projectedUpNormalized;

			public readonly float3 projectionAxis;

			public readonly float distanceScaleAlongProjectionAxis;

			public readonly DistanceMetric distanceMetric;

			private readonly byte alignedWithXZPlaneBacking;

			public bool alignedWithXZPlane => alignedWithXZPlaneBacking != 0;

			public float SquaredRectPointDistanceOnPlane(IntRect rect, float3 p)
			{
				return SquaredRectPointDistanceOnPlane(in this, ref rect, ref p);
			}

			[BurstCompile(FloatMode = FloatMode.Fast)]
			private static float SquaredRectPointDistanceOnPlane(in ProjectionParams projection, ref IntRect rect, ref float3 p)
			{
				return SquaredRectPointDistanceOnPlane_00000A99_0024BurstDirectCall.Invoke(in projection, ref rect, ref p);
			}

			public ProjectionParams(NNConstraint constraint, GraphTransform graphTransform)
			{
				if (constraint != null && constraint.distanceMetric.projectionAxis != Vector3.zero)
				{
					if (float.IsPositiveInfinity(constraint.distanceMetric.projectionAxis.x))
					{
						projectionAxis = new float3(0f, 1f, 0f);
					}
					else
					{
						projectionAxis = math.normalizesafe(graphTransform.InverseTransformVector(constraint.distanceMetric.projectionAxis));
					}
					if (projectionAxis.x * projectionAxis.x + projectionAxis.z * projectionAxis.z < 0.0001f)
					{
						projectedUpNormalized = float2.zero;
						planeProjection = new float2x3(1f, 0f, 0f, 0f, 0f, 1f);
						distanceMetric = DistanceMetric.ScaledManhattan;
						alignedWithXZPlaneBacking = 1;
						distanceScaleAlongProjectionAxis = math.max(constraint.distanceMetric.distanceScaleAlongProjectionDirection, 0f);
						return;
					}
					float3 float5 = math.normalizesafe(math.cross(new float3(1f, 0f, 1f), projectionAxis));
					if (math.all(float5 == 0f))
					{
						float5 = math.normalizesafe(math.cross(new float3(-1f, 0f, 1f), projectionAxis));
					}
					float3 c = math.normalizesafe(math.cross(projectionAxis, float5));
					planeProjection = math.transpose(new float3x2(float5, c));
					projectedUpNormalized = ((math.lengthsq(planeProjection.c1) <= 0.0001f) ? float2.zero : math.normalize(planeProjection.c1));
					distanceMetric = DistanceMetric.ScaledManhattan;
					alignedWithXZPlaneBacking = (byte)(math.all(projectedUpNormalized == 0f) ? 1 : 0);
					distanceScaleAlongProjectionAxis = math.max(constraint.distanceMetric.distanceScaleAlongProjectionDirection, 0f);
				}
				else
				{
					projectionAxis = float3.zero;
					planeProjection = default(float2x3);
					projectedUpNormalized = default(float2);
					distanceMetric = DistanceMetric.Euclidean;
					alignedWithXZPlaneBacking = 1;
					distanceScaleAlongProjectionAxis = 0f;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile(FloatMode = FloatMode.Fast)]
			public static float SquaredRectPointDistanceOnPlane_0024BurstManaged(in ProjectionParams projection, ref IntRect rect, ref float3 p)
			{
				if (projection.alignedWithXZPlane)
				{
					float2 a = new float2(rect.xmin, rect.ymin) * 0.001f;
					float2 b = new float2(rect.xmax, rect.ymax) * 0.001f;
					return math.lengthsq(math.clamp(p.xz, a, b) - p.xz);
				}
				float3 b2 = new float3(rect.xmin, 0f, rect.ymin) * 0.001f - p;
				float3 b3 = new float3(rect.xmax, 0f, rect.ymax) * 0.001f - p;
				float3 b4 = new float3(rect.xmin, 0f, rect.ymax) * 0.001f - p;
				float3 b5 = new float3(rect.xmax, 0f, rect.ymin) * 0.001f - p;
				float2 c = math.mul(projection.planeProjection, b2);
				float2 c2 = math.mul(projection.planeProjection, b4);
				float2 c3 = math.mul(projection.planeProjection, b5);
				float2 c4 = math.mul(projection.planeProjection, b3);
				float4 x = math.mul(b: new float2(projection.projectedUpNormalized.y, 0f - projection.projectedUpNormalized.x), a: math.transpose(new float2x4(c, c2, c3, c4)));
				float num = math.clamp(0f, math.cmin(x), math.cmax(x));
				return num * num;
			}
		}

		private struct CloseNode
		{
			public int node;

			public float distanceSq;

			public float tieBreakingDistance;

			public float3 closestPointOnNode;
		}

		public enum DistanceMetric : byte
		{
			Euclidean = 0,
			ScaledManhattan = 1
		}

		[BurstCompile]
		private struct NearbyNodesIterator : IEnumerator<CloseNode>, IEnumerator, IDisposable
		{
			public struct BoxWithDist
			{
				public int index;

				public float distSqr;
			}

			public delegate bool MoveNext_00000AA0_0024PostfixBurstDelegate(ref NearbyNodesIterator it);

			internal static class MoveNext_00000AA0_0024BurstDirectCall
			{
				private static IntPtr Pointer;

				private static IntPtr DeferredCompilation;

				[BurstDiscard]
				private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
				{
					if (Pointer == (IntPtr)0)
					{
						Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(MoveNext_00000AA0_0024PostfixBurstDelegate).TypeHandle);
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

				static MoveNext_00000AA0_0024BurstDirectCall()
				{
					Constructor();
				}

				public unsafe static bool Invoke(ref NearbyNodesIterator it)
				{
					if (BurstCompiler.IsEnabled)
					{
						IntPtr functionPointer = GetFunctionPointer();
						if (functionPointer != (IntPtr)0)
						{
							return ((delegate* unmanaged[Cdecl]<ref NearbyNodesIterator, bool>)functionPointer)(ref it);
						}
					}
					return MoveNext_0024BurstManaged(ref it);
				}
			}

			public UnsafeSpan<BoxWithDist> stack;

			public int stackSize;

			public UnsafeSpan<BBTreeBox> tree;

			public UnsafeSpan<int> nodes;

			public UnsafeSpan<int> triangles;

			public UnsafeSpan<Int3> vertices;

			public int indexInLeaf;

			public float3 point;

			public ProjectionParams projection;

			public float distanceThresholdSqr;

			public float tieBreakingDistanceThreshold;

			internal CloseNode current;

			public CloseNode Current => current;

			object IEnumerator.Current
			{
				get
				{
					throw new NotSupportedException();
				}
			}

			public bool MoveNext()
			{
				return MoveNext(ref this);
			}

			void IDisposable.Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[BurstCompile(FloatMode = FloatMode.Default)]
			private static bool MoveNext(ref NearbyNodesIterator it)
			{
				return MoveNext_00000AA0_0024BurstDirectCall.Invoke(ref it);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[BurstCompile(FloatMode = FloatMode.Default)]
			public static bool MoveNext_0024BurstManaged(ref NearbyNodesIterator it)
			{
				float num = it.distanceThresholdSqr;
				while (true)
				{
					if (it.stackSize == 0)
					{
						return false;
					}
					BoxWithDist boxWithDist = it.stack[it.stackSize - 1];
					if (boxWithDist.distSqr > num)
					{
						it.stackSize--;
						it.indexInLeaf = 0;
						continue;
					}
					BBTreeBox bBTreeBox = it.tree[boxWithDist.index];
					if (bBTreeBox.IsLeaf)
					{
						for (int i = it.indexInLeaf; i < 4; i++)
						{
							int num2 = it.nodes[bBTreeBox.nodeOffset + i];
							if (num2 == -1)
							{
								break;
							}
							uint num3 = (uint)(num2 * 3);
							uint num4 = (uint)(num2 * 3 + 1);
							uint num5 = (uint)(num2 * 3 + 2);
							if (num5 >= it.triangles.length)
							{
								throw new Exception("Invalid node index");
							}
							Hint.Assume(num3 < it.triangles.length && num4 < it.triangles.length && num5 < it.triangles.length);
							Int3 vi = it.vertices[it.triangles[num3]];
							Int3 vi2 = it.vertices[it.triangles[num4]];
							Int3 vi3 = it.vertices[it.triangles[num5]];
							if (it.projection.distanceMetric == DistanceMetric.Euclidean)
							{
								Polygon.ClosestPointOnTriangleByRef((float3)vi, (float3)vi2, (float3)vi3, in it.point, out var output);
								float num6 = math.distancesq(output, it.point);
								if (num6 < num)
								{
									it.indexInLeaf = i + 1;
									it.current = new CloseNode
									{
										node = num2,
										distanceSq = num6,
										tieBreakingDistance = 0f,
										closestPointOnNode = output
									};
									return true;
								}
							}
							else
							{
								Polygon.ClosestPointOnTriangleProjected(ref vi, ref vi2, ref vi3, ref it.projection, ref it.point, out var closest, out var sqrDist, out var distAlongProjection);
								if (sqrDist < num || (sqrDist == num && distAlongProjection < it.tieBreakingDistanceThreshold))
								{
									it.indexInLeaf = i + 1;
									it.current = new CloseNode
									{
										node = num2,
										distanceSq = sqrDist,
										tieBreakingDistance = distAlongProjection,
										closestPointOnNode = closest
									};
									return true;
								}
							}
						}
						it.indexInLeaf = 0;
						it.stackSize--;
					}
					else
					{
						it.stackSize--;
						int a = bBTreeBox.left;
						int b = bBTreeBox.right;
						float a2 = it.projection.SquaredRectPointDistanceOnPlane(it.tree[a].rect, it.point);
						float b2 = it.projection.SquaredRectPointDistanceOnPlane(it.tree[b].rect, it.point);
						if (b2 < a2)
						{
							Memory.Swap(ref a, ref b);
							Memory.Swap(ref a2, ref b2);
						}
						if (it.stackSize + 2 > it.stack.Length)
						{
							break;
						}
						if (b2 <= num)
						{
							it.stack[it.stackSize++] = new BoxWithDist
							{
								index = b,
								distSqr = b2
							};
						}
						if (a2 <= num)
						{
							it.stack[it.stackSize++] = new BoxWithDist
							{
								index = a,
								distSqr = a2
							};
						}
					}
				}
				throw new InvalidOperationException("Tree is too deep. Overflowed the internal stack.");
			}
		}

		private struct BBTreeBox
		{
			public IntRect rect;

			public int nodeOffset;

			public int left;

			public int right;

			public bool IsLeaf => nodeOffset >= 0;

			public BBTreeBox(IntRect rect)
			{
				nodeOffset = -1;
				this.rect = rect;
				left = (right = -1);
			}
		}

		public delegate void Build_00000A8E_0024PostfixBurstDelegate(ref UnsafeSpan<int> triangles, ref UnsafeSpan<Int3> vertices, out BBTree bbTree);

		internal static class Build_00000A8E_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			private static IntPtr DeferredCompilation;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = (nint)BurstCompiler.GetILPPMethodFunctionPointer2(DeferredCompilation, (RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/, typeof(Build_00000A8E_0024PostfixBurstDelegate).TypeHandle);
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

			static Build_00000A8E_0024BurstDirectCall()
			{
				Constructor();
			}

			public unsafe static void Invoke(ref UnsafeSpan<int> triangles, ref UnsafeSpan<Int3> vertices, out BBTree bbTree)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<ref UnsafeSpan<int>, ref UnsafeSpan<Int3>, ref BBTree, void>)functionPointer)(ref triangles, ref vertices, ref bbTree);
						return;
					}
				}
				Build_0024BurstManaged(ref triangles, ref vertices, out bbTree);
			}
		}

		private UnsafeList<BBTreeBox> tree;

		private UnsafeList<int> nodePermutation;

		private const int MaximumLeafSize = 4;

		private const int MAX_TREE_HEIGHT = 26;

		public IntRect Size
		{
			get
			{
				if (tree.Length != 0)
				{
					return tree[0].rect;
				}
				return default(IntRect);
			}
		}

		public void Dispose()
		{
			nodePermutation.Dispose();
			tree.Dispose();
		}

		public BBTree(UnsafeSpan<int> triangles, UnsafeSpan<Int3> vertices)
		{
			if (triangles.Length % 3 != 0)
			{
				throw new ArgumentException("triangles must be a multiple of 3 in length");
			}
			Build(ref triangles, ref vertices, out this);
		}

		[BurstCompile]
		private static void Build(ref UnsafeSpan<int> triangles, ref UnsafeSpan<Int3> vertices, out BBTree bbTree)
		{
			Build_00000A8E_0024BurstDirectCall.Invoke(ref triangles, ref vertices, out bbTree);
		}

		private static int SplitByX(NativeArray<IntRect> nodesBounds, NativeArray<int> permutation, int from, int to, int divider)
		{
			int num = to;
			for (int i = from; i < num; i++)
			{
				IntRect intRect = nodesBounds[permutation[i]];
				if ((intRect.xmin + intRect.xmax) / 2 > divider)
				{
					num--;
					int value = permutation[num];
					permutation[num] = permutation[i];
					permutation[i] = value;
					i--;
				}
			}
			return num;
		}

		private static int SplitByZ(NativeArray<IntRect> nodesBounds, NativeArray<int> permutation, int from, int to, int divider)
		{
			int num = to;
			for (int i = from; i < num; i++)
			{
				IntRect intRect = nodesBounds[permutation[i]];
				if ((intRect.ymin + intRect.ymax) / 2 > divider)
				{
					num--;
					int value = permutation[num];
					permutation[num] = permutation[i];
					permutation[i] = value;
					i--;
				}
			}
			return num;
		}

		private static int BuildSubtree(NativeArray<int> permutation, NativeArray<IntRect> nodeBounds, ref UnsafeList<int> nodes, ref UnsafeList<BBTreeBox> tree, int from, int to, bool odd, int depth)
		{
			IntRect rect = NodeBounds(permutation, nodeBounds, from, to);
			int length = tree.Length;
			tree.Add(new BBTreeBox(rect));
			if (to - from <= 4)
			{
				if (depth > 26)
				{
					Debug.LogWarning($"Maximum tree height of {26} exceeded (got depth of {depth}). Querying this tree may fail. Is the tree very unbalanced?");
				}
				BBTreeBox value = tree[length];
				int num = (value.nodeOffset = nodes.Length);
				tree[length] = value;
				nodes.Length += 4;
				for (int i = 0; i < 4; i++)
				{
					nodes[num + i] = ((i < to - from) ? permutation[from + i] : (-1));
				}
				return length;
			}
			int num2;
			if (odd)
			{
				int divider = (rect.xmin + rect.xmax) / 2;
				num2 = SplitByX(nodeBounds, permutation, from, to, divider);
			}
			else
			{
				int divider2 = (rect.ymin + rect.ymax) / 2;
				num2 = SplitByZ(nodeBounds, permutation, from, to, divider2);
			}
			int num3 = (to - from) / 8;
			if (num2 <= from + num3 || num2 >= to - num3)
			{
				if (!odd)
				{
					int divider3 = (rect.xmin + rect.xmax) / 2;
					num2 = SplitByX(nodeBounds, permutation, from, to, divider3);
				}
				else
				{
					int divider4 = (rect.ymin + rect.ymax) / 2;
					num2 = SplitByZ(nodeBounds, permutation, from, to, divider4);
				}
				if (num2 <= from + num3 || num2 >= to - num3)
				{
					num2 = (from + to) / 2;
				}
			}
			int left = BuildSubtree(permutation, nodeBounds, ref nodes, ref tree, from, num2, !odd, depth + 1);
			int right = BuildSubtree(permutation, nodeBounds, ref nodes, ref tree, num2, to, !odd, depth + 1);
			BBTreeBox value2 = tree[length];
			value2.left = left;
			value2.right = right;
			tree[length] = value2;
			return length;
		}

		private static IntRect NodeBounds(NativeArray<int> permutation, NativeArray<IntRect> nodeBounds, int from, int to)
		{
			int2 x = (int2)nodeBounds[permutation[from]].Min;
			int2 x2 = (int2)nodeBounds[permutation[from]].Max;
			for (int i = from + 1; i < to; i++)
			{
				IntRect intRect = nodeBounds[permutation[i]];
				int2 y = new int2(intRect.xmin, intRect.ymin);
				int2 y2 = new int2(intRect.xmax, intRect.ymax);
				x = math.min(x, y);
				x2 = math.max(x2, y2);
			}
			return new IntRect(x.x, x.y, x2.x, x2.y);
		}

		public float DistanceSqrLowerBound(float3 p, in ProjectionParams projection)
		{
			if (tree.Length == 0)
			{
				return float.PositiveInfinity;
			}
			return projection.SquaredRectPointDistanceOnPlane(tree[0].rect, p);
		}

		public unsafe void QueryClosest(float3 p, NNConstraint constraint, in ProjectionParams projection, ref float distanceSqr, ref NNInfo previous, GraphNode[] nodes, UnsafeSpan<int> triangles, UnsafeSpan<Int3> vertices)
		{
			if (tree.Length == 0)
			{
				return;
			}
			NearbyNodesIterator.BoxWithDist* ptr = stackalloc NearbyNodesIterator.BoxWithDist[26];
			UnsafeSpan<NearbyNodesIterator.BoxWithDist> stack = new UnsafeSpan<NearbyNodesIterator.BoxWithDist>(ptr, 26);
			stack[0] = new NearbyNodesIterator.BoxWithDist
			{
				index = 0,
				distSqr = 0f
			};
			NearbyNodesIterator nearbyNodesIterator = new NearbyNodesIterator
			{
				stack = stack,
				stackSize = 1,
				indexInLeaf = 0,
				point = p,
				projection = projection,
				distanceThresholdSqr = distanceSqr,
				tieBreakingDistanceThreshold = float.PositiveInfinity,
				tree = tree.AsUnsafeSpan(),
				nodes = nodePermutation.AsUnsafeSpan(),
				triangles = triangles,
				vertices = vertices
			};
			NNInfo nNInfo = previous;
			while (nearbyNodesIterator.stackSize > 0 && nearbyNodesIterator.MoveNext())
			{
				CloseNode current = nearbyNodesIterator.current;
				if (constraint == null || constraint.Suitable(nodes[current.node]))
				{
					nearbyNodesIterator.distanceThresholdSqr = current.distanceSq;
					nearbyNodesIterator.tieBreakingDistanceThreshold = current.tieBreakingDistance;
					nNInfo = new NNInfo(nodes[current.node], current.closestPointOnNode, current.distanceSq);
				}
			}
			distanceSqr = nearbyNodesIterator.distanceThresholdSqr;
			previous = nNInfo;
		}

		public void DrawGizmos(CommandBuilder draw)
		{
			Gizmos.color = new Color(1f, 1f, 1f, 0.5f);
			if (tree.Length != 0)
			{
				DrawGizmos(ref draw, 0, 0);
			}
		}

		private void DrawGizmos(ref CommandBuilder draw, int boxi, int depth)
		{
			BBTreeBox bBTreeBox = tree[boxi];
			Vector3 vector = (Vector3)new Int3(bBTreeBox.rect.xmin, 0, bBTreeBox.rect.ymin);
			Vector3 vector2 = (Vector3)new Int3(bBTreeBox.rect.xmax, 0, bBTreeBox.rect.ymax);
			Vector3 vector3 = (vector + vector2) * 0.5f;
			Vector3 vector4 = vector2 - vector;
			vector4 = new Vector3(vector4.x, 1f, vector4.z);
			vector3.y += depth * 2;
			draw.xz.WireRectangle(vector3, new float2(vector4.x, vector4.z), AstarMath.IntToColor(depth, 1f));
			if (!bBTreeBox.IsLeaf)
			{
				DrawGizmos(ref draw, bBTreeBox.left, depth + 1);
				DrawGizmos(ref draw, bBTreeBox.right, depth + 1);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		public static void Build_0024BurstManaged(ref UnsafeSpan<int> triangles, ref UnsafeSpan<Int3> vertices, out BBTree bbTree)
		{
			int num = triangles.Length / 3;
			UnsafeList<BBTreeBox> unsafeList = new UnsafeList<BBTreeBox>((int)((float)num * 2.1f), Allocator.Persistent);
			UnsafeList<int> nodes = new UnsafeList<int>((int)((float)num * 1.1f), Allocator.Persistent);
			NativeArray<int> permutation = new NativeArray<int>(num, Allocator.Temp);
			for (int i = 0; i < num; i++)
			{
				permutation[i] = i;
			}
			NativeArray<IntRect> nodeBounds = new NativeArray<IntRect>(num, Allocator.Temp);
			for (int j = 0; j < num; j++)
			{
				int2 xz = ((int3)vertices[triangles[j * 3]]).xz;
				int2 xz2 = ((int3)vertices[triangles[j * 3 + 1]]).xz;
				int2 xz3 = ((int3)vertices[triangles[j * 3 + 2]]).xz;
				int2 int5 = math.min(xz, math.min(xz2, xz3));
				int2 int6 = math.max(xz, math.max(xz2, xz3));
				nodeBounds[j] = new IntRect(int5.x, int5.y, int6.x, int6.y);
			}
			if (num > 0)
			{
				BuildSubtree(permutation, nodeBounds, ref nodes, ref unsafeList, 0, num, odd: false, 0);
			}
			nodeBounds.Dispose();
			permutation.Dispose();
			bbTree = new BBTree
			{
				tree = unsafeList,
				nodePermutation = nodes
			};
		}

		public static void Initialize_0024NearbyNodesIterator_MoveNext_00000AA0_0024BurstDirectCall()
		{
			NearbyNodesIterator.MoveNext_00000AA0_0024BurstDirectCall.Initialize();
		}
	}
}
