using System;
using System.Collections.Generic;
using Restory.Data.Elements.Condition;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Disassemble.StateMachine;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.Equipment.CashRegisters;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.Equipment.Levers;
using Restory.Gameplay.Equipment.PersonalComputers;
using Restory.Gameplay.Equipment.TableLamps;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.Tips;
using Restory.Gameplay.Work.StateMachine;
using Restory.Gameplay.Workplace;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.DetectableObjects
{
	public class DetectableObjectService : MonoBehaviour, IInitializable, IDisposable
	{
		private readonly List<IDetectableObject> detectableObjects = new List<IDetectableObject>();

		private WorkStateMachine workStateMachine;

		private DisassembleStateMachine disassembleStateMachine;

		private DragObjectRegistrator dragObjectRegistrator;

		private DragElementRegistrator dragElementRegistrator;

		private DeviceService deviceService;

		private PcKeyboardInteractiveWorkplaceItem pcMouse;

		private PcInteractiveWorkplaceItem pcBlock;

		private NotepadInteractiveWorkplaceItem notebook;

		private InventoryBoxDetector inventoryBox;

		private BicycleInteractiveStoreItem bicycle;

		private VerticalLever verticalLever;

		private CashRegister cashRegister;

		private TableLamp tableLamp;

		private TrashCan trashCan;

		private TipBox tipBox;

		private WorkSurface workSurface;

		private InteractiveObjectService interactiveObjectService;

		private PaintingToolWorkplaceItemDetector paintingTool;

		[Inject]
		private void Construct(WorkStateMachine workStateMachine, DisassembleStateMachine disassembleStateMachine, DragObjectRegistrator dragObjectRegistrator, DragElementRegistrator dragElementRegistrator, DeviceService deviceService, PcKeyboardInteractiveWorkplaceItem pcMouse, PcInteractiveWorkplaceItem pcBlock, NotepadInteractiveWorkplaceItem notebook, PaintingToolWorkplaceItemDetector paintingTool, InventoryBoxDetector inventoryBox, BicycleInteractiveStoreItem bicycle, VerticalLever verticalLever, CashRegister cashRegister, TableLamp tableLamp, TrashCan trashCan, TipBox tipBox, WorkSurface workSurface, InteractiveObjectService interactiveObjectService)
		{
			this.workStateMachine = workStateMachine;
			this.disassembleStateMachine = disassembleStateMachine;
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.dragElementRegistrator = dragElementRegistrator;
			this.deviceService = deviceService;
			this.pcMouse = pcMouse;
			this.pcBlock = pcBlock;
			this.notebook = notebook;
			this.inventoryBox = inventoryBox;
			this.paintingTool = paintingTool;
			this.bicycle = bicycle;
			this.verticalLever = verticalLever;
			this.cashRegister = cashRegister;
			this.tableLamp = tableLamp;
			this.trashCan = trashCan;
			this.tipBox = tipBox;
			this.workSurface = workSurface;
			this.interactiveObjectService = interactiveObjectService;
		}

		public void Initialize()
		{
			detectableObjects.Add(pcMouse);
			detectableObjects.Add(pcBlock);
			detectableObjects.Add(notebook);
			detectableObjects.Add(inventoryBox);
			detectableObjects.Add(paintingTool);
			detectableObjects.Add(bicycle);
			detectableObjects.Add(verticalLever);
			detectableObjects.Add(cashRegister);
			detectableObjects.Add(tableLamp);
			detectableObjects.Add(trashCan);
			detectableObjects.Add(tipBox);
			detectableObjects.Add(workSurface);
			EnableDetectableObjects();
			workStateMachine.OnStateChanged.AddListener(ResolveWorkStateChanged);
			disassembleStateMachine.OnStateChanged.AddListener(ResolveDisassembleStateChanged);
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartDrag;
			dragElementRegistrator.OnElementStartDrag += ResolveElementStartDrag;
		}

		public void Dispose()
		{
			workStateMachine.OnStateChanged.RemoveListener(ResolveWorkStateChanged);
			disassembleStateMachine.OnStateChanged.RemoveListener(ResolveDisassembleStateChanged);
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartDrag;
			dragElementRegistrator.OnElementStartDrag -= ResolveElementStartDrag;
		}

		private void EnableDetectableObjects()
		{
			foreach (IDetectableObject detectableObject in detectableObjects)
			{
				detectableObject.CanBeDetected = true;
			}
			if ((bool)deviceService.PlacedDeviceContainer || interactiveObjectService.AnyObjectOnSurface)
			{
				workSurface.CanBeDetected = false;
			}
		}

		private void DisableDetectableObjects()
		{
			foreach (IDetectableObject detectableObject in detectableObjects)
			{
				detectableObject.CanBeDetected = false;
			}
		}

		private void ResolveWorkStateChanged()
		{
			IExitableState activeState = workStateMachine.ActiveState;
			if (!(activeState is DetectionWorkState))
			{
				if (activeState is DialogueWorkState || activeState is DisabledWorkState)
				{
					DisableDetectableObjects();
				}
			}
			else
			{
				EnableDetectableObjects();
			}
		}

		private void ResolveDisassembleStateChanged()
		{
			IExitableState activeState = disassembleStateMachine.ActiveState;
			if (activeState is DetectionDisassembleState || activeState is EmptyDisassembleState)
			{
				inventoryBox.CanBeDetected = true;
				pcMouse.CanBeDetected = true;
				tableLamp.CanBeDetected = true;
				paintingTool.CanBeDetected = true;
			}
		}

		private void ResolveInteractiveObjectStartDrag()
		{
			DisableDetectableObjects();
			InteractiveObject draggingObject = dragObjectRegistrator.DraggingObject;
			if (!draggingObject)
			{
				return;
			}
			if (draggingObject.TryGetComponent<TrashObject>(out var _))
			{
				trashCan.CanBeDetected = true;
				return;
			}
			if (draggingObject.TryGetComponent<CashMoneyObject>(out var _))
			{
				cashRegister.CanBeDetected = true;
			}
			if (draggingObject.TryGetComponent<PcAppObject>(out var _))
			{
				pcBlock.CanBeDetected = true;
			}
			PaintingPalettesContainer component6;
			if (draggingObject.TryGetComponent<ElementsContainer>(out var _) || draggingObject.TryGetComponent<ElementsBox>(out var _))
			{
				inventoryBox.CanBeDetected = true;
			}
			else if (draggingObject.TryGetComponent<PaintingPalettesContainer>(out component6))
			{
				paintingTool.CanBeDetected = true;
				dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolvePaintingPalettesContainerStoppedBeingDragged;
			}
		}

		private void ResolveElementStartDrag()
		{
			DisableDetectableObjects();
			ElementBase draggingElement = dragElementRegistrator.DraggingElement;
			if ((bool)draggingElement)
			{
				inventoryBox.CanBeDetected = true;
				if (draggingElement.ConditionHandler.ElementData.Condition is DamagedElementCondition)
				{
					trashCan.CanBeDetected = true;
				}
			}
		}

		private void ResolvePaintingPalettesContainerStoppedBeingDragged()
		{
			paintingTool.CanBeDetected = false;
			if (dragObjectRegistrator != null)
			{
				dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolvePaintingPalettesContainerStoppedBeingDragged;
			}
		}
	}
}
