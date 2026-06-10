using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "group_data", menuName = "Database/Group Preset")]
public class GroupPreset : SoCustomComparison
{
	public enum GroupType
	{
		interestGroup = 0,
		couples = 1,
		cheaters = 2,
		work = 3
	}

	[Serializable]
	public class MeetUpVmailThread
	{
		public string name;

		public string treeID;

		public MeetUpVmailSender sender;

		public MeetUpVmailSender recevier;
	}

	[Serializable]
	public class ClubClue
	{
		public string name;

		public InteractablePreset preset;

		public SpawnAt spawnAt;
	}

	public enum SpawnAt
	{
		meetingPlace = 0,
		leadersApartment = 1,
		entireGroupsApartments = 2
	}

	public enum MeetUpVmailSender
	{
		groupLeader = 0,
		groupRandom = 1,
		meetupPlace = 2,
		entireGroup = 3,
		prioritiseFaithful = 4
	}

	[Header("Setup")]
	public GroupType groupType;

	[Tooltip("Chance of existance on a per instance basis.")]
	[Range(0f, 1f)]
	public float chance;

	[Tooltip("Minimum members")]
	public int minMembers;

	[Tooltip("Maximum members")]
	public int maxMembers;

	[Header("Requirements")]
	[Tooltip("Members must have these traits")]
	public List<CharacterTrait> requiredTraits;

	[Tooltip("Members must have this extraversion value")]
	[Range(0f, 1f)]
	public float minimumExtraversion;

	[Header("Meet Ups")]
	public bool enableMeetUps;

	[Tooltip("How many times a week this group meets")]
	[EnableIf("enableMeetUps")]
	public int daysPerWeek;

	[Tooltip("The time range for the meet up time. If set to something other that special interest, this is driven by when both are free (after work etc).")]
	[EnableIf("enableMeetUps")]
	public Vector2 timeRange;

	[Tooltip("Meet up length")]
	public float meetUpLength;

	[Tooltip("Possible meeting place address types")]
	[EnableIf("enableMeetUps")]
	public List<CompanyPreset> meetUpLocations;

	[EnableIf("enableMeetUps")]
	[Tooltip("Meet up goal")]
	public AIGoalPreset meetUpGoal;

	[Tooltip("The first person will reserve up to 4 seats on arrival...")]
	[EnableIf("enableMeetUps")]
	public bool reserveSeats;

	[Tooltip("Add this distance multiplier when choosing a seat")]
	public float useDistanceMultiplierModifier;

	[Header("Evidence")]
	[ReorderableList]
	public List<ClubClue> clues;

	[ReorderableList]
	[Header("Vmails")]
	public List<MeetUpVmailThread> vmails;
}
