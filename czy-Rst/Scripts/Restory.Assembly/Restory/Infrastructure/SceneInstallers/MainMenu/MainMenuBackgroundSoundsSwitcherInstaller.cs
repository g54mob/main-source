using FMODUnity;
using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.MainMenu
{
	public class MainMenuBackgroundSoundsSwitcherInstaller : MonoInstaller
	{
		[SerializeField]
		private EventReference music;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesTo<MainMenuBackgroundSoundsSwitcher>().FromNew().AsSingle()
				.WithArguments(music);
		}
	}
}
