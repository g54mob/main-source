namespace Gh.Tk
{
	public class InspectStockBehaviour : StaffBehaviour
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		private DogsbodySkill _dogsbodySkill;

		protected InspectStockBehaviour()
		{
		}

		public InspectStockBehaviour(Staff staff)
		{
		}

		public override void Init()
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}
	}
}
