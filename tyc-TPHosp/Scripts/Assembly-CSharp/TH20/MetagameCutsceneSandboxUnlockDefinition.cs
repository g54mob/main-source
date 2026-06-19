namespace TH20
{
	public class MetagameCutsceneSandboxUnlockDefinition : MetagameCutsceneDefinition
	{
		public override MetagameCutsceneInstance CreateCutsceneInstance(MetagameMap map)
		{
			return new MetagameCutsceneSandboxUnlock(map, this);
		}
	}
}
