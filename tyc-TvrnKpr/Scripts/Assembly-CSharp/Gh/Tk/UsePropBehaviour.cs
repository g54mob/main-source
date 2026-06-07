namespace Gh.Tk
{
	public class UsePropBehaviour : PatronBehaviour
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		private bool _done;

		[PersistenceOptIn]
		public string PrefabIdentifier;

		[PersistenceOptIn]
		private string _usageKey;

		public UsePropBehaviour()
		{
		}

		public UsePropBehaviour(Patron owner, string prefabIdentifier, string usageKey, int priority = -10)
		{
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override bool IsTreshholdReached()
		{
			return false;
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
