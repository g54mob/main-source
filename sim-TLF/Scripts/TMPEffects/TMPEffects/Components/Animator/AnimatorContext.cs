using System;
using TMPEffects.CharacterData;
using TMPEffects.Modifiers;
using UnityEngine;

namespace TMPEffects.Components.Animator
{
	[Serializable]
	internal class AnimatorContext : IAnimatorContext, IAnimatorDataProvider, ICharacterTimingsProvider, IAnimatorTimingsProvider
	{
		[Tooltip("Whether to scale the animations. If true, they will look the same no matter how large or small the individual characters")]
		[SerializeField]
		private bool scaleAnimations = true;

		[Tooltip("Whether to scale the animations uniformly based on the default font size of the TMP_Text component, or on a per character basis.\nIgnored if ScaleAnimations is false")]
		[SerializeField]
		private bool scaleUniformly = true;

		[Tooltip("Whether to use scaled time (instead of real time)")]
		[SerializeField]
		private bool useScaledTime = true;

		[SerializeField]
		[HideInInspector]
		private TMPAnimator tmpAnimator;

		[NonSerialized]
		[HideInInspector]
		public float deltaTime;

		[NonSerialized]
		[HideInInspector]
		public float passed;

		[NonSerialized]
		[HideInInspector]
		public Func<int, float> _StateTime;

		[NonSerialized]
		[HideInInspector]
		public Func<int, float> _VisibleTime;

		public CharDataModifiers Modifiers { get; internal set; }

		public bool ScaleAnimations
		{
			get
			{
				return scaleAnimations;
			}
			internal set
			{
				scaleAnimations = value;
			}
		}

		public bool ScaleUniformly
		{
			get
			{
				return scaleUniformly;
			}
			internal set
			{
				scaleUniformly = value;
			}
		}

		public bool UseScaledTime
		{
			get
			{
				return useScaledTime;
			}
			internal set
			{
				useScaledTime = value;
			}
		}

		public TMPAnimator Animator
		{
			get
			{
				return tmpAnimator;
			}
			internal set
			{
				tmpAnimator = value;
			}
		}

		public float DeltaTime
		{
			get
			{
				return deltaTime;
			}
			internal set
			{
				deltaTime = value;
			}
		}

		public float PassedTime
		{
			get
			{
				return passed;
			}
			internal set
			{
				passed = value;
			}
		}

		public AnimatorContext()
		{
		}

		public AnimatorContext(TMPAnimator animator)
		{
			tmpAnimator = animator;
		}

		public AnimatorContext(TMPAnimator animator, bool scaleAnimations, bool useScaledTime, bool scaleUniformly, Func<int, float> getVisibleTime, Func<int, float> getStateTime)
		{
			tmpAnimator = animator;
			ScaleAnimations = scaleAnimations;
			this.scaleUniformly = scaleUniformly;
			UseScaledTime = useScaledTime;
			deltaTime = 0f;
			passed = 0f;
			_StateTime = getVisibleTime;
			_VisibleTime = getStateTime;
		}

		public float StateTime(CharData cData)
		{
			return _StateTime(cData.info.index);
		}

		public float VisibleTime(CharData cData)
		{
			return _VisibleTime(cData.info.index);
		}

		public float StateTime(int index)
		{
			return _StateTime(index);
		}

		public float VisibleTime(int index)
		{
			return _VisibleTime(index);
		}
	}
}
