using UnityEngine;

namespace Kitchen
{
	public class LetterView : MonoBehaviour
	{
		public Animator Animator;

		public GameObject Letter;

		public float MinDelay;

		public float MaxDelay = 2f;

		private float Delay;

		private bool IsPlaying;

		private void Start()
		{
			Delay = Random.Range(MinDelay, MaxDelay);
			Animator.speed = Random.Range(0.9f, 1.1f);
			Animator.enabled = false;
			Letter.SetActive(value: false);
		}

		private void Update()
		{
			if (!IsPlaying)
			{
				Delay -= Time.deltaTime;
				if (Delay < 0f)
				{
					Letter.SetActive(value: true);
					IsPlaying = true;
					Animator.enabled = true;
				}
			}
		}
	}
}
