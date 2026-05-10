using System;
using UnityEngine;

namespace RootMotion
{
	[Serializable]
	public class BipedReferences
	{
		public struct AutoDetectParams
		{
			public bool legsParentInSpine;

			public bool includeEyes;

			public static AutoDetectParams xpd => default(AutoDetectParams);

			public AutoDetectParams(bool legsParentInSpine, bool includeEyes)
			{
				this.legsParentInSpine = false;
				this.includeEyes = false;
			}
		}

		public Transform root;

		public Transform pelvis;

		public Transform leftThigh;

		public Transform leftCalf;

		public Transform leftFoot;

		public Transform rightThigh;

		public Transform rightCalf;

		public Transform rightFoot;

		public Transform leftUpperArm;

		public Transform leftForearm;

		public Transform leftHand;

		public Transform rightUpperArm;

		public Transform rightForearm;

		public Transform rightHand;

		public Transform head;

		public Transform[] spine;

		public Transform[] eyes;

		public virtual bool xpe => false;

		public bool xpf => false;

		public virtual bool jly(bool a)
		{
			return false;
		}

		public virtual bool jlz(Transform a, bool b = false)
		{
			return false;
		}

		public static bool jma(ref BipedReferences a, Transform b, AutoDetectParams c)
		{
			return false;
		}

		public static void jmb(ref BipedReferences a, Transform b, AutoDetectParams c)
		{
		}

		public static void jmc(ref BipedReferences a, Animator b, AutoDetectParams c)
		{
		}

		public static bool jmd(BipedReferences a, ref string b)
		{
			return false;
		}

		public static bool jme(BipedReferences a, ref string b)
		{
			return false;
		}

		private static bool jmf(Transform a, Transform b)
		{
			return false;
		}

		private static bool jmg(Transform a, ref BipedReferences b, AutoDetectParams c)
		{
			return false;
		}

		private static bool jmh(Transform a, ref BipedReferences b, AutoDetectParams c)
		{
			return false;
		}

		private static void jmi(bli.BoneType a, bli.BoneSide b, ref Transform c, ref Transform d, ref Transform e, Transform[] f)
		{
		}

		private static void jmj(ref Transform[] a, Transform b)
		{
		}

		private static bool jmk(Transform a, Transform b, Transform c, ref string d)
		{
			return false;
		}

		private static bool jml(Transform a, Transform b, Transform c, ref string d)
		{
			return false;
		}

		private static bool jmm(BipedReferences a, ref string b)
		{
			return false;
		}

		private static bool jmn(BipedReferences a, ref string b)
		{
			return false;
		}

		private static bool jmo(BipedReferences a, ref string b)
		{
			return false;
		}

		private static bool jmp(BipedReferences a, ref string b)
		{
			return false;
		}

		private static bool jmq(BipedReferences a, ref string b)
		{
			return false;
		}

		private static bool jmr(BipedReferences a, ref string b)
		{
			return false;
		}

		private static float jms(Vector3 a, Vector3 b, Quaternion c)
		{
			return 0f;
		}
	}
}
