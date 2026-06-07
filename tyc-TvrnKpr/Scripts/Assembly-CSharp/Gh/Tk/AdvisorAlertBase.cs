namespace Gh.Tk
{
	[PersistenceOptIn]
	public abstract class AdvisorAlertBase : IPersistable
	{
		[PersistenceOptIn]
		protected float _lastTriggeredAt;

		[PersistenceOptIn]
		protected float _minTimeBeforeNextTrigger;

		public int Priority { get; protected set; }

		public AdvisorAlertBase(int priority = 0)
		{
		}

		protected void SetMinDeltaBeforeNextTrigger(float deltaTime)
		{
		}

		public virtual AdvisorState GetAdvisorState()
		{
			return default(AdvisorState);
		}

		public bool IsGameSpeedOnSpeedOne()
		{
			return false;
		}

		public bool TryTrigger()
		{
			return false;
		}

		internal void SuspendTemporarily()
		{
		}

		protected abstract bool TryTriggerInternal();

		protected bool Trigger(AlertMessage msg)
		{
			return false;
		}
	}
}
