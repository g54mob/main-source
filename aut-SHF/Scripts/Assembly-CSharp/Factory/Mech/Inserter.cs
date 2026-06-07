using Factory.FieldData;
using Models;

namespace Factory.Mech
{
	public class Inserter : MechBase
	{
		public enum InserterState
		{
			PickupWait = 0,
			Pickup = 1,
			Carrying = 2,
			InsertWait = 3,
			Insert = 4,
			Return = 5
		}

		private InserterState _state;

		private StructureAddr _pickupAddr;

		private StructureAddr _insertAddr;

		private Structure _pickup;

		private Structure _insert;

		private string billboardPartsName;

		private InserterState oldState;

		private double _inserterRate;

		private double[] inserterAnimationTimeline;

		private double AllInserter_SpeedUp;

		private double Inserter_SpeedUp;

		public override bool HasLuggageFilter => false;

		public override bool IsLiquidFilter => false;

		public override eLuggage Product => default(eLuggage);

		public override bool inserterError => false;

		public override bool IsSerialize => false;

		public Inserter(Structure[] structures)
			: base(null)
		{
		}

		private void PlayBillboardAnimation(bool force = false)
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

		private bool IsFilterOk(eLuggage pickupHasLuggageId)
		{
			return false;
		}

		public override void SetFilterLuggage(eLuggage luggage)
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
