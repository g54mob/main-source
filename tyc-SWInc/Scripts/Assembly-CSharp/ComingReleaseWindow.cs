using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ComingReleaseWindow : MonoBehaviour
{
	public enum EventType
	{
		PlayerRelease = 0,
		SubsidiaryRelease = 1,
		AIRelease = 2,
		DealDeadline = 3,
		ContractDeadline = 4
	}

	public GUIWindow Window;

	public RectTransform DetailContent;

	public RectTransform MonthContainer;

	public Image DotPrefab;

	public GUICombobox TypeFilter;

	public GUICombobox CategoryFilter;

	public GUILegend Legend;

	public Text CurrentYear;

	private GameObject _detailPrefab;

	private GameObject _linePrefab;

	private RectTransform[] _monthContent;

	private Image[] _monthBox;

	private int Year;

	private int Month;

	private ObjectPool<Image> _dotPool;

	private bool _initialized;

	[NonSerialized]
	private List<ICalenderItem> _calItemCache = new List<ICalenderItem>();

	private void Initialize()
	{
		if (!_initialized)
		{
			TypeFilter.UpdateContent(new SoftwareType[1].Concat(MarketSimulation.Active.SoftwareTypes.Values));
			Legend.Colors.AddRange(HUD.GetThemeColors());
			Legend.Items.AddRange(new string[5]
			{
				"MainPlayerRelease".Loc(),
				"Subsidiaries".Loc(),
				"Market".Loc(),
				"Deals".Loc(),
				"Contracts".Loc()
			});
			Legend.OnToggle = Refresh;
			_initialized = true;
			_monthBox = new Image[12];
			_monthContent = new RectTransform[12];
			_detailPrefab = DetailContent.GetChild(0).gameObject;
			_linePrefab = DetailContent.GetChild(1).gameObject;
			Transform child = MonthContainer.GetChild(0);
			InitMonth(child, 0);
			for (int i = 1; i < 12; i++)
			{
				Transform transform = UnityEngine.Object.Instantiate(child);
				transform.transform.SetParent(MonthContainer, false);
				InitMonth(transform, i);
			}
		}
	}

	public void TypeChange()
	{
		SoftwareType softwareType = TypeFilter.SelectedItem as SoftwareType;
		if (softwareType != null)
		{
			CategoryFilter.Software = softwareType.Name;
			CategoryFilter.UpdateContent(new SoftwareCategory[1].Concat(softwareType.Categories.Values.Where((SoftwareCategory x) => !x.Hidden)));
		}
		else
		{
			CategoryFilter.UpdateContent(new SoftwareCategory[1]);
		}
		CategoryFilter.Selected = 0;
		Refresh();
	}

	private void InitMonth(Transform root, int month)
	{
		string input = SDateTime.Months[month];
		root.gameObject.name = input;
		root.GetComponentInChildren<Text>().text = input.Loc();
		root.GetComponentInChildren<Button>().onClick.AddListener(delegate
		{
			SetMonth(month);
		});
		_monthBox[month] = root.GetComponent<Image>();
		RectTransform[] componentsInChildren = root.GetComponentsInChildren<RectTransform>();
		int num = month % 3;
		int num2 = month / 3;
		componentsInChildren[0].anchorMin = new Vector2((float)num / 3f, (float)(3 - num2) / 4f);
		componentsInChildren[0].anchorMax = new Vector2(componentsInChildren[0].anchorMin.x + 1f / 3f, componentsInChildren[0].anchorMin.y + 0.25f);
		componentsInChildren[0].offsetMin = new Vector2(2f, 2f);
		componentsInChildren[0].offsetMax = new Vector2(-2f, -2f);
		_monthContent[month] = componentsInChildren[2];
	}

	private void Awake()
	{
		_dotPool = new ObjectPool<Image>(() => UnityEngine.Object.Instantiate(DotPrefab), delegate(Image x)
		{
			x.gameObject.SetActive(true);
		}, delegate(Image x)
		{
			x.gameObject.SetActive(false);
		});
	}

	public void ChangeYear(int d)
	{
		Year = Mathf.Max(SDateTime.Now().Year, Year + d);
		Refresh();
	}

	public void SetMonth(int m)
	{
		Month = m;
		Refresh();
	}

	private bool[] GetActiveBools()
	{
		return new bool[5]
		{
			Legend.IsOn(0),
			Legend.IsOn(1),
			Legend.IsOn(2),
			Legend.IsOn(3),
			Legend.IsOn(4)
		};
	}

	private IEnumerable<ICalenderItem> GetCurrentItems()
	{
		bool[] active = GetActiveBools();
		SoftwareType type = TypeFilter.SelectedItem as SoftwareType;
		SoftwareCategory cat = CategoryFilter.SelectedItem as SoftwareCategory;
		if (active[1] || active[2])
		{
			foreach (SimulatedCompany company in GameSettings.Instance.simulation.Companies.Values)
			{
				for (int i = 0; i < company.Releases.Count; i++)
				{
					SimulatedCompany.ProductPrototype productPrototype = company.Releases[i];
					if (productPrototype.ReleaseDate.Year == Year && active[(int)productPrototype.GetEventType()] && productPrototype.MatchSWFilter(type, cat))
					{
						yield return productPrototype;
					}
				}
			}
		}
		if (active[2])
		{
			foreach (Company playerCompany in MarketSimulation.Active.GetPlayerCompanies())
			{
				if (playerCompany.LocalPlayer)
				{
					continue;
				}
				foreach (ScheduledRelease release in playerCompany.GetReleases())
				{
					SDateTime? time = release.GetTime();
					if (time.HasValue && time.Value.Year == Year && active[(int)release.GetEventType()] && release.MatchSWFilter(type, cat))
					{
						yield return release;
					}
				}
			}
		}
		if (active[0] || active[4])
		{
			foreach (SoftwareWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>())
			{
				if (item.GetNetworkDealState() != WorkItem.NetworkDealState.Receiver)
				{
					SDateTime? time2 = item.GetTime();
					if (time2.HasValue && time2.Value.Year == Year && active[(int)item.GetEventType()] && item.MatchSWFilter(type, cat))
					{
						yield return item;
					}
				}
			}
		}
		if (active[3])
		{
			foreach (Deal item2 in HUD.Instance.dealWindow.GetActiveDealsPerformance())
			{
				SDateTime? time3 = item2.GetTime();
				if (time3.HasValue && time3.Value.Year == Year && active[(int)item2.GetEventType()] && item2.MatchSWFilter(type, cat))
				{
					yield return item2;
				}
			}
		}
		if (!active[4])
		{
			yield break;
		}
		lock (GameSettings.Instance.PrintOrders)
		{
			foreach (PrintJob printOrder in GameSettings.Instance.PrintOrders)
			{
				ContractWork contractWork = printOrder.Target as ContractWork;
				if (contractWork != null)
				{
					SDateTime? time4 = contractWork.GetTime();
					if (time4.HasValue && time4.Value.Year == Year && active[(int)contractWork.GetEventType()] && contractWork.MatchSWFilter(type, cat))
					{
						yield return contractWork;
					}
				}
			}
		}
	}

	public void CheckRefresh()
	{
		if (Window.Shown)
		{
			Refresh();
		}
	}

	private void Refresh()
	{
		Initialize();
		CurrentYear.text = (Year + 1900).ToString();
		SDateTime sDateTime = SDateTime.Now();
		if (Year < sDateTime.Year)
		{
			Year = sDateTime.Year;
			Month = sDateTime.Month;
		}
		else if (Year == sDateTime.Year && Month < sDateTime.Month)
		{
			Month = sDateTime.Month;
		}
		bool flag = Year == sDateTime.Year;
		for (int i = 0; i < _monthBox.Length; i++)
		{
			_monthBox[i].GetComponent<Button>().interactable = !flag || i >= sDateTime.Month;
			if (i == Month)
			{
				_monthBox[i].color = HUD.GetThemeColor(0);
			}
			else if (flag && i == sDateTime.Month)
			{
				_monthBox[i].color = Color.Lerp(HUD.GetThemeColor(1), Color.white, 0.5f);
			}
			else
			{
				_monthBox[i].color = Color.white;
			}
		}
		for (int j = 0; j < _monthContent.Length; j++)
		{
			RectTransform rectTransform = _monthContent[j];
			for (int k = 0; k < rectTransform.childCount; k++)
			{
				Transform child = rectTransform.GetChild(k);
				if (child.gameObject.activeSelf)
				{
					_dotPool.Release(child.GetComponent<Image>());
				}
			}
		}
		_calItemCache.Clear();
		foreach (ICalenderItem item in from x in GetCurrentItems()
			orderby x.GetEventType()
			select x)
		{
			SDateTime value = item.GetTime().Value;
			if (!flag || value.Month >= sDateTime.Month)
			{
				Image image = _dotPool.Get();
				image.transform.SetParent(_monthContent[value.Month], false);
				image.transform.SetAsLastSibling();
				image.color = HUD.GetThemeColor((int)item.GetEventType());
				if (value.Month == Month)
				{
					_calItemCache.Add(item);
				}
			}
		}
		int num = 0;
		int num2 = -1;
		foreach (ICalenderItem item2 in _calItemCache.OrderBy((ICalenderItem x) => x.GetTime().Value.ToInt()))
		{
			if (GameSettings.DaysPerMonth > 1 && item2.GetTime().Value.Day != num2)
			{
				num2 = item2.GetTime().Value.Day;
				Transform nextDetail = GetNextDetail(num);
				Text[] componentsInChildren = nextDetail.GetComponentsInChildren<Text>(true);
				componentsInChildren[0].text = "Day".Loc() + " " + (num2 + 1);
				componentsInChildren[1].gameObject.SetActive(false);
				nextDetail.GetComponent<Image>().color = Color.clear;
				DetailContent.GetChild(num * 2).gameObject.SetActive(true);
				DetailContent.GetChild(num * 2 + 1).gameObject.SetActive(true);
				num++;
			}
			Transform nextDetail2 = GetNextDetail(num);
			Text[] componentsInChildren2 = nextDetail2.GetComponentsInChildren<Text>(true);
			componentsInChildren2[0].text = item2.GetTitle();
			componentsInChildren2[1].text = item2.GetDescription();
			componentsInChildren2[1].gameObject.SetActive(true);
			nextDetail2.GetComponent<Image>().color = HUD.GetThemeColor((int)item2.GetEventType()).Alpha(0.5f);
			DetailContent.GetChild(num * 2).gameObject.SetActive(true);
			DetailContent.GetChild(num * 2 + 1).gameObject.SetActive(true);
			num++;
		}
		for (int num3 = num * 2; num3 < DetailContent.childCount; num3++)
		{
			DetailContent.GetChild(num3).gameObject.SetActive(false);
		}
		_calItemCache.Clear();
	}

	private Transform GetNextDetail(int k)
	{
		if (k * 2 < DetailContent.childCount)
		{
			return DetailContent.GetChild(k * 2);
		}
		GameObject obj = UnityEngine.Object.Instantiate(_detailPrefab);
		obj.transform.SetParent(DetailContent, false);
		UnityEngine.Object.Instantiate(_linePrefab).transform.SetParent(DetailContent, false);
		return obj.transform;
	}

	public void Toggle()
	{
		Window.Toggle();
		if (Window.Shown)
		{
			SDateTime sDateTime = SDateTime.Now();
			Year = sDateTime.Year;
			Month = sDateTime.Month;
			Refresh();
		}
	}
}
