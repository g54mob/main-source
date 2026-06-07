using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteamReview : ActiveComponent
{
	[SceneBind("RangPage")]
	public RectTransform RangPage;

	[SceneBind("DiscordPage")]
	public RectTransform DiscordPage;

	[SceneBind("DiscordPage4")]
	public RectTransform DiscordPage4;

	[SceneBind("RangPage/Ok")]
	public Button RangPageOk;

	[SceneBind("RangPage/Cancel")]
	public Button RangPageCancel;

	[SceneBind("DiscordPage/Cancel")]
	public Button DiscordPageCancel;

	[SceneBind("DiscordPage4/Cancel")]
	public Button DiscordPage4Cancel;

	[SceneBind("DiscordPage/Discord")]
	public UrlButton Discord;

	[SceneBind("DiscordPage4/Discord")]
	public UrlButton Discord4;

	[SceneBind("DiscordPage/Body")]
	public Text DiscordPageBody;

	[SceneBind("SteamPage")]
	public RectTransform SteamPage;

	[SceneBind("SteamPage/Ok")]
	public Button SteamPageOk;

	[SceneBind("SteamPage/Cancel")]
	public Button SteamPageCancel;

	private int score = -1;

	private List<Image> btns = new List<Image>();

	private void FirstStepAnalytics()
	{
	}

	private void CancelClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		score = -1;
		base.gameObject.SetActive(value: false);
		FirstStepAnalytics();
	}

	private void OkClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		RangPage.gameObject.SetActive(value: false);
		SteamPage.gameObject.SetActive(score == 5);
		FirstStepAnalytics();
		if (score < 5)
		{
			DiscordPage.gameObject.SetActive(score < 4);
			DiscordPage4.gameObject.SetActive(score == 4);
		}
	}

	public void InitRedraw()
	{
		score = -1;
		RangPage.gameObject.SetActive(value: true);
		SteamPage.gameObject.SetActive(value: false);
		DiscordPage.gameObject.SetActive(value: false);
		DiscordPage4.gameObject.SetActive(value: false);
		Redraw();
	}

	private void Redraw()
	{
		RangPageOk.gameObject.SetActive(score > 0);
		for (int i = 0; i < btns.Count; i++)
		{
			if (i >= score)
			{
				btns[i].color = Logic.GetColor("GREY");
				continue;
			}
			Color color = Logic.GetColor("GREEN") / btns.Count * score + Logic.GetColor("RED") / btns.Count * (btns.Count - score);
			color.a = 1f;
			btns[i].color = color;
		}
	}

	private void ClcikOnScore(int score)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		this.score = score;
		Redraw();
	}

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		SteamPage.gameObject.SetActive(value: false);
		RangPage.gameObject.SetActive(value: false);
		DiscordPage.gameObject.SetActive(value: false);
		DiscordPage4.gameObject.SetActive(value: false);
		Discord.Init();
		Discord4.Init();
		for (int i = 0; i < 5; i++)
		{
			Transform transform = RangPage.transform.Find("CAT" + i);
			int newI = i + 1;
			transform.GetComponent<Button>().onClick.AddListener(delegate
			{
				ClcikOnScore(newI);
			});
			btns.Add(transform.GetComponent<Image>());
		}
		RangPageOk.onClick.AddListener(OkClick);
		SteamPageOk.onClick.AddListener(SteamClickOk);
		SteamPageCancel.onClick.AddListener(CancelClick);
		RangPageCancel.onClick.AddListener(CancelClick);
		DiscordPageCancel.onClick.AddListener(CancelClick);
		DiscordPage4Cancel.onClick.AddListener(CancelClick);
		Redraw();
	}

	private void SteamClickOk()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		string url = "steam://openurl/https://store.steampowered.com/app/619150/#review_create";
		if (Steam.IsAvailable())
		{
			Application.OpenURL(url);
		}
		else
		{
			Logic.OpenUrl(url);
		}
		base.gameObject.SetActive(value: false);
	}
}
