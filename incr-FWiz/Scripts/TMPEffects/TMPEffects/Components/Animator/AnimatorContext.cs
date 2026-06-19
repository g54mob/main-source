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
		private bool scaleAnimations;

		[Tooltip("Whether to scale the animations uniformly based on the default font size of the TMP_Text component, or on a per character basis.\nIgnored if ScaleAnimations is false")]
		[SerializeField]
		private bool scaleUniformly;

		[Tooltip("Whether to use scaled time (instead of real time)")]
		[SerializeField]
		private bool useScaledTime;

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
				return false;
			}
			internal set
			{
			}
		}

		public bool ScaleUniformly
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public bool UseScaledTime
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public TMPAnimator Animator
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public float DeltaTime
		{
			get
			{
				return 0f;
			}
			internal set
			{
			}
		}

		public float PassedTime
		{
			get
			{
				return 0f;
			}
			internal set
			{
			}
		}

		public AnimatorContext()
		{
		}

		public AnimatorContext(TMPAnimator animator)
		{
		}

		public AnimatorContext(TMPAnimator animator, bool scaleAnimations, bool useScaledTime, bool scaleUniformly, Func<int, float> getVisibleTime, Func<int, float> getStateTime)
		{
		}

		public float StateTime(CharData cData)
		{
			return 0f;
		}

		public float VisibleTime(CharData cData)
		{
			return 0f;
		}

		public float StateTime(int index)
		{
			return 0f;
		}

		public float VisibleTime(int index)
		{
			return 0f;
		}
	}
}
