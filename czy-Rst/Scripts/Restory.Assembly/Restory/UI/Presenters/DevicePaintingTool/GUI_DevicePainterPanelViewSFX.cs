using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public sealed class GUI_DevicePainterPanelViewSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_DevicePainterPanelView devicePainterPanelView;

		[SerializeField]
		private EventReference clickSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			devicePainterPanelView.OnVisibilitySwitchRequested += ResolveButtonClicked;
			devicePainterPanelView.OnSwitchRequested += ResolveButtonClicked;
			devicePainterPanelView.OnPaintClearRequested += ResolveButtonClicked;
			devicePainterPanelView.OnUndoActionRequested += ResolveButtonClicked;
			devicePainterPanelView.OnRedoActionRequested += ResolveButtonClicked;
			devicePainterPanelView.OnExitRequested += ResolveButtonClicked;
		}

		private void OnDisable()
		{
			if (devicePainterPanelView.MonoShellExists())
			{
				devicePainterPanelView.OnVisibilitySwitchRequested += ResolveButtonClicked;
				devicePainterPanelView.OnSwitchRequested += ResolveButtonClicked;
				devicePainterPanelView.OnPaintClearRequested += ResolveButtonClicked;
				devicePainterPanelView.OnUndoActionRequested += ResolveButtonClicked;
				devicePainterPanelView.OnRedoActionRequested += ResolveButtonClicked;
				devicePainterPanelView.OnExitRequested += ResolveButtonClicked;
			}
		}

		private void ResolveButtonClicked()
		{
			audioPlayer.PlaySoundEventOneShot(clickSound);
		}
	}
}
