using System.Collections;
using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.UI;

public class StartupsControl : ActiveComponent
{
	[SceneBind("CreateStartupButton")]
	private Button createNew;

	[SceneBind("StartupText")]
	private Text StartupsText;

	[SceneBind("StartupText")]
	private Button StartupsBtn;

	[SceneBind("Arrow")]
	private RectTransform Arrow;

	[SceneBind("Blocks")]
	private RectTransform Blocks;

	[SceneBind("AttentionDelete/Hide")]
	public Toggle HideAcceptDelete;

	[SceneBind("AttentionDelete/Accept")]
	private Button AcceptStartupDelete;

	[SceneBind("AttentionDelete/Cancel")]
	private Button CancelStartupdelete;

	[SceneBind("AttentionDelete")]
	public Image AttentionDelete;

	[SceneBind("AddDay")]
	public Button AddDay;

	[SceneBind("GrayLayer")]
	public Image GrayLayer;

	[SceneBind("AttentionDelete/Sell")]
	private Text Sell;

	private Image _loadingDisabledImage;

	private List<GameObject> blocks = new List<GameObject>();

	public List<GameObject> startups = new List<GameObject>();

	private int maxStartups = 4;

	private GameObject StartupPrefab;

	private Construction construction;

	private int curIdDelete;

	private IEnumerator WaitForUserAction()
	{
		yield return StartCoroutine(construction.WaitForUserAction());
	}

	private void DeleteStartupClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		int num = (int)((float)ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.PlayersShares * ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.ShareSellCoef * ((float)ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.BaseMoney / (float)(ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.PlayersShares + ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.SharesCou)));
		ActiveComponent.Model.P.Money += num;
		ActiveComponent.Model.P.removedStartups.Add(ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.KeyName);
		Logic.SendAnalytics("ALL_STARTUP_EXIT", new Dictionary<string, object>
		{
			{
				"keyName",
				ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.KeyName
			},
			{ "status", "sold" },
			{ "money", num },
			{
				"patch",
				ActiveComponent.Model.P.Startups[curIdDelete].patch
			},
			{
				"test runs",
				ActiveComponent.Model.P.Startups[curIdDelete].testRunsInStartup
			},
			{
				"global time in startup",
				ActiveComponent.Model.P.Startups[curIdDelete].timeInStartup
			},
			{
				"days",
				Logic.GetDay() - ActiveComponent.Model.P.Startups[curIdDelete].startDay
			}
		});
		StartupStat startupStat = ActiveComponent.Model.P.startupsStatsString[ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.KeyName];
		startupStat.exitMoney = num;
		int daysUntilExit = Logic.GetDay() - ActiveComponent.Model.P.Startups[curIdDelete].startDay;
		startupStat.daysUntilExit = daysUntilExit;
		ActiveComponent.Model.P.Startups.RemoveAt(curIdDelete);
		ActiveComponent._controller._startupView.Redraw();
		AttentionDelete.gameObject.SetActive(value: false);
		ActiveComponent.Program.cursor.SetPosition(AcceptStartupDelete.transform.position);
		Logic.UpdateGameSaves();
	}

	private void DeleteStartupCancel()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		AttentionDelete.gameObject.SetActive(value: false);
	}

	public void DeleteClick(int id)
	{
		AttentionDelete.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		curIdDelete = id;
		if (ActiveComponent.Model.P.hideDeleteStartup == 1)
		{
			DeleteStartupClick();
			return;
		}
		ActiveComponent.Program.cursor.SetPosition(AcceptStartupDelete.transform.position);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		AttentionDelete.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
		Sell.text = TextResources.GetString("DELETESTARTUPWARNING").Replace("%NUM", Logic.ColorTransform("MONEY", (int)((float)ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.PlayersShares * ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.ShareSellCoef * ((float)ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.BaseMoney / (float)(ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.PlayersShares + ActiveComponent.Model.P.Startups[curIdDelete].baseStartup.SharesCou))) + "$"));
	}

	private void HideDeleteClick(bool click)
	{
		if (click)
		{
			ActiveComponent.Model.P.hideDeleteStartup = 1;
		}
		else
		{
			ActiveComponent.Model.P.hideDeleteStartup = 0;
		}
		Logic.UpdateGameSaves();
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		StartupsBtn.onClick.AddListener(ChangeShowState);
		AddDay.onClick.AddListener(ActiveComponent._controller.OpenDayAttention);
		for (int i = 0; i < maxStartups; i++)
		{
			blocks.Add(Blocks.transform.Find("Block" + i).gameObject);
		}
		StartupPrefab = Resources.Load("Prefabs/StartupBlock") as GameObject;
		construction = GameObject.Find("ConstructionWindow").GetComponent<Construction>();
		AcceptStartupDelete.onClick.AddListener(DeleteStartupClick);
		CancelStartupdelete.onClick.AddListener(DeleteStartupCancel);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && AttentionDelete.gameObject.activeSelf)
		{
			DeleteStartupCancel();
		}
	}

	public void SetStartupsShowState(bool state)
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Blocks.gameObject.SetActive(state);
		Vector3 one = Vector3.one;
		if (state)
		{
			one.y = -1f;
		}
		Arrow.gameObject.transform.localScale = one;
	}

	private void ChangeShowState()
	{
		SetStartupsShowState(!Blocks.gameObject.activeSelf);
	}

	public void Redraw()
	{
		if (ActiveComponent.Model != null)
		{
			StartupsText.text = Logic.ColorTransform("GREEN", TextResources.GetString("STARTUPS"));
		}
		AttentionDelete.gameObject.SetActive(value: false);
		for (int i = 0; i < startups.Count; i++)
		{
			Object.Destroy(startups[i]);
		}
		startups.Clear();
		for (int j = 0; j < ActiveComponent.Model.P.Startups.Count; j++)
		{
			GameObject gameObject = Object.Instantiate(StartupPrefab, base.transform.position, base.transform.rotation);
			startups.Add(gameObject);
			gameObject.transform.SetParent(blocks[j].transform);
			gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.GetComponent<StartupControl>().Init(ActiveComponent.Model.P.Startups[j]);
			gameObject.GetComponent<StartupControl>().Redraw();
		}
		bool flag = false;
		base.gameObject.SetActive(value: false);
		foreach (Startup startup in ActiveComponent._staticData.Startups)
		{
			if (UnlockGroup.IsUnlocked(startup.ReqUnlockGroups))
			{
				base.gameObject.SetActive(value: true);
			}
		}
		foreach (StartupScheme startup2 in ActiveComponent.Model.P.Startups)
		{
			if (startup2.released == 1)
			{
				flag = true;
			}
		}
		AddDay.interactable = flag;
		GrayLayer.gameObject.SetActive(!flag);
		if (ActiveComponent.Model.P.Startups.Count == 0)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void DayStep()
	{
		for (int i = 0; i < ActiveComponent.Model.P.Startups.Count; i++)
		{
			startups[i].GetComponent<StartupControl>().UpdateScheme(ActiveComponent.Model.P.Startups[i]);
			startups[i].GetComponent<StartupControl>().DayStep();
		}
	}
}
