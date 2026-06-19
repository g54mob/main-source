namespace TH20
{
	public class MetagameCutsceneSandboxUnlock : MetagameCutsceneInstance
	{
		public MetagameCutsceneSandboxUnlock(MetagameMap map, MetagameCutsceneSandboxUnlockDefinition definition)
			: base(map, definition)
		{
		}

		public override void OnCutsceneStart()
		{
			MetagameMap.App.UserProfile.HasSeenSandboxCutscene = true;
		}

		public override void OnSkip()
		{
			MetagameMap.App.UserProfile.HasSeenSandboxCutscene = true;
			base.OnSkip();
		}
	}
}
