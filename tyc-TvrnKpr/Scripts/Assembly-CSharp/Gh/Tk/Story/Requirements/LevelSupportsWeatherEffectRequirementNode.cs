namespace Gh.Tk.Story.Requirements
{
	public class LevelSupportsWeatherEffectRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllWeatherEffects")]
		public string effect;

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
