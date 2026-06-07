using System.Runtime.CompilerServices;
using RootMotion.FinalIK;
using UnityEngine;

public abstract class bly : MonoBehaviour
{
	public delegate void GrounderDelegate();

	[Range(0f, 1f)]
	public float weight;

	public Grounding solver;

	public GrounderDelegate OnPreGrounder;

	public GrounderDelegate OnPostGrounder;

	public GrounderDelegate OnPostIK;

	public bool tlm
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		protected set
		{
		}
	}

	public abstract void jts();

	protected Vector3 cef()
	{
		return default(Vector3);
	}

	protected abstract void jtz();

	protected void jtw(string a)
	{
	}

	protected abstract void jua();

	protected void imj(string a)
	{
	}

	private Vector3 jty(Grounding.Leg a)
	{
		return default(Vector3);
	}

	private Vector3 jtx(Grounding.Leg a)
	{
		return default(Vector3);
	}

	protected void dbz(string a)
	{
	}

	protected void fpt(string a)
	{
	}

	protected Vector3 jtv()
	{
		return default(Vector3);
	}
}
