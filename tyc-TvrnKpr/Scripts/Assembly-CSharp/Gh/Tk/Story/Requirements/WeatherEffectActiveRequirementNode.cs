using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class WeatherEffectActiveRequirementNode : RequirementNode
	{
		[Tooltip("If set to true, this node will check if no weather effect is active rather than test against the effect")]
		public bool checkThatNoEffectIsActive;

		[DropDownChoice(typeof(StoryHelper), "GetAllWeatherEffects")]
		public string effect;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
