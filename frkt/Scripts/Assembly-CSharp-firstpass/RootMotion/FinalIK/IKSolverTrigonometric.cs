using System;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverTrigonometric : IKSolver
	{
		[Serializable]
		public class TrigonometricBone : Bone
		{
			private Quaternion ttb;

			private Vector3 ttc;

			public void kjx(Vector3 a, Vector3 b)
			{
			}

			public Quaternion kjy(Vector3 a, Vector3 b)
			{
				return default(Quaternion);
			}

			public Vector3 kjz()
			{
				return default(Vector3);
			}
		}

		public Transform target;

		[Range(0f, 1f)]
		public float IKRotationWeight;

		public Quaternion IKRotation;

		public Vector3 bendNormal;

		public TrigonometricBone bone1;

		public TrigonometricBone bone2;

		public TrigonometricBone bone3;

		protected Vector3 ttd;

		protected bool tte;

		public void kka(Vector3 a, float b)
		{
		}

		public void kkb()
		{
		}

		public void kkc(Quaternion a)
		{
		}

		public void kkd(float a)
		{
		}

		public Quaternion kke()
		{
			return default(Quaternion);
		}

		public float kkf()
		{
			return 0f;
		}

		public override Point[] kel()
		{
			return null;
		}

		public override Point kem(Transform a)
		{
			return null;
		}

		public override void keo()
		{
		}

		public override void ken()
		{
		}

		public override bool keb(ref string a)
		{
			return false;
		}

		public bool kkg(Transform a, Transform b, Transform c, Transform d)
		{
			return false;
		}

		public static void kkh(Transform a, Transform b, Transform c, Vector3 d, Vector3 e, float f)
		{
		}

		private static Vector3 kki(Vector3 a, float b, Vector3 c, float d, float e)
		{
			return default(Vector3);
		}

		protected override void kep()
		{
		}

		private bool kkj()
		{
			return false;
		}

		public void kkk()
		{
		}

		protected override void keq()
		{
		}

		protected virtual void kiv()
		{
		}

		protected virtual void kiw()
		{
		}

		protected virtual void kix()
		{
		}

		protected Vector3 kkl(Vector3 a, Vector3 b)
		{
			return default(Vector3);
		}
	}
}
