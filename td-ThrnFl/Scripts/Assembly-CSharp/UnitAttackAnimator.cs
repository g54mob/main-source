using UnityEngine;

public class UnitAttackAnimator : MonoBehaviour
{
	public AutoAttack unit;

	public OneShotAnimationBase attackAnimation;

	public OneShotAnimationBase[] additionalAttackAnimations;

	private void Start()
	{
		if ((bool)unit)
		{
			unit.onAttackTriggered.AddListener(OnAttack);
		}
	}

	private void OnAttack()
	{
		if ((bool)attackAnimation)
		{
			attackAnimation.Trigger();
		}
		OneShotAnimationBase[] array = additionalAttackAnimations;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Trigger();
		}
	}
}
