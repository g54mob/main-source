using System;
using Restory.EventSystems;
using Restory.Gameplay.PlayerInput;
using Restory.Infrastructure.CommonServices;
using Rewired;
using RewiredConsts;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class PlayerInputInstaller : MonoInstaller
	{
		[SerializeField]
		[PlayerIdProperty(typeof(RewiredConsts.Player))]
		private int playerID;

		[SerializeField]
		private GameObject controlsManagerPrefab;

		[SerializeField]
		private GameObject activeSelectionServicePrefab;

		public override void InstallBindings()
		{
			InstallControlsManager();
			InstallRewired();
			InstallActiveSelectionService();
			base.Container.BindInterfacesAndSelfTo<DebugInputSwitcher>().AsTransient();
		}

		private void InstallActiveSelectionService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(activeSelectionServicePrefab);
			base.Container.BindInterfacesAndSelfTo<ActiveSelectionService>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallControlsManager()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(controlsManagerPrefab);
			base.Container.BindInterfacesAndSelfTo<ControlsManager>().FromComponentOn(gameObject).AsSingle();
		}

		private void InstallRewired()
		{
			base.Container.Bind<int>().WithId("PlayerInputId").FromInstance(playerID)
				.AsSingle();
			base.Container.Bind<IInitializable>().To<IPlayerInput>().FromResolve();
			base.Container.Bind<IDisposable>().To<IPlayerInput>().FromResolve();
			base.Container.Bind<IPlayerInput>().FromFactory<RewiredPlayerInput.PlayerFactory>().AsTransient();
			base.Container.Bind<IPlayerInput>().WithId("OperatorInputId").FromFactory<RewiredPlayerInput.OperatorFactory>()
				.AsTransient();
			base.Container.BindFactory<System.Action, int, InputSubscriber, InputSubscriber.Factory>().AsSingle();
		}
	}
}
