using I2.Loc;
using UnityEngine;

public class BtnPromptLocParams : MonoBehaviour
{
	public Localize Loc;

	public LocalizationParamsManager Params;

	public string ParamName;

	public bool UseAction;

	public GameActionType TgtAction;

	public bool ShowController;

	public ControllerBtn TgtControllerBtn;

	public bool IsDirectionalFaceBtn;

	public CardinalDir TgtFaceBtnDir;

	public bool ShowSecondControllerBtn;

	public ControllerBtn TgtControllerBtn2;

	public bool IsSecondControllerBtnModifier;

	public bool ShowKeyboard;

	public bool DisableKeyboardResize;

	public bool PrioritizeKeyboardBtn;

	public KeyboardBtn TgtKeyboardBtn;

	public bool ShowSecondKeyboard;

	public KeyboardBtn TgtKeyboardBtn2;

	public string KeyboardOverrideText;

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

	public void SetBtns(KeyboardBtn kbBtn, ControllerBtn controllerBtn)
	{
	}
}
