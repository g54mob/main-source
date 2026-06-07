using System.Diagnostics;
using Simulation;

public class MCElement : SPIElement
{
	public MicroController mc;

	public double VIN_MAX;

	public double VIN_MIN;

	public double SINK_MAX;

	public double SOURCE_MAX;

	public double V_HL;

	public double V_LL;

	public double GND_VL;

	private int D13;

	private int _3V3;

	public int REF;

	private int A0;

	private int A1;

	private int A2;

	private int A3;

	private int A4;

	private int A5;

	private int A6;

	private int A7;

	private int _5V;

	private int RST;

	private int GND;

	private int VIN;

	private int D0;

	private int D1;

	private int RST1;

	private int GND1;

	private int D2;

	private int D3;

	private int D4;

	private int D5;

	private int D6;

	private int D7;

	private int D8;

	private int D9;

	private int D10;

	private int D11;

	private int D12;

	private int _5Vinternal;

	private int _3V3internal;

	private int _pwm0;

	private int _pwm1;

	private int _pwm2;

	private int _pwm3;

	private int _pwm4;

	private int _pwm5;

	public Pin[] pins;

	public int[] digitalPins;

	public int[] analogPins;

	public int[] pwmPins;

	private int[] vs;

	private bool hasPower;

	private bool resetTrig;

	public Stopwatch sw;

	public override int GetLeadCount()
	{
		return 0;
	}

	public override int getInternalLeadCount()
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

	public override void MatrixInitialise()
	{
	}

	public override int GetVoltageSourceCount()
	{
		return 0;
	}

	public override void setVoltageSource(int leadX, int voltSourceNdx)
	{
	}

	public override void Reset()
	{
	}

	public override void DefineMatrixUnknowns()
	{
	}

	public override void Step()
	{
	}
}
