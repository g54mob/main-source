using TMPro;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
	[SerializeField]
	private GameObject loadPanel;

	[SerializeField]
	private GameObject createPanel;

	[SerializeField]
	private GameObject createXoPanel;

	[SerializeField]
	private GameObject buttonsPanel;

	[SerializeField]
	private GameObject welcomeText;

	[SerializeField]
	private GameObject newMapText;

	[SerializeField]
	private GameObject allMapsText;

	[Header("Explainer box")]
	[SerializeField]
	private GameObject boxObj;

	[SerializeField]
	private TMP_Text explainerText;

	private void OnEnable()
	{
		if (PersistentFilePath.ins.closeMainMenuOnReload)
		{
			PersistentFilePath.ins.closeMainMenuOnReload = false;
			CloseEntireMainMenu();
		}
		else
		{
			OpenMainPanel();
		}
		HideExplainerBox();
	}

	public void CloseEntireMainMenu()
	{
		CloseAllPanels();
		base.gameObject.SetActive(value: false);
	}

	public void OpenMainPanel()
	{
		CloseAllPanels();
		buttonsPanel.SetActive(value: true);
	}

	public void ShowWelcomeText()
	{
		welcomeText.SetActive(value: true);
		newMapText.SetActive(value: false);
		allMapsText.SetActive(value: false);
	}

	public void ShowNewMapText()
	{
		welcomeText.SetActive(value: false);
		newMapText.SetActive(value: true);
		allMapsText.SetActive(value: false);
	}

	public void ShowAllMapsText()
	{
		welcomeText.SetActive(value: false);
		newMapText.SetActive(value: false);
		allMapsText.SetActive(value: true);
	}

	public void OpenLoadPanel()
	{
		CloseAllPanels();
		loadPanel.SetActive(value: true);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void OpenCreatePanel()
	{
		CloseAllPanels();
		createPanel.SetActive(value: true);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	public void OpenCreateXOPanel()
	{
		CloseAllPanels();
		createXoPanel.SetActive(value: true);
		SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
	}

	private void CloseAllPanels()
	{
		loadPanel.SetActive(value: false);
		createPanel.SetActive(value: false);
		createXoPanel.SetActive(value: false);
		buttonsPanel.SetActive(value: false);
	}

	public void ShowExplainerBox(string key)
	{
		explainerText.text = LocalizationSystem.GetLocalizedValue(key);
		boxObj.SetActive(value: true);
	}

	public void HideExplainerBox()
	{
		explainerText.text = "";
		boxObj.SetActive(value: false);
	}
}
