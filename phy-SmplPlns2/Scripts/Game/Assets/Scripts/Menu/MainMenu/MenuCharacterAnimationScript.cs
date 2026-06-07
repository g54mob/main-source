using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Menu.MainMenu
{
	public class MenuCharacterAnimationScript : MonoBehaviour
	{
		[Serializable]
		public class AnimationEntry
		{
			[SerializeField]
			private AnimationClip animationClip;

			[SerializeField]
			private int loopCount = 1;

			[SerializeField]
			private float probability = 1f;

			[SerializeField]
			private float speed = 1f;

			public AnimationClip AnimationClip => animationClip;

			public int LoopCount => loopCount;

			public float Probability
			{
				get
				{
					return probability;
				}
				set
				{
					probability = value;
				}
			}

			public float Speed => speed;
		}

		[Serializable]
		public class AnimationSet
		{
			[SerializeField]
			private List<AnimationEntry> animations = new List<AnimationEntry>();

			private float totalProbability;

			public List<AnimationEntry> Animations => animations;

			public float TotalProbability => totalProbability;

			public void CalculateTotalProbability()
			{
				totalProbability = 0f;
				foreach (AnimationEntry animation in animations)
				{
					totalProbability += animation.Probability;
				}
			}
		}

		[SerializeField]
		private Animator animator;

		private AnimationEntry currentAnimation;

		private int currentLoop;

		[SerializeField]
		private AnimationSet danceAnimations;

		[SerializeField]
		private AnimationSet idleAnimations;

		private float nextDanceTime = -1f;

		public void SetAnimator(Animator newAnimator)
		{
			newAnimator.runtimeAnimatorController = animator.runtimeAnimatorController;
			animator = newAnimator;
		}

		protected virtual void Start()
		{
			idleAnimations.CalculateTotalProbability();
			danceAnimations.CalculateTotalProbability();
			StartCoroutine(AnimationCycle());
		}

		private IEnumerator AnimationCycle()
		{
			while (true)
			{
				currentAnimation = SelectRandomAnimation();
				currentLoop = 1;
				animator.CrossFadeInFixedTime(currentAnimation.AnimationClip.name, 0.5f);
				animator.speed = currentAnimation.Speed;
				yield return new WaitForSeconds(currentAnimation.AnimationClip.length / animator.speed + 0.5f);
				while (currentLoop < currentAnimation.LoopCount)
				{
					animator.Play(currentAnimation.AnimationClip.name);
					yield return new WaitForSeconds(currentAnimation.AnimationClip.length / animator.speed);
					currentLoop++;
				}
			}
		}

		private AnimationEntry SelectRandomAnimation()
		{
			AnimationSet animationSet = idleAnimations;
			if (nextDanceTime < Time.time && Game.Instance.Settings.Gameplay.Audio.MusicVolume.Value >= 0.4f)
			{
				if (Game.Instance.MusicPlayer.PlayingSong.DanceSong)
				{
					animationSet = danceAnimations;
					nextDanceTime = Time.time + UnityEngine.Random.Range(30f, 60f);
				}
				else
				{
					nextDanceTime = Time.time + 10f;
				}
			}
			float num = UnityEngine.Random.Range(0f, animationSet.TotalProbability);
			float num2 = 0f;
			foreach (AnimationEntry animation in animationSet.Animations)
			{
				num2 += animation.Probability;
				if (num <= num2)
				{
					animation.Probability *= 0.5f;
					animationSet.CalculateTotalProbability();
					return animation;
				}
			}
			return animationSet.Animations.Last();
		}
	}
}
