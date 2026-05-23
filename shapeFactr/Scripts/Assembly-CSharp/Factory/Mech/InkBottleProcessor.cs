using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class InkBottleProcessor : MechBase
	{
		private StructureAddr fromAddr;

		private bool _isAnimation;

		private double inkParBottle;

		private eLuggage product;

		private MiniLiquidCarrier EntranceTank => null;

		private MiniLiquidCarrier WorkTank => null;

		public override int MinionLayer { get; set; }

		public override eLuggage Product => default(eLuggage);

		public override bool HasToggleSwitch => false;

		public override bool HasRotateSwitch => false;

		public InkBottleProcessor(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdatePortAddrs()
		{
		}

		private void _UpdateCircuitData()
		{
		}

		private void _UpdateAttachmentData()
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

		private eLuggage SearchInkBottleProcessorBlueprint(eLuggage input)
		{
			return default(eLuggage);
		}

		public override void SwitchToggle()
		{
		}

		public override bool IsPickupable(Structure from, out ILuggageCarrier carrier)
		{
			carrier = null;
			return false;
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
