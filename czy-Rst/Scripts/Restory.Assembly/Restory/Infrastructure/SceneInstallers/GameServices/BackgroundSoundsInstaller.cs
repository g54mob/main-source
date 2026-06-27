using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class BackgroundSoundsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		private EventReference musicSoundEvent;

		[SerializeField]
		private EventReference radioSwitchSoundEvent;

		public override void InstallBindings()
		{
			base.Container.InstantiateAndQueueForInject(prefab);
			base.Container.BindInterfacesAndSelfTo<RadioMusicSwitcher>().FromNew().AsSingle()
				.WithArguments(radioSwitchSoundEvent);
			base.Container.BindInterfacesAndSelfTo<RadioMusicTracksSwitcher>().FromNew().AsSingle()
				.WithArguments(musicSoundEvent);
		}
	}
}
