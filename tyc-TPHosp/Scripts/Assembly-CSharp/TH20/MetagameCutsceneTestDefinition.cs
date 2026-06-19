namespace TH20
{
	public class MetagameCutsceneTestDefinition : MetagameCutsceneDefinition
	{
		public override MetagameCutsceneInstance CreateCutsceneInstance(MetagameMap map)
		{
			return new MetagameCutsceneTest(map, this);
		}
	}
}
