using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace RootMotion.FinalIK
{
	[Serializable]
	public class IKSolverVR : IKSolver
	{
		[Serializable]
		public class Arm : BodyPart
		{
			[Serializable]
			public enum ShoulderRotationMode
			{
				YawPitch = 0,
				FromTo = 1
			}

			[LargeHeader("Hand")]
			public Transform target;

			[Range(0f, 1f)]
			public float positionWeight;

			[Range(0f, 1f)]
			public float rotationWeight;

			[LargeHeader("Shoulder")]
			[Range(0f, 1f)]
			public float shoulderRotationWeight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public ShoulderRotationMode shoulderRotationMode;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float shoulderTwistWeight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float shoulderYawOffset;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float shoulderPitchOffset;

			[LargeHeader("Bending")]
			public Transform bendGoal;

			[Range(0f, 1f)]
			public float bendGoalWeight;

			[Range(-180f, 180f)]
			public float swivelOffset;

			public Vector3 wristToPalmAxis;

			public Vector3 palmToThumbAxis;

			[LargeHeader("Stretching")]
			[Range(0.01f, 2f)]
			public float armLengthMlp;

			public AnimationCurve stretchCurve;

			[NonSerialized]
			[HideInInspector]
			public Vector3 IKPosition;

			[NonSerialized]
			[HideInInspector]
			public Quaternion IKRotation;

			[NonSerialized]
			[HideInInspector]
			public Vector3 bendDirection;

			[NonSerialized]
			[HideInInspector]
			public Vector3 handPositionOffset;

			private bool tth;

			private Vector3 tti;

			private Vector3 ttj;

			private Quaternion ttk;

			private Vector3 ttl;

			private Vector3 ttm;

			private Quaternion ttn;

			private Vector3 tto;

			public Vector3 ttf
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

			public Quaternion ttg
			{
				[CompilerGenerated]
				get
				{
					return default(Quaternion);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			private VirtualBone xrm => null;

			private VirtualBone xrn => null;

			private VirtualBone xro => null;

			private VirtualBone xrp => null;

			protected override void kku(Vector3[] a, Quaternion[] b, bool c, bool d, bool e, bool f, bool g, int h, int i)
			{
			}

			public override void kkv(float a)
			{
			}

			public override void kkw(float a)
			{
			}

			private void kkx()
			{
			}

			public void kky(bool a)
			{
			}

			public override void kkz()
			{
			}

			public override void kla(ref Vector3[] a, ref Quaternion[] b)
			{
			}

			private float klb(float a, float b, float c, float d = 1f)
			{
				return 0f;
			}

			private Vector3 klc(Vector3 a)
			{
				return default(Vector3);
			}

			private void kld(VirtualBone a, VirtualBone b, VirtualBone c, Color d)
			{
			}
		}

		[Serializable]
		public abstract class BodyPart
		{
			[HideInInspector]
			public VirtualBone[] bones;

			protected bool ttr;

			protected Vector3 tts;

			protected Quaternion ttt;

			protected int ttu;

			protected int ttv;

			public float ttp
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

			public float ttq
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

			protected abstract void kku(Vector3[] a, Quaternion[] b, bool c, bool d, bool e, bool f, bool g, int h, int i);

			public abstract void kkv(float a);

			public abstract void kla(ref Vector3[] a, ref Quaternion[] b);

			public abstract void kkw(float a);

			public abstract void kkz();

			public void kli(int a)
			{
			}

			public void klj(Vector3[] a, Quaternion[] b, bool c, bool d, bool e, bool f, bool g, int h, int i)
			{
			}

			public void klk(Vector3 a)
			{
			}

			public void kll(Quaternion a)
			{
			}

			public void klm(Vector3 a, Quaternion b)
			{
			}

			public void kln(Vector3 a, Quaternion b)
			{
			}

			public void klo(VirtualBone a, Quaternion b, float c = 1f)
			{
			}

			public void klp(Color a)
			{
			}

			public void klq()
			{
			}
		}

		[Serializable]
		public class Footstep
		{
			public float stepSpeed;

			public Vector3 characterSpaceOffset;

			public Vector3 position;

			public Quaternion rotation;

			public Quaternion stepToRootRot;

			public bool isSupportLeg;

			public bool relaxFlag;

			public Vector3 stepFrom;

			public Vector3 stepTo;

			public Quaternion stepFromRot;

			public Quaternion stepToRot;

			private Quaternion ttx;

			private float tty;

			private float ttz;

			public bool xrq => false;

			public float ttw
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

			public Footstep(Quaternion rootRotation, Vector3 footPosition, Quaternion footRotation, Vector3 characterSpaceOffset)
			{
			}

			public void klu(Quaternion a, Vector3 b, Quaternion c)
			{
			}

			public void klv(Vector3 a, Quaternion b, float c)
			{
			}

			public void klw(Vector3 a, Quaternion b, float c, float d)
			{
			}

			public void klx(Quaternion a, float b, float c, float d)
			{
			}

			public void kly(InterpolationMode a, UnityEvent b, float c)
			{
			}
		}

		[Serializable]
		public class Leg : BodyPart
		{
			[LargeHeader("Foot/Toe")]
			public Transform target;

			[Range(0f, 1f)]
			public float positionWeight;

			[Range(0f, 1f)]
			public float rotationWeight;

			[LargeHeader("Bending")]
			public Transform bendGoal;

			[Range(0f, 1f)]
			public float bendGoalWeight;

			[Range(-180f, 180f)]
			public float swivelOffset;

			[Range(0f, 1f)]
			public float bendToTargetWeight;

			[LargeHeader("Stretching")]
			[Range(0.01f, 2f)]
			public float legLengthMlp;

			public AnimationCurve stretchCurve;

			[NonSerialized]
			[HideInInspector]
			public Vector3 IKPosition;

			[NonSerialized]
			[HideInInspector]
			public Quaternion IKRotation;

			[NonSerialized]
			[HideInInspector]
			public Vector3 footPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 heelPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Quaternion footRotationOffset;

			[NonSerialized]
			[HideInInspector]
			public float currentMag;

			[HideInInspector]
			public bool useAnimatedBendNormal;

			private Vector3 tue;

			private Quaternion tuf;

			private Vector3 tug;

			private Quaternion tuh;

			private Quaternion tui;

			public Vector3 tua
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

			public Quaternion tub
			{
				[CompilerGenerated]
				get
				{
					return default(Quaternion);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			public bool tuc
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

			public VirtualBone xrr => null;

			private VirtualBone xrs => null;

			private VirtualBone xrt => null;

			private VirtualBone xru => null;

			public VirtualBone xrv => null;

			public Vector3 tud
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

			public Vector3 tuj
			{
				[CompilerGenerated]
				get
				{
					return default(Vector3);
				}
				[CompilerGenerated]
				set
				{
				}
			}

			public Vector3 tuk
			{
				[CompilerGenerated]
				get
				{
					return default(Vector3);
				}
				[CompilerGenerated]
				set
				{
				}
			}

			protected override void kku(Vector3[] a, Quaternion[] b, bool c, bool d, bool e, bool f, bool g, int h, int i)
			{
			}

			public override void kkv(float a)
			{
			}

			public override void kkw(float a)
			{
			}

			private void kmq(Vector3 a, float b)
			{
			}

			private void kmr(Quaternion a, float b)
			{
			}

			public void kms(bool a)
			{
			}

			private void kmt()
			{
			}

			private void kmu()
			{
			}

			public override void kla(ref Vector3[] a, ref Quaternion[] b)
			{
			}

			public override void kkz()
			{
			}
		}

		[Serializable]
		public class Locomotion
		{
			[Serializable]
			public enum Mode
			{
				Procedural = 0,
				Animated = 1
			}

			public Mode mode;

			[Range(0f, 1f)]
			public float weight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float moveThreshold;

			[ShowLargeHeaderIf(/*Could not decode attribute arguments.*/)]
			[SerializeField]
			private byte animationHeader;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float minAnimationSpeed;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float maxAnimationSpeed;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float animationSmoothTime;

			[ShowLargeHeaderIf(/*Could not decode attribute arguments.*/)]
			[SerializeField]
			private byte rootPositionHeader;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public Vector2 standOffset;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float rootLerpSpeedWhileMoving;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float rootLerpSpeedWhileStopping;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float rootLerpSpeedWhileTurning;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float maxRootOffset;

			[ShowLargeHeaderIf(/*Could not decode attribute arguments.*/)]
			[SerializeField]
			private byte rootRotationHeader;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float maxRootAngleMoving;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float maxRootAngleStanding;

			[HideInInspector]
			[SerializeField]
			public float stepLengthMlp;

			private Animator tul;

			private Vector3 tum;

			private Vector3 tun;

			private Vector3 tuo;

			private Vector3 tup;

			private Vector3 tuq;

			private Vector3 tur;

			private float tus;

			private float tut;

			private float tuu;

			private float tuv;

			private float tuw;

			private float tux;

			private float tuy;

			private float tuz;

			private bool tva;

			private bool tvb;

			private static int tvc;

			private static int tvd;

			private static int tve;

			private static int tvf;

			private static int tvg;

			private static bool tvh;

			private float tvi;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float footDistance;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float stepThreshold;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float angleThreshold;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float comAngleMlp;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float maxVelocity;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float velocityFactor;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float maxLegStretch;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float rootSpeed;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float stepSpeed;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public AnimationCurve stepHeight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float maxBodyYOffset;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public AnimationCurve heelHeight;

			[ShowRangeIf(/*Could not decode attribute arguments.*/)]
			public float relaxLegTwistMinAngle;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float relaxLegTwistSpeed;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public InterpolationMode stepInterpolation;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public Vector3 offset;

			[HideInInspector]
			public bool blockingEnabled;

			[HideInInspector]
			public LayerMask blockingLayers;

			[HideInInspector]
			public float raycastRadius;

			[HideInInspector]
			public float raycastHeight;

			[HideInInspector]
			[SerializeField]
			public UnityEvent onLeftFootstep;

			[HideInInspector]
			[SerializeField]
			public UnityEvent onRightFootstep;

			private Footstep[] tvk;

			private Vector3 tvl;

			private Vector3 tvm;

			private int tvn;

			private int tvo;

			public Vector3 tvj
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

			public Vector3 xrw => default(Vector3);

			public Vector3 xrx => default(Vector3);

			public Quaternion xry => default(Quaternion);

			public Quaternion xrz => default(Quaternion);

			public void kmv(Animator a, Vector3[] b, Quaternion[] c, bool d, float e)
			{
			}

			public void kmw(Vector3[] a, Quaternion[] b)
			{
			}

			public void kmx()
			{
			}

			public void kmy(Quaternion a, Vector3 b)
			{
			}

			public void kmz(Vector3 a)
			{
			}

			public void kna(Animator a, Vector3[] b)
			{
			}

			private void knb(Vector3[] a)
			{
			}

			public void knc(Vector3[] a)
			{
			}

			private void knd(Quaternion a, Vector3 b)
			{
			}

			private void kne(Vector3 a)
			{
			}

			public void knf(IKSolverVR a, float b, float c)
			{
			}

			private void kni(Vector3[] a, Quaternion[] b, bool c, float d)
			{
			}

			private void knj(Vector3[] a, Quaternion[] b)
			{
			}

			private void knk()
			{
			}

			private void knl(Quaternion a, Vector3 b)
			{
			}

			private void knm(Vector3 a)
			{
			}

			public void knn(VirtualBone a, Spine b, Leg c, Leg d, Arm e, Arm f, int g, out Vector3 h, out Vector3 i, out Quaternion j, out Quaternion k, out float l, out float m, out float n, out float o, float p, float q)
			{
				h = default(Vector3);
				i = default(Vector3);
				j = default(Quaternion);
				k = default(Quaternion);
				l = default(float);
				m = default(float);
				n = default(float);
				o = default(float);
			}

			private bool kns(Vector3 a, Vector3 b, Vector3 c)
			{
				return false;
			}

			private bool knt()
			{
				return false;
			}

			private static bool knu(Vector3 a, Vector3 b, Vector3 c, float d)
			{
				return false;
			}
		}

		[Serializable]
		public class Spine : BodyPart
		{
			[LargeHeader("Head")]
			public Transform headTarget;

			[Range(0f, 1f)]
			public float positionWeight;

			[Range(0f, 1f)]
			public float rotationWeight;

			[Range(0f, 1f)]
			public float headClampWeight;

			public float minHeadHeight;

			[Range(0f, 1f)]
			public float useAnimatedHeadHeightWeight;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float useAnimatedHeadHeightRange;

			[ShowIf(/*Could not decode attribute arguments.*/)]
			public float animatedHeadHeightBlend;

			[LargeHeader("Pelvis")]
			public Transform pelvisTarget;

			[Range(0f, 1f)]
			public float pelvisPositionWeight;

			[Range(0f, 1f)]
			public float pelvisRotationWeight;

			[Range(0f, 1f)]
			public float maintainPelvisPosition;

			[LargeHeader("Chest")]
			public Transform chestGoal;

			[Range(0f, 1f)]
			public float chestGoalWeight;

			[Range(0f, 1f)]
			public float chestClampWeight;

			[Range(0f, 1f)]
			public float rotateChestByHands;

			[LargeHeader("Spine")]
			[Range(0f, 1f)]
			public float bodyPosStiffness;

			[Range(0f, 1f)]
			public float bodyRotStiffness;

			[FormerlySerializedAs("chestRotationWeight")]
			[Range(0f, 1f)]
			public float neckStiffness;

			public float moveBodyBackWhenCrouching;

			[LargeHeader("Root Rotation")]
			[Range(0f, 180f)]
			public float maxRootAngle;

			[Range(-180f, 180f)]
			public float rootHeadingOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 IKPositionHead;

			[NonSerialized]
			[HideInInspector]
			public Quaternion IKRotationHead;

			[NonSerialized]
			[HideInInspector]
			public Vector3 IKPositionPelvis;

			[NonSerialized]
			[HideInInspector]
			public Quaternion IKRotationPelvis;

			[NonSerialized]
			[HideInInspector]
			public Vector3 goalPositionChest;

			[NonSerialized]
			[HideInInspector]
			public Vector3 pelvisPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 chestPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 headPositionOffset;

			[NonSerialized]
			[HideInInspector]
			public Quaternion pelvisRotationOffset;

			[NonSerialized]
			[HideInInspector]
			public Quaternion chestRotationOffset;

			[NonSerialized]
			[HideInInspector]
			public Quaternion headRotationOffset;

			[NonSerialized]
			[HideInInspector]
			public Vector3 faceDirection;

			[NonSerialized]
			[HideInInspector]
			internal Vector3 tvp;

			private Quaternion tvs;

			private Quaternion tvt;

			private Quaternion tvu;

			private Quaternion tvv;

			private Quaternion tvw;

			private Vector3 tvx;

			private Quaternion tvy;

			private Quaternion tvz;

			private int twa;

			private int twb;

			private int twc;

			private int twd;

			private int twe;

			private float twf;

			private bool twg;

			private bool twh;

			private bool twi;

			private float twj;

			private float twk;

			private Vector3 twl;

			internal VirtualBone xsa => null;

			internal VirtualBone xsb => null;

			internal VirtualBone xsc => null;

			internal VirtualBone xsd => null;

			private VirtualBone xse => null;

			internal Quaternion tvq
			{
				[CompilerGenerated]
				get
				{
					return default(Quaternion);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			internal Quaternion tvr
			{
				[CompilerGenerated]
				get
				{
					return default(Quaternion);
				}
				[CompilerGenerated]
				private set
				{
				}
			}

			protected override void kku(Vector3[] a, Quaternion[] b, bool c, bool d, bool e, bool f, bool g, int h, int i)
			{
			}

			public override void kkv(float a)
			{
			}

			public override void kkw(float a)
			{
			}

			private void koe(VirtualBone a, Arm[] b)
			{
			}

			public void kof(Animator a, VirtualBone b, Leg[] c, Arm[] d, float e)
			{
			}

			private void kog(Vector3 a, Vector3 b, float c)
			{
			}

			private void koh()
			{
			}

			public override void kla(ref Vector3[] a, ref Quaternion[] b)
			{
			}

			public override void kkz()
			{
			}

			private void koi(ref Quaternion a, Arm[] b)
			{
			}

			public void koj(Leg[] a, bool b, bool c, Vector3 d, float e)
			{
			}

			private void kok(Leg[] a, Vector3 b, Quaternion c, float d)
			{
			}

			private Vector3 kol(Leg[] a, Vector3 b, bool c, int d = 2)
			{
				return default(Vector3);
			}

			private void kom(VirtualBone[] a, int b, int c, Quaternion d, float e, bool f, float g)
			{
			}

			private void kon(VirtualBone[] a, int b, int c, Quaternion d, Quaternion e, float f, bool g, float h)
			{
			}
		}

		[Serializable]
		public enum PositionOffset
		{
			Pelvis = 0,
			Chest = 1,
			Head = 2,
			LeftHand = 3,
			RightHand = 4,
			LeftFoot = 5,
			RightFoot = 6,
			LeftHeel = 7,
			RightHeel = 8
		}

		[Serializable]
		public enum RotationOffset
		{
			Pelvis = 0,
			Chest = 1,
			Head = 2
		}

		[Serializable]
		public class VirtualBone
		{
			public Vector3 readPosition;

			public Quaternion readRotation;

			public Vector3 solverPosition;

			public Quaternion solverRotation;

			public float length;

			public float sqrMag;

			public Vector3 axis;

			public VirtualBone(Vector3 position, Quaternion rotation)
			{
			}

			public void koo(Vector3 a, Quaternion b)
			{
			}

			public static void kop(VirtualBone[] a, int b, Vector3 c, float d = 1f)
			{
			}

			public static float koq(ref VirtualBone[] a)
			{
				return 0f;
			}

			public static void kor(VirtualBone[] a, int b, Vector3 c, Quaternion d)
			{
			}

			public static void kos(VirtualBone[] a, int b, Quaternion c)
			{
			}

			public static void kot(VirtualBone[] a, Quaternion b)
			{
			}

			public static void kou(VirtualBone[] a, int b, Quaternion c)
			{
			}

			public static void kov(VirtualBone[] a, int b, int c, int d, Vector3 e, Vector3 f, float g)
			{
			}

			private static Vector3 kow(Vector3 a, float b, Vector3 c, float d, float e)
			{
				return default(Vector3);
			}

			public static void kox(VirtualBone[] a, Vector3 b, Vector3 c, float d, float e, int f, float g, Vector3 h)
			{
			}

			private static Vector3 koy(Vector3 a, Vector3 b, float c)
			{
				return default(Vector3);
			}

			public static void koz(VirtualBone[] a, Vector3 b, float c, int d)
			{
			}
		}

		private Transform[] twn;

		private bool two;

		private bool twp;

		private bool twq;

		private bool twr;

		private bool tws;

		private bool twt;

		private Vector3[] twu;

		private Quaternion[] twv;

		private Vector3[] tww;

		private Quaternion[] twx;

		private Quaternion[] twy;

		private Vector3[] twz;

		private Vector3 txa;

		private Vector3 txb;

		private Vector3 txc;

		private int txd;

		private int txe;

		private float txf;

		[Range(0f, 2f)]
		public int LOD;

		public float scale;

		public bool plantFeet;

		public Spine spine;

		public Arm leftArm;

		public Arm rightArm;

		public Leg leftLeg;

		public Leg rightLeg;

		public Locomotion locomotion;

		private Leg[] txh;

		private Arm[] txi;

		private Vector3 txj;

		private Vector3 txk;

		private Vector3 txl;

		private Vector3 txm;

		private Vector3 txn;

		private Vector3 txo;

		private Vector3 txp;

		private Vector3 txq;

		public Animator twm
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

		[HideInInspector]
		public VirtualBone txg
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

		public void kpc(bmo.References a)
		{
		}

		public void kpd(bmo.References a, bool b)
		{
		}

		public void kpe()
		{
		}

		public void kpf(PositionOffset a, Vector3 b)
		{
		}

		public void kpg(RotationOffset a, Vector3 b)
		{
		}

		public void kph(RotationOffset a, Quaternion b)
		{
		}

		public void kpi(Vector3 a, Quaternion b, Vector3 c)
		{
		}

		public void kpj()
		{
		}

		public override void keo()
		{
		}

		public override void ken()
		{
		}

		public override Point[] kel()
		{
			return null;
		}

		public override Point kem(Transform a)
		{
			return null;
		}

		public override bool keb(ref string a)
		{
			return false;
		}

		private Vector3 kpk(Transform[] a)
		{
			return default(Vector3);
		}

		private static Keyframe[] kpl(float a)
		{
			return null;
		}

		private void kpm()
		{
		}

		protected override void kep()
		{
		}

		protected override void keq()
		{
		}

		private void kpn()
		{
		}

		private void kpo(Vector3[] a, Quaternion[] b, bool c, bool d, bool e, bool f, bool g, bool h)
		{
		}

		private void kpp()
		{
		}

		private Vector3 kpq(int a)
		{
			return default(Vector3);
		}

		private Quaternion kpr(int a)
		{
			return default(Quaternion);
		}

		private void kpu()
		{
		}

		private Vector3 kpv(float a)
		{
			return default(Vector3);
		}
	}
}
