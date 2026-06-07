using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Achievements;
using Tyd;
using UnityEngine;
using UnityEngine.UI;

public class AutoDevWindow : MonoBehaviour
{
	[NonSerialized]
	private Actor _leaderPick;

	[NonSerialized]
	private AutoDevWorkItem _work;

	[NonSerialized]
	private bool _initializing;

	[NonSerialized]
	private string _server;

	[NonSerialized]
	private string _SCM;

	[NonSerialized]
	private HashSet<string> _designPick = new SHashSet<string>();

	[NonSerialized]
	private HashSet<string> _devPick = new SHashSet<string>();

	[NonSerialized]
	private HashSet<string> _dev2Pick = new SHashSet<string>();

	[NonSerialized]
	private HashSet<string> _supportPick = new SHashSet<string>();

	[NonSerialized]
	private HashSet<string> _prePick = new SHashSet<string>();

	[NonSerialized]
	private HashSet<string> _postPick = new SHashSet<string>();

	[NonSerialized]
	private HashSet<string> _updatePick = new SHashSet<string>();

	[NonSerialized]
	private HashSet<string> _portPick = new HashSet<string>();

	[NonSerialized]
	private List<SoftwareProduct> _prototypes = new List<SoftwareProduct>();

	[NonSerialized]
	private List<SoftwareProduct> _existing = new List<SoftwareProduct>();

	public GUIWindow Window;

	public InputField ProjectName;

	public InputField PhysicalCopies;

	public InputField PrintingCopies;

	public InputField IterationCooldown;

	public InputField UpdateCooldown;

	public InputField UpdateMonths;

	public InputField ReleaseCooldown;

	public Text LeaderLabel;

	public Text DesignLabel;

	public Text DevLabel;

	public Text Dev2Label;

	public Text SupportLabel;

	public Text PortLabel;

	public Text PreLabel;

	public Text PostLabel;

	public Text UpdateLabel;

	public Text DevTimeLabel;

	public Text SCMLabel;

	public Text ServerLabel;

	public Text SoftwarePrototypeLabel;

	public Text ExistingProductLabel;

	public Text MistakeList;

	public Text LeadErrorLabel;

	public Toggle HypeToggle;

	public Toggle AutoToggle;

	public Toggle SequelToggle;

	public Toggle PostToggle;

	public Toggle MarketToggle;

	public Toggle LicenseToggle;

	public Toggle IPToggle;

	public Toggle SupportToggle;

	public Toggle FrameworkToggle;

	public Toggle UpdateToggle;

	public Toggle UpdateTechToggle;

	public Toggle DistributionToggle;

	public Toggle PortingToggle;

	public Slider DevTimeSlider;

	public float DrainSpeed = 5f;

	public PosNegBar DrainStatus;

	public GUIProgressBar StateBar;

	public GUIListView PlanList;

	public GUIListView WorkList;

	public GameObject PlanPanel;

	public GameObject OKButton;

	public GameObject InfoPanel;

	public GameObject LeadErrorPanel;

	public GameObject LeaderSkillWarning;

	private bool DisablePh;

	private bool DisablePr;

	public AutoDevWorkItem Work
	{
		get
		{
			return _work;
		}
	}

	public void Show(AutoDevWorkItem item)
	{
		if (_work != null)
		{
			_work.IsViewed = false;
			_work.Items.OnChange = null;
		}
		_work = item;
		_work.IsViewed = true;
		_work.UpdateLists();
		Window.Show();
		PlanPanel.SetActive(true);
		PlanList.Items = _work.Items.OfType<object>().ToList();
		_work.Items.OnChange = delegate
		{
			PlanList.Items = _work.Items.OfType<object>().ToList();
		};
		OKButton.SetActive(false);
		ClearFields();
		UpdateProtoLabel();
		UpdateExistingLabel();
		DrainStatus.SetValues(ConvertEff(item.GetLastEffGain()), ConvertEff(item.LastEffLoss));
	}

	private float ConvertEff(float value)
	{
		return Mathf.Clamp(value * 5f, 0f, 10f);
	}

	private void UpdateProtoLabel()
	{
		List<SoftwareProduct> products = ((_work != null) ? _work.PastReleases : _prototypes);
		SoftwarePrototypeLabel.text = GetProto(products, SoftwarePrototypeLabel);
	}

	private void UpdateExistingLabel()
	{
		List<SoftwareProduct> products = ((_work != null) ? _work.PreviousSoftware : _existing);
		ExistingProductLabel.text = GetProto(products, ExistingProductLabel);
	}

	private void Update()
	{
		if (_work == null)
		{
			return;
		}
		DrainStatus.SetValues(Mathf.MoveTowards(DrainStatus.Positive, ConvertEff(_work.GetLastEffGain()), Time.deltaTime * DrainSpeed), Mathf.MoveTowards(DrainStatus.Negative, ConvertEff(_work.LastEffLoss), Time.deltaTime * DrainSpeed));
		if (_work.Mistakes.Count == 0)
		{
			MistakeList.text = "None".Loc();
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int num = _work.Mistakes.Count - 1; num >= 0; num--)
			{
				string value = _work.Mistakes[num];
				stringBuilder.AppendLine(value);
			}
			MistakeList.text = stringBuilder.ToString().TrimEnd();
		}
		StateBar.Value = _work.LastEffectiveness / 3f;
		StateBar.StartColor = Color.Lerp(HUD.GetThemeColor(2), HUD.GetThemeColor(0), Mathf.Clamp01(_work.LastEffectiveness));
		if (_work.LastDesignError != null)
		{
			LeadErrorLabel.text = "ProjManLeadError".Loc(_work.LastDesignError.FullName);
			LeadErrorPanel.SetActive(true);
		}
		else
		{
			LeadErrorPanel.SetActive(false);
		}
	}

	public void PickReleases()
	{
		ProductWindow productWindow = HUD.Instance.GetProductWindow("DesignDoc");
		productWindow.Show(false, "PrototypeSoftware".Loc(), delegate(SoftwareProduct[] xs)
		{
			if (_work != null)
			{
				_work.PastReleases.Clear();
				_work.PastReleases.AddRange(xs.Where((SoftwareProduct x) => x.DevCompany.IsLocalPlayer));
			}
			else
			{
				_prototypes.Clear();
				_prototypes.AddRange(xs.Where((SoftwareProduct x) => x.DevCompany.IsLocalPlayer));
			}
			UpdateProtoLabel();
		}, true);
		productWindow.ProductList.ClearFilters();
		HashSet<SoftwareProduct> hashSet = GameSettings.Instance.MyCompany.Products.Select((SoftwareProduct x) => x.GetLatestSuccessor()).ToHashSet();
		foreach (AutoDevWorkItem item in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
		{
			hashSet.RemoveRange(item.PastReleases);
			hashSet.RemoveRange(item.PreviousSoftware);
		}
		if (_work == null)
		{
			hashSet.RemoveRange(_existing);
		}
		HashSet<SoftwareProduct> selected = new HashSet<SoftwareProduct>();
		List<SoftwareProduct> list = ((_work != null) ? _work.PastReleases : _prototypes);
		for (int num = 0; num < list.Count; num++)
		{
			SoftwareProduct latestSuccessor = list[num].GetLatestSuccessor();
			selected.Add(latestSuccessor);
			hashSet.Add(latestSuccessor);
		}
		productWindow.SetContent(hashSet);
		productWindow.ApplyFilters();
		productWindow.ProductList.SelectAll((SoftwareProduct x) => selected.Contains(x));
	}

	public void PickPreviousSoftware()
	{
		ProductWindow productWindow = HUD.Instance.GetProductWindow("DesignDoc");
		productWindow.Show(false, "ExistingProducts".Loc(), delegate(SoftwareProduct[] xs)
		{
			if (_work != null)
			{
				foreach (SoftwareProduct item in _work.PreviousSoftware.Where((SoftwareProduct x) => !xs.Contains(x)).ToList())
				{
					_work.RemovePreviousSoftware(item);
				}
				foreach (SoftwareProduct item2 in xs.Where((SoftwareProduct x) => x.DevCompany.IsLocalPlayer && !_work.PreviousSoftware.Contains(x)).ToList())
				{
					_work.AddPreviousSoftware(item2);
				}
				_work.UpdateSupportMarket(false);
			}
			else
			{
				_existing.Clear();
				_existing.AddRange(xs.Where((SoftwareProduct x) => x.DevCompany.IsLocalPlayer));
			}
			UpdateExistingLabel();
		}, true);
		productWindow.ProductList.ClearFilters();
		HashSet<SoftwareProduct> hashSet = GameSettings.Instance.MyCompany.Products.Where((SoftwareProduct x) => !x.Archived).ToHashSet();
		foreach (AutoDevWorkItem item3 in GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>())
		{
			hashSet.RemoveRange(item3.PastReleases);
			hashSet.RemoveRange(item3.PreviousSoftware);
		}
		if (_work == null)
		{
			hashSet.RemoveRange(_prototypes);
		}
		HashSet<SoftwareProduct> selected = new HashSet<SoftwareProduct>();
		List<SoftwareProduct> list = ((_work != null) ? _work.PreviousSoftware : _existing);
		for (int num = 0; num < list.Count; num++)
		{
			selected.Add(list[num]);
			hashSet.Add(list[num]);
		}
		productWindow.SetContent(hashSet);
		productWindow.ApplyFilters();
		productWindow.ProductList.SelectAll((SoftwareProduct x) => selected.Contains(x));
	}

	public void Toggle()
	{
		Window.Toggle();
		if (_work != null)
		{
			_work.IsViewed = false;
			_work.Items.OnChange = null;
		}
		_work = null;
		PlanPanel.SetActive(false);
		OKButton.SetActive(true);
		ClearFields();
		UpdateProtoLabel();
		UpdateExistingLabel();
		if (Window.Shown)
		{
			TutorialSystem.Instance.StartTutorial("Project management");
		}
	}

	private void Start()
	{
		Window.OnClose = delegate
		{
			if (_work != null)
			{
				_work.IsViewed = false;
				_work.Items.OnChange = null;
			}
		};
		GameSettings instance = GameSettings.Instance;
		instance.OnServersChanged = (EventHandler)Delegate.Combine(instance.OnServersChanged, (EventHandler)delegate
		{
			if (Window.Shown)
			{
				if (_work != null)
				{
					SetServer(ref _work.MainServer, ServerLabel, _work.MainServer);
					SetServer(ref _work.SCMServer, SCMLabel, _work.SCMServer);
				}
				else
				{
					SetServer(ref _server, ServerLabel, null);
					SetServer(ref _SCM, SCMLabel, null);
				}
			}
		});
		StateBar.IndValue = 1f / 3f;
		StateBar.IndColor = Color.blue;
	}

	private void SetLeader(Actor actor)
	{
		if (_work != null)
		{
			if (!_initializing)
			{
				_work.Leader = actor;
			}
		}
		else
		{
			_leaderPick = actor;
		}
		LeaderLabel.text = ((actor == null) ? "None".Loc() : actor.employee.FullName);
		LeaderUpdate();
	}

	public void TeamButtonClick(int i)
	{
		HashSet<string> team = null;
		Text label = null;
		string type = null;
		string taskType = null;
		switch (i)
		{
		case 0:
			team = ((_work != null) ? _work.DesignTeams : _designPick);
			label = DesignLabel;
			type = "Design";
			taskType = "DesignDocument";
			break;
		case 1:
			team = ((_work != null) ? _work.SDevTeams : _devPick);
			label = DevLabel;
			type = "Development";
			taskType = "SoftwareAlpha";
			break;
		case 2:
			team = ((_work != null) ? _work.SupportTeams : _supportPick);
			label = SupportLabel;
			type = "Support";
			taskType = "SupportWork";
			break;
		case 3:
			team = ((_work != null) ? _work.MarketingTeams : _prePick);
			label = PreLabel;
			type = "Marketing";
			taskType = "MarketingPlan";
			break;
		case 4:
			team = ((_work != null) ? _work.PostMarketingTeams : _postPick);
			label = PostLabel;
			type = "Marketing";
			taskType = "MarketingPlan";
			break;
		case 5:
			team = ((_work != null) ? _work.SecondaryDevTeams : _dev2Pick);
			label = Dev2Label;
			type = "Development";
			taskType = "SoftwareAlpha";
			break;
		case 6:
			team = ((_work != null) ? _work.UpdateTeams : _updatePick);
			label = UpdateLabel;
			type = "Update";
			taskType = "SoftwareUpdate";
			break;
		case 7:
			team = ((_work != null) ? _work.PortingTeams : _portPick);
			label = PortLabel;
			type = "Porting";
			taskType = "SoftwarePort";
			break;
		}
		if (team != null && label != null)
		{
			HUD.Instance.TeamSelectWindow.Show(false, team, delegate(string[] x)
			{
				SetTeam(team, label, x.ToHashSet());
			}, type, null, taskType);
		}
	}

	public void RefreshTeamLabels(string before, string after)
	{
		if (_work == null)
		{
			_devPick.Swap(before, after);
			_designPick.Swap(before, after);
			_supportPick.Swap(before, after);
			_prePick.Swap(before, after);
			_postPick.Swap(before, after);
			_dev2Pick.Swap(before, after);
			_updatePick.Swap(before, after);
		}
		DesignLabel.text = GetTeam((_work != null) ? _work.SDevTeams : _devPick, DesignLabel);
		DevLabel.text = GetTeam((_work != null) ? _work.DesignTeams : _designPick, DevLabel);
		SupportLabel.text = GetTeam((_work != null) ? _work.SupportTeams : _supportPick, SupportLabel);
		PreLabel.text = GetTeam((_work != null) ? _work.MarketingTeams : _prePick, PreLabel);
		PostLabel.text = GetTeam((_work != null) ? _work.PostMarketingTeams : _postPick, PostLabel);
		Dev2Label.text = GetTeam((_work != null) ? _work.SecondaryDevTeams : _dev2Pick, Dev2Label);
		UpdateLabel.text = GetTeam((_work != null) ? _work.UpdateTeams : _updatePick, UpdateLabel);
		PortLabel.text = GetTeam((_work != null) ? _work.PortingTeams : _portPick, PortLabel);
	}

	public void PickLeader()
	{
		Actor[] leaders = GameSettings.Instance.sActorManager.Actors.Where((Actor x) => x.employee.IsRole(Employee.RoleBit.Lead) && x.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Automation") > 0).ToArray();
		if (leaders.Length != 0)
		{
			WindowManager.Instance.MultiWindow.Show("Leader", leaders.Select((Actor x) => x.employee.FullName + " (" + (x.Team ?? "None".Loc()) + ")"), delegate(int x)
			{
				SetLeader(leaders[x]);
			}, false);
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("AutoDevNoLeaders".Loc(), false, DialogWindow.DialogType.Error);
		}
	}

	public void ServerButtonClick(int i)
	{
		List<ServerGroup> servs = GameSettings.Instance.GetAllServerGroups().ToList();
		if (servs.Count <= 0)
		{
			return;
		}
		if (_work != null)
		{
			switch (i)
			{
			case 0:
				WindowManager.Instance.MultiWindow.Show("Server", servs.Select((ServerGroup x) => x.Name), delegate(int x)
				{
					SetServer(ref _work.SCMServer, SCMLabel, (x > -1) ? servs[x].Name : null);
				}, true);
				break;
			case 1:
				WindowManager.Instance.MultiWindow.Show("Server", servs.Select((ServerGroup x) => x.Name), delegate(int x)
				{
					SetServer(ref _work.MainServer, ServerLabel, (x > -1) ? servs[x].Name : null);
				}, true);
				break;
			}
			return;
		}
		switch (i)
		{
		case 0:
			WindowManager.Instance.MultiWindow.Show("Server", servs.Select((ServerGroup x) => x.Name), delegate(int x)
			{
				SetServer(ref _SCM, SCMLabel, (x > -1) ? servs[x].Name : null);
			}, true);
			break;
		case 1:
			WindowManager.Instance.MultiWindow.Show("Server", servs.Select((ServerGroup x) => x.Name), delegate(int x)
			{
				SetServer(ref _server, ServerLabel, (x > -1) ? servs[x].Name : null);
			}, true);
			break;
		}
	}

	private void LeaderUpdate()
	{
		bool flag = true;
		bool flag2 = true;
		Actor actor = ((_work != null) ? Work.Leader : _leaderPick);
		if (actor != null)
		{
			int specialization = actor.employee.GetSpecialization(Employee.EmployeeRole.Lead, "Automation");
			flag = specialization > 1;
			flag2 = specialization > 2;
		}
		RefreshToggle(SequelToggle, flag);
		RefreshToggle(FrameworkToggle, flag);
		RefreshToggle(UpdateToggle, flag2);
		RefreshToggle(DistributionToggle, flag2);
		RefreshToggle(PortingToggle, flag2);
		RefreshToggle(UpdateTechToggle, flag2);
		RefreshToggle(PostToggle, flag2);
		RefreshToggle(MarketToggle, flag2);
		RefreshToggle(SupportToggle, flag2);
		PhysicalCopies.interactable = flag2;
		PrintingCopies.interactable = flag2;
		IterationCooldown.interactable = flag;
		ReleaseCooldown.interactable = flag;
		UpdateCooldown.interactable = flag2;
		UpdateMonths.interactable = flag2;
		LeaderSkillWarning.SetActive(!flag || !flag2);
	}

	private void RefreshToggle(Toggle toggle, bool active)
	{
		toggle.interactable = active;
	}

	public void ToggleSet(int i)
	{
		if (_work != null)
		{
			switch (i)
			{
			case 0:
				_work.Hype = HypeToggle.isOn;
				break;
			case 1:
				_work.AutoProject = AutoToggle.isOn;
				break;
			case 2:
				_work.OnlySequels = SequelToggle.isOn;
				break;
			case 3:
				_work.PostMarketing = PostToggle.isOn;
				break;
			case 4:
				_work.HandleMarketing = MarketToggle.isOn;
				break;
			case 5:
				_work.UseOwnLicenses = LicenseToggle.isOn;
				break;
			case 6:
				_work.SingleIP = IPToggle.isOn;
				break;
			case 7:
				_work.AutoSupport = SupportToggle.isOn;
				break;
			case 8:
				_work.UseFrameworks = FrameworkToggle.isOn;
				break;
			case 9:
				_work.Updates = UpdateToggle.isOn;
				break;
			case 10:
				_work.TechUpdates = UpdateTechToggle.isOn;
				break;
			case 11:
				_work.AutoDistribution = DistributionToggle.isOn;
				break;
			case 12:
				_work.Porting = PortingToggle.isOn;
				break;
			}
		}
	}

	private string GetProto(List<SoftwareProduct> products, Text label)
	{
		if (label != null && products.Count > 1)
		{
			float width = label.rectTransform.rect.width;
			int num = 0;
			int lineWidth = label.GetLineWidth(", ");
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			int num2 = 1;
			for (int i = 0; i < products.Count; i++)
			{
				SoftwareProduct softwareProduct = products[i];
				if (flag)
				{
					num += label.GetLineWidth(softwareProduct.Name);
					stringBuilder.Append(softwareProduct.Name);
					flag = false;
					continue;
				}
				num += lineWidth + label.GetLineWidth(softwareProduct.Name);
				if ((float)num <= width)
				{
					stringBuilder.Append(", " + softwareProduct.Name);
					num2++;
				}
			}
			if (num2 < products.Count)
			{
				stringBuilder.Append("+" + (products.Count - num2));
			}
			return stringBuilder.ToString();
		}
		if (products.Count > 1)
		{
			return products.First().Name + "+" + (products.Count - 1);
		}
		if (products.Count > 0)
		{
			return products.First().Name;
		}
		return "None".Loc();
	}

	private string GetTeam(HashSet<string> values, Text label)
	{
		if (label != null && values.Count > 1)
		{
			float width = label.rectTransform.rect.width;
			int num = 0;
			int lineWidth = label.GetLineWidth(", ");
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			int num2 = 1;
			foreach (string value in values)
			{
				if (flag)
				{
					num += label.GetLineWidth(value);
					stringBuilder.Append(value);
					flag = false;
					continue;
				}
				num += lineWidth + label.GetLineWidth(value);
				if ((float)num <= width)
				{
					stringBuilder.Append(", " + value);
					num2++;
				}
			}
			if (num2 < values.Count)
			{
				stringBuilder.Append("+" + (values.Count - num2));
			}
			return stringBuilder.ToString();
		}
		if (values.Count > 1)
		{
			return values.First() + "+" + (values.Count - 1);
		}
		if (values.Count > 0)
		{
			return values.First();
		}
		return "None".Loc();
	}

	private void SetTeam(HashSet<string> teams, Text label, HashSet<string> value)
	{
		if (_work != null)
		{
			if (!_initializing)
			{
				teams.Clear();
				teams.AddRange(value);
				_work.RefreshTeams();
			}
		}
		else
		{
			teams.Clear();
			teams.AddRange(value);
		}
		label.text = GetTeam(value, label);
	}

	public void UpdateDevTime()
	{
		DevTimeLabel.text = Mathf.RoundToInt(DevTimeSlider.value * 10f) + "%";
		if (_work != null && !_initializing)
		{
			_work.DevTimeMultiplier = DevTimeSlider.value / 10f;
		}
	}

	private void SetServer(ref string server, Text label, string value)
	{
		if (_work != null)
		{
			if (!_initializing)
			{
				server = value;
			}
		}
		else
		{
			server = value;
		}
		label.text = value ?? "None".Loc();
	}

	public void NameChange()
	{
		if (_work != null && !_initializing)
		{
			_work.Name = ProjectName.text;
		}
	}

	public void PhysicalChange(bool end)
	{
		if (DisablePh || _initializing)
		{
			DisablePh = false;
			return;
		}
		try
		{
			bool flag = false;
			string text = PhysicalCopies.text;
			if (text.EndsWith("%"))
			{
				flag = true;
				text = text.Substring(0, text.Length - 1).Trim();
			}
			uint physicalCopies = Convert.ToUInt32(text.Replace(",", ""));
			if (_work != null)
			{
				_work.PhysicalCopies = physicalCopies;
				_work.PhysicalCopyRel = flag;
			}
			if (end)
			{
				DisablePh = true;
				PhysicalCopies.text = physicalCopies.ToString("N0") + (flag ? "%" : "");
				DisablePh = false;
			}
		}
		catch (Exception)
		{
		}
	}

	public void PrintChange(bool end)
	{
		if (DisablePr || _initializing)
		{
			DisablePr = false;
			return;
		}
		try
		{
			bool flag = false;
			string text = PrintingCopies.text;
			if (text.EndsWith("%"))
			{
				flag = true;
				text = text.Substring(0, text.Length - 1).Trim();
			}
			uint printingCopies = Convert.ToUInt32(text.Replace(",", ""));
			if (_work != null)
			{
				_work.PrintingCopies = printingCopies;
				_work.PrintingCopyRel = flag;
			}
			if (end)
			{
				DisablePr = true;
				PrintingCopies.text = printingCopies.ToString("N0") + (flag ? "%" : "");
				DisablePr = false;
			}
		}
		catch (Exception)
		{
		}
	}

	public void IterationChange()
	{
		if (_initializing)
		{
			return;
		}
		try
		{
			int iterationCoolDown = Convert.ToInt32(IterationCooldown.text);
			if (_work != null)
			{
				_work.IterationCoolDown = iterationCoolDown;
			}
		}
		catch (Exception)
		{
		}
	}

	public void ReleaseChange()
	{
		if (_initializing)
		{
			return;
		}
		try
		{
			int releaseCooldown = Convert.ToInt32(ReleaseCooldown.text);
			if (_work != null)
			{
				_work.ReleaseCooldown = releaseCooldown;
			}
		}
		catch (Exception)
		{
		}
	}

	public void UpdateChange(int t)
	{
		if (_initializing)
		{
			return;
		}
		try
		{
			int num = Convert.ToInt32((t == 0) ? UpdateCooldown.text : UpdateMonths.text);
			if (_work != null && num > 0)
			{
				if (t == 0)
				{
					_work.UpdateCooldown = num;
				}
				else
				{
					_work.UpdateMonths = num;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	private void ClearFields()
	{
		_initializing = true;
		LeadErrorPanel.SetActive(false);
		LeaderSkillWarning.SetActive(false);
		if (_work != null)
		{
			ProjectName.text = _work.Name;
			SetLeader(_work.Leader);
			SetTeam(null, DesignLabel, _work.DesignTeams);
			SetTeam(null, DevLabel, _work.SDevTeams);
			SetTeam(null, Dev2Label, _work.SecondaryDevTeams);
			SetTeam(null, SupportLabel, _work.SupportTeams);
			SetTeam(null, PreLabel, _work.MarketingTeams);
			SetTeam(null, PostLabel, _work.PostMarketingTeams);
			SetTeam(null, UpdateLabel, _work.UpdateTeams);
			SetTeam(null, PortLabel, _work.PortingTeams);
			DevTimeSlider.value = Mathf.Round(_work.DevTimeMultiplier * 10f);
			HypeToggle.isOn = _work.Hype;
			UpdateToggle.isOn = _work.Updates;
			UpdateTechToggle.isOn = _work.TechUpdates;
			AutoToggle.isOn = _work.AutoProject;
			SequelToggle.isOn = _work.OnlySequels;
			FrameworkToggle.isOn = _work.UseFrameworks;
			PostToggle.isOn = _work.PostMarketing;
			MarketToggle.isOn = _work.HandleMarketing;
			DistributionToggle.isOn = _work.AutoDistribution;
			PortingToggle.isOn = _work.Porting;
			LicenseToggle.isOn = _work.UseOwnLicenses;
			IPToggle.isOn = _work.SingleIP;
			SupportToggle.isOn = _work.AutoSupport;
			PhysicalCopies.text = _work.PhysicalCopies.ToString("N0") + (_work.PhysicalCopyRel ? "%" : "");
			PrintingCopies.text = _work.PrintingCopies.ToString("N0") + (_work.PrintingCopyRel ? "%" : "");
			IterationCooldown.text = _work.IterationCoolDown.ToString();
			ReleaseCooldown.text = _work.ReleaseCooldown.ToString();
			UpdateCooldown.text = _work.UpdateCooldown.ToString();
			UpdateMonths.text = _work.UpdateMonths.ToString();
			SetServer(ref _work.MainServer, ServerLabel, _work.MainServer);
			SetServer(ref _work.SCMServer, SCMLabel, _work.SCMServer);
			InfoPanel.SetActive(true);
		}
		else
		{
			ProjectName.text = "ProjectManagementDefaultName".Loc();
			SetLeader(null);
			HashSet<string> value = GameSettings.Instance.GetDefaultTeams("Design").ToHashSet();
			SetTeam(_designPick, DesignLabel, value);
			SetTeam(_devPick, DevLabel, value);
			SetTeam(_dev2Pick, Dev2Label, value);
			SetTeam(_supportPick, SupportLabel, value);
			SetTeam(_prePick, PreLabel, GameSettings.Instance.GetDefaultTeams(MarketingPlan.TaskType.PressRelease.ToString()).ToHashSet());
			SetTeam(_postPick, PostLabel, GameSettings.Instance.GetDefaultTeams(MarketingPlan.TaskType.PostMarket.ToString()).ToHashSet());
			SetTeam(_updatePick, UpdateLabel, value);
			SetTeam(_portPick, PortLabel, GameSettings.Instance.GetDefaultTeams("Porting").ToHashSet());
			DevTimeSlider.value = 10f;
			HypeToggle.isOn = true;
			UpdateToggle.isOn = false;
			UpdateTechToggle.isOn = false;
			AutoToggle.isOn = true;
			SequelToggle.isOn = true;
			FrameworkToggle.isOn = true;
			PostToggle.isOn = true;
			MarketToggle.isOn = false;
			DistributionToggle.isOn = false;
			PortingToggle.isOn = false;
			LicenseToggle.isOn = false;
			IPToggle.isOn = false;
			SupportToggle.isOn = true;
			PhysicalCopies.text = "0";
			PrintingCopies.text = "0";
			IterationCooldown.text = "0";
			ReleaseCooldown.text = "0";
			UpdateCooldown.text = "3";
			UpdateMonths.text = "12";
			SetServer(ref _server, ServerLabel, null);
			SetServer(ref _SCM, SCMLabel, null);
			_prototypes.Clear();
			_existing.Clear();
			InfoPanel.SetActive(false);
		}
		UpdateDevTime();
		_initializing = false;
	}

	public void OKClick()
	{
		if (_leaderPick != null)
		{
			AutoDevWorkItem autoDevWorkItem = new AutoDevWorkItem(ProjectName.text, _leaderPick);
			autoDevWorkItem.DesignTeams.AddRange(_designPick);
			autoDevWorkItem.SDevTeams.AddRange(_devPick);
			autoDevWorkItem.SecondaryDevTeams.AddRange(_dev2Pick);
			autoDevWorkItem.SupportTeams.AddRange(_supportPick);
			autoDevWorkItem.MarketingTeams.AddRange(_prePick);
			autoDevWorkItem.PostMarketingTeams.AddRange(_postPick);
			autoDevWorkItem.UpdateTeams.AddRange(_updatePick);
			autoDevWorkItem.PortingTeams.AddRange(_portPick);
			autoDevWorkItem.Hype = HypeToggle.isOn;
			autoDevWorkItem.Updates = UpdateToggle.isOn;
			autoDevWorkItem.TechUpdates = UpdateTechToggle.isOn;
			autoDevWorkItem.AutoProject = AutoToggle.isOn;
			autoDevWorkItem.UseFrameworks = FrameworkToggle.isOn;
			autoDevWorkItem.OnlySequels = SequelToggle.isOn;
			autoDevWorkItem.PostMarketing = PostToggle.isOn;
			autoDevWorkItem.HandleMarketing = MarketToggle.isOn;
			autoDevWorkItem.AutoDistribution = DistributionToggle.isOn;
			autoDevWorkItem.Porting = PortingToggle.isOn;
			autoDevWorkItem.UseOwnLicenses = LicenseToggle.isOn;
			autoDevWorkItem.AutoSupport = SupportToggle.isOn;
			autoDevWorkItem.SingleIP = IPToggle.isOn;
			autoDevWorkItem.DevTimeMultiplier = DevTimeSlider.value / 10f;
			autoDevWorkItem.MainServer = _server;
			autoDevWorkItem.SCMServer = _SCM;
			for (int i = 0; i < _prototypes.Count; i++)
			{
				autoDevWorkItem.AddPastRelease(_prototypes[i]);
			}
			for (int j = 0; j < _existing.Count; j++)
			{
				autoDevWorkItem.AddPreviousSoftware(_existing[j]);
			}
			_work = autoDevWorkItem;
			PhysicalChange(false);
			PrintChange(false);
			IterationChange();
			UpdateChange(0);
			UpdateChange(1);
			GameSettings.Instance.MyCompany.AddWorkItem(autoDevWorkItem);
			AchievementController.SetInteraction(AchievementController.Mechanics.Projectmanagement);
			if (_existing.Count > 0)
			{
				_work.UpdateSupportMarket(false);
			}
			Window.Close();
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("AutoDevMissingLeader".Loc(), false, DialogWindow.DialogType.Error);
		}
	}

	public void LoadProjectSetup()
	{
		if (GameData.ProjectManagementSetups == null || GameData.ProjectManagementSetups.Nodes.Count <= 0)
		{
			return;
		}
		List<TydTable> setups = GameData.ProjectManagementSetups.Nodes.OfType<TydTable>().ToList();
		WindowManager.Instance.MultiWindow.Show("ProjectSetup".Loc(), setups.Select((TydTable x) => x.Name), delegate(int x)
		{
			TydTable tydTable = setups[x];
			DevTimeSlider.value = tydTable["DevTime"].ConvertToFloatDef(DevTimeSlider.value);
			HypeToggle.isOn = tydTable["Hype"].ConvertToBoolDef(HypeToggle.isOn);
			UpdateToggle.isOn = tydTable["Update"].ConvertToBoolDef(HypeToggle.isOn);
			UpdateTechToggle.isOn = tydTable["UpdateTech"].ConvertToBoolDef(HypeToggle.isOn);
			AutoToggle.isOn = tydTable["Auto"].ConvertToBoolDef(HypeToggle.isOn);
			SequelToggle.isOn = tydTable["Sequel"].ConvertToBoolDef(HypeToggle.isOn);
			FrameworkToggle.isOn = tydTable["Framework"].ConvertToBoolDef(HypeToggle.isOn);
			PostToggle.isOn = tydTable["Post"].ConvertToBoolDef(HypeToggle.isOn);
			MarketToggle.isOn = tydTable["Market"].ConvertToBoolDef(HypeToggle.isOn);
			DistributionToggle.isOn = tydTable["Distribution"].ConvertToBoolDef(HypeToggle.isOn);
			PortingToggle.isOn = tydTable["Porting"].ConvertToBoolDef(HypeToggle.isOn);
			LicenseToggle.isOn = tydTable["License"].ConvertToBoolDef(HypeToggle.isOn);
			IPToggle.isOn = tydTable["IP"].ConvertToBoolDef(HypeToggle.isOn);
			SupportToggle.isOn = tydTable["Support"].ConvertToBoolDef(HypeToggle.isOn);
			PhysicalCopies.text = tydTable["PhysicalCopies"];
			PrintingCopies.text = tydTable["PrintingCopies"];
			IterationCooldown.text = tydTable["IterationCooldown"];
			ReleaseCooldown.text = tydTable["ReleaseCooldown"];
			UpdateCooldown.text = tydTable["UpdateCooldown"];
			UpdateMonths.text = tydTable["UpdateMonths"];
		}, false, true, true, false, delegate(int del)
		{
			GameData.ProjectManagementSetups.Nodes.Remove(setups[del]);
			if (GameData.ProjectManagementSetups.Nodes.Count == 0)
			{
				File.Delete("ProjectManagement.tyd");
			}
			else
			{
				File.WriteAllText("ProjectManagement.tyd", TydToText.Write(GameData.ProjectManagementSetups, true));
			}
		});
	}

	public void SaveProjectSetup()
	{
		WindowManager.SpawnInputDialog("Save".Loc(), "Name".Loc(), ProjectName.text, delegate(string x)
		{
			string value = TydToText.CleanNodeName(x);
			if (!string.IsNullOrWhiteSpace(value))
			{
				TydTable tydTable = new TydTable(value);
				tydTable["DevTime"] = DevTimeSlider.value.ToString();
				tydTable["Hype"] = HypeToggle.isOn.ToString();
				tydTable["Update"] = UpdateToggle.isOn.ToString();
				tydTable["UpdateTech"] = UpdateTechToggle.isOn.ToString();
				tydTable["Auto"] = AutoToggle.isOn.ToString();
				tydTable["Sequel"] = SequelToggle.isOn.ToString();
				tydTable["Framework"] = FrameworkToggle.isOn.ToString();
				tydTable["Post"] = PostToggle.isOn.ToString();
				tydTable["Market"] = MarketToggle.isOn.ToString();
				tydTable["Distribution"] = DistributionToggle.isOn.ToString();
				tydTable["Porting"] = PortingToggle.isOn.ToString();
				tydTable["License"] = LicenseToggle.isOn.ToString();
				tydTable["IP"] = IPToggle.isOn.ToString();
				tydTable["Support"] = SupportToggle.isOn.ToString();
				tydTable["PhysicalCopies"] = PhysicalCopies.text;
				tydTable["PrintingCopies"] = PrintingCopies.text;
				tydTable["IterationCooldown"] = IterationCooldown.text;
				tydTable["ReleaseCooldown"] = ReleaseCooldown.text;
				tydTable["UpdateCooldown"] = UpdateCooldown.text;
				tydTable["UpdateMonths"] = UpdateMonths.text;
				if (GameData.ProjectManagementSetups == null)
				{
					GameData.ProjectManagementSetups = new TydDocument();
				}
				GameData.ProjectManagementSetups.AddChild(tydTable);
				File.WriteAllText("ProjectManagement.tyd", TydToText.Write(GameData.ProjectManagementSetups, true));
			}
		});
	}
}
