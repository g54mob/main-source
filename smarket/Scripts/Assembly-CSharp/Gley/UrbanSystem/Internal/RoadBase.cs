using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public abstract class RoadBase : MonoBehaviour
	{
		public Path path;

		public Vector3 positionOffset;

		public Vector3 rotationOffset;

		public float laneWidth;

		public float waypointDistance;

		public int nrOfLanes;

		public int selectedSegmentIndex;

		public bool draw;

		public bool isInsidePrefab;

		public bool inView;

		public Vector3 startPosition;

		public Vector3 endPosition;

		public bool skip;

		public bool justCreated;

		public abstract bool VerifyAssignments();

		public Path CreatePath(Vector3 startPosition, Vector3 endPosition)
		{
			return null;
		}
	}
}
