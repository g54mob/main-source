using System.Runtime.CompilerServices;

namespace Simulation
{
	public class TransistorGeneric : CircuitModel
	{
		private static readonly double leakage;

		private static readonly double voltageT;

		private static readonly double voltageDeltaCoefficient;

		private static readonly double rGain;

		private double _fGain;

		private double _gMin;

		private double _currentCollector;

		private double _currentEmitter;

		private double _currentBase;

		private double _voltageCritical;

		private double _lastVoltageBaseCollector;

		private double _lastVoltageBaseEmitter;

		private double _beta;

		private double _pnp;

		private SingleStamp_t _stamp0;

		private SingleStamp_t _stamp1;

		private SingleStamp_t _stamp2;

		private SingleStamp_t _stamp3;

		private SingleStamp_t _stamp4;

		private SingleStamp_t _stamp5;

		private SingleStamp_t _stamp6;

		private SingleStamp_t _stamp7;

		private SingleStamp_t _stamp8;

		private int _rightSide0;

		private int _rightSide1;

		private int _rightSide2;

		private double _gee;

		private double _gec;

		private double _gce;

		private double _gcc;

		private double _vbe;

		private double _vbc;

		private double _pcoef;

		private double _expbc;

		private double _expbe;

		private double _arg;

		private double _vnew;

		private double _vold;

		public double Beta
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public bool IsPNP
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override string GetName()
		{
			return null;
		}

		public TransistorGeneric()
		{
		}

		public TransistorGeneric(bool isPNP)
		{
		}

		public override int GetLeadCount()
		{
			return 0;
		}

		public override bool IsNonLinear()
		{
			return false;
		}

		private void Initialise()
		{
		}

		public override void Reset()
		{
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

		public override void CheckFail()
		{
		}

		public double LimitStep(double vnew, double vold)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void Step()
		{
		}
	}
}
