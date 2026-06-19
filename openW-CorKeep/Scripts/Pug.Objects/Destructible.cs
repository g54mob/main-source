using UnityEngine;

public class Destructible : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 vector = new Vector3(0f, 3f, -3f);
		Manager.effects.ExploDisc(base.transform.position + vector + Vector3.up * 0.25f, 0.33f);
	}
}
