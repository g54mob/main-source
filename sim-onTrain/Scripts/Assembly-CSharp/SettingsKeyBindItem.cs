using System;
using System.Collections;
using Michsky.UI.Heat;
using UnityEngine;
using UnityEngine.UI;

public class SettingsKeyBindItem : MonoBehaviour
{
	public KeyData keyData;

	public KeyBindType keyBindType;

	public SettingsElement settingsElement;

	public ButtonManager keyBindButton;

	public Image selectedKeyBindImage;

	private KeyBindManager keyBindManager;

	private bool isListening;

	private Coroutine pulseCoroutine;

	public static bool IsAnyListening { get; private set; }

	private void Start()
	{
		keyBindManager = GetComponentInParent<KeyBindManager>();
		UpdateKeyText();
		if (settingsElement != null)
		{
			settingsElement.onClick.AddListener(StartListening);
		}
		if (keyBindButton != null)
		{
			keyBindButton.onClick.AddListener(StartListening);
		}
	}

	private void OnDisable()
	{
		if (isListening)
		{
			StopListening(assigned: false);
		}
	}

	private void Update()
	{
		if (!isListening)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			StopListening(assigned: false);
			return;
		}
		foreach (KeyCode value in Enum.GetValues(typeof(KeyCode)))
		{
			if (value != KeyCode.Escape && value != KeyCode.Mouse0 && value != KeyCode.Mouse1 && value != KeyCode.Mouse2 && value != KeyCode.Mouse3 && value != KeyCode.Mouse4 && value != KeyCode.Mouse5 && value != KeyCode.Mouse6 && Input.GetKeyDown(value))
			{
				SetCurrentKey(value);
				UpdateKeyText();
				Singleton<UserPrefencesManager>.Instance.SaveKeyBinding(keyBindType, value);
				if (keyBindManager != null)
				{
					keyBindManager.OnKeyAssigned(this, value);
				}
				StopListening(assigned: true);
				break;
			}
		}
	}

	private void StartListening()
	{
		if (!isListening)
		{
			isListening = true;
			IsAnyListening = true;
			keyBindButton.SetText("[...]");
			if (selectedKeyBindImage != null)
			{
				selectedKeyBindImage.gameObject.SetActive(value: true);
				pulseCoroutine = StartCoroutine(PulseAlpha());
			}
		}
	}

	private void StopListening(bool assigned)
	{
		isListening = false;
		StartCoroutine(ResetListeningFlag());
		if (pulseCoroutine != null)
		{
			StopCoroutine(pulseCoroutine);
			pulseCoroutine = null;
		}
		if (selectedKeyBindImage != null)
		{
			selectedKeyBindImage.gameObject.SetActive(value: false);
		}
		if (!assigned)
		{
			UpdateKeyText();
		}
	}

	private IEnumerator ResetListeningFlag()
	{
		yield return null;
		IsAnyListening = false;
	}

	private IEnumerator PulseAlpha()
	{
		float t = 0f;
		while (true)
		{
			t += Time.unscaledDeltaTime * 2f;
			float t2 = (Mathf.Sin(t * MathF.PI) + 1f) / 2f;
			t2 = Mathf.Lerp(0.2f, 1f, t2);
			Color color = selectedKeyBindImage.color;
			color.a = t2;
			selectedKeyBindImage.color = color;
			yield return null;
		}
	}

	public void UpdateKeyText()
	{
		if (!(keyData == null) && !(keyBindButton == null))
		{
			KeyCode currentKey = GetCurrentKey();
			keyBindButton.SetText("[" + KeyCodeToDisplayString(currentKey) + "]");
		}
	}

	public KeyCode GetCurrentKey()
	{
		return keyBindType switch
		{
			KeyBindType.InteractKey => keyData.InteractKey, 
			KeyBindType.AddFuelKey => keyData.AddFuelKey, 
			KeyBindType.InventoryKey => keyData.InventoryKey, 
			KeyBindType.BuildKey => keyData.BuildKey, 
			KeyBindType.RadialSelectMenuKey => keyData.RadialSelectMenuKey, 
			KeyBindType.RotateKey => keyData.RotateKey, 
			KeyBindType.StoryPanelKey => keyData.StoryPanelKey, 
			KeyBindType.PushToTalkKey => keyData.PushToTalkKey, 
			_ => KeyCode.None, 
		};
	}

	public void ClearKey()
	{
		SetCurrentKey(KeyCode.None);
		UpdateKeyText();
		Singleton<UserPrefencesManager>.Instance.SaveKeyBinding(keyBindType, KeyCode.None);
	}

	private void SetCurrentKey(KeyCode key)
	{
		if (!(keyData == null))
		{
			switch (keyBindType)
			{
			case KeyBindType.InteractKey:
				keyData.InteractKey = key;
				break;
			case KeyBindType.AddFuelKey:
				keyData.AddFuelKey = key;
				break;
			case KeyBindType.InventoryKey:
				keyData.InventoryKey = key;
				break;
			case KeyBindType.BuildKey:
				keyData.BuildKey = key;
				break;
			case KeyBindType.RadialSelectMenuKey:
				keyData.RadialSelectMenuKey = key;
				break;
			case KeyBindType.RotateKey:
				keyData.RotateKey = key;
				break;
			case KeyBindType.StoryPanelKey:
				keyData.StoryPanelKey = key;
				break;
			case KeyBindType.PushToTalkKey:
				keyData.PushToTalkKey = key;
				break;
			case (KeyBindType)2:
				break;
			}
		}
	}

	private string KeyCodeToDisplayString(KeyCode key)
	{
		return key switch
		{
			KeyCode.Mouse0 => "LMB", 
			KeyCode.Mouse1 => "RMB", 
			KeyCode.Mouse2 => "MMB", 
			KeyCode.Return => "Enter", 
			KeyCode.Escape => "ESC", 
			KeyCode.BackQuote => "~", 
			KeyCode.Tab => "Tab", 
			KeyCode.Space => "Space", 
			KeyCode.LeftShift => "L-Shift", 
			KeyCode.RightShift => "R-Shift", 
			KeyCode.LeftControl => "L-Ctrl", 
			KeyCode.RightControl => "R-Ctrl", 
			KeyCode.LeftAlt => "L-Alt", 
			KeyCode.RightAlt => "R-Alt", 
			KeyCode.CapsLock => "CapsLock", 
			_ => key.ToString().ToUpper(), 
		};
	}
}
