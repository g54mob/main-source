using UnityEngine;

public class OnDeathKillAllEnemies : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Hp>().OnKillOrKnockout.AddListener(OnDeath);
	}

	private void OnDeath()
	{
		Hp.KillAllEnemyUnits();
	}
}
