using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class Case
{
	public enum CaseStatus
	{
		handInNotCollected = 0,
		handInCollected = 1,
		submitted = 2,
		closable = 3,
		archived = 4,
		forced = 5
	}

	public enum CaseType
	{
		mainStory = 0,
		murder = 1,
		sideJob = 2,
		custom = 3,
		retirement = 4
	}

	public enum CaseRank
	{
		super = 0,
		A = 1,
		B = 2,
		C = 3,
		D = 4,
		unSolved = 5
	}

	[Serializable]
	public class CaseElement
	{
		public int caseID;

		public string n;

		public string id;

		public List<Evidence.DataKey> dk;

		public Vector2 v;

		public List<Evidence.DataKey> sdk;

		public bool ap;

		public bool w;

		public Vector3 resPos;

		public Vector2 resPiv;

		public bool co;

		public bool m;

		public InterfaceControls.EvidenceColours color;

		[NonSerialized]
		public PinnedItemController pinnedController;

		public void SetColour(InterfaceControls.EvidenceColours newColour)
		{
		}
	}

	[Serializable]
	public class StringColours
	{
		public string fromEv;

		public List<string> toEv;

		public List<Evidence.DataKey> fromDK;

		public List<Evidence.DataKey> toDK;

		public int colIndex;
	}

	[Serializable]
	public class ResolveQuestion
	{
		public delegate void ProgressChange(ResolveQuestion resolve);

		[HorizontalLine(2f, EColor.Gray)]
		[Header("Setup")]
		public string name;

		public bool displayObjective;

		[EnableIf("displayObjective")]
		public bool displayOnlyAtPhase;

		[EnableIf("displayOnlyAtPhase")]
		public int displayAtPhase;

		public float objectiveDelay;

		public List<SideMissionIntroPreset> onlyCompatibleWithIntros;

		public List<SideMissionHandInPreset> onlyCompatibleWithHandIns;

		public InputType inputType;

		[Tooltip("A list of automatically set answers")]
		public List<AutoCorrectAnswer> automaticAnswers;

		public JobPreset.JobTag tag;

		public InterfaceControls.Icon icon;

		public Vector2 rewardRange;

		public Vector2 penaltyRange;

		public bool isOptional;

		[Header("Revenge Objective")]
		[HorizontalLine(2f, EColor.Gray)]
		public bool useAlternateName;

		public RevengeObjectiveName useName;

		public JobPreset.LeadCitizen target;

		public JobPreset.JobSpawnWhere location;

		[ReadOnly]
		public string revengeObjective;

		[ReadOnly]
		public int revengeObjTarget;

		[ReadOnly]
		public int revengeObjLoc;

		[ReadOnly]
		public float revengeObjPassed;

		[ReadOnly]
		public bool completedRevenge;

		[Header("Inputted")]
		[ReadOnly]
		public string input;

		[ReadOnly]
		public string inputtedEvidence;

		[ReadOnly]
		[Header("State")]
		public List<string> correctAnswers;

		[ReadOnly]
		public float progress;

		[ReadOnly]
		public int reward;

		[ReadOnly]
		public int penalty;

		[ReadOnly]
		public bool isValid;

		[ReadOnly]
		public bool isCorrect;

		[NonSerialized]
		public InputFieldController inputField;

		public event ProgressChange OnProgressChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public bool UpdateCorrect(Case forCase, bool isMainStory = true)
		{
			return false;
		}

		public bool UpdateValid(Case forCase)
		{
			return false;
		}

		private bool SaveVictimCheck()
		{
			return false;
		}

		public string GetText(Case belongsToCase, bool includeReward = true, bool includePenalty = true)
		{
			return null;
		}

		public RevengeObjective GetRevengeObjective()
		{
			return null;
		}

		public void SetProgress(float val, bool forceTrigger = false)
		{
		}
	}

	public enum RevengeObjectiveName
	{
		D0 = 0,
		D1 = 1,
		IDTarget = 2
	}

	public enum AutoCorrectAnswer
	{
		none = 0,
		poster = 1,
		purp = 2,
		purpsParamour = 3,
		posterHome = 4,
		purpHome = 5,
		purpsParamourHome = 6,
		posterWork = 7,
		purpWork = 8,
		purpsParamourWork = 9,
		posterPhoto = 10,
		purpPhoto = 11,
		purpsParamourPhoto = 12,
		posterHomePhoto = 13,
		purpHomePhoto = 14,
		purpsParamourHomePhoto = 15,
		posterWorkPhoto = 16,
		purpWorkPhoto = 17,
		purpsParamourWorkPhoto = 18,
		spawnedItemA = 19,
		spawnedItemB = 20,
		spawnedItemC = 21,
		spawnedItemD = 22,
		spawnedItemE = 23,
		spawnedItemF = 24,
		spawnedItemTag = 25
	}

	public enum InputType
	{
		citizen = 0,
		location = 1,
		item = 2,
		revengeObjective = 3,
		objective = 4,
		arrestPurp = 5,
		saveVictim = 6
	}

	[Header("Serializable")]
	public string name;

	public int id;

	public static int assignCaseID;

	public CaseType caseType;

	public CaseStatus caseStatus;

	public int jobReference;

	public string mainStoryChapter;

	public List<CaseElement> caseElements;

	public List<StringColours> stringColours;

	public List<string> hiddenConnections;

	public bool isActive;

	public bool handInValid;

	public bool isSolved;

	public float questionsRank;

	public float victimsRank;

	public CaseRank rank;

	public List<Objective> currentActiveObjectives;

	public List<Objective> inactiveCurrentObjectives;

	public List<Objective> endedObjectives;

	public List<ResolveQuestion> resolveQuestions;

	public List<int> suspectsDetained;

	public List<int> handIn;

	[NonSerialized]
	public List<Objective> waitForObjectives;

	[NonSerialized]
	public SideJob job;

	public void AddNewStringColour(Evidence.FactLink link, InterfaceControls.EvidenceColours col)
	{
	}

	public void SetHidden(Fact fact, bool val)
	{
	}

	public void ToggleHidden(Fact fact)
	{
	}

	public void SetStatus(CaseStatus newStatus, bool cancelObjectives = true)
	{
	}

	public void ApplyMonikerToCaseCheck()
	{
	}

	public NewGameLocation GetGameLocationFromQuestionInput(ResolveQuestion question)
	{
		return null;
	}

	public Human GetCitizenFromQuestionInput(ResolveQuestion question)
	{
		return null;
	}

	public void OnQuestionProgressChange(ResolveQuestion question)
	{
	}

	public void Resolve()
	{
	}

	public bool ValidationCheck()
	{
		return false;
	}

	public virtual void AddObjective(string entryRef, Objective.ObjectiveTrigger trigger, bool usePointer = false, Vector3 pointerPosition = default(Vector3), InterfaceControls.Icon useIcon = InterfaceControls.Icon.lookingGlass, Objective.OnCompleteAction onCompleteAction = Objective.OnCompleteAction.nextChapterPart, float delay = 0f, bool removePrevious = false, string chapterString = "", bool isSilent = false, bool allowCrouchPromt = false, SideJob jobRef = null, bool forceBottomOfList = false, bool ignoreDuplicates = false, bool useParsing = true)
	{
	}

	public Case(string newName, CaseType newCaseType, CaseStatus newCaseStatus)
	{
	}

	public Interactable GetClosestHandIn()
	{
		return null;
	}

	public void ClearAllObjectives()
	{
	}
}
