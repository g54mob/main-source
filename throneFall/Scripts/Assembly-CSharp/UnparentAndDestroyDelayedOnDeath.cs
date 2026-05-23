using UnityEngine;

public class UnparentAndDestroyDelayedOnDeath : MonoBehaviour
{
	public Hp target;

	public float extraLifetime = 4f;

	private void Start()
	{
		target.OnKillOrKnockout.AddListener(Trigger);
	}

	private void Trigger()
	{
		base.transform.parent = null;
		Object.Destroy(base.gameObject, extraLifetime);
	}
}
