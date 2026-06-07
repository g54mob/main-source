using System;
using Simulation;

public class LM741Element : Chip
{
	private const int Onull1 = 0;

	private const int Iinv = 1;

	private const int I = 2;

	private const int Vneg = 3;

	private const int Onull2 = 4;

	private const int Q = 5;

	private const int Vpos = 6;

	private const int NC = 7;

	private double lastvd;

	private double gain;

	private double maxOut;

	private double minOut;

	private Random random;

	private int getRand(int x)
	{
		return 0;
	}

	public override string GetName()
	{
		return null;
	}

	public override bool IsNonLinear()
	{
		return false;
	}

	public override void SetupPins()
	{
	}

	public override int GetLeadCount()
	{
		return 0;
	}

	public override int GetVoltageSourceCount()
	{
		return 0;
	}

	public override bool leadsAreConnected(int n1, int n2)
	{
		return false;
	}

	public override bool IsLeadGround(int n1)
	{
		return false;
	}

	public override double GetVoltageDelta()
	{
		return 0.0;
	}

	public override void MatrixInitialise()
	{
	}

	public override void DefineMatrixUnknowns()
	{
	}

	public override void InitStep()
	{
	}

	public override void Step()
	{
	}
}
