using System;
using UnityEngine;

namespace RootMotion
{
	[Serializable]
	public class BakerHumanoidQT
	{
		private Transform thn;

		private string tho;

		private string thp;

		private string thq;

		private string thr;

		private string ths;

		private string tht;

		private string thu;

		public AnimationCurve rotX;

		public AnimationCurve rotY;

		public AnimationCurve rotZ;

		public AnimationCurve rotW;

		public AnimationCurve posX;

		public AnimationCurve posY;

		public AnimationCurve posZ;

		private AvatarIKGoal thv;

		private Quaternion thw;

		private bool thx;

		public BakerHumanoidQT(string name)
		{
		}

		public BakerHumanoidQT(Transform transform, AvatarIKGoal goal, string name)
		{
		}

		public Quaternion jja(float a)
		{
			return default(Quaternion);
		}

		public Vector3 jjb(float a)
		{
			return default(Vector3);
		}

		public blb jjc(float a)
		{
			return null;
		}

		public void jjd(AnimationClip a, Animator b)
		{
		}

		public void jje()
		{
		}

		public void jjf(float a, Avatar b, Transform c, float d, Vector3 e, Quaternion f)
		{
		}

		public void jjg(float a, Vector3 b, Quaternion c)
		{
		}

		public void jjh(float a)
		{
		}

		public void jji(float a)
		{
		}

		public void jjj(float a)
		{
		}

		private void jjk(float a, AnimationCurve b)
		{
		}

		public void jjl(AnimationCurve a, float b)
		{
		}

		public void jjm(ref AnimationClip a, float b, float c)
		{
		}
	}
}
