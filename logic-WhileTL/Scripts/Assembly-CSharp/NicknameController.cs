using System.Collections;
using Localization;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NicknameController : ActiveComponent
{
	[SceneBind("Accept")]
	private Button Accept;

	[SceneBind("Accept/OK")]
	private Image OK;

	[SceneBind("InputField/Show")]
	private Text Show;

	[SceneBind("Used")]
	private Text Used;

	[SceneBind("PS_Text")]
	private Text PS_Text;

	[SceneBind("InputField")]
	private InputField InputField;

	private string last = "";

	private int maxLen = 12;

	private bool flag;

	private Callback<FloatingGamepadTextInputDismissed_t> m_FloatingGamepadTextInputDismissed;

	private bool PromocodeWasFocused;

	private void Start()
	{
	}

	private void AcceptClick()
	{
		if (!ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(AcceptClick);
			return;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.curPreview.showName = Show.text;
		ActiveComponent.Model.P.playerUnit.name = Show.text + TextResources.GetString("@cat.meow");
		flag = true;
		base.gameObject.SetActive(value: false);
		Logic.UpdateGameSaves();
	}

	private void NickChange(string val)
	{
		if (val.Length > maxLen)
		{
			val = last;
		}
		else
		{
			last = val;
		}
		InputField.text = val;
		Show.text = val;
		if (val == "")
		{
			Show.text = "";
		}
		OK.gameObject.SetActive(val != "");
		Accept.gameObject.GetComponent<Button>().enabled = val != "";
		Used.gameObject.SetActive(value: false);
		CheckNick();
	}

	private void CheckNick()
	{
		int num = 0;
		foreach (PreviewData item in ActiveComponent.Model.globalSaves.Preview)
		{
			if (item.showName == Show.text)
			{
				num++;
				break;
			}
		}
		if (num > 0)
		{
			OK.gameObject.SetActive(value: false);
			Used.gameObject.SetActive(value: true);
			Accept.gameObject.GetComponent<Button>().enabled = false;
		}
	}

	public IEnumerator WaitForUserAction()
	{
		while (!flag)
		{
			yield return new WaitForEndOfFrame();
		}
		base.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		flag = false;
		SceneBindContainer.BindObjects(this, base.transform);
		Accept.onClick.AddListener(AcceptClick);
		InputField.onValueChanged.AddListener(NickChange);
		OK.gameObject.SetActive(value: false);
		Accept.gameObject.GetComponent<Button>().enabled = false;
		InputField.Select();
	}

	private void OnFloatingGamepadTextInputDismissed(FloatingGamepadTextInputDismissed_t pCallback)
	{
		string pchText = string.Empty;
		uint cchText = 0u;
		SteamUtils.GetEnteredGamepadTextInput(out pchText, cchText);
		InputField.text = pchText;
		InputField.OnDeselect(new BaseEventData(EventSystem.current));
	}

	public void Redraw()
	{
		InputField.text = ActiveComponent.Model.curPreview.saveName;
		InputField.Select();
		ActiveComponent.Program.cursor.SetPosition(InputField.transform.position);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return) && InputField.text.Length > 0)
		{
			AcceptClick();
		}
		if (!InputField.gameObject.activeSelf)
		{
			return;
		}
		if (Logic.IsSteamDeckRunning())
		{
			bool isFocused = InputField.isFocused;
			if (isFocused && !PromocodeWasFocused)
			{
				SteamUtils.ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeSingleLine, 0, 0, 0, 0);
			}
			if (isFocused != PromocodeWasFocused)
			{
				PromocodeWasFocused = isFocused;
			}
		}
		if (!Logic.IsSteamDeckRunning() && (ActiveComponent.Model.CurInputDeviceIsController || ActiveComponent.Model.globalSaves.ForcedVisualKeyBoard))
		{
			bool isFocused2 = InputField.isFocused;
			if (isFocused2 && !PromocodeWasFocused)
			{
				ActiveComponent.Model.Keyboard.SetInput(InputField);
			}
			if (isFocused2 != PromocodeWasFocused)
			{
				PromocodeWasFocused = isFocused2;
			}
		}
	}
}
