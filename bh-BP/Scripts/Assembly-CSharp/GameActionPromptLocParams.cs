using I2.Loc;
using Rewired;
using UnityEngine;

public class GameActionPromptLocParams : MonoBehaviour
{
	public Localize Loc;

	public LocalizationParamsManager Params;

	public string ParamName;

	public bool ShowController;

	public bool ShowKeyboard;

	public bool OverrideKeyboardActionWithBtn;

	public GameActionType TgtAction;

	public Pole TgtPole;

	public bool ShowSecondActionController;

	public bool ShowSecondActionKeyboard;

	public GameActionType TgtAction2;

	public ControllerBtn FallbackControllerBtn;

	public ControllerBtn FallbackControllerBtn2;

	public KeyboardBtn FallbackKbBtn;

	public KeyboardBtn FallbackKbBtn2;

	private bool _inited;

	private void Reset()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnInputChanged()
	{
	}

	public void SetAction(GameActionType at)
	{
	}

	private void OnBtnRemapped()
	{
	}
}
