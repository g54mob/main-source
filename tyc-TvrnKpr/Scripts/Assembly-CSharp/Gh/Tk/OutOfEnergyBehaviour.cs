namespace Gh.Tk
{
	public class OutOfEnergyBehaviour : PatronBehaviour
	{
		private EnergyStat _energyStat;

		protected OutOfEnergyBehaviour()
		{
		}

		public OutOfEnergyBehaviour(Patron owner)
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
