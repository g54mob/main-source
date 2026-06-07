using UnityEngine;

namespace PajamaLlama.Fltsm.UI
{
	public class ScenarioSelectionPage : GameSetupPage
	{
		[SerializeField]
		private ScenarioToggle[] _scenarioToggles;

		public override bool Activate()
		{
			return base.enabled;
		}

		public override GameSetup Apply(GameSetup gameSetup)
		{
			ScenarioToggle[] scenarioToggles = _scenarioToggles;
			foreach (ScenarioToggle scenarioToggle in scenarioToggles)
			{
				if (scenarioToggle.isOn)
				{
					gameSetup.TileProperties = scenarioToggle.TileProperties;
					gameSetup.IsTutorial = scenarioToggle.IsTutorial;
					break;
				}
			}
			return gameSetup;
		}
	}
}
