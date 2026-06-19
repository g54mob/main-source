namespace TH20
{
	public class MetagameCutsceneGameIntro : MetagameCutsceneInstance
	{
		public MetagameCutsceneGameIntro(MetagameMap map, MetagameCutsceneGameIntroDefinition definition)
			: base(map, definition)
		{
		}

		public override void OnSkip()
		{
			AdvisorMenu advisorMenu = MetagameMap.HUD.FindMenu<AdvisorMenu>();
			if (advisorMenu != null)
			{
				advisorMenu.HideAdvisorMessage();
			}
			base.OnSkip();
		}
	}
}
