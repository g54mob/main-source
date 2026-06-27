using Restory.Audio;
using Restory.Data.Audio.SoundBanks;

namespace Restory.UI.SFX
{
	public sealed class UiClickPresenterSFX
	{
		private IAudioPlayerService audioPlayerService;

		private UiSoundBank soundBank;

		public void Init(IAudioPlayerService audioPlayerService, UiSoundBank soundBank)
		{
			this.soundBank = soundBank;
			this.audioPlayerService = audioPlayerService;
		}

		public void Clear()
		{
			audioPlayerService = null;
			soundBank = null;
		}

		public void PlayClickSound()
		{
			audioPlayerService.PlaySoundEventOneShot(soundBank.ClickSound);
		}
	}
}
