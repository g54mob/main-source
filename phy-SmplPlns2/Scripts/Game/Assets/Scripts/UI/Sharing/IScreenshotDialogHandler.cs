using UnityEngine;

namespace Assets.Scripts.UI.Sharing
{
	public interface IScreenshotDialogHandler
	{
		Camera SceneCamera { get; }

		void OnScreenshotDialogActivated(bool activated);

		void SetSceneUIVisibility(bool visible);

		void ShowMessage(string message, float time);
	}
}
