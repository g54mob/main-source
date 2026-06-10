using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "musiccue_data", menuName = "Audio/Music Cue")]
public class MusicCue : SoCustomComparison
{
	public enum MusicTriggerGameState
	{
		any = 0,
		menu = 1,
		inGame = 2,
		inCutscene = 3
	}

	public enum MusicTriggerPlayerState
	{
		any = 0,
		safe = 1,
		trespass = 2,
		combat = 3,
		passingTime = 4
	}

	public enum MusicTriggerPlayerLocation
	{
		any = 0,
		outdoors = 1,
		indoors = 2,
		playersApartment = 3
	}

	public enum MusicTriggerEvent
	{
		none = 0,
		newMurderCase = 1,
		caseComplete = 2,
		caseFailed = 3,
		caseUnsolved = 4,
		socialCreditLevelUp = 5,
		resolveScreen = 6,
		arriveAtCrimeScene = 7,
		passingTime = 8
	}

	[Serializable]
	public class MusicTrigger
	{
		public MusicTriggerGameState onGameState;

		public CutScenePreset cutSceneReference;

		public MusicTriggerPlayerState onPlayerSate;

		public MusicTriggerPlayerLocation onPlayerLocation;

		[Space(7f)]
		public MusicTriggerEvent onEvent;

		[Range(0f, 1f)]
		public float eventTriggerChance;

		public bool triggerOnlyOnEvents;

		[Tooltip("If true this will be triggered regardless of the time between tracks")]
		[Space(7f)]
		public bool ignoreSilentTimeBetweenTracks;

		[Space(7f)]
		public bool onlyInDistricts;

		[EnableIf("onlyInDistricts")]
		public List<DistrictPreset> compatibleDistricts;

		public bool excludeDistricts;

		[EnableIf("excludeDistricts")]
		public List<DistrictPreset> excludedDistricts;

		[Space(7f)]
		public bool onlyInBuildings;

		[EnableIf("onlyInBuildings")]
		public List<BuildingPreset> compatibleBuildings;

		public bool excludeBuildings;

		[EnableIf("excludeBuildings")]
		public List<BuildingPreset> excludedBuildings;

		[Space(7f)]
		public bool onlyInLocations;

		[EnableIf("onlyInLocations")]
		public List<AddressPreset> compatibleAddressTypes;

		public bool excludeLocations;

		[EnableIf("excludeLocations")]
		public List<AddressPreset> excludedAddressTypes;

		[Space(7f)]
		public bool onlyDuringStatuses;

		[EnableIf("onlyDuringStatuses")]
		public List<StatusPreset> compatibleStatuses;

		public bool excludeStatuses;

		[EnableIf("excludeStatuses")]
		public List<StatusPreset> excludedStatuses;

		[Space(7f)]
		public bool useDecorGrimeRange;

		[MinMaxSlider(0f, 1f)]
		public Vector2 grimeRange;

		[InfoBox("Play on these floor ranges, if empty then it will play on any floor", EInfoBoxType.Normal)]
		[Space(7f)]
		public List<Vector2> floorRanges;

		[InfoBox("Play at this time (24hr clock so 0 = midnight, 12 = mid day etc). If empty then it will play at any time", EInfoBoxType.Normal)]
		public List<Vector2> timeRanges;
	}

	[Header("Setup")]
	public string fmodGUID;

	public bool disabled;

	public bool debug;

	[Header("Track Settings")]
	[Tooltip("If true, only play this track once per game")]
	public bool playOnce;

	[Tooltip("If true then when it's appropraite to play this ambient, it will stop a previously playing one.")]
	public bool interrupt;

	[Tooltip("If true then this track will stop when the ambient state is switched to something that's not compatible")]
	public bool stopOnIncompatibleStateSwitch;

	[Tooltip("If true this track will avoid repetition as much as possible by playing other tracks of the same priority when available")]
	public bool avoidRepetition;

	[Range(0f, 4f)]
	[Tooltip("The game will choose between the highest available priority tracks. Higher plays first.")]
	public int ambientPriority;

	public List<MusicTrigger> triggers;
}
