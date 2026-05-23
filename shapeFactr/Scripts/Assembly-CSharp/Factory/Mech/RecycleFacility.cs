using Factory.FieldData;
using Libs;
using Models;

namespace Factory.Mech
{
	public class RecycleFacility : MechBase
	{
		private bool _isAnimation;

		private FixedQueue<eLuggage> luggageQueue;

		private double Recycle_EfficiencyUp;

		public override bool HasToggleSwitch => false;

		public override bool HasRotateSwitch => false;

		public RecycleFacility(Structure[] structures)
			: base(null)
		{
		}

		private void _UpdatePortAddrs()
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

		public override void SetIntArray(int[] array)
		{
		}

		public override int[] GetIntArray()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public override void Update(double deltaTime)
		{
		}

		private void PlayBillboardAnimation(bool play, bool force = false)
		{
		}

		public int GetRecycleCounter()
		{
			return 0;
		}

		public void AddLuggage(eLuggage luggage)
		{
		}

		public override void SwitchToggle()
		{
		}

		public override void SwitchRotate(StructureAddr addr)
		{
		}

		public override bool IsPickupable(Structure from, out ILuggageCarrier carrier)
		{
			carrier = null;
			return false;
		}
	}
}
