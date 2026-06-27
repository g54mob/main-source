using Restory.Data.SaveLoad;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public sealed class IDServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private IDService idServicePrefab;

		public override void InstallBindings()
		{
			InstallIDService();
		}

		private void InstallIDService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(idServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<IDService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
