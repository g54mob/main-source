namespace Gh.Tk
{
	public class EatBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		[PersistenceOptIn]
		public bool AlsoWantsDessert { get; set; }

		[PersistenceOptIn]
		public string WantsSpecificDessert { get; set; }

		[PersistenceOptIn]
		public string RestrictToSpecificType { get; set; }

		[PersistenceOptIn]
		public bool ShouldOrderDessertNext { get; set; }

		protected EatBehaviour()
		{
		}

		public EatBehaviour(Patron owner)
		{
		}

		public override void Init()
		{
		}

		protected override string GetNeedType()
		{
			return null;
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public static bool HasTavernAnyOrderableFood()
		{
			return false;
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
