using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class Grounding
	{
		[Serializable]
		public enum Quality
		{
			Fastest = 0,
			Simple = 1,
			Best = 2
		}

		public delegate bool OnRaycastDelegate(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		public delegate bool OnCapsuleCastDelegate(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		public delegate bool OnSphereCastDelegate(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float maxDistance, int layerMask, QueryTriggerInteraction queryTriggerInteraction);

		public class Leg
		{
			public Quaternion tmu;

			public bool tna;

			private Grounding tnd;

			private float tne;

			private float tnf;

			private Vector3 tng;

			private Quaternion tnh;

			private Quaternion tni;

			private Vector3 tnj;

			private bool tnk;

			private Vector3 tnl;

			private Vector3 tnm;

			public bool tms
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

			public Vector3 tmt
			{
				[CompilerGenerated]
				get
				{
					return default(Vector3);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public bool tmv
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

			public float tmw
			{
				[CompilerGenerated]
				get
				{
					return 0f;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public Vector3 tmx
			{
				[CompilerGenerated]
				get
				{
					return default(Vector3);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public Transform tmy
			{
				[CompilerGenerated]
				get
				{
					return null;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public float tmz
			{
				[CompilerGenerated]
				get
				{
					return 0f;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public RaycastHit tnb
			{
				[CompilerGenerated]
				get
				{
					return default(RaycastHit);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public RaycastHit tnc
			{
				[CompilerGenerated]
				get
				{
					return default(RaycastHit);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public RaycastHit xps => default(RaycastHit);

			public float xpt => 0f;

			private float xpu => 0f;

			public void jvv(Vector3 a)
			{
			}

			public void jvw(Grounding a, Transform b)
			{
			}

			public void jvx()
			{
			}

			public void jvy()
			{
			}

			public void jvz()
			{
			}

			private RaycastHit jwb(Vector3 a)
			{
				return default(RaycastHit);
			}

			private RaycastHit jwc(Vector3 a)
			{
				return default(RaycastHit);
			}

			private Vector3 jwd(Vector3 a)
			{
				return default(Vector3);
			}

			private void jwe(Vector3 a, Vector3 b)
			{
			}

			private void jwf(Vector3 a, Vector3 b, Vector3 c)
			{
			}

			private float jwg(Vector3 a)
			{
				return 0f;
			}

			private void jwh()
			{
			}

			private Quaternion jwi()
			{
				return default(Quaternion);
			}
		}

		public class Pelvis
		{
			private Grounding tnp;

			private Vector3 tnq;

			private float tnr;

			private bool tns;

			private float tnt;

			public Vector3 tnn
			{
				[CompilerGenerated]
				get
				{
					return default(Vector3);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public float tno
			{
				[CompilerGenerated]
				get
				{
					return 0f;
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public void jwo(Grounding a)
			{
			}

			public void jwp()
			{
			}

			public void jwq()
			{
			}

			public void jwr(float a, float b, bool c)
			{
			}
		}

		public LayerMask layers;

		public float maxStep;

		public float heightOffset;

		public float footSpeed;

		public float footRadius;

		[HideInInspector]
		public float footCenterOffset;

		public float prediction;

		[Range(0f, 1f)]
		public float footRotationWeight;

		public float footRotationSpeed;

		[Range(0f, 90f)]
		public float maxFootRotationAngle;

		public bool rotateSolver;

		public float pelvisSpeed;

		[Range(0f, 1f)]
		public float pelvisDamper;

		public float lowerPelvisWeight;

		public float liftPelvisWeight;

		public float rootSphereCastRadius;

		public bool overstepFallsDown;

		public Quality quality;

		public OnRaycastDelegate Raycast;

		public OnCapsuleCastDelegate CapsuleCast;

		public OnSphereCastDelegate SphereCast;

		private bool tnz;

		public Leg[] tnu
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Pelvis tnv
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public bool tnw
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

		public Transform tnx
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public RaycastHit tny
		{
			[CompilerGenerated]
			get
			{
				return default(RaycastHit);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public bool xpv => false;

		public Vector3 xpw => default(Vector3);

		private bool xpx => false;

		public RaycastHit jxd(float a = 10f)
		{
			return default(RaycastHit);
		}

		public bool jxe(ref string a)
		{
			return false;
		}

		public void jxf(Transform a, Transform[] b)
		{
		}

		public void jxg()
		{
		}

		public Vector3 jxh()
		{
			return default(Vector3);
		}

		public void jxi()
		{
		}

		public void jxj(string a)
		{
		}

		public float jxl(Vector3 a, Vector3 b)
		{
			return 0f;
		}

		public Vector3 jxm(Vector3 a)
		{
			return default(Vector3);
		}

		public Vector3 jxo()
		{
			return default(Vector3);
		}
	}
}
