using UnityEngine;

namespace TH20
{
	public class PickUpItemMenu : InWorldMenuObject
	{
		[SerializeField]
		private ProgressBar _progressBar;

		public new void Setup(ICursorSelectable objectSelected, Level level)
		{
			base.Setup(objectSelected, level);
		}

		public void SetProgress(float progress)
		{
			_progressBar.Progress = progress;
		}

		protected override Vector3 GetMenuPosition()
		{
			return base.Level.CursorManager.WorldPosition + Vector3.up * _menuYOffset;
		}
	}
}
