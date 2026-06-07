namespace UIScripts
{
	public class NewOptionsSelectPanel : UIPanel
	{
		public ScenarioSelectorPanel scenarioPanel;

		public BibiteTemplateSelectorPanel selector;

		public void NewSimulation()
		{
			scenarioPanel.OpenPanel();
			scenarioPanel.SwitchList(scenario: true);
			ClosePanel();
		}

		public void NewChallenge()
		{
			scenarioPanel.OpenPanel();
			scenarioPanel.SwitchList(scenario: false);
			ClosePanel();
		}

		public void CreateNewBibite()
		{
			selector.OpenForBibiteEditor();
			ClosePanel();
		}
	}
}
