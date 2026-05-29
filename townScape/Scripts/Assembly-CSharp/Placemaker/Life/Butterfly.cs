using UnityEngine;

namespace Placemaker.Life
{
	public class Butterfly : MonoBehaviour
	{
		public Quaternion rotation0;

		public Quaternion rotation1;

		public Vector3 posMid;

		public Vector3 velocityPrev;

		public Vector3 velocityNext;

		public Vector3 pos;

		public float time;

		public ButterflyFlock.State state;

		public ButterflyLanding landing;
	}
}
