namespace Gh.Tk
{
	public abstract class PatronBehaviour : ActorBehaviour
	{
		[PersistenceOptIn]
		private bool _failed;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int FailedTriggers { get; set; }

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public int MaxRetries { get; set; }

		public bool CanTriggerWhileWaitingForOtherJob { get; protected set; }

		[PersistenceObjectReference]
		[PersistenceOptIn]
		public new Patron Owner
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

		protected PatronBehaviour()
		{
		}

		public PatronBehaviour(Patron owner, string name, int priority)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		protected virtual string GetNeedType()
		{
			return null;
		}

		public bool IsPatronNeedBehaviour()
		{
			return false;
		}

		public virtual bool IsOptionalBehaviour()
		{
			return false;
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		public override void Reset()
		{
		}
	}
}
