using System;
using Factory.FieldData;
using Factory.FieldObject;
using Models;

namespace Factory.Mech
{
	public class Cutter : MechBase
	{
		public enum CutterMode
		{
			Normal = 0,
			Smart = 1,
			ModeError = 2
		}

		private CutterMode mode;

		private StructureAddr? fromAddrMain;

		private StructureAddr? fromAddrSub;

		private StructureAddr entAddrMain;

		private StructureAddr entAddrSub;

		private int outMain;

		private int outSub;

		private double _smartParallelCircuitRate;

		private bool addInput;

		private bool addDualOutput;

		private double normalRate;

		private double smartRate;

		private Structure fromStrMain;

		private Structure fromStrSub;

		private eLuggage product;

		public override double outputPortUtilizationAverageMain => 0.0;

		public override double outputPortUtilizationAverageSub => 0.0;

		public override bool HasToggleSwitch => false;

		public override eLuggage Product => default(eLuggage);

		public Cutter(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdateAttachmentData()
		{
		}

		private void _UpdatePortAddrs()
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

		public override void Update(double deltaTime)
		{
		}

		private (eLuggage, eLuggage) SearchCutterBlueprint(Luggage input)
		{
			return default((eLuggage, eLuggage));
		}

		public override void SwitchToggle()
		{
		}

		private void PlayBillboardAnimation(bool play, eLuggage luggage, bool elite)
		{
		}

		public override bool IsPickupable(Structure from, out ILuggageCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public override bool IsInsertable(ILuggageCarrier fromCarrier, Structure to, out ILuggageCarrier toCarrier, out double luggageRate, out bool visible, out bool? cautionIcon, out Action<ILuggageCarrier> successCallback)
		{
			toCarrier = null;
			luggageRate = default(double);
			visible = default(bool);
			cautionIcon = null;
			successCallback = null;
			return false;
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
