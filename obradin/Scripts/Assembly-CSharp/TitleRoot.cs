using System.Collections.Generic;
using UnityEngine;

public class TitleRoot : MonoBehaviour, PageTemplateHost
{
	private enum PageId
	{
		Main = 0,
		Settings = 1,
		Profiles = 2
	}

	private class Page
	{
		public PageId id;

		public PageTemplate template;
	}

	public AudioClip titleAudioClip;

	public AudioClip musicAudioClip;

	public PageTemplate titleOceanPageTemplate;

	public AudioKit audioKit;

	private SettingsMenu settingsMenu;

	private ProfilesMenu profilesMenu;

	private AudioOneShot oceanAudioOneShot;

	private AudioOneShot musicAudioOneShot;

	private float musicStartDelay;

	private string wantLoadSaveId;

	private List<Page> pages = new List<Page>();

	private void Start()
	{
		if (!LocReview.active)
		{
			Settings.Load();
		}
		AudioOneShot.StopAll();
		settingsMenu = GetComponentInChildren<SettingsMenu>(true);
		settingsMenu.gameObject.SetActive(false);
		profilesMenu = GetComponentInChildren<ProfilesMenu>(true);
		profilesMenu.gameObject.SetActive(false);
		oceanAudioOneShot = AudioOneShot.Play(titleAudioClip, true);
		Refresh();
		pages.Add(new Page
		{
			id = PageId.Main,
			template = titleOceanPageTemplate
		});
		pages.Add(new Page
		{
			id = PageId.Settings,
			template = settingsMenu.GetComponent<PageTemplate>()
		});
		pages.Add(new Page
		{
			id = PageId.Profiles,
			template = profilesMenu.GetComponent<PageTemplate>()
		});
		ScreenHelper.Boot();
		musicStartDelay = 10f;
	}

	private void OnEnable()
	{
		wantLoadSaveId = null;
		SettingsMenu.onDone.AddListener(OnSettingsDone);
	}

	private void OnDisable()
	{
		SettingsMenu.onDone.RemoveListener(OnSettingsDone);
		if (oceanAudioOneShot != null)
		{
			oceanAudioOneShot.Stop(2f);
			oceanAudioOneShot = null;
		}
		if (musicAudioOneShot != null)
		{
			musicAudioOneShot.Stop(2f);
			musicAudioOneShot = null;
		}
	}

	private void Update()
	{
		if (wantLoadSaveId != null)
		{
			Monitor.BlackOut(2);
			if ((musicAudioOneShot == null || musicAudioOneShot.done) && (oceanAudioOneShot == null || oceanAudioOneShot.done))
			{
				musicAudioOneShot = null;
				oceanAudioOneShot = null;
				Settings.activeSaveId = wantLoadSaveId;
				SaveData.it.Reset();
				if (SaveData.CanLoad(wantLoadSaveId))
				{
					Game.LoadSave(wantLoadSaveId);
				}
				else
				{
					Game.LoadIntro();
				}
			}
		}
		else if (titleOceanPageTemplate.gameObject.activeSelf && (musicAudioOneShot == null || musicAudioOneShot.done))
		{
			musicStartDelay -= Clock.menu.deltaTime;
			if (musicStartDelay < 0f)
			{
				musicAudioOneShot = AudioOneShot.Play(musicAudioClip, false, 0.75f);
				musicStartDelay = 0f;
			}
		}
		else if (musicStartDelay <= 0f)
		{
			musicStartDelay = 30f;
		}
		if (oceanAudioOneShot != null)
		{
			float num = 1f;
			if (musicAudioOneShot != null && !musicAudioOneShot.done)
			{
				num = 0.1f;
			}
			if (oceanAudioOneShot.volume < num)
			{
				oceanAudioOneShot.volume = Mathf.Min(oceanAudioOneShot.volume + Clock.active.deltaTime, num);
			}
			else
			{
				oceanAudioOneShot.volume = Mathf.Max(oceanAudioOneShot.volume - Clock.active.deltaTime, num);
			}
		}
	}

	public void MoveOffPage(int dir, PageItem sourcePageItem)
	{
	}

	private void Refresh()
	{
		titleOceanPageTemplate.BeginRefresh();
		Dictionary<string, PageItem> pageItemDict = titleOceanPageTemplate.pageItemDict;
		pageItemDict["settings"].visible = true;
		pageItemDict["begin"].visible = true;
		pageItemDict["quit"].visible = true;
		titleOceanPageTemplate.EndRefresh();
	}

	public void OnPageButtonClick(PageItem pageItem)
	{
		switch (pageItem.buttonSettings.actionId)
		{
		case "button-begin":
			audioKit.Play("tap");
			SetPage(PageId.Profiles);
			break;
		case "button-credit":
			audioKit.Play("tap");
			Game.LoadCredits();
			break;
		case "button-settings":
			audioKit.Play("tap");
			SetPage(PageId.Settings);
			break;
		case "button-quit":
			OnClickQuit();
			break;
		}
	}

	public void OnClickBack()
	{
		SetPage(PageId.Main);
	}

	public void OnClickQuit()
	{
		Application.Quit();
	}

	public void OnSettingsDone()
	{
		SetPage(PageId.Main);
	}

	public void OnProfilesDone(string loadSaveId_ = null)
	{
		if (loadSaveId_ != null)
		{
			wantLoadSaveId = loadSaveId_;
			if (musicAudioOneShot != null)
			{
				musicAudioOneShot.Stop(2f);
			}
			if (oceanAudioOneShot != null)
			{
				oceanAudioOneShot.Stop(2f);
			}
			Monitor.BlackOut(2);
		}
		SetPage(PageId.Main);
	}

	private void SetPage(PageId pageId)
	{
		foreach (Page page in pages)
		{
			page.template.gameObject.SetActive(page.id == pageId);
		}
		if (pageId == PageId.Main)
		{
			Refresh();
		}
	}
}
