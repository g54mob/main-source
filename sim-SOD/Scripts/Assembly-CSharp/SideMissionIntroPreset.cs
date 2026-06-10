using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sidejobintro_data", menuName = "Database/Side Job Intro Preset")]
public class SideMissionIntroPreset : SoCustomComparison
{
	public enum SideMissionElementType
	{
		playerCallsNumber = 0,
		acquireInformation = 1,
		askStaff = 2,
		spawnItems = 3,
		photoOfItemLocation = 4,
		openedBriefcase = 5,
		postSubmission = 6,
		playerHasCamera = 7,
		setGooseChaseCall = 8,
		setMeeting = 9,
		handDossier = 10,
		setupHomeInvestigation = 11,
		submitToPoster = 12,
		setHomeMeeting = 13,
		setGooseChaseCallIndoorOnly = 14,
		tailBriefcase = 15,
		playerHasItemInPossession = 16,
		leaveItemAtSecretLocation = 17,
		destroyItem = 18,
		playerHasHandcuffs = 19,
		telephoneSubmission = 20,
		placeItemInPosterMailbox = 21,
		placeItemOfTypeInPosterMailbox = 22
	}

	[Serializable]
	public class SideMissionObjectiveBlock
	{
		public string name;

		public SideMissionElementType elementType;

		public string dialogReference;

		public JobPreset.JobTag tagReference;

		public List<JobPreset.StartingSpawnItem> spawnItems;

		public bool enableUpdateWhileTalking;

		public float objectiveDelay;

		public List<InteractablePreset> validItems;

		public List<FurniturePreset> validFurniture;

		public List<JobPreset.DifficultyTag> disableOnDifficulties;

		public List<SideMissionIntroPreset> onlyCompativleWithIntros;

		public List<SideMissionHandInPreset> onlyCompatibleWithHandIns;

		public List<JobPreset.JobTag> triggerFailIfItemDestroyed;
	}

	[Header("Rewards")]
	public int rewardModifier;

	[Header("Elements")]
	public List<SideMissionObjectiveBlock> blocks;
}
