using Simulation;

public class HD44780Element : CircuitModel
{
	public HD44780 hd;

	public double VIN_MAX;

	public double VIN_MIN;

	public double SINK_MAX;

	public double SOURCE_MAX;

	public double V_HL;

	public double V_LL;

	protected Pin[] pins;

	protected bool lastEnable;

	private const int VSS = 0;

	private const int VDD = 1;

	private const int V0 = 2;

	private const int RS = 3;

	private const int RW = 4;

	private const int E = 5;

	private const int D0 = 6;

	private const int D1 = 7;

	private const int D2 = 8;

	private const int D3 = 9;

	private const int D4 = 10;

	private const int D5 = 11;

	private const int D6 = 12;

	private const int D7 = 13;

	private const int A = 14;

	private const int K = 15;

	private Simulation.Diode backlightDiode;

	private double forwardV;

	private double leakage;

	public double backlightCurrent;

	public double contrastVoltage;

	private bool powerOn;

	private bool read;

	public bool _8bit;

	private bool[] dataBits;

	private bool _4bitEntry;

	private int[] failCounters;

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

	public override void Reset()
	{
	}

	public override int GetLeadCount()
	{
		return 0;
	}

	public override void MatrixInitialise()
	{
	}

	private void GetDataBits()
	{
	}

	public override void Step()
	{
	}

	public override void DefineMatrixUnknowns()
	{
	}

	public override void GetMatrixPointers()
	{
	}

	public override void CalculateCurrent()
	{
	}

	public override bool IsNonLinear()
	{
		return false;
	}

	public override void CheckFail()
	{
	}
}
