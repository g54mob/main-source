namespace TH20
{
	public class MetagameState : State
	{
		protected MetagameMap MetagameMap;

		protected Metagame Metagame;

		protected MetagameState(MetagameMap map)
		{
			MetagameMap = map;
			Metagame = map.Metagame;
		}

		public virtual bool CanQuickLoadInThisState()
		{
			return false;
		}
	}
}
