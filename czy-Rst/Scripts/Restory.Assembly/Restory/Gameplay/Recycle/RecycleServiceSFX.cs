using System;
using Restory.Audio;
using Restory.Data.Audio.SoundBanks;
using Restory.Gameplay.Equipment;
using Zenject;

namespace Restory.Gameplay.Recycle
{
	public class RecycleServiceSFX : IInitializable, IDisposable
	{
		private RecycleService recycleService;

		private TrashCan trashCan;

		private IAudioPlayerService audioPlayer;

		private RecycleServiceSfxSoundsDatabase soundsDatabase;

		[Inject]
		private void Construct(RecycleService recycleService, TrashCan trashCan, IAudioPlayerService audioPlayer, RecycleServiceSfxSoundsDatabase soundsDatabase)
		{
			this.soundsDatabase = soundsDatabase;
			this.audioPlayer = audioPlayer;
			this.trashCan = trashCan;
			this.recycleService = recycleService;
		}

		public void Initialize()
		{
			recycleService.OnRecycled += ResolveObjectRecycled;
		}

		public void Dispose()
		{
			if (recycleService != null)
			{
				recycleService.OnRecycled -= ResolveObjectRecycled;
			}
		}

		private void ResolveObjectRecycled(RecycleService recycleService)
		{
			audioPlayer.PlaySoundEventOneShot(soundsDatabase.ObjectRecycledSound, trashCan.gameObject);
		}
	}
}
