using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LogicEditorUserLogicView
{
	private LogicEditorView logicEditorView;

	private GameObject logicSlotsPanel;

	private ToggleGroup logicSlotsToggleGroup;

	private GameObject logicSlotPrefab;

	private TMP_InputField newLogicInputField;

	private Button newLogicButton;

	private List<LogicSlot> logicSlots;

	public GameObject MainPanel { get; private set; }

	public bool IsMouseOverLogicsPanel { get; private set; }

	public bool ShouldBlinkNextNewSlot { get; set; }

	public event Action OnBeginingEditLogicName;

	public event Action OnEndingEditLogicName;

	public LogicEditorUserLogicView(LogicEditorView logicEditorView)
	{
		this.logicEditorView = logicEditorView;
		logicSlots = new List<LogicSlot>();
		MainPanel = logicEditorView.mainPanel.transform.Find("UserLogicsPanel").gameObject;
		logicSlotsPanel = MainPanel.transform.FindChildRecursively("LogicSlotsPanel").gameObject;
		logicSlotsToggleGroup = logicSlotsPanel.GetComponent<ToggleGroup>();
		GameObject gameObject = MainPanel.transform.FindChildRecursively("NewLogicInput").gameObject;
		newLogicInputField = gameObject.transform.FindComponent<TMP_InputField>("InputField", isRecursively: true);
		newLogicButton = MainPanel.transform.FindComponent<Button>("NewLogicButton", isRecursively: true);
		logicSlotPrefab = logicEditorView.logicSlotPrefab;
		newLogicInputField.onSelect.AddListener(delegate
		{
			this.OnBeginingEditLogicName?.Invoke();
		});
		newLogicInputField.onEndEdit.AddListener(delegate
		{
			this.OnEndingEditLogicName?.Invoke();
		});
		newLogicInputField.onSubmit.AddListener(delegate
		{
			NewUserLogicButtonHandler();
		});
		newLogicButton.onClick.AddListener(NewUserLogicButtonHandler);
		ComponentEventTrigger component = logicSlotsPanel.GetComponent<ComponentEventTrigger>();
		component.OnPointerEnterEvent += delegate
		{
			IsMouseOverLogicsPanel = true;
		};
		component.OnPointerExitEvent += delegate
		{
			IsMouseOverLogicsPanel = false;
		};
		IsMouseOverLogicsPanel = false;
		ShouldBlinkNextNewSlot = false;
		ClearLogicSlots();
	}

	public void ClearLogicSlots()
	{
		logicSlots.Clear();
		logicSlotsPanel.transform.RemoveAllChildren();
	}

	private void NewUserLogicButtonHandler()
	{
		string text = newLogicInputField.text;
		if (!string.IsNullOrEmpty(text))
		{
			newLogicInputField.text = "";
			EventSystem.current.SetSelectedGameObject(null);
			logicEditorView.NewUserLogicHandler(text);
		}
	}

	public void AddUserLogicSlot(Logic logic, int index)
	{
		GameObject gameObject = Util.InstantiateForGUI(logicSlotPrefab, logicSlotsPanel.transform, index, "LogicSlot_" + index);
		LogicSlot logicSlot = gameObject.GetComponent<LogicSlot>();
		logicSlot.Initialize(logic, logicSlotsToggleGroup);
		logicSlot.OnDeleteButtonEvent += delegate
		{
			DeleteButtonHandler(logicSlot);
		};
		logicSlot.OnToggleChangedEvent += delegate(bool isOn)
		{
			ChangeLogicSlot(isOn, logicSlot);
		};
		logicSlot.OnSlotBeginOrEndDragEvent += logicEditorView.SetBeingDragEvent;
		logicSlot.OnSlotPositionChangedEvent += logicEditorView.SwapUserLogicHandler;
		logicSlots.Add(logicSlot);
		if (ShouldBlinkNextNewSlot)
		{
			logicSlot.BlinkSlot();
		}
		ShouldBlinkNextNewSlot = false;
	}

	private void ChangeLogicSlot(bool isSelected, LogicSlot userLogicSlot)
	{
		if (isSelected)
		{
			int index = logicSlots.IndexOf(userLogicSlot);
			logicEditorView.SelectUserLogic(index);
		}
	}

	private void DeleteButtonHandler(LogicSlot userLogicSlot)
	{
		int index = logicSlots.IndexOf(userLogicSlot);
		logicEditorView.DeleteUserLogicHandler(index);
	}

	public void RemoveUserLogicSlot(int index)
	{
		LogicSlot logicSlot = logicSlots[index];
		logicSlots.Remove(logicSlot);
		UnityEngine.Object.Destroy(logicSlot.gameObject);
	}

	public void SwapUserLogicSlot(int oldIndex, int newIndex)
	{
		LogicSlot logicSlot = logicSlots[oldIndex];
		logicSlots.RemoveAt(oldIndex);
		logicSlots.Insert(newIndex, logicSlot);
		logicSlot.transform.SetSiblingIndex(newIndex);
	}

	public void SetSelectedLogicSlot(int index)
	{
		if (index <= logicSlots.Count - 1)
		{
			logicSlots[index].SelectSlot();
		}
	}

	public void LogicSlotNameChanged(Logic logic)
	{
		for (int i = 0; i < logicSlots.Count; i++)
		{
			if (logicSlots[i].Logic == logic)
			{
				logicSlots[i].RefreshSlot();
				break;
			}
		}
	}

	public void SetLogicSlotActiveState(bool isActive, Logic logic)
	{
		for (int i = 0; i < logicSlots.Count; i++)
		{
			if (logicSlots[i].Logic == logic)
			{
				logicSlots[i].SetActiveState(isActive);
				break;
			}
		}
	}
}
