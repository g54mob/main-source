using UnityEngine;

public class CoalHoseSegment : LinkComponent
{
	[SerializeField]
	private Animator anim;

	public void PlaySuckAnim()
	{
		if (anim != null)
		{
			anim.SetTrigger("Suck");
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
	}

	private void OnDestroy()
	{
	}
}
