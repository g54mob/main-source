using Restory.Audio;
using Restory.Data.Audio.SoundBanks;
using UnityEngine;
using Zenject;

namespace Restory.UI.SFX
{
	public class UiDemoSoundPlayer : MonoBehaviour
	{
		[SerializeField]
		private UiSoundBank uiSoundBank;

		private IAudioPlayerService audioPlayerService;

		[Inject]
		private void Construct(IAudioPlayerService audioPlayerService)
		{
			this.audioPlayerService = audioPlayerService;
		}

		public void PlayClickSound()
		{
			audioPlayerService.PlaySoundEventOneShot(uiSoundBank.ClickSound);
		}
	}
}
