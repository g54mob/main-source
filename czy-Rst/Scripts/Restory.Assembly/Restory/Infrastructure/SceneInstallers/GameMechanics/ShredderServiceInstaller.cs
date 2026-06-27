using Restory.Gameplay.Shredders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class ShredderServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject shredderServicePrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(shredderServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<ShredderService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<TrashCanAndShredderSwitcherService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
