using System;
using System.Collections;
using Pug.Sprite;
using UnityEngine;

public class CreditsGraphicsAnimator : MonoBehaviour
{
	[Serializable]
	public class SpriteObjectChainAnimation
	{
		[Header("Trigger")]
		public string animationStartName;

		public string animationEndName;

		public string eventName;

		[Header("Target")]
		public SpriteObject target;

		public string animation;

		public float delay;

		public int animationStartHash { get; private set; }

		public int animationEndHash { get; private set; }

		public int eventHash { get; private set; }

		public int animationHash { get; private set; }

		public void Initialize()
		{
			animationStartHash = SpriteAsset.StringToHash(animationStartName);
			animationEndHash = SpriteAsset.StringToHash(animationEndName);
			eventHash = SpriteAsset.StringToHash(eventName);
			animationHash = SpriteAsset.StringToHash(animation);
		}
	}

	[Serializable]
	public class SpriteObjectAnimator
	{
		public SpriteObject spriteObject;

		public string thresholdAnimation;

		public string startAnimation;

		public float startAnimationDelay;

		public SpriteObjectChainAnimation[] chainAnimations;

		private float m_startTime;

		private bool m_didPlayStartAnimation;

		private MonoBehaviour m_owner;

		public int resetAnimationHash { get; private set; }

		public int resetVariantHash { get; private set; }

		public int thresholdAnimationHash { get; private set; }

		public int startAnimationHash { get; private set; }

		public void Initialize(MonoBehaviour owner)
		{
			m_owner = owner;
			resetAnimationHash = spriteObject.currentAnimationHash;
			resetVariantHash = spriteObject.currentVariantHash;
			thresholdAnimationHash = SpriteAsset.StringToHash(thresholdAnimation);
			startAnimationHash = SpriteAsset.StringToHash(startAnimation);
			SpriteObjectChainAnimation[] array = chainAnimations;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Initialize();
			}
			spriteObject.onAnimationStart += OnAnimationStart;
			spriteObject.onAnimationEnd += OnAnimationEnd;
			spriteObject.onAnimationEvent += OnAnimationEvent;
			Reset();
		}

		public void Reset()
		{
			spriteObject.PlayAnimation(resetAnimationHash, resetVariantHash, forceResetTime: false, skipTransition: true);
			m_startTime = -1f;
			m_didPlayStartAnimation = false;
		}

		public void Update()
		{
			if (!spriteObject.isActiveAndEnabled)
			{
				return;
			}
			if (m_startTime < 0f)
			{
				m_startTime = Time.time;
			}
			if (Time.time - m_startTime > startAnimationDelay && !m_didPlayStartAnimation)
			{
				if (startAnimationHash != 0)
				{
					spriteObject.PlayAnimation(startAnimationHash, spriteObject.currentVariantHash);
				}
				m_didPlayStartAnimation = true;
			}
		}

		private void OnAnimationStart(int animationHash)
		{
			SpriteObjectChainAnimation[] array = chainAnimations;
			foreach (SpriteObjectChainAnimation spriteObjectChainAnimation in array)
			{
				if (spriteObjectChainAnimation.animationStartHash == animationHash)
				{
					PlayTargetAnimation(spriteObjectChainAnimation.target, spriteObjectChainAnimation.animationHash, spriteObjectChainAnimation.delay);
				}
			}
		}

		private void OnAnimationEnd(int animationHash)
		{
			SpriteObjectChainAnimation[] array = chainAnimations;
			foreach (SpriteObjectChainAnimation spriteObjectChainAnimation in array)
			{
				if (spriteObjectChainAnimation.animationEndHash == animationHash)
				{
					PlayTargetAnimation(spriteObjectChainAnimation.target, spriteObjectChainAnimation.animationHash, spriteObjectChainAnimation.delay);
				}
			}
		}

		private void OnAnimationEvent(int eventHash)
		{
			SpriteObjectChainAnimation[] array = chainAnimations;
			foreach (SpriteObjectChainAnimation spriteObjectChainAnimation in array)
			{
				if (spriteObjectChainAnimation.eventHash == eventHash)
				{
					PlayTargetAnimation(spriteObjectChainAnimation.target, spriteObjectChainAnimation.animationHash, spriteObjectChainAnimation.delay);
				}
			}
		}

		private void PlayTargetAnimation(SpriteObject target, int animationHash, float delay)
		{
			if (delay > Mathf.Epsilon)
			{
				m_owner.StartCoroutine(PlayTargetAnimationDelayed(target, animationHash, delay));
			}
			else
			{
				target.PlayAnimation(animationHash);
			}
		}

		private IEnumerator PlayTargetAnimationDelayed(SpriteObject target, int animationHash, float delay)
		{
			yield return new WaitForSeconds(delay);
			target.PlayAnimation(animationHash);
		}
	}

	public float animationThreshold = -5f;

	[Header("Animator")]
	public Animator animator;

	public string startTrigger;

	[Header("SpriteObjects")]
	public SpriteObjectAnimator[] spriteObjectAnimators;

	private bool m_wasPastThreshold;

	private void Awake()
	{
		SpriteObjectAnimator[] array = spriteObjectAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Initialize(this);
		}
	}

	private void OnEnable()
	{
		if (animator != null && !string.IsNullOrEmpty(startTrigger))
		{
			animator.SetTrigger(startTrigger);
		}
		SpriteObjectAnimator[] array = spriteObjectAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Reset();
		}
		m_wasPastThreshold = false;
	}

	private void Update()
	{
		bool flag = base.transform.position.y > animationThreshold;
		if (flag && !m_wasPastThreshold)
		{
			PlayThresholdAnimation();
		}
		SpriteObjectAnimator[] array = spriteObjectAnimators;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Update();
		}
		m_wasPastThreshold = flag;
	}

	public void PlayThresholdAnimation()
	{
		SpriteObjectAnimator[] array = spriteObjectAnimators;
		foreach (SpriteObjectAnimator spriteObjectAnimator in array)
		{
			if (spriteObjectAnimator.thresholdAnimationHash != 0)
			{
				spriteObjectAnimator.spriteObject.PlayAnimation(spriteObjectAnimator.thresholdAnimationHash, spriteObjectAnimator.spriteObject.currentVariantHash);
			}
		}
	}
}
