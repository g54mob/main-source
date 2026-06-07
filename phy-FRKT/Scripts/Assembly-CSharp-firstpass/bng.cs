using System;
using UnityEngine;

public class bng : bnd
{
	[Serializable]
	public class ReachCone
	{
		public Vector3[] tetrahedron;

		public float volume;

		public Vector3 S;

		public Vector3 B;

		public Vector3 xst => default(Vector3);

		public Vector3 xsu => default(Vector3);

		public Vector3 xsv => default(Vector3);

		public Vector3 xsw => default(Vector3);

		public bool xsx => false;

		public ReachCone(Vector3 _o, Vector3 _a, Vector3 _b, Vector3 _c)
		{
		}

		public void kyf()
		{
		}
	}

	[Serializable]
	public class LimitPoint
	{
		public Vector3 point;

		public float tangentWeight;
	}

	[Range(0f, 180f)]
	public float twistLimit;

	[Range(0f, 3f)]
	public int smoothIterations;

	[HideInInspector]
	public LimitPoint[] points;

	[HideInInspector]
	public Vector3[] P;

	[HideInInspector]
	public ReachCone[] reachCones;

	public void nax()
	{
	}

	private void kyi()
	{
	}

	public void nmb(LimitPoint[] a)
	{
	}

	public void mqh()
	{
	}

	private float ibi(int a)
	{
		return 0f;
	}

	protected override Quaternion kxl(Quaternion a)
	{
		return default(Quaternion);
	}

	private int kys(Vector3 a)
	{
		return 0;
	}

	private float lvx(int a)
	{
		return 0f;
	}

	private int ooo(Vector3 a)
	{
		return 0;
	}

	private Vector3 dli(Vector3 a, float b)
	{
		return default(Vector3);
	}

	private int hqg(Vector3 a)
	{
		return 0;
	}

	public void kyk(LimitPoint[] a)
	{
	}

	public void yx(LimitPoint[] a)
	{
	}

	private void maj()
	{
	}

	public void bdi()
	{
	}

	private void kyj()
	{
	}

	public void jni(LimitPoint[] a)
	{
	}

	private void Start()
	{
	}

	public void gca()
	{
	}

	public void csp()
	{
	}

	private Quaternion kyr(Quaternion a)
	{
		return default(Quaternion);
	}

	public void bqv()
	{
	}

	private void kyg()
	{
	}

	private Vector3 kyq(Vector3 a, float b)
	{
		return default(Vector3);
	}

	private float kyo(int a)
	{
		return 0f;
	}

	public void kym()
	{
	}

	private void kyh()
	{
	}

	public void cfv()
	{
	}

	public void nzw(LimitPoint[] a)
	{
	}

	private Vector3 dcl(Vector3 a, float b)
	{
		return default(Vector3);
	}

	public void kyl()
	{
	}

	private Vector3 fs(Vector3 a, float b)
	{
		return default(Vector3);
	}

	private Vector3 jxb(Vector3 a, float b)
	{
		return default(Vector3);
	}

	private Vector3[] nsf()
	{
		return null;
	}

	private int hpf(Vector3 a)
	{
		return 0;
	}

	private Vector3 kyp(Vector3 a, float b)
	{
		return default(Vector3);
	}

	public void oqq()
	{
	}

	private Vector3 gyt(Vector3 a, float b)
	{
		return default(Vector3);
	}

	private Vector3 lwn(Vector3 a, float b)
	{
		return default(Vector3);
	}

	private Vector3[] kyn()
	{
		return null;
	}

	private Vector3[] iub()
	{
		return null;
	}

	private Vector3 kpx(Vector3 a, float b)
	{
		return default(Vector3);
	}
}
