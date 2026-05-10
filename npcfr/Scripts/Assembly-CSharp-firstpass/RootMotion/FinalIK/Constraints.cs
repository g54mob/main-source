using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class Constraints
	{
		public Transform transform;

		public Transform target;

		public Vector3 positionOffset;

		public Vector3 position;

		[Range(0f, 1f)]
		public float positionWeight;

		public Vector3 rotationOffset;

		public Vector3 rotation;

		[Range(0f, 1f)]
		public float rotationWeight;

		private Vector3 tla;

		private Quaternion tlb;

		public bool jst()
		{
			return false;
		}

		public void jsu(Transform a)
		{
		}

		public void jsv()
		{
		}

		public void jsw()
		{
		}
	}
}
