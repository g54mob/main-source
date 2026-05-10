using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal class PathDistanceForwardIterator
	{
		private class BezierLoop : IList<BezierPathSegment>, ICollection<BezierPathSegment>, IEnumerable<BezierPathSegment>, IEnumerable
		{
			private IList<BezierPathSegment> OpenPath;

			public BezierPathSegment this[int index]
			{
				get
				{
					return default(BezierPathSegment);
				}
				set
				{
				}
			}

			public int Count => 0;

			public bool IsReadOnly => false;

			public BezierLoop(IList<BezierPathSegment> openPath)
			{
			}

			public void Add(BezierPathSegment item)
			{
			}

			public void Clear()
			{
			}

			public bool Contains(BezierPathSegment item)
			{
				return false;
			}

			public void CopyTo(BezierPathSegment[] array, int arrayIndex)
			{
			}

			public IEnumerator<BezierPathSegment> GetEnumerator()
			{
				return null;
			}

			public int IndexOf(BezierPathSegment item)
			{
				return 0;
			}

			public void Insert(int index, BezierPathSegment item)
			{
			}

			public bool Remove(BezierPathSegment item)
			{
				return false;
			}

			public void RemoveAt(int index)
			{
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public enum Result
		{
			Stepped = 0,
			NewSegment = 1,
			Ended = 2
		}

		private readonly bool closed;

		private readonly bool needTangentsDuringEval;

		private readonly float maxCordDeviationSq;

		private readonly float maxTanAngleDevCosine;

		private readonly float stepSizeT;

		private int currentSegment;

		private float currentT;

		private float segmentLengthSoFar;

		private float lengthSoFar;

		private Vector2 lastPointEval;

		private Vector2 currentTTangent;

		private BezierSegment currentBezSeg;

		public IList<BezierPathSegment> Segments { get; }

		public bool Closed => false;

		public int CurrentSegment => 0;

		public float CurrentT => 0f;

		public float LengthSoFar => 0f;

		public float SegmentLengthSoFar => 0f;

		public bool Ended => false;

		public PathDistanceForwardIterator(IList<BezierPathSegment> pathSegments, bool closed, float maxCordDeviationSq, float maxTanAngleDevCosine, float stepSizeT)
		{
		}

		private float PointToLineDistanceSq(Vector2 point, Vector2 lineStart, Vector2 lineEnd)
		{
			return 0f;
		}

		public Result AdvanceBy(float units, out float unitsRemaining)
		{
			unitsRemaining = default(float);
			return default(Result);
		}

		public Vector2 EvalCurrent()
		{
			return default(Vector2);
		}
	}
}
