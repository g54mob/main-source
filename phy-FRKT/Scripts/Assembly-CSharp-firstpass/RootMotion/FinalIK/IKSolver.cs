using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public abstract class IKSolver
	{
		[Serializable]
		public class Point
		{
			public Transform transform;

			[Range(0f, 1f)]
			public float weight;

			public Vector3 solverPosition;

			public Quaternion solverRotation;

			public Vector3 defaultLocalPosition;

			public Quaternion defaultLocalRotation;

			public void kdo()
			{
			}

			public void kdp()
			{
			}

			public void kdq()
			{
			}

			public void kdr()
			{
			}

			public void kds()
			{
			}

			public void kdt()
			{
			}
		}

		[Serializable]
		public class Bone : Point
		{
			public float length;

			public float sqrMag;

			public Vector3 axis;

			private bnd trr;

			private bool trs;

			public bnd xqe
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public void kdw(Vector3 a, float b = 1f)
			{
			}

			public static void kdx(Bone[] a, int b, Vector3 c, float d = 1f)
			{
			}

			public void kdy(Vector3 a, float b = 1f)
			{
			}

			public void kdz()
			{
			}

			public Bone()
			{
			}

			public Bone(Transform transform)
			{
			}

			public Bone(Transform transform, float weight)
			{
			}
		}

		[Serializable]
		public class Node : Point
		{
			public float length;

			public float effectorPositionWeight;

			public float effectorRotationWeight;

			public Vector3 offset;

			public Node()
			{
			}

			public Node(Transform transform)
			{
			}

			public Node(Transform transform, float weight)
			{
			}
		}

		public delegate void UpdateDelegate();

		public delegate void IterationDelegate(int i);

		[HideInInspector]
		public bool executedInEditor;

		[HideInInspector]
		public Vector3 IKPosition;

		[Range(0f, 1f)]
		public float IKPositionWeight;

		public UpdateDelegate OnPreInitiate;

		public UpdateDelegate OnPostInitiate;

		public UpdateDelegate OnPreUpdate;

		public UpdateDelegate OnPostUpdate;

		protected bool tru;

		[SerializeField]
		[HideInInspector]
		protected Transform root;

		public bool trt
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public bool kea()
		{
			return false;
		}

		public abstract bool keb(ref string a);

		public void kec(Transform a)
		{
		}

		public void ked()
		{
		}

		public virtual Vector3 kee()
		{
			return default(Vector3);
		}

		public void kef(Vector3 a)
		{
		}

		public float keg()
		{
			return 0f;
		}

		public void keh(float a)
		{
		}

		public Transform kei()
		{
			return null;
		}

		public abstract Point[] kel();

		public abstract Point kem(Transform a);

		public abstract void ken();

		public abstract void keo();

		protected abstract void kep();

		protected abstract void keq();

		protected void ker(string a)
		{
		}

		public static Transform kes(Bone[] a)
		{
			return null;
		}

		public static bool ket(Bone[] a)
		{
			return false;
		}

		protected static float keu(ref Bone[] a)
		{
			return 0f;
		}
	}
}
