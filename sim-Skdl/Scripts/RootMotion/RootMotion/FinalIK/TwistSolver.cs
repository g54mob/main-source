using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class TwistSolver
	{
		[Tooltip("The transform that this solver operates on.")]
		public Transform transform;

		[Tooltip("If this is the forearm roll bone, the parent should be the forearm bone. If null, will be found automatically.")]
		public Transform parent;

		[Tooltip("If this is the forearm roll bone, the child should be the hand bone. If null, will attempt to find automatically. Assign the hand manually if the hand bone is not a child of the roll bone.")]
		public Transform[] children;

		[Tooltip("The weight of relaxing the twist of this Transform")]
		[Range(0f, 1f)]
		public float weight;

		[Range(0f, 1f)]
		[Tooltip("If 0.5, this Transform will be twisted half way from parent to child. If 1, the twist angle will be locked to the child and will rotate with along with it.")]
		public float parentChildCrossfade;

		[Range(-180f, 180f)]
		[Tooltip("Rotation offset around the twist axis.")]
		public float twistAngleOffset;

		private Vector3 twistAxis;

		private Vector3 axis;

		private Vector3 axisRelativeToParentDefault;

		private Vector3 axisRelativeToChildDefault;

		private Quaternion[] childRotations;

		private bool inititated;

		private Quaternion defaultLocalRotation;

		private Quaternion[] defaultChildLocalRotations;

		public TwistSolver()
		{
		}

		public TwistSolver(Transform t)
		{
		}

		public void Initiate()
		{
		}

		public void FixTransforms()
		{
		}

		public void Relax()
		{
		}
	}
}
