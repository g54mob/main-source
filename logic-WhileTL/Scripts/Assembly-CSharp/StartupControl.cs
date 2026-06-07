using System.Collections.Generic;
using App.Data;
using Localization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartupControl : ActiveComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SceneBind("HoverShow/AuedienceT")]
	private Text AuedienceT;

	[SceneBind("HoverShow/TypeT")]
	private Text TypeT;

	[SceneBind("HoverShow/AccT")]
	private Text AccT;

	[SceneBind("HoverShow/TotalT")]
	private Text TotalT;

	[SceneBind("HoverShow/ServersT")]
	private Text ServersT;

	[SceneBind("HoverShow/WeekT")]
	private Text WeekT;

	[SceneBind("HoverShow/UsersTotalT")]
	private Text UsersTotalT;

	[SceneBind("HoverShow/WeekUIncT")]
	private Text WeekUIncT;

	[SceneBind("HoverShow")]
	private Image HoverShow;

	[SceneBind("HistogramCanvas/UsersHist")]
	private RectTransform UsersHist;

	[SceneBind("HistogramCanvas/ProfitHist")]
	private RectTransform ProfitHist;

	[SceneBind("InDevelopment")]
	private Image InDevelopment;

	[SceneBind("InDevelopment/InDevText")]
	private Button InDevBtn;

	[SceneBind("Delete")]
	private Button DeleteBtn;

	[SceneBind("StartupName")]
	private Text Name;

	[SceneBind("BaseMoney")]
	private Text BaseMoney;

	[SceneBind("MoneyMax")]
	private Text MoneyMax;

	[SceneBind("UsersMax")]
	private Text UsersMax;

	[SceneBind("Rework")]
	private Button Rework;

	[SceneBind("Patch")]
	private Button Patch;

	[SceneBind("Hype")]
	private Image hypeImage;

	[SceneBind("Hype/Text")]
	private Text hypeText;

	[SceneBind("Delete/YourShareText")]
	private Text yourShareText;

	[SceneBind("Delete/BTN")]
	private Image deleteGray;

	private List<Image> positiveUsersHistList = new List<Image>();

	private List<Image> negativeUserHistList = new List<Image>();

	private List<Image> ProfitHistList = new List<Image>();

	public StartupScheme sch;

	private static float barHeight = 50.5f;

	private bool hover;

	private int weekDays = 7;

	private float timer;

	private List<float> usersDrawed = new List<float>();

	private List<float> moneyDrawed = new List<float>();

	private List<float> failedDrawed = new List<float>();

	private List<float> usersDrawedSpeed = new List<float>();

	private List<float> moneyDrawedSpeed = new List<float>();

	private List<float> failedDrawedSpeed = new List<float>();

	private static Sprite ActiveHypeSprite = null;

	private static Sprite InactiveHypeSprite = null;

	private static Color ActiveHypeColor;

	private static Color InactiveHypeColor = new Color(0.3372549f, 0.40784314f, 0.40784314f);

	private bool move;

	private float moveTimer;

	private bool showCompany = true;

	private float shareTimer = -1f;

	private void Start()
	{
		RectTransform component = base.gameObject.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
		RectTransform component2 = base.gameObject.GetComponent<RectTransform>();
		component.sizeDelta = component2.sizeDelta;
		component.pivot = component2.pivot;
		component.anchorMax = component2.anchorMax;
		component.anchorMin = component2.anchorMin;
		component.anchoredPosition = component2.anchoredPosition;
		component.transform.localPosition = Vector3.zero;
		component.localScale = component2.localScale;
	}

	private static float GetFillAmount(Image bar)
	{
		if (!bar.gameObject.activeSelf)
		{
			return 0f;
		}
		float num = Mathf.Max(0f, bar.GetComponent<RectTransform>().sizeDelta.y / barHeight);
		if (float.IsNaN(num))
		{
			return 0f;
		}
		return num;
	}

	private static void SetFillAmount(Image bar, float value)
	{
		RectTransform component = bar.GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		sizeDelta.y = Mathf.Max(0f, barHeight * value);
		component.sizeDelta = sizeDelta;
		bar.gameObject.SetActive(value: true);
	}

	private static void SetTopFillAmount(Image parent, Image bar, float value)
	{
		SetFillAmount(bar, value);
		Vector3 localPosition = bar.transform.localPosition;
		localPosition.y = Mathf.Max(0f, parent.GetComponent<RectTransform>().sizeDelta.y);
		if (float.IsNaN(localPosition.y))
		{
			localPosition.y = 0f;
		}
		bar.transform.localPosition = localPosition;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		HoverShow.gameObject.SetActive(value: false);
		hover = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HoverShow.gameObject.SetActive(value: false);
		hover = false;
	}

	private void DeleteClick()
	{
		for (int i = 0; i < ActiveComponent.Model.P.Startups.Count; i++)
		{
			if (ActiveComponent.Model.P.Startups[i].baseStartup.KeyName == sch.baseStartup.KeyName)
			{
				ActiveComponent._controller._startupView.DeleteClick(i);
				break;
			}
		}
	}

	public void ReworkClick(bool transitionScreen = true)
	{
		if (transitionScreen && !ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(delegate
			{
				ReworkClick(transitionScreen);
			});
			return;
		}
		ActiveComponent._controller.Tree.gameObject.SetActive(value: false);
		ActiveComponent._controller.ResetRandomEnv();
		ActiveComponent.Model.curStartup = sch.baseStartup;
		ActiveComponent.Model.curStartupInWork = sch;
		ActiveComponent._controller.construction.gameObject.SetActive(value: true);
		ActiveComponent.Model.constructionState = ConstructionState.Startup;
		ActiveComponent._controller.construction.couTest = 0;
		ActiveComponent._controller.construction.OpenWindowInit(ConstructionState.Startup, Logic.GetTaskByKeyName(ActiveComponent.Model.curStartup.TaskKeyName));
	}

	public void UpdateScheme(StartupScheme scheme)
	{
		sch = scheme;
		Redraw();
	}

	public void Init(StartupScheme scheme)
	{
		base.Init();
		positiveUsersHistList.Clear();
		negativeUserHistList.Clear();
		ProfitHistList.Clear();
		usersDrawed.Clear();
		moneyDrawed.Clear();
		failedDrawed.Clear();
		usersDrawedSpeed.Clear();
		moneyDrawedSpeed.Clear();
		failedDrawedSpeed.Clear();
		SceneBindContainer.BindObjects(this, base.transform);
		sch = scheme;
		for (int i = 0; i < weekDays; i++)
		{
			positiveUsersHistList.Add(UsersHist.transform.Find("Hist" + i).GetComponent<Image>());
			negativeUserHistList.Add(positiveUsersHistList[positiveUsersHistList.Count - 1].GetComponentsInChildren<Image>()[1]);
			ProfitHistList.Add(ProfitHist.transform.Find("Hist" + i).GetComponent<Image>());
			if (sch.IsReleased())
			{
				usersDrawed.Add((float)scheme.lastUsers[i] - scheme.lastFailed[i]);
				moneyDrawed.Add(scheme.lastMoney[i]);
				failedDrawed.Add(scheme.lastFailed[i]);
			}
			else
			{
				usersDrawed.Add(0f);
				moneyDrawed.Add(0f);
				failedDrawed.Add(0f);
			}
			usersDrawedSpeed.Add(0f);
			moneyDrawedSpeed.Add(0f);
			failedDrawedSpeed.Add(0f);
		}
		InitDraw();
		Rework.onClick.RemoveAllListeners();
		Patch.onClick.RemoveAllListeners();
		InDevBtn.onClick.RemoveAllListeners();
		Rework.onClick.AddListener(delegate
		{
			ReworkClick();
		});
		Patch.onClick.AddListener(delegate
		{
			ReworkClick();
		});
		InDevBtn.onClick.AddListener(delegate
		{
			ReworkClick();
		});
		move = false;
		DeleteBtn.onClick.AddListener(DeleteClick);
		if (ActiveComponent.Model.globalSaves.IsSet(SaveFlags.DisabledTutorial))
		{
			ActiveComponent.Model.P.daysTutorial = 1;
		}
		if (ActiveComponent.Model.P.daysTutorial != 1 && scheme.released != 1)
		{
			DeleteBtn.interactable = false;
			deleteGray.color = Logic.GetColor("GREY");
			DeleteBtn.gameObject.GetComponent<SelectHighlighter>().enabled = false;
		}
		Logic.UpdateGameSaves();
		timer = 0f;
	}

	protected override void OnInit()
	{
		base.OnInit();
		if (ActiveHypeSprite == null)
		{
			ActiveHypeColor = Logic.GetColor("GREEN");
		}
	}

	private void SetHype(int hypeValue, int usersIncomeValue)
	{
		if (hypeValue > 0)
		{
			hypeText.color = ActiveHypeColor;
			hypeImage.color = ActiveHypeColor;
		}
		else if (usersIncomeValue >= 0 && sch.curUsers > 0)
		{
			hypeImage.color = Logic.GetColor("WARNING");
			hypeText.color = Logic.GetColor("WARNING");
		}
		else
		{
			hypeText.color = InactiveHypeColor;
			hypeImage.color = InactiveHypeColor;
		}
	}

	public void Redraw()
	{
		BaseMoney.text = TextResources.GetString("COMPANYBALANCE") + Logic.ColorTransform("MONEY", sch.baseStartup.BaseMoney + "$");
		yourShareText.text = (int)((float)sch.baseStartup.PlayersShares * sch.baseStartup.ShareSellCoef * ((float)sch.baseStartup.BaseMoney / (float)(sch.baseStartup.PlayersShares + sch.baseStartup.SharesCou))) + "$";
		InDevelopment.gameObject.SetActive(sch.released == 0);
		hypeImage.gameObject.SetActive(sch.released != 0);
		ProfitHist.gameObject.SetActive(sch.released != 0);
		UsersHist.gameObject.SetActive(sch.released != 0);
		Name.text = TextResources.GetString(sch.baseStartup.Texts + "SHORTT").ToUpper();
		HoverShow.gameObject.SetActive(value: false);
		AuedienceT.text = sch.audience.ToString();
		TypeT.text = sch.type.ToString();
		TotalT.text = sch.totalMoney.ToString();
		UsersTotalT.text = sch.totalUsers.ToString();
		ServersT.text = sch.ServersCost.ToString();
		Rework.gameObject.SetActive(sch.released == 0);
		Patch.gameObject.SetActive(sch.released == 1);
		if (sch.released == 0)
		{
			for (int i = 0; i < weekDays; i++)
			{
				positiveUsersHistList[i].gameObject.SetActive(value: false);
				negativeUserHistList[i].gameObject.SetActive(value: false);
				ProfitHistList[i].fillAmount = 0f;
			}
			return;
		}
		float num = 0f;
		for (int j = 0; j < sch.lastMoney.Count; j++)
		{
			num += (float)sch.lastMoney[j];
		}
		num /= (float)sch.lastMoney.Count;
		WeekT.text = num.ToString();
		num = 0f;
		for (int k = 0; k < sch.lastUsers.Count; k++)
		{
			num += (float)sch.lastUsers[k];
		}
		num /= (float)sch.lastUsers.Count;
		WeekUIncT.text = num.ToString();
		num = 0f;
		for (int l = 0; l < sch.lastAccuracy.Count; l++)
		{
			num += sch.lastAccuracy[l];
		}
		num /= (float)sch.lastAccuracy.Count;
		AccT.text = num.ToString();
		HoverShow.gameObject.SetActive(hover);
		HoverShow.gameObject.SetActive(value: false);
		float num2 = -1000000f;
		float num3 = -1000000f;
		float num4 = -1000000f;
		for (int m = 0; m < weekDays; m++)
		{
			num2 = Mathf.Max(num2, sch.lastUsers[m]);
			num3 = Mathf.Max(num3, sch.lastMoney[m] - sch.lastServers[m]);
			num4 = Mathf.Max(num4, Mathf.Abs(sch.lastMoney[m] - sch.lastServers[m]));
		}
		string keyName = "MONEY";
		if (sch.lastMoney[6] - sch.lastServers[6] <= 0)
		{
			keyName = "BAD";
		}
		if (num3 <= 0f)
		{
			num4 = 0f - num4;
		}
		MoneyMax.text = TextResources.GetString("WEEKPROFIT") + " " + Logic.ColorTransform(keyName, sch.lastMoney[6] - sch.lastServers[6] + "$");
		UsersMax.text = string.Format(TextResources.GetString("CURUSERS") + "{0} : {1}", Logic.ColorTransform("WARNING", Mathf.Max(0f, (float)sch.lastUsers[6] - sch.lastFailed[6]).ToString()), Logic.ColorTransform("RED", sch.lastFailed[6].ToString()));
		for (int n = 0; n < weekDays; n++)
		{
			if (float.IsNaN(ProfitHistList[n].fillAmount))
			{
				ProfitHistList[n].fillAmount = 0.0001f;
			}
			if (float.IsNaN(positiveUsersHistList[n].fillAmount))
			{
				positiveUsersHistList[n].fillAmount = 0.0001f;
			}
			if (float.IsNaN(negativeUserHistList[n].fillAmount))
			{
				negativeUserHistList[n].fillAmount = 0.0001f;
			}
		}
		for (int num5 = 0; num5 < weekDays; num5++)
		{
			usersDrawed[num5] = Mathf.Abs(((float)sch.lastUsers[num5] - sch.lastFailed[num5]) / Mathf.Abs(num2));
			moneyDrawed[num5] = Mathf.Abs((float)(sch.lastMoney[num5] - sch.lastServers[num5]) / Mathf.Abs(num4));
			failedDrawed[num5] = Mathf.Abs(sch.lastFailed[num5] / Mathf.Abs(num2)) * 1f;
			usersDrawedSpeed[num5] = usersDrawed[num5] * 1f - GetFillAmount(positiveUsersHistList[num5]);
			failedDrawedSpeed[num5] = failedDrawed[num5] * 1f - GetFillAmount(negativeUserHistList[num5]);
			moneyDrawedSpeed[num5] = moneyDrawed[num5] * 1f - ProfitHistList[num5].fillAmount;
		}
		moveTimer = Time.time;
		move = true;
	}

	public void DayStep()
	{
		if (sch != null)
		{
			Redraw();
		}
	}

	private void InitDraw()
	{
		BaseMoney.text = TextResources.GetString("COMPANYBALANCE") + Logic.ColorTransform("MONEY", sch.baseStartup.BaseMoney + "$");
		yourShareText.text = (int)((float)sch.baseStartup.PlayersShares * sch.baseStartup.ShareSellCoef * ((float)sch.baseStartup.BaseMoney / (float)(sch.baseStartup.PlayersShares + sch.baseStartup.SharesCou))) + "$";
		Name.text = TextResources.GetString(sch.baseStartup.KeyName + "SHORTT").ToUpper();
		HoverShow.gameObject.SetActive(value: false);
		AuedienceT.text = sch.audience.ToString();
		TypeT.text = sch.type.ToString();
		TotalT.text = sch.totalMoney.ToString();
		UsersTotalT.text = sch.totalUsers.ToString();
		ServersT.text = sch.ServersCost.ToString();
		InDevelopment.gameObject.SetActive(sch.released == 0);
		hypeImage.gameObject.SetActive(sch.released != 0);
		ProfitHist.gameObject.SetActive(sch.released != 0);
		UsersHist.gameObject.SetActive(sch.released != 0);
		Rework.gameObject.SetActive(sch.released == 0);
		Patch.gameObject.SetActive(sch.released == 1);
		if (sch.released == 0)
		{
			for (int i = 0; i < weekDays; i++)
			{
				positiveUsersHistList[i].gameObject.SetActive(value: false);
				negativeUserHistList[i].gameObject.SetActive(value: false);
				ProfitHistList[i].fillAmount = 0f;
			}
			return;
		}
		float num = -1000000f;
		float a = -1000000f;
		float num2 = -1000000f;
		if (!sch.IsReleased())
		{
			return;
		}
		for (int j = 0; j < weekDays; j++)
		{
			num = Mathf.Max(num, sch.lastUsers[j]);
			a = Mathf.Max(a, sch.lastMoney[j] - sch.lastServers[j]);
			num2 = Mathf.Max(num2, Mathf.Abs(sch.lastMoney[j] - sch.lastServers[j]));
		}
		string keyName = "MONEY";
		if (sch.lastMoney[6] - sch.lastServers[6] <= 0)
		{
			keyName = "BAD";
		}
		if (num2 <= 0f)
		{
			num2 = 0f - num2;
		}
		MoneyMax.text = TextResources.GetString("WEEKPROFIT") + " " + Logic.ColorTransform(keyName, sch.lastMoney[6] - sch.lastServers[6] + "$");
		UsersMax.text = string.Format(TextResources.GetString("CURUSERS") + "{0} : {1}", Logic.ColorTransform("WARNING", Mathf.Max(0f, (float)sch.lastUsers[6] - sch.lastFailed[6]).ToString()), Logic.ColorTransform("RED", sch.lastFailed[6].ToString()));
		for (int k = 0; k < weekDays; k++)
		{
			if (num != 0f)
			{
				float num3 = Mathf.Abs((float)sch.lastUsers[k] / Mathf.Abs(num));
				float num4 = Mathf.Abs(sch.lastFailed[k] / Mathf.Abs(num));
				SetFillAmount(positiveUsersHistList[k], num3 - num4);
				SetTopFillAmount(positiveUsersHistList[k], negativeUserHistList[k], num4);
			}
			else
			{
				positiveUsersHistList[k].gameObject.SetActive(value: false);
				negativeUserHistList[k].gameObject.SetActive(value: false);
			}
			if (num2 != 0f)
			{
				ProfitHistList[k].fillAmount = Mathf.Abs((float)(sch.lastMoney[k] - sch.lastServers[k]) / Mathf.Abs(num2)) * 1f;
			}
			else
			{
				ProfitHistList[k].fillAmount = 0f;
			}
			if (sch.lastUsers[k] < 0)
			{
				positiveUsersHistList[k].color = Logic.GetColor("RED");
			}
			else
			{
				positiveUsersHistList[k].color = Logic.GetColor("WARNING");
			}
			if (sch.lastMoney[k] - sch.lastServers[k] < 0)
			{
				ProfitHistList[k].color = Logic.GetColor("RED");
			}
			else
			{
				ProfitHistList[k].color = Logic.GetColor("MONEY");
			}
			Color color = negativeUserHistList[k].color;
			color.a = 1f;
			negativeUserHistList[k].color = color;
			SetHype(sch.GetHypeValue(), sch.GetUsersIncomeValue());
			if (7 - k > ActiveComponent.Model.P.Days)
			{
				color = positiveUsersHistList[k].color;
				color.a = 0.5f;
				positiveUsersHistList[k].color = color;
				color = ProfitHistList[k].color;
				color.a = 0.5f;
				ProfitHistList[k].color = color;
				color = negativeUserHistList[k].color;
				color.a = 0.5f;
				negativeUserHistList[k].color = color;
			}
		}
		for (int l = 0; l < weekDays; l++)
		{
			if (float.IsNaN(ProfitHistList[l].fillAmount))
			{
				ProfitHistList[l].fillAmount = 0.0001f;
			}
			if (float.IsNaN(negativeUserHistList[l].fillAmount))
			{
				negativeUserHistList[l].fillAmount = 0.0001f;
			}
			if (float.IsNaN(positiveUsersHistList[l].fillAmount))
			{
				positiveUsersHistList[l].fillAmount = 0.0001f;
			}
		}
	}

	private void FakeDraw()
	{
		sch.released = 1;
		sch.baseStartup.PlayersShares = 100;
		sch.baseStartup.SharesCou = 200;
		sch.baseStartup.ShareSellCoef = 0.8f;
		sch.baseStartup.BaseMoney = 10000;
		BaseMoney.text = TextResources.GetString("COMPANYBALANCE") + Logic.ColorTransform("MONEY", sch.baseStartup.BaseMoney + "$");
		yourShareText.text = (int)((float)sch.baseStartup.PlayersShares * sch.baseStartup.ShareSellCoef * ((float)sch.baseStartup.BaseMoney / (float)(sch.baseStartup.PlayersShares + sch.baseStartup.SharesCou))) + "$";
		Name.text = TextResources.GetString(sch.baseStartup.KeyName + "SHORTT").ToUpper();
		HoverShow.gameObject.SetActive(value: false);
		InDevelopment.gameObject.SetActive(value: false);
		float num = -1000000f;
		float num2 = -1000000f;
		float num3 = -1000000f;
		float a = -1000000f;
		for (int i = 0; i < weekDays; i++)
		{
			num = Mathf.Max(num, sch.lastUsers[i]);
			num2 = Mathf.Max(num2, sch.lastMoney[i] - sch.lastServers[i]);
			num3 = Mathf.Max(num3, Mathf.Abs(sch.lastMoney[i] - sch.lastServers[i]));
			a = Mathf.Max(a, Mathf.Abs(sch.lastFailed[i]));
		}
		string keyName = "MONEY";
		if (sch.lastMoney[6] - sch.lastServers[6] <= 0)
		{
			keyName = "BAD";
		}
		if (num2 <= 0f)
		{
			num3 = 0f - num3;
		}
		MoneyMax.text = TextResources.GetString("WEEKPROFIT") + " " + Logic.ColorTransform(keyName, sch.lastMoney[6] - sch.lastServers[6] + "$");
		UsersMax.text = string.Format(TextResources.GetString("CURUSERS") + "{0} : {1}", Logic.ColorTransform("WARNING", Mathf.Max(0f, (float)sch.lastUsers[6] - sch.lastFailed[6]).ToString()), Logic.ColorTransform("RED", sch.lastFailed[6].ToString()));
		for (int j = 0; j < weekDays; j++)
		{
			if (num != 0f)
			{
				float num4 = Mathf.Abs((float)sch.lastUsers[j] / Mathf.Abs(num));
				float num5 = Mathf.Abs(sch.lastFailed[j] / Mathf.Abs(num));
				SetFillAmount(positiveUsersHistList[j], num4 - num5);
				SetTopFillAmount(positiveUsersHistList[j], negativeUserHistList[j], num5);
			}
			else
			{
				positiveUsersHistList[j].gameObject.SetActive(value: false);
				negativeUserHistList[j].gameObject.SetActive(value: false);
			}
			if (num3 != 0f)
			{
				ProfitHistList[j].fillAmount = Mathf.Abs((float)(sch.lastMoney[j] - sch.lastServers[j]) / Mathf.Abs(num3)) * 1f;
			}
			else
			{
				ProfitHistList[j].fillAmount = 0f;
			}
			if (sch.lastUsers[j] < 0)
			{
				positiveUsersHistList[j].color = Logic.GetColor("RED");
			}
			else
			{
				positiveUsersHistList[j].color = Logic.GetColor("WARNING");
			}
			if (sch.lastMoney[j] - sch.lastServers[j] < 0)
			{
				ProfitHistList[j].color = Logic.GetColor("RED");
			}
			else
			{
				ProfitHistList[j].color = Logic.GetColor("MONEY");
			}
			Color color = negativeUserHistList[j].color;
			color.a = 1f;
			negativeUserHistList[j].color = color;
			SetHype(sch.GetHypeValue(), sch.GetUsersIncomeValue());
		}
		for (int k = 0; k < weekDays; k++)
		{
			if (float.IsNaN(ProfitHistList[k].fillAmount))
			{
				ProfitHistList[k].fillAmount = 0.0001f;
			}
		}
	}

	public void InitFake()
	{
		base.Init();
		SceneBindContainer.BindObjects(this, base.transform);
		sch = new StartupScheme();
		sch.baseStartup = new Startup();
		sch.baseStartup.KeyName = "FAKESTARTUP";
		for (int i = 0; i < weekDays; i++)
		{
			sch.lastMoney.Add((int)Mathf.Sqrt(10 * i));
			if (i >= 5)
			{
				sch.lastMoney[i] = -13 + i;
			}
			sch.lastUsers.Add(2 * i);
			sch.lastFailed[i] = i;
			sch.lastServers.Add(0);
			positiveUsersHistList.Add(UsersHist.transform.Find("Hist" + i).GetComponent<Image>());
			negativeUserHistList.Add(positiveUsersHistList[positiveUsersHistList.Count - 1].GetComponentsInChildren<Image>()[1]);
			ProfitHistList.Add(ProfitHist.transform.Find("Hist" + i).GetComponent<Image>());
			usersDrawed.Add((float)sch.lastUsers[i] - sch.lastFailed[i]);
			moneyDrawed.Add(sch.lastMoney[i]);
			failedDrawed.Add(sch.lastFailed[i]);
			usersDrawedSpeed.Add(0f);
			moneyDrawedSpeed.Add(0f);
			failedDrawedSpeed.Add(0f);
		}
		FakeDraw();
	}

	private void Update()
	{
		if (!move)
		{
			return;
		}
		if (Time.time - 1f <= moveTimer)
		{
			for (int i = 0; i < weekDays; i++)
			{
				SetFillAmount(positiveUsersHistList[i], GetFillAmount(positiveUsersHistList[i]) + usersDrawedSpeed[i] * Time.deltaTime);
				SetTopFillAmount(positiveUsersHistList[i], negativeUserHistList[i], GetFillAmount(negativeUserHistList[i]) + failedDrawedSpeed[i] * Time.deltaTime);
				ProfitHistList[i].fillAmount += moneyDrawedSpeed[i] * Time.deltaTime;
				if (sch.lastUsers[i] <= 0)
				{
					positiveUsersHistList[i].color = Logic.GetColor("RED");
				}
				else
				{
					positiveUsersHistList[i].color = Logic.GetColor("WARNING");
				}
				if (sch.lastMoney[i] - sch.lastServers[i] < 0)
				{
					ProfitHistList[i].color = Logic.GetColor("RED");
				}
				else
				{
					ProfitHistList[i].color = Logic.GetColor("MONEY");
				}
				Color color = negativeUserHistList[i].color;
				color.a = 1f;
				negativeUserHistList[i].color = color;
				SetHype(sch.GetHypeValue(), sch.GetUsersIncomeValue());
				if (7 - i > ActiveComponent.Model.P.Days)
				{
					color = positiveUsersHistList[i].color;
					color.a = 0.5f;
					positiveUsersHistList[i].color = color;
					color = ProfitHistList[i].color;
					color.a = 0.5f;
					ProfitHistList[i].color = color;
					color = negativeUserHistList[i].color;
					color.a = 0.5f;
					negativeUserHistList[i].color = color;
				}
				if (7 - i == ActiveComponent.Model.P.Days)
				{
					color = positiveUsersHistList[i].color;
					color.a = 0.5f + 0.5f * (Time.time - moveTimer);
					positiveUsersHistList[i].color = color;
					color = ProfitHistList[i].color;
					color.a = 0.5f + 0.5f * (Time.time - moveTimer);
					ProfitHistList[i].color = color;
					color = negativeUserHistList[i].color;
					color.a = 0.5f + 0.5f * (Time.time - moveTimer);
					negativeUserHistList[i].color = color;
				}
			}
		}
		else
		{
			float num = -1000000f;
			float num2 = -1000000f;
			float num3 = -1000000f;
			float a = -1000000f;
			for (int j = 0; j < weekDays; j++)
			{
				num = Mathf.Max(num, sch.lastUsers[j]);
				num2 = Mathf.Max(num2, sch.lastMoney[j] - sch.lastServers[j]);
				num3 = Mathf.Max(num3, Mathf.Abs(sch.lastMoney[j] - sch.lastServers[j]));
				a = Mathf.Max(a, Mathf.Abs(sch.lastFailed[j]));
			}
			string keyName = "MONEY";
			if (sch.lastMoney[6] - sch.lastServers[6] <= 0)
			{
				keyName = "BAD";
			}
			if (num2 <= 0f)
			{
				num3 = 0f - num3;
			}
			MoneyMax.text = TextResources.GetString("WEEKPROFIT") + " " + Logic.ColorTransform(keyName, sch.lastMoney[6] - sch.lastServers[6] + "$");
			UsersMax.text = string.Format(TextResources.GetString("CURUSERS") + "{0} : {1}", Logic.ColorTransform("WARNING", Mathf.Max(0f, (float)sch.lastUsers[6] - sch.lastFailed[6]).ToString()), Logic.ColorTransform("RED", sch.lastFailed[6].ToString()));
			for (int k = 0; k < weekDays; k++)
			{
				if (num != 0f)
				{
					float num4 = Mathf.Abs((float)sch.lastUsers[k] / Mathf.Abs(num));
					float num5 = Mathf.Abs(sch.lastFailed[k] / Mathf.Abs(num));
					SetFillAmount(positiveUsersHistList[k], num4 - num5);
					SetTopFillAmount(positiveUsersHistList[k], negativeUserHistList[k], num5);
				}
				else
				{
					positiveUsersHistList[k].gameObject.SetActive(value: false);
					negativeUserHistList[k].gameObject.SetActive(value: false);
				}
				if (num3 != 0f)
				{
					ProfitHistList[k].fillAmount = Mathf.Abs((float)(sch.lastMoney[k] - sch.lastServers[k]) / Mathf.Abs(num3)) * 1f;
				}
				else
				{
					ProfitHistList[k].fillAmount = 0f;
				}
				if (sch.lastUsers[k] < 0)
				{
					positiveUsersHistList[k].color = Logic.GetColor("RED");
				}
				else
				{
					positiveUsersHistList[k].color = Logic.GetColor("WARNING");
				}
				if (sch.lastMoney[k] - sch.lastServers[k] < 0)
				{
					ProfitHistList[k].color = Logic.GetColor("RED");
				}
				else
				{
					ProfitHistList[k].color = Logic.GetColor("MONEY");
				}
				Color color2 = negativeUserHistList[k].color;
				color2.a = 1f;
				negativeUserHistList[k].color = color2;
				SetHype(sch.GetHypeValue(), sch.GetUsersIncomeValue());
				if (7 - k > ActiveComponent.Model.P.Days)
				{
					color2 = positiveUsersHistList[k].color;
					color2.a = 0.5f;
					positiveUsersHistList[k].color = color2;
					color2 = ProfitHistList[k].color;
					color2.a = 0.5f;
					ProfitHistList[k].color = color2;
					color2 = negativeUserHistList[k].color;
					color2.a = 0.5f;
					negativeUserHistList[k].color = color2;
				}
			}
			move = false;
		}
		for (int l = 0; l < weekDays; l++)
		{
			if (float.IsNaN(ProfitHistList[l].fillAmount))
			{
				ProfitHistList[l].fillAmount = 0.0001f;
			}
			if (float.IsNaN(negativeUserHistList[l].fillAmount))
			{
				negativeUserHistList[l].fillAmount = 0.0001f;
			}
			if (float.IsNaN(positiveUsersHistList[l].fillAmount))
			{
				positiveUsersHistList[l].fillAmount = 0.0001f;
			}
		}
	}
}
