using System;
using UnityEngine;
using UnityEngine.UI;

public class InputButton : MonoBehaviour
{
	public Button button;

	public RawImage[] Mods;

	public Text label;

	private bool Active;

	public bool Alt;

	public InputController.Keys Key;

	private void Start()
	{
		UpdateText();
	}

	public void ToggleInput()
	{
		if (Active)
		{
			Active = false;
			UpdateText();
		}
		else
		{
			Active = true;
			label.text = "KeyBindingHint".Loc();
		}
	}

	public void UpdateText()
	{
		label.text = InputController.GetKeyBindString(Key, Alt);
		bool[] mods = InputController.GetMods(Key, Alt);
		for (int i = 0; i < mods.Length; i++)
		{
			Mods[i].gameObject.SetActive(mods[i]);
		}
	}

	private void Update()
	{
		if (!Active)
		{
			return;
		}
		bool flag = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
		bool flag2 = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
		bool flag3 = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		bool flag4 = Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand);
		bool key = Input.GetKey(KeyCode.AltGr);
		Mods[0].gameObject.SetActive(flag);
		Mods[1].gameObject.SetActive(flag2);
		Mods[2].gameObject.SetActive(flag3);
		Mods[3].gameObject.SetActive(flag4);
		if (Input.GetKey(KeyCode.Escape))
		{
			if (Alt)
			{
				InputController.BindKey(Key, KeyCode.Escape, true, true, InputController.Modifiers.NONE);
				Options.SaveToFile();
			}
			foreach (InputButton inputButton in OptionsWindow.Instance.InputButtons)
			{
				inputButton.UpdateText();
			}
			Active = false;
		}
		else
		{
			if (!Input.anyKey)
			{
				return;
			}
			bool flag5 = InputController.CanBeModifier(Key);
			KeyCode? keyPressed = GetKeyPressed(flag5);
			if (keyPressed.HasValue)
			{
				InputController.BindKey(Key, keyPressed.Value, Alt, true, !flag5 && flag, !flag5 && flag2, !flag5 && flag3, !flag5 && flag4);
				foreach (InputButton inputButton2 in OptionsWindow.Instance.InputButtons)
				{
					inputButton2.UpdateText();
				}
				Options.SaveToFile();
				Active = false;
			}
			else if (!flag && !flag2 && !flag3 && !flag4 && !key)
			{
				WindowManager.SpawnDialog("KeyBindError".Loc(), true, DialogWindow.DialogType.Error);
				UpdateText();
				Active = false;
			}
		}
	}

	private KeyCode? GetKeyPressed(bool canBeModifier)
	{
		foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
		{
			KeyCode keyCode = value;
			if ((canBeModifier || (keyCode != KeyCode.LeftControl && keyCode != KeyCode.RightControl && keyCode != KeyCode.LeftShift && keyCode != KeyCode.RightShift && keyCode != KeyCode.LeftAlt && keyCode != KeyCode.RightAlt && keyCode != KeyCode.LeftCommand && keyCode != KeyCode.RightCommand && keyCode != KeyCode.AltGr)) && Input.GetKey(keyCode))
			{
				int num = (int)keyCode;
				if (num >= 303 && num <= 309 && num % 2 == 1)
				{
					keyCode = (KeyCode)(num + 1);
				}
				return keyCode;
			}
		}
		return null;
	}
}
