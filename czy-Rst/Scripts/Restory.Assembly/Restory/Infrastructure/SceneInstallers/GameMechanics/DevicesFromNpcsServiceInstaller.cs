using Restory.Gameplay.Storages;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DevicesFromNpcsServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private DevicesFromNpcsService prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.Bind<DevicesFromNpcsService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
