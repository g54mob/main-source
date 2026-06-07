using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class VitalsPersistentData
{
	public float Health;

	public int HungerAmount;

	public int ThirstAmount;

	[OptionalField(VersionAdded = 5)]
	public float PollutionAmountFloat;

	public List<ProjectPersistentData> Projects;

	[OptionalField(VersionAdded = 3)]
	public DiseasePersistentData CurrentDisease;

	[OptionalField(VersionAdded = 4)]
	public Diet.PD FoodDiet;

	public int ExhaustionAmount;

	[OptionalField(VersionAdded = 2)]
	public int PollutionAmount;

	public VitalsPersistentData(Vitals vitals)
	{
		HungerAmount = vitals.Hunger.Amount;
		ThirstAmount = vitals.Thirst.Amount;
		PollutionAmountFloat = vitals.Pollution.Level;
		Projects = new List<ProjectPersistentData>();
		foreach (Vital item in (IEnumerable<Vital>)vitals)
		{
			if (item.Project != null)
			{
				Projects.Add(new ProjectPersistentData(item.Project));
			}
		}
		if (vitals.Pollution.CurrentDisease != null)
		{
			CurrentDisease = new DiseasePersistentData(vitals.Pollution.CurrentDisease);
		}
		if (vitals.TryReturnDiet(VitalType.Hunger, out var diet))
		{
			diet.TryReturnPersistentData(out FoodDiet);
		}
	}

	public void Restore(Vitals vitals)
	{
		vitals.Hunger.Restore(HungerAmount, FoodDiet);
		vitals.Thirst.Restore(ThirstAmount);
		vitals.Pollution.Restore(PollutionAmountFloat);
		RestoreReferences(vitals);
		if (CurrentDisease != null)
		{
			vitals.Pollution.RestoreDisease(CurrentDisease);
		}
	}

	private void RestoreReferences(Vitals vitals)
	{
		if (Projects == null || 0 >= Projects.Count)
		{
			return;
		}
		foreach (ProjectPersistentData project2 in Projects)
		{
			if (project2.TryRestore(out var project, communityProject: false))
			{
				vitals.RestoreProject(project);
			}
		}
	}
}
