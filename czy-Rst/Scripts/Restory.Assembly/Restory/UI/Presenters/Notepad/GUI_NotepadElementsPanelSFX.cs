using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.Notepad
{
	public sealed class GUI_NotepadElementsPanelSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_NotepadElementsPanel notepadElementsPanel;

		[SerializeField]
		private EventReference itemSelectedSound;

		private IAudioPlayerService audioPlayer;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayer)
		{
			this.audioPlayer = audioPlayer;
		}

		private void OnEnable()
		{
			notepadElementsPanel.OnElementSelected += ResolveElementSelected;
		}

		private void OnDisable()
		{
			if (notepadElementsPanel.MonoShellExists())
			{
				notepadElementsPanel.OnElementSelected -= ResolveElementSelected;
			}
		}

		private void ResolveElementSelected(GUI_NotepadElementItem selectedItem)
		{
			if (selectedItem.ElementData == null || selectedItem.ElementData.IsInspected)
			{
				audioPlayer.PlaySoundEventOneShot(itemSelectedSound);
			}
		}
	}
}
