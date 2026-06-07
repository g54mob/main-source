using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResearchWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GameObject SWButtonPrefab;

	public GameObject SWPanel;

	public GameObject NoResearch;

	public Text ResearchButtonText;

	public Text MainLabel;

	public Text StatusLabel;

	public GUIListView featureList;

	public GUIListView ActiveList;

	public int NewSpecs;

	public ButtonCounter Counter;

	[NonSerialized]
	private Dictionary<string, GameObject> SWButtons = new Dictionary<string, GameObject>();

	[NonSerialized]
	public string Spec;

	[NonSerialized]
	private bool _initialized;

	public static EventHandler SpecsChanged;

	private void Init()
	{
		if (_initialized)
		{
			return;
		}
		string[] allSpecializations = GameSettings.Instance.GetAllSpecializations(Employee.EmployeeRole.Designer);
		foreach (string text in allSpecializations)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(SWButtonPrefab);
			Button component = gameObject.GetComponent<Button>();
			string localItem = text;
			component.onClick.AddListener(delegate
			{
				Spec = localItem;
				MainLabel.text = localItem.LocTry();
				ResearchButtonText.text = "ResearchAction".Loc(Spec.LocTry() + " - " + (TimeOfDay.Instance.Year + 1900), "SpecSkillRole".Loc(3, Spec.LocTry(), "Designer".Loc()), GameSettings.Instance.simulation.GetRoyalty(Spec).ToPercent(), GameData.GetOptimalEmployees(Mathf.CeilToInt(GameSettings.Instance.simulation.GetTechMonths(Spec))));
				UpdateLists();
			});
			gameObject.GetComponentInChildren<Text>().text = localItem.LocTry();
			gameObject.transform.SetParent(SWPanel.transform, false);
			SWButtons[localItem] = gameObject;
		}
		GUIColumn gUIColumn = ActiveList["AResearchETA"];
		ActiveList.LastSort = gUIColumn;
		gUIColumn.Sort(true);
		_initialized = true;
	}

	private void Start()
	{
		Init();
		UpdateLists();
		featureList.OnDoubleClick = delegate
		{
			TechLevel firstSelected = featureList.GetFirstSelected<TechLevel>();
			if (firstSelected != null)
			{
				List<Company> res = new List<Company>();
				foreach (Company allCompany in MarketSimulation.Active.GetAllCompanies())
				{
					if (allCompany.GetLocalLatestResearch(firstSelected.Spec, 0) >= firstSelected.Year)
					{
						res.Add(allCompany);
					}
				}
				if (res.Count > 0)
				{
					res.Sort((Company x, Company y) => x.Name.CompareTo(y.Name));
					WindowManager.Instance.MultiWindow.Show("Researched", res.Select((Company x) => x.Name), delegate(int x)
					{
						HUD.Instance.companyWindow.ShowCompanyDetails(res[x]);
					}, false);
				}
			}
		};
	}

	private void UpdateUnlocked()
	{
		Init();
		bool flag = false;
		HashSet<string> hashSet = GameSettings.Instance.GetUnlockedSpecializations(Employee.EmployeeRole.Designer).ToHashSet();
		foreach (KeyValuePair<string, GameObject> sWButton in SWButtons)
		{
			bool activeSelf = sWButton.Value.activeSelf;
			bool flag2 = hashSet.Contains(sWButton.Key);
			if (flag2 && !activeSelf)
			{
				NewSpecs++;
				flag = true;
			}
			sWButton.Value.SetActive(flag2);
		}
		if (flag)
		{
			EventHandler specsChanged = SpecsChanged;
			if (specsChanged != null)
			{
				specsChanged(this, null);
			}
		}
		Counter.SetNumber(NewSpecs);
	}

	public void ResearchClick()
	{
		if (Spec == null || GameSettings.Instance.IsResearching(Spec))
		{
			return;
		}
		if (GameSettings.Instance.MyCompany.GetLocalLatestResearch(Spec, -1) >= TimeOfDay.Instance.Year)
		{
			WindowManager.Instance.ShowMessageBox("AlreadyResearched".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		HUD.Instance.TeamSelectWindow.Show(false, GameSettings.Instance.GetDefaultTeams("Research"), delegate(string[] x)
		{
			ResearchWork researchWork = new ResearchWork(Spec, TimeOfDay.Instance.Year);
			researchWork.AddDevTeams(x);
			GameSettings.Instance.MyCompany.AddWorkItem(researchWork);
			UpdateLists();
		}, "Research", "Research", "ResearchWork");
	}

	public void UpdateLists()
	{
		UpdateUnlocked();
		featureList.Items.Clear();
		ActiveList.Items.Clear();
		List<TechLevel> value;
		if (Spec != null && GameSettings.Instance.simulation.TechLevels.TryGetValue(Spec, out value) && value.Count > 0)
		{
			featureList.Items.AddRange(value.Cast<object>());
			ActiveList.Items.AddRange((from x in MarketSimulation.Active.Companies.Values
				where x.SpecResearch != null && x.SpecResearch.Spec.Equals(Spec)
				select new KeyValuePair<Company, SimulatedCompany.TechResearch>(x, x.SpecResearch)).Cast<object>());
			ResearchWork researchWork = GameSettings.Instance.MyCompany.WorkItems.OfType<ResearchWork>().FirstOrDefault((ResearchWork x) => x.Spec.Equals(Spec));
			if (researchWork == null)
			{
				int year = value[Mathf.Max(0, value.Count - 2)].Year;
				string source;
				string sourceType;
				int latestResearchDetailed = GameSettings.Instance.MyCompany.GetLatestResearchDetailed(Spec, year, out source, out sourceType);
				if (sourceType != null)
				{
					StatusLabel.text = "ResearchStatus".Loc(1900 + latestResearchDetailed, sourceType, source);
				}
				else
				{
					int localLatestResearch = GameSettings.Instance.MyCompany.GetLocalLatestResearch(Spec, -1);
					if (localLatestResearch > 0)
					{
						StatusLabel.text = "Researched".Loc() + " " + (1900 + localLatestResearch);
					}
					else
					{
						StatusLabel.text = "NotResearched".Loc();
					}
				}
			}
			else
			{
				StatusLabel.text = "OngoingResearch".Loc(1900 + researchWork.Year);
			}
		}
		else
		{
			StatusLabel.text = "";
		}
	}

	public void ToggleShow()
	{
		if (Window.ToggleReturn())
		{
			TutorialSystem.Instance.StartTutorial("Research");
			Spec = null;
			MainLabel.text = "";
			NewSpecs = 0;
			Counter.SetNumber(0);
			UpdateLists();
			UpdateUnlocked();
		}
	}
}
