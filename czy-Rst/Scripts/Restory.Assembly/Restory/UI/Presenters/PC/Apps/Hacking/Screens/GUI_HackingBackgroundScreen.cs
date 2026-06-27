using UnityEngine;
using UnityEngine.Video;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Screens
{
	public class GUI_HackingBackgroundScreen : MonoBehaviour
	{
		[SerializeField]
		private VideoPlayer videoPlayer;

		private bool activated;

		[SerializeField]
		[Tooltip("While player contains draft or unappreciated video clip, keep it blocked.")]
		private bool videoPlayerBlocked;

		public void Activate()
		{
			if (!videoPlayerBlocked && !activated)
			{
				activated = true;
				videoPlayer.gameObject.SetActive(value: true);
				videoPlayer.Play();
			}
		}

		private void OnDisable()
		{
			if (!videoPlayerBlocked)
			{
				videoPlayer.Stop();
				ClearVideoTargetTexture();
				videoPlayer.gameObject.SetActive(value: false);
				activated = false;
			}
		}

		private void ClearVideoTargetTexture()
		{
			RenderTexture targetTexture = videoPlayer.targetTexture;
			if ((bool)targetTexture)
			{
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = targetTexture;
				GL.Clear(clearDepth: true, clearColor: true, Color.clear);
				RenderTexture.active = active;
			}
		}
	}
}
