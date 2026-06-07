using System;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler
{
	public Image Back;

	public Image Flag;

	public GameObject Checkmark;

	public GameObject SteamMark;

	public GameObject LocalizorMark;

	public Text NameLabel;

	public Text Description;

	public Text Author;

	public Text LocalizorLoadText;

	public Button LocalizorLoadButton;

	public Button CreditButton;

	public Color Selected;

	public Color NotSelected;

	[NonSerialized]
	public Localization.Translation Translation;

	public void Init(Localization.Translation tr)
	{
		Translation = tr;
		NameLabel.text = tr.ItemTitle;
		Description.text = tr.GetExtraInfo() + "\n" + tr.MetaData.Description;
		Author.text = tr.MetaData.Author;
		SteamMark.SetActive(tr.MetaData.SteamID.HasValue);
		string value;
		LocalizorMark.SetActive(tr.MetaData.TryGetCustomData("DownloadLink", out value) && tr.MetaData.TryGetCustomData("VersionLink", out value));
		Highlight(Localization.CurrentTranslation == tr);
		Flag.sprite = ObjectDatabase.Instance.TryGetFlag(tr.ItemTitle, tr.MetaData.GetCustomData("Flag"));
		if (Translation.MetaData.Author != null && Translation.MetaData.Author.Length > 9)
		{
			CreditButton.gameObject.SetActive(true);
		}
	}

	public void ShowLocalizor()
	{
		if (SteamManager.Initialized && SteamUtils.IsOverlayEnabled())
		{
			SteamFriends.ActivateGameOverlayToWebPage("https://translate.Coredumping.com");
		}
		else
		{
			Application.OpenURL("https://translate.Coredumping.com");
		}
	}

	public void Credits()
	{
		WindowManager.Instance.ShowMessageBox(Translation.MetaData.Author, true, DialogWindow.DialogType.Information);
	}

	public void DownloadFromLocalizor()
	{
		StartCoroutine(LocalizorButton.DownloadLanguage(Translation.MetaData.GetCustomData("DownloadLink"), NameLabel.text, Translation.MetaData.GetCustomData("VersionLink"), -1, LocalizorLoadText, LocalizorLoadButton));
	}

	public void Highlight(bool sel)
	{
		Checkmark.SetActive(sel);
		Back.color = (sel ? Selected : NotSelected);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		LanguageWindow.Instance.SelectLanguage(Translation);
		UISoundFX.PlaySFX("ButtonClick");
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
