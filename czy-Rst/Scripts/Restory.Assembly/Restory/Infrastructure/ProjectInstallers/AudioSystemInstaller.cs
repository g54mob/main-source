using Restory.Audio;
using Restory.UI.SFX;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class AudioSystemInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject audioSystemPrefab;

		public override void InstallBindings()
		{
			InstallAudioService();
		}

		private void InstallAudioService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(audioSystemPrefab);
			base.Container.Bind<IAudioPlayerService>().To<FmodAudioPlayerService>().FromComponentOn(gameObject)
				.AsSingle();
			base.Container.Bind<BackgroundLoopingSoundsService>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<MusicSwitcherService>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<SoundLoopEmittersService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<AudioSceneVolumeSwitcher>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<AudioSceneVolumeSwitchRequesterFromFadeScreens>().FromNew().AsSingle();
			base.Container.Bind<UiDemoSoundPlayer>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<CollidingObjectsSfxService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
