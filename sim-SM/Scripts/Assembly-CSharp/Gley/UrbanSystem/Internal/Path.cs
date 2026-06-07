using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class Path
	{
		[SerializeField]
		private List<Vector3> points;

		[SerializeField]
		private bool isClosed;

		[SerializeField]
		private bool autoSetControlPoints;

		public Vector3 this[int i] => default(Vector3);

		public bool IsClosed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AutoSetControlPoints
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int NumPoints => 0;

		public int NumSegments => 0;

		public Path(Vector3 startPosition, Vector3 endPosition)
		{
		}

		public void AddSegment(Vector3 anchorPos)
		{
		}

		public void SplitSegment(Vector3 anchorPos, int segmentIndex)
		{
		}

		public void DeleteSegment(int anchorIndex)
		{
		}

		public Vector3[] GetPointsInSegment(int i, Vector3 offset)
		{
			return null;
		}

		public Vector3 GetPoint(int i, Vector3 offset)
		{
			return default(Vector3);
		}

		public void MovePoint(int i, Vector3 pos)
		{
		}

		private void AutoSetAllAffectedControlPoints(int updatedAnchorIndex)
		{
		}

		private void AutoSetAllControlPoints()
		{
		}

		private void AutoSetAnchorControlPoints(int anchorIndex)
		{
		}

		private void AutoSetStartAndEndControls()
		{
		}

		private int LoopIndex(int i)
		{
			return 0;
		}
	}
}
