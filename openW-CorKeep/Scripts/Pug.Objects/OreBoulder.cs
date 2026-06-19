using UnityEngine;

public class OreBoulder : EntityMonoBehaviour
{
	private Animator _animator;

	protected override void Awake()
	{
		base.Awake();
		_animator = GetComponent<Animator>();
	}

	protected override void HandleAnimationTrigger(int animID)
	{
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		animator.SetTrigger(-1533413595);
	}
}
