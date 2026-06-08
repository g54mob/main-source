using System.Collections.Generic;
using Dorfromantik;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.InputSystem;

public class RebindingButton : MonoBehaviour
{
	[SerializeField]
	private InputActionReference targetActionReference;

	[SerializeField]
	private string actionKey;

	[SerializeField]
	private GameModeId usedInGameMode = GameModeId.Undefined;

	[SerializeField]
	private string controlScheme = "Mouse & Keyboard";

	[SerializeField]
	private Dorfromantik.InputDevice inputDevice = Dorfromantik.InputDevice.MouseKeyboard;

	[SerializeField]
	private GameObject unassignedWarningIcon;

	[SerializeField]
	private List<string> awaitedInputComposites;

	private InputActionRebindingExtensions.RebindingOperation rebindOperation;

	private Animator animator;

	private InputControl currentControl;

	private InputActionAsset inputActionAsset;

	private RebindingManager rebindingManager;

	private ButtonManager rebindButton;

	private bool waitingForInput;

	public InputAction InputAction => targetActionReference.action;

	public string ActionLocalizationKey => actionKey;

	public GameModeId RelatedGameMode => usedInGameMode;

	private void Awake()
	{
		animator = GetComponentInChildren<Animator>();
		rebindButton = GetComponentInChildren<ButtonManager>();
		rebindingManager = GetComponentInParent<RebindingManager>();
	}

	private void Start()
	{
		LocalizationManager.Instance.OnLanguageChanged += UpdateLanguage;
		Singleton<InputManager>.Instance.OnInputDeviceChanged += DisplayBindingsOnButtonFromInputDeviceChanged;
		UpdateLanguage();
		DisplayBindingsOnButton();
	}

	public void StartRebinding()
	{
		int bindingIndex = InputActionRebindingExtensions.GetBindingIndex(InputAction, controlScheme);
		rebindingManager.StartRebind(this, InputAction, bindingIndex, controlScheme, allCompositeParts: true);
	}

	public void RebindCompleted()
	{
		InputAction.Enable();
		DisplayBindingsOnButton();
		animator.SetBool("shouldStayHighlighted", value: false);
	}

	public void RebindStarted(int inputIndex)
	{
		InputAction.Disable();
		DisplayWaitingForInputOnButton(inputIndex);
		animator.SetBool("shouldStayHighlighted", value: true);
	}

	public void ResetBinding()
	{
		InputAction.Disable();
		Debug.Log("Reset Binding of " + InputAction.name);
		rebindingManager.CancelRebindingOfAction(InputAction);
		rebindingManager.RemoveBindings(InputAction, controlScheme);
		DisplayBindingsOnButton();
		InputAction.Enable();
	}

	private void UpdateLanguage()
	{
		rebindButton.highlightedText.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.H2);
		rebindButton.normalText.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.H2);
	}

	private void DisplayWaitingForInputOnButton(int awaitedInputIndex)
	{
		waitingForInput = true;
		string text = ((awaitedInputComposites.Count <= awaitedInputIndex) ? LocalizationManager.Instance.GetLocalizedValue("settings_controls_waitingForInput", useFallbackText: true) : LocalizationManager.Instance.GetLocalizedValue(awaitedInputComposites[awaitedInputIndex], useFallbackText: true));
		rebindButton.buttonText = "<" + text + ">";
		rebindButton.UpdateUI();
	}

	private void DisplayBindingsOnButtonFromInputDeviceChanged(Dorfromantik.InputDevice obj)
	{
		if (!waitingForInput)
		{
			DisplayBindingsOnButton();
		}
	}

	public void DisplayBindingsOnButton()
	{
		waitingForInput = false;
		string text = KeyBindingUtility.GetBindingString(InputAction, InputBinding.MaskByGroup(controlScheme));
		string richTextAttributeForBinding = KeyBindingUtility.GetRichTextAttributeForBinding(text, showSymbolForEmptyBinding: true, "", -1, -1, inputDevice);
		if (!string.IsNullOrWhiteSpace(richTextAttributeForBinding))
		{
			text = richTextAttributeForBinding;
		}
		if ((bool)LocalizationManager.Instance && LocalizationManager.Instance.Language == Language.ChineseSimplified && controlScheme == "Mouse & Keyboard")
		{
			text = text.Replace("Left", LocalizationManager.Instance.GetLocalizedValue("left"));
			text = text.Replace("Right", LocalizationManager.Instance.GetLocalizedValue("right"));
		}
		rebindButton.buttonText = text;
		rebindButton.UpdateUI();
	}

	private void OnDisable()
	{
		rebindingManager.CancelRebindingOfAction(InputAction);
		RebindCompleted();
	}

	private void OnDestroy()
	{
		if ((bool)Singleton<InputManager>.Instance)
		{
			Singleton<InputManager>.Instance.OnInputDeviceChanged -= DisplayBindingsOnButtonFromInputDeviceChanged;
		}
	}

	public void ShowUnassignedWarning(bool show)
	{
		unassignedWarningIcon.SetActive(show);
	}
}
