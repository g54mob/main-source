using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SideJobController : MonoBehaviour
{
	[Serializable]
	public class JobTracking
	{
		public string name;

		public JobPreset preset;

		public List<SideJob> activeJobs;

		public List<SideJob> endedJobs;

		public int desiredActiveInstances;
	}

	[Serializable]
	public class JobPickData
	{
		public MotivePreset motive;

		public Citizen poster;

		public Citizen purp;

		public float score;
	}

	public bool enableJobs;

	[Header("Job Tracking")]
	public List<JobTracking> jobTracking;

	[Header("Exempt Citizens")]
	public List<Human> exemptFromPosters;

	public List<Human> exemptFromPurps;

	public Dictionary<Human, List<SideJob>> exemptFromPostersJobs;

	public Dictionary<Human, List<SideJob>> exemptFromPurpsJobs;

	public Dictionary<int, SideJob> allJobsDictionary;

	[NonSerialized]
	public SideJob invokedSideJob;

	[NonSerialized]
	public Objective invokedObjective;

	[Header("Debug")]
	public int debugJobID;

	private static SideJobController _instance;

	public static SideJobController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void JobCreationCheck()
	{
	}

	public void AddExemptFromPostersJob(Human cit, SideJob job)
	{
	}

	public void AddExemptFromPurpJob(Human cit, SideJob job)
	{
	}

	public void RemoveExemptFromPosters(Human cit, SideJob job)
	{
	}

	public void RemoveExemptFromPurps(Human cit, SideJob job)
	{
	}

	private bool MotivePass(ref List<MotivePreset.ModifierRule> rules, Citizen cit, out int score)
	{
		score = default(int);
		return false;
	}

	public void SideJobObjectiveComplete(SideJob job, Objective objective)
	{
	}

	public void RestrainedPeopleJobCheck()
	{
	}

	public void DeadPeopleJobCheck()
	{
	}

	public void CallPoster()
	{
	}

	public void CallFake()
	{
	}

	public void SabotageRecoverInfo()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListSpawnedItemsForJob()
	{
	}
}
