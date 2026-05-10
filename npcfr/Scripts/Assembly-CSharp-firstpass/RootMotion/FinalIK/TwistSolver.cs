using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class TwistSolver
	{
		public Transform transform;

		public Transform parent;

		public Transform[] children;

		[Range(0f, 1f)]
		public float weight;

		[Range(0f, 1f)]
		public float parentChildCrossfade;

		[Range(-180f, 180f)]
		public float twistAngleOffset;

		private Vector3 txr;

		private Vector3 txs;

		private Vector3 txt;

		private Vector3 txu;

		private Quaternion[] txv;

		private bool txw;

		private Quaternion txx;

		private Quaternion[] txy;

		public TwistSolver()
		{
		}

		public TwistSolver(Transform t)
		{
		}

		public void kpx()
		{
		}

		public void kpy()
		{
		}

		public void kpz()
		{
		}
	}
}
