using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MarketingWindow : MonoBehaviour
{
	public enum MarketingOption
	{
		AnnounceRelease = 0,
		PressRelease = 1,
		PressBuild = 2,
		Hype = 3,
		Market = 4
	}

	public GUIWindow Window;

	public Toggle[] Toggles;

	public GameObject ReleasePanel;

	public GameObject PressPanel;

	public GameObject MarketPanel;

	public Text DescriptionText;

	public Text PressCost;

	public Text TeamLabel;

	[NonSerialized]
	public HashSet<string> Teams = new HashSet<string>();

	[NonSerialized]
	public SimulatedCompany CompanyWorker;

	public InputField MarketBudget;

	public Toggle[] PressOptions;

	public Toggle[] AllPressOptions;

	public static string[] PressOptionNames = new string[3] { "PressText", "PressPicture", "PressVideo" };

	[NonSerialized]
	public IMarketable[] TargetProducts;

	[NonSerialized]
	public SoftwareWorkItem TargetWork;

	public GameObject[] TeamThings;

	public RectTransform ContentPanel;

	public DatePicker datePicker;

	public float[] PressOptionCost;

	public float[] PressOptionEffect;

	private static string[] Descs = new string[5] { "MarketingDescAnnounce2", "MarketingDescRelease", "MarketingDescBuild", "MarketingDescHype", "MarketingDescPost" };

	public MarketingOption SelectedOption;

	public void UpdateTeamLabel()
	{
		TeamLabel.text = ((CompanyWorker != null) ? CompanyWorker.Name : Teams.GetListAbbrev("Team"));
	}

	public void EnableTeams(bool enable)
	{
		GameObject[] teamThings = TeamThings;
		for (int i = 0; i < teamThings.Length; i++)
		{
			teamThings[i].SetActive(enable);
		}
		ContentPanel.offsetMin = new Vector2(ContentPanel.offsetMin.x, enable ? 88 : 55);
	}

	public void Show(SoftwareWorkItem sw)
	{
		datePicker.CurrentDate = sw.ReleaseDate ?? (SDateTime.Now() + sw.DevTime);
		TargetWork = sw;
		TargetProducts = null;
		bool[] array = new bool[4];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = true;
		}
		bool flag = PublisherDeal.HasDeal(sw, "Marketing");
		array[0] = !sw.WorkAddOn && (sw.Publishing == null || !sw.Publishing.ControlReleaseSchedule());
		array[2] = !flag && sw is SoftwareAlpha && !GameSettings.Instance.PressBuildQueue.Contains((SoftwareAlpha)sw);
		array[1] = !flag;
		array[3] = !flag;
		if (!flag)
		{
			foreach (MarketingPlan item in GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>())
			{
				if (item.TargetItem == sw)
				{
					array[1] &= item.Type != MarketingPlan.TaskType.PressRelease;
					array[3] &= item.Type != MarketingPlan.TaskType.Hype;
				}
			}
		}
		Toggles[4].gameObject.SetActive(false);
		bool flag2 = false;
		int num = 0;
		for (int num2 = array.Length - 1; num2 > -1; num2--)
		{
			if (array[num2] && (num2 != 0 || !sw.ReleaseDate.HasValue))
			{
				num = num2;
			}
			flag2 |= array[num2];
			Toggles[num2].gameObject.SetActive(array[num2]);
		}
		if (flag2)
		{
			Window.NonLocTitle = "MarketingWindowTitle".Loc(sw.SoftwareName);
			for (int j = 0; j < array.Length; j++)
			{
				if (num != j)
				{
					Toggles[j].isOn = false;
				}
			}
			Toggles[num].isOn = true;
			Window.Show();
			Toggle(true);
			UpdateLabels();
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("NoMarketingOptions".Loc(), false, DialogWindow.DialogType.Error);
		}
	}

	public void Show(params IMarketable[] products)
	{
		HashSet<IMarketable> alreadyMarketed = (from x in GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>()
			where !x.AutoDev && x.Type == MarketingPlan.TaskType.PostMarket
			select x.TargetProduct).ToHashSet();
		alreadyMarketed.AddRange(products.Where((IMarketable x) => PublisherDeal.HasDeal(x, "Marketing")));
		products = products.Where((IMarketable x) => !alreadyMarketed.Contains(x)).ToArray();
		if (products.Length == 0)
		{
			WindowManager.Instance.ShowMessageBox("NoMarketingOptions".Loc(), false, DialogWindow.DialogType.Error);
			return;
		}
		TargetWork = null;
		TargetProducts = products;
		Window.NonLocTitle = "MarketingWindowTitle".Loc((products.Length == 1) ? products[0].GetName() : "Product".LocPlural(products.Length));
		for (int num = 0; num < 4; num++)
		{
			Toggles[num].isOn = false;
			Toggles[num].gameObject.SetActive(false);
		}
		Toggles[4].gameObject.SetActive(true);
		Toggles[4].isOn = true;
		Window.Show();
		Toggle(true);
		TutorialSystem.Instance.StartTutorial("Marketing");
		UpdateLabels();
	}

	private void UpdateLabels()
	{
		string text = "Marketing".Loc();
		for (int i = 0; i < AllPressOptions.Length; i++)
		{
			AllPressOptions[i].GetComponentInChildren<Text>().text = PressOptionNames[i].Loc() + " (" + "SpecSkill".Loc(i + 1, text) + ")";
		}
	}

	public void Reset()
	{
		PressPanel.SetActive(false);
		ReleasePanel.SetActive(false);
		MarketPanel.SetActive(false);
		MarketBudget.text = "0";
		UpdatePressReleaseCost();
		for (int i = 0; i < PressOptions.Length; i++)
		{
			PressOptions[i].isOn = false;
		}
	}

	public void Toggle(bool val)
	{
		if (!val)
		{
			return;
		}
		int num = -1;
		for (int i = 0; i < Toggles.Length; i++)
		{
			if (Toggles[i].isOn && Toggles[i].gameObject.activeSelf)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			SelectedOption = (MarketingOption)num;
			Reset();
			DescriptionText.text = Descs[num].Loc();
			switch (SelectedOption)
			{
			case MarketingOption.AnnounceRelease:
				ReleasePanel.SetActive(true);
				EnableTeams(false);
				break;
			case MarketingOption.PressRelease:
				Teams.Clear();
				Teams.AddRange(GameSettings.Instance.GetDefaultTeams(SelectedOption.ToString()));
				CompanyWorker = null;
				UpdateTeamLabel();
				EnableTeams(true);
				PressPanel.SetActive(true);
				break;
			case MarketingOption.Market:
				Teams.Clear();
				Teams.AddRange(GameSettings.Instance.GetDefaultTeams(SelectedOption.ToString()));
				CompanyWorker = null;
				UpdateTeamLabel();
				EnableTeams(true);
				MarketPanel.SetActive(true);
				break;
			case MarketingOption.Hype:
				Teams.Clear();
				Teams.AddRange(GameSettings.Instance.GetDefaultTeams(SelectedOption.ToString()));
				CompanyWorker = null;
				UpdateTeamLabel();
				EnableTeams(true);
				break;
			case MarketingOption.PressBuild:
				EnableTeams(false);
				break;
			}
		}
	}

	public float GetPressReleaseCost()
	{
		float num = PressOptionCost[0];
		for (int i = 0; i < PressOptions.Length; i++)
		{
			if (PressOptions[i].isOn)
			{
				num += PressOptionCost[i + 1];
			}
		}
		return num;
	}

	public MarketingPlan.PressOption GetPressOptions()
	{
		int num = 1;
		for (int i = 0; i < PressOptions.Length; i++)
		{
			if (PressOptions[i].isOn)
			{
				num |= 1 << i + 1;
			}
		}
		return (MarketingPlan.PressOption)num;
	}

	public void PickTeams()
	{
		HUD.Instance.TeamSelectWindow.Show(Teams, CompanyWorker, delegate(string[] ts, SimulatedCompany c)
		{
			Teams.Clear();
			if (c != null)
			{
				CompanyWorker = c;
			}
			else
			{
				CompanyWorker = null;
				Teams.AddRange(ts);
			}
			UpdateTeamLabel();
		}, "Marketing", SelectedOption.ToString(), "MarketingPlan");
		HUD.Instance.TeamSelectWindow.Window.SetParentWindow(Window);
	}

	public void UpdatePressReleaseCost()
	{
		PressCost.text = GetPressReleaseCost().Currency();
	}

	private static void ChangeReleaseDate(SDateTime before, SDateTime now, SoftwareWorkItem item)
	{
		if (!(now > before))
		{
			return;
		}
		float months = SDateTime.GetMonths(before, now);
		float months2 = SDateTime.GetMonths(SDateTime.Now(), now);
		if (months2 < 24f)
		{
			float num = Mathf.Clamp(Mathf.Pow(Mathf.Max(0f, 0.9f - (months2 - months / 8f) / 24f), 12f / months), 0f, 0.8f);
			item.Followers *= 1f - num;
			item.FollowerChange -= item.Followers * num;
			for (int i = 0; i < item.AddonWorkChildren.Count; i++)
			{
				SoftwareWorkItem softwareWorkItem = item.AddonWorkChildren[i];
				softwareWorkItem.Followers *= 1f - num;
				softwareWorkItem.FollowerChange -= softwareWorkItem.Followers * num;
			}
		}
	}

	public void Begin()
	{
		bool flag = true;
		switch (SelectedOption)
		{
		case MarketingOption.AnnounceRelease:
		{
			int month = datePicker.CurrentDate.Month;
			int year = datePicker.CurrentDate.Year;
			SDateTime rDate = new SDateTime(0, month, year);
			SDateTime now = SDateTime.Now();
			if (rDate.Year < now.Year || (rDate.Year == now.Year && rDate.Month <= now.Month))
			{
				WindowManager.Instance.ShowMessageBox("ReleaseDateError".Loc(), false, DialogWindow.DialogType.Error);
				flag = false;
				break;
			}
			if (TargetWork.ReleaseDate.HasValue)
			{
				if (TargetWork.ReleaseDate.Value.EqualsVerySimple(rDate))
				{
					break;
				}
				WindowManager.Instance.ShowMessageBox("ReleaseDateChangeWarning".Loc(SDateTime.DateDiff(now, rDate + SDateTime.GetMonth(1))), true, DialogWindow.DialogType.Question, delegate
				{
					ChangeReleaseDate(TargetWork.ReleaseDate.Value, rDate, TargetWork);
					TargetWork.ReleaseDate = rDate;
					TargetWork.NetworkSchedule(false);
					for (int j = 0; j < TargetWork.AddonWorkChildren.Count; j++)
					{
						TargetWork.AddonWorkChildren[j].ReleaseDate = rDate;
					}
					HUD.Instance.comingReleaseWindow.CheckRefresh();
				});
				break;
			}
			WindowManager.Instance.ShowMessageBox("ReleaseDateConfirmation".Loc(rDate.ToCompactString(), SDateTime.DateDiff(now, rDate + SDateTime.GetMonth(1))), true, DialogWindow.DialogType.Question, delegate
			{
				TargetWork.ReleaseDate = rDate;
				TargetWork.NetworkSchedule(false);
				TargetWork.MarketingDone();
				for (int j = 0; j < TargetWork.AddonWorkChildren.Count; j++)
				{
					TargetWork.AddonWorkChildren[j].ReleaseDate = rDate;
					TargetWork.AddonWorkChildren[j].MarketingDone();
				}
				HUD.Instance.comingReleaseWindow.CheckRefresh();
			}, "Set release date");
			break;
		}
		case MarketingOption.PressRelease:
			if (TargetWork.Done)
			{
				break;
			}
			if (CompanyWorker == null)
			{
				int num = 0;
				for (int num2 = 0; num2 < AllPressOptions.Length; num2++)
				{
					if (AllPressOptions[num].isOn)
					{
						num = num2 + 1;
					}
				}
				if (Teams.SelectNotNull(GameSettings.GetTeam).MaxSafeInt((Team team) => team.GetEmployeesDirect().MaxSafeInt((Actor z) => z.employee.IsRole(Employee.RoleBit.Service, true) ? z.employee.GetSpecialization(Employee.EmployeeRole.Service, "Marketing", z) : 0)) < num)
				{
					flag = false;
					WindowManager.Instance.ShowMessageBox("DesignProductFeatureHint".Loc("SpecSkill".Loc(num, "Marketer".Loc())), true, DialogWindow.DialogType.Warning, delegate
					{
						PressRelease();
						Window.Close();
					}, "MissingMarketingSpec");
				}
				else
				{
					PressRelease();
				}
			}
			else
			{
				PressRelease();
			}
			break;
		case MarketingOption.PressBuild:
			if (TargetWork.Done)
			{
				break;
			}
			if (TargetWork.ReleaseDate.HasValue)
			{
				PressBuild();
				break;
			}
			WindowManager.Instance.ShowMessageBox("MarketingReleaseDateWarning".Loc("Pressbuild".Loc().ToLower()), true, DialogWindow.DialogType.Question, delegate
			{
				PressBuild();
			}, "Marketing without release date");
			break;
		case MarketingOption.Hype:
			if (!TargetWork.Done)
			{
				if (CompanyWorker == null)
				{
					GameSettings.Instance.TeamDefaults["Hype"] = Teams.ToHashSet();
				}
				MarketingPlan item2 = new MarketingPlan(TargetWork, MarketingPlan.TaskType.Hype, MarketingPlan.PressOption.None, (TargetWork.guiItem == null) ? (-1) : (TargetWork.guiItem.transform.GetSiblingIndex() + 1));
				AssignTeams(item2);
				GameSettings.Instance.MyCompany.AddWorkItem(item2);
			}
			break;
		case MarketingOption.Market:
		{
			if (CompanyWorker == null)
			{
				GameSettings.Instance.TeamDefaults["Marketing"] = Teams.ToHashSet();
			}
			float x = 0f;
			try
			{
				x = (float)Convert.ToDouble(MarketBudget.text);
			}
			catch (Exception)
			{
			}
			x = x.FromCurrency();
			for (int i = 0; i < TargetProducts.Length; i++)
			{
				IMarketable product = TargetProducts[i];
				MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan marketingPlan2) => marketingPlan2.TargetProduct == product);
				if (marketingPlan != null)
				{
					foreach (AutoDevWorkItem item3 in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
					{
						if (item3.TakeOverTask(marketingPlan))
						{
							AssignTeams(marketingPlan);
							marketingPlan.MaxBudget = x;
							break;
						}
					}
				}
				else
				{
					MarketingPlan item = new MarketingPlan(x, product);
					AssignTeams(item);
					GameSettings.Instance.MyCompany.AddWorkItem(item);
				}
			}
			break;
		}
		}
		if (flag)
		{
			Window.Close();
		}
	}

	private void Update()
	{
		if (Window.IsActiveWindow)
		{
			if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
			{
				Begin();
			}
			if (Window.Modal && Input.GetKeyUp(KeyCode.Escape))
			{
				Window.Close();
			}
		}
	}

	private void PressRelease()
	{
		if (CompanyWorker == null)
		{
			GameSettings.Instance.TeamDefaults["PressRelease"] = Teams.ToHashSet();
		}
		MarketingPlan item = new MarketingPlan(TargetWork, MarketingPlan.TaskType.PressRelease, GetPressOptions(), (TargetWork.guiItem == null) ? (-1) : (TargetWork.guiItem.transform.GetSiblingIndex() + 1));
		AssignTeams(item);
		GameSettings.Instance.MyCompany.AddWorkItem(item);
	}

	private void AssignTeams(WorkItem item)
	{
		if (CompanyWorker != null)
		{
			item.CompanyWorker = CompanyWorker;
		}
		else
		{
			item.SetDevTeams(Teams.ToList());
		}
	}

	private void PressBuild()
	{
		GameSettings.Instance.PressBuildQueue.Add(TargetWork as SoftwareAlpha);
		NotificationManager.AddNotification(new NotificationMessage("PressBuildConfirmation".LocColor(TargetWork), "Newspaper", NotificationManager.NotificationType.Neutral));
	}
}
