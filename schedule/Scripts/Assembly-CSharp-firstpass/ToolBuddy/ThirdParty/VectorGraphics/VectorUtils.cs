using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	public static class VectorUtils
	{
		public enum Alignment
		{
			Center = 0,
			TopLeft = 1,
			TopCenter = 2,
			TopRight = 3,
			LeftCenter = 4,
			RightCenter = 5,
			BottomLeft = 6,
			BottomCenter = 7,
			BottomRight = 8,
			Custom = 9,
			SVGOrigin = 10
		}

		internal enum WindingDir
		{
			CW = 0,
			CCW = 1
		}

		public struct TessellationOptions
		{
			private float m_MaxCordDev;

			private float m_MaxCordDevSq;

			private float m_MaxTanAngleDev;

			private float m_MaxTanAngleDevCosine;

			private float m_StepSize;

			public float StepDistance { get; set; }

			public float MaxCordDeviation
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			internal float MaxCordDeviationSquared => 0f;

			public float MaxTanAngleDeviation
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			internal float MaxTanAngleDeviationCosine => 0f;

			public float SamplingStepSize
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}
		}

		private class JoiningInfo
		{
			public Vector2 JoinPos;

			public Vector2 TanAtEnd;

			public Vector2 TanAtStart;

			public Vector2 NormAtEnd;

			public Vector2 NormAtStart;

			public Vector2 PosThicknessStart;

			public Vector2 NegThicknessStart;

			public Vector2 PosThicknessEnd;

			public Vector2 NegThicknessEnd;

			public Vector2 PosThicknessClosingPoint;

			public Vector2 NegThicknessClosingPoint;

			public bool RoundPosThickness;

			public bool SimpleJoin;

			public Vector2 InnerCornerVertex;

			public float InnerCornerDistToEnd;

			public float InnerCornerDistFromStart;
		}

		public struct SceneNodeWorldTransform
		{
			public SceneNode Node;

			public SceneNode Parent;

			public Matrix2D WorldTransform;

			public float WorldOpacity;
		}

		[CompilerGenerated]
		private sealed class _003CSceneNodes_003Ed__68 : IEnumerable<SceneNode>, IEnumerable, IEnumerator<SceneNode>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private SceneNode _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private SceneNode root;

			public SceneNode _003C_003E3__root;

			private List<SceneNode>.Enumerator _003C_003E7__wrap1;

			private IEnumerator<SceneNode> _003C_003E7__wrap2;

			SceneNode IEnumerator<SceneNode>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSceneNodes_003Ed__68(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<SceneNode> IEnumerable<SceneNode>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CSegmentsInPath_003Ed__75 : IEnumerable<BezierSegment>, IEnumerable, IEnumerator<BezierSegment>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private BezierSegment _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<BezierPathSegment> segments;

			public IEnumerable<BezierPathSegment> _003C_003E3__segments;

			private bool closed;

			public bool _003C_003E3__closed;

			private IEnumerator<BezierPathSegment> _003Ce_003E5__2;

			private BezierPathSegment _003Cs2_003E5__3;

			BezierSegment IEnumerator<BezierSegment>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(BezierSegment);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSegmentsInPath_003Ed__75(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<BezierSegment> IEnumerable<BezierSegment>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CWorldTransformedSceneNodes_003Ed__70 : IEnumerable<SceneNodeWorldTransform>, IEnumerable, IEnumerator<SceneNodeWorldTransform>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private SceneNodeWorldTransform _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Dictionary<SceneNode, float> nodeOpacities;

			public Dictionary<SceneNode, float> _003C_003E3__nodeOpacities;

			private SceneNode child;

			public SceneNode _003C_003E3__child;

			private SceneNodeWorldTransform parent;

			public SceneNodeWorldTransform _003C_003E3__parent;

			private SceneNodeWorldTransform _003CchildWorldTransform_003E5__2;

			private List<SceneNode>.Enumerator _003C_003E7__wrap2;

			private IEnumerator<SceneNodeWorldTransform> _003C_003E7__wrap3;

			SceneNodeWorldTransform IEnumerator<SceneNodeWorldTransform>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(SceneNodeWorldTransform);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWorldTransformedSceneNodes_003Ed__70(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<SceneNodeWorldTransform> IEnumerable<SceneNodeWorldTransform>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private static Material s_ExpandEdgesMat;

		public static readonly float Epsilon;

		internal static BezierPathSegment[] BuildEllipsePath(Vector2 p0, Vector2 p1, float rotation, float rx, float ry, bool largeArc, bool sweep)
		{
			return null;
		}

		private static void ComputeEllipseParameters(Vector2 p0, Vector2 p1, float phi, float rx, float ry, bool fa, bool fs, out Vector2 c, out float theta1, out float sweepTheta, out float adjustedRx, out float adjustedRy)
		{
			c = default(Vector2);
			theta1 = default(float);
			sweepTheta = default(float);
			adjustedRx = default(float);
			adjustedRy = default(float);
		}

		private static void EnsureRadiiAreLargeEnough(Vector2 p, ref float rx, ref float ry)
		{
		}

		public static BezierContour BuildRectangleContour(Rect rect, Vector2 radiusTL, Vector2 radiusTR, Vector2 radiusBR, Vector2 radiusBL)
		{
			return default(BezierContour);
		}

		private static void FlipYAxis(IList<Vector2> vertices)
		{
		}

		internal static void AdjustWinding(Vector2[] vertices, ushort[] indices, WindingDir dir)
		{
		}

		private static void FlipRangeIfNecessary(List<Vector2> vertices, List<ushort> indices, int indexStart, int indexEnd, bool flipYAxis)
		{
		}

		internal static void RenderFromArrays(Vector2[] vertices, ushort[] indices, Vector2[] uvs, Color[] colors, Vector2[] settings, Texture2D texture, Material mat, bool clear = true)
		{
		}

		public static void RenderSprite(Sprite sprite, Material mat, bool clear = true)
		{
		}

		public static Texture2D RenderSpriteToTexture2D(Sprite sprite, int width, int height, Material mat, int antiAliasing = 1, bool expandEdges = false)
		{
			return null;
		}

		internal static Vector2 GetPivot(Alignment alignment, Vector2 customPivot, Rect bbox, bool flipYAxis)
		{
			return default(Vector2);
		}

		public static void TessellatePath(BezierContour contour, PathProperties pathProps, TessellationOptions tessellateOptions, out Vector2[] vertices, out ushort[] indices)
		{
			vertices = null;
			indices = null;
		}

		private static Vector2[] TraceShape(BezierContour contour, Stroke stroke, TessellationOptions tessellateOptions)
		{
			return null;
		}

		private static bool TryGetMoreRemainingUnits(ref float unitsRemaining, PathDistanceForwardIterator pathIt, float startingLength, float distance, float stepDistance)
		{
			return false;
		}

		private static void HandleNewSegmentJoining(PathDistanceForwardIterator pathIt, PathPatternIterator patternIt, JoiningInfo[] joiningInfo, float halfThickness, float[] segmentLengths)
		{
		}

		private static void SkipRange(float distance, PathDistanceForwardIterator pathIt, PathPatternIterator patternIt, PathProperties pathProps, JoiningInfo[] joiningInfo, float[] segmentLengths)
		{
		}

		private static void TessellateRange(float distance, PathDistanceForwardIterator pathIt, PathPatternIterator patternIt, PathProperties pathProps, TessellationOptions tessellateOptions, JoiningInfo[] joiningInfo, float[] segmentLengths, float totalLength, int rangeIndex, List<Vector2> verts, List<ushort> inds)
		{
		}

		private static void AddSegment(BezierSegment segment, float toT, float halfThickness, JoiningInfo[] joinInfo, float segmentLengthSoFar, List<Vector2> verts, List<ushort> inds)
		{
		}

		private static JoiningInfo ForeseeJoining(BezierSegment end, BezierSegment start, float halfThickness, float endSegmentLength)
		{
			return null;
		}

		private static Vector2[] LineBezierThicknessIntersect(BezierSegment seg, float thickness, Vector2 lineFrom, Vector2 lineTo, out float distanceToIntersection, out Vector2 intersection)
		{
			distanceToIntersection = default(float);
			intersection = default(Vector2);
			return null;
		}

		private static bool PointOnLineIsWithinSegment(Vector2 lineFrom, Vector2 lineTo, Vector2 point)
		{
			return false;
		}

		private static void GenerateJoining(JoiningInfo joinInfo, PathCorner corner, float halfThickness, float tippedCornerLimit, TessellationOptions tessellateOptions, List<Vector2> verts, List<ushort> inds)
		{
		}

		private static void GenerateTip(BezierSegment segment, bool atStart, float t, PathEnding ending, float halfThickness, TessellationOptions tessellateOptions, List<Vector2> verts, List<ushort> inds)
		{
		}

		private static int CalculateArcSteps(float radius, float fromAngle, float toAngle, TessellationOptions tessellateOptions)
		{
			return 0;
		}

		public static void TessellateRect(Rect rect, out Vector2[] vertices, out ushort[] indices)
		{
			vertices = null;
			indices = null;
		}

		public static void TessellateRectBorder(Rect rect, float halfThickness, out Vector2[] vertices, out ushort[] indices)
		{
			vertices = null;
			indices = null;
		}

		public static BezierPathSegment[] BezierSegmentToPath(BezierSegment segment)
		{
			return null;
		}

		public static BezierPathSegment[] BezierSegmentsToPath(BezierSegment[] segments)
		{
			return null;
		}

		public static BezierSegment PathSegmentAtIndex(IList<BezierPathSegment> path, int index)
		{
			return default(BezierSegment);
		}

		public static bool PathEndsPerfectlyMatch(IList<BezierPathSegment> path)
		{
			return false;
		}

		public static void MakeRectangleShape(Shape rectShape, Rect rect)
		{
		}

		public static void MakeRectangleShape(Shape rectShape, Rect rect, Vector2 radiusTL, Vector2 radiusTR, Vector2 radiusBR, Vector2 radiusBL)
		{
		}

		public static void MakeEllipseShape(Shape ellipseShape, Vector2 pos, float radiusX, float radiusY)
		{
		}

		public static void MakeCircleShape(Shape circleShape, Vector2 pos, float radius)
		{
		}

		public static Rect Bounds(BezierPathSegment[] path)
		{
			return default(Rect);
		}

		public static Rect Bounds(IEnumerable<Vector2> vertices)
		{
			return default(Rect);
		}

		public static BezierSegment MakeLine(Vector2 from, Vector2 to)
		{
			return default(BezierSegment);
		}

		public static BezierSegment QuadraticToCubic(Vector2 p0, Vector2 p1, Vector2 p2)
		{
			return default(BezierSegment);
		}

		public static BezierPathSegment[] MakePathLine(Vector2 from, Vector2 to)
		{
			return null;
		}

		internal static BezierSegment MakeArcQuarter(Vector2 center, float startAngleRads, float sweepAngleRads)
		{
			return default(BezierSegment);
		}

		public static BezierPathSegment[] MakeArc(Vector2 center, float startAngleRads, float sweepAngleRads, float radius)
		{
			return null;
		}

		internal static int QuadrantAtAngle(float angle)
		{
			return 0;
		}

		internal static BezierSegment ArcSegmentForQuadrant(int quadrant)
		{
			return default(BezierSegment);
		}

		public static BezierSegment FlipSegment(BezierSegment segment)
		{
			return default(BezierSegment);
		}

		public static void Bounds(BezierSegment segment, out Vector2 min, out Vector2 max)
		{
			min = default(Vector2);
			max = default(Vector2);
		}

		public static Vector2 Eval(BezierSegment segment, float t)
		{
			return default(Vector2);
		}

		public static Vector2 EvalTangent(BezierSegment segment, float t)
		{
			return default(Vector2);
		}

		public static Vector2 EvalNormal(BezierSegment segment, float t)
		{
			return default(Vector2);
		}

		public static Vector2 EvalFull(BezierSegment segment, float t, out Vector2 tangent)
		{
			tangent = default(Vector2);
			return default(Vector2);
		}

		public static Vector2 EvalFull(BezierSegment segment, float t, out Vector2 tangent, out Vector2 normal)
		{
			tangent = default(Vector2);
			normal = default(Vector2);
			return default(Vector2);
		}

		public static float[] SegmentsLengths(IList<BezierPathSegment> segments, bool closed, float precision = 0.001f)
		{
			return null;
		}

		public static float SegmentsLength(IList<BezierPathSegment> segments, bool closed, float precision = 0.001f)
		{
			return 0f;
		}

		public static float SegmentLength(BezierSegment segment, float precision = 0.001f)
		{
			return 0f;
		}

		internal static float SegmentLengthIterative(BezierSegment segment, int steps = 10)
		{
			return 0f;
		}

		internal static bool HasLargeCoordinates(BezierSegment segment)
		{
			return false;
		}

		private static float AdaptiveQuadraticApproxSplitPoint(BezierSegment segment, float precision)
		{
			return 0f;
		}

		private static float MidPointQuadraticApproxLength(BezierSegment segment)
		{
			return 0f;
		}

		public static void SplitSegment(BezierSegment segment, float t, out BezierSegment b1, out BezierSegment b2)
		{
			b1 = default(BezierSegment);
			b2 = default(BezierSegment);
		}

		public static BezierSegment TransformSegment(BezierSegment segment, Vector2 translation, float rotation, Vector2 scaling)
		{
			return default(BezierSegment);
		}

		public static BezierSegment TransformSegment(BezierSegment segment, Matrix2D matrix)
		{
			return default(BezierSegment);
		}

		public static BezierPathSegment[] TransformBezierPath(BezierPathSegment[] path, Vector2 translation, float rotation, Vector2 scaling)
		{
			return null;
		}

		public static BezierPathSegment[] TransformBezierPath(BezierPathSegment[] path, Matrix2D matrix)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSceneNodes_003Ed__68))]
		public static IEnumerable<SceneNode> SceneNodes(SceneNode root)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWorldTransformedSceneNodes_003Ed__70))]
		private static IEnumerable<SceneNodeWorldTransform> WorldTransformedSceneNodes(SceneNode child, Dictionary<SceneNode, float> nodeOpacities, SceneNodeWorldTransform parent)
		{
			return null;
		}

		public static IEnumerable<SceneNodeWorldTransform> WorldTransformedSceneNodes(SceneNode root, Dictionary<SceneNode, float> nodeOpacities)
		{
			return null;
		}

		public static void RealignVerticesInBounds(IList<Vector2> vertices, Rect bounds, bool flip)
		{
		}

		public static void FlipVerticesInBounds(IList<Vector2> vertices, Rect bounds)
		{
		}

		internal static void ClampVerticesInBounds(IList<Vector2> vertices, Rect bounds)
		{
		}

		[IteratorStateMachine(typeof(_003CSegmentsInPath_003Ed__75))]
		public static IEnumerable<BezierSegment> SegmentsInPath(IEnumerable<BezierPathSegment> segments, bool closed = false)
		{
			return null;
		}

		private static void SolveQuadratic(float a, float b, float c, out float s1, out float s2)
		{
			s1 = default(float);
			s2 = default(float);
		}

		public static Vector2 IntersectLines(Vector2 line1Pt1, Vector2 line1Pt2, Vector2 line2Pt1, Vector2 line2Pt2)
		{
			return default(Vector2);
		}

		public static Vector2 IntersectLineSegments(Vector2 line1Pt1, Vector2 line1Pt2, Vector2 line2Pt1, Vector2 line2Pt2)
		{
			return default(Vector2);
		}

		private static bool PointOnTheLeftOfLine(Vector2 lineFrom, Vector2 lineTo, Vector2 point)
		{
			return false;
		}

		public static float[] FindBezierLineIntersections(BezierSegment segment, Vector2 p0, Vector2 p1)
		{
			return null;
		}

		private static float[] CubicRoots(double a, double b, double c, double d)
		{
			return null;
		}

		private static Vector2[] BezierCoefficients(BezierSegment segment)
		{
			return null;
		}

		public static Rect SceneNodeBounds(SceneNode root)
		{
			return default(Rect);
		}

		public static Rect ApproximateSceneNodeBounds(SceneNode root)
		{
			return default(Rect);
		}

		internal static bool IsEmptySegment(BezierSegment bs)
		{
			return false;
		}
	}
}
