using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Achievements;
using UnityEngine;
using UnityEngine.UI;

public class ContractWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIListView Contracts;

	public GUIListView ContractResults;

	public Text FeatureList;

	public Text RequirementsList;

	public GUICombobox SCMCombo;

	public VarValueSheet ContractInfo;

	public VarValueSheet ResultInfo;

	public Text DesignTeamLabel;

	public Text DevTeamLabel;

	public Text LeadLabel;

	public GameObject TeamPanel;

	public GameObject ManufacturingButton;

	public GameObject AcceptPanel;

	[NonSerialized]
	private Employee _leadDesigner;

	[NonSerialized]
	public HashSet<string> DesignTeams = new HashSet<string>();

	[NonSerialized]
	public HashSet<string> DevTeams = new HashSet<string>();

	private bool _init;

	public Toggle AvailableToggle;

	public Toggle CompletedToggle;

	public GameObject AvailablePanel;

	public GameObject CompletedPanel;

	private void Start()
	{
		Init();
	}

	public void PickLeadDesigner()
	{
		HUD.Instance.leadDesignWindow.Show(from x in DesignTeams.SelectNotNull(GameSettings.GetTeam).SelectMany((Team x) => from z in x.GetEmployeesDirect()
				select z.employee)
			where x.IsRole(Employee.RoleBit.Designer)
			select x, _leadDesigner, null, SetLeadDesigner, true);
	}

	public void SetLeadDesigner(Employee emp)
	{
		_leadDesigner = emp;
		UpdateLeadDesigner();
	}

	public void UpdateLeadDesigner()
	{
		ContractWork[] selected = Contracts.GetSelected<ContractWork>();
		if (selected.Length == 0 || selected.Any((ContractWork x) => !x.Hardware))
		{
			if (_leadDesigner != null && (_leadDesigner.MyActor == null || !_leadDesigner.IsRole(Employee.RoleBit.Designer) || !DesignTeams.Contains(_leadDesigner.MyActor.Team)))
			{
				_leadDesigner = null;
			}
			UpdateLeadLabel();
		}
		else
		{
			_leadDesigner = null;
			UpdateLeadLabel();
		}
	}

	private void UpdateLeadLabel()
	{
		LeadLabel.text = ((_leadDesigner != null) ? _leadDesigner.FullName : "None".Loc());
	}

	public void Init()
	{
		if (_init)
		{
			return;
		}
		_init = true;
		ContractInfo.SetData(new string[11]
		{
			"Company".Loc(),
			"Minimumprogress".Loc(),
			"Recommendeddesigners".Loc(),
			"Recommendedprogrammers".Loc(),
			"Recommendedartists".Loc(),
			"Time-limit".Loc() + "(" + "Months".Loc() + ")",
			"Expectedquality".Loc(),
			"Upfront".Loc(),
			"Whendone".Loc(),
			"Latepenalty".Loc(),
			"Costperbug".Loc()
		}, new string[0]);
		ResultInfo.SetData(new string[9]
		{
			"Income".Loc(),
			"Upfront".Loc(),
			"Bugpenalty".Loc(),
			"Latepenalty".Loc(),
			"Completionpenalty".Loc(),
			"Cancelpenalty".Loc(),
			"NetProfit".Loc(),
			"Qualityassesment".Loc(),
			"Delivered".Loc()
		}, new string[0]);
		Contracts.OnSelectChange = delegate
		{
			ContractWork[] selected = Contracts.GetSelected<ContractWork>();
			bool flag = selected.Length == 0 || selected.Any((ContractWork x) => !x.Hardware);
			TeamPanel.SetActive(flag && selected.Length != 0);
			ManufacturingButton.SetActive(!flag && selected.Length != 0);
			AcceptPanel.SetActive(selected.Length != 0);
			if (selected.Length == 1)
			{
				ContractWork sel = selected[0];
				SoftwareType type = sel.SoftwareType;
				if (sel.Hardware)
				{
					ContractInfo.SetData(new string[6]
					{
						"Company".Loc(),
						"Goal".Loc(),
						"Percopy".Loc(),
						"NetProfit".Loc(),
						"UndeliveredCopy".Loc(),
						"Time-limit".Loc() + "(" + "Months".Loc() + ")"
					}, new string[6]
					{
						sel.Company,
						sel.Goal.ToString("N0"),
						(sel.PerPrintFactor + sel.HardwarePrice).Currency(true, true),
						sel.PerPrintFactor.Currency(),
						((0f - sel.HardwarePrice) * 0.1f).Currency(),
						sel.Months.ToString()
					});
					StringBuilder stringBuilder = new StringBuilder();
					if (!GameSettings.Instance.GetAssemblyLines().Any((AssemblyLine x) => x.IsCompatible(sel.Manufacturing, sel.HardwareMask, sel.HardwareInputMask) > 0))
					{
						stringBuilder.AppendLine("NoValidAssemblyLinesShort".Loc().FontColor(HUD.GetPosNeg(false)));
					}
					for (int num = 0; num < sel.SoftwareCat.Manufacturing.Components.Length; num++)
					{
						HardwareComponent c = sel.SoftwareCat.Manufacturing.Components[num];
						if (c.Valid(sel.Features, null))
						{
							bool printer = (c.Mask & sel.HardwareInputMask) != 0;
							bool flag2 = GameSettings.Instance.ProductPrinters.Any((ProductPrinter x) => x.IsProducing(c, printer));
							string text = (printer ? "PrinterPost" : "AssemblerPost").Loc(Localization.GetSoftwareComponent(type, c.Name));
							if (!flag2 && GameSettings.Instance.ProductPrinters.Any((ProductPrinter x) => x.IsProducing(c, !printer)))
							{
								text = text + " (" + "NotThis".Loc((printer ? "Assemblers" : "Printers").Loc().ToLower()) + ")";
							}
							stringBuilder.AppendLine(text.FontColor(HUD.GetPosNeg(flag2)));
						}
					}
					RequirementsList.text = stringBuilder.ToString().Trim();
				}
				else
				{
					float devTime = type.DevTime(sel.Features, null, GameSettings.Instance.MyCompany, null, null, null, false, null);
					float num2 = SoftwareType.CodeArtRatio(sel.Features);
					int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(devTime);
					ContractInfo.SetData(new string[11]
					{
						"Company".Loc(),
						"Minimumprogress".Loc(),
						"Recommendeddesigners".Loc(),
						"Recommendedprogrammers".Loc(),
						"Recommendedartists".Loc(),
						"Time-limit".Loc() + "(" + "Months".Loc() + ")",
						"Expectedquality".Loc(),
						"Upfront".Loc(),
						"Whendone".Loc(),
						"Latepenalty".Loc(),
						"Costperbug".Loc()
					}, new string[11]
					{
						sel.Company,
						sel.MinProg.ToPercent(),
						Mathf.Ceil(optimalEmployeeCount[0]).ToString(),
						Mathf.Ceil((float)optimalEmployeeCount[1] * num2).ToString(),
						Mathf.Ceil((float)optimalEmployeeCount[1] * (1f - num2)).ToString(),
						sel.Months.ToString(),
						SoftwareType.GetQualityLabel(sel.Quality),
						sel.Initial.CurrencyInt(),
						sel.Done.CurrencyInt(),
						sel.Penalty.CurrencyInt(),
						sel.PerBug.Currency()
					});
					Dictionary<Employee.EmployeeRole, Dictionary<string, int>> specs = SoftwareType.GetSpecs(sel.Features);
					if (specs.Count > 0)
					{
						StringBuilder stringBuilder2 = new StringBuilder();
						foreach (KeyValuePair<Employee.EmployeeRole, Dictionary<string, int>> item in specs)
						{
							stringBuilder2.Append("<b>");
							stringBuilder2.Append(item.Key.ToString().Loc());
							stringBuilder2.AppendLine("</b>");
							foreach (KeyValuePair<string, int> item2 in item.Value)
							{
								stringBuilder2.Append("\t");
								stringBuilder2.AppendLine((item2.Value == 0) ? string.Format("{0} ({1})", item2.Key.LocTry(), "AnyLevel".Loc()) : "SpecSkill".Loc(item2.Value, item2.Key.LocTry()));
							}
							stringBuilder2.AppendLine();
						}
						RequirementsList.text = stringBuilder2.ToString().Trim();
					}
					else
					{
						RequirementsList.text = "None".Loc();
					}
				}
				FeatureList.text = string.Join("\n", sel.Features.Select((FeatureBase x) => Localization.GetFeature(type, x.Name)[0]).ToArray());
			}
			else
			{
				ContractInfo.UpdateValues(new string[0]);
				RequirementsList.text = "";
				FeatureList.text = "";
			}
			UpdateLeadDesigner();
		};
		ContractResults.OnSelectChange = delegate
		{
			ContractResult[] selected = ContractResults.GetSelected<ContractResult>();
			if (selected.Length == 1)
			{
				ContractResult contractResult = selected[0];
				if (contractResult.Contract.Hardware)
				{
					ResultInfo.SetData(new string[6]
					{
						"Income".Loc(),
						"Goal".Loc(),
						"Delivered".Loc(),
						"Undelivered".Loc(),
						"ManufacturingCost".Loc(),
						"NetProfit".Loc()
					}, new string[6]
					{
						contractResult.Income.Currency(),
						contractResult.Contract.Goal.ToString("N0"),
						contractResult.Contract.LastPrinted.ToString("N0"),
						contractResult.LatePenalty.Currency(),
						contractResult.CancelPenalty.Currency(),
						contractResult.FinalResult.Currency()
					});
				}
				else
				{
					ResultInfo.SetData(new string[9]
					{
						"Income".Loc(),
						"Upfront".Loc(),
						"Bugpenalty".Loc(),
						"Latepenalty".Loc(),
						"Completionpenalty".Loc(),
						"Cancelpenalty".Loc(),
						"NetProfit".Loc(),
						"Qualityassesment".Loc(),
						"Delivered".Loc()
					}, new string[9]
					{
						contractResult.Income.Currency(),
						contractResult.Contract.Initial.CurrencyInt(),
						contractResult.Bugs + " x " + contractResult.Contract.PerBug.Currency() + " = " + contractResult.BugPenalty.Currency(),
						contractResult.LatePenalty.Currency(),
						contractResult.QualityPenalty.Currency(),
						contractResult.CancelPenalty.Currency(),
						contractResult.FinalResult.Currency(),
						QualityAssess(contractResult).Loc(),
						(contractResult.MonthDiff < 0) ? "ContractEarly".Loc(((GameSettings.DaysPerMonth > 1) ? "Day" : "Month").LocPlural(-contractResult.MonthDiff)) : ((contractResult.MonthDiff == 0) ? "ContractOnTime".Loc() : "ContractLate".Loc(((GameSettings.DaysPerMonth > 1) ? "Day" : "Month").LocPlural(contractResult.MonthDiff)))
					});
				}
			}
			else
			{
				ResultInfo.UpdateValues(new string[0]);
			}
		};
		ContractResults.Initialize();
		GameSettings instance = GameSettings.Instance;
		instance.OnServersChanged = (EventHandler)Delegate.Combine(instance.OnServersChanged, (EventHandler)delegate
		{
			if (Window.Shown)
			{
				UpdateSCMCombo();
			}
		});
	}

	public static string QualityAssess(ContractResult r)
	{
		if (r.QualityResult < 0.9f)
		{
			return "Inadequate";
		}
		if (r.GetRep() < 0f && (float)r.Bugs / Mathf.Max(2000f, r.Contract.GetDevTime() * SoftwareAlpha.BugLimitFactor) > 0.1f)
		{
			return "Glitchy";
		}
		if (r.QualityResult < 1.05f)
		{
			return "Satisfactory";
		}
		return "Outstanding";
	}

	public void UpdateTeamLabel()
	{
		DesignTeamLabel.text = DesignTeams.GetListAbbrev("Team");
		DevTeamLabel.text = DevTeams.GetListAbbrev("Team");
	}

	public void Show(bool toggle = true)
	{
		if (GameSettings.Instance.Difficulty.Contracts < 0.5f)
		{
			Window.Close();
			return;
		}
		bool flag;
		if (toggle)
		{
			flag = Window.ToggleReturn();
		}
		else
		{
			flag = true;
			Window.Show();
		}
		if (flag)
		{
			DesignTeams.Clear();
			DesignTeams.AddRange(GameSettings.Instance.GetDefaultTeams("ContractDesign"));
			DevTeams.Clear();
			DevTeams.AddRange(GameSettings.Instance.GetDefaultTeams("ContractDevelopment"));
			UpdateTeamLabel();
			UpdateSCMCombo();
			Init();
			_leadDesigner = null;
			UpdateLeadDesigner();
			TutorialSystem.Instance.StartTutorial("Contracts");
			SetTab(true);
		}
	}

	public void OnToggle()
	{
		AvailablePanel.SetActive(AvailableToggle.isOn);
		CompletedPanel.SetActive(!AvailableToggle.isOn);
	}

	public void SetTab(bool available)
	{
		AvailableToggle.isOn = available;
		CompletedToggle.isOn = !available;
		AvailablePanel.SetActive(available);
		CompletedPanel.SetActive(!available);
	}

	private void UpdateSCMCombo()
	{
		SCMCombo.UpdateContent(GameSettings.Instance.GetAllServerGroups(true));
		ServerGroup server;
		if (GameSettings.GetPrefServer("Contract", out server))
		{
			SCMCombo.SelectedItem = server;
		}
	}

	public void PickTeams(bool design)
	{
		HashSet<string> t = (design ? DesignTeams : DevTeams);
		HUD.Instance.TeamSelectWindow.Show(false, t, delegate(string[] ts)
		{
			t.Clear();
			t.AddRange(ts);
			UpdateTeamLabel();
			UpdateLeadDesigner();
		}, design ? "Design" : "Development", null, design ? "DesignDocument" : "SoftwareAlpha");
	}

	public void AddWork()
	{
		List<ContractWork> current = Contracts.Items.OfType<ContractWork>().ToList();
		float num = (float)current.Count((ContractWork x) => x.Hardware) / (float)current.Count;
		bool hardware = (!GameSettings.Instance.CampaignMode || GameSettings.HasCompletedOrInMission("Mission11")) && GameSettings.Instance.MyCompany.BusinessStars >= 2 && num < 0.25f;
		List<SoftwareCategory> list = new List<SoftwareCategory>();
		FindCats(list, hardware);
		if (list.Count == 0)
		{
			hardware = !hardware;
			FindCats(list, hardware);
		}
		list.Shuffle();
		SoftwareCategory softwareCategory = list.MinInstance((SoftwareCategory x) => current.Count((ContractWork y) => y.Hardware == hardware && y.SoftwareCat == x));
		if (softwareCategory != null)
		{
			ContractWork contractWork = ContractWork.GenerateWork(softwareCategory, ContractDifficulty(hardware), GameSettings.Instance.MyCompany.DiscreteRep, hardware);
			if (contractWork != null)
			{
				Contracts.Items.Add(contractWork);
			}
		}
	}

	public void FindCats(List<SoftwareCategory> cats, bool hardware)
	{
		foreach (SoftwareCategory item in from x in MarketSimulation.Active.SoftwareTypes.Values.Where((SoftwareType x) => x.OneClient && x.IsUnlocked(TimeOfDay.Instance.Year)).SelectMany((SoftwareType x) => x.Categories.Values)
			where (x.Hardware || !hardware) && x.IsUnlocked(TimeOfDay.Instance.Year)
			select x)
		{
			cats.Add(item);
		}
	}

	public void ShowManufacturing()
	{
		ContractWork[] selected = Contracts.GetSelected<ContractWork>();
		if (selected.Length != 0)
		{
			ContractWork contractWork = selected.FirstOrDefault((ContractWork x) => x.Hardware);
			if (contractWork != null)
			{
				int value = (int)(contractWork.Goal / contractWork.Months);
				HUD.Instance.ManufacturingWindow.Show(contractWork.Manufacturing, contractWork.Features, null, value);
			}
		}
	}

	public float ContractDifficulty(bool hardware)
	{
		float r = GameSettings.Instance.MyCompany.DiscreteRep;
		if (Contracts.Items.Count == 0)
		{
			return r;
		}
		List<float> list = (from x in Contracts.Items.OfType<ContractWork>()
			where x.Hardware == hardware
			select x.Difficulty into x
			where x < r
			orderby x
			select x).ToList();
		list.Add(r);
		float num = list[0];
		float min = 0f;
		float max = list[0];
		for (int num2 = 1; num2 < list.Count - 1; num2++)
		{
			float num3 = list[num2 + 1] - list[num2];
			if (num3 > num)
			{
				num = num3;
				min = list[num2];
				max = list[num2 + 1];
			}
		}
		return UnityEngine.Random.Range(min, max);
	}

	public void UpdateContracts(SDateTime time)
	{
		for (int i = 0; i < Contracts.Items.Count; i++)
		{
			if (SDateTime.GetMonths(((ContractWork)Contracts.Items[i]).Added, time) > (float)UnityEngine.Random.Range(4, 8))
			{
				Contracts.Items.RemoveAt(i);
				i--;
			}
		}
		int num = Mathf.CeilToInt(GameSettings.Instance.MyCompany.DiscreteRep * 15f + 5f) - Contracts.Items.Count;
		int num2 = UnityEngine.Random.Range(num / 2, num);
		for (int j = 0; j < num2; j++)
		{
			AddWork();
		}
	}

	public void AcceptJobs()
	{
		object obj;
		if (SCMCombo.Selected >= 1)
		{
			ServerGroup selected = SCMCombo.GetSelected<ServerGroup>();
			obj = ((selected != null) ? selected.Name : null);
		}
		else
		{
			obj = null;
		}
		string scm = (string)obj;
		ContractWork[] selected2 = Contracts.GetSelected<ContractWork>();
		if (selected2.Length == 0)
		{
			return;
		}
		string text = null;
		List<Team> designTeams = DesignTeams.SelectNotNull(GameSettings.GetTeam).ToList();
		List<Team> devTeams = DevTeams.SelectNotNull(GameSettings.GetTeam).ToList();
		foreach (ContractWork contractWork in selected2)
		{
			if (!contractWork.Hardware)
			{
				text = DesignDocumentWindow.CheckCompetency(contractWork.Features, designTeams, devTeams);
				if (text != null)
				{
					break;
				}
			}
		}
		if (text != null)
		{
			WindowManager.Instance.ShowMessageBox("DesignProductFeatureHint".Loc(text), false, DialogWindow.DialogType.Question, delegate
			{
				CheckHardware(selected2, scm);
			});
		}
		else
		{
			CheckHardware(selected2, scm);
		}
	}

	private void OnEnable()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			UpdateSCMCombo();
		}
	}

	private void CheckHardware(ContractWork[] selected, string scm)
	{
		if (selected.Any((ContractWork x) => x.Hardware))
		{
			Dictionary<IManufacturable, int> dict = new Dictionary<IManufacturable, int>();
			Dictionary<IManufacturable, int> dict2 = new Dictionary<IManufacturable, int>();
			bool flag = false;
			for (int num = 0; num < GameSettings.Instance.ProductPrinters.Count; num++)
			{
				ProductPrinter productPrinter = GameSettings.Instance.ProductPrinters[num];
				if (productPrinter.Type == ProductPrinter.PrinterType.Component)
				{
					if (productPrinter.TargetComponent != null && productPrinter.TargetComponent.Parent.Type.OneClient)
					{
						dict.AddTo(productPrinter.TargetComponent.Parent.Category, productPrinter.TargetComponent.Mask, (int x, int y) => x | y);
					}
				}
				else if (productPrinter.Type == ProductPrinter.PrinterType.Assembly && productPrinter.TargetProcess != null && !productPrinter.TargetProcess.Final && productPrinter.TargetProcess.Parent.Type.OneClient)
				{
					dict2.AddTo(productPrinter.TargetProcess.Parent.Category, productPrinter.TargetProcess.Output.Mask, (int x, int y) => x | y);
				}
			}
			foreach (ContractWork contractWork in selected)
			{
				int orDefault = dict.GetOrDefault(contractWork.Manufacturing, 0);
				int orDefault2 = dict2.GetOrDefault(contractWork.Manufacturing, 0);
				int num3 = contractWork.HardwareMask & ~contractWork.HardwareInputMask;
				if ((contractWork.HardwareInputMask & orDefault) != contractWork.HardwareInputMask || (num3 & orDefault2) != num3)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				WindowManager.Instance.ShowMessageBox("ManufactureContractWarning".Loc(), false, DialogWindow.DialogType.Question, delegate
				{
					StartWork(selected, scm);
				});
			}
			else
			{
				StartWork(selected, scm);
			}
		}
		else
		{
			StartWork(selected, scm);
		}
	}

	private void StartWork(ContractWork[] selected, string scm)
	{
		GameSettings.Instance.TeamDefaults["ContractDesign"] = DesignTeams.ToHashSet();
		GameSettings.Instance.TeamDefaults["ContractDevelopment"] = DevTeams.ToHashSet();
		Contracts.Selected.Clear();
		PrintJob printJob = null;
		bool flag = selected.Count((ContractWork x) => x.Hardware) > 1;
		UpdateLeadDesigner();
		foreach (ContractWork contractWork in selected)
		{
			Contracts.Items.Remove(contractWork);
			if (contractWork.Hardware)
			{
				PrintJob printJob2 = new PrintJob(contractWork);
				GameSettings.Instance.AddPrintOrder(printJob2, flag);
				printJob = printJob2;
				contractWork.SetDeadline();
				continue;
			}
			AchievementController.SetInteraction(AchievementController.Mechanics.Contracts);
			DesignDocument designDocument = contractWork.GenerateWorkItem(scm);
			designDocument.AddDevTeams(DesignTeams);
			designDocument.NextPhaseTeam = DevTeams.ToSHashSet();
			designDocument.CheckCompetency();
			designDocument.SetLeadDesigner(_leadDesigner);
			GameSettings.Instance.MyCompany.AddWorkItem(designDocument);
			NotificationManager.AddNotification("ContractIncomeMsg".Loc(contractWork.Initial.CurrencyInt()), "Paper", NotificationManager.NotificationType.Good);
			GameSettings.Instance.MyCompany.MakeTransaction(contractWork.Initial, Company.TransactionCategory.Contracts, true);
		}
		if (selected.Any((ContractWork x) => !x.Hardware))
		{
			GameSettings.SavePrefServer("Contract", scm);
		}
		if (printJob != null)
		{
			if (printJob.Hardware && !flag)
			{
				GameSettings.Instance.PromptPrintAssignment(printJob);
			}
			HUD.Instance.distributionWindow.Show(printJob);
		}
		HUD.Instance.comingReleaseWindow.CheckRefresh();
	}

	public void RejectJobs()
	{
		ContractWork[] selected = Contracts.GetSelected<ContractWork>();
		if (selected.Length == 0)
		{
			return;
		}
		WindowManager.Instance.ShowMessageBox("RejectConfirmation".Loc(), true, DialogWindow.DialogType.Question, delegate
		{
			Contracts.Selected.Clear();
			ContractWork[] array = selected;
			foreach (ContractWork value in array)
			{
				Contracts.Items.Remove(value);
			}
		}, "Reject contract");
	}

	public void FixReferences()
	{
		Contracts.Items.OfType<ContractWork>().ForEachEnum(delegate(ContractWork x)
		{
			x.FixReferences();
		});
		ContractResults.Items.OfType<ContractResult>().ForEachEnum(delegate(ContractResult x)
		{
			x.Contract.FixReferences();
		});
	}

	private void Update()
	{
		if (WindowManager.Instance.GetFrontMostWindow() == Window && Contracts.IsFocused && Contracts.Selected.Count > 0 && (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter)))
		{
			int value = Contracts.Selected[0];
			AcceptJobs();
			if (Contracts.ActualItems.Count > 0)
			{
				Contracts.Select(Mathf.Clamp(value, 0, Contracts.ActualItems.Count - 1));
			}
		}
	}
}
