using UnityEngine;

public class AnimationActivator : ActiveComponent
{
	private Animation anim;

	protected override void OnInit()
	{
		anim = base.transform.GetComponent<Animation>();
	}

	public void StartAnim()
	{
		anim.Play();
	}
}
