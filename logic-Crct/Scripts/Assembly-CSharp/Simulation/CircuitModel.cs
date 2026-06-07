using System;
using System.Runtime.InteropServices;

namespace Simulation
{
	public abstract class CircuitModel : ICircuitModel
	{
		public class Pin
		{
			public string name;

			public ArduinoPinType aPinType;

			public int voltSource;

			public bool lineOver;

			public bool clock;

			public bool output;

			public bool value;

			public bool tone;

			public bool input;

			public bool last;

			public double current;

			public double nextPulse;

			public double endTime;

			public double voltDrop;

			public bool pulse;

			public int outputVal;

			public int freq;

			public int duration;

			public double impedence;

			public int analogVal;

			public double lastFreqT;

			public double durationT;

			public Pin()
			{
			}

			public Pin(PinType pType)
			{
			}

			public Pin(ArduinoPinType pType)
			{
			}

			public Pin(string nm)
			{
			}

			public void reset()
			{
			}
		}

		protected bool req_converge;

		private bool[] _isConnected;

		protected int failCounter;

		protected int failsteps;

		public BaseComponent Component;

		public long[] nodeData;

		public static readonly double pi;

		protected int voltSource;

		public double Current;

		protected int[] lead_node;

		public double[] Lead_volt;

		public double I_MAX;

		private Action step_function_delegate;

		private GCHandle step_function_handle;

		private IntPtr step_function_ptr_internal;

		private GCHandle lead_volt_hnd;

		private IntPtr lead_volt_mem_private;

		public int leadCount;

		public bool Requires_Convergence => false;

		public bool[] IsConnected => null;

		public Circuit.Lead lead0 => null;

		public Circuit.Lead lead1 => null;

		public IntPtr step_function_ptr => (IntPtr)0;

		public IntPtr lead_volt_mem
		{
			get
			{
				return (IntPtr)0;
			}
			set
			{
			}
		}

		public virtual string GetName()
		{
			return null;
		}

		public CircuitModel()
		{
		}

		public void test_step()
		{
		}

		~CircuitModel()
		{
		}

		protected void InitialiseLeads()
		{
		}

		public virtual void CalculateCurrent()
		{
		}

		public int getLeadNode(int lead_ndx)
		{
			return 0;
		}

		public void setLeadNode(int lead_ndx, int node_ndx)
		{
		}

		public virtual void InitStep()
		{
		}

		public virtual void Step()
		{
		}

		public virtual void MatrixInitialise()
		{
		}

		public virtual void DefineMatrixUnknowns()
		{
		}

		public virtual void RemovePreprocessValues()
		{
		}

		public virtual void GetMatrixPointers()
		{
		}

		public virtual void CCS_PreProcess()
		{
		}

		public virtual void CheckFail()
		{
		}

		public virtual void Reset()
		{
		}

		public virtual int GetLeadCount()
		{
			return 0;
		}

		public virtual int getInternalLeadCount()
		{
			return 0;
		}

		public virtual double getLeadVoltage(int leadX)
		{
			return 0.0;
		}

		public virtual void setLeadVoltage(int leadX, double vValue)
		{
		}

		public virtual double getCurrent()
		{
			return 0.0;
		}

		public virtual void setCurrent(int voltSourceNdx, double c)
		{
		}

		public virtual double GetVoltageDelta()
		{
			return 0.0;
		}

		public virtual int GetVoltageSourceCount()
		{
			return 0;
		}

		public virtual void setVoltageSource(int leadX, int voltSourceNdx)
		{
		}

		public virtual bool leadsAreConnected(int leadX, int leadY)
		{
			return false;
		}

		public virtual bool IsLeadGround(int leadX)
		{
			return false;
		}

		public virtual bool IsWire()
		{
			return false;
		}

		public virtual bool IsNonLinear()
		{
			return false;
		}

		protected static bool comparePair(int x1, int x2, int y1, int y2)
		{
			return false;
		}

		public virtual bool FailCondition()
		{
			return false;
		}

		public virtual double GetPower()
		{
			return 0.0;
		}
	}
}
