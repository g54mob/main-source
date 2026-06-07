namespace Gh.Tk
{
	public abstract class GameObjectXTrait : AiComponent, IAiComponentVisualInfo
	{
		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public float AutoRemoveInSeconds { get; set; }

		public override bool ShouldUpdateTooltipPeriodically
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		protected GameObjectXTrait()
		{
		}

		public GameObjectXTrait(GameObjectX owner, bool canOwnerBeNull = false, bool expectCodexTooltip = true)
		{
		}

		protected override int GetDefaultExecutionOrder()
		{
			return 0;
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}

		public void SetAutoRemoveInDayF(float dayF)
		{
		}

		public override void Update()
		{
		}
	}
}
