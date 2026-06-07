using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpecializationChart : MonoBehaviour
{
	public static Employee.EmployeeRole[][] Roles = new Employee.EmployeeRole[4][]
	{
		new Employee.EmployeeRole[3]
		{
			Employee.EmployeeRole.Designer,
			Employee.EmployeeRole.Programmer,
			Employee.EmployeeRole.Artist
		},
		new Employee.EmployeeRole[1],
		new Employee.EmployeeRole[1] { Employee.EmployeeRole.Service },
		new Employee.EmployeeRole[5]
		{
			Employee.EmployeeRole.Lead,
			Employee.EmployeeRole.Designer,
			Employee.EmployeeRole.Programmer,
			Employee.EmployeeRole.Artist,
			Employee.EmployeeRole.Service
		}
	};

	public static Color[][] SkillColors = new Color[4][]
	{
		new Color[5]
		{
			new Color32(200, 200, 100, byte.MaxValue),
			new Color32(161, 219, 133, byte.MaxValue),
			new Color32(133, 162, 219, byte.MaxValue),
			new Color32(219, 100, 100, byte.MaxValue),
			new Color32(219, 180, 120, byte.MaxValue)
		},
		new Color[5]
		{
			new Color32(byte.MaxValue, 248, 57, byte.MaxValue),
			new Color32(171, 160, 55, byte.MaxValue),
			new Color32(2, 85, 253, byte.MaxValue),
			new Color32(16, 81, 171, byte.MaxValue),
			new Color32(111, 130, 206, byte.MaxValue)
		},
		new Color[5]
		{
			new Color32(254, 251, 52, byte.MaxValue),
			new Color32(185, 170, 53, byte.MaxValue),
			new Color32(0, 80, byte.MaxValue, byte.MaxValue),
			new Color32(2, 53, 178, byte.MaxValue),
			new Color32(121, 139, 211, byte.MaxValue)
		},
		new Color[5]
		{
			new Color32(251, 170, 189, byte.MaxValue),
			new Color32(97, 210, 250, byte.MaxValue),
			new Color32(17, 164, 197, byte.MaxValue),
			new Color32(254, 41, 107, byte.MaxValue),
			new Color32(215, 70, 113, byte.MaxValue)
		}
	};

	public static Color NonActiveColor = new Color32(138, 138, 138, byte.MaxValue);

	public GameObject ContentPanel;

	public GameObject EmptyCorner;

	public RectTransform ContentRect;

	public GridLayoutGroup GridPanel;

	public Text TextPrefab;

	public GUIProgressBar ProgressBarPrefab;

	public StarCounter StarCountPrefab;

	private GUIProgressBar[] BaseBars;

	private Text[] MainLabels;

	private Text[] PointLabels;

	private GameObject BaseSkillLabel;

	private GameObject PointLabel;

	public GUICombobox RoleCombo;

	public EducationWindow EdWindow;

	private List<StarCounter> _specPool = new List<StarCounter>();

	private Dictionary<string, StarCounter>[] SpecBars = new Dictionary<string, StarCounter>[5];

	private List<Text> labels = new List<Text>();

	public UnityEvent OnChanged;

	public bool AutoSize = true;

	public bool ShowAllRoles;

	public bool DisplayAllOption;

	public bool ForceAllRoles;

	public bool IncludeBaseSkill = true;

	public bool Customization;

	public ISpecController SpecController;

	[NonSerialized]
	public Employee[] Employees = new Employee[0];

	[NonSerialized]
	public Team CompareTeam;

	[NonSerialized]
	public Team MinSkillTeam;

	[NonSerialized]
	public Dictionary<string, int>[] CustomSpecLevels = new Dictionary<string, int>[5]
	{
		new Dictionary<string, int>(),
		new Dictionary<string, int>(),
		new Dictionary<string, int>(),
		new Dictionary<string, int>(),
		new Dictionary<string, int>()
	};

	[NonSerialized]
	public float[] SkillOverride;

	public static Color GetSkillColor(Employee.EmployeeRole role)
	{
		if (Options.ColorBlindness != -1)
		{
			return SkillColors[Options.ColorBlindness][(int)role];
		}
		return Options.GetCustomColor((int)(8 + role));
	}

	private StarCounter GetCounter()
	{
		StarCounter starCounter = _specPool.Pop();
		if (starCounter != null)
		{
			starCounter.gameObject.SetActive(true);
			return starCounter;
		}
		return UnityEngine.Object.Instantiate(StarCountPrefab);
	}

	private void DestroyCounter(StarCounter c)
	{
		c.gameObject.SetActive(false);
		c.OnPointerDownEvent.RemoveAllListeners();
		_specPool.Add(c);
	}

	private void Start()
	{
		MainLabels = new Text[5];
		PointLabels = new Text[5];
		for (int i = 0; i < 5; i++)
		{
			MainLabels[i] = CreateLabel();
		}
		Text text = UnityEngine.Object.Instantiate(TextPrefab);
		text.text = "Baseskill".LocTry();
		text.transform.SetParent(ContentPanel.transform, false);
		BaseSkillLabel = text.gameObject;
		BaseBars = new GUIProgressBar[5];
		for (int j = 0; j < 5; j++)
		{
			GUIProgressBar gUIProgressBar = UnityEngine.Object.Instantiate(ProgressBarPrefab);
			gUIProgressBar.transform.SetParent(ContentPanel.transform, false);
			BaseBars[j] = gUIProgressBar;
			gUIProgressBar.gameObject.SetActive(false);
			SpecBars[j] = new Dictionary<string, StarCounter>();
		}
		Text text2 = UnityEngine.Object.Instantiate(TextPrefab);
		text2.text = "PointsLeft".Loc();
		text2.transform.SetParent(ContentPanel.transform, false);
		text2.gameObject.SetActive(false);
		PointLabels = new Text[5];
		for (int k = 0; k < 5; k++)
		{
			PointLabels[k] = CreateLabel();
			PointLabels[k].alignment = TextAnchor.MiddleCenter;
		}
		PointLabel = text2.gameObject;
		RoleCombo.UpdateContent((!DisplayAllOption) ? new string[3] { "Development", "Leader", "Service" } : new string[4] { "Development", "Leader", "Service", "All" });
		RoleCombo.gameObject.SetActive(!ShowAllRoles);
		EmptyCorner.SetActive(ShowAllRoles);
		ResearchWindow.SpecsChanged = (EventHandler)Delegate.Combine(ResearchWindow.SpecsChanged, new EventHandler(ContentCallback));
	}

	private void ContentCallback(object sender, EventArgs e)
	{
		if (base.gameObject.activeInHierarchy)
		{
			ResetContent();
		}
	}

	private void OnDestroy()
	{
		ResearchWindow.SpecsChanged = (EventHandler)Delegate.Remove(ResearchWindow.SpecsChanged, new EventHandler(ContentCallback));
	}

	private Text CreateLabel()
	{
		Text text = UnityEngine.Object.Instantiate(TextPrefab);
		text.transform.SetParent(ContentPanel.transform, false);
		text.gameObject.SetActive(false);
		return text;
	}

	public void SetContent(Employee[] emps)
	{
		Employees = emps;
		ResetContent();
	}

	public void ResetContent()
	{
		if (Customization && SpecController == null)
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			foreach (KeyValuePair<string, StarCounter> item in SpecBars[i])
			{
				DestroyCounter(item.Value);
			}
			SpecBars[i].Clear();
		}
		labels.ForEach(delegate(Text x)
		{
			UnityEngine.Object.Destroy(x.gameObject);
		});
		labels.Clear();
		bool flag = Customization || Employees.Length == 1;
		int num = (ShowAllRoles ? 3 : RoleCombo.Selected);
		GridPanel.constraintCount = Roles[num].Length + 1;
		BaseSkillLabel.SetActive(IncludeBaseSkill);
		PointLabel.SetActive(flag);
		bool flag2 = !Customization && Employees.Length != 0 && Employees.All((Employee x) => x.HasDemanded(LeadDesignDemands.Demand.ExclusiveLead));
		if (Customization || Employees.Length != 0 || SkillOverride != null)
		{
			HashSet<string> hashSet = new HashSet<string>();
			string[][] array = (Customization ? SpecController.GetUnlockedSpecializations() : GameSettings.Instance.GetAllUnlockedSpecializations());
			for (int num2 = 0; num2 < 5; num2++)
			{
				if (num2 < Roles[num].Length)
				{
					Employee.EmployeeRole employeeRole = Roles[num][num2];
					int num3 = (int)employeeRole;
					if (Customization)
					{
						List<string> list = CustomSpecLevels[num3].Keys.ToList();
						for (int num4 = 0; num4 < list.Count; num4++)
						{
							string text = list[num4];
							if (!array[num3].Contains(text))
							{
								CustomSpecLevels[num3].Remove(text);
							}
						}
					}
					hashSet.AddRange(array[num3]);
					BaseBars[num2].gameObject.SetActive(IncludeBaseSkill);
					MainLabels[num2].gameObject.SetActive(true);
					BaseBars[num2].EndExt = (BaseBars[num2].EndColor = (BaseBars[num2].StartColor = (flag2 ? Color.gray : GetSkillColor(employeeRole))));
					MainLabels[num2].text = employeeRole.ToString().Loc();
					if (flag)
					{
						PointLabels[num2].gameObject.SetActive(true);
						PointLabels[num2].text = (Customization ? "0" : Employees[0].GetSpecPointsLeft(employeeRole, Employees[0].MyActor).ToString());
					}
					else
					{
						PointLabels[num2].gameObject.SetActive(false);
					}
				}
				else
				{
					BaseBars[num2].gameObject.SetActive(false);
					MainLabels[num2].gameObject.SetActive(false);
					PointLabels[num2].gameObject.SetActive(false);
				}
			}
			IEnumerable<SoftwareType> enumerable;
			if (!Customization)
			{
				IEnumerable<SoftwareType> values = MarketSimulation.Active.SoftwareTypes.Values;
				enumerable = values;
			}
			else
			{
				enumerable = GameData.AllSoftwareTypes();
			}
			IEnumerable<SoftwareType> sw = enumerable;
			string[] array2 = ((!flag2) ? null : new string[3]
			{
				"LeadDemandExclusiveLead".Loc(),
				"LeadDemandExclusiveLead".Loc(),
				"LeadDemandExclusiveLead".Loc()
			});
			foreach (string item2 in hashSet.OrderByDescending((string x) => SpecDevTime(x, sw)))
			{
				Text text2 = UnityEngine.Object.Instantiate(TextPrefab);
				text2.text = item2.LocTry();
				text2.transform.SetParent(ContentPanel.transform, false);
				text2.transform.SetAsLastSibling();
				labels.Add(text2);
				for (int num5 = 0; num5 < Roles[num].Length; num5++)
				{
					Employee.EmployeeRole r = Roles[num][num5];
					StarCounter counter = GetCounter();
					counter.transform.SetParent(ContentPanel.transform, false);
					counter.transform.SetAsLastSibling();
					counter.ActiveColor = (flag2 ? new Color(0.7f, 0.7f, 0.7f, 1f) : GetSkillColor(r));
					if (!Customization && Employees != null && Employees.Length == 1)
					{
						counter.NonActiveColor = (Employees[0].SpecPointsLeft(r) ? NonActiveColor : Color.clear);
					}
					counter.Numbers = (array[(int)r].Contains(item2) ? new int[3] : null);
					counter.Tips = (flag2 ? array2 : Employee.GetTips(r, item2));
					if (Customization)
					{
						string spec1 = item2;
						counter.OnPointerDownEvent.AddListener(delegate(int lvl)
						{
							HandleClick(r, spec1, lvl);
						});
					}
					else if (EdWindow != null)
					{
						string spec2 = item2;
						counter.OnPointerDownEvent.AddListener(delegate(int lvl)
						{
							HandleEdClick(r, spec2, lvl);
						});
					}
					SpecBars[num5][item2] = counter;
				}
			}
		}
		Update();
	}

	public static float SpecDevTime(string spec, IEnumerable<SoftwareType> types)
	{
		float num = 0f;
		foreach (SoftwareType type in types)
		{
			foreach (FeatureBase allFeature in type.GetAllFeatures())
			{
				if (allFeature.Spec.Equals(spec))
				{
					num += allFeature.DevTime;
				}
			}
		}
		return num;
	}

	public void RandomizePoints()
	{
		string[][] unlockedSpecializations = SpecController.GetUnlockedSpecializations();
		HashSet<string> hashSet = new HashSet<string>();
		for (int i = 0; i < 5; i++)
		{
			Employee.EmployeeRole r = (Employee.EmployeeRole)i;
			int maxPoints = SpecController.GetMaxPoints(r);
			int num = CountPoints(r, CustomSpecLevels);
			if (maxPoints <= num)
			{
				continue;
			}
			hashSet.Clear();
			for (int j = 0; j < unlockedSpecializations[i].Length; j++)
			{
				string text = unlockedSpecializations[i][j];
				if (CustomSpecLevels[i].GetOrDefault(text, 0) < 3)
				{
					hashSet.Add(text);
				}
			}
			int num2 = maxPoints - num;
			while (hashSet.Count > 0 && num2 > 0)
			{
				string random = hashSet.GetRandom(hashSet.Count);
				int orDefault = CustomSpecLevels[i].GetOrDefault(random, 0);
				if (orDefault < 3)
				{
					CustomSpecLevels[i][random] = orDefault + 1;
					num2--;
					if (orDefault >= 3)
					{
						hashSet.Remove(random);
					}
				}
				else
				{
					hashSet.Remove(random);
				}
			}
		}
		OnChanged.Invoke();
	}

	public void ResetPoints()
	{
		for (int i = 0; i < 5; i++)
		{
			CustomSpecLevels[i].Clear();
		}
		OnChanged.Invoke();
	}

	public void MaintainCounts(Dictionary<string, int>[] specs, int founder)
	{
		bool flag = false;
		for (int i = 0; i < 5; i++)
		{
			Employee.EmployeeRole r = (Employee.EmployeeRole)i;
			int maxPoints = SpecController.GetMaxPoints(r, founder);
			int num = CountPoints(r, specs);
			if (num <= 0 || num <= maxPoints)
			{
				continue;
			}
			int num2 = num - maxPoints;
			List<KeyValuePair<string, int>> list = specs[i].ToList();
			while (num2 > 0)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (num2 <= 0)
					{
						break;
					}
					KeyValuePair<string, int> keyValuePair = list[j];
					if (keyValuePair.Value > 0)
					{
						list[j] = new KeyValuePair<string, int>(keyValuePair.Key, keyValuePair.Value - 1);
						num2--;
					}
				}
			}
			specs[i] = list.ToDictionary((KeyValuePair<string, int> x) => x.Key, (KeyValuePair<string, int> x) => x.Value);
			flag = true;
		}
		if (flag)
		{
			OnChanged.Invoke();
		}
	}

	public bool Spent(Dictionary<string, int>[] specs, int founder)
	{
		string[][] unlockedSpecializations = SpecController.GetUnlockedSpecializations();
		for (int i = 0; i < 5; i++)
		{
			Employee.EmployeeRole r = (Employee.EmployeeRole)i;
			int num = Mathf.Min(unlockedSpecializations[i].Length * 3, SpecController.GetMaxPoints(r, founder));
			if (CountPoints(r, specs) < num)
			{
				RoleCombo.Selected = GetCombo(r);
				return false;
			}
		}
		return true;
	}

	public int GetCombo(Employee.EmployeeRole r)
	{
		for (int i = 0; i < Roles.GetLength(0); i++)
		{
			if (Roles[i].Contains(r))
			{
				return i;
			}
		}
		return 0;
	}

	private void HandleEdClick(Employee.EmployeeRole role, string spec, int i)
	{
		if (Employees != null && Employees.Length == 1 && Employees[0].MyActor != null)
		{
			UISoundFX.PlaySFX("ButtonClick");
			EdWindow.SendEmployeeDirect(Employees[0].MyActor, role, spec, i + 1);
			string text = role.ToString();
			if (EdWindow.RoleCombo.Items.Contains(text))
			{
				EdWindow.RoleCombo.SelectedItem = text;
			}
		}
	}

	private void HandleClick(Employee.EmployeeRole role, string spec, int i)
	{
		int orDefault = CustomSpecLevels[(int)role].GetOrDefault(spec, 0);
		if (orDefault == 1 && i == 0)
		{
			CustomSpecLevels[(int)role][spec] = 0;
			UISoundFX.PlaySFX("ToggleClick");
		}
		else
		{
			i++;
			if (i > orDefault)
			{
				i = Mathf.Min(i, SpecController.GetMaxPoints(role) - CountPoints(role, CustomSpecLevels) + orDefault);
			}
			if (i != orDefault)
			{
				CustomSpecLevels[(int)role][spec] = i;
				UISoundFX.PlaySFX("ToggleClick", 1f + (float)i / 6f);
			}
		}
		OnChanged.Invoke();
	}

	private int CountPoints(Employee.EmployeeRole r, Dictionary<string, int>[] specs)
	{
		return specs[(int)r].SumSafe((KeyValuePair<string, int> x) => x.Value);
	}

	private void Update()
	{
		if (AutoSize)
		{
			float num = ContentRect.rect.width / (float)GridPanel.constraintCount - 2f;
			GridPanel.cellSize = new Vector2(num, Mathf.Min(24f, num / 4f));
		}
		bool flag = CompareTeam != null && CompareTeam.GetEmployeesDirect().Count > 0;
		int num2 = (ShowAllRoles ? 3 : RoleCombo.Selected);
		bool flag2 = EdWindow != null && Employees.Length == 1 && Employees[0].MyActor != null;
		for (int i = 0; i < Roles[num2].Length; i++)
		{
			Employee.EmployeeRole r = Roles[num2][i];
			if (IncludeBaseSkill)
			{
				BaseBars[i].Value = ((SkillOverride != null) ? SkillOverride[i] : Employees.AverageOrDefault((Employee x) => x.GetSkill(r)));
				BaseBars[i].AltValue = (flag ? CompareTeam.GetEmployeesDirect().AverageOrDefault((Actor x) => x.employee.GetSkill(r)) : 0f);
			}
			int num3 = 0;
			if (Customization)
			{
				num3 = SpecController.GetMaxPoints(r) - CountPoints(r, CustomSpecLevels);
			}
			else if (flag2)
			{
				num3 = Mathf.FloorToInt(Employees[0].GetSpecExperience(r, Employees[0].MyActor));
			}
			if (Employees.Length == 1)
			{
				PointLabels[i].text = Employees[0].GetSpecPointsLeft(r, Employees[0].MyActor).ToString();
			}
			else if (Customization)
			{
				PointLabels[i].text = num3.ToString();
			}
			foreach (KeyValuePair<string, StarCounter> item in SpecBars[i])
			{
				if (item.Value.Numbers == null)
				{
					continue;
				}
				int num4 = 0;
				if (Customization || SkillOverride != null)
				{
					num4 = CustomSpecLevels[(int)r].GetOrDefault(item.Key, 0);
					item.Value.ForceNum = num4 - 1;
				}
				else if (flag2)
				{
					num4 = Employees[0].GetSpecialization(r, item.Key, Employees[0].MyActor);
					item.Value.ForceNum = num4 - 1;
				}
				else if (Employees.Length == 1)
				{
					item.Value.ForceNum = Employees[0].GetSpecialization(r, item.Key) - 1;
				}
				else
				{
					item.Value.ForceNum = null;
				}
				for (int num5 = 0; num5 < 3; num5++)
				{
					if (SkillOverride != null || Customization || flag2)
					{
						item.Value.Numbers[num5] = ((num5 - num4 < num3) ? (-99) : 0);
						continue;
					}
					item.Value.Numbers[num5] = 0;
					if (Employees.Length > 1)
					{
						for (int num6 = 0; num6 < Employees.Length; num6++)
						{
							if (Employees[num6].GetSpecialization(r, item.Key) == num5 + 1)
							{
								item.Value.Numbers[num5]++;
							}
						}
					}
					else
					{
						if (!flag)
						{
							continue;
						}
						List<Actor> employeesDirect = CompareTeam.GetEmployeesDirect();
						for (int num7 = 0; num7 < employeesDirect.Count; num7++)
						{
							if (employeesDirect[num7].employee.GetSpecialization(r, item.Key) == num5 + 1)
							{
								item.Value.Numbers[num5]++;
							}
						}
					}
				}
				item.Value.SetVerticesDirty();
			}
		}
		if (flag2 || Customization || Employees.Length != 1)
		{
			return;
		}
		Employee employee = Employees[0];
		if (!(employee.MyActor != null))
		{
			return;
		}
		for (int num8 = 0; num8 < employee.MyActor.Courses.Count; num8++)
		{
			KeyValuePair<Employee.EmployeeRole, string> keyValuePair = employee.MyActor.Courses[num8];
			int num9 = Array.IndexOf(Roles[num2], keyValuePair.Key);
			if (num9 < 0)
			{
				continue;
			}
			StarCounter orDefault = SpecBars[num9].GetOrDefault(keyValuePair.Value);
			if (orDefault != null)
			{
				int num10;
				for (num10 = employee.GetSpecialization(keyValuePair.Key, keyValuePair.Value); num10 >= 0 && num10 < orDefault.Numbers.Length && orDefault.Numbers[num10] == -99; num10++)
				{
				}
				if (num10 >= 0 && num10 < orDefault.Numbers.Length)
				{
					orDefault.Numbers[num10] = -99;
				}
			}
		}
	}

	private void GetAverageAndMax(Employee[] emps, Employee.EmployeeRole role, string spec, bool baseSkill, float minSkill, out float maxVal, out float avgVal)
	{
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		float num4 = 0f;
		int num5 = 0;
		foreach (Employee employee in emps)
		{
			if (ForceAllRoles || emps.Length <= 1 || employee.IsRole(role))
			{
				float num6 = (baseSkill ? employee.GetSkill(role) : ((float)GetSpec(employee, role, spec)));
				num = Mathf.Max(num, num6);
				if (!ForceAllRoles && emps.Length > 1 && !baseSkill && num6 < minSkill)
				{
					num4 += num6;
					num5++;
				}
				else
				{
					num2 += num6;
					num3++;
				}
			}
		}
		if (num3 == 0)
		{
			num2 = num4;
			num3 = num5;
		}
		maxVal = num;
		avgVal = num2 / (float)Mathf.Max(1, num3);
	}

	private int GetSpec(Employee emp, Employee.EmployeeRole role, string spec)
	{
		return emp.GetSpecialization(role, spec);
	}
}
