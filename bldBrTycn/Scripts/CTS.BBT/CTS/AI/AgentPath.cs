using CTS.Core;
using UnityEngine;

namespace CTS.AI
{
	public class AgentPath
	{
		public enum ECalculationStatus
		{
			Pending = 0,
			Completed = 1,
			Failed = 2
		}

		public enum EPathingStatus
		{
			InProgress = 0,
			Completed = 1,
			Blocked = 2
		}

		public enum EDestinationType
		{
			Precise = 0,
			LookAtDistance = 1,
			Simple = 2
		}

		private int _floor;

		private int _currentCornerIndex;

		public PathCorner[] Corners { get; set; }

		public bool IsFirstCorner => _currentCornerIndex == 0;

		public Quaternion EndRotation { get; set; }

		public Quaternion StartRotation { get; set; }

		public bool HasStartedRotating { get; set; }

		public float DistanceToLookAt { get; set; }

		public Vector3 Target { get; set; }

		public PathCorner CurrentCorner => Corners[_currentCornerIndex];

		public PathCorner PreviousCorner => Corners[_currentCornerIndex - 1];

		public PathCorner NextCorner => Corners[_currentCornerIndex + 1];

		public ECalculationStatus CalculationStatus { get; set; }

		public EPathingStatus PathingStatus { get; set; }

		public EDestinationType DestinationType { get; }

		public float RemainingDistance { get; private set; }

		public IndexedArrayEnumerator<PathCorner> RemainingCorners => new IndexedArrayEnumerator<PathCorner>(Corners, _currentCornerIndex);

		public AgentPath(EDestinationType p_destinationType)
		{
			Corners = null;
			CalculationStatus = ECalculationStatus.Pending;
			PathingStatus = EPathingStatus.InProgress;
			DestinationType = p_destinationType;
		}

		public bool TrySetNextCorner()
		{
			if (CurrentCorner.IsLastCorner)
			{
				PathingStatus = EPathingStatus.Completed;
				RemainingDistance = 0f;
				return false;
			}
			_currentCornerIndex++;
			RemainingDistance = CurrentCorner.RemainingDistance;
			return true;
		}
	}
}
