using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyboardController : ActiveComponent
{
	public Button ConfirmBtn;

	public Button CloseBtn;

	public Button AroundCloseBtn;

	public Button Backspace;

	public InputField input;

	private bool inited;

	private void Awake()
	{
		ConfirmBtn.onClick.AddListener(Close);
		CloseBtn.onClick.AddListener(Close);
		AroundCloseBtn.onClick.AddListener(Close);
		Backspace.onClick.AddListener(BackspaceClick);
	}

	private void BackspaceClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		string text = input.text;
		if (text.Length != 0)
		{
			text = text.Remove(text.Length - 1, 1);
			input.text = text;
		}
	}

	public void SetInput(InputField field)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		input = field;
		base.gameObject.SetActive(value: true);
		input.OnDeselect(new BaseEventData(EventSystem.current));
	}

	private void Update()
	{
		if (!(ActiveComponent.Program == null) && Logic.GetModel() != null && ActiveComponent.Model != null)
		{
			if (!inited)
			{
				ActiveComponent.Model.Keyboard = this;
				inited = true;
				base.gameObject.SetActive(value: false);
				Logic.GetModel().InputDeviceChanged.AddListener(CheckShow);
				CheckShow(Logic.GetModel().CurInputDevice);
			}
			Logic.GetModel().KeyBoardTicks = 2;
			if (ActiveComponent.Program.joyInput.bUp)
			{
				Close();
			}
			else if (ActiveComponent.Program.joyInput.xUp)
			{
				Close();
			}
			else if (ActiveComponent.Program.joyInput.yUp)
			{
				BackspaceClick();
			}
		}
	}

	private void CheckShow(string deviceTag)
	{
		if (base.gameObject.activeSelf)
		{
			_ = deviceTag == "PC";
		}
	}

	public void Close()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		if (input != null)
		{
			input.OnDeselect(new BaseEventData(EventSystem.current));
		}
		base.gameObject.SetActive(value: false);
	}
}
