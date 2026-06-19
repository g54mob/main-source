namespace TH20
{
	public class MetagameCutsceneGameIntroDefinition : MetagameCutsceneDefinition
	{
		public override MetagameCutsceneInstance CreateCutsceneInstance(MetagameMap map)
		{
			return new MetagameCutsceneGameIntro(map, this);
		}
	}
}
