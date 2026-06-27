using System;
using Restory.Data.NewGame;
using Restory.Data.PC;
using Restory.Data.RegularPayments;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.ToDoList;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;
using Restory.Gameplay.PC;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.SaveLoad.Services;
using Restory.Gameplay.SpawnPoints;
using Restory.Gameplay.Statistics;
using Restory.Gameplay.Tips;
using Restory.Gameplay.ToDoList;
using Restory.Gameplay.Tutorials;
using Restory.Gameplay.Visits;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Gameplay.WorkshopStatus;
using Restory.StorageSystem.StorageElements;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.NewGame
{
	public class NewGameInitializer : IInitializable, IDisposable
	{
		private readonly IDService idService;

		private readonly Wallet wallet;

		private readonly TipBox tipBox;

		private readonly IInventory inventory;

		private readonly IGameplaySaveLoadService saveLoadService;

		private readonly NewGameSettings newGameSettings;

		private readonly PersonalBoxService personalBoxService;

		private readonly InteractiveObjectService interactiveObjectService;

		private readonly EquipmentService equipmentService;

		private readonly WindowShuttersStoreInteractiveItem windowShutters;

		private readonly AvailableToolsTrackingService availableToolsTracker;

		private readonly CleaningToolSelectionService cleaningToolSelector;

		private readonly ToDoListService toDoListService;

		private readonly TutorialService tutorialService;

		private readonly PcAppManager pcAppManager;

		private readonly RegularPaymentsService regularPaymentsService;

		private readonly WorkshopStatusNotificationService workshopStatusNotificationService;

		private readonly GameStatisticsService gameStatisticsService;

		private readonly CurrentDayVisitsQueueService visitsService;

		private readonly AvailablePaintingPalettesTrackingService availablePaintingPalettesTracker;

		[Inject]
		public NewGameInitializer(IDService idService, Wallet wallet, TipBox tipBox, IInventory inventory, IGameplaySaveLoadService saveLoadService, NewGameSettings newGameSettings, PersonalBoxService personalBoxService, InteractiveObjectService interactiveObjectService, EquipmentService equipmentService, WindowShuttersStoreInteractiveItem windowShutters, AvailableToolsTrackingService availableToolsTracker, CleaningToolSelectionService cleaningToolSelector, ToDoListService toDoListService, TutorialService tutorialService, PcAppManager pcAppManager, RegularPaymentsService regularPaymentsService, AvailablePaintingPalettesTrackingService availablePaintingPalettesTracker, WorkshopStatusNotificationService workshopStatusNotificationService, CurrentDayVisitsQueueService visitsService, GameStatisticsService gameStatisticsService)
		{
			this.idService = idService;
			this.wallet = wallet;
			this.tipBox = tipBox;
			this.inventory = inventory;
			this.saveLoadService = saveLoadService;
			this.newGameSettings = newGameSettings;
			this.personalBoxService = personalBoxService;
			this.interactiveObjectService = interactiveObjectService;
			this.equipmentService = equipmentService;
			this.windowShutters = windowShutters;
			this.cleaningToolSelector = cleaningToolSelector;
			this.availableToolsTracker = availableToolsTracker;
			this.toDoListService = toDoListService;
			this.tutorialService = tutorialService;
			this.pcAppManager = pcAppManager;
			this.regularPaymentsService = regularPaymentsService;
			this.availablePaintingPalettesTracker = availablePaintingPalettesTracker;
			this.workshopStatusNotificationService = workshopStatusNotificationService;
			this.visitsService = visitsService;
			this.gameStatisticsService = gameStatisticsService;
		}

		public void Initialize()
		{
			saveLoadService.OnSaveNotFound += InitNewGame;
			personalBoxService.OnPersonalBoxAppearanceCompleted += ResolveOnPersonalBoxAppearanceCompleted;
		}

		public void Dispose()
		{
			saveLoadService.OnSaveNotFound -= InitNewGame;
			personalBoxService.OnPersonalBoxAppearanceCompleted -= ResolveOnPersonalBoxAppearanceCompleted;
		}

		private void InitNewGame()
		{
			InitWallet();
			InitTipBox();
			InitInventory();
			InitSpawnPoints();
			InitEquipment();
			InitWindowShutters();
			InitCleaningTools();
			InitTutorials();
			InitPcApps();
			InitGameStatisticsService();
			SetupInitialPaintingPalettes();
			SetupInitialRegularPayments();
			EnqueueFirstNpcVisit();
		}

		private void InitWallet()
		{
			wallet.Init(newGameSettings.InitialMoneyAmount);
		}

		private void InitTipBox()
		{
			tipBox.Init(newGameSettings.InitialTipsAmount);
		}

		private void InitInventory()
		{
			foreach (ElementData item in newGameSettings.InitialElementsSupply)
			{
				inventory.StorageElements.AddItem(new StorageItemElement(item));
			}
		}

		private void InitSpawnPoints()
		{
			InteractiveObjectSpawnPoint[] array = UnityEngine.Object.FindObjectsByType<InteractiveObjectSpawnPoint>(FindObjectsSortMode.None);
			foreach (InteractiveObjectSpawnPoint interactiveObjectSpawnPoint in array)
			{
				if (interactiveObjectSpawnPoint.InteractiveObjectInfo.Prefab.TryGetComponent<InteractiveObjectBoxContainer>(out var _))
				{
					SpawnPersonalBox(interactiveObjectSpawnPoint);
				}
				else
				{
					SpawnInteractiveObject(interactiveObjectSpawnPoint);
				}
			}
		}

		private void SpawnPersonalBox(InteractiveObjectSpawnPoint spawnPoint)
		{
			InteractiveObjectData boxData = new InteractiveObjectData
			{
				InteractiveObjectInfo = spawnPoint.InteractiveObjectInfo,
				InteractiveObjectTransform = new SerializableTransform(spawnPoint.PreviewContainer),
				State = InteractiveObjectState.Stored,
				UniqueId = idService.GenerateNew(),
				HasChanged = false
			};
			personalBoxService.CreatePersonalBox(newGameSettings.InitialPersonalObjects, boxData);
			personalBoxService.ActivatePersonalBoxAppearance();
		}

		private void SpawnInteractiveObject(InteractiveObjectSpawnPoint spawnPoint)
		{
			interactiveObjectService.CreateNewInteractiveObject(spawnPoint.InteractiveObjectInfo, spawnPoint.transform);
		}

		private void InitEquipment()
		{
			equipmentService.SetInitialState();
		}

		private void InitWindowShutters()
		{
			windowShutters.SetInitialState(shouldBeOpen: false);
		}

		private void InitCleaningTools()
		{
			foreach (NewGameSettings.ToolInitializationData initialTool in newGameSettings.InitialTools)
			{
				if ((bool)initialTool.Tool)
				{
					availableToolsTracker.AddTool(initialTool.Tool, initialTool.Count);
					if (initialTool.Tool.IsConsumable)
					{
						availableToolsTracker.SetToolCurrentUsesLeft(initialTool.Tool, initialTool.UsesLeft);
					}
				}
			}
			cleaningToolSelector.TryToSelectDefaultTool();
		}

		private void InitToDoListService()
		{
			foreach (ToDoItem initToDoListItem in newGameSettings.InitToDoListItems)
			{
				toDoListService.AddItem(initToDoListItem);
			}
			toDoListService.IsActive = true;
		}

		private void InitTutorials()
		{
			tutorialService.AddTutorials(newGameSettings.InitialTutorials);
		}

		private void InitPcApps()
		{
			foreach (PcAppInfo initialPcApp in newGameSettings.InitialPcApps)
			{
				pcAppManager.InstallPcApp(initialPcApp);
			}
		}

		private void InitGameStatisticsService()
		{
			gameStatisticsService.ClearDataAtStartOfNewDay();
		}

		private void SetupInitialRegularPayments()
		{
			foreach (RegularPaymentInfo initialRegularPayment in newGameSettings.InitialRegularPayments)
			{
				regularPaymentsService.AddNewRegularPayment(initialRegularPayment);
			}
		}

		private void SetupInitialPaintingPalettes()
		{
			availablePaintingPalettesTracker.SetUpInitialPalettes(newGameSettings.InitialPaintingPalettes);
		}

		private void EnqueueFirstNpcVisit()
		{
			visitsService.AddInitialNpcVisit(newGameSettings.FirstVisitor);
		}

		private void ResolveOnPersonalBoxAppearanceCompleted(PersonalBoxService service)
		{
			InitToDoListService();
			workshopStatusNotificationService.ShowAll();
		}
	}
}
