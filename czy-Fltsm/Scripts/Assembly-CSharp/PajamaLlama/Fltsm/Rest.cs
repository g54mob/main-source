namespace PajamaLlama.Fltsm
{
	public class Rest : Vital
	{
		public override VitalType VitalType => VitalType.Rest;

		public Rest(Vitals vitals)
			: base(vitals)
		{
		}

		public override void Start()
		{
			GameEventDispatcher.AddListener(GameEventType.NighttimeStarted, OnNighttimeStarted);
		}

		public override void OnDestroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.NighttimeStarted, OnNighttimeStarted);
		}

		public override void Reset()
		{
		}

		public override void ConsumeItem(Item item)
		{
		}

		public override void OnDayStarted()
		{
		}

		private void OnNighttimeStarted(GameEvent gameEvent)
		{
			if (!HasProject() && base.Agent.Community == Community.PlayerCommunity)
			{
				if ((bool)base.Agent.ReservedHouse && base.Agent.ReservedHouse.IsEnabled() && (bool)base.Agent.ReservedHouse.Rejuvenator)
				{
					InstantiateProject(GameManager.Settings.ProjectSettings.RejuvenateProperties, base.Agent.ReservedHouse.Rejuvenator.gameObject);
				}
				else
				{
					InstantiateProject(GameManager.Settings.ProjectSettings.SleepOnGround, Construction.Townheart.gameObject);
				}
			}
		}
	}
}
