using Restory.Gameplay.Licenses;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class LicensesServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private LicensesService licensesServicePrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(licensesServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<LicensesService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
