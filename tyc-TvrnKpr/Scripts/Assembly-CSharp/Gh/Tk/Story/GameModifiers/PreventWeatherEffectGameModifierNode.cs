namespace Gh.Tk.Story.GameModifiers
{
	public class PreventWeatherEffectGameModifierNode : TemporaryGameModifierNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllWeatherEffects")]
		public string effectType;

		public static bool IsWeatherEffectSuspended(string effect)
		{
			return false;
		}
	}
}
