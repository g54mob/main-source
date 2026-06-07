using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorTriggeredByAction : DynamicObjectBase
{
	private Animator animator;

	protected override void Awake()
	{
		base.Awake();
		animator = GetComponent<Animator>();
	}

	public override void SetupToAction()
	{
		base.SetupToAction();
		animator.SetBool("Start", value: true);
	}

	public override void Recycle()
	{
		base.Recycle();
		animator.SetBool("Start", value: false);
	}
}
