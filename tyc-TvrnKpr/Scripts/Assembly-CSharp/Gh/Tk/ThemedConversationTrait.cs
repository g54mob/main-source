namespace Gh.Tk
{
	public class ThemedConversationTrait : PatronTrait, IAiComponentIsDoneInfo
	{
		[PersistenceOptIn]
		protected bool _failed;

		[PersistenceOptIn]
		public bool IsDone { get; set; }

		public bool Failed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected ThemedConversationTrait()
		{
		}

		public ThemedConversationTrait(Patron owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
