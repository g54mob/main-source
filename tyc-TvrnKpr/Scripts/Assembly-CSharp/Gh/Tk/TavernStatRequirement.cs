namespace Gh.Tk
{
	public class TavernStatRequirement : Requirement
	{
		private readonly string _key;

		private readonly int _targetMinAmount;

		public TavernStatRequirement(string titleKey, string key, int targetMinAmount, string category = null)
		{
		}

		protected override void AttachListeners()
		{
		}

		protected override void DetachListeners()
		{
		}

		protected virtual void GameHooks_TavernCounterChanged(object sender, EventArgs<(string key, int value)> e)
		{
		}

		protected virtual int GetValue()
		{
			return 0;
		}

		protected override void CheckIfDoneInternal()
		{
		}
	}
}
