using Simulation;

public class _74F189Element : CircuitModel
{
	public double VIN_MAX;

	public double VIN_MIN;

	public double SINK_MAX;

	public double SOURCE_MAX;

	public double V_HL;

	public double V_LL;

	public double GND_VL;

	protected int bits;

	protected Pin[] pins;

	protected bool lastClock;

	protected double maxVcc;

	protected double macCurr;

	private const int A0 = 0;

	private const int _CS = 1;

	private const int _WE = 2;

	private const int D0 = 3;

	private const int _O0 = 4;

	private const int D1 = 5;

	private const int _O1 = 6;

	private const int GND = 7;

	private const int _O2 = 8;

	private const int D2 = 9;

	private const int _O3 = 10;

	private const int D3 = 11;

	private const int A3 = 12;

	private const int A2 = 13;

	private const int A1 = 14;

	private const int Vcc = 15;

	public byte[] data;

	private int address;

	private int dataByte;

	private int bit;

	private int[] addressPins;

	private int[] dataPins;

	private int[] outputPins;

	private ConductanceStamp_t[] _conductanceStamps_On;

	private ConductanceStamp_t[] _conductanceStamps_Off;

	private ConductanceStamp_t _conductanceStamps_Vcc_GND;

	private double _r;

	private int[] failCounters;

	public override int GetLeadCount()
	{
		return 0;
	}

	public override string GetName()
	{
		return null;
	}

	public virtual void setupPins()
	{
	}

	public virtual void execute()
	{
	}

	public virtual bool needsBits()
	{
		return false;
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

	public override void Step()
	{
	}

	public override void Reset()
	{
	}

	public override void CalculateCurrent()
	{
	}

	public override bool leadsAreConnected(int n1, int n2)
	{
		return false;
	}

	public override void CheckFail()
	{
	}
}
