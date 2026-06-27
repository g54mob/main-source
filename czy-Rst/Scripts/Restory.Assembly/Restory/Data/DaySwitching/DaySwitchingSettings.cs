using Restory.Data.Locations;
using UnityEngine;

namespace Restory.Data.DaySwitching
{
	[CreateAssetMenu(fileName = "DaySwitchingSettings", menuName = "Restory/DaySwitchingSettings")]
	public class DaySwitchingSettings : ScriptableObject
	{
		private static class Style
		{
			public const string FadeInName = "Fade In";

			public const string MinStayName = "Min Stay";

			public const string FadeOutName = "Fade Out";
		}

		[SerializeField]
		private GameScenesPresetTransition transitionToEndOfDayScenes;

		[SerializeField]
		private float delayBeforeShowingResultsWindow = 1f;

		[SerializeField]
		private GameScenesPresetTransition transitionToNextDayScenes;

		public GameScenesPresetTransition TransitionToEndOfDayScenes => transitionToEndOfDayScenes;

		public GameScenesPresetTransition TransitionToNextDayScenes => transitionToNextDayScenes;

		public float DelayBeforeShowingResultsWindow => delayBeforeShowingResultsWindow;
	}
}
