using System;
using System.Runtime.CompilerServices;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.Events;

public class bms : MonoBehaviour
{
	[Serializable]
	public class InteractionEvent
	{
		public float time;

		public bool pause;

		public bool pickUp;

		public AnimatorEvent[] animations;

		public Message[] messages;

		public UnityEvent unityEvent;

		public void kqz(Transform a)
		{
		}
	}

	[Serializable]
	public class Message
	{
		public string function;

		public GameObject recipient;

		private const string uam = "";

		public void kra(Transform a)
		{
		}
	}

	[Serializable]
	public class AnimatorEvent
	{
		public Animator animator;

		public Animation animation;

		public string animationState;

		public float crossfadeTime;

		public int layer;

		public bool resetNormalizedTime;

		private const string uan = "";

		public void krb(bool a)
		{
		}

		private void krc(Animator a)
		{
		}

		private void krd(Animation a)
		{
		}
	}

	[Serializable]
	public class WeightCurve
	{
		[Serializable]
		public enum Type
		{
			PositionWeight = 0,
			RotationWeight = 1,
			PositionOffsetX = 2,
			PositionOffsetY = 3,
			PositionOffsetZ = 4,
			Pull = 5,
			Reach = 6,
			RotateBoneWeight = 7,
			Push = 8,
			PushParent = 9,
			PoserWeight = 10,
			BendGoalWeight = 11
		}

		public Type type;

		public AnimationCurve curve;

		public float kre(float a)
		{
			return 0f;
		}
	}

	[Serializable]
	public class Multiplier
	{
		public WeightCurve.Type curve;

		public float multiplier;

		public WeightCurve.Type result;

		public float krf(WeightCurve a, float b)
		{
			return 0f;
		}
	}

	public Transform otherLookAtTarget;

	public Transform otherTargetsRoot;

	public Transform positionOffsetSpace;

	public WeightCurve[] weightCurves;

	public Multiplier[] multipliers;

	public InteractionEvent[] events;

	private bmt[] uaq;

	public float uao
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

	public InteractionSystem uap
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

	public Transform xsh => null;

	public Transform xsi => null;

	public bmt nsb(FullBodyBipedEffector a, InteractionSystem b)
	{
		return null;
	}

	private int gzd(WeightCurve.Type a)
	{
		return 0;
	}

	private void krj()
	{
	}

	private void kri()
	{
	}

	private void krl()
	{
	}

	public bmt isv(FullBodyBipedEffector a, InteractionSystem b)
	{
		return null;
	}

	private int jxl(WeightCurve.Type a)
	{
		return 0;
	}

	private void ksc(IKSolverFullBodyBiped a, FullBodyBipedEffector b, WeightCurve.Type c, float d, float e)
	{
	}

	public void dku(IKSolverFullBodyBiped a, FullBodyBipedEffector b, bmt c, float d, float e, bool f)
	{
	}

	public void krs()
	{
	}

	public Transform krx(FullBodyBipedEffector a, string b)
	{
		return null;
	}

	public bmt kru(FullBodyBipedEffector a, InteractionSystem b)
	{
		return null;
	}

	private void idz()
	{
	}

	public float kvj(WeightCurve.Type a, bmt b, float c)
	{
		return 0f;
	}

	private void oou()
	{
	}

	public bmt[] czw()
	{
		return null;
	}

	public float lfh(WeightCurve.Type a, bmt b, float c)
	{
		return 0f;
	}

	public void gfu(IKSolverFullBodyBiped a, FullBodyBipedEffector b, bmt c, float d, float e, bool f)
	{
	}

	private void Start()
	{
	}

	private int kse(WeightCurve.Type a)
	{
		return 0;
	}

	public bool jdq(WeightCurve.Type a)
	{
		return false;
	}

	private void fcj()
	{
	}

	public bmt[] grf()
	{
		return null;
	}

	private void krg()
	{
	}

	private void krn()
	{
	}

	public float ksa(WeightCurve.Type a, bmt b, float c)
	{
		return 0f;
	}

	public bmt dvu(FullBodyBipedEffector a, InteractionSystem b)
	{
		return null;
	}

	private Transform ksd(FullBodyBipedEffector a)
	{
		return null;
	}

	private void krm()
	{
	}

	public bool cwn(WeightCurve.Type a)
	{
		return false;
	}

	public void kry(InteractionSystem a)
	{
	}

	public bmt[] krw()
	{
		return null;
	}

	public void ocz(IKSolverFullBodyBiped a, FullBodyBipedEffector b, bmt c, float d, float e, bool f)
	{
	}

	private void krh()
	{
	}

	private int ksf(WeightCurve.Type a)
	{
		return 0;
	}

	public bmt[] pl()
	{
		return null;
	}

	public bool mjf(WeightCurve.Type a)
	{
		return false;
	}

	public void bub(IKSolverFullBodyBiped a, FullBodyBipedEffector b, bmt c, float d, float e, bool f)
	{
	}

	public bool mex(WeightCurve.Type a)
	{
		return false;
	}

	public void krz(IKSolverFullBodyBiped a, FullBodyBipedEffector b, bmt c, float d, float e, bool f)
	{
	}

	public float nzm(WeightCurve.Type a, bmt b, float c)
	{
		return 0f;
	}

	private void jec()
	{
	}

	public bmt mnm(FullBodyBipedEffector a, InteractionSystem b)
	{
		return null;
	}

	private void krk()
	{
	}

	public void kue()
	{
	}

	private void hsm(IKSolverFullBodyBiped a, FullBodyBipedEffector b, WeightCurve.Type c, float d, float e)
	{
	}

	public bool krv(WeightCurve.Type a)
	{
		return false;
	}

	public bmt[] dup()
	{
		return null;
	}
}
