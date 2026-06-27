using Restory.Data.NPCs;
using Restory.Gameplay;
using Restory.Gameplay.Competitions;
using Restory.Gameplay.Decors;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Dialogue;
using Restory.Gameplay.Dialogue.LuaWrappers;
using Restory.Gameplay.EmailSystems;
using Restory.Gameplay.Internet;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.Quests;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.Shops.Elements;
using Restory.Gameplay.Shops.HomeDepot;
using Restory.Gameplay.ToDoList;
using Restory.Gameplay.Visits;
using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkshopRatings;
using Restory.Scripts.Restory.Data.Dialogue;
using Restory.Scripts.Restory.UI.LuaWrappers;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DialogueSystemNecessitiesInstaller : MonoInstaller
	{
		[SerializeField]
		private DialogueSystemTester prefab;

		[SerializeField]
		private DialogueAdditionalImagesSettings dialogueAdditionalImagesSettings;

		[SerializeField]
		private NpcEmotionInfo defaultEmotion;

		public override void InstallBindings()
		{
			InstallDialogueAdditionalImagesProvider();
			InstallLuaWrappers();
			InstallDialogueSystemInitializer();
			InstallDialogueEmotionsSystems();
			InstallDialogueSystemTestingTools();
		}

		private void InstallDialogueAdditionalImagesProvider()
		{
			base.Container.Bind<DialogueAdditionalImagesSettingsProvidingService>().FromNew().AsSingle()
				.WithArguments(dialogueAdditionalImagesSettings);
		}

		private void InstallLuaWrappers()
		{
			base.Container.BindInterfacesTo<WalletLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<MoneyCashLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<VisitsLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<WorkOrdersLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<DeviceServiceLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<DialogueAdditionalImagesLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<DialogueNpcTexturesLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<GuiFromDialogueControllingLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<InternetConnectionLuaWrapper>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<QuestItemsLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<ToDoListLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<RegularPaymentsLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<DecorLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<ElementsShopServiceLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<HomeDepotShopServiceLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<EmailServiceLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<WorkshopRatingsLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<GameVersionLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<CompetitionsLuaWrappers>().FromNew().AsSingle();
			base.Container.BindInterfacesTo<LightLuaWrappers>().FromNew().AsSingle();
		}

		private void InstallDialogueSystemInitializer()
		{
			base.Container.BindInterfacesTo<DialogueSystemInitializer>().FromNew().AsSingle();
		}

		private void InstallDialogueEmotionsSystems()
		{
			base.Container.BindInterfacesTo<DialogueNpcEmotionsPlayerService>().FromNew().AsSingle()
				.WithArguments(defaultEmotion);
		}

		private void InstallDialogueSystemTestingTools()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.Bind<DialogueSystemTester>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
