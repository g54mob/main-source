using Localization;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CommunityWindow : ActiveComponent
{
	[SceneBind("SettingsWindow")]
	public Image SettingsSubWindow;

	[SceneBind("PromoLayer/HoverPromo")]
	public Image HoverPromo;

	[SceneBind("PromoLayer/Survey")]
	public Image Survey;

	[SceneBind("PromoLayer/Survey/Accept")]
	public Button SurveyApply;

	[SceneBind("PromoLayer/Survey/Cancel")]
	public Button SurveyCancel;

	[SceneBind("PromoLayer/HoverPromo/HoverText")]
	public Text HoverText;

	[SceneBind("Close")]
	public Button Close;

	[SceneBind("PromoLayer/Check")]
	public Button Check;

	[SceneBind("PromoLayer/GooglePlay")]
	public Button GooglePlay;

	[SceneBind("PromoLayer/Promocode")]
	public InputField Promocode;

	[SceneBind("PromoLayer")]
	public RectTransform PromoLayer;

	private string code;

	private float startTimer = -1000f;

	private bool PromocodeWasFocused;

	private bool init;

	private Callback<FloatingGamepadTextInputDismissed_t> m_FloatingGamepadTextInputDismissed;

	private void CloseSurvey()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.Set(SaveFlags.ShowSurvey);
		Logic.UpdateGlobalSaves();
		Survey.gameObject.SetActive(value: false);
	}

	private void OpenSurvey()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Survey.gameObject.SetActive(value: false);
		ActiveComponent.Model.globalSaves.Set(SaveFlags.ShowSurvey);
		Logic.UpdateGlobalSaves();
		Logic.OpenUrl(TextResources.GetString("SURVEY_URL"));
	}

	public void Redraw()
	{
		ActiveComponent.Model.globalSaves.IsSet(SaveFlags.ShowSurvey);
	}

	private void CloseClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		ActiveComponent.Program.cursor.SetPosition(ActiveComponent.Program.mainMenu.Settings.transform.position);
		base.gameObject.SetActive(value: false);
	}

	private void CheckCode()
	{
		bool flag = Logic.WasPromoCode(code);
		if (Logic.CheckPromoCode(code))
		{
			if (flag)
			{
				HoverText.text = Logic.ColorTransform("WARNING", TextResources.GetString("PROMOWAS"));
			}
			else
			{
				MainMenu component = base.gameObject.transform.parent.GetComponent<MainMenu>();
				component.SettingsWindow.Redraw();
				component.ActiveTheme(ActiveComponent.Model.globalSaves.activeTheme);
				HoverText.text = Logic.GetPromoText(code);
				ActiveComponent.Model.lastCatPromoActivated = true;
			}
			Promocode.text = "";
		}
		else
		{
			HoverText.text = Logic.ColorTransform("BAD", TextResources.GetString("PROMOERROR"));
		}
		startTimer = Time.time;
		HoverPromo.gameObject.SetActive(value: true);
	}

	private void CodeChange(string val)
	{
		code = val.ToLower();
	}

	private void Update()
	{
		if (!base.gameObject.activeSelf)
		{
			return;
		}
		if (init && Promocode.gameObject.activeSelf)
		{
			if (Logic.IsSteamDeckRunning())
			{
				bool isFocused = Promocode.isFocused;
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
				bool isFocused2 = Promocode.isFocused;
				if (isFocused2 && !PromocodeWasFocused)
				{
					ActiveComponent.Model.Keyboard.SetInput(Promocode);
				}
				if (isFocused2 != PromocodeWasFocused)
				{
					PromocodeWasFocused = isFocused2;
				}
			}
			if ((double)(Time.time - startTimer) > 1.5)
			{
				HoverPromo.gameObject.SetActive(value: false);
			}
		}
		if (Input.GetKeyDown(KeyCode.Return) && Promocode.isFocused)
		{
			CheckCode();
		}
	}

	private void OnFloatingGamepadTextInputDismissed(FloatingGamepadTextInputDismissed_t pCallback)
	{
		string pchText = string.Empty;
		uint cchText = 0u;
		SteamUtils.GetEnteredGamepadTextInput(out pchText, cchText);
		Promocode.text = pchText;
		Promocode.OnDeselect(new BaseEventData(EventSystem.current));
	}

	protected override void OnInit()
	{
		init = true;
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		code = "";
		Close.onClick.AddListener(CloseClick);
		Check.onClick.AddListener(CheckCode);
		HoverPromo.gameObject.SetActive(value: false);
		Promocode.onValueChanged.AddListener(CodeChange);
		SurveyApply.onClick.AddListener(OpenSurvey);
		SurveyCancel.onClick.AddListener(CloseSurvey);
		Survey.gameObject.SetActive(value: false);
	}
}
