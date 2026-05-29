using System;
using Factory.FieldData;

namespace Factory.Mech
{
	public class InkBottleReverse : MechBase
	{
		private Structure fromStr;

		private ILiquidCarrier toPipeStr;

		private bool _isAnimation;

		private MiniLiquidCarrier InkTank => null;

		public override eLuggage Product => default(eLuggage);

		public InkBottleReverse(Structure[] structures)
			: base(null)
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

		private eLuggage SearchInkBottleReverseBlueprint(eLuggage input)
		{
			return default(eLuggage);
		}

		private void PlayBillboardAnimation(bool play, bool force = false)
		{
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
	}
}
