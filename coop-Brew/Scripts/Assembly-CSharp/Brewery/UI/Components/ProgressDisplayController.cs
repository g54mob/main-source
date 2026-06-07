using UnityEngine.UIElements;

namespace Brewery.UI.Components
{
	public sealed class ProgressDisplayController
	{
		private ProgressBar progressBar;

		private Label percentLabel;

		private Label remainingLabel;

		public void Initialize(VisualElement root, string progressBarId, string percentLabelId = null, string remainingLabelId = null)
		{
		}

		public void Update(float normalizedProgress, string remainingText = null)
		{
		}
	}
}
