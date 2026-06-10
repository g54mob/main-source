using System;
using System.Collections.Generic;

public class Occupation : IComparable<Occupation>
{
	public int id;

	[NonSerialized]
	public static int idAssign;

	public OccupationPreset preset;

	public string name;

	public Company employer;

	public bool isAgent;

	public bool teamLeader;

	public Occupation boss;

	public float paygrade;

	public int teamID;

	public bool isOwner;

	public OccupationPreset.workType work;

	public List<OccupationPreset.workTags> tags;

	public CompanyOpenHoursPreset.CompanyShift shift;

	public float workHours;

	public float startTimeDecimalHour;

	public float endTimeDecialHour;

	public bool lunchBreak;

	public float lunchBreakHoursAfterStart;

	[NonSerialized]
	public List<SessionData.WeekDay> workDaysList;

	public float salary;

	public string salaryString;

	public Human employee;

	public static Comparison<Occupation> SalaryComparison;

	public static Comparison<Occupation> FillPriorityComparison;

	public void Setup()
	{
	}

	public void Load(CitySaveData.OccupationCitySave data, Company newCompany)
	{
	}

	public bool IsAtWork(float atTime)
	{
		return false;
	}

	public CitySaveData.OccupationCitySave GenerateSaveData()
	{
		return null;
	}

	public string GetWorkingHoursString()
	{
		return null;
	}

	public int CompareTo(Occupation paygrade)
	{
		return 0;
	}
}
