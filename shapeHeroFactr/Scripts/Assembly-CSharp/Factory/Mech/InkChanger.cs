using System.Collections.Generic;
using Factory.FieldData;

namespace Factory.Mech
{
	public class InkChanger : MechBase
	{
		public enum State
		{
			Store = 0,
			FeedWait = 1
		}

		private bool _isAnimation;

		private ILiquidCarrier fromPipeStr;

		private ILiquidCarrier toPipeStr;

		private const int EntranceCount = 1;

		private State state;

		private double InkChangerEfficiency;

		private double _outputSpeed;

		private bool modeSmart => false;

		private MiniLiquidCarrier EntranceTank => null;

		private MiniLiquidCarrier ExitTank => null;

		private MiniLiquidCarrier WorkTank => null;

		public override double OutputSpeedPerSec => 0.0;

		public override double Efficiency => 0.0;

		protected override bool isLiquidProduct => false;

		public override bool HasLuggageFilter => false;

		public override bool IsLiquidFilter => false;

		public override bool IsSerialize => false;

		public InkChanger(Structure[] structures)
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

		public override void Update(double deltaTime)
		{
		}

		private eLuggage SearchInkChangerBlueprint(eLuggage a)
		{
			return default(eLuggage);
		}

		private void PlayAnimation(eLuggage color, bool force = false, bool ctor = false)
		{
		}

		public override List<eLuggage> GetFilterLuggageList()
		{
			return null;
		}

		public override void SetIntArray(int[] array)
		{
		}

		public override int[] GetIntArray()
		{
			return null;
		}

		public override string ToDump()
		{
			return null;
		}
	}
}
