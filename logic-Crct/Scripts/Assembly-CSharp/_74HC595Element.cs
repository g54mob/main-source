using Simulation;

public class _74HC595Element : _74HCBase
{
	private int Qb;

	private int Qc;

	private int Qd;

	private int Qe;

	private int Qf;

	private int Qg;

	private int Qh;

	private int _Qh;

	private int _SRCLR;

	private int SRCLK;

	private int RCLK;

	private int _OE;

	private int SER;

	private int Qa;

	private int[] outputPins;

	private ConductanceStamp_t[] _conductanceStamps_On;

	private ConductanceStamp_t[] _conductanceStamps_Off;

	private double _r;

	private const double HIGH_IMPEDANCE = 6250000.0;

	private int shift;

	private int store;

	private bool lastSRCLK;

	private bool lastRCLK;

	public override string GetName()
	{
		return null;
	}

	public override void SetupPins()
	{
	}

	public override int GetLeadCount()
	{
		return 0;
	}

	public override void MatrixInitialise()
	{
	}

	public override void DefineMatrixUnknowns()
	{
	}

	public override void GetMatrixPointers()
	{
	}

	public override void Reset()
	{
	}

	public override void Step()
	{
	}

	public override void ExecuteLogic()
	{
	}
}
