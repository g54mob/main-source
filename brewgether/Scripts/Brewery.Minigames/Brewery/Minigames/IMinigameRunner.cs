using System;

namespace Brewery.Minigames
{
	public interface IMinigameRunner
	{
		bool IsRunning { get; }

		MinigameInputMode InputMode { get; }

		float ElapsedTime { get; }

		float RoundDuration { get; }

		int CurrentScore { get; }

		int CurrentCombo { get; }

		int MaxCombo { get; }

		int EventSuccesses { get; }

		int ComboMultiplier { get; }

		int CurrentBPM { get; }

		event Action<MinigameSubmission> OnRoundComplete;

		event Action<int, int> OnScoreChanged;

		event Action<int, int> OnComboChanged;

		event Action<string> OnEventTriggered;

		void Start(int seed, bool overclock, MinigameConfig config, int stepIndex);

		MinigameSubmission Stop();

		void ProcessInput(float inputTimeSeconds);

		void ProcessInputRelease(float inputTimeSeconds);

		void Tick(float deltaTime);
	}
}
