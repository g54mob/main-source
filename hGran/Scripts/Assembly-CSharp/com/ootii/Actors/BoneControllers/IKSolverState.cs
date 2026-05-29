using System.Collections.Generic;
using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Actors.BoneControllers
{
	public struct IKSolverState
	{
		public Vector3 TargetPosition;

		public bool UsePlaneNormal;

		public bool UseBindRotation;

		public bool IsDebugEnabled;

		public List<BoneControllerBone> Bones;

		public List<float> BoneLengths;

		public List<Vector3> BonePositions;

		public List<Vector3> BoneBendAxes;

		public Dictionary<BoneControllerBone, Quaternion> Rotations;

		public Dictionary<BoneControllerBone, Quaternion> Swings;

		public Dictionary<BoneControllerBone, Quaternion> Twists;

		private static ObjectPool<IKSolverState> sPool;

		public static int Length => 0;

		public void AddRotation(BoneControllerBone rBone, Quaternion rRotation)
		{
		}

		public void AddRotation(BoneControllerBone rBone, Quaternion rSwing, Quaternion rTwist)
		{
		}

		public static IKSolverState Allocate()
		{
			return default(IKSolverState);
		}

		public static void Release(IKSolverState rInstance)
		{
		}
	}
}
