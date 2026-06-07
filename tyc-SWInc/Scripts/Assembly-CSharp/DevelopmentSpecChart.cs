using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevelopmentSpecChart : MonoBehaviour
{
	public StarCounter StarCountPrefab;

	public Text TextPrefab;

	public RectTransform ContentPanel;

	[NonSerialized]
	private List<Text> _labelPool = new List<Text>();

	[NonSerialized]
	private List<StarCounter> _starPool = new List<StarCounter>();

	[NonSerialized]
	private Dictionary<string, ValueTuple<Text, StarCounter[]>> _counters = new Dictionary<string, ValueTuple<Text, StarCounter[]>>();

	public StarCounter GetCounter()
	{
		StarCounter starCounter;
		if (_starPool.Count > 0)
		{
			starCounter = _starPool[_starPool.Count - 1];
			starCounter.gameObject.SetActive(true);
			_starPool.RemoveAt(_starPool.Count - 1);
		}
		else
		{
			starCounter = UnityEngine.Object.Instantiate(StarCountPrefab);
			starCounter.transform.SetParent(ContentPanel, false);
		}
		starCounter.ForceNum = -1;
		starCounter.Numbers = new int[3];
		return starCounter;
	}

	public Text GetLabel(string value)
	{
		Text text;
		if (_labelPool.Count > 0)
		{
			text = _labelPool[_labelPool.Count - 1];
			text.gameObject.SetActive(true);
			_labelPool.RemoveAt(_labelPool.Count - 1);
		}
		else
		{
			text = UnityEngine.Object.Instantiate(TextPrefab);
			text.transform.SetParent(ContentPanel, false);
		}
		text.text = value;
		return text;
	}

	public ValueTuple<Text, StarCounter[]> GetCounters(string spec)
	{
		ValueTuple<Text, StarCounter[]> value;
		if (_counters.TryGetValue(spec, out value))
		{
			return value;
		}
		ValueTuple<Text, StarCounter[]> result = (_counters[spec] = new ValueTuple<Text, StarCounter[]>(GetLabel(spec.Loc()), new StarCounter[3]
		{
			GetCounter(),
			GetCounter(),
			GetCounter()
		}));
		return result;
	}

	private int RoleToIndex(Employee.EmployeeRole r)
	{
		switch (r)
		{
		case Employee.EmployeeRole.Programmer:
			return 1;
		case Employee.EmployeeRole.Designer:
			return 0;
		case Employee.EmployeeRole.Artist:
			return 2;
		default:
			throw new ArgumentOutOfRangeException("r", r, null);
		}
	}

	public void CountEmployee(Actor a, Employee.EmployeeRole r)
	{
		if (!a.employee.IsRole(r, a.SecondaryWork))
		{
			return;
		}
		foreach (KeyValuePair<string, ValueTuple<Text, StarCounter[]>> counter in _counters)
		{
			int specialization = a.employee.GetSpecialization(r, counter.Key);
			if (specialization > 0)
			{
				StarCounter starCounter = counter.Value.Item2[RoleToIndex(r)];
				if (specialization > starCounter.ForceNum.Value)
				{
					starCounter.ActiveColor = SpecializationChart.GetSkillColor(r);
				}
				starCounter.Numbers[Mathf.Clamp(specialization - 1, 0, starCounter.Numbers.Length - 1)]++;
			}
		}
	}

	public void Refresh(IList<SoftwareWorkItem.FeatureProgress> prog, IList<Team> teams, bool design)
	{
		foreach (KeyValuePair<string, ValueTuple<Text, StarCounter[]>> counter in _counters)
		{
			counter.Value.Item1.gameObject.SetActive(false);
			_labelPool.Add(counter.Value.Item1);
			StarCounter[] item = counter.Value.Item2;
			foreach (StarCounter starCounter in item)
			{
				_starPool.Add(starCounter);
				starCounter.gameObject.SetActive(false);
			}
		}
		_counters.Clear();
		int num = 1;
		foreach (SoftwareWorkItem.FeatureProgress item2 in prog)
		{
			int level = item2.Feature.Level;
			if (level <= 0)
			{
				continue;
			}
			if (design)
			{
				if (item2.CodeDone)
				{
					continue;
				}
			}
			else if ((item2.Feature.CodeArtRatio == 0f || item2.CodeDone) && (item2.Feature.CodeArtRatio == 1f || item2.ArtDone))
			{
				continue;
			}
			string spec = item2.Feature.Spec;
			ValueTuple<Text, StarCounter[]> counters = GetCounters(spec);
			counters.Item2[0].ActiveColor = Color.red;
			counters.Item2[1].ActiveColor = Color.red;
			counters.Item2[2].ActiveColor = Color.red;
			if (design)
			{
				counters.Item2[0].ForceNum = Mathf.Max(level - 1, counters.Item2[0].ForceNum.Value);
			}
			else
			{
				if (item2.Feature.CodeArtRatio > 0f)
				{
					counters.Item2[1].ForceNum = Mathf.Max(level - 1, counters.Item2[1].ForceNum.Value);
				}
				if (item2.Feature.CodeArtRatio < 1f)
				{
					counters.Item2[2].ForceNum = Mathf.Max(level - 1, counters.Item2[2].ForceNum.Value);
				}
			}
			counters.Item1.transform.SetSiblingIndex(num * 4);
			counters.Item2[0].transform.SetSiblingIndex(num * 4 + 1);
			counters.Item2[1].transform.SetSiblingIndex(num * 4 + 2);
			counters.Item2[2].transform.SetSiblingIndex(num * 4 + 3);
			num++;
		}
		for (int j = 0; j < teams.Count; j++)
		{
			List<Actor> employeesDirect = teams[j].GetEmployeesDirect();
			for (int k = 0; k < employeesDirect.Count; k++)
			{
				Actor a = employeesDirect[k];
				if (design)
				{
					CountEmployee(a, Employee.EmployeeRole.Designer);
					continue;
				}
				CountEmployee(a, Employee.EmployeeRole.Programmer);
				CountEmployee(a, Employee.EmployeeRole.Artist);
			}
		}
	}
}
