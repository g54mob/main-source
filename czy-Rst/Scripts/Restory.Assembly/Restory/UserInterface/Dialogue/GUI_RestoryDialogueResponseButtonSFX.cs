using FMODUnity;
using Restory.Audio;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.Dialogue
{
	public class GUI_RestoryDialogueResponseButtonSFX : MonoBehaviour
	{
		[SerializeField]
		private GUI_RestoryDialogueResponseButton responseButton;

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
			responseButton.OnClicked += ResolveContinueConversationTriggered;
		}

		private void OnDisable()
		{
			if (responseButton.MonoShellExists())
			{
				responseButton.OnClicked -= ResolveContinueConversationTriggered;
			}
		}

		private void ResolveContinueConversationTriggered()
		{
			audioPlayer.PlaySoundEventOneShot(clickSound);
		}
	}
}
