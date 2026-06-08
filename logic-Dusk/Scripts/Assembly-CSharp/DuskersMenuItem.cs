using System;
using UnityEngine;

public class DuskersMenuItem
{
	public enum MenuTypeEnum
	{
		Standard = 0,
		Slider = 1,
		MultiItemSlider = 2
	}

	public delegate void MenuItemSelection(DuskersMenuItem item);

	public Rect WindowRect;

	public string Label { get; private set; }

	public string Description { get; set; }

	public KeyCode ShortcutKey { get; private set; }

	public KeyCode ShortcutKeyIncrease { get; private set; }

	public KeyCode ShortcutKeyDecrease { get; private set; }

	public string ShortcutKeyIncreaseMappedKey { get; private set; }

	public string ShortcutKeyDecreaseMappedKey { get; private set; }

	public Action SelectAction { get; private set; }

	public MenuItemSelection SelectActionIncrease { get; private set; }

	public MenuItemSelection SelectActionDecrease { get; private set; }

	public int MenuIndex { get; private set; }

	public float TopMargin { get; private set; }

	public float TextWidth { get; set; }

	public string TextValue { get; set; }

	public float SliderValue { get; set; }

	public float SliderValueFactor { get; set; }

	public float SliderStepSize { get; set; }

	public Color OverridenColor { get; set; }

	public bool SpecialHighlight { get; set; }

	public bool Hidden { get; set; }

	public bool Disabled { get; set; }

	public MenuTypeEnum MenuType { get; private set; }

	public DuskersMenuItem(string label, KeyCode key, Action action, int menuIndex)
		: this(label, key, action, menuIndex, false)
	{
	}

	public DuskersMenuItem(string label, KeyCode key, Action action, int menuIndex, bool disabled)
		: this(label, key, action, menuIndex, 0f, disabled)
	{
	}

	public DuskersMenuItem(string label, KeyCode key, Action action, int menuIndex, float topMargin, bool disabled)
		: this(label, menuIndex, MenuTypeEnum.Standard, disabled)
	{
		ShortcutKey = key;
		SelectAction = action;
		TopMargin = topMargin;
	}

	public DuskersMenuItem(string label, float sliderValue, KeyCode keyShortcut, string keyIncreaseMapped, string keyDecreaseMapped, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex)
		: this(label, sliderValue, 1f, 0.035f, keyShortcut, KeyCode.None, KeyCode.None, actionIncrease, actionDecrease, menuIndex)
	{
		ShortcutKeyIncreaseMappedKey = keyIncreaseMapped;
		ShortcutKeyDecreaseMappedKey = keyDecreaseMapped;
	}

	public DuskersMenuItem(string label, float sliderValue, KeyCode keyShortcut, KeyCode keyIncrease, KeyCode keyDecrease, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex)
		: this(label, sliderValue, 1f, 0.035f, keyShortcut, keyIncrease, keyDecrease, actionIncrease, actionDecrease, menuIndex)
	{
	}

	public DuskersMenuItem(string label, float sliderValue, float sliderValueFactor, KeyCode keyShortcut, string keyIncreaseMapped, string keyDecreaseMapped, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex)
		: this(label, sliderValue, sliderValueFactor, 0.035f, keyShortcut, KeyCode.None, KeyCode.None, actionIncrease, actionDecrease, menuIndex)
	{
		ShortcutKeyIncreaseMappedKey = keyIncreaseMapped;
		ShortcutKeyDecreaseMappedKey = keyDecreaseMapped;
	}

	public DuskersMenuItem(string label, float sliderValue, float sliderValueFactor, KeyCode keyShortcut, KeyCode keyIncrease, KeyCode keyDecrease, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex)
		: this(label, sliderValue, sliderValueFactor, 0.035f, keyShortcut, keyIncrease, keyDecrease, actionIncrease, actionDecrease, menuIndex)
	{
	}

	public DuskersMenuItem(string label, float sliderValue, float sliderValueFactor, float sliderStepSize, KeyCode keyShortcut, KeyCode keyIncrease, KeyCode keyDecrease, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex)
		: this(label, sliderValue, sliderValueFactor, sliderStepSize, keyShortcut, keyIncrease, keyDecrease, actionIncrease, actionDecrease, menuIndex, false)
	{
	}

	public DuskersMenuItem(string label, float sliderValue, float sliderValueFactor, float sliderStepSize, KeyCode keyShortcut, KeyCode keyIncrease, KeyCode keyDecrease, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex, bool disabled)
		: this(label, menuIndex, MenuTypeEnum.Slider, disabled)
	{
		SliderValue = sliderValue;
		SliderValueFactor = sliderValueFactor;
		SliderStepSize = sliderStepSize;
		ShortcutKey = keyShortcut;
		ShortcutKeyIncrease = keyIncrease;
		ShortcutKeyDecrease = keyDecrease;
		SelectActionIncrease = actionIncrease;
		SelectActionDecrease = actionDecrease;
	}

	public DuskersMenuItem(string label, KeyCode keyShortcut, string keyIncreaseMapped, string keyDecreaseMapped, Action action, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex)
		: this(label, keyShortcut, KeyCode.None, KeyCode.None, action, actionIncrease, actionDecrease, menuIndex, false)
	{
		ShortcutKeyIncreaseMappedKey = keyIncreaseMapped;
		ShortcutKeyDecreaseMappedKey = keyDecreaseMapped;
	}

	public DuskersMenuItem(string label, KeyCode keyShortcut, KeyCode keyIncrease, KeyCode keyDecrease, Action action, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex)
		: this(label, keyShortcut, keyIncrease, keyDecrease, action, actionIncrease, actionDecrease, menuIndex, false)
	{
	}

	public DuskersMenuItem(string label, KeyCode keyShortcut, string keyIncreaseMapped, string keyDecreaseMapped, Action action, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex, bool disabled)
		: this(label, keyShortcut, KeyCode.None, KeyCode.None, action, actionIncrease, actionDecrease, menuIndex, disabled)
	{
		ShortcutKeyIncreaseMappedKey = keyIncreaseMapped;
		ShortcutKeyDecreaseMappedKey = keyDecreaseMapped;
	}

	public DuskersMenuItem(string label, KeyCode keyShortcut, KeyCode keyIncrease, KeyCode keyDecrease, Action action, MenuItemSelection actionIncrease, MenuItemSelection actionDecrease, int menuIndex, bool disabled)
		: this(label, menuIndex, MenuTypeEnum.MultiItemSlider, disabled)
	{
		ShortcutKey = keyShortcut;
		ShortcutKeyIncrease = keyIncrease;
		ShortcutKeyDecrease = keyDecrease;
		SelectAction = action;
		SelectActionIncrease = actionIncrease;
		SelectActionDecrease = actionDecrease;
	}

	private DuskersMenuItem(string label, int menuIndex, MenuTypeEnum menuType, bool disabled)
	{
		Label = label;
		MenuIndex = menuIndex;
		MenuType = menuType;
		Disabled = disabled;
	}
}
