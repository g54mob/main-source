using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class TeamSelectWindow : MonoBehaviour
{
	public GameObject TogglePrefab;

	public InputField SearchBar;

	public ToggleGroup TGroup;

	public Toggle PassThrough;

	public GUIWindow Window;

	public Image NewTeamButton;

	public GameObject AllNonePanel;

	public GameObject OKButtonPanel;

	public RectTransform ContentPanel;

	public RectTransform ContentContainer;

	public ScrollRect MainScroll;

	[NonSerialized]
	private List<TeamToggle> TeamToggles = new List<TeamToggle>();

	[NonSerialized]
	private Employee _compatEmp;

	[NonSerialized]
	private Action<string[]> OnAccept;

	[NonSerialized]
	private Action<string[], SimulatedCompany> OnAccept2;

	[NonSerialized]
	private Action<string[], bool> OnAccept3;

	[NonSerialized]
	private ObjectPool<TeamToggle> _togglePool;

	[NonSerialized]
	private string _saveCat;

	[NonSerialized]
	private string _lastType;

	[NonSerialized]
	private string _taskType;

	private bool _singleTeam;

	private TeamToggle CreateToggle()
	{
		GameObject obj = UnityEngine.Object.Instantiate(TogglePrefab);
		obj.transform.SetParent(ContentPanel, false);
		return obj.GetComponent<TeamToggle>();
	}

	public void SearchUpdate()
	{
		if (string.IsNullOrWhiteSpace(SearchBar.text))
		{
			for (int i = 0; i < TeamToggles.Count; i++)
			{
				TeamToggles[i].gameObject.SetActive(true);
			}
			return;
		}
		string search = SearchBar.text.ToLower();
		for (int j = 0; j < TeamToggles.Count; j++)
		{
			TeamToggle teamToggle = TeamToggles[j];
			teamToggle.gameObject.SetActive(teamToggle.Match(search));
		}
	}

	private void ActivateToggle(TeamToggle t)
	{
		t.gameObject.SetActive(true);
	}

	private void DeactivateToggle(TeamToggle t)
	{
		t.MainToggle.onValueChanged.RemoveAllListeners();
		t.Team = null;
		t.Company = null;
		t.Player = null;
		t.Compat = null;
		t.MainToggle.group = null;
		t.MainToggle.isOn = false;
		t.gameObject.SetActive(false);
	}

	private void Awake()
	{
		_togglePool = new ObjectPool<TeamToggle>(CreateToggle, ActivateToggle, DeactivateToggle);
	}

	private void SetSingleTeam(bool singleTeam)
	{
		AllNonePanel.SetActive(!singleTeam);
		OKButtonPanel.SetActive(!singleTeam);
		NewTeamButton.sprite = ObjectDatabase.Instance.GetSprite(false, true, singleTeam, false);
		ContentContainer.offsetMax = new Vector2(ContentContainer.offsetMax.x, singleTeam ? (-25) : (-56));
		RectTransform component = SearchBar.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(component.anchoredPosition.x, singleTeam ? (-10) : (-40));
	}

	public void Show(bool singleTeam, string selected, Action<string[]> accept, string type, string saveCat = null, Employee compat = null)
	{
		PassThrough.gameObject.SetActive(false);
		_singleTeam = singleTeam;
		SetSingleTeam(singleTeam);
		_saveCat = saveCat;
		_compatEmp = compat;
		_taskType = null;
		Init(string.IsNullOrEmpty(selected) ? null : new HashSet<string> { selected }, null, false, singleTeam, null);
		OnAccept = accept;
		OnAccept2 = null;
		OnAccept3 = null;
		_lastType = type;
		Window.Show();
		SearchBar.text = "";
		SearchBar.Select();
	}

	public void Show(bool singleTeam, HashSet<string> selected, Action<string[]> accept, string type, string saveCat = null, string taskType = null, WorkItem networking = null)
	{
		PassThrough.gameObject.SetActive(false);
		_singleTeam = singleTeam;
		SetSingleTeam(singleTeam);
		_saveCat = saveCat;
		_compatEmp = null;
		_taskType = taskType;
		Init(selected, null, false, singleTeam, networking);
		OnAccept = accept;
		OnAccept2 = null;
		OnAccept3 = null;
		_lastType = type;
		Window.Show();
		SearchBar.text = "";
		SearchBar.Select();
	}

	public void Show(HashSet<string> selected, SimulatedCompany selectedCompany, Action<string[], SimulatedCompany> accept, string type, string saveCat = null, string taskType = null, WorkItem networking = null)
	{
		PassThrough.gameObject.SetActive(false);
		_singleTeam = false;
		SetSingleTeam(false);
		_saveCat = saveCat;
		_compatEmp = null;
		_taskType = taskType;
		Init(selected, selectedCompany, true, false, networking);
		OnAccept = null;
		OnAccept2 = accept;
		OnAccept3 = null;
		_lastType = type;
		Window.Show();
		SearchBar.text = "";
		SearchBar.Select();
	}

	public void ShowPassThrough(HashSet<string> selected, Action<string[], bool> accept, bool passThrough)
	{
		PassThrough.gameObject.SetActive(true);
		PassThrough.isOn = passThrough;
		_singleTeam = false;
		SetSingleTeam(false);
		_saveCat = null;
		_compatEmp = null;
		_taskType = null;
		Init(selected, null, false, false, null);
		OnAccept = null;
		OnAccept2 = null;
		_lastType = null;
		OnAccept3 = accept;
		Window.Show();
		SearchBar.text = "";
		SearchBar.Select();
	}

	private void Init(HashSet<string> selected, SimulatedCompany selectedCompany, bool subsidiaries, bool singleTeam, WorkItem networkingTarget)
	{
		_togglePool.ReleaseAll();
		TeamToggles.Clear();
		if (subsidiaries)
		{
			foreach (KeyValuePair<uint, SimulatedCompany> company in GameSettings.Instance.simulation.Companies)
			{
				SimulatedCompany value = company.Value;
				if (!value.IsPlayerOwned())
				{
					continue;
				}
				Toggle toggle = CreateToggle(value, selectedCompany == value);
				if (!singleTeam)
				{
					continue;
				}
				toggle.onValueChanged.AddListener(delegate(bool x)
				{
					if (x)
					{
						Accept();
					}
				});
			}
		}
		if (networkingTarget != null && NetworkManager.IsConnected)
		{
			foreach (NetworkPlayer player in NetworkManager.Instance.Players.Where((NetworkPlayer x) => !x.Self && x.InGame && x.Name != null))
			{
				CreateToggle(player, false).onValueChanged.AddListener(delegate(bool x)
				{
					if (x)
					{
						HUD.Instance.networkDealWindow.Show(networkingTarget, player);
						Window.Close();
					}
				});
			}
		}
		foreach (string key in GameSettings.Instance.sActorManager.Teams.Keys)
		{
			Toggle toggle2 = CreateToggle(key, selected != null && selected.Contains(key));
			if (!singleTeam)
			{
				continue;
			}
			toggle2.onValueChanged.AddListener(delegate(bool x)
			{
				if (x)
				{
					Accept();
				}
			});
		}
		OrderTeams(_lastType);
		MainScroll.normalizedPosition = Vector2.up;
	}

	private SDateTime GetLast(TeamToggle t, string type)
	{
		if (type == null)
		{
			return default(SDateTime);
		}
		Team team = t.GetTeam();
		if (team == null)
		{
			return default(SDateTime);
		}
		return team.LastAssigned.GetOrDefault(type);
	}

	private void OrderTeams(string type)
	{
		int num = 0;
		foreach (TeamToggle item in from x in TeamToggles
			orderby ((x.Player == null) ? ((x.Company != null) ? 2 : 4) : 0) + ((!x.MainToggle.isOn) ? 1 : 0), GetLast(x, type).ToInt() descending, (x.Player == null) ? ((x.Company == null) ? x.Team : x.Company.Name) : x.Player.Name
			select x)
		{
			item.transform.SetSiblingIndex(num);
			num++;
		}
	}

	private Toggle CreateToggle(NetworkPlayer player, bool selected)
	{
		TeamToggle tt = _togglePool.Get();
		tt.Player = player;
		if (selected)
		{
			tt.MainToggle.isOn = true;
		}
		tt.MainToggle.onValueChanged.AddListener(delegate(bool x)
		{
			if (x)
			{
				foreach (TeamToggle teamToggle in TeamToggles)
				{
					if (teamToggle != tt)
					{
						teamToggle.MainToggle.isOn = false;
					}
				}
			}
		});
		tt.Init(_taskType);
		TeamToggles.Add(tt);
		return tt.MainToggle;
	}

	private Toggle CreateToggle(SimulatedCompany company, bool selected)
	{
		TeamToggle tt = _togglePool.Get();
		tt.Company = company;
		if (selected)
		{
			tt.MainToggle.isOn = true;
		}
		tt.MainToggle.onValueChanged.AddListener(delegate(bool x)
		{
			if (x)
			{
				foreach (TeamToggle teamToggle in TeamToggles)
				{
					if (teamToggle != tt)
					{
						teamToggle.MainToggle.isOn = false;
					}
				}
			}
		});
		tt.Init(_taskType);
		TeamToggles.Add(tt);
		return tt.MainToggle;
	}

	private Toggle CreateToggle(string team, bool selected)
	{
		TeamToggle tt = _togglePool.Get();
		tt.Team = team;
		tt.Compat = _compatEmp;
		if (_singleTeam)
		{
			tt.MainToggle.onValueChanged.AddListener(delegate(bool x)
			{
				if (x)
				{
					foreach (TeamToggle teamToggle in TeamToggles)
					{
						if (teamToggle != tt)
						{
							teamToggle.MainToggle.isOn = false;
						}
					}
				}
			});
		}
		else
		{
			tt.MainToggle.onValueChanged.AddListener(delegate(bool x)
			{
				if (x)
				{
					foreach (TeamToggle teamToggle2 in TeamToggles)
					{
						if (teamToggle2.Company != null)
						{
							teamToggle2.MainToggle.isOn = false;
						}
					}
				}
			});
		}
		if (selected)
		{
			tt.MainToggle.isOn = true;
		}
		tt.Init(_taskType);
		TeamToggles.Add(tt);
		return tt.MainToggle;
	}

	private void Update()
	{
		if (!Window.IsActiveWindow || (!Input.GetKeyDown(KeyCode.Return) && !Input.GetKeyDown(KeyCode.KeypadEnter)))
		{
			return;
		}
		if (!string.IsNullOrWhiteSpace(SearchBar.text))
		{
			string search = SearchBar.text.ToLower();
			bool flag = true;
			bool flag2 = false;
			for (int i = 0; i < ContentPanel.childCount; i++)
			{
				Transform child = ContentPanel.GetChild(i);
				if (!(child.gameObject != null))
				{
					continue;
				}
				TeamToggle component = child.GetComponent<TeamToggle>();
				if (!(component != null))
				{
					continue;
				}
				bool flag3 = !flag2 && (!_singleTeam || flag) && component.Match(search);
				component.MainToggle.isOn = flag3;
				if (flag3)
				{
					if (component.Company != null)
					{
						flag2 = true;
					}
					flag = false;
				}
			}
		}
		Accept();
	}

	public void SelectAllNone(bool all)
	{
		foreach (TeamToggle teamToggle in TeamToggles)
		{
			teamToggle.MainToggle.isOn = all && teamToggle.gameObject.activeSelf && teamToggle.Company == null;
		}
	}

	public void Accept()
	{
		TeamToggle teamToggle = TeamToggles.FirstOrDefault((TeamToggle x) => x.MainToggle.isOn && x.Company != null);
		string[] array = ((teamToggle == null) ? TeamToggles.WhereSelect((TeamToggle x) => x.MainToggle.isOn, (TeamToggle x) => x.Team).ToArray() : null);
		if (OnAccept != null)
		{
			OnAccept(array);
		}
		else if (OnAccept2 != null)
		{
			OnAccept2(array, (teamToggle != null) ? teamToggle.Company : null);
		}
		else if (OnAccept3 != null)
		{
			OnAccept3(array, PassThrough.isOn);
		}
		if (array != null)
		{
			if (_saveCat != null)
			{
				GameSettings.Instance.TeamDefaults[_saveCat] = array.ToHashSet();
			}
			if (_lastType != null)
			{
				SDateTime value = SDateTime.Now().SimplifyMore();
				foreach (Team item in array.SelectNotNull(GameSettings.GetTeam))
				{
					item.LastAssigned[_lastType] = value;
				}
			}
		}
		Window.Close();
	}

	public void NewTeam()
	{
		WindowManager.SpawnInputDialog("Teamname".Loc(), "Newteam".Loc(), "", delegate(string s)
		{
			if (HUD.Instance.TeamWindow.CreateTeam(s))
			{
				CreateToggle(s, true);
				OrderTeams(_lastType);
				if (_singleTeam)
				{
					Accept();
				}
			}
		});
	}
}
