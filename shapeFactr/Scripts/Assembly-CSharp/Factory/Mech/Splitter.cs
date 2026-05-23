using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class Splitter : MechBase
	{
		public enum SplitterMode
		{
			Normal = 0,
			Cross = 1,
			Large = 2,
			Tshaped = 3,
			Huge = 4,
			ModeError = 5
		}

		private readonly SplitterMode _mode;

		private StructureAddr[] _fromAddrs;

		private StructureAddr _entranceAddr;

		private int outMainForNormal;

		private int outSubForNormal;

		private int outMainForTShape;

		private int outSubForTShape;

		private double AllConnector_SpeedUp;

		public override bool HasToggleSwitch => false;

		public override bool HasMultiOutputProduct => false;

		public override bool HasLuggageFilter => false;

		public override bool IsLiquidFilter => false;

		public override bool HasOutputPriority => false;

		public override StructureAddr? OutputPriorityToAddr => null;

		public override bool IsSerialize => false;

		public Splitter(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		private void _UpdateCircuitData()
		{
		}

		public override void UpdateCircuitData(bool updateAttachment = false)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToMinimum()
		{
			return null;
		}

		public override string ToDump()
		{
			return null;
		}

		public override void Update(double deltaTime)
		{
		}

		private bool CheckPriorityB(ILuggageCarrier outputA, ILuggageCarrier outputB)
		{
			return false;
		}

		private ILuggageCarrier GetOutputCarrier(ILuggageCarrier from, ILuggageCarrier outputMain, ILuggageCarrier outputSub)
		{
			return null;
		}

		private ILuggageCarrier GetOutputCarrierWithFilterAndPriority(ILuggageCarrier from, ILuggageCarrier outputMain, ILuggageCarrier outputSub)
		{
			return null;
		}

		public override void SwitchToggle()
		{
		}

		public override void SetIntArray(int[] array)
		{
		}

		public override int[] GetIntArray()
		{
			return null;
		}
	}
}
