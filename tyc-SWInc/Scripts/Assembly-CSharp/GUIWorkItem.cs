using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIWorkItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public LayoutElement WorkLayout;

	public GameObject ActionButtonPrefab;

	public GameObject DealIndicator;

	public Text Title;

	public Text Description;

	public Text State;

	public Text Progress;

	public Text Team;

	public Text PriorityLabel;

	[NonSerialized]
	public WorkItem work;

	public Image TypeBar;

	public Image TeamImg;

	public LeftwardProgress ProgImg;

	public LeftwardProgress BackProgImg;

	public RectTransform MaxIndicator;

	public RectTransform ButtonPanel;

	public RectTransform ProgressBar;

	public Sprite SprExpand;

	public Sprite SprCollapse;

	public Sprite Play;

	public Sprite Pause;

	public Sprite Deal;

	public Sprite PeopleTeam;

	public Sprite CompanyTeam;

	public Image MainIcon;

	public Image StateIcon;

	public Image SelfImage;

	public GameObject UnassignWarning;

	public GameObject PauseWarning;

	public RectTransform BonusButtonPanel;

	public GameObject BonusButtonPrefab;

	public GameObject[] PriorityStuff;

	public Image PauseButton;

	public Image ActiveButton;

	public int BonusButtons;

	public GUIToolTipper TitleTipper;

	private bool _hovering;

	[NonSerialized]
	private Dictionary<string, Image> Buttons = new Dictionary<string, Image>();

	[NonSerialized]
	private bool _initialized;

	public void Remove()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void ChangePriority(int val)
	{
		work.Priority = Mathf.Clamp(work.Priority + val, 1, 10);
		UpdatePriorityLabel();
		SelectorController.CanClick = false;
	}

	private void UpdatePriorityLabel()
	{
		if (work != null)
		{
			PriorityLabel.text = work.Priority.ToString();
		}
	}

	private void Start()
	{
		if (work != null)
		{
			GlobalSearchPanel.Instance.RefreshQuery(this, work.QueryString);
			Init(work);
			UpdatePriorityLabel();
			string text = work.ProgressTip();
			if (!string.IsNullOrEmpty(text))
			{
				Progress.GetComponent<GUIToolTipper>().TooltipDescription = text;
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public GameObject AddActionButton(string label, Action OnClick)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(ActionButtonPrefab);
		gameObject.GetComponent<Button>().onClick.AddListener(delegate
		{
			OnClick();
		});
		gameObject.GetComponentInChildren<Text>().text = label.Loc();
		gameObject.transform.SetParent(ButtonPanel, false);
		gameObject.name = label + "Button";
		Buttons[label] = gameObject.GetComponent<Image>();
		return gameObject;
	}

	public void CheckInit()
	{
		if (!_initialized && work != null)
		{
			Init(work);
		}
	}

	private void Init(WorkItem item)
	{
		if (_initialized)
		{
			return;
		}
		_initialized = true;
		work = item;
		if (item == null || item.Done)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		base.name = work.GetWorkTypeName() + ((work.contract != null) ? "Contract" : "");
		UpdatePauseButton();
		Title.text = work.Name;
		if (Title.GetLineWidth(Title.text) >= 210)
		{
			TitleTipper.ToolTipValue = Title.text;
		}
		else
		{
			TitleTipper.enabled = false;
		}
		UpdateCollapse();
		string tut = item.GetTutorial();
		if (tut != null)
		{
			AddBonusButton("Question", "Tutorial".Loc(), delegate
			{
				TutorialSystem.Instance.StartTutorial(tut, true);
			});
		}
		bool flag = false;
		SoftwareUpdate softwareUpdate;
		if ((softwareUpdate = item as SoftwareUpdate) != null)
		{
			flag = true;
			AddBonusButton("Server", "Server".Loc(), delegate
			{
				ServerGroup[] serv = GameSettings.Instance.GetAllServerGroups().ToArray();
				if (serv.Length != 0)
				{
					WindowManager.Instance.MultiWindow.Show("Server", serv.Select((ServerGroup x) => x.GetDisplayName()).ToArray(), delegate(int i)
					{
						if (i == -1)
						{
							GameSettings.Instance.DeregisterServerItem(softwareUpdate);
							softwareUpdate.Server2 = null;
						}
						else
						{
							GameSettings.Instance.RegisterWithServer(serv[i].Name, softwareUpdate);
							softwareUpdate.Server2 = serv[i].Name;
						}
					}, true);
				}
			});
		}
		SoftwareWorkItem workItem;
		DesignDocument designDocument;
		if (!flag && (workItem = item as SoftwareWorkItem) != null && ((designDocument = item as DesignDocument) == null || designDocument.Parent == null))
		{
			AddBonusButton("Info", "Projectdetails".Loc(), delegate
			{
				SpawnDevInfoWindow(workItem, workItem is DesignDocument);
			});
			if (work.contract == null && work.ActiveDeal == null && item.GetNetworkDealState() != WorkItem.NetworkDealState.Receiver)
			{
				AddBonusButton("Cogs", "Changesoftwarename".Loc(), delegate
				{
					if (item.GetNetworkDealState() == WorkItem.NetworkDealState.None)
					{
						WindowManager.SpawnInputDialog("Changesoftwarename".Loc(), "Name".Loc(), workItem.SoftwareName, delegate(string newName)
						{
							if (!newName.Equals(workItem.SoftwareName))
							{
								if (!CheckValidNewName(newName, workItem))
								{
									WindowManager.Instance.ShowMessageBox("DesignProductNameError".Loc(), false, DialogWindow.DialogType.Error);
								}
								else
								{
									work.Name = newName;
									workItem.SoftwareName = newName;
									MarketingPlan marketingPlan = GameSettings.Instance.MyCompany.WorkItems.OfType<MarketingPlan>().FirstOrDefault((MarketingPlan x) => x.TargetItem == work);
									if (marketingPlan != null)
									{
										marketingPlan.CorrectName();
									}
									GlobalSearchPanel.Instance.RefreshQuery(this, work.QueryString);
								}
							}
						}, null, 64);
					}
				});
			}
		}
		SoftwareAlpha alpha;
		if ((alpha = item as SoftwareAlpha) != null)
		{
			AddBonusButton("Server", "Server".Loc(), delegate
			{
				ServerGroup[] serv = GameSettings.Instance.GetAllServerGroups().ToArray();
				if (serv.Length != 0)
				{
					WindowManager.Instance.MultiWindow.Show("Server", serv.Select((ServerGroup x) => x.GetDisplayName()).ToArray(), delegate(int i)
					{
						if (i == -1)
						{
							GameSettings.Instance.DeregisterServerItem(alpha);
							alpha.Server2 = null;
						}
						else
						{
							GameSettings.Instance.RegisterWithServer(serv[i].Name, alpha);
							alpha.Server2 = serv[i].Name;
						}
					}, true);
				}
			});
			if (alpha.SWCategory.Hardware)
			{
				AddBonusButton("Hardware", "Manufacturing".Loc(), delegate
				{
					HUD.Instance.ManufacturingWindow.Show(alpha.Manufacturing, alpha.GetFeatures(), alpha.GetFeaturesFactors());
				});
			}
			AddBonusButton("Smiley", "Pastpeerreviews".Loc(), delegate
			{
				if (alpha.PastReviews.Count > 0)
				{
					WindowManager.Instance.MultiWindow.Show("Pastpeerreviews", alpha.PastReviews.Select((ReviewWindow.ReviewData x) => x.BuildDate.ToCompactString2()), delegate(int i)
					{
						HUD.Instance.reviewWindow.Show(alpha.PastReviews[i], alpha);
					}, false);
				}
			});
		}
		MarketingPlan mark;
		if ((mark = item as MarketingPlan) != null && mark.Type == MarketingPlan.TaskType.PostMarket && mark.GetNetworkDealState() != WorkItem.NetworkDealState.Receiver)
		{
			AddBonusButton("Money", "Budget".Loc(), delegate
			{
				if (item.GetNetworkDealState() == WorkItem.NetworkDealState.None)
				{
					WindowManager.SpawnInputDialog("Budget".Loc(), "Budget".Loc(), mark.MaxBudget.Currency(false), delegate(string x)
					{
						try
						{
							float x2 = (float)Convert.ToDouble(x);
							mark.MaxBudget = x2.FromCurrency();
						}
						catch (Exception)
						{
						}
					});
				}
			});
		}
		SupportWork sp;
		if ((sp = item as SupportWork) != null && sp.TargetProduct.Type != MarketSimulation.Active.DigitalDistSoft)
		{
			AddBonusButton("Info", "Details".Loc(), delegate
			{
				HUD.Instance.GetProductWindow(null).ShowProductDetails(sp.TargetProduct);
			});
		}
		MainIcon.sprite = ObjectDatabase.GetIcon(item.GetIcon());
		InitButtons();
		TypeBar.color = item.BackColor;
		UpdatePriorityLabel();
		work.InitWorkItem(this);
		DealIndicator.SetActive(work.ActiveDeal != null);
	}

	private static bool CheckValidNewName(string newName, SoftwareWorkItem item)
	{
		if (item.AddOn)
		{
			SoftwareProduct addonParent = item.AddonParent;
			List<AddOnProduct> list = ((addonParent != null) ? addonParent.Addons.GetOrNull(item.AddonType) : null);
			if (list != null)
			{
				return list.None((AddOnProduct x) => x.Name.Equals(newName));
			}
			return true;
		}
		if (!(from x in GameSettings.Instance.simulation.GetAllProducts(true)
			select x.Name).Contains(newName) && !(from x in GameSettings.Instance.simulation.Companies.Values.SelectMany((SimulatedCompany x) => x.Releases)
			select x.Name).Contains(newName) && !(from x in GameSettings.Instance.simulation.Companies.Values.SelectMany((SimulatedCompany x) => x.ProjectQueue)
			select x.Name).Contains(newName))
		{
			return GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareWorkItem>().None((SoftwareWorkItem x) => x != item && !x.AddOn && x.SoftwareName.Equals(newName));
		}
		return true;
	}

	public static void TallyEmps(IEnumerable<Team> teams, ref int designers, ref float programmers, ref float artists, bool design)
	{
		foreach (Team team in teams)
		{
			List<Actor> employeesDirect = team.GetEmployeesDirect();
			for (int i = 0; i < employeesDirect.Count; i++)
			{
				Actor actor = employeesDirect[i];
				if (actor.employee.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead))
				{
					continue;
				}
				if (design)
				{
					if (actor.employee.IsRole(Employee.RoleBit.Designer))
					{
						designers++;
					}
					continue;
				}
				bool flag = actor.employee.IsRole(Employee.RoleBit.Programmer);
				bool flag2 = actor.employee.IsRole(Employee.RoleBit.Artist);
				if (flag2 && flag)
				{
					artists += 0.5f;
					programmers += 0.5f;
				}
				else if (flag2)
				{
					artists += 1f;
				}
				else if (flag)
				{
					programmers += 1f;
				}
			}
		}
	}

	public static void SpawnDevInfoWindow(SoftwareWorkItem work, bool design)
	{
		GUIWindow tableInfoWindow = WindowManager.GetTableInfoWindow("WorkInfo" + work.SoftwareName);
		if (tableInfoWindow != null)
		{
			tableInfoWindow.Close();
			return;
		}
		SoftwareType type = work.Type;
		SDateTime time = SDateTime.Now();
		FeatureBase[] features = work.GetFeatures();
		SoftwareProduct sequelTo = work.SequelTo;
		SoftwareCategory sWCategory = work.SWCategory;
		uint num = ((!work.AddOn) ? type.GetReach(sWCategory, work.OSs) : ((!work.WorkAddOn) ? ((uint)work.AddonParent.Userbase) : 0u));
		sequelTo = ((sequelTo != null && sequelTo.Traded) ? null : sequelTo);
		float num2 = (work.AddOn ? work.AddonType.DevTime(features.OfType<AddOnFeature>().ToArray(), work.GetFactors(), sWCategory, GameSettings.Instance.MyCompany, work.TechLevels) : type.DevTime(features, sWCategory, GameSettings.Instance.MyCompany, work.TechLevels, work.OSs, work.Framework, work.CreateFramework != null, work.SequelTo));
		float num3 = num2;
		float codeArtRatio = work.CodeArtRatio;
		float num4 = num3 * codeArtRatio;
		if (type.OSSpecific && work.OSs != null)
		{
			int num5 = Mathf.Max(0, work.OSs.Length - 1);
			num2 += (float)num5;
			num4 += (float)num5;
		}
		int[] optimalEmployeeCount = SoftwareType.GetOptimalEmployeeCount(num2);
		int designers = 0;
		float programmers = 0f;
		float artists = 0f;
		if (design)
		{
			TallyEmps(work.DevTeams.SelectNotNull(GameSettings.GetTeam), ref designers, ref programmers, ref artists, true);
			DesignDocument designDocument = (DesignDocument)work;
			if (designDocument.NextPhaseTeam != null)
			{
				TallyEmps(designDocument.NextPhaseTeam.SelectNotNull(GameSettings.GetTeam), ref designers, ref programmers, ref artists, false);
			}
		}
		else
		{
			TallyEmps(work.DevTeams.SelectNotNull(GameSettings.GetTeam), ref designers, ref programmers, ref artists, false);
		}
		artists = Mathf.Ceil(artists);
		programmers = Mathf.Ceil(programmers);
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		list.Add("Type".Loc());
		list2.Add(work.AddOn ? work.AddonType.GetPrettyName() : work.SWCategory.GetPrettyName());
		if (work.AddOn)
		{
			list.Add("");
			list2.Add(work.WorkAddOn ? work.AddonWorkParent.SoftwareName : work.AddonParent.Name);
		}
		list.Add("Starteddevelopment".Loc());
		list2.Add(work.DevStart.ToCompactString2());
		if (work.Publishing != null)
		{
			list.Add("Publisher".Loc());
			list2.Add(work.Publishing.Publisher.Name);
			bool flag = true;
			foreach (string deal in work.Publishing.Deals)
			{
				list.Add(flag ? "PublisherJobs".Loc() : "");
				flag = false;
				list2.Add(deal.Loc());
			}
		}
		if (!work.AddOn && work.ActiveDeal == null)
		{
			list.Add("LeadDesigner".Loc());
			Employee leadDesigner = work.GetLeadDesigner();
			list2.Add((leadDesigner == null) ? "None".Loc() : leadDesigner.FullName);
		}
		if (design)
		{
			list.Add("Recommendeddesigners".Loc());
			list2.Add(designers + "/" + Mathf.Ceil(optimalEmployeeCount[0]).ToString());
		}
		list.Add("Recommendedprogrammers".Loc());
		list.Add("Recommendedartists".Loc());
		list2.Add(programmers + "/" + Mathf.Ceil((float)optimalEmployeeCount[1] * codeArtRatio).ToString());
		list2.Add(artists + "/" + Mathf.Ceil((float)optimalEmployeeCount[1] * (1f - codeArtRatio)).ToString());
		if (work.contract != null)
		{
			if (!design || !work.AllZero(false))
			{
				list.Add("Deadline".Loc());
				list2.Add((work.DevStart + new SDateTime(work.contract.Months, 0)).ToCompactString2());
			}
			list.Add("Minimumprogress".Loc());
			list.Add("Requiredquality".Loc());
			list.Add("Payout".Loc());
			list.Add("Penalty".Loc());
			list.Add("Costperbug".Loc());
			list2.Add(work.contract.MinProg.ToPercent());
			list2.Add(SoftwareType.GetQualityLabel(work.contract.Quality));
			list2.Add(work.contract.Done.CurrencyInt());
			list2.Add(work.contract.Penalty.CurrencyInt());
			list2.Add(work.contract.PerBug.Currency());
		}
		else
		{
			WorkDeal activeDeal = work.ActiveDeal;
			if (activeDeal != null)
			{
				list.Add("Deadline".Loc());
				list2.Add(activeDeal.GetEndDate());
			}
			else
			{
				Employee employee = ((work.LeadWork != null) ? work.LeadWork.MaxInstance((KeyValuePair<Employee, float> x) => x.Value).Key : null);
				list.Add("Releasedate".Loc());
				list.Add("Consumerreach".Loc());
				list.Add("Royalties".Loc());
				list2.Add(work.ReleaseDate.HasValue ? work.ReleaseDate.Value.ToCompactString2() : "None".Loc());
				list2.Add(num.ToString("N0"));
				float num6 = work.TechLevels.Values.Where((TechLevel x) => x.HasToPay(work.MyCompany)).SumSafe((TechLevel x) => x.Royalty) + work.FrameworkRoyalty + ((work.Publishing != null) ? work.Publishing.Royalty : 0f) + ((employee != null && employee.HasDemanded(LeadDesignDemands.Demand.Royalties)) ? 0.05f : 0f);
				float num7 = work.GetWorkRoyalties().SumSafe((KeyValuePair<Company, float> x) => x.Value);
				num6 = 1f - (1f - num7) * (1f - num6);
				list2.Add(num6.ToPercent());
				if (!design)
				{
					list.Add("Licenses".Loc());
					int emps = 0;
					List<Team> devTeams = work.GetDevTeams();
					for (int num8 = 0; num8 < devTeams.Count; num8++)
					{
						List<Actor> employeesDirect = devTeams[num8].GetEmployeesDirect();
						for (int num9 = 0; num9 < employeesDirect.Count; num9++)
						{
							WorkItem.HasWorkReturn hasWorkReturn = work.HasWork(employeesDirect[num9], employeesDirect[num9].SecondaryWork, false);
							if (hasWorkReturn == WorkItem.HasWorkReturn.True || hasWorkReturn == WorkItem.HasWorkReturn.Secondary)
							{
								emps++;
							}
						}
					}
					list2.Add(work.Needs.Values.Where((SoftwareProduct x) => x.HasToPay(work.MyCompany)).SumSafe((SoftwareProduct x) => x.GetLicenseCost(true) * (float)emps).Currency());
				}
				list.Add("Appxbandwidth".Loc());
				list2.Add(((float)((double)(SoftwareType.GetServerRequirement(features) * (float)num * sWCategory.Popularity) * sWCategory.GetRetentionFact() / (double)num3)).BandwidthFactor(time).Bandwidth());
			}
		}
		foreach (KeyValuePair<string, SoftwareProduct> need in work.Needs)
		{
			list.Add(need.Key.LocSW());
			list2.Add(need.Value.Name);
		}
		if (type.OSSpecific && work.OSs != null)
		{
			list.Add("Operatingsystems".Loc());
			for (int num10 = 0; num10 < work.OSs.Length - 1; num10++)
			{
				list.Add("");
			}
			for (int num11 = 0; num11 < work.OSs.Length; num11++)
			{
				list2.Add(work.OSs[num11].Name);
			}
		}
		list.Add("SCM".Loc());
		list2.Add(work.Server2 ?? "None".Loc());
		IManufacturable manufacturable2;
		if (!work.AddOn)
		{
			IManufacturable manufacturable = sWCategory;
			manufacturable2 = manufacturable;
		}
		else
		{
			IManufacturable manufacturable = work.AddonType;
			manufacturable2 = manufacturable;
		}
		IManufacturable manufacturable3 = manufacturable2;
		bool flag2 = manufacturable3.IsHardware();
		uint[] array = (work.AddOn ? work.GetFactors() : null);
		WindowManager.SpawnTableInfoWindow("Projectdetails".Loc(), work.SoftwareName, list.ToArray(), list2.ToArray(), "WorkInfo" + work.SoftwareName, SoftwareType.GetSpecializationMonths(features, work.SWCategory, work.OSs, sequelTo, array), flag2 ? manufacturable3 : null, flag2 ? features.ToList() : null, (flag2 && work.AddOn) ? array.ToList() : null, work.AddonWorkChildren);
	}

	public void InitButtons()
	{
		foreach (KeyValuePair<string, Image> button in Buttons)
		{
			UnityEngine.Object.Destroy(button.Value.gameObject);
		}
		Buttons.Clear();
		foreach (KeyValuePair<string, Action> button2 in work.GetButtons())
		{
			AddActionButton(button2.Key, button2.Value);
		}
		if (HUD.Instance.GroupTaskManager.Grouping != WorkGroupManager.GroupType.None)
		{
			SubWorkItem item = HUD.Instance.GroupTaskManager.GetItem(work).Item2;
			if (item != null)
			{
				item.RefreshButtons();
			}
		}
	}

	public void InitPos()
	{
		if (work.SiblingIndex > -1)
		{
			base.transform.SetSiblingIndex(work.SiblingIndex);
		}
		else
		{
			work.SiblingIndex = base.transform.GetSiblingIndex();
		}
	}

	public void AddBonusButton(string icon, string tip, UnityAction onClick)
	{
		AddBonusButton(icon, tip, null, onClick);
	}

	public void AddBonusButton(string icon, string tip, string desc, UnityAction onClick)
	{
		GameObject obj = UnityEngine.Object.Instantiate(BonusButtonPrefab);
		obj.GetComponent<Image>().sprite = ObjectDatabase.GetIcon(icon);
		GUIToolTipper component = obj.GetComponent<GUIToolTipper>();
		component.ToolTipValue = tip;
		component.TooltipDescription = desc;
		obj.GetComponent<Button>().onClick.AddListener(onClick);
		obj.transform.SetParent(BonusButtonPanel, false);
		obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-BonusButtons * 26 - 2, 0f);
		BonusButtons++;
	}

	public void Collapse()
	{
		HelpTipPanel.Show(HintController.Hints.HintWorkItemActions, HUD.Instance.WorkItemPanel);
		work.Collapsed = !work.Collapsed;
		UpdateCollapse();
		SelectorController.CanClick = false;
	}

	public void UpdateActivation()
	{
		if (this != null && base.gameObject != null && HUD.Instance != null && HUD.Instance.WorkToToggle != null && work != null)
		{
			base.gameObject.SetActive(!work.Hidden && HUD.Instance.GroupTaskManager.Grouping == WorkGroupManager.GroupType.None && IsUnfiltered());
			GlobalSearchPanel.Instance.SetEnabled(this, !work.Hidden);
		}
	}

	public bool IsUnfiltered()
	{
		if (!HUD.Instance.GetWorkTypeToggled(work.GetWorkTypeFilter()) || !HUD.Instance.CheckDealContractFilter(work))
		{
			return false;
		}
		if (SelectorController.Instance != null && SelectorController.Instance.SelectedTeams != null)
		{
			bool result = false;
			foreach (string devTeam in work.DevTeams)
			{
				if (SelectorController.Instance.SelectedTeams.Contains(devTeam))
				{
					result = true;
					break;
				}
			}
			return result;
		}
		return true;
	}

	public void Expand()
	{
		if (work.Collapsed)
		{
			work.Collapsed = false;
			UpdateCollapse();
		}
	}

	private void UpdateCollapse()
	{
		if (work.Collapsed)
		{
			WorkLayout.minHeight = 43f;
			GetComponent<Image>().sprite = SprCollapse;
		}
		else
		{
			WorkLayout.minHeight = 128f;
			GetComponent<Image>().sprite = SprExpand;
		}
		MainIcon.color = new Color32(56, 56, 56, byte.MaxValue);
	}

	private void OnEnable()
	{
		if (HUD.Instance != null && HUD.Instance.MainWorkItemPanel != null)
		{
			NoDragScrollRect component = HUD.Instance.MainWorkItemPanel.GetComponent<NoDragScrollRect>();
			component.OnChange(component.normalizedPosition);
			UpdatePriorityLabel();
		}
	}

	private void OnDisable()
	{
		if (HUD.Instance != null && HUD.Instance.MainWorkItemPanel != null)
		{
			NoDragScrollRect component = HUD.Instance.MainWorkItemPanel.GetComponent<NoDragScrollRect>();
			component.OnChange(component.normalizedPosition);
		}
		_hovering = false;
	}

	private void SetIndicator(float value)
	{
		if (value > 0f && value < 1f)
		{
			MaxIndicator.gameObject.SetActive(true);
			MaxIndicator.anchoredPosition = new Vector2(256f * value, 0f);
		}
		else
		{
			MaxIndicator.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		string team = work.GetTeam(Team);
		if (work.Collapsed)
		{
			Description.text = work.CollapseLabel();
		}
		else
		{
			State.text = work.GetCurrentStage();
			Team.text = team ?? "Unassigned".Loc();
			TeamImg.sprite = ((work.GetNetworkDealState() == WorkItem.NetworkDealState.Sender) ? ObjectDatabase.GetIcon("Server") : ((work.CompanyWorker != null) ? CompanyTeam : PeopleTeam));
			Description.text = work.GetCategory();
			Progress.text = work.GetActualProgressLabel();
		}
		float num = work.GetActualProgress();
		if (!num.IsValidFloat())
		{
			num = 0f;
		}
		if (num > 0f)
		{
			ProgressBar.gameObject.SetActive(true);
			ProgressBar.sizeDelta = new Vector2((0f - (1f - num)) * 256f, ProgressBar.sizeDelta.y);
		}
		else
		{
			ProgressBar.gameObject.SetActive(false);
		}
		string text = work.HightlightButton();
		if (work.Collapsed)
		{
			if (ActiveButton != null)
			{
				ActiveButton.color = Color.white;
				ActiveButton = null;
			}
			if (text != null)
			{
				MainIcon.color = Utilities.Blink(new Color32(56, 56, 56, byte.MaxValue), Color.red, 1f);
			}
			else
			{
				MainIcon.color = new Color32(56, 56, 56, byte.MaxValue);
			}
		}
		else
		{
			if (ActiveButton != null)
			{
				Image value;
				if (text == null)
				{
					ActiveButton.color = Color.white;
					ActiveButton = null;
				}
				else if (Buttons.TryGetValue(text, out value) && value != ActiveButton)
				{
					ActiveButton.color = Color.white;
					ActiveButton = value;
				}
			}
			else if (ActiveButton == null && text != null)
			{
				ActiveButton = Buttons.GetOrNull(text);
			}
			if (ActiveButton != null)
			{
				ActiveButton.color = Utilities.Blink(Color.white, Color.red, 1f);
			}
		}
		ButtonPanel.sizeDelta = new Vector2(ButtonPanel.sizeDelta.x, Mathf.Lerp(ButtonPanel.sizeDelta.y, ((ActiveButton != null || _hovering) && !work.Collapsed) ? 43 : 0, Time.deltaTime * 10f));
		bool flag = ButtonPanel.sizeDelta.y > 1f;
		GameObject gameObject = ButtonPanel.gameObject;
		if (flag != gameObject.activeSelf)
		{
			gameObject.SetActive(flag);
		}
		if (BonusButtons > 0)
		{
			BonusButtonPanel.sizeDelta = new Vector2(Mathf.Lerp(BonusButtonPanel.sizeDelta.x, _hovering ? (BonusButtons * 26 + 4) : 0, Time.deltaTime * 10f), BonusButtonPanel.sizeDelta.y);
			flag = BonusButtonPanel.sizeDelta.x > 1f;
			gameObject = BonusButtonPanel.gameObject;
			if (flag != gameObject.activeSelf)
			{
				gameObject.SetActive(flag);
			}
		}
		ProgImg.color = work.GetProgressColor();
		Color? lastPhaseProgress = work.GetLastPhaseProgress();
		if (lastPhaseProgress.HasValue)
		{
			if (BackProgImg == null)
			{
				BackProgImg = UnityEngine.Object.Instantiate(ProgImg);
				BackProgImg.transform.SetParent(base.transform, false);
				BackProgImg.transform.SetSiblingIndex(ProgImg.transform.GetSiblingIndex());
				RectTransform component = BackProgImg.GetComponent<RectTransform>();
				component.offsetMin = Vector2.zero;
				component.offsetMax = Vector2.zero;
			}
			if (!BackProgImg.gameObject.activeSelf)
			{
				BackProgImg.gameObject.SetActive(true);
			}
			BackProgImg.color = lastPhaseProgress.Value;
		}
		else if (BackProgImg != null)
		{
			BackProgImg.gameObject.SetActive(false);
		}
		SetIndicator(work.GetMax());
		UnassignWarning.SetActive(team == null);
	}

	public static bool HasDetails(WorkItem item)
	{
		SoftwareAlpha softwareAlpha;
		SoftwareUpdate softwareUpdate;
		if (item.GetNetworkDealState() != WorkItem.NetworkDealState.Sender && (item is DesignDocument || ((softwareAlpha = item as SoftwareAlpha) != null && !softwareAlpha.InBeta) || ((softwareUpdate = item as SoftwareUpdate) != null && !softwareUpdate.HasFinished)))
		{
			return true;
		}
		return false;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (work.GetNetworkDealState() != WorkItem.NetworkDealState.Sender)
		{
			SoftwareAlpha softwareAlpha;
			SoftwareUpdate softwareUpdate;
			MarketingPlan marketingPlan;
			if (work is DesignDocument || ((softwareAlpha = work as SoftwareAlpha) != null && !softwareAlpha.InBeta) || ((softwareUpdate = work as SoftwareUpdate) != null && !softwareUpdate.HasFinished))
			{
				SpecializationProgress.Instance.Show(this);
			}
			else if ((marketingPlan = work as MarketingPlan) != null && marketingPlan.Type == MarketingPlan.TaskType.PressRelease)
			{
				SpecializationProgress.Instance.Show(this);
			}
		}
		_hovering = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!SpecializationProgress.Instance.CheckSelf())
		{
			SpecializationProgress.Instance.Hide();
		}
		_hovering = false;
	}

	public void StartDrag()
	{
		HelpTipPanel.Show(HintController.Hints.HintWorkItemActions, HUD.Instance.WorkItemPanel);
		HUD.Instance.DraggingWork = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (HUD.Instance != null)
		{
			if (HUD.Instance.DraggingWork == this)
			{
				HUD.Instance.DraggingWork = null;
			}
			GlobalSearchPanel.Instance.RemoveSearchItem(this);
		}
	}

	public void PauseWork()
	{
		work.Paused = !work.Paused;
		UpdatePauseButton();
	}

	public void UpdatePauseButton()
	{
		PauseButton.sprite = (work.Paused ? Pause : Play);
		PauseWarning.gameObject.SetActive(work.Paused);
	}

	public void Highlight()
	{
		if (work.AutoDev)
		{
			foreach (AutoDevWorkItem item2 in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
			{
				if (item2.Owns(work))
				{
					item2.guiItem.Highlight();
					break;
				}
			}
			return;
		}
		if (work.Hidden)
		{
			return;
		}
		AutoDevWorkItem item;
		if ((item = work as AutoDevWorkItem) != null)
		{
			HUD.Instance.AutoDevWindow.Show(item);
			return;
		}
		NoDragScrollRect component = HUD.Instance.MainWorkItemPanel.GetComponent<NoDragScrollRect>();
		if (HUD.Instance.GroupTaskManager.Grouping != WorkGroupManager.GroupType.None)
		{
			HUD.Instance.GroupTaskManager.ChangeType(0);
			LayoutRebuilder.ForceRebuildLayoutImmediate(component.content);
		}
		Sequence s = DOTween.Sequence();
		s.Append(SelfImage.DOColor(Color.red, 0.5f));
		s.Append(SelfImage.DOColor(Color.white, 0.5f));
		float num = component.content.rect.height - component.GetComponent<RectTransform>().rect.height;
		if (num > 0f)
		{
			component.verticalNormalizedPosition = 1f + GetComponent<RectTransform>().anchoredPosition.y / num;
		}
	}
}
