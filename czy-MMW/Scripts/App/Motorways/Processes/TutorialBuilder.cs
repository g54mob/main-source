using System;
using System.Collections.Generic;

namespace Motorways.Processes
{
	public class TutorialBuilder
	{
		private readonly List<TutorialProgressionProcess.TutorialStep> _steps = new List<TutorialProgressionProcess.TutorialStep>();

		private readonly TutorialProgressionProcess _progressionProcess;

		public IReadOnlyList<TutorialProgressionProcess.TutorialStep> Steps => _steps;

		public TutorialBuilder(TutorialProgressionProcess progressionProcess)
		{
			_progressionProcess = progressionProcess;
		}

		public void StartStage(string name, string shortName)
		{
			_progressionProcess.SetCurrentStage(name, shortName);
			AddStep(new TutorialProgressionProcess.TutorialStep("Start Stage: " + name).ClockTicksWhile(() => false).WhenStepStarts((Action)delegate
			{
				_progressionProcess.SetCurrentStage(name, shortName);
			}).StepOverWhen(() => true));
		}

		public void AddStep(TutorialProgressionProcess.TutorialStep tutorialStep)
		{
			tutorialStep.StageShortName = _progressionProcess.CurrentStageShortName;
			_steps.Add(tutorialStep);
		}

		public void AddMarker(TutorialProgressionProcess.TutorialMarker marker)
		{
			AddStep(new TutorialProgressionProcess.TutorialStep("Marker : " + marker).WhenStepStarts((Action)delegate
			{
				_progressionProcess.SetLastReachedMarker(marker);
			}).StepOverWhen(() => true));
		}

		public void AddRealtimeDelay(float delay, bool clockTicks)
		{
			AddStep(new TutorialProgressionProcess.TutorialStep(delay + " second delay").WhenStepStarts((Action)delegate
			{
				_progressionProcess.StartRealtimeTimer(delay);
			}).StepOverWhen(_progressionProcess.RealtimeTimerFinished).ClockTicksWhile(() => clockTicks));
		}
	}
}
