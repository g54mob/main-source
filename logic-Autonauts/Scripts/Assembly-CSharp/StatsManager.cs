using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
	public enum Stat
	{
		TreesCut = 0,
		TreesCutRate = 1,
		Stones = 2,
		Clay = 3,
		Iron = 4,
		Sand = 5,
		Water = 6,
		Buildings = 7,
		Flooring = 8,
		Walls = 9,
		TimePlayed = 10,
		RealTimePlayed = 11,
		Total = 12
	}

	public enum StatEvent
	{
		TreeCut = 0,
		Stones = 1,
		Clay = 2,
		Iron = 3,
		Sand = 4,
		Water = 5,
		Buildings = 6,
		Flooring = 7,
		Walls = 8,
		Total = 9
	}

	public static StatsManager Instance;

	public List<StatValues> m_Values;

	private void Awake()
	{
		Instance = this;
		m_Values = new List<StatValues>();
		m_Values.Add(new StatValuesCount(Stat.TreesCut));
		m_Values.Add(new StatValuesRate(Stat.TreesCutRate));
		m_Values.Add(new StatValuesCount(Stat.Stones));
		m_Values.Add(new StatValuesCount(Stat.Clay));
		m_Values.Add(new StatValuesCount(Stat.Iron));
		m_Values.Add(new StatValuesCount(Stat.Sand));
		m_Values.Add(new StatValuesCount(Stat.Water));
		m_Values.Add(new StatValuesCount(Stat.Buildings));
		m_Values.Add(new StatValuesCount(Stat.Flooring));
		m_Values.Add(new StatValuesCount(Stat.Walls));
		m_Values.Add(new StatValuesTime(Stat.TimePlayed));
		m_Values.Add(new StatValuesTime(Stat.RealTimePlayed));
	}

	public string GetStatTitle(Stat NewStat)
	{
		return TextManager.Instance.Get("Stat" + NewStat);
	}

	private Stat GetStatFromName(string Name)
	{
		for (int i = 0; i < 12; i++)
		{
			if (Name == GetStatTitle((Stat)i))
			{
				return (Stat)i;
			}
		}
		return Stat.Total;
	}

	public void Save(JSONNode Node)
	{
		JSONArray jSONArray = (JSONArray)(Node["Values"] = new JSONArray());
		for (int i = 0; i < 12; i++)
		{
			JSONNode jSONNode2 = new JSONObject();
			JSONUtils.Set(jSONNode2, "Name", GetStatTitle((Stat)i));
			m_Values[i].Save(jSONNode2);
			jSONArray[i] = jSONNode2;
		}
	}

	public void Load(JSONNode Node)
	{
		JSONArray asArray = Node["Values"].AsArray;
		if (!(asArray != null) || asArray.IsNull)
		{
			return;
		}
		for (int i = 0; i < asArray.Count; i++)
		{
			JSONNode node = asArray[i];
			string asString = JSONUtils.GetAsString(node, "Name", "");
			Stat statFromName = GetStatFromName(asString);
			if (statFromName != Stat.Total)
			{
				m_Values[(int)statFromName].Load(node);
			}
		}
	}

	public void AddEvent(StatEvent NewEvent)
	{
		if (NewEvent == StatEvent.TreeCut)
		{
			m_Values[0].Add();
		}
		if (NewEvent == StatEvent.Stones)
		{
			m_Values[2].Add();
		}
		if (NewEvent == StatEvent.Clay)
		{
			m_Values[3].Add();
		}
		if (NewEvent == StatEvent.Iron)
		{
			m_Values[4].Add();
		}
		if (NewEvent == StatEvent.Sand)
		{
			m_Values[5].Add();
		}
		if (NewEvent == StatEvent.Water)
		{
			m_Values[6].Add();
		}
		if (NewEvent == StatEvent.Buildings)
		{
			m_Values[7].Add();
		}
		if (NewEvent == StatEvent.Flooring)
		{
			m_Values[8].Add();
		}
		if (NewEvent == StatEvent.Walls)
		{
			m_Values[9].Add();
		}
		if (NewEvent == StatEvent.TreeCut)
		{
			m_Values[1].Add();
		}
	}

	public string GetStat(Stat NewStat)
	{
		return m_Values[(int)NewStat].GetAsString();
	}

	private void Update()
	{
		((StatValuesTime)m_Values[10]).SetTime((int)TimeManager.Instance.m_TotalTime);
		((StatValuesTime)m_Values[11]).SetTime((int)TimeManager.Instance.m_TotalRealTime);
		foreach (StatValues value in m_Values)
		{
			value.Update();
		}
	}
}
