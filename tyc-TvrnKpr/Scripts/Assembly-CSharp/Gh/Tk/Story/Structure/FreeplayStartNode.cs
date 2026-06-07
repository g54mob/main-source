namespace Gh.Tk.Story.Structure
{
	public class FreeplayStartNode : StartNode
	{
		public GameLevel region;

		public string scenarioId;

		public string freeplayScenarioName;

		public ScenarioPreset presetData;

		public override bool CanTrigger()
		{
			return false;
		}

		protected override void GenerateI18nEntriesInternal(string context)
		{
		}
	}
}
