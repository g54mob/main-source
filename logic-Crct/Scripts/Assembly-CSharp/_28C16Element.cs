using Simulation;

public class _28C16Element : CircuitModel
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

	private const int A7 = 0;

	private const int A6 = 1;

	private const int A5 = 2;

	private const int A4 = 3;

	private const int A3 = 4;

	private const int A2 = 5;

	private const int A1 = 6;

	private const int A0 = 7;

	private const int IO0 = 8;

	private const int IO1 = 9;

	private const int IO2 = 10;

	private const int GND = 11;

	private const int IO3 = 12;

	private const int IO4 = 13;

	private const int IO5 = 14;

	private const int IO6 = 15;

	private const int IO7 = 16;

	private const int _CE = 17;

	private const int A10 = 18;

	private const int _OE = 19;

	private const int _WE = 20;

	private const int A9 = 21;

	private const int A8 = 22;

	private const int Vcc = 23;

	public byte[] data;

	private int address;

	private int dataByte;

	private int bit;

	private int[] addressPins;

	private int[] dataPins;

	private bool lastWrite;

	private bool lastEnable;

	private ConductanceStamp_t[] _conductanceStamps_On;

	private ConductanceStamp_t[] _conductanceStamps_Off;

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
