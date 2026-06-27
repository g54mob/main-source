using System;
using System.Linq;
using Restory.Constants;
using Restory.Data.Equipment;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Effects;
using Restory.Gameplay.Equipment.CashRegisters;
using Restory.Gameplay.Equipment.Views;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.PC;
using Restory.Gameplay.PlayerInput;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.UI.Presenters.Notifications;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class EquipmentService : MonoBehaviour, IInitializable, ITickable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		private readonly RaycastHit[] raycastHits = new RaycastHit[2];

		private IPlayerInput playerInput;

		private CursorDetectorService cursorDetectorService;

		private DragObjectRegistrator dragObjectRegistrator;

		private InteractiveObjectRegistry interactiveObjectRegistry;

		private InteractiveObjectFactory interactiveObjectFactory;

		private CleanerActivator cleanerActivator;

		private NotebookActivator notebookActivator;

		private ToolActivator[] toolActivators;

		private CashRegisterActivator cashRegisterActivator;

		private CashRegister cashRegister;

		private CashMoneyService cashMoneyService;

		private PcAppManager pcAppManager;

		private PcDriveActivator pcDriveActivator;

		private AvailableToolsTrackingService toolsService;

		private VfxService vfxService;

		private GUI_NotificationCanvas notificationCanvas;

		private LayerMask equipmentMask;

		private PersonalObjectBase draggedPersonalObject;

		private EquipmentActivatorBase compatibleEquipmentActivator;

		public bool IsReadyToDisassemble => cleanerActivator.IsActivated;

		[Inject]
		private void Construct(IPlayerInput playerInput, CursorDetectorService cursorDetectorService, DragObjectRegistrator dragObjectRegistrator, InteractiveObjectRegistry interactiveObjectRegistry, InteractiveObjectFactory interactiveObjectFactory, CleanerActivator cleanerActivator, NotebookActivator notebookActivator, CashRegisterActivator cashRegisterActivator, CashRegister cashRegister, CashMoneyService cashMoneyService, PcAppManager pcAppManager, PcDriveActivator pcDriveActivator, AvailableToolsTrackingService toolsService, ToolActivator[] toolActivators, VfxService vfxService, GUI_NotificationCanvas notificationCanvas)
		{
			this.toolActivators = toolActivators;
			this.playerInput = playerInput;
			this.cursorDetectorService = cursorDetectorService;
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.interactiveObjectFactory = interactiveObjectFactory;
			this.cleanerActivator = cleanerActivator;
			this.notebookActivator = notebookActivator;
			this.cashRegisterActivator = cashRegisterActivator;
			this.cashRegister = cashRegister;
			this.cashMoneyService = cashMoneyService;
			this.pcAppManager = pcAppManager;
			this.pcDriveActivator = pcDriveActivator;
			this.toolsService = toolsService;
			this.vfxService = vfxService;
			this.notificationCanvas = notificationCanvas;
			equipmentMask = ProjectConstants.Layers.EquipmentMask;
		}

		public void Initialize()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveInteractiveObjectStopDrag;
			toolsService.OnToolAdded += ResolveToolAdded;
			toolsService.OnToolRemoved += ResolveToolRemoved;
		}

		public void Tick()
		{
			if ((bool)draggedPersonalObject && (bool)compatibleEquipmentActivator)
			{
				UpdatePersonalObjectDragging();
			}
		}

		public void Dispose()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveInteractiveObjectStopDrag;
			toolsService.OnToolAdded -= ResolveToolAdded;
			toolsService.OnToolRemoved -= ResolveToolRemoved;
		}

		public void SetInitialState()
		{
			notebookActivator.RestoreState(isActivated: false);
			cashRegisterActivator.RestoreState(isActivated: false);
			ToolActivator[] array = toolActivators;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RestoreState(isActivated: false);
			}
			UpdateInstrumentActivators();
		}

		public bool TryToApplyInteractiveObject(InteractiveObject interactiveObject)
		{
			if (!draggedPersonalObject || !compatibleEquipmentActivator)
			{
				return false;
			}
			if (draggedPersonalObject.transform != interactiveObject.transform)
			{
				Debug.LogError("draggedPersonalObject don't match interactiveObject");
				return false;
			}
			bool result = false;
			if (IsCompatibleEquipmentDetected())
			{
				if (!(compatibleEquipmentActivator is LeverActivator))
				{
					vfxService.PlayPlacementEffect(draggedPersonalObject.transform);
				}
				if (draggedPersonalObject is CashMoneyObject cashMoneyObject)
				{
					cashMoneyService.TransferMoneyToWallet(cashMoneyObject);
					cashRegister.ProcessAddingMoneyToRegister(cashMoneyObject.MoneyAmountHeld);
					notificationCanvas.ShowMoneyNotification(cashMoneyObject.MoneyAmountHeld, cashRegister.transform);
				}
				if (draggedPersonalObject is PersonalTool personalTool)
				{
					int amount = ((!(personalTool is PersonalConsumableTool personalConsumableTool)) ? 1 : personalConsumableTool.Amount);
					toolsService.AddTool(personalTool.ToolInfo, amount);
					DestroyPersonalObject(draggedPersonalObject);
				}
				if (draggedPersonalObject is PcAppObject pcAppObject)
				{
					pcAppManager.ActivatePcApp(pcAppObject.Info);
					DestroyPersonalObject(draggedPersonalObject);
				}
				else
				{
					DestroyPersonalObject(draggedPersonalObject);
				}
				ActivateEquipment(compatibleEquipmentActivator);
				result = true;
			}
			compatibleEquipmentActivator.ToggleIndicator(isActive: false);
			compatibleEquipmentActivator = null;
			return result;
		}

		private bool IsCompatibleEquipmentDetected()
		{
			if (!cursorDetectorService.GameDetector.TryToDetect(playerInput.GetMousePosition(), equipmentMask, raycastHits, out var hitCount))
			{
				return false;
			}
			for (int i = 0; i < hitCount; i++)
			{
				if (raycastHits[i].transform == compatibleEquipmentActivator.transform)
				{
					return true;
				}
			}
			return false;
		}

		private void UpdatePersonalObjectDragging()
		{
			if (compatibleEquipmentActivator is CashRegisterActivator)
			{
				if (cursorDetectorService.GameDetector.TryToDetect(playerInput.GetMousePosition(), equipmentMask, raycastHits, out var _) && raycastHits[0].transform == compatibleEquipmentActivator.transform)
				{
					cashRegister.SetCashDrawerState(CashDrawerState.Open, animate: true);
				}
				else
				{
					cashRegister.SetCashDrawerState(CashDrawerState.PartiallyOpen, animate: true);
				}
			}
		}

		private void ResolveInteractiveObjectStartDrag()
		{
			if ((bool)dragObjectRegistrator.DraggingObject && dragObjectRegistrator.DraggingObject.TryGetComponent<PersonalObjectBase>(out var component))
			{
				HighlightCompatibleEquipment(component);
				draggedPersonalObject = component;
			}
		}

		private void ResolveInteractiveObjectStopDrag()
		{
			draggedPersonalObject = null;
			if ((bool)compatibleEquipmentActivator)
			{
				Debug.Log("compatibleEquipmentActivator is still active");
				compatibleEquipmentActivator.ToggleIndicator(isActive: false);
				compatibleEquipmentActivator = null;
			}
		}

		private void HighlightCompatibleEquipment(PersonalObjectBase personalObject)
		{
			EquipmentActivatorBase toolActivator;
			if (!(personalObject is PersonalNotebook))
			{
				if (!(personalObject is CashMoneyObject))
				{
					if (!(personalObject is PcAppObject))
					{
						if (!(personalObject is PersonalTool tool))
						{
							throw new NotImplementedException("Not implemented equipment view for personalObject");
						}
						toolActivator = GetToolActivator(tool);
					}
					else
					{
						toolActivator = pcDriveActivator;
					}
				}
				else
				{
					toolActivator = cashRegisterActivator;
				}
			}
			else
			{
				toolActivator = notebookActivator;
			}
			compatibleEquipmentActivator = toolActivator;
			compatibleEquipmentActivator.ToggleIndicator(isActive: true);
		}

		private ToolActivator GetToolActivator(PersonalTool tool)
		{
			ToolActivator toolActivator = toolActivators.FirstOrDefault((ToolActivator a) => a.ToolsCategories.Any((ToolsCategory c) => c.ID == tool.ToolInfo.ToolsCategory.ID));
			if (!toolActivator)
			{
				throw new Exception("No ToolActivator found for " + tool.ToolInfo.name);
			}
			return toolActivator;
		}

		private void DestroyPersonalObject(PersonalObjectBase personalObject)
		{
			if ((bool)personalObject)
			{
				personalObject.InteractiveObject.Remove();
				interactiveObjectRegistry.Unregister(personalObject.InteractiveObject);
				interactiveObjectFactory.DestroyInteractiveObject(personalObject.InteractiveObject);
			}
		}

		private void ActivateEquipment(EquipmentActivatorBase equipmentActivator)
		{
			equipmentActivator.Activate();
		}

		private void ResolveToolAdded(ToolInfo toolInfo)
		{
			ToolActivator[] array = toolActivators;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetTool(toolInfo, instantly: false);
			}
		}

		private void ResolveToolRemoved(ToolInfo toolInfo)
		{
			UpdateInstrumentActivators();
		}

		private void UpdateInstrumentActivators(bool instantly = true)
		{
			ToolActivator[] array = toolActivators;
			foreach (ToolActivator toolActivator in array)
			{
				foreach (ToolInfo availableTool in toolsService.AvailableTools)
				{
					toolActivator.SetTool(availableTool, instantly);
				}
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				EquipmentSaveData equipmentSaveData = DataMigrationWizard.Migrate<EquipmentSaveData>(state, base.gameObject);
				notebookActivator.RestoreState(equipmentSaveData.IsNotebookActivated);
				cashRegisterActivator.RestoreState(equipmentSaveData.IsCashRegisterActivated);
				cleanerActivator.RestoreState(equipmentSaveData.IsCleanerActivated);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new EquipmentSaveData
				{
					IsNotebookActivated = notebookActivator.IsActivated,
					IsCashRegisterActivated = cashRegisterActivator.IsActivated,
					IsCleanerActivated = cleanerActivator.IsActivated
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void PostRestore()
		{
			UpdateInstrumentActivators();
		}
	}
}
