using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FrogController : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private List<FrogAction> actions;

	private void Start()
	{
		StartCoroutine(PlayAnimationSequence());
	}

	private IEnumerator PlayAnimationSequence()
	{
		foreach (FrogAction action in actions)
		{
			yield return new WaitForSeconds(GetRandomWaitValue(1f, 3f));
			animator.Play("Idle_A");
			base.transform.DOLocalMove(action.pointToMoveTo.localPosition, action.moveSpeed * Time.deltaTime).SetEase(Ease.Linear);
			if (action.jump)
			{
				animator.Play("Jump");
			}
		}
	}

	private float GetRandomWaitValue(float min, float max)
	{
		return Random.Range(min, max);
	}
}
