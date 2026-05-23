using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackAnimator : MonoBehaviour
{
	public List<OneShotAnimationBase> animations = new List<OneShotAnimationBase>();

	public List<OneShotAnimationBase> cooldownAnimations = new List<OneShotAnimationBase>();

	public float delayOfCooldownAnimation = 0.15f;

	private ManualAttack playerAttack;

	public void AssignAttack(ManualAttack attack)
	{
		playerAttack = attack;
		playerAttack.onAttack.AddListener(TriggerAnimations);
	}

	private void TriggerAnimations()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		foreach (OneShotAnimationBase animation in animations)
		{
			animation.Trigger();
		}
		StopAllCoroutines();
		if (cooldownAnimations.Count > 0)
		{
			StartCoroutine(DelayedCooldownAnimation());
		}
	}

	private IEnumerator DelayedCooldownAnimation()
	{
		yield return new WaitForSeconds(delayOfCooldownAnimation);
		float num = playerAttack.Cooldown - delayOfCooldownAnimation;
		if (!(num > 0.1f))
		{
			yield break;
		}
		foreach (OneShotAnimationBase cooldownAnimation in cooldownAnimations)
		{
			cooldownAnimation.duration = num;
			cooldownAnimation.Trigger();
		}
	}
}
