using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuController : MonoBehaviour
{
	public GameObject Panel_Shards;

	public GameObject Panel_Quests;

	public GameObject Panel_Settings;

	public GameObject Panel_Stats;

	public GameObject PanelObject;

	public TMP_Text LastSaveText;

	public TMP_Text TimePlayedValue;

	public HelpPanel HelpPanel;

	private void Start()
	{
	}

	private void Update()
	{
		int num = (int)GameController.Instance.LastSave;
		LastSaveText.text = 60 - num + "s";
		TimePlayedValue.text = GameController.Instance.GetTimePlayedString();
	}

	public void OpenPanel_Shards()
	{
		Music2Controller.Instance.PlaySubMenuMusic();
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_on);
		OpenMenu();
		Shards_OnClick();
		CameraController.Instance.StopMovement();
		Sign.PreventEvent = true;
	}

	public void OpenPanel_Quest()
	{
		Music2Controller.Instance.PlaySubMenuMusic();
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_on);
		OpenMenu();
		Quests_OnClick();
		CameraController.Instance.StopMovement();
		Sign.PreventEvent = true;
	}

	public void OpenPanel_Settings()
	{
		Music2Controller.Instance.PlaySubMenuMusic();
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_on);
		OpenMenu();
		Settings_OnClick();
		CameraController.Instance.StopMovement();
		Sign.PreventEvent = true;
	}

	public void OpenPanel_Book()
	{
		Music2Controller.Instance.PlaySubMenuMusic();
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_on);
		OpenMenu();
		Books_OnClick();
		CameraController.Instance.StopMovement();
		Sign.PreventEvent = true;
	}

	public void Shards_OnClick()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		Panel_Shards.SetActive(value: true);
		Panel_Quests.SetActive(value: false);
		Panel_Settings.SetActive(value: false);
		Panel_Stats.SetActive(value: false);
	}

	public void Quests_OnClick()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		Panel_Shards.SetActive(value: false);
		Panel_Quests.SetActive(value: true);
		Panel_Settings.SetActive(value: false);
		Panel_Stats.SetActive(value: false);
	}

	public void Settings_OnClick()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		Panel_Shards.SetActive(value: false);
		Panel_Quests.SetActive(value: false);
		Panel_Settings.SetActive(value: true);
		Panel_Stats.SetActive(value: false);
	}

	public void Stats_OnClick()
	{
		HelpPanel.SetDisplayLogic();
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		Panel_Shards.SetActive(value: false);
		Panel_Quests.SetActive(value: false);
		Panel_Settings.SetActive(value: false);
		Panel_Stats.SetActive(value: true);
	}

	public void Books_OnClick()
	{
		ScreenCanvasController.Instance.HideBookIcon();
		HelpPanel.SetDisplayLogic();
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		Panel_Shards.SetActive(value: false);
		Panel_Quests.SetActive(value: false);
		Panel_Settings.SetActive(value: false);
		Panel_Stats.SetActive(value: true);
		HelpPanel.DisplayDeviceHelp();
	}

	public void Save_Click()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		GameController.Instance.SaveData();
	}

	public void Quit_OnClick()
	{
		Music2Controller.Instance.StopSubMenuMusic();
		Sign.PreventEvent = false;
		SceneManager.LoadScene("MainMenu");
	}

	public void Close_OnClick()
	{
		SaveManager.SaveAppData();
		Music2Controller.Instance.StopSubMenuMusic();
		base.gameObject.SetActive(value: false);
		CameraController.Instance.StartMovement();
		Sign.PreventEvent = false;
	}

	private void OpenMenu()
	{
		PanelObject.transform.localScale = Vector3.zero;
		base.gameObject.SetActive(value: true);
		PanelObject.transform.DOScale(1f, 0.1f);
	}
}
