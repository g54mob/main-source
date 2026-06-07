using System;
using System.Collections.Generic;
using UnityEngine;

public class Schematic
{
	public const string NameStr = "Name";

	public const string DescriptionStr = "Description";

	private readonly List<BodySchematic> bodySchematics;

	public GameObject Prefab { get; set; }

	public string Id { get; set; }

	public MaterialSchematic MaterialSchematic { get; set; }

	public string FolderPath { get; set; }

	public string HashSHA256 { get; set; }

	public Properties Infos { private get; set; }

	public Properties Properties { private get; set; }

	public string Name => Infos.GetProperty("Name");

	public string Description => Infos.GetProperty("Description");

	public string Type => Properties.GetProperty("Type", "structural");

	public string MaterialId => Properties.GetProperty("MaterialId", "iron");

	public float Volume => Properties.GetPropertyAsFloat("Volume", 1f);

	public int Cost => Properties.GetPropertyAsInt("Cost", 5);

	public int Health => Properties.GetPropertyAsInt("Health", 50);

	public int ImpactAttack => Properties.GetPropertyAsInt("ImpactAttack", 5);

	public int ImpactResistence => Properties.GetPropertyAsInt("ImpactResistence", 5);

	public int PiercingAttack => Properties.GetPropertyAsInt("PiercingAttack", 1);

	public int PiercingResistence => Properties.GetPropertyAsInt("PiercingResistence", 5);

	public int LaserResistence => Properties.GetPropertyAsInt("LaserResistence");

	public int PrepoolingQuantity => Properties.GetPropertyAsInt("Prepooling");

	public bool IsUserMod { get; set; }

	public event Action OnInfosUpdatedEvent;

	public Schematic()
	{
		bodySchematics = new List<BodySchematic>();
		IsUserMod = false;
	}

	public void AddBodySchematic(BodySchematic bodySchematic)
	{
		bodySchematic.ParentSchematic = this;
		bodySchematic.Index = bodySchematics.Count;
		bodySchematics.Add(bodySchematic);
	}

	public BodySchematic GetBodySchematic(int index)
	{
		return bodySchematics[index];
	}

	public ICollection<BodySchematic> GetAllBodySchematics()
	{
		return bodySchematics;
	}

	public int BodySchematicsCount()
	{
		return bodySchematics.Count;
	}

	public void UpdateInfos(string name, string description)
	{
		Infos.SetProperty("Name", name);
		Infos.SetProperty("Description", description);
		if (this.OnInfosUpdatedEvent != null)
		{
			this.OnInfosUpdatedEvent();
		}
	}
}
