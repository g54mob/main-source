using System;
using UnityEngine;

namespace Placemaker.Life
{
	public class Bird : MonoBehaviour, IComparable<Bird>, IComparable<Vector3>
	{
		public Transform body;

		public Transform shade;

		public MeshFilter mf0;

		public MeshFilter mf1;

		[Space]
		public BirdFlock flock;

		public Quaternion rotation0;

		public Quaternion rotation1;

		public Vector3 posMid;

		public Vector3 velocityPrev;

		public Vector3 velocityNext;

		public Vector3 pos;

		public float time;

		public byte preferredNeighbourCount;

		public BirdFlock.State statePrev;

		public BirdFlock.State stateNext;

		public float lastActionTime;

		public BirdLanding landing;

		int IComparable<Bird>.CompareTo(Bird other)
		{
			return 0;
		}

		int IComparable<Vector3>.CompareTo(Vector3 other)
		{
			return 0;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
