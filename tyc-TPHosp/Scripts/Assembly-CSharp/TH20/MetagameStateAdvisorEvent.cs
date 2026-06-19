namespace TH20
{
	public class MetagameStateAdvisorEvent : MetagameState
	{
		private readonly AdvisorMessageDefinition _definition;

		public MetagameStateAdvisorEvent(MetagameMap map, PostCutsceneAdvisorEventDefinition definition)
			: base(map)
		{
			_definition = definition.Definition;
		}

		public override void Enter()
		{
			MetagameMapCareerUI metagameMapCareerUI = MetagameMap.MapUI as MetagameMapCareerUI;
			if (!(metagameMapCareerUI == null))
			{
				metagameMapCareerUI.AdvisorMenu.ShowAdvisorMessage(_definition);
			}
		}

		public override void Update()
		{
			MetagameMapCareerUI metagameMapCareerUI = MetagameMap.MapUI as MetagameMapCareerUI;
			if (metagameMapCareerUI == null)
			{
				PopState();
			}
			else if (!metagameMapCareerUI.AdvisorMenu.IsShowingMessage)
			{
				PopState();
			}
		}
	}
}
