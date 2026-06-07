using Unity.Burst;

namespace Simulation
{
	public class ArduinoElm : CircuitModel
	{
		public int D1;

		public int VIN;

		public int D0;

		public int GND2;

		public int RST1;

		public int RST2;

		public int GND1;

		public int V5;

		public int D2;

		public int A7;

		public int D3;

		public int A6;

		public int D4;

		public int A5;

		public int D5;

		public int A4;

		public int D6;

		public int A3;

		public int D7;

		public int A2;

		public int D8;

		public int A1;

		public int D9;

		public int A0;

		public int D10;

		public int AREF;

		public int D11;

		public int V3;

		public int D12;

		public int D13;

		public double VIN_MAX;

		public double VIN_MIN;

		public string CODE;

		public ArduinoCodeBase CODEBASE;

		public bool needsRESET;

		public Pin[] pins;

		public override string GetName()
		{
			return null;
		}

		public override bool IsNonLinear()
		{
			return false;
		}

		private void setupPins()
		{
		}

		public override void MatrixInitialise()
		{
		}

		public override void InitStep()
		{
		}

		[BurstCompile(FloatMode = FloatMode.Fast)]
		public override void Step()
		{
		}

		public override void DefineMatrixUnknowns()
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override void Reset()
		{
		}

		public override void CalculateCurrent()
		{
		}
	}
}
