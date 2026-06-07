using Gh.Tk.Story.Structure;

namespace Gh.Tk.UI.Dialogs
{
	public class ScenarioSettings
	{
		public bool isFreeplay;

		public string levelId;

		public string scenarioName;

		public string scenarioId;

		public bool isCheatsEnabled;

		private ScenarioStoryStartNode _startNode;

		public float GetMaxStarRating()
		{
			return 0f;
		}

		public ScenarioPreset GetScenarioPreset()
		{
			return null;
		}
	}
}
