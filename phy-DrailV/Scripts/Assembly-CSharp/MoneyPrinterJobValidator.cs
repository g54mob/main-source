using System.Collections;
using DV.Logic.Job;
using UnityEngine;

public class MoneyPrinterJobValidator : MoneyPrinter
{
	private const float INITIAL_MONEY_OUTPUT_DELAY = 2f;

	private const float DELAY_BEFORE_MONEY_SPAWN = 1f;

	private const float PICK_UP_MONEY_WITH_WALLET_CHECKER_DELAY = 0.5f;

	[SerializeField]
	private AudioClip moneyOutputSound;

	[SerializeField]
	private LayeredAudio takeMoneyAlarmSound;

	[SerializeField]
	private LampControl takeMoneyLamp;

	private GameObject lastPaymentMoney;

	private bool takeMoneyFlag;

	private Coroutine moneyPickupCoro;

	protected override void Awake()
	{
		base.Awake();
		if (moneyOutputSound == null || takeMoneyAlarmSound == null || takeMoneyLamp == null)
		{
			Debug.LogError("MoneyPrinter is not initialized properly, not all fields are set!", this);
		}
		takeMoneyLamp.SetLampState(LampControl.LampState.Off);
		takeMoneyAlarmSound = AudioManager.InstantiateLayeredAudio(takeMoneyAlarmSound, spawnMoneyAnchor);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == lastPaymentMoney && takeMoneyFlag)
		{
			FinalizeTakeMoney();
		}
	}

	public void PrintPayment(Job job)
	{
		StartCoroutine(PrintMoneyProcess(job));
	}

	private IEnumerator PrintMoneyProcess(Job job)
	{
		yield return WaitFor.Seconds(2f);
		moneyOutputSound.Play(spawnMoneyAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, spawnMoneyAnchor);
		yield return WaitFor.Seconds(1f);
		lastPaymentMoney = PrintMoney(job.GetWageForTheJob());
		takeMoneyAlarmSound.Play();
		takeMoneyAlarmSound.Set(1f);
		takeMoneyLamp.SetLampState(LampControl.LampState.Blinking);
		takeMoneyFlag = true;
		if (moneyPickupCoro != null)
		{
			StopCoroutine(moneyPickupCoro);
		}
		moneyPickupCoro = StartCoroutine(CheckForMoneyPickedUpWithWallet(0.5f));
	}

	private IEnumerator CheckForMoneyPickedUpWithWallet(float delay)
	{
		while (lastPaymentMoney != null)
		{
			yield return WaitFor.Seconds(delay);
		}
		FinalizeTakeMoney();
	}

	private void FinalizeTakeMoney()
	{
		takeMoneyAlarmSound.Stop();
		takeMoneyAlarmSound.Set(0f);
		takeMoneyLamp.SetLampState(LampControl.LampState.Off);
		takeMoneyFlag = false;
		if (moneyPickupCoro != null)
		{
			StopCoroutine(moneyPickupCoro);
		}
		moneyPickupCoro = null;
	}
}
