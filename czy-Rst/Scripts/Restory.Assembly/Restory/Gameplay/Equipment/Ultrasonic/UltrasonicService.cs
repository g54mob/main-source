using System;
using System.Collections.Generic;
using Restory.Data.Devices;
using Restory.Data.Elements.Condition;
using Restory.Data.GameWarnings;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.Ultrasonic.States;
using Restory.Gameplay.GameCursor;
using Restory.Gameplay.GameDialogues;
using Restory.Gameplay.Quests;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class UltrasonicService : MonoBehaviour, IInitializable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		private SonicBath sonicBath;

		private InventoryBox inventoryBox;

		private DeviceService deviceService;

		private ElementService elementService;

		private ElementCleaner elementCleaner;

		private DragElementRegistrator dragElementRegistrator;

		private GameWarningService gameWarningService;

		private GameWarningDatabase gameWarningDatabase;

		private CursorSelectionService cursorSelectionService;

		private DisassembleStateMachine disassembleStateMachine;

		private UltrasonicStateMachine ultrasonicStateMachine;

		private bool isDraggingElementCanBeInsertedToSonicBath;

		[Inject]
		private void Construct(SonicBath sonicBath, InventoryBox inventoryBox, DeviceService deviceService, ElementService elementService, ElementCleaner elementCleaner, DragElementRegistrator dragElementRegistrator, GameWarningService gameWarningService, GameWarningDatabase gameWarningDatabase, CursorSelectionService cursorSelectionService, DisassembleStateMachine disassembleStateMachine)
		{
			this.sonicBath = sonicBath;
			this.inventoryBox = inventoryBox;
			this.deviceService = deviceService;
			this.elementService = elementService;
			this.elementCleaner = elementCleaner;
			this.dragElementRegistrator = dragElementRegistrator;
			this.gameWarningService = gameWarningService;
			this.gameWarningDatabase = gameWarningDatabase;
			this.cursorSelectionService = cursorSelectionService;
			this.disassembleStateMachine = disassembleStateMachine;
		}

		public void Initialize()
		{
			ultrasonicStateMachine = new UltrasonicStateMachine(sonicBath, cursorSelectionService, disassembleStateMachine);
			dragElementRegistrator.OnElementStartDrag += ResolveElementStartDrag;
			dragElementRegistrator.OnElementStopDrag += ResolveElementStopDrag;
		}

		public void Dispose()
		{
			ultrasonicStateMachine.Dispose();
			dragElementRegistrator.OnElementStartDrag -= ResolveElementStartDrag;
			dragElementRegistrator.OnElementStopDrag -= ResolveElementStopDrag;
		}

		public bool TryFitElementToSonicBath(ElementBase element, Vector3 sonicBathHitPosition)
		{
			if (!sonicBath.ActiveTool)
			{
				return false;
			}
			if (!isDraggingElementCanBeInsertedToSonicBath)
			{
				return false;
			}
			if (ultrasonicStateMachine.CurrentState is LaunchedUltrasonicState)
			{
				return false;
			}
			sonicBath.TryPull();
			return sonicBath.ElementFitter.TryFitElement(element, sonicBathHitPosition);
		}

		public bool TryInsertElementToSonicBath(ElementBase element)
		{
			if (!sonicBath.ActiveTool)
			{
				return false;
			}
			if (element.ConditionHandler.ElementData.Condition is DamagedElementCondition)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.BrokenPartRejectedByBath);
				return false;
			}
			if (ultrasonicStateMachine.CurrentState is LaunchedUltrasonicState)
			{
				gameWarningService.ShowWarning(gameWarningDatabase.NeedTurnOffBath);
				return false;
			}
			if (sonicBath.IsFull)
			{
				sonicBath.OccupancyIndicator.PlayWarningIndication();
				gameWarningService.ShowWarning(gameWarningDatabase.NoSpaceInBath);
				return false;
			}
			if (dragElementRegistrator.DraggingElement is QuestItem)
			{
				return false;
			}
			return sonicBath.TryInsertElement(element);
		}

		public bool TryRetrieveElementFromSonicBath(ElementBase element)
		{
			if (!sonicBath.ActiveTool)
			{
				return false;
			}
			if (!sonicBath.TryRetrieveElement(element))
			{
				return false;
			}
			if ((bool)deviceService.PlacedDeviceContainer && deviceService.PlacedDeviceContainer.Device.Info != element.Info.SourceDevice as DeviceInfo)
			{
				inventoryBox.ToggleIndicator(isActive: true);
			}
			return true;
		}

		public bool TryReturnElementToSonicBath(ElementBase element)
		{
			if (!sonicBath.ActiveTool)
			{
				return false;
			}
			return sonicBath.TryCancelElementRetrieving(element);
		}

		public void ResetElement()
		{
			if ((bool)sonicBath.ActiveTool)
			{
				sonicBath.ElementFitter.ResetElement();
			}
		}

		private void ResolveElementStartDrag()
		{
			if (!sonicBath.ActiveTool || sonicBath.IsFull || dragElementRegistrator.DraggingElement is QuestItem || dragElementRegistrator.DraggingElement.ConditionHandler.ElementData.Condition is DamagedElementCondition)
			{
				return;
			}
			if (!(ultrasonicStateMachine.CurrentState is LaunchedUltrasonicState))
			{
				sonicBath.CanBeDetected = true;
				if (elementCleaner.DraggingElementInitialCleaningData != null && elementCleaner.DraggingElementInitialCleaningData.CanBeCleaned())
				{
					sonicBath.ToggleTooltipIndicator(isActive: true);
				}
			}
			isDraggingElementCanBeInsertedToSonicBath = true;
		}

		private void ResolveElementStopDrag()
		{
			if (isDraggingElementCanBeInsertedToSonicBath)
			{
				isDraggingElementCanBeInsertedToSonicBath = false;
				sonicBath.ElementFitter.ResetElement();
				sonicBath.CanBeDetected = false;
				sonicBath.ToggleTooltipIndicator(isActive: false);
				inventoryBox.ToggleIndicator(isActive: false);
			}
		}

		public object CaptureState()
		{
			try
			{
				UltrasonicSaveData ultrasonicSaveData = new UltrasonicSaveData
				{
					ActiveTool = sonicBath.ActiveTool
				};
				if (!ultrasonicSaveData.ActiveTool || sonicBath.InsertedElements.Count == 0)
				{
					return ultrasonicSaveData;
				}
				ultrasonicSaveData.InsertedElements = new List<InsertedElementData>();
				foreach (KeyValuePair<ElementBase, ElementRescaleData> insertedElement in sonicBath.InsertedElements)
				{
					ultrasonicSaveData.InsertedElements.Add(new InsertedElementData
					{
						ElementData = insertedElement.Key.ConditionHandler.ElementData,
						ElementTransform = new SerializableTransform(insertedElement.Key.transform.localPosition, insertedElement.Key.transform.localRotation),
						RescaleData = insertedElement.Value
					});
				}
				if (sonicBath.Timer.IsCountdown)
				{
					ultrasonicSaveData.TimerData = sonicBath.Timer.Capture();
				}
				ultrasonicSaveData.IsCleaningDone = sonicBath.IsCleaningDone;
				return ultrasonicSaveData;
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				UltrasonicSaveData ultrasonicSaveData = DataMigrationWizard.Migrate<UltrasonicSaveData>(state, base.gameObject);
				if (ultrasonicSaveData == null || !ultrasonicSaveData.ActiveTool)
				{
					return;
				}
				sonicBath.RestoreActiveTool(ultrasonicSaveData.ActiveTool);
				if (ultrasonicSaveData.InsertedElements == null || ultrasonicSaveData.InsertedElements.Count == 0)
				{
					sonicBath.ToggleButton.TurnOff();
					ultrasonicStateMachine.EnterIdleState();
					return;
				}
				foreach (InsertedElementData insertedElement in ultrasonicSaveData.InsertedElements)
				{
					ElementBase elementBase = elementService.CreateElement(insertedElement.ElementData);
					sonicBath.InsertElement(elementBase, insertedElement.RescaleData);
					if (insertedElement.RescaleData.RescaleFactor < 1f)
					{
						elementBase.transform.localScale *= insertedElement.RescaleData.RescaleFactor;
					}
					elementBase.transform.SetLocalPositionAndRotation(insertedElement.ElementTransform.Position, insertedElement.ElementTransform.Rotation);
					elementBase.Activate();
				}
				if (ultrasonicSaveData.TimerData == null || !ultrasonicSaveData.TimerData.IsCountdown)
				{
					sonicBath.IsCleaningDone = ultrasonicSaveData.IsCleaningDone;
					sonicBath.ToggleButton.TurnOff();
					ultrasonicStateMachine.EnterIdleState();
				}
				else
				{
					sonicBath.Timer.Restore(ultrasonicSaveData.TimerData);
					sonicBath.ToggleButton.TurnOn();
					ultrasonicStateMachine.EnterLaunchedState();
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if ((bool)sonicBath.ActiveTool)
			{
				sonicBath.Timer.PostRestore();
			}
			else
			{
				ultrasonicStateMachine.EnterDisabledState();
			}
		}
	}
}
