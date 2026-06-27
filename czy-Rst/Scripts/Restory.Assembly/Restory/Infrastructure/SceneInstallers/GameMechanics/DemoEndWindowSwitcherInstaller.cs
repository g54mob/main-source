using Restory.Gameplay.DemoEnd;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DemoEndWindowSwitcherInstaller : MonoInstaller
	{
		[SerializeField]
		private DemoEndWindowSwitcher prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.Bind<DemoEndWindowSwitcher>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
