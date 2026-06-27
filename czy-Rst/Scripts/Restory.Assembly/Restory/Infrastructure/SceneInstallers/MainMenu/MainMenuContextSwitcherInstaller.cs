using Restory.Gameplay.PlayerInput;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.MainMenu
{
	public class MainMenuContextSwitcherInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject mainMenuContextSwitcherPrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(mainMenuContextSwitcherPrefab);
			base.Container.BindInterfacesAndSelfTo<MainMenuRewiredContextSwitcher>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
