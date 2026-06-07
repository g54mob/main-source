using System;
using Effectors.ReceiveMethods.Index;
using Unity.Mathematics;

public abstract class ua<a> : ub, uc, IDisposable where a : biu
{
	protected enum VoxelEffectorAcceptanceConditionType
	{
		OnlyEnabled = 0,
		AlwaysTrue = 1
	}

	protected enum OverallProgressCalculationType
	{
		OnlyEnabledVoxelsIncluded = 0,
		AllVoxelsIncluded = 1
	}

	private delegate float EffectorSignalInfluenceProcessFunction(IndexEffectorSignal signal);

	private readonly float rsp;

	private rx rsq;

	private hx<int3, float> rsr;

	private tz rss;

	private float rst;

	private float rsu;

	private float rsv;

	private float rsw;

	public abstract ue rso { get; protected set; }

	protected abstract VoxelEffectorAcceptanceConditionType xfk { get; }

	protected virtual OverallProgressCalculationType xfn => default(OverallProgressCalculationType);

	protected abstract bool xfl { get; }

	public virtual Type xfm => null;

	public Type xfo => null;

	private sz xfp => null;

	protected ua(float a = 0f)
	{
	}

	private static float ixb(IndexEffectorSignal a)
	{
		return 0f;
	}

	private void gwa(IndexEffectorFeedback a)
	{
	}

	private float ktw(float a)
	{
		return 0f;
	}

	private void ia()
	{
	}

	private void lts(IndexEffectorFeedback a)
	{
	}

	private IndexEffectorSignal gvy(IndexEffectorSignal a)
	{
		return default(IndexEffectorSignal);
	}

	private static float gvx(float a)
	{
		return 0f;
	}

	private float nnj(float a)
	{
		return 0f;
	}

	public bool gvo(int3 a, bool b, out IndexEffectorSignal c)
	{
		c = default(IndexEffectorSignal);
		return false;
	}

	private float hrt(float a)
	{
		return 0f;
	}

	private float llx(int3 a)
	{
		return 0f;
	}

	private void gvr()
	{
	}

	private float gvu(int3 a)
	{
		return 0f;
	}

	private float eci(IndexEffectorSignal a)
	{
		return 0f;
	}

	public void Dispose()
	{
	}

	private static float gvv(IndexEffectorSignal a)
	{
		return 0f;
	}

	protected virtual float gvp(int3 a)
	{
		return 0f;
	}

	private void gvs()
	{
	}

	private float gwc(float a, float b, float c, float d)
	{
		return 0f;
	}

	private void mrn()
	{
	}

	private float gvz(float a)
	{
		return 0f;
	}

	private static float mtn(IndexEffectorSignal a)
	{
		return 0f;
	}

	private float gvw(IndexEffectorSignal a)
	{
		return 0f;
	}

	private bool lnn(int3 a)
	{
		return false;
	}

	private void its()
	{
	}

	private float tr(int3 a)
	{
		return 0f;
	}

	public bool gvm(IndexEffectorSignal a, bool b, bool c, out IndexEffectorFeedback d)
	{
		d = default(IndexEffectorFeedback);
		return false;
	}

	public void gvk(rx a)
	{
	}

	public bool gvl(IndexEffectorSignal a, bool b, bool c, out IndexEffectorFeedback d)
	{
		d = default(IndexEffectorFeedback);
		return false;
	}

	protected virtual float gvq(int3 a)
	{
		return 0f;
	}

	private float mml(float a)
	{
		return 0f;
	}

	private float gte(IndexEffectorSignal a)
	{
		return 0f;
	}

	public void gvn(int a)
	{
	}

	private void dot()
	{
	}

	private bool gwb(int3 a)
	{
		return false;
	}

	private static float fhn(IndexEffectorSignal a)
	{
		return 0f;
	}

	private void gvt()
	{
	}
}
