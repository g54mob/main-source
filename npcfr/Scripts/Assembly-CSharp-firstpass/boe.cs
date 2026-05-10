using System;
using RootMotion.FinalIK;
using UnityEngine;

public static class boe
{
	[Serializable]
	public class Settings
	{
		public float scaleMlp;

		public Vector3 headTrackerForward;

		public Vector3 headTrackerUp;

		public Vector3 handTrackerForward;

		public Vector3 handTrackerUp;

		public Vector3 footTrackerForward;

		public Vector3 footTrackerUp;

		[Space(10f)]
		public Vector3 headOffset;

		public Vector3 handOffset;

		public float footForwardOffset;

		public float footInwardOffset;

		[Range(-180f, 180f)]
		public float footHeadingOffset;

		[Range(0f, 1f)]
		public float pelvisPositionWeight;

		[Range(0f, 1f)]
		public float pelvisRotationWeight;
	}

	[Serializable]
	public class CalibrationData
	{
		[Serializable]
		public class Target
		{
			public bool used;

			public Vector3 localPosition;

			public Quaternion localRotation;

			public Target(Transform t)
			{
			}

			public void lcy(Transform a)
			{
			}
		}

		public float scale;

		public Target head;

		public Target leftHand;

		public Target rightHand;

		public Target pelvis;

		public Target leftFoot;

		public Target rightFoot;

		public Target leftLegGoal;

		public Target rightLegGoal;

		public Vector3 pelvisTargetRight;

		public float pelvisPositionWeight;

		public float pelvisRotationWeight;
	}

	public static void iyl(bmo a, CalibrationData b, float c)
	{
	}

	public static Vector3 bgb(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static Vector3 cmm(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static CalibrationData ldh(bmo a, Transform b, Transform c, Transform d, Vector3 e, Vector3 f, Vector3 g, Vector3 h, float i = 1f)
	{
		return null;
	}

	private static void ldg(CalibrationData a, Transform b, IKSolverVR.Leg c, Transform d, Vector3 e, bool f)
	{
	}

	public static void jeb(bmo a, Transform b, Vector3 c, Vector3 d)
	{
	}

	public static CalibrationData ldd(bmo a, Settings b, Transform c, Transform d = null, Transform e = null, Transform f = null, Transform g = null, Transform h = null)
	{
		return null;
	}

	private static void lde(Settings a, Transform b, IKSolverVR.Leg c, Transform d, Vector3 e, bool f)
	{
	}

	public static void fdt(bmo a, CalibrationData b, float c)
	{
	}

	private static void gdk(bmo a, Transform b, Vector3 c, Vector3 d, bool e)
	{
	}

	public static void ewz(bmo a, Transform b, Transform c, Vector3 d, Vector3 e)
	{
	}

	public static void ldk(bmo a, Transform b, Transform c, Vector3 d, Vector3 e)
	{
	}

	public static void ldf(bmo a, CalibrationData b, Transform c, Transform d = null, Transform e = null, Transform f = null, Transform g = null, Transform h = null)
	{
	}

	public static Vector3 ldn(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static Vector3 ofd(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static void lox(bmo a, CalibrationData b, Settings c)
	{
	}

	public static void ldj(bmo a, Transform b, Vector3 c, Vector3 d)
	{
	}

	public static void bpt(bmo a, CalibrationData b, Settings c)
	{
	}

	public static void lpn(bmo a, Transform b, Transform c, Vector3 d, Vector3 e)
	{
	}

	public static void dlk(bmo a, Transform b, Vector3 c, Vector3 d)
	{
	}

	public static void efo(bmo a, CalibrationData b, Transform c, Transform d = null, Transform e = null, Transform f = null, Transform g = null, Transform h = null)
	{
	}

	private static void gyw(bmo a, float b = 1f)
	{
	}

	public static void h(bmo a, CalibrationData b, float c)
	{
	}

	public static void lcz(bmo a, CalibrationData b, Settings c)
	{
	}

	public static void kbb(bmo a, CalibrationData b, Settings c)
	{
	}

	private static void hnq(bmo a, Transform b, Vector3 c, Vector3 d, bool e)
	{
	}

	private static void kwn(bmo a, float b = 1f)
	{
	}

	public static void nnh(bmo a, Transform b, Vector3 c, Vector3 d)
	{
	}

	private static void mhr(Settings a, Transform b, IKSolverVR.Leg c, Transform d, Vector3 e, bool f)
	{
	}

	public static Vector3 hwa(Transform a, Transform b)
	{
		return default(Vector3);
	}

	private static void cuz(Settings a, Transform b, IKSolverVR.Leg c, Transform d, Vector3 e, bool f)
	{
	}

	private static void byb(bmo a, float b = 1f)
	{
	}

	private static void bla(CalibrationData a, Transform b, IKSolverVR.Leg c, Transform d, Vector3 e, bool f)
	{
	}

	private static void ldb(bmo a, Settings b)
	{
	}

	public static Vector3 hs(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static void jja(bmo a, Transform b, Transform c, Vector3 d, Vector3 e)
	{
	}

	private static void fer(Settings a, Transform b, IKSolverVR.Leg c, Transform d, Vector3 e, bool f)
	{
	}

	public static Vector3 ldm(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static Vector3 nsu(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static void jjr(bmo a, Transform b, Transform c, Vector3 d, Vector3 e)
	{
	}

	public static Vector3 cdn(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static void ldi(bmo a, Transform b, Vector3 c, Vector3 d)
	{
	}

	private static void ldc(bmo a, float b = 1f)
	{
	}

	private static void fre(CalibrationData a, Transform b, IKSolverVR.Leg c, Transform d, Vector3 e, bool f)
	{
	}

	private static void ooq(Settings a, Transform b, IKSolverVR.Leg c, Transform d, Vector3 e, bool f)
	{
	}

	private static void chu(bmo a, float b = 1f)
	{
	}

	public static void llf(bmo a, CalibrationData b, float c)
	{
	}

	public static void dap(bmo a, CalibrationData b, Settings c)
	{
	}

	public static Vector3 ldq(Transform a, Transform b)
	{
		return default(Vector3);
	}

	public static void lda(bmo a, CalibrationData b, float c)
	{
	}

	private static void ldl(bmo a, Transform b, Vector3 c, Vector3 d, bool e)
	{
	}
}
