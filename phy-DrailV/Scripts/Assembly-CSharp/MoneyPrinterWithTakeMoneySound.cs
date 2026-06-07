using UnityEngine;

public class MoneyPrinterWithTakeMoneySound : MoneyPrinter
{
	public AudioClip takeMoneyAlarmSound;

	protected override void Awake()
	{
		base.Awake();
		if (takeMoneyAlarmSound == null)
		{
			Debug.LogError("takeMoneyAlarmSound is not set, so it won't be played");
		}
	}

	public override GameObject PrintMoney(double cashAmount)
	{
		if (takeMoneyAlarmSound != null)
		{
			takeMoneyAlarmSound.Play(spawnMoneyAnchor.position, 1f, 1f, 0f, 1f, 50f, default(AudioSourceCurves), null, base.transform);
		}
		return base.PrintMoney(cashAmount);
	}
}
