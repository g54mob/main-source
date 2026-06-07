using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ControlsMenuManager : MonoBehaviour
{
	public static ControlsMenuManager Singleton;

	[SerializeField]
	private RebindActionButton[] allRebindActionButtons;

	[SerializeField]
	private GameObject pressKeyToRebindPanel;

	private Button rebindButtonWeLastClicked;

	private bool isRebindPanelActive;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Singleton = this;
		Object.DontDestroyOnLoad(base.gameObject);
		LoadUserRebinds();
	}

	private void Start()
	{
		HidePressKeyToRebindPanel();
		StartCoroutine(WaitABitThenUpdateAllBindingTexts());
	}

	private IEnumerator WaitABitThenUpdateAllBindingTexts()
	{
		yield return new WaitForSeconds(1f);
		UpdateAllRebindKeyButtonDisplayTextToMatchTheirBindings();
	}

	private void Update()
	{
		isRebindPanelActive = pressKeyToRebindPanel.activeSelf;
	}

	public bool GetIsRebindMenuActive()
	{
		return isRebindPanelActive;
	}

	public void RemapButton_WaitAFrame(int _actionIndex)
	{
		InputAction inputAction = null;
		int num = -1;
		bool flag = false;
		RebindActionButton rab = rebindButtonWeLastClicked.GetComponent<RebindActionButton>();
		if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.keyboard)
		{
			flag = false;
		}
		else if (InputManager.Singleton.lastUsedControllerType == InputManager.ControllerType.controller)
		{
			flag = true;
		}
		if (rab.GetIsMovementAxis())
		{
			num = rab.GetAdditionalIndex();
		}
		switch (_actionIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Movement;
			break;
		case 4:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Jump;
			break;
		case 5:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Sprint;
			break;
		case 6:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Throw;
			break;
		case 7:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Drop;
			break;
		case 8:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.PickUpAndUse;
			break;
		case 9:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.BerryBlitz;
			break;
		case 10:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.GapingMaw;
			break;
		case 11:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.AirBlast;
			break;
		case 12:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.MoveHole;
			break;
		case 13:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.UpgradePlantBed;
			break;
		case 14:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Shop;
			break;
		case 15:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Rotate;
			break;
		case 16:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.DestroyBuildable;
			break;
		case 17:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.PardnerCamLook;
			break;
		case 18:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Crouch;
			break;
		case 19:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Escape;
			break;
		case 20:
			inputAction = InputManager.Singleton.inputActions.PlayerActionMap.Movement;
			break;
		}
		if (inputAction == null)
		{
			return;
		}
		InputManager.Singleton.DisableAllActionMaps();
		ShowPressKeyToRebindPanel();
		if (!rab.GetIsMovementAxis())
		{
			if (flag)
			{
				inputAction.PerformInteractiveRebinding(1).WithControlsExcluding("Keyboard").WithCancelingThrough("<Keyboard>/escape")
					.OnComplete(delegate(InputActionRebindingExtensions.RebindingOperation completedCallback)
					{
						SaveUserRebinds();
						completedCallback.Dispose();
						InputManager.Singleton.EnableAllActionMaps();
						rab.UpdateActionBindingButtonText();
						HidePressKeyToRebindPanel();
					})
					.OnCancel(delegate(InputActionRebindingExtensions.RebindingOperation cancelledCallback)
					{
						cancelledCallback.Dispose();
						InputManager.Singleton.EnableAllActionMaps();
						HidePressKeyToRebindPanel();
					})
					.OnMatchWaitForAnother(0.1f)
					.Start();
			}
			else
			{
				inputAction.PerformInteractiveRebinding(0).WithControlsExcluding("<Gamepad>").WithControlsExcluding("<Joystick>")
					.WithControlsExcluding("<Keyboard>/escape")
					.WithCancelingThrough("<Keyboard>/escape")
					.OnComplete(delegate(InputActionRebindingExtensions.RebindingOperation completedCallback)
					{
						SaveUserRebinds();
						completedCallback.Dispose();
						InputManager.Singleton.EnableAllActionMaps();
						rab.UpdateActionBindingButtonText();
						HidePressKeyToRebindPanel();
					})
					.OnCancel(delegate(InputActionRebindingExtensions.RebindingOperation cancelledCallback)
					{
						cancelledCallback.Dispose();
						InputManager.Singleton.EnableAllActionMaps();
						HidePressKeyToRebindPanel();
					})
					.OnMatchWaitForAnother(0.1f)
					.Start();
			}
		}
		else if (flag)
		{
			InputActionRebindingExtensions.RebindingOperation rebindingOperation = inputAction.PerformInteractiveRebinding(num + 6);
			if (rebindingOperation != null)
			{
				rebindingOperation.Cancel();
				InputManager.Singleton.EnableAllActionMaps();
				HidePressKeyToRebindPanel();
			}
		}
		else
		{
			inputAction.PerformInteractiveRebinding(num + 1).WithControlsExcluding("<Gamepad>").WithControlsExcluding("<Joystick>")
				.WithControlsExcluding("<Keyboard>/escape")
				.WithCancelingThrough("<Keyboard>/escape")
				.OnComplete(delegate(InputActionRebindingExtensions.RebindingOperation completedCallback)
				{
					SaveUserRebinds();
					completedCallback.Dispose();
					InputManager.Singleton.EnableAllActionMaps();
					rab.UpdateActionBindingButtonText();
					HidePressKeyToRebindPanel();
				})
				.OnCancel(delegate(InputActionRebindingExtensions.RebindingOperation cancelledCallback)
				{
					cancelledCallback.Dispose();
					InputManager.Singleton.EnableAllActionMaps();
					HidePressKeyToRebindPanel();
				})
				.OnMatchWaitForAnother(0.1f)
				.Start();
		}
	}

	private IEnumerator Remap_WaitAFrame_Coroutine(int _actionIndex)
	{
		yield return null;
		yield return null;
		yield return null;
		RemapButton_WaitAFrame(_actionIndex);
	}

	public void RemapButton(int _actionIndex)
	{
		StartCoroutine(Remap_WaitAFrame_Coroutine(_actionIndex));
	}

	public void ShowPressKeyToRebindPanel()
	{
		pressKeyToRebindPanel.SetActive(value: true);
	}

	public void HidePressKeyToRebindPanel()
	{
		pressKeyToRebindPanel.SetActive(value: false);
	}

	private void SaveUserRebinds()
	{
		string value = InputManager.Singleton.inputActions.SaveBindingOverridesAsJson();
		PlayerPrefs.SetString("controlRebinds", value);
	}

	public void LoadUserRebinds()
	{
		StartCoroutine(WaitASecThenLoadCustomRebinds());
	}

	private IEnumerator WaitASecThenLoadCustomRebinds()
	{
		yield return new WaitForSeconds(0.25f);
		string text = PlayerPrefs.GetString("controlRebinds");
		if (text != string.Empty)
		{
			InputManager.Singleton.inputActions.LoadBindingOverridesFromJson(text);
			UpdateAllRebindKeyButtonDisplayTextToMatchTheirBindings();
		}
		else
		{
			ResetControlsToDefault();
			UpdateAllRebindKeyButtonDisplayTextToMatchTheirBindings();
		}
	}

	public void SetButtonWeJustClicked(Button _button)
	{
		rebindButtonWeLastClicked = _button;
	}

	private void SetRebindButtonText(string _name)
	{
		rebindButtonWeLastClicked.GetComponentInChildren<TMP_Text>().text = _name;
	}

	public void ResetControlsToDefault()
	{
		InputManager.Singleton.inputActions.RemoveAllBindingOverrides();
		SaveUserRebinds();
		UpdateAllRebindKeyButtonDisplayTextToMatchTheirBindings();
	}

	public void UpdateAllRebindKeyButtonDisplayTextToMatchTheirBindings()
	{
		RebindActionButton[] array = allRebindActionButtons;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateActionBindingButtonText();
		}
	}
}
