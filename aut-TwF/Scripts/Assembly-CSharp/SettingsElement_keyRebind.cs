using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class SettingsElement_keyRebind : MonoBehaviour
{
	[Header("Action")]
	[SerializeField]
	private InputActionReference[] actions;

	[SerializeField]
	private PlayerController.EInputControlScheme controlScheme;

	[SerializeField]
	private int mainBindingIdx;

	[SerializeField]
	private int secondaryBindingIdx = 1;

	[SerializeField]
	private bool debugPath;

	[Header("References")]
	[SerializeField]
	private TextMeshProUGUI actionNameLabelTMP;

	[SerializeField]
	private GameObject overrideButtonGraphics;

	[SerializeField]
	private TextMeshProUGUI mainBindingTMP;

	[SerializeField]
	private TextMeshProUGUI secondaryBindingTMP;

	[SerializeField]
	private GameObject mainKeyConflictObject;

	[SerializeField]
	private GameObject secondaryKeyConflictObject;

	[SerializeField]
	private Color bindingSetColor;

	[SerializeField]
	private Color bindingNoneColor;

	private KeyRebindingGroup keyRebindingGroup;

	private InputActionRebindingExtensions.RebindingOperation currentRebindingOp;

	private Image mainConflictImage;

	private Image secondaryConflictImage;

	private TooltipComponent_text mainConflictTooltip;

	private TooltipComponent_text secondaryConflictTooltip;

	public KeyRebindingGroup KeyRebindingGroup
	{
		get
		{
			return keyRebindingGroup;
		}
		set
		{
			keyRebindingGroup = value;
		}
	}

	public string BindingDisplayName => actionNameLabelTMP.text;

	public string MainActionBindingPath => actions[0].action.bindings[mainBindingIdx].effectivePath;

	public string SecondaryActionBindingPath => actions[0].action.bindings[secondaryBindingIdx].effectivePath;

	private void Awake()
	{
		mainConflictImage = mainKeyConflictObject.GetComponent<Image>();
		secondaryConflictImage = secondaryKeyConflictObject.GetComponent<Image>();
		mainConflictTooltip = mainKeyConflictObject.GetComponent<TooltipComponent_text>();
		secondaryConflictTooltip = secondaryKeyConflictObject.GetComponent<TooltipComponent_text>();
	}

	private void Start()
	{
		InputSystem.onActionChange += OnActionChange;
		_ = actions[0];
	}

	private void OnEnable()
	{
		UpdateDisplayedBinding();
		StartCoroutine(DelayedCheckConflictsCoroutine());
	}

	private IEnumerator DelayedCheckConflictsCoroutine()
	{
		yield return null;
		CheckConflicts();
	}

	private void OnDestroy()
	{
		InputSystem.onActionChange -= OnActionChange;
	}

	private string GetBindingGroup()
	{
		return controlScheme switch
		{
			PlayerController.EInputControlScheme.None => "Keyboard&Mouse", 
			PlayerController.EInputControlScheme.KeyboardMouse => "Keyboard&Mouse", 
			PlayerController.EInputControlScheme.Gamepad => "Gamepad", 
			_ => "Keyboard&Mouse", 
		};
	}

	private void UpdateDisplayedBinding()
	{
		string bindingDisplayString = actions[0].action.GetBindingDisplayString(mainBindingIdx);
		string bindingDisplayString2 = actions[0].action.GetBindingDisplayString(secondaryBindingIdx);
		if (bindingDisplayString.Trim() != "")
		{
			mainBindingTMP.text = bindingDisplayString;
			mainBindingTMP.color = bindingSetColor;
		}
		else
		{
			mainBindingTMP.text = "-";
			mainBindingTMP.color = bindingNoneColor;
		}
		if (bindingDisplayString2.Trim() != "")
		{
			secondaryBindingTMP.text = bindingDisplayString2;
			secondaryBindingTMP.color = bindingSetColor;
		}
		else
		{
			secondaryBindingTMP.text = "-";
			secondaryBindingTMP.color = bindingNoneColor;
		}
		UpdateOverrideButtonVisibility();
	}

	private void UpdateOverrideButtonVisibility()
	{
		InputBinding inputBinding = actions[0].action.bindings[mainBindingIdx];
		InputBinding inputBinding2 = actions[0].action.bindings[secondaryBindingIdx];
		bool active = (inputBinding.hasOverrides && inputBinding.overridePath != inputBinding.path) || (inputBinding2.hasOverrides && inputBinding2.overridePath != inputBinding2.path);
		overrideButtonGraphics.gameObject.SetActive(active);
	}

	public void StartRebind(int bindingIdx)
	{
		actions[0].action.Disable();
		if (debugPath)
		{
			Debug.Log("Old path: " + actions[0].action.bindings[bindingIdx].effectivePath);
		}
		currentRebindingOp = new InputActionRebindingExtensions.RebindingOperation().WithAction(actions[0]).WithControlsHavingToMatchPath("<Keyboard>").WithControlsExcluding("<Mouse>/leftButton")
			.WithControlsExcluding("<Mouse>/rightButton")
			.WithControlsExcluding("<Mouse>/position")
			.WithControlsExcluding("<Mouse>/delta")
			.WithControlsExcluding("<Mouse>/scroll/y")
			.WithControlsExcluding("<Pointer>/Press")
			.WithCancelingThrough("<Keyboard>/escape");
		if (actions[0].action.bindings.Count > bindingIdx)
		{
			currentRebindingOp.WithTargetBinding(bindingIdx);
		}
		currentRebindingOp.OnComplete(delegate(InputActionRebindingExtensions.RebindingOperation x)
		{
			for (int i = 1; i < actions.Length; i++)
			{
				if (actions[i].action.bindings.Count > bindingIdx)
				{
					actions[i].action.ApplyBindingOverride(bindingIdx, x.action.bindings[bindingIdx].overridePath);
				}
			}
			if (debugPath)
			{
				Debug.Log("New path: " + x.action.bindings[bindingIdx].overridePath);
			}
			GameManager.instance.PlayerController.CurrentHUD.CloseModalWindow();
			currentRebindingOp.Dispose();
			SettingsController.instance.SaveInputActions();
			UpdateDisplayedBinding();
			actions[0].action.Enable();
		});
		currentRebindingOp.OnCancel(delegate
		{
			GameManager.instance.PlayerController.CurrentHUD.CloseModalWindow();
			currentRebindingOp.Dispose();
			actions[0].action.Enable();
		});
		ShowRebindModalWindow();
		currentRebindingOp.Start();
	}

	private void ShowRebindModalWindow()
	{
		string arg = "\"" + actionNameLabelTMP.text + "\"";
		string bodyMessage = string.Format(LocalizationSettings.StringDatabase.GetTableEntry("UI_Settings", "UI_Settings_modalWindow_rebinding_message").Entry.GetLocalizedString(), arg);
		string localizedString = LocalizationSettings.StringDatabase.GetTableEntry("UI_Common", "UI_Common_cancel").Entry.GetLocalizedString();
		Action yesAction = delegate
		{
			currentRebindingOp.Cancel();
		};
		GameManager.instance.PlayerController.CurrentHUD.ShowModalWindowOneButton(bodyMessage, "", null, yesAction, localizedString);
	}

	public void OnMainBindingPressed()
	{
		StartRebind(mainBindingIdx);
	}

	public void OnSecondaryBindingPressed()
	{
		StartRebind(secondaryBindingIdx);
	}

	public void ResetToDefault()
	{
		InputActionReference[] array = actions;
		foreach (InputActionReference obj in array)
		{
			obj.action.RemoveBindingOverride(mainBindingIdx);
			obj.action.RemoveBindingOverride(secondaryBindingIdx);
		}
		SettingsController.instance.SaveInputActions();
		UpdateDisplayedBinding();
	}

	private void CheckConflicts()
	{
		mainConflictImage.enabled = false;
		secondaryConflictImage.enabled = false;
		string text = LocalizationSettings.StringDatabase.GetTableEntry("UI_Settings", "UI_Settings_rebindingOp_tooltip_conflictsWith").Entry.GetLocalizedString();
		string text2 = LocalizationSettings.StringDatabase.GetTableEntry("UI_Settings", "UI_Settings_rebindingOp_tooltip_conflictsWith").Entry.GetLocalizedString();
		SettingsElement_keyRebind[] keyRebindElements = keyRebindingGroup.KeyRebindElements;
		foreach (SettingsElement_keyRebind settingsElement_keyRebind in keyRebindElements)
		{
			if (!(settingsElement_keyRebind == this))
			{
				if (HasConflictWith(settingsElement_keyRebind, checkSecondaryBinding: false))
				{
					mainConflictImage.enabled = true;
					text = text + "\n- " + settingsElement_keyRebind.BindingDisplayName;
				}
				if (HasConflictWith(settingsElement_keyRebind, checkSecondaryBinding: true))
				{
					secondaryConflictImage.enabled = true;
					text2 = text2 + "\n- " + settingsElement_keyRebind.BindingDisplayName;
				}
			}
		}
		mainConflictTooltip.TooltipText = text.Trim();
		secondaryConflictTooltip.TooltipText = text2.Trim();
	}

	private bool HasConflictWith(SettingsElement_keyRebind otherKeyRebind, bool checkSecondaryBinding)
	{
		if (checkSecondaryBinding)
		{
			if (SecondaryActionBindingPath != "")
			{
				if (!(SecondaryActionBindingPath == otherKeyRebind.MainActionBindingPath))
				{
					return SecondaryActionBindingPath == otherKeyRebind.SecondaryActionBindingPath;
				}
				return true;
			}
			return false;
		}
		if (MainActionBindingPath != "")
		{
			if (!(MainActionBindingPath == otherKeyRebind.MainActionBindingPath))
			{
				return MainActionBindingPath == otherKeyRebind.SecondaryActionBindingPath;
			}
			return true;
		}
		return false;
	}

	private void OnActionChange(object obj, InputActionChange change)
	{
		if (change == InputActionChange.BoundControlsChanged)
		{
			CheckConflicts();
		}
	}
}
