using System;
using System.Collections.Generic;
using UnityEngine;
using com.ootii.Base;

namespace com.ootii.Actors.BoneControllers
{
	public abstract class BaseBoneController : BaseMonoObject
	{
		public List<Transform> BoneTransforms;

		public abstract IKBone GetBone(string rBoneName);

		public abstract IKBone GetBone(Transform rBone);

		public abstract IKBone GetBone(HumanBodyBones rBone);

		public abstract IKBone TestPointCollision(Vector3 rPoint);

		public abstract bool TestRayCollision(Vector3 rStart, Vector3 rDirection, float rRange, out IKBone rHitBone, out Vector3 rHitPoint);

		public abstract void ResetBindPose();

		public abstract IKMotor GetMotor(string rName);

		public abstract IKMotor GetMotor(Type rType);

		public abstract T GetMotor<T>() where T : IKMotor;

		public abstract T GetMotor<T>(string rName) where T : IKMotor;

		public abstract void EnableMotors<T>(bool rEnable) where T : IKMotor;

		public static string CleanBoneName(string rBoneName)
		{
			return null;
		}
	}
}
