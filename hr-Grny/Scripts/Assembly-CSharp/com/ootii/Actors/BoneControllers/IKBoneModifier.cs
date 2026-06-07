using System;
using UnityEngine;
using com.ootii.Collections;

namespace com.ootii.Actors.BoneControllers
{
	[Serializable]
	public class IKBoneModifier
	{
		public bool IsDirty;

		public int Type;

		public Quaternion Swing;

		public Quaternion Twist;

		public Vector3 Position;

		public Vector3 Up;

		public float Weight;

		private static ObjectPool<IKBoneModifier> sPool;

		public static int Length => 0;

		public IKBoneModifier()
		{
		}

		public IKBoneModifier(int rType)
		{
		}

		public static IKBoneModifier Allocate()
		{
			return null;
		}

		public static IKBoneModifier Allocate(int rType, Quaternion rSwing, Quaternion rTwist, float rWeight)
		{
			return null;
		}

		public static IKBoneModifier Allocate(int rType, Vector3 rPosition, Vector3 rUp, float rWeight)
		{
			return null;
		}

		public static void Release(IKBoneModifier rInstance)
		{
		}
	}
}
