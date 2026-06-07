using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Booklets;
using DV.CabControls;
using DV.Common;
using DV.Logic.Job;
using DV.Printers;
using DV.ServicePenalty;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

public class JobValidator : MonoBehaviour
{
	private static Coroutine summonBookletsCoro;

	public GameObject reprintActiveJobBookletsButtonGO;

	[SerializeField]
	private MoneyPrinterJobValidator moneyPrinter;

	[SerializeField]
	private PrinterController bookletPrinter;

	[SerializeField]
	private AudioClip jobValidatedSound;

	private void Awake()
	{
		if (moneyPrinter == null || bookletPrinter == null || jobValidatedSound == null)
		{
			Debug.LogError("JobValidator is not initialized properly, not all fields are set!", this);
		}
	}

	private void Start()
	{
		ButtonBase component = reprintActiveJobBookletsButtonGO.GetComponent<ButtonBase>();
		if (component != null)
		{
			component.Used += SummonAllActiveJobBooklets;
		}
		else
		{
			Debug.LogError("reprintActiveJobBookletsButtonGO doesn't have ButtonBase component attached! Button will be unusable", this);
		}
	}

	public void ProcessJobOverview(JobOverview jobOverview)
	{
		if (bookletPrinter.IsOnCooldown)
		{
			bookletPrinter.PlayErrorSound();
			return;
		}
		Transform originShiftParent = WorldMover.OriginShiftParent;
		switch (jobOverview.job.State)
		{
		case JobState.Available:
		{
			StationController stationController = StationController.allStations.FirstOrDefault((StationController st) => st.logicStation.availableJobs.Contains(jobOverview.job));
			if (stationController != null)
			{
				Job job = jobOverview.job;
				if (!GameFeatureFlags.IsAllowed(GameFeatureFlags.Flag.UseJobValidator))
				{
					BookletCreator.CreateTutorialWarningReport(bookletPrinter.spawnAnchor.position, bookletPrinter.spawnAnchor.rotation, originShiftParent);
					bookletPrinter.PlayErrorSound();
					bookletPrinter.Print();
				}
				else if (SingletonBehaviour<JobsManager>.Instance.currentJobs.Count >= SingletonBehaviour<LicenseManager>.Instance.GetNumberOfAllowedConcurrentJobs())
				{
					BookletCreator.CreateMissingLicenseReport(job, isJobLicenseMissing: false, bookletPrinter.spawnAnchor.position, bookletPrinter.spawnAnchor.rotation, originShiftParent);
					bookletPrinter.PlayErrorSound();
					bookletPrinter.Print();
				}
				else if (!SingletonBehaviour<LicenseManager>.Instance.IsLicensedForJob(JobLicenseType_v2.ToV2List(job.requiredLicenses)))
				{
					BookletCreator.CreateMissingLicenseReport(job, isJobLicenseMissing: true, bookletPrinter.spawnAnchor.position, bookletPrinter.spawnAnchor.rotation, originShiftParent);
					bookletPrinter.PlayErrorSound();
					bookletPrinter.Print();
				}
				else if (!SingletonBehaviour<CareerManagerDebtController>.Instance.IsPlayerAllowedToTakeJob())
				{
					BookletCreator.CreateDebtWarningReport(bookletPrinter.spawnAnchor.position, bookletPrinter.spawnAnchor.rotation, originShiftParent);
					bookletPrinter.PlayErrorSound();
					bookletPrinter.Print();
				}
				else
				{
					stationController.TakeJobFromStation(jobOverview);
					BookletCreator.CreateJobBooklet(job, bookletPrinter.spawnAnchor.position, bookletPrinter.spawnAnchor.rotation, originShiftParent, addToWorldStorage: true);
					jobValidatedSound.Play(bookletPrinter.spawnAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
					bookletPrinter.Print();
				}
			}
			else
			{
				Debug.LogError("Job[" + jobOverview.job.ID + "] is in available state, but is not part of any station! Destroying jobOverview");
				jobOverview.DestroyJobOverview();
			}
			break;
		}
		case JobState.Expired:
			BookletCreator.CreateJobExpiredReport(jobOverview.job, bookletPrinter.spawnAnchor.position, bookletPrinter.spawnAnchor.rotation, originShiftParent);
			bookletPrinter.PlayErrorSound();
			bookletPrinter.Print();
			jobOverview.DestroyJobOverview();
			break;
		default:
			Debug.LogError("Job[" + jobOverview.job.ID + "] was already taken, but jobOverview: " + jobOverview.name + " was not destroyed! Destroying jobOverview");
			jobOverview.DestroyJobOverview();
			break;
		}
	}

	public void ValidateJob(JobBooklet jobBooklet)
	{
		if (jobBooklet == null || jobBooklet.job == null || jobBooklet.job.State != JobState.InProgress)
		{
			Debug.LogError("Job attached to name or JobBooklet itself is not initialized or in correct state! Ignoring request!");
			return;
		}
		if (bookletPrinter.IsOnCooldown)
		{
			bookletPrinter.PlayErrorSound();
			return;
		}
		Job job = jobBooklet.job;
		if (!SingletonBehaviour<JobsManager>.Instance.currentJobs.Contains(job))
		{
			Debug.LogError("Job[" + job.ID + "] isn't taken, but we have a jobBooklet!");
			return;
		}
		bool num = SingletonBehaviour<JobsManager>.Instance.TryToCompleteAJob(job) == JobState.Completed;
		DisplayableDebt displayableDebt = (num ? SingletonBehaviour<JobDebtController>.Instance.LastStagedJobDebt : SingletonBehaviour<JobDebtController>.Instance.GetExistingJobDebtForJob(job));
		if (displayableDebt != null && !displayableDebt.IsStaged)
		{
			displayableDebt.UpdateDebtState();
		}
		BookletCreator.CreateJobReport(job, displayableDebt, bookletPrinter.spawnAnchor.position, bookletPrinter.spawnAnchor.rotation, WorldMover.OriginShiftParent);
		jobValidatedSound.Play(bookletPrinter.spawnAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		bookletPrinter.Print();
		if (num)
		{
			jobBooklet.DestroyJobBooklet();
			moneyPrinter.PrintPayment(job);
		}
	}

	public void SummonAllActiveJobBooklets()
	{
		if (summonBookletsCoro != null)
		{
			bookletPrinter.PlayErrorSound();
		}
		else
		{
			summonBookletsCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(SummonAllActiveJobBookletsCoro());
		}
	}

	private IEnumerator SummonAllActiveJobBookletsCoro()
	{
		List<JobBooklet> allJobBooklets = new List<JobBooklet>(JobBooklet.allExistingJobBooklets);
		if (allJobBooklets.Count == 0)
		{
			bookletPrinter.PlayErrorSound();
			summonBookletsCoro = null;
			yield break;
		}
		yield return null;
		Vector3 vector = Vector3.up * 0.02f;
		Vector3 vector2 = bookletPrinter.spawnAnchor.forward * 0.55f;
		int num = 0;
		foreach (JobBooklet item in allJobBooklets)
		{
			if (item == null)
			{
				Debug.LogWarning("Reprint preparation failed: JobBooklet was deleted in the meantime - abandoned job or some other source. Skipping");
				continue;
			}
			if (!item.HasJobAssigned())
			{
				Debug.LogError("Reprint preparation failed: JobBooklet: " + item.name + " without job assigned exists! Ignoring summon request", item);
				continue;
			}
			ItemBase component = item.GetComponent<ItemBase>();
			if (component != null)
			{
				if (component.SnappableItem?.SnappedTo != null)
				{
					component.SnappableItem.SnappedTo.UnsnapItem(forced: true);
				}
				TrainPhysicsLod.RemoveItemFromAnyCar(component);
				Vector3 position = bookletPrinter.spawnAnchor.position + vector * num + vector2;
				Quaternion rotation = bookletPrinter.spawnAnchor.rotation;
				StorageController.RemoveItemFromCurrentStorageAndAddToWorld(component, position, rotation);
				component.gameObject.SetActive(value: false);
			}
			else
			{
				Debug.LogError("Reprint preparation failed: JobBooklet: " + item.name + " doesn't have and ItemBase component attached! Ignoring request!");
			}
			num++;
		}
		foreach (JobBooklet item2 in allJobBooklets)
		{
			if (item2 == null)
			{
				Debug.LogWarning("Reprinting failed: JobBooklet was deleted in the meantime - abandoned job or some other source. Skipping");
				continue;
			}
			if (!item2.HasJobAssigned())
			{
				Debug.LogError("Reprinting failed: JobBooklet: " + item2.name + " without job assigned exists! Ignoring summon request", item2);
				continue;
			}
			ItemBase component2 = item2.GetComponent<ItemBase>();
			if (component2 != null)
			{
				bookletPrinter.Print(ignoreCooldown: true);
				component2.transform.position = bookletPrinter.spawnAnchor.position;
				component2.gameObject.SetActive(value: true);
			}
			else
			{
				Debug.LogError("Reprinting failed: JobBooklet: " + item2.name + " doesn't have and ItemBase component attached! Ignoring request!");
			}
			yield return WaitFor.Seconds(1.25f);
		}
		summonBookletsCoro = null;
	}

	public void PlayErrorSound()
	{
		if (bookletPrinter != null)
		{
			bookletPrinter.PlayErrorSound();
		}
	}
}
