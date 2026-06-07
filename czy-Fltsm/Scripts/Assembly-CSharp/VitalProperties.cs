using System;
using System.Collections.Generic;
using PajamaLlama.Procedural;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Vitals Properties")]
public class VitalProperties : ScriptableObject
{
	[Serializable]
	private struct Pollution
	{
		public PollutionLevels PollutionLevel;

		public float PollutionPerDay;
	}

	[Header("Hunger / Thirst")]
	public int HungerLimit = 4;

	public int ThirstLimit = 4;

	[Header("Notifications")]
	[Tooltip("The notification properties if the agent died of unspecified causes.")]
	public NotificationProperties DefaultDeathNotification;

	[Tooltip("The notification properties if the agent died of hunger.")]
	public NotificationProperties DiedOfHungerNotification;

	[Tooltip("The notification properties if the agent died of thirst.")]
	public NotificationProperties DiedOfThirstNotification;

	[Header("Assignments")]
	[Tooltip("Assignment types that this agent can't handle.")]
	public List<AssignmentType> AssignmentTypes;

	[Header("Pollution")]
	public int PollutionMaximum = 10;

	[Tooltip("Pollution level the drifter's pollution goes to after reaching the pollution maximum.")]
	public int PollutionReturn = 5;

	public Disease[] Diseases = new Disease[0];

	[SerializeField]
	private Pollution[] SwimmingPollution;

	[Header("Diets")]
	public TaggedItemPropertiesRandomizer FavouriteFoods;

	public void Initialize()
	{
		FavouriteFoods.Initialize();
	}

	public float ReturnSwimmingPollutionPerSecond()
	{
		PollutionLevels pollutionLevel = GameManager.WorldManager.CurrentRegion.PollutionLevel;
		float daytimeLength = GameManager.TimeManager.CurrentDay.DaytimeLength;
		float result = 0f;
		Pollution[] swimmingPollution = SwimmingPollution;
		for (int i = 0; i < swimmingPollution.Length; i++)
		{
			Pollution pollution = swimmingPollution[i];
			if (pollution.PollutionLevel <= pollutionLevel)
			{
				result = pollution.PollutionPerDay / daytimeLength;
			}
		}
		return result;
	}
}
