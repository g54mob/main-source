namespace Gh.Tk
{
	public abstract class MinTavernGameStatWithMinTierRequirementBase : TavernStatRequirement
	{
		private readonly string _itemCategory;

		private readonly int _minTier;

		private string[] _keysToListenTo;

		public MinTavernGameStatWithMinTierRequirementBase(string titleKey, string itemCategory, int targetMinAmount, int minTier, string category = null)
			: base(null, null, 0)
		{
		}

		private void EnsureKeysToListenTo()
		{
		}

		protected abstract string GetStatKey(string itemCategory, int tier);

		protected override void GameHooks_TavernCounterChanged(object sender, EventArgs<(string key, int value)> e)
		{
		}

		protected override int GetValue()
		{
			return 0;
		}
	}
}
