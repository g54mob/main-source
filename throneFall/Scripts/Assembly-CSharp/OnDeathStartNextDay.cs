using System.Collections;
using UnityEngine;

public class OnDeathStartNextDay : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Hp>().OnKillOrKnockout.AddListener(OnDeath);
	}

	private void OnDeath()
	{
		StartCoroutine(DelayedSwithToDay());
	}

	private IEnumerator DelayedSwithToDay()
	{
		yield return new WaitForSeconds(2f);
		DayNightCycle.Instance.SwithToDay();
	}
}
