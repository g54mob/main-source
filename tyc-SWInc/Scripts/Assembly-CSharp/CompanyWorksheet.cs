using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CompanyWorksheet : MonoBehaviour
{
	public CompanyChart CompanyChartPanel;

	public Color NormalColor;

	public Color LinkColor;

	public GUIWindow Window;

	public GUIWorkSheet Worksheet;

	public GUICombobox BillCombo;

	public GUICombobox GranularityCombo;

	private bool init = true;

	public int offset;

	private int _lastGranularity = 1;

	[NonSerialized]
	public List<KeyValuePair<string, Company.TransactionCategory[]>> Categories = new List<KeyValuePair<string, Company.TransactionCategory[]>>
	{
		new KeyValuePair<string, Company.TransactionCategory[]>("HR", new Company.TransactionCategory[5]
		{
			Company.TransactionCategory.Salaries,
			Company.TransactionCategory.Staff,
			Company.TransactionCategory.Hire,
			Company.TransactionCategory.Education,
			Company.TransactionCategory.Benefits
		}),
		new KeyValuePair<string, Company.TransactionCategory[]>("Maintenance", new Company.TransactionCategory[3]
		{
			Company.TransactionCategory.Construction,
			Company.TransactionCategory.Repairs,
			Company.TransactionCategory.Bills
		}),
		new KeyValuePair<string, Company.TransactionCategory[]>("Software", new Company.TransactionCategory[6]
		{
			Company.TransactionCategory.Sales,
			Company.TransactionCategory.Licenses,
			Company.TransactionCategory.Marketing,
			Company.TransactionCategory.Contracts,
			Company.TransactionCategory.Distribution,
			Company.TransactionCategory.Royalties
		}),
		new KeyValuePair<string, Company.TransactionCategory[]>("Misc", new Company.TransactionCategory[6]
		{
			Company.TransactionCategory.Stocks,
			Company.TransactionCategory.Dividends,
			Company.TransactionCategory.Loan,
			Company.TransactionCategory.Interest,
			Company.TransactionCategory.Deals,
			Company.TransactionCategory.Legal
		})
	};

	[NonSerialized]
	public HashSet<Company.TransactionCategory> NoLoc = new HashSet<Company.TransactionCategory>
	{
		Company.TransactionCategory.Royalties,
		Company.TransactionCategory.Licenses
	};

	public VarValueSheet Bills;

	public GameObject SheetPanel;

	public GameObject GraphPanel;

	public GameObject DiscreteCombo;

	public GameObject TaxPanel;

	public GameObject TaxReportPanel;

	public Toggle LastTaxReportToggle;

	public Toggle CurrentTaxReportToggle;

	public Toggle CrunchToggle;

	public Text TaxLabel;

	public Text TaxAmount;

	public Text TaxReportDesc;

	public Text LastTaxLabel;

	public Text CurrentTaxLabel;

	public Text AccountantDetails;

	public Text CompletionAbility;

	public Text AccTeamText;

	public GUIProgressBar TaxReportProgress;

	public Toggle[] MainToggles;

	public int ActiveTax;

	private bool _disableToggle;

	private bool _taxInit;

	[NonSerialized]
	private bool _disableCrunchUpdate;

	[NonSerialized]
	private float _completionTimer;

	private int Granularity
	{
		get
		{
			return CompanyChart.Granularities[Mathf.Max(0, GranularityCombo.Selected)];
		}
	}

	public void ToggleTax(int i)
	{
		ActiveTax = i;
		UpdateTaxes(true);
	}

	public void OnToggle(int panel)
	{
		if (!_disableToggle)
		{
			_disableToggle = true;
			MainToggles[panel].isOn = true;
			_disableToggle = false;
			DiscreteCombo.SetActive(panel < 3);
			SheetPanel.SetActive(panel == 0);
			GraphPanel.SetActive(panel > 0 && panel < 3);
			TaxPanel.SetActive(panel == 4);
			CompanyChartPanel.ToggleStatMode(panel == 2);
			if (panel == 4)
			{
				Window.ChangeAssociatedTutorial("Accounting and taxes");
				TutorialSystem.Instance.StartTutorial("Accounting and taxes");
				InitTaxes();
			}
			else
			{
				Window.ChangeAssociatedTutorial(null);
			}
		}
	}

	public void CheckTaxes()
	{
		if (Window.Shown && TaxPanel.activeSelf)
		{
			InitTaxes();
		}
	}

	private void InitTaxes()
	{
		_taxInit = true;
		if (GameSettings.Instance.MyCompany.LastTaxReport != null)
		{
			LastTaxReportToggle.gameObject.SetActive(true);
			LastTaxReportToggle.isOn = true;
			CurrentTaxReportToggle.isOn = false;
			ActiveTax = 1;
		}
		else
		{
			LastTaxReportToggle.isOn = false;
			CurrentTaxReportToggle.isOn = true;
			LastTaxReportToggle.gameObject.SetActive(false);
			ActiveTax = 0;
		}
		int realYear = SDateTime.Now().RealYear;
		LastTaxLabel.text = (realYear - 1).ToString();
		CurrentTaxLabel.text = realYear.ToString();
		_taxInit = false;
		UpdateTaxes(true);
	}

	public void UpdateAccCrunch()
	{
		if (!_disableCrunchUpdate)
		{
			GameSettings.Instance.BackgroundAccounting.GetDevTeams().ForEach(delegate(Team x)
			{
				x.CrunchMode = CrunchToggle.isOn;
			});
			UpdateTaxes(true);
		}
	}

	private void UpdateTaxes(bool updateCompletion)
	{
		if (_taxInit || !TaxPanel.activeSelf || GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		TaxReport taxReport = ((ActiveTax == 0) ? GameSettings.Instance.MyCompany.CurrentTaxReport : GameSettings.Instance.MyCompany.LastTaxReport);
		if (taxReport == null)
		{
			InitTaxes();
			return;
		}
		if (ActiveTax == 0 || !TaxReport.NeedsAccounting(GameSettings.Instance.MyCompany.LastTaxReport))
		{
			TaxReportPanel.SetActive(false);
		}
		else
		{
			AccountingWork backgroundAccounting = GameSettings.Instance.BackgroundAccounting;
			TaxReportPanel.SetActive(true);
			_disableCrunchUpdate = true;
			if (backgroundAccounting.DevTeams.Count > 0)
			{
				CrunchToggle.isOn = backgroundAccounting.GetDevTeams().Mode((Team x) => x.CrunchMode);
				CrunchToggle.interactable = true;
			}
			else
			{
				CrunchToggle.isOn = false;
				CrunchToggle.interactable = false;
			}
			_disableCrunchUpdate = false;
			AccTeamText.text = backgroundAccounting.GetTeam(AccTeamText) ?? "None".Loc();
			SDateTime now = SDateTime.Now();
			SDateTime end = new SDateTime(0, 0, 0, 3, now.Year);
			double cost = taxReport.GetCost();
			TaxReportDesc.text = ((taxReport.ReportProgress < 1f) ? "TaxReportDesc".Loc(SDateTime.DateDiff2(now, end, true), cost.Currency()) : "Finished".Loc());
			bool flag = GameSettings.Instance.WouldBeAudited(taxReport);
			if (taxReport.ReportProgress < 1f && flag)
			{
				Text taxReportDesc = TaxReportDesc;
				taxReportDesc.text = taxReportDesc.text + "\n" + "TaxReportIllegalActivity".Loc().FontColor(Color.red);
			}
			TaxReportProgress.Value = taxReport.ReportProgress;
			int workers;
			float salary;
			taxReport.GetWorkersNeeded(out workers, out salary);
			AccountantDetails.text = "AccountantsNeeded".Loc() + ": " + workers + " - " + "EstimationAbbr".Loc("Salaries".Loc()) + ": " + salary.Currency();
			if ((double)salary > cost && !flag)
			{
				AccountantDetails.text += (" (" + "NotRecommended".Loc() + ")").FontColor(new Color(0.7f, 0f, 0f));
			}
			if (taxReport.ReportProgress < 1f)
			{
				if (updateCompletion)
				{
					float num = Mathf.Max(0.01f, taxReport.GetComplexity());
					float num2 = 0f;
					float num3 = backgroundAccounting.Priority;
					List<Team> devTeams = backgroundAccounting.GetDevTeams();
					for (int num4 = 0; num4 < devTeams.Count; num4++)
					{
						Team team = devTeams[num4];
						bool flag2 = team.SecondaryTasks.Contains(WorkItem.GetWorkTypeName(backgroundAccounting));
						List<Actor> employeesDirect = team.GetEmployeesDirect();
						for (int num5 = 0; num5 < employeesDirect.Count; num5++)
						{
							Actor actor = employeesDirect[num5];
							if (!actor.employee.IsRole(Employee.EmployeeRole.Service, actor.SecondaryWork))
							{
								continue;
							}
							int specialization = actor.employee.GetSpecialization(Employee.EmployeeRole.Service, "Accounting");
							if (specialization <= 0)
							{
								continue;
							}
							int num6 = backgroundAccounting.Priority;
							bool flag3 = true;
							for (int num7 = 0; num7 < team.WorkItems.Count; num7++)
							{
								WorkItem workItem = team.WorkItems[num7];
								if (!workItem.Paused && workItem != backgroundAccounting && workItem.HasWork(actor, true, false).IsWork())
								{
									if (flag2 && !team.SecondaryTasks.Contains(WorkItem.GetWorkTypeName(workItem)))
									{
										flag3 = false;
										break;
									}
									num6 += workItem.Priority;
								}
							}
							if (flag3)
							{
								float num8 = ((!actor.employee.Founder && team.CrunchMode) ? 3f : 1f);
								float num9 = (actor.employee.HasTrait(Employee.Trait.BornLeader) ? 0.25f : 1f);
								num2 += num9 * num8 * actor.Effectiveness * actor.LeaderEffectivenessFactor(3) * actor.employee.GetSkill(Employee.EmployeeRole.Service) * (1f + ((float)specialization - 1f) / 4f) * (GetWorkHoursUntil(actor, team, now, end) / 24f) * (num3 / (float)num6);
							}
						}
					}
					float num10 = num2 / (num * (1f - taxReport.ReportProgress));
					string input = ((num10 > 2f) ? "> 200%" : ((float)Mathf.FloorToInt(num10 * 20f) / 20f).ToPercent(false));
					CompletionAbility.text = "EstimatedFulfillment".Loc() + ": " + input.FontColor((num10 >= 1f) ? new Color(0f, 0.7f, 0f) : new Color(0.7f, 0f, 0f));
				}
			}
			else
			{
				CompletionAbility.text = "";
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		double num11 = 0.0;
		for (int num12 = 0; num12 < taxReport.Values.Length; num12++)
		{
			double num13 = taxReport.Values[num12];
			TaxReport.TaxType taxType = (TaxReport.TaxType)(num12 + 1);
			if (num12 < 2 || num13 != 0.0)
			{
				num11 += num13;
				stringBuilder.AppendLine(taxType.ToString().Loc());
				stringBuilder2.AppendLine(num13.Currency());
			}
		}
		stringBuilder.AppendLine("Balance".Loc());
		stringBuilder2.AppendLine(num11.Currency());
		if (num11 > 0.0)
		{
			float taxeRate = GameSettings.Instance.GetTaxeRate();
			stringBuilder.AppendLine(taxeRate.ToPercent() + " " + "Tax".Loc());
			double num14 = (double)taxeRate * num11;
			stringBuilder2.AppendLine(num14.Currency());
			double num15 = 0.0;
			if (taxReport.Optimization > 0f)
			{
				stringBuilder.AppendLine("Optimization".Loc());
				num15 = 0.0 - Math.Min(num11 * 0.05000000074505806, taxReport.Optimization);
				stringBuilder2.AppendLine(num15.Currency());
			}
			num11 = num14 + num15;
		}
		else
		{
			num11 = 0.0;
		}
		stringBuilder.AppendLine("ToPay".Loc(), 24);
		stringBuilder2.AppendLine(num11.Currency(), 24);
		TaxLabel.text = stringBuilder.ToString().TrimEnd();
		TaxAmount.text = stringBuilder2.ToString().TrimEnd();
	}

	private float GetWorkHoursUntil(Actor ac, Team t, SDateTime now, SDateTime end)
	{
		int num = 1;
		float num2 = 0f;
		SDateTime sDateTime = now;
		SDateTime? arriveTime = GameSettings.Instance.sActorManager.GetArriveTime(ac);
		while (now < end)
		{
			if (!sDateTime.EqualsVerySimple(now))
			{
				num++;
				sDateTime = now;
			}
			if (!now.EqualsVerySimple(ac.VacationMonth) && (!arriveTime.HasValue || now >= arriveTime.Value))
			{
				if (t.WorkStart > t.WorkEnd)
				{
					if (now.Hour >= t.WorkStart || now.Hour < t.WorkEnd)
					{
						num2 += 1f;
					}
				}
				else if (now.Hour >= t.WorkStart && now.Hour < t.WorkEnd)
				{
					num2 += 1f;
				}
			}
			now = new SDateTime(now.Minute, now.Hour + 1, now.Day, now.Month, now.Year);
		}
		return Mathf.Max(0f, num2 / (float)GameSettings.DaysPerMonth - (float)num);
	}

	private void Update()
	{
		_completionTimer += Time.deltaTime;
		if (_completionTimer > 1f)
		{
			_completionTimer = 0f;
			UpdateTaxes(true);
		}
		else
		{
			UpdateTaxes(false);
		}
	}

	public void UpdateBills()
	{
		object selectedItem = BillCombo.SelectedItem;
		if (selectedItem != null)
		{
			Company.TransactionCategory transactionCategory = (Company.TransactionCategory)selectedItem;
			KeyValuePair<string, float>[] l = GameSettings.Instance.BillsCurrent[transactionCategory].OrderBy((KeyValuePair<string, float> x) => x.Key).ToArray();
			bool loc = !NoLoc.Contains(transactionCategory);
			List<string> list = l.Select((KeyValuePair<string, float> x) => (!loc) ? x.Key : x.Key.LocTry()).ToList();
			List<string> list2 = l.Select((KeyValuePair<string, float> x) => x.Value.Currency()).ToList();
			Bills.SetData(list.ToArray(), list2.ToArray());
		}
		else
		{
			Bills.SetData(new string[0], new string[0]);
		}
	}

	private void Init()
	{
		TaxPanel.SetActive(false);
		Worksheet.Width = 5;
		Worksheet.Height = Categories.Count + Categories.Sum((KeyValuePair<string, Company.TransactionCategory[]> x) => x.Value.Length) + 2;
		Worksheet.Initialize();
		UpdateHeaders();
		Worksheet.MarkRow(0, Color.white);
		Worksheet[1, 0].fontStyle = FontStyle.Bold;
		Worksheet[2, 0].fontStyle = FontStyle.Bold;
		Worksheet[3, 0].fontStyle = FontStyle.Bold;
		Worksheet[4, 0].fontStyle = FontStyle.Bold;
		int num = 1;
		for (int num2 = 0; num2 < Categories.Count; num2++)
		{
			KeyValuePair<string, Company.TransactionCategory[]> keyValuePair = Categories[num2];
			Worksheet[0, num].text = ("Sheet" + keyValuePair.Key).LocDef(keyValuePair.Key.Loc());
			Worksheet[0, num].fontStyle = FontStyle.Bold;
			Worksheet.MarkRow(num, new Color32(163, 221, byte.MaxValue, byte.MaxValue));
			num++;
			for (int num3 = 0; num3 < keyValuePair.Value.Length; num3++)
			{
				Company.TransactionCategory t = keyValuePair.Value[num3];
				Worksheet[0, num].text = ("Sheet" + t).LocDef(t.ToString().Loc());
				Worksheet[0, num].fontStyle = FontStyle.Bold;
				if (t == Company.TransactionCategory.Interest)
				{
					for (int num4 = 0; num4 < Worksheet.CellImage.GetLength(0); num4++)
					{
						Worksheet.CellImage[num4, num].gameObject.AddComponent<GUIToolTipper>().TooltipDescription = "BankInterestHint";
					}
				}
				EventTrigger eventTrigger = Worksheet[0, num].gameObject.AddComponent<EventTrigger>();
				EventTrigger.TriggerEvent triggerEvent = new EventTrigger.TriggerEvent();
				triggerEvent.AddListener(delegate
				{
					if (BillCombo.Items.Contains(t))
					{
						BillCombo.SelectedItem = t;
					}
				});
				EventTrigger.Entry item = new EventTrigger.Entry
				{
					eventID = EventTriggerType.PointerClick,
					callback = triggerEvent
				};
				eventTrigger.triggers.Add(item);
				Worksheet.IndentCell(0, num, 8f);
				num++;
			}
		}
		Worksheet[0, num].text = "NetProfit".Loc();
		Worksheet[0, num].fontStyle = FontStyle.Bold;
		Worksheet.MarkRow(num, new Color32(239, 228, 138, byte.MaxValue));
		OnToggle(0);
		UpdateBills();
	}

	public void ChangeGranularity()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			int granularity = Granularity;
			offset = offset * _lastGranularity / granularity;
			_lastGranularity = granularity;
			UpdateSheet(false);
		}
	}

	private void UpdateHeaders()
	{
		int granularity = Granularity;
		SDateTime sDateTime = SDateTime.Now();
		int num = sDateTime.Month % granularity;
		sDateTime -= num;
		for (int i = 0; i < 4; i++)
		{
			int num2 = (i - 3 + offset) * granularity;
			switch (granularity)
			{
			case 12:
				Worksheet[i + 1, 0].text = (sDateTime + num2).RealYear.ToString();
				break;
			case 3:
				Worksheet[i + 1, 0].text = (sDateTime + num2).ToQuarterString();
				break;
			default:
				Worksheet[i + 1, 0].text = (sDateTime + num2).ToVeryCompactString();
				break;
			}
		}
	}

	public void ChangeOffset(int change)
	{
		switch (change)
		{
		case 0:
			if (offset < 0)
			{
				offset = 0;
				UpdateSheet(false);
			}
			break;
		case -1:
		{
			int granularity = Granularity;
			int num = GameSettings.Instance.MyCompany.Founded.Month % granularity;
			int num2 = (SDateTime.GetMonthsFlat(GameSettings.Instance.MyCompany.Founded, SDateTime.Now()) + num) / granularity;
			int num3 = Mathf.Min(0, -num2 + 3);
			if (offset > num3)
			{
				offset--;
				UpdateSheet(false);
			}
			break;
		}
		case 1:
			if (offset < 0)
			{
				offset++;
				UpdateSheet(false);
			}
			break;
		}
	}

	public void UpdateSheet(bool onlyThisMonth)
	{
		if (init)
		{
			return;
		}
		Company myCompany = GameSettings.Instance.MyCompany;
		int granularity = Granularity;
		int num = ((offset == 0) ? ((SDateTime.Now().Month + 1) % granularity) : 0);
		int actual = offset * granularity;
		if (offset < 0)
		{
			int num2 = (SDateTime.Now().Month + 1) % granularity;
			if (num2 > 0)
			{
				actual += granularity - num2;
			}
		}
		for (int i = 0; i < 4; i++)
		{
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			for (int j = 0; j < granularity; j++)
			{
				foreach (KeyValuePair<string, float> item in (i == 0 && offset == 0 && j == 0) ? myCompany.tempCashflow : myCompany.Cashflow.ToDictionary((KeyValuePair<string, List<float>> x) => x.Key, (KeyValuePair<string, List<float>> x) => (x.Value.Count <= -actual - 1) ? 0f : x.Value[x.Value.Count + actual]))
				{
					dictionary.AddUp(item.Key, item.Value);
				}
				actual--;
				if (num > 0)
				{
					num--;
					if (num == 0)
					{
						break;
					}
				}
			}
			int num3 = 1;
			float num4 = 0f;
			for (int num5 = 0; num5 < Categories.Count; num5++)
			{
				KeyValuePair<string, Company.TransactionCategory[]> keyValuePair = Categories[num5];
				int j2 = num3;
				float num6 = 0f;
				num3++;
				for (int num7 = 0; num7 < keyValuePair.Value.Length; num7++)
				{
					string key = keyValuePair.Value[num7].ToString();
					float num8 = (dictionary.ContainsKey(key) ? dictionary[key] : 0f);
					num6 += num8;
					SetCellValue(4 - i, num3, num8, false, keyValuePair.Value[num7] == Company.TransactionCategory.Interest);
					num3++;
				}
				num4 += num6;
				SetCellValue(4 - i, j2, num6);
			}
			SetCellValue(4 - i, num3, num4, true);
			if (onlyThisMonth && i == 0)
			{
				break;
			}
		}
		if (!onlyThisMonth)
		{
			UpdateCategoryColors();
			BillCombo.UpdateContent(GameSettings.Instance.BillsCurrent.Keys.OrderBy((Company.TransactionCategory x) => (int)x));
			UpdateBills();
			UpdateHeaders();
		}
	}

	private void UpdateCategoryColors()
	{
		int num = 1;
		HashSet<Company.TransactionCategory> hashSet = GameSettings.Instance.BillsCurrent.Keys.ToHashSet();
		for (int i = 0; i < Categories.Count; i++)
		{
			num++;
			for (int j = 0; j < Categories[i].Value.Length; j++)
			{
				Worksheet[0, num].color = (hashSet.Contains(Categories[i].Value[j]) ? LinkColor : NormalColor);
				num++;
			}
		}
	}

	private void SetCellValue(int i, int j, float val, bool green = false, bool paran = false)
	{
		Worksheet[i, j].text = (paran ? ("(" + val.Currency() + ")") : val.Currency());
		if (green)
		{
			Worksheet[i, j].color = ((val < -1f) ? HUD.GetPosNeg(false) : ((val > 1f) ? HUD.GetPosNeg(true) : Color.black));
		}
		else
		{
			Worksheet[i, j].color = ((val < -1f) ? HUD.GetPosNeg(false) : Color.black);
		}
	}

	public void ShowTaxes()
	{
		Show(false);
		OnToggle(4);
	}

	public void Show()
	{
		Show(true);
	}

	public void Show(bool toggle)
	{
		HUD.Instance.BankruptcyWarning.SetActive(false);
		if (init)
		{
			Init();
			init = false;
		}
		UpdateSheet(false);
		CompanyChartPanel.SetCompany(GameSettings.Instance.MyCompany);
		CompanyChartPanel.UpdateChart();
		if (TaxPanel.activeSelf)
		{
			InitTaxes();
		}
		if (toggle)
		{
			Window.Toggle();
		}
		else
		{
			Window.Show();
		}
	}

	public void ShowTimeline()
	{
		HUD.Instance.TimeLineWindow.Show(GameSettings.Instance.MyCompany, Window.Modal, Window.Modal ? Window : null, !Window.Modal);
	}
}
