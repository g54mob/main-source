namespace Gh.Tk
{
	public class FrugalTrait : ChefTraitBase
	{
		protected FrugalTrait()
		{
		}

		public FrugalTrait(Staff owner)
		{
		}

		private int GetTriggerChance(GameItem item)
		{
			return 0;
		}

		public bool TryTrigger(Inventory inventory, GameItem item)
		{
			return false;
		}
	}
}
