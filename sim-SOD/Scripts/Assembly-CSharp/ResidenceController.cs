using System;
using System.Collections.Generic;
using UnityEngine;

public class ResidenceController : Controller, IComparable<ResidenceController>
{
	public ResidencePreset preset;

	[Header("Location")]
	public NewBuilding building;

	public NewAddress address;

	public List<NewRoom> bedrooms;

	[NonSerialized]
	public int bedroomsTaken;

	[NonSerialized]
	public FurnitureLocation mailbox;

	public static Comparison<ResidenceController> RoommateComparison;

	public void Setup(ResidencePreset newPreset, NewAddress newAddress)
	{
	}

	public string GetResidenceString()
	{
		return null;
	}

	public int GetResidenceNumber()
	{
		return 0;
	}

	public void AddBedroom(NewRoom newBedroom)
	{
	}

	public void Load(CitySaveData.ResidenceCitySave data, NewAddress newAddress)
	{
	}

	public CitySaveData.ResidenceCitySave GenerateSaveData()
	{
		return null;
	}

	public override void CreateEvidence()
	{
	}

	public int CompareTo(ResidenceController other)
	{
		return 0;
	}
}
