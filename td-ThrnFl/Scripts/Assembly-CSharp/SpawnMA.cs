using UnityEngine;

public class SpawnMA : ManualAttack
{
	[SerializeField]
	private GameObject spawnHere;

	[SerializeField]
	private bool enableBaseAttack;

	public override void Attack()
	{
		if (enableBaseAttack)
		{
			base.Attack();
		}
		if ((bool)spawnHere)
		{
			Object.Instantiate(spawnHere, base.transform.position, spawnHere.transform.rotation);
		}
	}
}
