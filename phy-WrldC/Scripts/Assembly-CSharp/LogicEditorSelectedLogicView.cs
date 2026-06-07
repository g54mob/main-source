using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicEditorSelectedLogicView
{
	private LogicEditorView logicEditorView;

	private GameObject headerPanel;

	private GameObject instructionsPanel;

	private TMP_Text logicNameText;

	private TMP_InputField logicNameInput;

	private Toggle logicActiveToggle;

	private Button editLogicNameButton;

	private TMP_Dropdown logicTypeDropdown;

	private InstructionDropZone rootInstructionDropZone;

	private Logic selectedLogic;

	private List<InstructionSlotBase> instructionSlots;

	public GameObject MainPanel { get; private set; }

	public bool IsMouseOverInstructionsPanel { get; private set; }

	public bool ShouldBlinkNextNewSlot { get; set; }

	public event Action OnBeginingEditLogicName;

	public event Action OnEndingEditLogicName;

	public event Action<Logic, string> OnLogicNameChangedEvent;

	public event Action<bool, Logic> OnLogicActivationChangedEvent;

	public LogicEditorSelectedLogicView(LogicEditorView logicEditorView)
	{
		LogicEditorSelectedLogicView logicEditorSelectedLogicView = this;
		this.logicEditorView = logicEditorView;
		MainPanel = logicEditorView.mainPanel.transform.Find("SelectedLogicPanel").gameObject;
		headerPanel = MainPanel.transform.FindChildRecursively("HeaderPanel").gameObject;
		instructionsPanel = MainPanel.transform.FindChildRecursively("InstructionsPanel").gameObject;
		logicNameText = headerPanel.transform.FindComponent<TMP_Text>("LogicNameText", isRecursively: true);
		logicNameInput = headerPanel.transform.FindComponent<TMP_InputField>("LogicNameInput", isRecursively: true);
		logicActiveToggle = headerPanel.transform.FindComponent<Toggle>("LogicActiveToggle", isRecursively: true);
		editLogicNameButton = headerPanel.transform.FindComponent<Button>("EditLogicNameButton", isRecursively: true);
		logicTypeDropdown = headerPanel.transform.FindComponent<TMP_Dropdown>("LogicTypeDropdown", isRecursively: true);
		GameObject scrollbarVertical = MainPanel.transform.FindChildRecursively("Scrollbar Vertical").gameObject;
		rootInstructionDropZone = instructionsPanel.GetComponent<InstructionDropZone>();
		editLogicNameButton.onClick.AddListener(EditLogicNameButtonHandler);
		logicNameInput.onEndEdit.AddListener(LogicNameInputHandler);
		RefreshLogicTypeDropdown();
		ComponentEventTrigger componentEventTrigger = MainPanel.transform.FindComponent<ComponentEventTrigger>("ScrollView", isRecursively: true);
		componentEventTrigger.OnPointerEnterEvent += delegate
		{
			logicEditorView.MouseOverScrollViewHandler(isMouseOverScrollView: true, scrollbarVertical.activeSelf);
			logicEditorSelectedLogicView.IsMouseOverInstructionsPanel = true;
		};
		componentEventTrigger.OnPointerExitEvent += delegate
		{
			logicEditorView.MouseOverScrollViewHandler(isMouseOverScrollView: false, scrollbarVertical.activeSelf);
			logicEditorSelectedLogicView.IsMouseOverInstructionsPanel = false;
		};
		LanguagesManager.Instance.OnLanguageChangedEvent += delegate
		{
			logicEditorSelectedLogicView.RefreshLogicTypeDropdown();
		};
		instructionSlots = new List<InstructionSlotBase>();
		IsMouseOverInstructionsPanel = false;
		ShouldBlinkNextNewSlot = false;
		MainPanel.SetActive(value: false);
	}

	private void RefreshLogicTypeDropdown()
	{
		logicTypeDropdown.options.Clear();
		string text = LanguagesManager.Instance.GetText("logic.type.loop", "Loop");
		string text2 = LanguagesManager.Instance.GetText("logic.type.once", "Once");
		logicTypeDropdown.options.Add(new TMP_Dropdown.OptionData(text));
		logicTypeDropdown.options.Add(new TMP_Dropdown.OptionData(text2));
	}

	public void SetSelectedLogic(Logic logic)
	{
		selectedLogic = logic;
		RemoveAllInstructionSlots();
		instructionsPanel.transform.RemoveAllChildren();
		instructionSlots.Clear();
		MainPanel.SetActive(value: true);
		logicEditorView.LogicEditorInstructionsInventoryView.MainPanel.SetActive(value: true);
		logicNameText.SetText(logic.Name);
		logicActiveToggle.onValueChanged.RemoveAllListeners();
		logicActiveToggle.isOn = logic.Active;
		logicActiveToggle.onValueChanged.AddListener(delegate(bool isActive)
		{
			SelectedLogicActiveToggleHandler(isActive, logic);
		});
		logicTypeDropdown.onValueChanged.RemoveAllListeners();
		logicTypeDropdown.value = (int)logic.Type;
		logicTypeDropdown.onValueChanged.AddListener(delegate(int index)
		{
			SelectedLogicTypeDropdownHandler(index, logic);
		});
		foreach (Instruction allInstruction in logic.InstructionsList.GetAllInstructions())
		{
			AddInstructionSlots(allInstruction, logic.InstructionsList, instructionsPanel.transform);
		}
		rootInstructionDropZone.IsRootLevel = true;
		rootInstructionDropZone.InstructionsList = logic.InstructionsList;
	}

	private void SelectedLogicActiveToggleHandler(bool isActive, Logic logic)
	{
		logic.Active = isActive;
		this.OnLogicActivationChangedEvent?.Invoke(isActive, logic);
	}

	private void SelectedLogicTypeDropdownHandler(int index, Logic logic)
	{
		logic.Type = (LogicType)index;
	}

	public Logic GetSelectedLogic()
	{
		if (!MainPanel.activeSelf)
		{
			return null;
		}
		return selectedLogic;
	}

	public void DeselectSelectedLogic()
	{
		RemoveAllInstructionSlots();
		instructionsPanel.transform.RemoveAllChildren();
		instructionSlots.Clear();
		MainPanel.SetActive(value: false);
		logicEditorView.LogicEditorInstructionsInventoryView.MainPanel.SetActive(value: false);
	}

	private void EditLogicNameButtonHandler()
	{
		if (selectedLogic != null)
		{
			editLogicNameButton.interactable = false;
			logicNameInput.gameObject.SetActive(value: true);
			logicNameInput.SetTextWithoutNotify(selectedLogic.Name);
			logicNameInput.Select();
			logicNameInput.ActivateInputField();
			this.OnBeginingEditLogicName?.Invoke();
		}
	}

	private void LogicNameInputHandler(string newLogicName)
	{
		if (selectedLogic != null && !string.IsNullOrEmpty(newLogicName) && !string.IsNullOrWhiteSpace(newLogicName))
		{
			editLogicNameButton.interactable = true;
			logicNameInput.gameObject.SetActive(value: false);
			logicNameText.SetText(newLogicName);
			this.OnEndingEditLogicName?.Invoke();
			this.OnLogicNameChangedEvent?.Invoke(selectedLogic, newLogicName);
		}
	}

	public void AddInstructionSlots(Instruction instruction, InstructionsList parentInstructionsList, Transform parentPanel)
	{
		if (parentPanel == null)
		{
			parentPanel = instructionsPanel.transform;
		}
		switch (instruction.Type)
		{
		case InstructionType.KeyTrigger:
		{
			KeyTriggerInstruction keyTriggerInstruction = instruction as KeyTriggerInstruction;
			AddKeyTriggerInstructionSlot(keyTriggerInstruction, parentInstructionsList, parentPanel, -1);
			break;
		}
		case InstructionType.Comparator:
		{
			ComparatorInstruction comparatorInstruction = instruction as ComparatorInstruction;
			AddComparatorInstructionSlot(comparatorInstruction, parentInstructionsList, parentPanel, -1);
			break;
		}
		case InstructionType.Set:
		{
			SetInstruction setInstruction = instruction as SetInstruction;
			AddSetInstructionSlot(setInstruction, parentInstructionsList, parentPanel, -1);
			break;
		}
		case InstructionType.Accumulator:
		{
			AccumulatorInstruction accumulatorInstruction = instruction as AccumulatorInstruction;
			AddAccumulatorInstructionSlot(accumulatorInstruction, parentInstructionsList, parentPanel, -1);
			break;
		}
		case InstructionType.Operation:
		{
			OperationInstruction operationInstruction = instruction as OperationInstruction;
			AddOperationInstructionSlot(operationInstruction, parentInstructionsList, parentPanel, -1);
			break;
		}
		case InstructionType.Delay:
		{
			DelayInstruction delayInstruction = instruction as DelayInstruction;
			AddDelayInstructionSlot(delayInstruction, parentInstructionsList, parentPanel, -1);
			break;
		}
		case InstructionType.Group:
		{
			GroupInstruction groupInstruction = instruction as GroupInstruction;
			AddGroupInstructionSlot(groupInstruction, parentInstructionsList, parentPanel, -1);
			break;
		}
		}
	}

	public void AddNewInstructionSlotHandler(InstructionType instructionType, InstructionsList listToAddInstruction, Transform parentPanel, int index = -1)
	{
		switch (instructionType)
		{
		case InstructionType.KeyTrigger:
		{
			KeyTriggerInstruction keyTriggerInstruction = new KeyTriggerInstruction(listToAddInstruction.ParentLogic);
			AddKeyTriggerInstructionSlot(keyTriggerInstruction, listToAddInstruction, parentPanel, index);
			if (index == -1)
			{
				listToAddInstruction.AddInstruction(keyTriggerInstruction);
			}
			else
			{
				listToAddInstruction.InsertInstruction(keyTriggerInstruction, index);
			}
			break;
		}
		case InstructionType.Comparator:
		{
			ComparatorInstruction comparatorInstruction = new ComparatorInstruction(listToAddInstruction.ParentLogic);
			AddComparatorInstructionSlot(comparatorInstruction, listToAddInstruction, parentPanel, index);
			if (index == -1)
			{
				listToAddInstruction.AddInstruction(comparatorInstruction);
			}
			else
			{
				listToAddInstruction.InsertInstruction(comparatorInstruction, index);
			}
			break;
		}
		case InstructionType.Set:
		{
			SetInstruction setInstruction = new SetInstruction(listToAddInstruction.ParentLogic);
			AddSetInstructionSlot(setInstruction, listToAddInstruction, parentPanel, index);
			if (index == -1)
			{
				listToAddInstruction.AddInstruction(setInstruction);
			}
			else
			{
				listToAddInstruction.InsertInstruction(setInstruction, index);
			}
			break;
		}
		case InstructionType.Accumulator:
		{
			AccumulatorInstruction accumulatorInstruction = new AccumulatorInstruction(listToAddInstruction.ParentLogic);
			AddAccumulatorInstructionSlot(accumulatorInstruction, listToAddInstruction, parentPanel, index);
			if (index == -1)
			{
				listToAddInstruction.AddInstruction(accumulatorInstruction);
			}
			else
			{
				listToAddInstruction.InsertInstruction(accumulatorInstruction, index);
			}
			break;
		}
		case InstructionType.Operation:
		{
			OperationInstruction operationInstruction = new OperationInstruction(listToAddInstruction.ParentLogic);
			AddOperationInstructionSlot(operationInstruction, listToAddInstruction, parentPanel, index);
			if (index == -1)
			{
				listToAddInstruction.AddInstruction(operationInstruction);
			}
			else
			{
				listToAddInstruction.InsertInstruction(operationInstruction, index);
			}
			break;
		}
		case InstructionType.Delay:
		{
			DelayInstruction delayInstruction = new DelayInstruction(listToAddInstruction.ParentLogic);
			AddDelayInstructionSlot(delayInstruction, listToAddInstruction, parentPanel, index);
			if (index == -1)
			{
				listToAddInstruction.AddInstruction(delayInstruction);
			}
			else
			{
				listToAddInstruction.InsertInstruction(delayInstruction, index);
			}
			break;
		}
		case InstructionType.Group:
		{
			GroupInstruction groupInstruction = new GroupInstruction(listToAddInstruction.ParentLogic);
			AddGroupInstructionSlot(groupInstruction, listToAddInstruction, parentPanel, index);
			if (index == -1)
			{
				listToAddInstruction.AddInstruction(groupInstruction);
			}
			else
			{
				listToAddInstruction.InsertInstruction(groupInstruction, index);
			}
			break;
		}
		}
	}

	private InstructionSlotBase AddKeyTriggerInstructionSlot(KeyTriggerInstruction keyTriggerInstruction, InstructionsList parentInstructionsList, Transform parentPanel, int newIndex)
	{
		GameObject instanceForUI = ObjectPools.Instance.GetInstanceForUI("key_trigger_instruction_slot", parentPanel);
		KeyTriggerInstructionSlot component = instanceForUI.GetComponent<KeyTriggerInstructionSlot>();
		component.Initialize(keyTriggerInstruction);
		component.SetAxisEnabled(!GameManager.Instance.OptionsModel.IsJoystickAxesDisabled);
		component.OnKeyBeginingOrEndingAssigmentEvent += delegate(bool isBeingAssigned)
		{
			logicEditorView.SetKeyboardInUse(isBeingAssigned);
		};
		component.OnKeyBeginingOrEndingLabelEditingEvent += delegate(bool isBeingAssigned)
		{
			logicEditorView.SetKeyboardInUse(isBeingAssigned);
		};
		ConfigureInstructionCommons(keyTriggerInstruction, component, parentInstructionsList, instanceForUI, newIndex);
		foreach (Instruction allInstruction in keyTriggerInstruction.FirstInstructionsList.GetAllInstructions())
		{
			AddInstructionSlots(allInstruction, keyTriggerInstruction.FirstInstructionsList, component.IfTransform);
		}
		foreach (Instruction allInstruction2 in keyTriggerInstruction.SecondInstructionsList.GetAllInstructions())
		{
			AddInstructionSlots(allInstruction2, keyTriggerInstruction.SecondInstructionsList, component.ElseTransform);
		}
		return component;
	}

	private InstructionSlotBase AddComparatorInstructionSlot(ComparatorInstruction comparatorInstruction, InstructionsList parentInstructionsList, Transform parentPanel, int newIndex)
	{
		GameObject instanceForUI = ObjectPools.Instance.GetInstanceForUI("comparator_instruction_slot", parentPanel);
		ComparatorInstructionSlot comparatorInstructionSlot = instanceForUI.GetComponent<ComparatorInstructionSlot>();
		comparatorInstructionSlot.Initialize(comparatorInstruction);
		comparatorInstructionSlot.OnFirstIOButtonClickedEvent += delegate
		{
			comparatorInstructionSlot.AttachFirstLogicIO(logicEditorView.LogicEditorBlockIOView.SelectedLogicIO);
		};
		comparatorInstructionSlot.OnSecondIOButtonClickedEvent += delegate
		{
			comparatorInstructionSlot.AttachSecondLogicIO(logicEditorView.LogicEditorBlockIOView.SelectedLogicIO);
		};
		comparatorInstructionSlot.OnFirstBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			logicEditorView.SetIOButton3DHighlight(comparatorInstruction.FirstSocketIO, isHighlighted);
		};
		comparatorInstructionSlot.OnSecondBlockHighlightChangedEvent += delegate(bool isHighlighted)
		{
			logicEditorView.SetIOButton3DHighlight(comparatorInstruction.SecondSocketIO, isHighlighted);
		};
		ConfigureInstructionCommons(comparatorInstruction, comparatorInstructionSlot, parentInstructionsList, instanceForUI, newIndex);
		foreach (Instruction allInstruction in comparatorInstruction.FirstInstructionsList.GetAllInstructions())
		{
			AddInstructionSlots(allInstruction, comparatorInstruction.FirstInstructionsList, comparatorInstructionSlot.IfTransform);
		}
		foreach (Instruction allInstruction2 in comparatorInstruction.SecondInstructionsList.GetAllInstructions())
		{
			AddInstructionSlots(allInstruction2, comparatorInstruction.SecondInstructionsList, comparatorInstructionSlot.ElseTransform);
		}
		return comparatorInstructionSlot;
	}

	private InstructionSlotBase AddSetInstructionSlot(SetInstruction setInstruction, InstructionsList parentInstructionsList, Transform parentPanel, int newIndex)
	{
		GameObject instanceForUI = ObjectPools.Instance.GetInstanceForUI("set_instruction_slot", parentPanel);
		SetInstructionSlot setInstructionSlot = instanceForUI.GetComponent<SetInstructionSlot>();
		setInstructionSlot.Initialize(setInstruction);
		setInstructionSlot.OnValueIOButtonClickedEvent += delegate
		{
			setInstructionSlot.AttachValueLogicIO(logicEditorView.LogicEditorBlockIOView.SelectedLogicIO);
		};
		setInstructionSlot.OnIOButtonClickedEvent += delegate
		{
			setInstructionSlot.AttachLogicIO(logicEditorView.LogicEditorBlockIOView.SelectedLogicIO);
		};
		setInstructionSlot.OnBlockHighlightChangedEvent += delegate(SocketIO socket, bool isHighlighted)
		{
			logicEditorView.SetIOButton3DHighlight(socket, isHighlighted);
		};
		ConfigureInstructionCommons(setInstruction, setInstructionSlot, parentInstructionsList, instanceForUI, newIndex);
		return setInstructionSlot;
	}

	private InstructionSlotBase AddAccumulatorInstructionSlot(AccumulatorInstruction accumulatorInstruction, InstructionsList parentInstructionsList, Transform parentPanel, int newIndex)
	{
		GameObject instanceForUI = ObjectPools.Instance.GetInstanceForUI("accumulator_instruction_slot", parentPanel);
		AccumulatorInstructionSlot accumulatorInstructionSlot = instanceForUI.GetComponent<AccumulatorInstructionSlot>();
		accumulatorInstructionSlot.Initialize(accumulatorInstruction);
		accumulatorInstructionSlot.OnValueIOButtonClickedEvent += delegate
		{
			accumulatorInstructionSlot.AttachValueLogicIO(logicEditorView.LogicEditorBlockIOView.SelectedLogicIO);
		};
		accumulatorInstructionSlot.OnIOButtonClickedEvent += delegate
		{
			accumulatorInstructionSlot.AttachLogicIO(logicEditorView.LogicEditorBlockIOView.SelectedLogicIO);
		};
		accumulatorInstructionSlot.OnBlockHighlightChangedEvent += delegate(SocketIO socket, bool isHighlighted)
		{
			logicEditorView.SetIOButton3DHighlight(socket, isHighlighted);
		};
		ConfigureInstructionCommons(accumulatorInstruction, accumulatorInstructionSlot, parentInstructionsList, instanceForUI, newIndex);
		return accumulatorInstructionSlot;
	}

	private InstructionSlotBase AddOperationInstructionSlot(OperationInstruction operationInstruction, InstructionsList parentInstructionsList, Transform parentPanel, int newIndex)
	{
		GameObject instanceForUI = ObjectPools.Instance.GetInstanceForUI("operation_instruction_slot", parentPanel);
		OperationInstructionSlot operationInstructionSlot = instanceForUI.GetComponent<OperationInstructionSlot>();
		operationInstructionSlot.Initialize(operationInstruction);
		operationInstructionSlot.OnValueIOButtonClickedEvent += delegate
		{
			operationInstructionSlot.AttachValueLogicIO(logicEditorView.LogicEditorBlockIOView.SelectedLogicIO);
		};
		operationInstructionSlot.OnIOButtonClickedEvent += delegate
		{
			operationInstructionSlot.AttachLogicIO(logicEditorView.LogicEditorBlockIOView.SelectedLogicIO);
		};
		operationInstructionSlot.OnBlockHighlightChangedEvent += delegate(SocketIO socket, bool isHighlighted)
		{
			logicEditorView.SetIOButton3DHighlight(socket, isHighlighted);
		};
		ConfigureInstructionCommons(operationInstruction, operationInstructionSlot, parentInstructionsList, instanceForUI, newIndex);
		return operationInstructionSlot;
	}

	private InstructionSlotBase AddDelayInstructionSlot(DelayInstruction delayInstruction, InstructionsList parentInstructionsList, Transform parentPanel, int index)
	{
		GameObject instanceForUI = ObjectPools.Instance.GetInstanceForUI("delay_instruction_slot", parentPanel);
		DelayInstructionSlot component = instanceForUI.GetComponent<DelayInstructionSlot>();
		component.Initialize(delayInstruction);
		ConfigureInstructionCommons(delayInstruction, component, parentInstructionsList, instanceForUI, index);
		return component;
	}

	private InstructionSlotBase AddGroupInstructionSlot(GroupInstruction groupInstruction, InstructionsList parentInstructionsList, Transform parentPanel, int index)
	{
		GameObject instanceForUI = ObjectPools.Instance.GetInstanceForUI("group_instruction_slot", parentPanel);
		GroupInstructionSlot component = instanceForUI.GetComponent<GroupInstructionSlot>();
		component.Initialize(groupInstruction);
		component.OnKeyBeginingOrEndingLabelEditingEvent += delegate(bool isBeingAssigned)
		{
			logicEditorView.SetKeyboardInUse(isBeingAssigned);
		};
		ConfigureInstructionCommons(groupInstruction, component, parentInstructionsList, instanceForUI, index);
		foreach (Instruction allInstruction in groupInstruction.FirstInstructionsList.GetAllInstructions())
		{
			AddInstructionSlots(allInstruction, groupInstruction.FirstInstructionsList, component.GroupTransform);
		}
		return component;
	}

	private void ConfigureInstructionCommons(Instruction instruction, InstructionSlotBase instructionSlot, InstructionsList parentInstructionsList, GameObject instructionSlotObject, int index)
	{
		instructionSlot.OnInstructionDeleteEvent += InstructionDeleteHandler;
		instructionSlot.OnSlotBeginOrEndDragEvent += delegate(bool isBeginDrag)
		{
			logicEditorView.SetBeingDragEvent(isBeginDrag);
		};
		instructionSlot.OnInstructionEndDragEvent += InstructionEndDragHandler;
		if (index >= 0)
		{
			instructionSlotObject.transform.SetSiblingIndex(index);
		}
		if (ShouldBlinkNextNewSlot)
		{
			instructionSlot.BlinkSlot();
		}
		ShouldBlinkNextNewSlot = false;
		void InstructionDeleteHandler()
		{
			RemoveInstructionSlot(instructionSlot.gameObject);
			parentInstructionsList.RemoveInstruction(instruction);
		}
		void InstructionEndDragHandler(int oldIndex, int newIndex, InstructionDropZone instructionDropZone)
		{
			logicEditorView.InstructionIndexChangedHandler(parentInstructionsList, instructionDropZone.InstructionsList, oldIndex, newIndex);
			instructionSlotObject.transform.SetParent(instructionDropZone.transform);
			instructionSlotObject.transform.SetSiblingIndex(newIndex);
			if (parentInstructionsList != instructionDropZone.InstructionsList)
			{
				parentInstructionsList = instructionDropZone.InstructionsList;
			}
		}
	}

	private void RemoveInstructionSlot(GameObject instructionSlotObject)
	{
		InstructionSlotBase component = instructionSlotObject.GetComponent<InstructionSlotBase>();
		if (component == null)
		{
			return;
		}
		if (component is MultiDropZonesInstructionSlot multiDropZonesInstructionSlot)
		{
			for (int i = 0; i < multiDropZonesInstructionSlot.InstructionDropZones.Length; i++)
			{
				Transform transform = multiDropZonesInstructionSlot.InstructionDropZones[i].transform;
				for (int num = transform.childCount - 1; num >= 0; num--)
				{
					RemoveInstructionSlot(transform.GetChild(num).gameObject);
				}
			}
		}
		ObjectPools.Instance.ReturnInstance(instructionSlotObject);
	}

	private void RemoveAllInstructionSlots()
	{
		for (int num = instructionsPanel.transform.childCount - 1; num >= 0; num--)
		{
			RemoveInstructionSlot(instructionsPanel.transform.GetChild(num).gameObject);
		}
	}
}
