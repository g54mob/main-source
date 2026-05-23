using System.Collections.Generic;
using I2.Loc;
using Rewired;
using TMPro;
using UnityEngine;

public class ControlMapButton : MonoBehaviour
{
	public enum AxisMode
	{
		Button = 0,
		Positive = 1,
		Negative = 2
	}

	public TFUITextButton target;

	public GameObject selectionIndicator;

	public TextMeshProUGUI displayKeyboard;

	public TextMeshProUGUI displayMouse;

	public TextMeshProUGUI displayController;

	private AxisMode axisMode;

	private InputAction actionToMap;

	private KeyRebinder targetRebinder;

	private ActionElementMap keyMap;

	private ActionElementMap mouseMap;

	private ActionElementMap joystickMap;

	private string descriptor
	{
		get
		{
			if (axisMode == AxisMode.Positive)
			{
				return actionToMap.name + " Positive";
			}
			if (axisMode == AxisMode.Negative)
			{
				return actionToMap.name + " Negative";
			}
			return actionToMap.name;
		}
	}

	private void Start()
	{
		selectionIndicator.SetActive(value: false);
		target.onApply.AddListener(OnApply);
		target.onSelectionStateChange.AddListener(UpdateSelectionIndicator);
	}

	public void SetData(InputAction _action, KeyRebinder _rebinder, AxisMode _axisMode)
	{
		axisMode = _axisMode;
		targetRebinder = _rebinder;
		actionToMap = _action;
		Refresh();
		target.SetOriginalString(LocalizationManager.GetTermTranslation("Controls/" + descriptor));
	}

	public void Refresh()
	{
		UpdateMappings();
		UpdateLabels();
	}

	private void UpdateMappings()
	{
		keyMap = null;
		mouseMap = null;
		joystickMap = null;
		List<ActionElementMap> list = new List<ActionElementMap>();
		if (targetRebinder.KeyboardMap != null)
		{
			list = new List<ActionElementMap>(targetRebinder.KeyboardMap.GetElementMapsWithAction(actionToMap.id));
		}
		List<ActionElementMap> list2 = new List<ActionElementMap>();
		if (targetRebinder.MouseMap != null)
		{
			list2 = new List<ActionElementMap>(targetRebinder.MouseMap.GetElementMapsWithAction(actionToMap.id));
		}
		List<ActionElementMap> list3 = new List<ActionElementMap>();
		if (targetRebinder.JoystickMap != null)
		{
			list3 = new List<ActionElementMap>(targetRebinder.JoystickMap.GetElementMapsWithAction(actionToMap.id));
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			ActionElementMap actionElementMap = list[num];
			switch (axisMode)
			{
			case AxisMode.Negative:
				if (actionElementMap.axisContribution != Pole.Negative)
				{
					list.RemoveAt(num);
				}
				break;
			case AxisMode.Positive:
				if (actionElementMap.axisContribution != Pole.Positive)
				{
					list.RemoveAt(num);
				}
				break;
			}
		}
		for (int num2 = list2.Count - 1; num2 >= 0; num2--)
		{
			ActionElementMap actionElementMap2 = list2[num2];
			switch (axisMode)
			{
			case AxisMode.Negative:
				if (actionElementMap2.axisContribution != Pole.Negative)
				{
					list2.RemoveAt(num2);
				}
				break;
			case AxisMode.Positive:
				if (actionElementMap2.axisContribution != Pole.Positive)
				{
					list2.RemoveAt(num2);
				}
				break;
			}
		}
		for (int num3 = list3.Count - 1; num3 >= 0; num3--)
		{
			ActionElementMap actionElementMap3 = list3[num3];
			switch (axisMode)
			{
			case AxisMode.Negative:
				if (actionElementMap3.axisContribution != Pole.Negative)
				{
					list3.RemoveAt(num3);
				}
				break;
			case AxisMode.Positive:
				if (actionElementMap3.axisContribution != Pole.Positive)
				{
					list3.RemoveAt(num3);
				}
				break;
			}
		}
		if (list.Count > 0)
		{
			keyMap = list[0];
		}
		if (list2.Count > 0)
		{
			mouseMap = list2[0];
		}
		if (list3.Count > 0)
		{
			joystickMap = list3[0];
		}
	}

	private void UpdateLabels()
	{
		string text = ((keyMap != null) ? InputActionGlyph.GetGlyphFromElementMap(keyMap) : "﹘");
		string text2 = ((mouseMap != null) ? InputActionGlyph.GetGlyphFromElementMap(mouseMap) : "﹘");
		string text3 = ((joystickMap == null) ? "﹘" : InputActionGlyph.GetGlyphFromElementMap(joystickMap));
		displayKeyboard.text = text;
		displayMouse.text = text2;
		displayController.text = text3;
	}

	private void OnApply()
	{
		targetRebinder.TriggerRebind(actionToMap, keyMap, mouseMap, joystickMap, axisMode);
	}

	private void UpdateSelectionIndicator()
	{
		if (target.CurrentState == ThronefallUIElement.SelectionState.Selected)
		{
			selectionIndicator.SetActive(value: true);
		}
		else
		{
			selectionIndicator.SetActive(value: false);
		}
	}
}
