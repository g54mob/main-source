namespace Gh.Tk
{
	public abstract class StaffExpectationBase : AiComponent
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		protected HappinessStat _happiness;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public new Staff Owner
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		[PersistenceOptIn]
		public string CategoryKey { get; set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string Category { get; set; }

		protected StaffExpectationBase()
		{
		}

		protected StaffExpectationBase(Staff owner, string categoryKey)
		{
		}

		public virtual bool IsEnabled()
		{
			return false;
		}

		public override void Update()
		{
		}

		protected virtual void UpdateInternal()
		{
		}

		public string GetCategoryKey()
		{
			return null;
		}

		public override void Init()
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
