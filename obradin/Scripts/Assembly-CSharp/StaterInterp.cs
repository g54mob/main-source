public abstract class StaterInterp
{
	private float segmentT0;

	private float segmentT1 = 1f;

	public StaterInterp Seg(float segmentT0_, float segmentT1_)
	{
		segmentT0 = segmentT0_;
		segmentT1 = segmentT1_;
		return this;
	}

	public float Interp(float interp)
	{
		interp = Util.LerpScale(interp, segmentT0, segmentT1, 0f, 1f);
		return InterpImpl(interp);
	}

	public abstract float InterpImpl(float interp);

	public static StaterInterp STEP(float t)
	{
		return new StaterInterp_Step(t);
	}

	public static StaterInterp LINEAR()
	{
		return new StaterInterp_Linear();
	}

	public static StaterInterp POW(float p)
	{
		return new StaterInterp_Pow(p);
	}

	public static StaterInterp INVPOW(float p)
	{
		return new StaterInterp_InvPow(p);
	}

	public static StaterInterp SMOOTHSTEP(float e0, float e1)
	{
		return new StaterInterp_Smoothstep(e0, e1);
	}

	public static StaterInterp BOUNCEBACK(float perc, int count)
	{
		return new StaterInterp_Bounceback(perc, count);
	}

	public static StaterInterp FLASH(int count)
	{
		return new StaterInterp_Flash(count);
	}

	public static StaterInterp RISEFALL(float mid)
	{
		return new StaterInterp_RiseFall(mid);
	}
}
