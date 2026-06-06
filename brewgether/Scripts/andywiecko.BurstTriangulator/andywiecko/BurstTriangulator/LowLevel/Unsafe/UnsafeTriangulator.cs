using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct UnsafeTriangulator
	{
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct UnsafeTriangulator<T2> where T2 : struct
	{
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal readonly struct UnsafeTriangulator<T, T2, TBig, TTransform, TUtils> where T : struct, IComparable<T> where T2 : struct where TBig : struct, IComparable<TBig> where TTransform : struct, ITransform<TTransform, T, T2> where TUtils : struct, IUtils<T, T2, TBig>
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct Markers
		{
			public static readonly ProfilerMarker PreProcessInputStep;

			public static readonly ProfilerMarker PostProcessInputStep;

			public static readonly ProfilerMarker ValidateInputStep;

			public static readonly ProfilerMarker DelaunayTriangulationStep;

			public static readonly ProfilerMarker ConstrainEdgesStep;

			public static readonly ProfilerMarker PlantingSeedStep;

			public static readonly ProfilerMarker RefineMeshStep;
		}

		private struct ValidateInputStep
		{
			private NativeArray<T2>.ReadOnly positions;

			private NativeReference<Status> status;

			private readonly Args args;

			private NativeArray<int>.ReadOnly constraints;

			private NativeArray<ConstraintType>.ReadOnly constraintTypes;

			private NativeArray<T2>.ReadOnly holes;

			public ValidateInputStep(InputData<T2> input, OutputData<T2> output, Args args)
			{
				positions = default(NativeArray<T2>.ReadOnly);
				status = default(NativeReference<Status>);
				this.args = default(Args);
				constraints = default(NativeArray<int>.ReadOnly);
				constraintTypes = default(NativeArray<ConstraintType>.ReadOnly);
				holes = default(NativeArray<T2>.ReadOnly);
			}

			public void Execute()
			{
			}

			private void ValidateArgs()
			{
			}

			private void ValidatePositions()
			{
			}

			private void ValidateConstraints()
			{
			}

			private void ValidateHoles()
			{
			}
		}

		private struct DelaunayTriangulationStep
		{
			private struct DistComparer : IComparer<int>
			{
				private NativeArray<TBig> dist;

				public DistComparer(NativeArray<TBig> dist)
				{
					this.dist = default(NativeArray<TBig>);
				}

				public int Compare(int x, int y)
				{
					return 0;
				}
			}

			private NativeReference<Status> status;

			private NativeArray<T2>.ReadOnly positions;

			private NativeList<int> triangles;

			private NativeList<int> halfedges;

			private NativeList<HalfedgeState> constrainedHalfedges;

			private NativeArray<int> hullNext;

			private NativeArray<int> hullPrev;

			private NativeArray<int> hullTri;

			private NativeArray<int> hullHash;

			private NativeArray<int> EDGE_STACK;

			private readonly int hashSize;

			private readonly bool verbose;

			private int hullStart;

			private int trianglesLen;

			public DelaunayTriangulationStep(OutputData<T2> output, Args args)
			{
				status = default(NativeReference<Status>);
				positions = default(NativeArray<T2>.ReadOnly);
				triangles = default(NativeList<int>);
				halfedges = default(NativeList<int>);
				constrainedHalfedges = default(NativeList<HalfedgeState>);
				hullNext = default(NativeArray<int>);
				hullPrev = default(NativeArray<int>);
				hullTri = default(NativeArray<int>);
				hullHash = default(NativeArray<int>);
				EDGE_STACK = default(NativeArray<int>);
				hashSize = 0;
				verbose = false;
				hullStart = 0;
				trianglesLen = 0;
			}

			public void Execute(Allocator allocator)
			{
			}

			private int Legalize(int a)
			{
				return 0;
			}

			private int AddTriangle(int i0, int i1, int i2, int a, int b, int c)
			{
				return 0;
			}

			private void Link(int a, int b)
			{
			}
		}

		private struct ConstrainEdgesStep
		{
			private NativeReference<Status> status;

			private NativeArray<T2>.ReadOnly positions;

			private NativeArray<int> triangles;

			private NativeArray<int>.ReadOnly inputConstraintEdges;

			private NativeArray<ConstraintType>.ReadOnly inputConstraintEdgeTypes;

			private NativeList<int> halfedges;

			private NativeList<HalfedgeState> constrainedHalfedges;

			private readonly Args args;

			private NativeList<int> intersections;

			private NativeList<int> unresolvedIntersections;

			private NativeArray<int> pointToHalfedge;

			public ConstrainEdgesStep(InputData<T2> input, OutputData<T2> output, Args args)
			{
				status = default(NativeReference<Status>);
				positions = default(NativeArray<T2>.ReadOnly);
				triangles = default(NativeArray<int>);
				inputConstraintEdges = default(NativeArray<int>.ReadOnly);
				inputConstraintEdgeTypes = default(NativeArray<ConstraintType>.ReadOnly);
				halfedges = default(NativeList<int>);
				constrainedHalfedges = default(NativeList<HalfedgeState>);
				this.args = default(Args);
				intersections = default(NativeList<int>);
				unresolvedIntersections = default(NativeList<int>);
				pointToHalfedge = default(NativeArray<int>);
			}

			public void Execute(Allocator allocator)
			{
			}

			private void TryResolveIntersections(int2 c, HalfedgeState constrainValue, ref int iter)
			{
			}

			private void ReplaceHalfedge(int h0, int h1)
			{
			}

			private bool EdgeEdgeIntersection(int2 e1, int2 e2)
			{
				return false;
			}

			private void MarkHalfedgeConstrained(int halfedge, HalfedgeState constrainValue)
			{
			}

			private void TryApplyConstraint(int2 edge, HalfedgeState constrainValue)
			{
			}

			private bool IsMaxItersExceeded(int iter, int maxIters)
			{
				return false;
			}
		}

		private struct PlantingSeedStep
		{
			private NativeReference<Status> status;

			private NativeList<int> triangles;

			[ReadOnly]
			private NativeList<T2> positions;

			private NativeList<HalfedgeState> constrainedHalfedges;

			private NativeList<int> halfedges;

			private NativeArray<bool> shouldRemoveTriangle;

			private NativeQueue<int> trianglesQueue;

			private NativeArray<T2> holes;

			private bool anyRemovedTriangles;

			private readonly Args args;

			public PlantingSeedStep(InputData<T2> input, OutputData<T2> output, Args args)
			{
				status = default(NativeReference<Status>);
				triangles = default(NativeList<int>);
				positions = default(NativeList<T2>);
				constrainedHalfedges = default(NativeList<HalfedgeState>);
				halfedges = default(NativeList<int>);
				shouldRemoveTriangle = default(NativeArray<bool>);
				trianglesQueue = default(NativeQueue<int>);
				holes = default(NativeArray<T2>);
				anyRemovedTriangles = false;
				this.args = default(Args);
			}

			public PlantingSeedStep(OutputData<T2> output, Args args, NativeArray<T2> localHoles)
			{
				status = default(NativeReference<Status>);
				triangles = default(NativeList<int>);
				positions = default(NativeList<T2>);
				constrainedHalfedges = default(NativeList<HalfedgeState>);
				halfedges = default(NativeList<int>);
				shouldRemoveTriangle = default(NativeArray<bool>);
				trianglesQueue = default(NativeQueue<int>);
				holes = default(NativeArray<T2>);
				anyRemovedTriangles = false;
				this.args = default(Args);
			}

			public void Execute(Allocator allocator, bool constraintsIsCreated)
			{
			}

			private void PlantBoundarySeeds()
			{
			}

			private void PlantHoleSeeds(NativeArray<T2> holeSeeds)
			{
			}

			private void RemoveVisitedTriangles(Allocator allocator)
			{
			}

			private void PlantSeed(int tId)
			{
			}

			private int FindTriangle(T2 p)
			{
				return 0;
			}

			private void PlantAuto(Allocator allocator)
			{
			}
		}

		private struct RefineMeshStep
		{
			private readonly struct Circle
			{
				public readonly T2 Center;

				public readonly T RadiusSq;

				public Circle((T2 center, T radiusSq) circle)
				{
					Center = default(T2);
					RadiusSq = default(T);
				}
			}

			private NativeReference<Status> status;

			private NativeList<int> triangles;

			private NativeList<T2> outputPositions;

			private NativeList<int> halfedges;

			private NativeList<HalfedgeState> constrainedHalfedges;

			private NativeList<Circle> circles;

			private NativeQueue<int> trianglesQueue;

			private NativeList<int> badTriangles;

			private NativeList<int> pathPoints;

			private NativeList<int> pathHalfedges;

			private NativeList<bool> visitedTriangles;

			private readonly T maximumArea2;

			private readonly T angleThreshold;

			private readonly int initialPointsCount;

			private const float ConcentricShellReferenceRadius = 0.001f;

			public RefineMeshStep(OutputData<T2> output, Args args, TTransform lt)
			{
				status = default(NativeReference<Status>);
				triangles = default(NativeList<int>);
				outputPositions = default(NativeList<T2>);
				halfedges = default(NativeList<int>);
				constrainedHalfedges = default(NativeList<HalfedgeState>);
				circles = default(NativeList<Circle>);
				trianglesQueue = default(NativeQueue<int>);
				badTriangles = default(NativeList<int>);
				pathPoints = default(NativeList<int>);
				pathHalfedges = default(NativeList<int>);
				visitedTriangles = default(NativeList<bool>);
				maximumArea2 = default(T);
				angleThreshold = default(T);
				initialPointsCount = 0;
			}

			public RefineMeshStep(OutputData<T2> output, T area2Threshold, T angleThreshold)
			{
				status = default(NativeReference<Status>);
				triangles = default(NativeList<int>);
				outputPositions = default(NativeList<T2>);
				halfedges = default(NativeList<int>);
				constrainedHalfedges = default(NativeList<HalfedgeState>);
				circles = default(NativeList<Circle>);
				trianglesQueue = default(NativeQueue<int>);
				badTriangles = default(NativeList<int>);
				pathPoints = default(NativeList<int>);
				pathHalfedges = default(NativeList<int>);
				visitedTriangles = default(NativeList<bool>);
				maximumArea2 = default(T);
				this.angleThreshold = default(T);
				initialPointsCount = 0;
			}

			public void Execute(Allocator allocator, bool refineMesh, bool constrainBoundary)
			{
			}

			private void SplitEncroachedEdges(NativeList<int> heQueue, NativeList<int> tQueue)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool IsEncroached(int he0)
			{
				return false;
			}

			private void SplitEdge(int he, NativeList<int> heQueue, NativeList<int> tQueue)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool IsBadTriangle(int tId)
			{
				return false;
			}

			private void SplitTriangle(int tId, NativeList<int> heQueue, NativeList<int> tQueue, Allocator allocator)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private bool AngleIsTooSmall(int tId, T minimumAngle)
			{
				return false;
			}

			private int UnsafeInsertPointCommon(T2 p, int initTriangle)
			{
				return 0;
			}

			private void UnsafeInsertPointBulk(T2 p, int initTriangle, NativeList<int> heQueue = default(NativeList<int>), NativeList<int> tQueue = default(NativeList<int>))
			{
			}

			private void UnsafeInsertPointBoundary(T2 p, int initHe, NativeList<int> heQueue = default(NativeList<int>), NativeList<int> tQueue = default(NativeList<int>))
			{
			}

			private void RecalculateBadTriangles(T2 p)
			{
			}

			private void VisitEdge(T2 p, int t0)
			{
			}

			private void BuildAmphitheaterPolygon(int initHe)
			{
			}

			private void BuildStarPolygon()
			{
			}

			private void ProcessBadTriangles(NativeList<int> heQueue, NativeList<int> tQueue)
			{
			}

			private void RemoveHalfedge(int he, int offset)
			{
			}

			private void BuildNewTrianglesForStar(int pId, NativeList<int> heQueue, NativeList<int> tQueue)
			{
			}

			private void BuildNewTrianglesForAmphitheater(int pId, NativeList<int> heQueue, NativeList<int> tQueue)
			{
			}
		}

		private static readonly TUtils utils;

		public void Triangulate(InputData<T2> input, OutputData<T2> output, Args args, Allocator allocator)
		{
		}

		public void PlantHoleSeeds(InputData<T2> input, OutputData<T2> output, Args args, Allocator allocator)
		{
		}

		public void RefineMesh(OutputData<T2> output, Allocator allocator, T area2Threshold, T angleThreshold, bool constrainBoundary = false)
		{
		}

		private void PreProcessInputStep(InputData<T2> input, OutputData<T2> output, Args args, out NativeArray<T2> localHoles, out TTransform lt, Allocator allocator)
		{
			localHoles = default(NativeArray<T2>);
			lt = default(TTransform);
		}

		private void PostProcessInputStep(OutputData<T2> output, Args args, TTransform lt)
		{
		}

		internal static bool AngleIsTooSmall(T2 pA, T2 pB, T2 pC, T minimumAngle)
		{
			return false;
		}

		internal static T Area2(T2 a, T2 b, T2 c)
		{
			return default(T);
		}

		private static T Cross(T2 a, T2 b)
		{
			return default(T);
		}

		private static TBig CircumRadiusSq(T2 a, T2 b, T2 c)
		{
			return default(TBig);
		}

		private static (T2, T) CalculateCircumCircle(int i, int j, int k, NativeArray<T2> positions)
		{
			return default((T2, T));
		}

		private static bool ccw(T2 a, T2 b, T2 c)
		{
			return false;
		}

		internal static bool EdgeEdgeIntersection(T2 a0, T2 a1, T2 b0, T2 b1)
		{
			return false;
		}

		private static int NextHalfedge(int he)
		{
			return 0;
		}

		internal static bool IsConvexQuadrilateral(T2 a, T2 b, T2 c, T2 d)
		{
			return false;
		}

		private static TBig Orient2dFast(T2 a, T2 b, T2 c)
		{
			return default(TBig);
		}

		internal static bool PointLineSegmentIntersection(T2 a, T2 b0, T2 b1)
		{
			return false;
		}
	}
}
