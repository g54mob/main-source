using Simulation;

public class _74HC173Element : _74HCBase
{
	private int _OE;

	private int _OE2;

	private int Q0;

	private int Q1;

	private int Q2;

	private int Q3;

	private int CP;

	private int _E1;

	private int _E2;

	private int D3;

	private int D2;

	private int D1;

	private int D0;

	private int MR;

	private Pin[] outputPins;

	private ConductanceStamp_t[] _conductanceStamps_On;

	private ConductanceStamp_t[] _conductanceStamps_Off;

	private double _r;

	private bool data0;

	private bool data1;

	private bool data2;

	private bool data3;

	public override int GetLeadCount()
	{
		return 0;
	}

	public override string GetName()
	{
		return null;
	}

	public override void SetupPins()
	{
	}

	public override void DefineMatrixUnknowns()
	{
	}

	public override void GetMatrixPointers()
	{
	}

	public override void Step()
	{
	}

	public override void ExecuteLogic()
	{
	}
}
