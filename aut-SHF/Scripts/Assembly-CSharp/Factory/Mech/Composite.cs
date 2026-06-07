using System.Collections.Generic;
using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class Composite : MechBase
	{
		public enum CompositeMode
		{
			Large = 0,
			CrossBridge = 1,
			Huge = 2,
			ModeError = 3
		}

		private readonly CompositeMode _mode;

		private StructureAddr[] beltFromFirstAddrs;

		private StructureAddr[] beltEntranceAddrs;

		private Structure[] beltExits;

		private Structure[] pipeEntrances;

		private List<PipeLinkPairInMechBase> pipeLinkPair0;

		private List<ILiquidCarrier> liquidCarriers0;

		private List<PipeLinkPairInMechBase> pipeLinkPair1;

		private List<ILiquidCarrier> liquidCarriers1;

		private double AllConnector_SpeedUp;

		public override bool HasToggleSwitch => false;

		public override bool HasMultiOutputProduct => false;

		public override bool HasLuggageFilter => false;

		public override bool IsLiquidFilter => false;

		public override bool HasOutputPriority => false;

		public override bool IsSerialize => false;

		public Composite(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		private void _UpdatePortAddrs()
		{
		}

		private void _UpdateCircuitData(bool updatePortAddrs = true)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override void Update(double deltaTime)
		{
		}

		private ILuggageCarrier GetOutputCarrier(ILuggageCarrier from, ILuggageCarrier outputMain, ILuggageCarrier outputSub)
		{
			return null;
		}

		public override void SwitchToggle()
		{
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
