using System;

namespace Simulation
{
	public interface ICircuitModel
	{
		IntPtr step_function_ptr { get; }

		bool Requires_Convergence { get; }

		bool[] IsConnected { get; }

		IntPtr lead_volt_mem { get; set; }

		void CheckFail();

		void InitStep();

		void Step();

		void test_step();

		void MatrixInitialise();

		void DefineMatrixUnknowns();

		void GetMatrixPointers();

		void RemovePreprocessValues();

		void CCS_PreProcess();

		void Reset();

		int getLeadNode(int lead_ndx);

		void setLeadNode(int lead_ndx, int node_ndx);

		int GetLeadCount();

		int getInternalLeadCount();

		double getLeadVoltage(int leadX);

		void setLeadVoltage(int leadX, double vValue);

		void CalculateCurrent();

		double getCurrent();

		void setCurrent(int voltSourceNdx, double cValue);

		double GetVoltageDelta();

		int GetVoltageSourceCount();

		void setVoltageSource(int leadX, int voltSourceNdx);

		bool leadsAreConnected(int leadX, int leadY);

		bool IsLeadGround(int leadX);

		bool IsWire();

		bool IsNonLinear();
	}
}
