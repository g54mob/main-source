using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class InputMgr : MonoBehaviour
{
	public static InputMgr I;

	public static readonly int[] kGameActionIds;

	public static readonly string[] kGameActionBtnNames;

	public static readonly string[] kGameActionLabels;

	public static readonly int[] kControllerBtnIds;

	public static readonly string[] kControllerBtnNames;

	public static readonly string[] kControllerBtnLabelsXBox;

	public static readonly string[] kControllerBtnLabelsSwitch;

	public static readonly string[] kControllerBtnLabelsPS4;

	public static string[] kKeyboardBtnNames;

	private Rewired.Player _player;

	public InputType LastControlType;

	[NonSerialized]
	public JoypadType LastJoypadType;

	public SwitchControllerMode SwitchCtrlMode;

	public DelegateUtl.NoArgsEvent OnInputTypeChanged;

	public DelegateUtl.NoArgsEvent OnBtnRemapped;

	public DelegateUtl.NoArgsEvent OnControllerDisconnected;

	private bool _isInputBConsumed;

	private bool _isInputAConsumed;

	private ControllerBtn[] _controllerBtnMapping;

	private JoypadType _mappedJoypadType;

	private int[] _btnIdentifierIds;

	private List<KeyboardBtn>[] _kbBtnMapping;

	private List<KeyboardBtn>[] _kbBtnMappingMinus;

	private Joystick _lastJoystick;

	private JoystickMap _lastJoystickGameMap;

	private KeyboardMap _lastKeyboardGameMap;

	private MouseMap _lastMouseGameMap;

	public JoypadType ForcedJoypadType;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnApplicationPause(bool pause)
	{
	}

	public Rewired.Player GetRewiredPlayer()
	{
		return null;
	}

	public bool IsAnyBtnDown()
	{
		return false;
	}

	public bool IsAnyBtnHeld()
	{
		return false;
	}

	public bool IsAnyBtnUp()
	{
		return false;
	}

	public bool IsBtnDown(ControllerBtn t)
	{
		return false;
	}

	public ControllerBtn GetFaceBtn(CardinalDir dir)
	{
		return default(ControllerBtn);
	}

	public bool IsFaceBtnDown(CardinalDir dir)
	{
		return false;
	}

	public bool IsBtnComboDown(ControllerBtn b1, ControllerBtn b2)
	{
		return false;
	}

	public bool IsBtnHeld(ControllerBtn t)
	{
		return false;
	}

	public bool IsBtnUp(ControllerBtn t, bool ignoreConsume = false)
	{
		return false;
	}

	public bool IsFaceBtnUp(CardinalDir dir)
	{
		return false;
	}

	public bool IsInputAConsumed()
	{
		return false;
	}

	public bool IsInputBConsumed()
	{
		return false;
	}

	public void ConsumeInputA()
	{
	}

	public void ConsumeInputB()
	{
	}

	public bool IsCancelBtnPressed()
	{
		return false;
	}

	public bool IsBtnDown(GameActionType t)
	{
		return false;
	}

	public bool IsBtnHeld(GameActionType t)
	{
		return false;
	}

	public bool IsBtnUp(GameActionType t)
	{
		return false;
	}

	public float GetAxis(GameActionType t)
	{
		return 0f;
	}

	public float GetAxis(ControllerBtn t)
	{
		return 0f;
	}

	public JoypadType GetJoypadFromControllerName(string name)
	{
		return default(JoypadType);
	}

	public SwitchControllerMode GetSwitchControllerModeFromName(string name)
	{
		return default(SwitchControllerMode);
	}

	private void OnLastActiveControllerChanged(Rewired.Player player, Controller controller)
	{
	}

	public GameActionType GetActionTypeFromName(string actionName)
	{
		return default(GameActionType);
	}

	public void RefreshControllerMap(bool force)
	{
	}

	public void RefreshKeyboardMap(bool force, GameActionType tgtAction = GameActionType.kNum, Pole axisContrib = Pole.Positive, int idx = 0, KeyboardBtn newBtn = KeyboardBtn.kNum)
	{
	}

	private void FillKeyboardAEM(ActionElementMap aem)
	{
	}

	public ControllerBtn GetControllerBtnForAction(GameActionType t, Pole axis = Pole.Positive)
	{
		return default(ControllerBtn);
	}

	public KeyboardBtn GetKeyboardBtnFromName(string kbName)
	{
		return default(KeyboardBtn);
	}

	public KeyboardBtn GetKeyboardBtnForActionPrioritized(GameActionType at, Pole axisContrib, KeyboardBtn prioritizeIfMapped)
	{
		return default(KeyboardBtn);
	}

	public KeyboardBtn GetKeyboardBtnForAction(GameActionType at, Pole axisContrib)
	{
		return default(KeyboardBtn);
	}

	public KeyboardBtn GetRemapperKeyboardBtnForAction(GameActionType at, Pole axisContrib)
	{
		return default(KeyboardBtn);
	}

	public KeyboardBtn GetRemapper2ndKeyboardBtnForAction(GameActionType at, Pole axisContrib)
	{
		return default(KeyboardBtn);
	}

	public ControllerBtn GetBtnFromPollingInfo(ControllerPollingInfo pollInfo)
	{
		return default(ControllerBtn);
	}

	public ElementAssignment CreateElementAssignmentForAction(GameActionType action, Pole axisContrib, ControllerPollingInfo pollInfo)
	{
		return default(ElementAssignment);
	}

	private void DeleteKBAEMsWithActionAndPole(int idx, ControllerMap map, GameActionType action, Pole pole, KeyboardBtn newBtn, bool deletePrevMappedBtn = true)
	{
	}

	private void DeleteControllerAEMsWithActionAndPole(ControllerMap map, GameActionType action, Pole pole)
	{
	}

	public void AssignBtnToAction(int mapIdx, GameActionType action, Pole axisContrib, ControllerPollingInfo pollInfo)
	{
	}

	private ElementAssignment CreateElementAssignment(ControllerBtn btn, GameActionType action)
	{
		return default(ElementAssignment);
	}

	public void RevertControlMappingToDefault()
	{
	}

	public void Vibrate(float intensity, float len)
	{
	}

	public void RunHaptics(float intensity)
	{
	}

	public void StopVibration()
	{
	}

	public bool IsPointerOverGameObject()
	{
		return false;
	}

	private void OnReinputControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
	}
}
