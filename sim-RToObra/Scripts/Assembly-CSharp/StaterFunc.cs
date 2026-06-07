public class StaterFunc
{
	public enum Time
	{
		Enter = 0,
		EveryFrame = 1,
		Interp = 2,
		AtInterp = 3,
		Seq = 4,
		SeqInterp = 5,
		Step = 6,
		AtStep = 7,
		Periodic = 8,
		AtPeriodic = 9,
		OnTrigger = 10,
		Exit = 11
	}

	public delegate void VFunc();

	public delegate void IFunc(float t);

	public delegate void CIFunc(int c, float t);

	public delegate void CFunc(int c);

	public Time time;

	public VFunc vFunc;

	public IFunc iFunc;

	public CIFunc ciFunc;

	public CFunc cFunc;

	public bool called;

	public float f0;

	public float f1;

	public string s0;

	private StaterFunc(Time time_, VFunc vFunc_, float f0_ = 0f, float f1_ = 0f)
	{
		time = time_;
		vFunc = vFunc_;
		f0 = f0_;
		f1 = f1_;
	}

	private StaterFunc(Time time_, IFunc iFunc_, float f0_ = 0f, float f1_ = 0f)
	{
		time = time_;
		iFunc = iFunc_;
		f0 = f0_;
		f1 = f1_;
	}

	private StaterFunc(Time time_, CIFunc ciFunc_, float f0_ = 0f, float f1_ = 0f)
	{
		time = time_;
		ciFunc = ciFunc_;
		f0 = f0_;
		f1 = f1_;
	}

	private StaterFunc(Time time_, CFunc cFunc_, float f0_ = 0f, float f1_ = 0f)
	{
		time = time_;
		cFunc = cFunc_;
		f0 = f0_;
		f1 = f1_;
	}

	private StaterFunc(Time time_, VFunc vFunc_, string s0_)
	{
		time = time_;
		vFunc = vFunc_;
		s0 = s0_;
	}

	public static StaterFunc ENTER(VFunc func)
	{
		return new StaterFunc(Time.Enter, func);
	}

	public static StaterFunc INTERP(IFunc func)
	{
		return new StaterFunc(Time.Interp, func);
	}

	public static StaterFunc AT_INTERP(float t, VFunc func)
	{
		return new StaterFunc(Time.AtInterp, func, t);
	}

	public static StaterFunc STEP(VFunc func)
	{
		return new StaterFunc(Time.Step, func);
	}

	public static StaterFunc AT_STEP(float time, VFunc func)
	{
		return new StaterFunc(Time.AtStep, func, time);
	}

	public static StaterFunc EVERYFRAME(VFunc func)
	{
		return new StaterFunc(Time.EveryFrame, func);
	}

	public static StaterFunc EXIT(VFunc func)
	{
		return new StaterFunc(Time.Exit, func);
	}

	public static StaterFunc SEQ(VFunc func)
	{
		return new StaterFunc(Time.Seq, func);
	}

	public static StaterFunc SEQ_INTERP(float duration, IFunc func)
	{
		return new StaterFunc(Time.SeqInterp, func, duration);
	}

	public static StaterFunc PERIODIC(float period, CIFunc func)
	{
		return new StaterFunc(Time.Periodic, func, period);
	}

	public static StaterFunc AT_PERIODIC(float period, float time, CFunc func)
	{
		return new StaterFunc(Time.AtPeriodic, func, period, time);
	}

	public static StaterFunc ON_TRIGGER(string triggerId, VFunc func)
	{
		return new StaterFunc(Time.OnTrigger, func, triggerId);
	}
}
