using System;
using System.Collections;
using DV.CabControls;
using UnityEngine;

public class TutorialJobValidator : MonoBehaviour
{
	private const float COOLDOWN_TIME = 5f;

	public float selfDestructionDistanceThreshold = 40f;

	private bool selfRemovalInitiated;

	[SerializeField]
	private MoneyPrinterJobValidator moneyPrinter;

	public Transform spawnReportAnchor;

	[SerializeField]
	private AudioClip cooldownErrorSound;

	[SerializeField]
	private AudioClip jobValidatedSound;

	[SerializeField]
	private AudioClip printingReportSound;

	[SerializeField]
	private LampControl cooldownLamp;

	private bool printReportCooldownFlag;

	public event Action TutorialJobValidated;

	private void Awake()
	{
		if (moneyPrinter == null || spawnReportAnchor == null || cooldownErrorSound == null || jobValidatedSound == null || printingReportSound == null || cooldownLamp == null)
		{
			Debug.LogError("JobValidator is not initialized properly, not all fields are set!", this);
		}
		cooldownLamp.SetLampState(LampControl.LampState.On);
	}

	private void OnTriggerEnter(Collider other)
	{
		TutorialJob componentInParent = other.GetComponentInParent<TutorialJob>();
		if (componentInParent != null && componentInParent.isCurrentJob)
		{
			if (!printReportCooldownFlag)
			{
				ValidateTutorialJob(componentInParent);
			}
			else
			{
				cooldownErrorSound.Play(spawnReportAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}
		else if (other.GetComponent<JobReport>() != null)
		{
			cooldownErrorSound.Play(spawnReportAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
	}

	public void ValidateTutorialJob(TutorialJob tutJob)
	{
		PrintJobDataReport(tutJob.RequestJobReportPrefab());
		if (tutJob.jobDone)
		{
			tutJob.isCurrentJob = false;
			tutJob.jobDone = false;
			if (tutJob.jobValue > double.Epsilon)
			{
				moneyPrinter.PrintMoney(tutJob.jobValue);
			}
			HandleJobDestruction(tutJob.GetComponent<ItemBase>());
			this.TutorialJobValidated?.Invoke();
		}
		jobValidatedSound.Play(spawnReportAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		printingReportSound.Play(spawnReportAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		StartCoroutine(PrintReportCooldown(5f));
	}

	private void HandleJobDestruction(ItemBase item)
	{
		if (!(item == null))
		{
			if (item.IsGrabbed())
			{
				StartCoroutine(UngrabAndDestroyCoro(item));
			}
			else
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
	}

	private IEnumerator PrintReportCooldown(float cooldownTime)
	{
		printReportCooldownFlag = true;
		cooldownLamp.SetLampState(LampControl.LampState.Off);
		yield return WaitFor.Seconds(cooldownTime);
		printReportCooldownFlag = false;
		cooldownLamp.SetLampState(LampControl.LampState.On);
	}

	private void PrintJobDataReport(GameObject jobReport)
	{
		if (!(jobReport == null))
		{
			UnityEngine.Object.Instantiate(jobReport, spawnReportAnchor.position, spawnReportAnchor.rotation, WorldMover.OriginShiftParent);
		}
	}

	public void StartCheckingForRemoval()
	{
		if (!selfRemovalInitiated)
		{
			selfRemovalInitiated = true;
			InvokeRepeating("CheckDistanceForSelfDestruction", 1f, 1f);
		}
	}

	private void CheckDistanceForSelfDestruction()
	{
		if ((PlayerManager.PlayerTransform.position - base.transform.position).sqrMagnitude > selfDestructionDistanceThreshold * selfDestructionDistanceThreshold)
		{
			CancelInvoke("CheckDistanceForSelfDestruction");
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public void PlayPrintSoundExternally()
	{
		printingReportSound.Play(spawnReportAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
	}

	private IEnumerator UngrabAndDestroyCoro(ItemBase item)
	{
		item.ForceEndInteraction();
		yield return null;
		UnityEngine.Object.Destroy(item.gameObject);
	}
}
