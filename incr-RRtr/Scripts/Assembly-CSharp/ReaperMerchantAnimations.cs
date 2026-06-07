using UnityEngine;

public class ReaperMerchantAnimations : MonoBehaviour
{
	private Animator anim;

	private float timer;

	private float targetTime = 5f;

	[SerializeField]
	private AnimatorOverrideController rustyAnimator;

	private void OnEnable()
	{
		ResetTimer();
		if (!anim)
		{
			anim = GetComponent<Animator>();
			if (SaveData.ins.checkIfCrossover())
			{
				anim.runtimeAnimatorController = rustyAnimator;
			}
		}
		anim.ResetTrigger("Sigh");
		anim.ResetTrigger("Blink");
		anim.Play("Idle");
	}

	private void ResetTimer()
	{
		timer = 0f;
		targetTime = Random.Range(2f, 5f);
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= targetTime)
		{
			if (Random.value < 0.33f)
			{
				anim.SetTrigger("Sigh");
			}
			else
			{
				anim.SetTrigger("Blink");
			}
			ResetTimer();
		}
	}
}
