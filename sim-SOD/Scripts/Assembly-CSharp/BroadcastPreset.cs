using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "broadcast_data", menuName = "Database/Broadcast Preset")]
public class BroadcastPreset : SoCustomComparison
{
	public enum ImageOrder
	{
		random = 0,
		ordered = 1
	}

	public enum EndOfShow
	{
		atEndOfAudioEvent = 0,
		onEndOfDynamicClips = 1
	}

	[Serializable]
	public class DynamicClip
	{
		public string name;

		[Range(0f, 1f)]
		public float chance;

		public List<DynamicClipEvent> possibleEvents;

		public float followingDelay;

		[Space(3f)]
		public FollowingIndexMode nextMode;

		public int nextIndex;

		public FollowingIndexMode onFailToGetEvent;

		public int onFailIndex;
	}

	[Serializable]
	public class DynamicClipEvent
	{
		public string name;

		[Space(3f)]
		[InfoBox("This clip group will only be valid if the following conditions are met. If none then it will always be valid.", EInfoBoxType.Normal)]
		public ConditionMode conditionMode;

		public List<DynamicShowCondition> OrConditions;

		[Space(3f)]
		[InfoBox("A list of possible audio events; one will be chosen at random if this clip group is played in the broadcast.", EInfoBoxType.Normal)]
		public List<AudioEvent> audioEvents;

		[Space(3f)]
		[InfoBox("If chosen, the following parameters are applied to the game.", EInfoBoxType.Normal)]
		public List<DynamicShowParam> applyParameters;

		[InfoBox("Will override the crowd noise param for the DURATION of the clip", EInfoBoxType.Normal)]
		[Space(3f)]
		public bool overrideCrowdNoiseParam;

		[EnableIf("overrideCrowdNoiseParam")]
		public float crowdLayerVolume;

		[InfoBox("Will trigger this crowd reaction at the START of the clip", EInfoBoxType.Normal)]
		public CrowdReaction triggerCrowdReaction;
	}

	[Serializable]
	public class DynamicShowCondition
	{
		public DynamicConditionType condition;

		public List<DynamicShowParam> parametersList;
	}

	public enum DynamicConditionType
	{
		IfParamIsPresent = 0,
		IfParamEquals = 1,
		IfParamDoesntEqual = 2,
		team1TakesLeadWithCurrentScore = 3,
		team2TakesLeadWithCurrentScore = 4,
		isDraw = 5,
		team1Wins = 6,
		team2Wins = 7
	}

	[Serializable]
	public class DynamicShowParam
	{
		public ShowParamType paramType;

		public ParamApplicationMode applicationMode;

		public float value;

		public DynamicShowParam(ShowParamType newParameter, float newValue)
		{
		}
	}

	public enum ShowParamType
	{
		team1 = 0,
		team2 = 1,
		scoreTeam1 = 2,
		scoreTeam2 = 3,
		playersTeamOne1 = 4,
		playersTeamTwo1 = 5,
		playersTeamOne2 = 6,
		playersTeamTwo2 = 7,
		playersTeamOne3 = 8,
		playersTeamTwo3 = 9,
		playerNameInterjection = 10,
		lastPlay = 11,
		currentBalls = 12,
		playersPlayed = 13,
		currentScore = 14,
		currentTeam = 15,
		innings = 16
	}

	public enum ConditionMode
	{
		OR = 0,
		AND = 1
	}

	public enum CrowdReaction
	{
		none = 0,
		cheerSmall = 1,
		cheerMedium = 2,
		cheerLarge = 3,
		boo = 4,
		nearMiss = 5
	}

	public enum ParamApplicationMode
	{
		set = 0,
		add = 1
	}

	public enum FollowingIndexMode
	{
		next = 0,
		goToIndex = 1
	}

	[Header("Contents")]
	public AudioEvent audioEvent;

	[Tooltip("Change image every x seconds (real time)")]
	public float changeImageEvery;

	[Tooltip("What order these images display in")]
	public ImageOrder order;

	public EndOfShow endOfShowTrigger;

	[ShowAssetPreview(64, 64)]
	[Header("Atlas")]
	public Texture2D spriteSheet;

	public Vector2 spriteResolution;

	public int indexWidth;

	public int indexHeight;

	public int totalSpriteCount;

	[Header("Dynamic Sounds")]
	public bool useDynamicClips;

	[EnableIf("useDynamicClips")]
	public List<DynamicClip> dynamicClips;
}
