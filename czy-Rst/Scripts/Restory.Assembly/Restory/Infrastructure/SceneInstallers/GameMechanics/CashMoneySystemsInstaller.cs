using Restory.Data.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class CashMoneySystemsInstaller : MonoInstaller
	{
		[SerializeField]
		private InteractiveObjectInfo cashMoneyItemInfo;

		[SerializeField]
		private CashMoneyService cashMoneyServicePrefab;

		[SerializeField]
		private CashMoneyTestingTool testingToolPrefab;

		public override void InstallBindings()
		{
			InstallCashMoneyService();
			InstallTestingTool();
			base.Container.Bind<InteractiveObjectInfo>().FromInstance(cashMoneyItemInfo).AsSingle()
				.WhenInjectedInto<CashMoneyObjectFactory>();
			base.Container.BindInterfacesAndSelfTo<CashMoneyObjectFactory>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<CashMoneyObjectRegistry>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<TransferCashMoneyFromCashRegisterService>().FromNew().AsSingle();
		}

		private void InstallCashMoneyService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(cashMoneyServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<CashMoneyService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallTestingTool()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(testingToolPrefab.gameObject);
			base.Container.Bind<CashMoneyTestingTool>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
