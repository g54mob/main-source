using Factory.FieldData;

namespace Factory.Mech
{
	public class Statue : MechBase
	{
		private eLuggage _luggage;

		private double _craftSpeed;

		private double AllStatue_SpeedUp;

		private bool AvailableStatueHero;

		private Structure Output => null;

		public override eLuggage Product => default(eLuggage);

		public override bool HasToggleSwitch => false;

		public Statue(Structure[] structures)
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

		public override void SwitchToggle()
		{
		}
	}
}
