using System;
using ReinforcementLearning;
using ReinforcementLearning.Environment;

namespace DeepTraffic
{
	public interface IAgentWrapper
	{
		Random TrainRandom { get; set; }

		Random RenderRandom { get; set; }

		DeepTrafficAction GetAction(CellObjects[] state);

		void AddEpisode(Episode<CellObjects[], DeepTrafficAction> episode);

		DeepTrafficAction GetEvalAction(CellObjects[] state);

		DeepTrafficAction GetBestAction(CellObjects[] state);

		void Update();

		void UpdateEvalAgent();
	}
}
