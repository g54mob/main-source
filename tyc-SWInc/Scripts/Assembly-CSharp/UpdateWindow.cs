using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Text BugLabel;

	public Text TeamLabel;

	public Toggle BugToggle;

	public TechUpdatePanel TechPrefab;

	public SWToolPanel ToolPrefab;

	public Transform TechPanel;

	public GUICombobox SCM;

	public GameObject ToolLabel;

	public Text SpecWarning;

	public VarValueSheet Data;

	private List<TechUpdatePanel> _techs = new List<TechUpdatePanel>();

	[NonSerialized]
	private SoftwareProduct _product;

	[NonSerialized]
	private SoftwareFramework _framework;

	[NonSerialized]
	public List<SWToolPanel> _tools = new List<SWToolPanel>();

	[NonSerialized]
	public Dictionary<string, SWToolPanel> _activeTools = new Dictionary<string, SWToolPanel>();

	[NonSerialized]
	public Dictionary<string, TechLevel> _activeTechs = new Dictionary<string, TechLevel>();

	[NonSerialized]
	private HashSet<string> _devTeams = new HashSet<string>();

	public SoftwareProduct Product
	{
		get
		{
			return _product;
		}
	}

	public SoftwareFramework Framework
	{
		get
		{
			return _framework;
		}
	}

	public Dictionary<string, TechLevel> TechLevels
	{
		get
		{
			return _techs.Where((TechUpdatePanel x) => x.gameObject.activeSelf).ToDictionary((TechUpdatePanel x) => x.Tech.Spec, (TechUpdatePanel x) => x.Tech);
		}
	}

	public Dictionary<string, SoftwareProduct> Tools
	{
		get
		{
			return _activeTools.Values.Where((SWToolPanel x) => x.gameObject.activeSelf).ToDictionary((SWToolPanel x) => x.Tool, (SWToolPanel x) => x.PickedProduct);
		}
	}

	private void UpdateTeamLabel()
	{
		TeamLabel.text = _devTeams.GetListAbbrev("Team");
	}

	public void PickDevteams()
	{
		HUD.Instance.TeamSelectWindow.Show(false, _devTeams, delegate(string[] ts)
		{
			_devTeams.Clear();
			_devTeams.AddRange(ts);
			UpdateTeamLabel();
			RefreshTooling();
		}, "Update", "SoftwareUpdate");
	}

	public void Show(SoftwareFramework f)
	{
		SoftwareUpdate tt = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareUpdate>().FirstOrDefault((SoftwareUpdate x) => x.TargetFramework == f);
		if (tt != null)
		{
			if (tt.AutoDev)
			{
				GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().ForEachEnum(delegate(AutoDevWorkItem x)
				{
					x.TakeOverTask(tt);
				});
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("UpdateInProgressError".Loc(), true, DialogWindow.DialogType.Error);
			}
			return;
		}
		_product = null;
		_framework = f;
		_activeTechs.Clear();
		_devTeams.Clear();
		_devTeams.AddRange(GameSettings.Instance.GetDefaultTeams("Update"));
		UpdateTeamLabel();
		_activeTools.Clear();
		for (int num = 0; num < _tools.Count; num++)
		{
			_tools[num].gameObject.SetActive(false);
		}
		BugToggle.isOn = false;
		BugToggle.gameObject.SetActive(false);
		int num2 = 0;
		foreach (KeyValuePair<string, TechLevel> techLevel in f.TechLevels)
		{
			TechUpdatePanel techUpdatePanel;
			if (num2 >= _techs.Count)
			{
				techUpdatePanel = UnityEngine.Object.Instantiate(TechPrefab);
				techUpdatePanel.Parent = this;
				techUpdatePanel.transform.SetParent(TechPanel, false);
				techUpdatePanel.transform.SetSiblingIndex(2);
				_techs.Add(techUpdatePanel);
			}
			else
			{
				techUpdatePanel = _techs[num2];
				_techs[num2].gameObject.SetActive(true);
			}
			techUpdatePanel.Init(_framework, techLevel.Key);
			num2++;
		}
		for (int num3 = num2; num3 < _techs.Count; num3++)
		{
			_techs[num3].gameObject.SetActive(false);
		}
		Window.NonLocTitle = "UpdateForProduct".Loc(f.Name);
		RefreshTooling();
		UpdateSCMCombo();
		Window.Show();
	}

	public Dictionary<string, TechLevel> GetTechs()
	{
		if (_product == null)
		{
			return _framework.TechLevels;
		}
		return _product.TechLevels;
	}

	public void Show(SoftwareProduct p)
	{
		SoftwareUpdate tt = GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareUpdate>().FirstOrDefault((SoftwareUpdate x) => x.Target == p);
		if (tt != null)
		{
			if (tt.AutoDev)
			{
				GameSettings.Instance.MyCompany.WorkItems.OfType<AutoDevWorkItem>().ForEachEnum(delegate(AutoDevWorkItem x)
				{
					x.TakeOverTask(tt);
				});
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("UpdateInProgressError".Loc(), true, DialogWindow.DialogType.Error);
			}
			return;
		}
		TutorialSystem.Instance.StartTutorial("Updates");
		_product = p;
		_framework = null;
		_activeTechs.Clear();
		_devTeams.Clear();
		_devTeams.AddRange(GameSettings.Instance.GetDefaultTeams("Update"));
		UpdateTeamLabel();
		int num = 0;
		_activeTools.Clear();
		foreach (SpecFeature item in _product.Features.OfType<SpecFeature>())
		{
			string[] dependencies = item.Dependencies;
			foreach (string text in dependencies)
			{
				if (!_activeTools.ContainsKey(text))
				{
					SWToolPanel sWToolPanel;
					if (num < _tools.Count)
					{
						sWToolPanel = _tools[num];
					}
					else
					{
						sWToolPanel = UnityEngine.Object.Instantiate(ToolPrefab);
						sWToolPanel.transform.SetParent(TechPanel, false);
						sWToolPanel.transform.SetSiblingIndex(TechPanel.childCount - 2);
						_tools.Add(sWToolPanel);
					}
					_activeTools[text] = sWToolPanel;
					sWToolPanel.Init(text, p.Type, p.Features, _activeTechs, RefreshTechs);
					num++;
				}
			}
		}
		for (int num3 = num; num3 < _tools.Count; num3++)
		{
			_tools[num3].gameObject.SetActive(false);
		}
		BugToggle.isOn = true;
		BugToggle.gameObject.SetActive(true);
		num = 0;
		foreach (KeyValuePair<string, TechLevel> techLevel in p.TechLevels)
		{
			TechUpdatePanel techUpdatePanel;
			if (num >= _techs.Count)
			{
				techUpdatePanel = UnityEngine.Object.Instantiate(TechPrefab);
				techUpdatePanel.Parent = this;
				techUpdatePanel.transform.SetParent(TechPanel, false);
				techUpdatePanel.transform.SetSiblingIndex(2);
				_techs.Add(techUpdatePanel);
			}
			else
			{
				techUpdatePanel = _techs[num];
				_techs[num].gameObject.SetActive(true);
			}
			techUpdatePanel.Init(_product, techLevel.Key);
			num++;
		}
		for (int num4 = num; num4 < _techs.Count; num4++)
		{
			_techs[num4].gameObject.SetActive(false);
		}
		Window.NonLocTitle = "UpdateForProduct".Loc(p.Name);
		RefreshTooling();
		UpdateSCMCombo();
		Window.Show();
	}

	private void Update()
	{
		if (_product != null)
		{
			BugLabel.text = "PatchBugs".Loc(_product.FixableBugs);
		}
	}

	private void Start()
	{
		GameSettings instance = GameSettings.Instance;
		instance.OnServersChanged = (EventHandler)Delegate.Combine(instance.OnServersChanged, (EventHandler)delegate
		{
			if (Window.Shown)
			{
				UpdateSCMCombo();
			}
		});
		Data.ToolTips = new string[4] { null, null, null, "LicenseCostTip" };
	}

	private Dictionary<string, TechLevel> GetActualTechs()
	{
		Dictionary<string, TechLevel> dictionary = new Dictionary<string, TechLevel>();
		foreach (TechUpdatePanel item in _techs.Where((TechUpdatePanel x) => x.gameObject.activeSelf))
		{
			if (_framework != null)
			{
				if (item.Tech.Year > _framework.TechLevels[item.Tech.Spec].Year)
				{
					dictionary[item.Tech.Spec] = item.Tech;
				}
			}
			else if (item.Tech.Year > _product.TechLevels[item.Tech.Spec].Year)
			{
				dictionary[item.Tech.Spec] = item.Tech;
			}
		}
		return dictionary;
	}

	private float GetLicenseCost(int devEmps)
	{
		Company myCompany = GameSettings.Instance.MyCompany;
		float num = 0f;
		foreach (SWToolPanel item in _activeTools.Values.Where((SWToolPanel x) => x.gameObject.activeSelf && x.PickedProduct != null))
		{
			SoftwareProduct pickedProduct = item.PickedProduct;
			if (pickedProduct.HasToPay(myCompany))
			{
				num += pickedProduct.GetLicenseCost(true) * (float)devEmps;
			}
		}
		return num;
	}

	private FeatureBase[] GetUpdatedFeatures(Dictionary<string, TechLevel> techs)
	{
		if (_framework == null)
		{
			return _product.Features.Where((FeatureBase x) => techs.ContainsKey(x.Spec)).ToArray();
		}
		return _framework.Features.Keys.Where((FeatureBase x) => techs.ContainsKey(x.Spec)).ToArray();
	}

	private void RefreshData()
	{
		Dictionary<string, TechLevel> techs = GetActualTechs();
		if (techs.Count > 0)
		{
			Data.gameObject.SetActive(true);
			FeatureBase[] updatedFeatures = GetUpdatedFeatures(techs);
			Dictionary<string, TechLevel> techs2;
			float num;
			if (_framework != null)
			{
				techs2 = _framework.TechLevels.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => techs.GetOrDefault(x.Key, x.Value));
				Dictionary<string, float> scales = techs.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => (_framework.TechLevels[x.Key].Outdates - x.Value.Outdates).MapRange(1f, 5f, 0.1f, 0.5f, true));
				num = updatedFeatures.SumSafe((FeatureBase x) => x.GetDevTime(_framework.Category, _framework.Owner, techs, null, null, false) * scales[x.Spec] * SoftwareFramework.GetUpdateSpeed(_framework.Updated)) * (1f - SoftwareType.DesignRatio);
			}
			else
			{
				techs2 = _product.TechLevels.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => techs.GetOrDefault(x.Key, x.Value));
				Dictionary<string, float> scales2 = techs.ToDictionary((KeyValuePair<string, TechLevel> x) => x.Key, (KeyValuePair<string, TechLevel> x) => (_product.TechLevels[x.Key].Outdates - x.Value.Outdates).MapRange(1f, 5f, 0.1f, 0.5f, true));
				num = updatedFeatures.SumSafe((FeatureBase x) => x.GetDevTime(_product.Category, _product.DevCompany, techs, null, _product.Framework, false) * scales2[x.Spec]) * (1f - SoftwareType.DesignRatio);
			}
			float num2 = SoftwareType.CodeArtRatio(updatedFeatures);
			float num3 = Mathf.Max(1f, Mathf.Round(num));
			int optimalEmployees = GameData.GetOptimalEmployees((int)num3);
			int num4 = optimalEmployees;
			int num5 = 0;
			foreach (string devTeam in _devTeams)
			{
				Team team = GameSettings.GetTeam(devTeam);
				if (team != null)
				{
					num5 += team.GetEmployeesDirect().Count((Actor x) => x.employee.IsRole(Employee.RoleBit.Programmer | Employee.RoleBit.Artist));
				}
			}
			if (num5 > 0)
			{
				num4 = num5;
			}
			num3 = GameData.ProjectDevTimeGeneric(num4, (int)num3);
			List<string> list = new List<string>
			{
				"ETA".Loc(),
				"Recommendedprogrammers".Loc(),
				"Recommendedartists".Loc(),
				"Licensecosts".Loc()
			};
			List<string> list2 = new List<string>
			{
				DesignDocumentWindow.GetTimeString(num3, num, 1f),
				Mathf.Ceil((float)optimalEmployees * num2).ToString(),
				Mathf.Ceil((float)optimalEmployees * (1f - num2)).ToString(),
				GetLicenseCost(num4).Currency()
			};
			if (_product != null && _product.Framework != null)
			{
				float num6 = 0f;
				float num7 = 0f;
				for (int num8 = 0; num8 < _product.Features.Length; num8++)
				{
					FeatureBase featureBase = _product.Features[num8];
					num6 += featureBase.GetDevTime(_product.Category, _product.DevCompany, techs2, null, _product.Framework, false);
					num7 += featureBase.GetDevTime(_product.Category, null, techs2, null, null, false);
				}
				num6 = (num7 - num6) / num7;
				if ((double)num6 >= 0.1)
				{
					list.Add("SpeedBoost".Loc());
					list2.Add(num6.ToPercent());
				}
			}
			Data.SetData(list.ToArray(), list2.ToArray());
			string text = DesignDocumentWindow.CheckCompetency(updatedFeatures, null, _devTeams.SelectNotNull(GameSettings.GetTeam));
			if (text != null)
			{
				SpecWarning.gameObject.SetActive(true);
				SpecWarning.text = "MissingThing".Loc(text);
			}
			else
			{
				SpecWarning.gameObject.SetActive(false);
			}
		}
		else
		{
			Data.gameObject.SetActive(false);
			SpecWarning.gameObject.SetActive(false);
		}
	}

	private void OnEnable()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			UpdateSCMCombo();
		}
	}

	public void RefreshTechs()
	{
		foreach (TechUpdatePanel tech in _techs)
		{
			if (tech.gameObject.activeSelf)
			{
				tech.RefreshLimits();
			}
		}
		RefreshData();
	}

	public void RefreshActiveTech()
	{
		_activeTechs.Clear();
		foreach (TechUpdatePanel tech in _techs)
		{
			if (tech.gameObject.activeSelf)
			{
				_activeTechs[tech.Tech.Spec] = tech.Tech;
			}
		}
	}

	public void RefreshTooling()
	{
		HashSet<string> hashSet = new HashSet<string>();
		if (_product != null)
		{
			foreach (TechUpdatePanel tech in _techs)
			{
				if (tech.Active())
				{
					hashSet.AddRange(tech.SpecFeat.Dependencies);
				}
			}
			foreach (KeyValuePair<string, SWToolPanel> activeTool in _activeTools)
			{
				activeTool.Value.gameObject.SetActive(hashSet.Contains(activeTool.Key));
			}
		}
		ToolLabel.SetActive(hashSet.Count > 0);
		RefreshData();
		Window.rectTransform.sizeDelta = new Vector2(Window.rectTransform.sizeDelta.x, 166 + GetTechs().Count * 49 + hashSet.Count * 25 + ((hashSet.Count > 0) ? 21 : 0) + (Data.gameObject.activeSelf ? 84 : 0) + (SpecWarning.gameObject.activeSelf ? 21 : 0));
	}

	private void UpdateSCMCombo()
	{
		SCM.UpdateContent(new ServerGroup[1].Concat(GameSettings.Instance.GetAllServerGroups()));
		ServerGroup server;
		if (GameSettings.GetPrefServer("Update", out server))
		{
			SCM.SelectedItem = server;
		}
	}

	public void LaunchUpdate()
	{
		if (SCM.Selected > 0)
		{
			ServerGroup selected = SCM.GetSelected<ServerGroup>();
			GameSettings.SavePrefServer("Update", (selected != null) ? selected.Name : null);
		}
		Dictionary<string, TechLevel> dictionary = GetActualTechs();
		Dictionary<string, SoftwareProduct> tools = Tools;
		if (tools.Any((KeyValuePair<string, SoftwareProduct> x) => x.Value == null))
		{
			WindowManager.Instance.ShowMessageBox("ProductNeedError".Loc(), true, DialogWindow.DialogType.Error);
		}
		else if (dictionary.Count == 0 && (_framework != null || !BugToggle.isOn))
		{
			WindowManager.Instance.ShowMessageBox("UpdateInEmptyError".Loc(), true, DialogWindow.DialogType.Error);
		}
		else if (GameSettings.Instance.MyCompany.WorkItems.OfType<SoftwareUpdate>().None((SoftwareUpdate x) => (_product == null) ? (x.TargetFramework == _framework) : (x.Target == _product)))
		{
			if (dictionary.Count == 0)
			{
				dictionary = null;
			}
			SoftwareUpdate softwareUpdate;
			if (_framework == null)
			{
				SoftwareProduct product = _product;
				bool isOn = BugToggle.isOn;
				Dictionary<string, TechLevel> tech = dictionary;
				object scm;
				if (SCM.Selected >= 1)
				{
					ServerGroup selected2 = SCM.GetSelected<ServerGroup>();
					scm = ((selected2 != null) ? selected2.Name : null);
				}
				else
				{
					scm = null;
				}
				softwareUpdate = new SoftwareUpdate(product, isOn, tech, tools, (string)scm, -1);
			}
			else
			{
				SoftwareFramework framework = _framework;
				Dictionary<string, TechLevel> tech2 = dictionary;
				object scm2;
				if (SCM.Selected >= 1)
				{
					ServerGroup selected3 = SCM.GetSelected<ServerGroup>();
					scm2 = ((selected3 != null) ? selected3.Name : null);
				}
				else
				{
					scm2 = null;
				}
				softwareUpdate = new SoftwareUpdate(framework, tech2, (string)scm2, -1);
			}
			SoftwareUpdate softwareUpdate2 = softwareUpdate;
			softwareUpdate2.AddDevTeams(_devTeams);
			GameSettings.Instance.MyCompany.WorkItems.Add(softwareUpdate2);
			GameSettings.Instance.TeamDefaults["Update"] = _devTeams.ToHashSet();
			softwareUpdate2.CheckCompetency();
			Window.Close();
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("UpdateInProgressError".Loc(), true, DialogWindow.DialogType.Error);
		}
	}
}
