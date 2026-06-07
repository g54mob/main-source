using UnityEngine.UIElements;

namespace Brewery.UI.Shared
{
	public class StationProgressController
	{
		private VisualElement progressBar;

		private VisualElement progressFill;

		private Label percentLabel;

		private float maxProgressSeen;

		private readonly int totalSteps;

		private readonly float capBeforeAction;

		public float CurrentProgress { get; private set; }

		public StationProgressController(int totalSteps, float capBeforeAction = 1f)
		{
		}

		public void CacheReferences(VisualElement panelRoot, string progressBarName = "main-progress-bar", string fillName = "progress-fill", string percentName = "progress-percent")
		{
		}

		public void UpdateProgress(int completedSteps, float currentStepProgress, bool isProcessComplete = false, bool preventRegression = true)
		{
		}

		public void SetProgress(float progress, bool preventRegression = true)
		{
		}

		public void Reset()
		{
		}

		public void ResetTracking()
		{
		}

		public void CheckResetTracking(bool isIdle, bool hasOutput, int completedSteps)
		{
		}

		private void ApplyProgress(float progress)
		{
		}
	}
}
