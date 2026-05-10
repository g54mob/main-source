using System;
using RootMotion;
using RootMotion.FinalIK;
using UnityEngine;

public class bmq : MonoBehaviour
{
	[Serializable]
	public class BendBone
	{
		public Transform transform;

		[Range(0f, 1f)]
		public float weight;

		private Quaternion tof;

		public BendBone()
		{
		}

		public BendBone(Transform transform, float weight)
		{
		}

		public void jzj()
		{
		}

		public void jzk()
		{
		}
	}

	public bmi ik;

	[LargeHeader("Position")]
	[Range(0f, 1f)]
	public float positionWeight;

	[Range(0f, 1f)]
	public float bodyWeight;

	[Range(0f, 1f)]
	public float thighWeight;

	public bool handsPullBody;

	[LargeHeader("Rotation")]
	[Range(0f, 1f)]
	public float rotationWeight;

	[Range(0f, 1f)]
	public float bodyClampWeight;

	[Range(0f, 1f)]
	public float headClampWeight;

	[Range(0f, 1f)]
	public float bendWeight;

	public BendBone[] bendBones;

	[LargeHeader("CCD")]
	[Range(0f, 1f)]
	public float CCDWeight;

	[Range(0f, 1f)]
	public float roll;

	[Range(0f, 1000f)]
	public float damper;

	public Transform[] CCDBones;

	[LargeHeader("Stretching")]
	[Range(0f, 1f)]
	public float postStretchWeight;

	public float maxStretch;

	public float stretchDamper;

	public bool fixHead;

	public Transform[] stretchBones;

	[LargeHeader("Chest Direction")]
	public Vector3 chestDirection;

	[Range(0f, 1f)]
	public float chestDirectionWeight;

	public Transform[] chestBones;

	public IKSolver.UpdateDelegate OnPostHeadEffectorFK;

	private Vector3 tog;

	private Vector3 toh;

	private Vector3 toi;

	private Vector3 toj;

	private Vector3 tok;

	private Vector3 tol;

	private Vector3 tom;

	private float ton;

	private float too;

	private float top;

	private Quaternion toq;

	private Quaternion tor;

	private Quaternion[] tos;

	private Vector3 tot;

	private Quaternion tou;

	private Vector3[] tov;

	private Quaternion[] tow;

	private Vector3[] tox;

	private Quaternion[] toy;

	private int toz;

	private int tpa;

	private int tpb;

	private int tpc;

	private void ijd(ref Vector3 a, ref Vector3 b, float c)
	{
	}

	private void dtg()
	{
	}

	private void jzn()
	{
	}

	private void jzv(ref Vector3 a, ref Vector3 b, float c)
	{
	}

	private void lnv()
	{
	}

	private void fvi(ref Vector3 a, ref Vector3 b, float c)
	{
	}

	private void jzu(IKEffector a, Vector3 b, float c, Vector3 d)
	{
	}

	private void obv()
	{
	}

	private void jzr()
	{
	}

	private void jli()
	{
	}

	private void ihb()
	{
	}

	private void obz()
	{
	}

	private void nwc()
	{
	}

	private void jcy()
	{
	}

	private void fxa()
	{
	}

	private void gsf()
	{
	}

	private void OnDestroy()
	{
	}

	private void klk()
	{
	}

	private void gze()
	{
	}

	private void dlv()
	{
	}

	private void ggm(ref Vector3 a, ref Vector3 b, float c)
	{
	}

	private void kpg()
	{
	}

	private void npp()
	{
	}

	private void cvy(ref Vector3 a, ref Vector3 b, float c)
	{
	}

	private void jzt()
	{
	}

	private void jzp()
	{
	}

	private void eqg(IKEffector a, Vector3 b, float c, Vector3 d)
	{
	}

	private void kfc()
	{
	}

	private void hky(int a)
	{
	}

	private void bdd()
	{
	}

	private void jzl()
	{
	}

	private void jzq(int a)
	{
	}

	private void iyg()
	{
	}

	private void jzo()
	{
	}

	private void Start()
	{
	}

	private void jzs()
	{
	}

	private void feh()
	{
	}

	private void jzm()
	{
	}

	private void kmc()
	{
	}
}
