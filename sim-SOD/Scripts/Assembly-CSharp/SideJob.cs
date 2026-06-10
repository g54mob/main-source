using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class SideJob
{
	public enum JobState
	{
		generated = 0,
		posted = 1,
		ended = 2
	}

	[Serializable]
	public class AddedDialog
	{
		public int humanID;

		public string dialogRef;

		public int roomID;

		public Evidence.DataKey key;

		[NonSerialized]
		public EvidenceWitness.DialogOption option;

		public Human GetHuman()
		{
			return null;
		}

		public DialogPreset GetDialog()
		{
			return null;
		}

		public NewRoom GetRoom()
		{
			return null;
		}
	}

	[Serializable]
	public class ConfineLocation
	{
		public int id;

		public int address;
	}

	public delegate void ObjectivesChange();

	public delegate void AcquireJobInfo();

	[Header("Serialized Data")]
	public string presetStr;

	public string motiveStr;

	public int jobID;

	public static int assignJobID;

	public JobState state;

	public bool postImmediately;

	public int startingScenario;

	public string intro;

	public string handIn;

	public bool accepted;

	public int caseID;

	public int phase;

	public int postID;

	public int gooseChasePhone;

	public int gooseChaseFromPhone;

	public bool knowHandInLocation;

	public float gooseChaseCallTime;

	public bool gooseChaseCallTriggered;

	public int meetingPoint;

	public int meetingConsumableIndex;

	public int secretLocationFurniture;

	public Vector3Int secretLocationNode;

	public bool failed;

	public List<Case.ResolveQuestion> resolveQuestions;

	public int posterID;

	public int purpID;

	public int reward;

	public string rewardSyncDisk;

	public int fakeNumber;

	public string fakeNumberStr;

	public string jobInfoDialogMsg;

	public List<JobPreset.BasicLeadPool> appliedBasicLeads;

	public List<Evidence.DataKey> leadKeys;

	public List<ConfineLocation> confine;

	public List<AddedDialog> dialog;

	[NonSerialized]
	[Header("Non Serialized")]
	public int phaseChange;

	[NonSerialized]
	public JobPreset preset;

	[NonSerialized]
	public MotivePreset motive;

	[NonSerialized]
	private JobPreset.IntroConfig chosenIntro;

	[NonSerialized]
	private JobPreset.HandInConfig chosenHandIn;

	[NonSerialized]
	public Human poster;

	[NonSerialized]
	public Human purp;

	[NonSerialized]
	public Interactable post;

	[NonSerialized]
	public Dictionary<JobPreset.JobTag, Interactable> activeJobItems;

	[NonSerialized]
	public Case thisCase;

	[NonSerialized]
	public Dictionary<string, List<Objective>> objectiveReference;

	[NonSerialized]
	public Interactable hiddenItemPhoto;

	[NonSerialized]
	public Interactable chosenGooseChasePhone;

	[NonSerialized]
	public Interactable chosenMeetingPoint;

	[NonSerialized]
	public TelephoneController.PhoneCall gooseChaseCall;

	[NonSerialized]
	private SideMissionIntroPreset.SideMissionObjectiveBlock currentBlock;

	[NonSerialized]
	private bool triggerHandIn;

	public event ObjectivesChange OnObjectivesChanged
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

	public event AcquireJobInfo AcquireInfo
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

	public SideJob(JobPreset newPreset, SideJobController.JobPickData newData, bool immediatePost)
	{
	}

	public virtual void GenerateFakeNumber()
	{
	}

	public virtual void ChooseIntro()
	{
	}

	public virtual void ChooseHandIn()
	{
	}

	public virtual void SpawnItems(ref List<JobPreset.StartingSpawnItem> spawnThese)
	{
	}

	private bool SpawnItemIsValid(JobPreset.StartingSpawnItem spawn, ref List<JobPreset.StartingSpawnItem> successsfullySpawned, bool useChance)
	{
		return false;
	}

	public virtual void GameWorldLoop()
	{
	}

	public virtual void HandleObjectiveProgress()
	{
	}

	public NewGameLocation GetGameLocationFromQuestionInput(Case.ResolveQuestion question)
	{
		return null;
	}

	public Human GetCitizenFromQuestionInput(Case.ResolveQuestion question)
	{
		return null;
	}

	public virtual void ObjectiveStateLoop()
	{
	}

	public void GenerateHidingLocation()
	{
	}

	public void OnPlayerCall()
	{
	}

	public virtual void OnGooseChaseCallTriggered()
	{
	}

	public virtual void OnGooseChaseSuccess()
	{
	}

	public virtual void OnGooseChaseEnd()
	{
	}

	public virtual Human GetExtraPerson1()
	{
		return null;
	}

	public virtual void SubmitCase()
	{
	}

	public Interactable SpawnJobItem(InteractablePreset spawnItem, JobPreset.JobSpawnWhere spawnWhere, JobPreset.LeadCitizen spawnBelongsTo, JobPreset.LeadCitizen spawnWriter, JobPreset.LeadCitizen spawnReceiver, int security, InteractablePreset.OwnedPlacementRule ownedRule, int priority, JobPreset.JobTag itemTag, bool tryFindExisting)
	{
		return null;
	}

	public Interactable FindExisting(InteractablePreset what, NewGameLocation location, Human belongsTo, Human writer, Human receiver, JobPreset.JobTag itemTag)
	{
		return null;
	}

	public void SetJobState(JobState newState, bool forceUpdate = false)
	{
	}

	public void SetupNonSerializedData()
	{
	}

	public virtual void Complete()
	{
	}

	public virtual void End()
	{
	}

	public virtual void OnRewarded()
	{
	}

	public virtual void PostJob()
	{
	}

	public virtual void AcceptJob()
	{
	}

	public virtual void SetHandIn()
	{
	}

	public virtual void AddObjective(string entryRef, Objective.ObjectiveTrigger trigger, bool usePointer = false, Vector3 pointerPosition = default(Vector3), InterfaceControls.Icon useIcon = InterfaceControls.Icon.lookingGlass, Objective.OnCompleteAction onCompleteAction = Objective.OnCompleteAction.nextChapterPart, float delay = 0f, bool removePrevious = false, string chapterString = "", bool isSilent = false, bool allowCrouchPromt = false)
	{
	}

	public virtual void OnObjectiveChange()
	{
	}

	public virtual void AddDialogOption(Human person, Evidence.DataKey key, DialogPreset newPreset, NewRoom roomRef = null)
	{
	}

	public virtual void OnAcquireJobInfo(DialogPreset dialog)
	{
	}

	public virtual void OnAcquireJobInfo(string infoDialogMessage)
	{
	}

	public void CreateAcqusitionFacts()
	{
	}

	private void PickPoolLeadOptions()
	{
	}

	private void ApplyLeads(ref List<JobPreset.StartingLead> leads)
	{
	}

	private Evidence GetEvidence(JobPreset.LeadEvidence lead)
	{
		return null;
	}

	public virtual void GenerateResolveQuestions(bool setRewardType)
	{
	}

	private RevengeObjective GetRevengeObjective(Case.ResolveQuestion resolveQ)
	{
		return null;
	}

	private NewGameLocation GetGameLocation(JobPreset.JobSpawnWhere spawnWhere)
	{
		return null;
	}

	private Human GetTarget(JobPreset.LeadCitizen who)
	{
		return null;
	}

	public Interactable GetItem(JobPreset.JobTag tag)
	{
		return null;
	}

	public virtual void UpdateResolveAnswers()
	{
	}

	public float GetDifficulty()
	{
		return 0f;
	}

	public void AddConfineLocation(Human who, NewAddress where)
	{
	}

	public void RemoveConfineLocation(Human who, NewAddress where)
	{
	}

	public virtual void DisplayResolveObjectivesCheck()
	{
	}

	public virtual void TriggerFail(string reason)
	{
	}

	public virtual void OnDestroyMissionObject(Interactable destroyed)
	{
	}

	public virtual void DebugDisplayAnswers()
	{
	}
}
