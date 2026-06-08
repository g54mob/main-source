using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class LoseHPOverTime : MonoBehaviour
{
	public float lossPerSecond = 1f;

	private Enemy myEnemy;

	private float lossAccumulated;

	private void HandleTic(Character c)
	{
		if (!(myEnemy != null) || !myEnemy.Alive || myEnemy.CurrentState == Enemy.State.Sleeping)
		{
			return;
		}
		if (myEnemy.Hitpoints <= 0 || myEnemy.MaxHitpoints <= 0)
		{
			myEnemy.Die(Character.DeathReason.LifetimeEnded);
			return;
		}
		lossAccumulated += lossPerSecond / 30f;
		if (lossAccumulated >= 1f)
		{
			int num = Mathf.FloorToInt(lossAccumulated);
			lossAccumulated -= num;
			myEnemy.Hitpoints -= num;
			myEnemy.MaxHitpoints -= num;
			myEnemy.DefaultHitpoints -= num;
		}
	}

	private void Awake()
	{
		myEnemy = GetComponent<Enemy>();
		myEnemy.OnUpdateTic += HandleTic;
	}

	private void OnDestroy()
	{
		myEnemy.OnUpdateTic -= HandleTic;
		myEnemy = null;
	}
}
