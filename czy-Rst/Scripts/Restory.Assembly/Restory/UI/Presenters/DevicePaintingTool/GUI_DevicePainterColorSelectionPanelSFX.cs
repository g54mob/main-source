using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public sealed class GUI_DevicePainterColorSelectionPanelSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_DevicePainterColorSelectionPanel colorSelectionPanel;

		[SerializeField]
		private EventReference colorSelectedSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			colorSelectionPanel.OnColorSelectionChangeRequested += ResolveColorClicked;
		}

		private void OnDisable()
		{
			if ((bool)colorSelectionPanel)
			{
				colorSelectionPanel.OnColorSelectionChangeRequested -= ResolveColorClicked;
			}
		}

		private void ResolveColorClicked(int colorIndex)
		{
			audioPlayer.PlaySoundEventOneShot(colorSelectedSound);
		}
	}
}
