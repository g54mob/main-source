namespace Gh.Tk
{
	public class GenericNeedBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		[PersistenceOptIn]
		private bool _done;

		public GenericNeedBehaviour()
		{
		}

		public GenericNeedBehaviour(Patron owner, string need)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override string GetTraitBadgeIconPrefabName()
		{
			return null;
		}

		public override void Reset()
		{
		}
	}
}
