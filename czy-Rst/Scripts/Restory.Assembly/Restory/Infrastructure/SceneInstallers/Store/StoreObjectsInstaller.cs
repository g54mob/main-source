using System;
using Restory.Gameplay;
using Restory.Gameplay.Dialogue;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.Levers;
using Restory.Gameplay.NPCs;
using Restory.Scripts.Restory.Gameplay.Storages;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.Store
{
	public class StoreObjectsInstaller : MonoInstaller
	{
		[SerializeField]
		private StorageSpaces storageSpaces;

		[SerializeField]
		private WindowShuttersStoreInteractiveItem windowShuttersObject;

		[SerializeField]
		private VerticalLever verticalLeverObject;

		[SerializeField]
		private BicycleInteractiveStoreItem bicycle;

		[SerializeField]
		private NpcMovementAnimator npcMovementAnimator;

		[SerializeField]
		private NpcTextureSwitcher npcTextureSwitcher;

		[SerializeField]
		private DialogueNpcSFX npcSoundSource;

		[SerializeField]
		private LightTimeView[] ambientLightTimeViews = Array.Empty<LightTimeView>();

		public override void InstallBindings()
		{
			InstallStorageSpaces();
			WindowShutters();
			InstallBicycle();
			InstallNpcNecessities();
			InstallAmbientLightTimeView();
		}

		private void WindowShutters()
		{
			base.Container.Bind<WindowShuttersStoreInteractiveItem>().FromComponentOn(windowShuttersObject.gameObject).AsSingle();
			base.Container.Bind<VerticalLever>().FromComponentOn(verticalLeverObject.gameObject).AsSingle();
		}

		private void InstallStorageSpaces()
		{
			base.Container.BindInterfacesAndSelfTo<StorageSpaces>().FromComponentOn(storageSpaces.gameObject).AsSingle();
		}

		private void InstallBicycle()
		{
			base.Container.Bind<BicycleInteractiveStoreItem>().FromComponentOn(bicycle.gameObject).AsSingle();
		}

		private void InstallNpcNecessities()
		{
			base.Container.Bind<NpcMovementAnimator>().FromComponentOn(npcMovementAnimator.gameObject).AsSingle();
			base.Container.Bind<NpcTextureSwitcher>().FromComponentOn(npcTextureSwitcher.gameObject).AsSingle();
			base.Container.Bind<DialogueNpcSFX>().FromComponentOn(npcSoundSource.gameObject).AsSingle();
		}

		private void InstallAmbientLightTimeView()
		{
			LightTimeView[] array = ambientLightTimeViews;
			foreach (LightTimeView instance in array)
			{
				base.Container.Bind<LightTimeView>().WithId("AmbientLightTimeView").FromInstance(instance)
					.AsCached();
			}
		}
	}
}
