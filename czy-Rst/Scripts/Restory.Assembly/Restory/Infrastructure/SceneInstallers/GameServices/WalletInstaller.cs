using Restory.Gameplay.Inventory;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class WalletInstaller : MonoInstaller
	{
		[SerializeField]
		private Wallet walletPrefab;

		public override void InstallBindings()
		{
			InstallWallet();
		}

		private void InstallWallet()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(walletPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<Wallet>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
