using System;
using Restory.Audio;
using Restory.Data.Audio.Soundbanks;
using Restory.Data.Devices.Quality;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.Effects
{
	public class VfxServiceSFX : IInitializable, IDisposable
	{
		private VfxService vfxService;

		private SfxForVfxEffectsDatabase soundsDatabase;

		private IAudioPlayerService audioPlayerService;

		[Inject]
		private void Construct(VfxService vfxService, SfxForVfxEffectsDatabase soundsDatabase, IAudioPlayerService audioPlayerService)
		{
			this.vfxService = vfxService;
			this.soundsDatabase = soundsDatabase;
			this.audioPlayerService = audioPlayerService;
		}

		public void Initialize()
		{
			vfxService.OnCheckDeviceEffectTriggered += ResolveCheckDeviceEffectTriggered;
		}

		public void Dispose()
		{
			if (vfxService.MonoShellExists())
			{
				vfxService.OnCheckDeviceEffectTriggered -= ResolveCheckDeviceEffectTriggered;
			}
		}

		private void ResolveCheckDeviceEffectTriggered(DeviceQualityBase deviceQuality)
		{
			if (deviceQuality is IdealDeviceQuality)
			{
				audioPlayerService.PlaySoundEventOneShot(soundsDatabase.PerfectDeviceCheckSound);
			}
		}
	}
}
