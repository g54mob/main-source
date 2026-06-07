using UnityEngine;

public class OnDeathKillAllPlayerUnits : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Hp>().OnKillOrKnockout.AddListener(OnDeath);
	}

	private void OnDeath()
	{
		Hp.KillAllPlayerUnits();
	}
}
