using LocoSim.Definitions;
using UnityEngine;

namespace LocoSim.Implementations
{
	public class ManualTransmissionInput : SimComponent
	{
		private readonly bool gear0IsNeutral;

		public readonly Port controlExtIn;

		public readonly PortReference reverserReader;

		public readonly PortReference numOfGearsReader;

		public readonly Port reverserReadOut;

		public readonly Port gearReadOut;

		private int numOfGears;

		public ManualTransmissionInput(ManualTransmissionInputDefinition mtiDef)
			: base(mtiDef.ID)
		{
			gear0IsNeutral = mtiDef.gear0IsNeutral;
			controlExtIn = AddPort(mtiDef.controlExtIn);
			reverserReader = AddPortReference(mtiDef.reverserReader);
			numOfGearsReader = AddPortReference(mtiDef.numOfGearsReader);
			reverserReadOut = AddPort(mtiDef.reverserReadOut);
			gearReadOut = AddPort(mtiDef.gearReadOut);
		}

		public override void InitializationAfterConnecting()
		{
			numOfGears = Mathf.RoundToInt(numOfGearsReader.Value);
		}

		public override void Tick(float delta)
		{
			int num = Mathf.RoundToInt(controlExtIn.Value * (float)(numOfGears - 1));
			reverserReadOut.Value = ((gear0IsNeutral && num == 0) ? 0f : reverserReader.Value);
			gearReadOut.Value = num;
		}
	}
}
