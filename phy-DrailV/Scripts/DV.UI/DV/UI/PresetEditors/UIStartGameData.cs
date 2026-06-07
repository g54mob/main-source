using DV.Common;
using DV.Scenarios.Common;
using UnityEngine;

namespace DV.UI.PresetEditors
{
	public class UIStartGameData
	{
		public IGameSession session;

		public IDifficulty difficulty;

		public IScenario scenario;

		public bool skipTutorial;

		public UIStartGameData(IGameSession session, IDifficulty difficulty, IScenario scenario, bool skipTutorial)
		{
			if (session == null)
			{
				Debug.LogError("difficulty is null");
			}
			if (difficulty == null)
			{
				Debug.LogError("difficulty is null");
			}
			if (scenario == null)
			{
				Debug.LogError("scenario is null");
			}
			this.session = session;
			this.difficulty = difficulty;
			this.scenario = scenario;
			this.skipTutorial = skipTutorial;
		}
	}
}
