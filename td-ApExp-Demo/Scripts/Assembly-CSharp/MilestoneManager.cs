using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilestoneManager : MonoBehaviour, ISaveable
{
	public static MilestoneManager Instance;

	[SerializeField]
	private Milestone[] all;

	[SerializeField]
	public bool milestoneTrackingOn;

	[NonSerialized]
	public List<Milestone> milestones;

	private bool found;

	[NonSerialized]
	public List<Milestone> currentRunUnlocks;

	[NonSerialized]
	public bool canUpdateProgress;

	public bool loadingFromSave;

	[NonSerialized]
	public int coresToGain;

	[field: SerializeField]
	public List<MilestoneEnemyKilled> EnemyKilledMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneModuleUsed> ModuleUsedMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneMinigamesCompleted> MinigamesCompletedMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneDamageFixed> DamageFixedMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneGetUpgrades> GetUpgradesMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneGetRelics> GetRelicsMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneGetModules> GetModulesMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneGetResource> GetResourceMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneDistanceTraveled> DistanceTraveledMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneModuleDealDamage> ModuleDealDamageMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneLocationsVisited> LocationsVisitedMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneModuleMitigateDamage> ModuleMitigateDamageMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneTimingMinigame> TimingMinigamesMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneScrapSpent> ScrapSpentMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneOverfillDuration> OverfillDurationMilestones { get; private set; }

	[field: SerializeField]
	public List<MilestoneUnavailable> UnavailableMilestones { get; private set; }

	[field: NonSerialized]
	public bool CoresAwarded { get; private set; }

	private void Awake()
	{
		Milestone[] array = all;
		foreach (Milestone obj in array)
		{
			obj.Progress = 0f;
			obj.Completed = false;
		}
		currentRunUnlocks = new List<Milestone>();
		Instance = this;
		milestones = new List<Milestone>();
		milestones.AddRange(EnemyKilledMilestones);
		milestones.AddRange(DamageFixedMilestones);
		milestones.AddRange(GetUpgradesMilestones);
		milestones.AddRange(GetRelicsMilestones);
		milestones.AddRange(GetModulesMilestones);
		milestones.AddRange(GetResourceMilestones);
		milestones.AddRange(DistanceTraveledMilestones);
		milestones.AddRange(TimingMinigamesMilestones);
		milestones.AddRange(ScrapSpentMilestones);
		milestones.AddRange(OverfillDurationMilestones);
		milestones.AddRange(UnavailableMilestones);
		foreach (Milestone milestone in milestones)
		{
			milestone.Initialize();
		}
		milestones.AddRange(ModuleUsedMilestones);
		milestones.AddRange(MinigamesCompletedMilestones);
		milestones.AddRange(ModuleDealDamageMilestones);
		milestones.AddRange(LocationsVisitedMilestones);
		milestones.AddRange(ModuleMitigateDamageMilestones);
	}

	private void Start()
	{
		if (milestones.Count == 0)
		{
			return;
		}
		foreach (MilestoneLocationsVisited locationsVisitedMilestone in LocationsVisitedMilestones)
		{
			locationsVisitedMilestone.Initialize();
		}
		if (coresToGain > 0)
		{
			GameManager.Instance.JourneyStarted += AwardCores;
			GameManager.Instance.JourneyContinued += AwardCores;
		}
	}

	private void Update()
	{
		if (GameManager.Instance.isDemo || milestones.Count == 0)
		{
			return;
		}
		foreach (MilestoneDistanceTraveled distanceTraveledMilestone in DistanceTraveledMilestones)
		{
			if (!distanceTraveledMilestone.Completed)
			{
				distanceTraveledMilestone.SimulateUpdate();
			}
		}
	}

	public void Save(SaveDataContext context)
	{
		if (GameManager.Instance.isDemo || milestones == null || milestones.Count == 0)
		{
			return;
		}
		MetaSavefile metaSave = context.MetaSave;
		foreach (Milestone milestone in milestones)
		{
			found = false;
			foreach (string savedMilestoneName in metaSave.savedMilestoneNames)
			{
				if (savedMilestoneName == milestone.Name)
				{
					int index = metaSave.savedMilestoneNames.IndexOf(savedMilestoneName);
					metaSave.savedMilestoneProgress[index] = milestone.Progress;
					metaSave.savedMilestoneCompleted[index] = milestone.Completed;
					found = true;
					break;
				}
			}
			if (!found)
			{
				metaSave.savedMilestoneNames.Add(milestone.Name);
				metaSave.savedMilestoneProgress.Add(milestone.Progress);
				metaSave.savedMilestoneCompleted.Add(milestone.Completed);
			}
		}
		Debug.Log("Saved milestones " + metaSave.savedMilestoneNames.Count);
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (GameManager.Instance.isDemo)
		{
			return;
		}
		loadingFromSave = true;
		if (milestones == null || milestones.Count == 0)
		{
			return;
		}
		MetaSavefile metaSave = context.MetaSave;
		CoresAwarded = metaSave.coresGainedFromMilestones;
		foreach (string savedMilestoneName in metaSave.savedMilestoneNames)
		{
			foreach (Milestone milestone in milestones)
			{
				if (savedMilestoneName == milestone.Name)
				{
					int index = metaSave.savedMilestoneNames.IndexOf(savedMilestoneName);
					milestone.Progress = metaSave.savedMilestoneProgress[index];
					milestone.Completed = metaSave.savedMilestoneCompleted[index];
					if (!CoresAwarded && milestone.Completed)
					{
						coresToGain += milestone.CoresGain;
					}
					if (!milestone.Completed && milestone.SingleRun)
					{
						milestone.ResetProgress();
					}
					milestone.UpdateProgress();
					break;
				}
			}
		}
		metaSave.coresGainedFromMilestones = true;
		Debug.Log("Loaded milestones " + metaSave.savedMilestoneNames.Count);
		loadingFromSave = false;
	}

	public void AddNewUnlock(Milestone unlock)
	{
		if (!GameManager.Instance.isDemo)
		{
			currentRunUnlocks.Add(unlock);
		}
	}

	public void ResetMilestones()
	{
		foreach (Milestone milestone in milestones)
		{
			milestone.Completed = false;
		}
	}

	public void FullResetMilesstones()
	{
		foreach (Milestone milestone in milestones)
		{
			milestone.Completed = false;
			milestone.Progress = 0f;
		}
	}

	public void DisplayCoresGainFromMilestone(IEnumerator coroutine)
	{
		StartCoroutine(coroutine);
	}

	private void AwardCores()
	{
		StartCoroutine(AwardCoresCoroutine());
		IEnumerator AwardCoresCoroutine()
		{
			yield return new WaitForSecondsRealtime(3f);
			ResourceManager.Instance.LootCores(coresToGain);
			Debug.Log("eve na");
			GameManager.Instance.JourneyStarted -= AwardCores;
			GameManager.Instance.JourneyContinued -= AwardCores;
			MenuManager.Instance.OpenMenu(MenuType.MilestoneCoresAward);
		}
	}
}
