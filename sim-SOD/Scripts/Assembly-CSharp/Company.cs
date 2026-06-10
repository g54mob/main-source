using System;
using System.Collections.Generic;
using UnityEngine;

public class Company
{
	[Serializable]
	public class SalesRecord
	{
		public int companyID;

		public int punterID;

		public List<string> items;

		public float time;

		public float cost;

		public int difficulty;

		[NonSerialized]
		public Fact fact;

		public SalesRecord(Company newCompany, Human newPunter, InteractablePreset newItem, float newTime)
		{
		}

		public SalesRecord(Company newCompany, Human newPunter, List<InteractablePreset> newItem, float newTime)
		{
		}

		public Company GetCompany()
		{
			return null;
		}

		public Human GetPunter()
		{
			return null;
		}

		public void SpawnFact()
		{
		}
	}

	public string name;

	public string seed;

	[Header("Location")]
	public NewAddress address;

	public NewGameLocation placeOfBusiness;

	[Header("Details")]
	public int companyID;

	public static int assignCompanyID;

	public string shortName;

	public List<string> nameAltTags;

	public int numberOfRankLevels;

	public int numberOfJobPositions;

	[NonSerialized]
	public CompanyPreset preset;

	public List<CompanyOpenHoursPreset.CompanyShift> shifts;

	public List<Occupation> companyRoster;

	public float topSalary;

	public float minimumSalary;

	public Human director;

	public Human receptionist;

	public Human janitor;

	public Human security;

	public bool publicFacing;

	public Color uniformColour;

	[NonSerialized]
	public int passedWorkLocationID;

	[NonSerialized]
	public Interactable passedWorkPosition;

	[Header("Opening Hours")]
	public bool monday;

	public bool tuesday;

	public bool wednesday;

	public bool thursday;

	public bool friday;

	public bool saturday;

	public bool sunday;

	public List<SessionData.WeekDay> daysOpen;

	public List<SessionData.WeekDay> daysClosed;

	public Vector2 retailOpenHours;

	public bool openForBusinessDesired;

	public bool openForBusinessActual;

	public List<Occupation> currentStaff;

	[NonSerialized]
	public EvidenceMultiPage employeeRoster;

	[NonSerialized]
	public Evidence menu;

	[NonSerialized]
	public Evidence salesRecords;

	private bool createdEvidence;

	[Header("Sales")]
	public Dictionary<InteractablePreset, int> prices;

	public List<SalesRecord> sales;

	public Dictionary<RetailItemPreset, Evidence> itemSingletons;

	public List<string> debugAddressSet;

	public string debugLastOpenedAt;

	public string debugLastClosedAt;

	public void Setup(CompanyPreset newPreset, NewAddress newAddress)
	{
	}

	public int GetOpenHoursCoverageCountForShift(CompanyOpenHoursPreset.CompanyShift sft)
	{
		return 0;
	}

	public void SetAddress(NewAddress newAdd)
	{
	}

	public void SetPlaceOfBusiness(NewGameLocation newLoc)
	{
	}

	public void Load(CitySaveData.CompanyCitySave data, NewAddress newAddress)
	{
	}

	public void GenerateFakeSalesRecords()
	{
	}

	public void UpdateName()
	{
	}

	public bool IsOpenAtThisTime(float atTime)
	{
		return false;
	}

	public bool IsOpenAtThisTime(float atTime, float decimalHour, SessionData.WeekDay day)
	{
		return false;
	}

	public bool IsOpenAtDecimalTime(SessionData.WeekDay day, float hour)
	{
		return false;
	}

	public void CreateEvidence()
	{
	}

	public void CreateItemSingletons()
	{
	}

	public void SetupEvidence()
	{
	}

	public void OpenCloseCheck()
	{
	}

	public void SetOpen(bool openClosed, bool forceActual = false)
	{
	}

	public void OnAddressCitizenEnter(Citizen cc)
	{
	}

	public void OnAddressCitizenExit(Citizen cc)
	{
	}

	public int GetNumberOfFilledJobs()
	{
		return 0;
	}

	public void OnActualOpen()
	{
	}

	public void OnActualClose()
	{
	}

	public void AddSalesRecord(Human who, InteractablePreset what, float time)
	{
	}

	public void AddSalesRecord(Human who, List<InteractablePreset> what, float time)
	{
	}

	public CitySaveData.CompanyCitySave GenerateSaveData()
	{
		return null;
	}

	public void UpdatePassedWorkPosition()
	{
	}

	public void UpdateOpenHoursBasedOnStaff()
	{
	}
}
