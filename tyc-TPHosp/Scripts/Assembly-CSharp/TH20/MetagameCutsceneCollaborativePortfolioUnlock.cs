namespace TH20
{
	public class MetagameCutsceneCollaborativePortfolioUnlock : MetagameCutsceneInstance
	{
		public MetagameCutsceneCollaborativePortfolioUnlock(MetagameMap map, MetagameCutsceneCollaborativePortfolioUnlockDefinition definition)
			: base(map, definition)
		{
		}

		public override void OnCutsceneStart()
		{
			MetagameMap.App.UserProfile.HasSeenCollaborativeProjectCutscene = true;
		}

		public override void OnCutsceneSequenceEnd()
		{
			base.OnCutsceneSequenceEnd();
			CollaborativeSidebarMenu collaborativeSidebarMenu = MetagameMap.HUD.FindMenu<CollaborativeSidebarMenu>();
			if (collaborativeSidebarMenu != null)
			{
				collaborativeSidebarMenu.OpenMenu();
				collaborativeSidebarMenu.PingButton();
			}
		}

		public override void OnSkip()
		{
			MetagameMap.App.UserProfile.HasSeenCollaborativeProjectCutscene = true;
			base.OnSkip();
		}
	}
}
