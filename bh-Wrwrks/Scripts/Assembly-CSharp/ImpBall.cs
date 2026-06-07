using UnityEngine;

public class ImpBall : Projectile
{
	public override void HitTrigger(Monster monster)
	{
		base.transform.localScale = Vector3.zero;
		GetComponent<Rigidbody2D>().simulated = false;
		base.HitTrigger(monster);
	}
}
