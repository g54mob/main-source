using RootMotion.FinalIK;
using UnityEngine;

public class bmc : bly
{
	public struct Foot
	{
		public IKSolver solver;

		public Transform transform;

		public Quaternion rotation;

		public Grounding.Leg leg;

		public Foot(IKSolver solver, Transform transform)
		{
			this.solver = null;
			this.transform = null;
			rotation = default(Quaternion);
			leg = null;
		}
	}

	public Grounding forelegSolver;

	[Range(0f, 1f)]
	public float rootRotationWeight;

	[Range(-90f, 0f)]
	public float minRootRotation;

	[Range(0f, 90f)]
	public float maxRootRotation;

	public float rootRotationSpeed;

	public float maxLegOffset;

	public float maxForeLegOffset;

	[Range(0f, 1f)]
	public float maintainHeadRotationWeight;

	public Transform characterRoot;

	public Transform pelvis;

	public Transform lastSpineBone;

	public Transform head;

	public IK[] legs;

	public IK[] forelegs;

	[HideInInspector]
	public Vector3 gravity;

	private Foot[] tme;

	private Vector3 tmf;

	private Quaternion tmg;

	private Quaternion tmh;

	private Vector3 tmi;

	private Quaternion tmj;

	private Quaternion tmk;

	private int tml;

	private bool tmm;

	private float tmn;

	private Transform tmo;

	private Quaternion tmp;

	private float tmq;

	private Rigidbody tmr;

	private void LateUpdate()
	{
	}

	private void ikc()
	{
	}

	private bool jut(IK[] a)
	{
		return false;
	}

	private void jgz()
	{
	}

	public override void jts()
	{
	}

	private void OnDisable()
	{
	}

	private void juy()
	{
	}

	private Transform[] juv(IK[] a, ref Foot[] b, int c)
	{
		return null;
	}

	private void lcv(IK[] a)
	{
	}

	private void mai()
	{
	}

	private void hbe(IK[] a)
	{
	}

	private void juz(Foot a, float b)
	{
	}

	protected override void jua()
	{
	}

	private void OnDestroy()
	{
	}

	private void juu()
	{
	}

	private void jvb(IK[] a)
	{
	}

	private void ehb()
	{
	}

	private void bfw(IK[] a)
	{
	}

	private bool jcm(IK[] a)
	{
		return false;
	}

	private void Update()
	{
	}

	private void oen()
	{
	}

	private void jux()
	{
	}

	private void hee()
	{
	}

	private void gah()
	{
	}

	private void wi()
	{
	}

	private void nuo()
	{
	}

	private bool jus()
	{
		return false;
	}

	private void iyh()
	{
	}

	private void cwo()
	{
	}

	private bool lmd(IK[] a)
	{
		return false;
	}

	private void osd()
	{
	}

	private void oqm()
	{
	}

	private void cnw()
	{
	}

	private void ldb(IK[] a)
	{
	}

	private void juw()
	{
	}

	private void hpj()
	{
	}

	private void dvr()
	{
	}

	private void eku()
	{
	}

	private void cqv()
	{
	}

	private void hxr()
	{
	}

	protected override void jtz()
	{
	}

	private void del()
	{
	}

	private bool hze(IK[] a)
	{
		return false;
	}

	private void gyf()
	{
	}

	private void jva()
	{
	}
}
