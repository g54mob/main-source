using System;
using UnityEngine;

namespace UMA.Examples
{
	[Serializable]
	public class JiggleElement
	{
		public Transform Bone;

		public string BoneType;

		public Vector3 BoneAxis;

		public Vector3 UpDirection;

		public Vector3 ExtraRotation;

		public float Stiffness;

		public float Mass;

		public float Damping;

		public float Gravity;

		public bool SquashAndStretch;

		public float SideStretch;

		public float FrontStretch;

		public float AnatomyScaleFactor;

		public Vector3 Force;

		public Vector3 Velocity;

		public Vector3 Acceleration;

		public Vector3 DynamicPosition;
	}
}
