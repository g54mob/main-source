namespace Gh.Tk
{
	public class FrugalServerTrait : ServerTraitBase
	{
		protected FrugalServerTrait()
		{
		}

		public FrugalServerTrait(Staff owner)
		{
		}

		private int GetTriggerChance(GameItem item)
		{
			return 0;
		}

		public bool TryTrigger(ItemServiceSource source, GameItem item)
		{
			return false;
		}
	}
}
