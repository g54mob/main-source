using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.Progress
{
	[AddComponentMenu("Doozy/Progress/Progressor", 13)]
	[DefaultExecutionOrder(-100)]
	public class Progressor : MonoBehaviour
	{
		public const float TOLERANCE = 0.001f;

		public const bool DEFAULT_ANIMATE_VALUE = false;

		public const float DEFAULT_DURATION = 0.5f;

		public const Ease DEFAULT_EASE = Ease.Linear;

		public const bool DEFAULT_IGNORE_UNITY_TIMESCALE = true;

		public bool DebugMode;

		public List<ProgressTarget> ProgressTargets;

		public bool AnimateValue;

		public float AnimationDuration;

		public Ease AnimationEase;

		public bool AnimationIgnoresUnityTimescale;

		public ResetValue OnEnableResetValue;

		public ResetValue OnDisableResetValue;

		public float CustomResetValue;

		public ProgressEvent OnValueChanged;

		public ProgressEvent OnProgressChanged;

		public ProgressEvent OnInverseProgressChanged;

		[SerializeField]
		private float m_minValue;

		[SerializeField]
		private float m_maxValue;

		[SerializeField]
		private bool m_wholeNumbers;

		[SerializeField]
		private float m_currentValue;

		private float m_previousValue;

		private Sequence m_animationSequence;

		private float m_value;

		private float m_progress;

		private float m_inverseProgress;

		private bool m_updatePreviousValue;

		private Tweener m_tween;

		private bool m_tweenInitialized;

		public float Progress => 0f;

		public float InverseProgress => 0f;

		public float Value
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public float MinValue
		{
			get
			{
				return 0f;
			}
			protected set
			{
			}
		}

		public float MaxValue
		{
			get
			{
				return 0f;
			}
			protected set
			{
			}
		}

		public bool WholeNumbers => false;

		private bool DebugComponent => false;

		private string GetAnimationId => null;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void OnValueUpdated()
		{
		}

		public void UpdateProgressTargets()
		{
		}

		public void SetValue(float value)
		{
		}

		public void InstantSetValue(float value)
		{
		}

		public void SetValue(float value, bool instantUpdate)
		{
		}

		public void SetProgress(float progressValue)
		{
		}

		public void InstantSetProgress(float progressValue)
		{
		}

		public void SetProgress(float progressValue, bool instantUpdate)
		{
		}

		public float GetProgress(TargetProgress direction)
		{
			return 0f;
		}

		public void UpdateProgress()
		{
		}

		public void SetMin(float value)
		{
		}

		public void SetMax(float value)
		{
		}

		public void EnableWholeNumbers()
		{
		}

		public void DisableWholeNumbers()
		{
		}

		public void ResetValueTo(ResetValue resetValue)
		{
		}

		public void ResetValueTo(ResetValue resetValue, bool instantUpdate)
		{
		}

		public float ClampValueBetweenMinAndMax(float value, bool roundValue = false)
		{
			return 0f;
		}

		public Tweener GetAnimationTween(float targetValue, float duration, Ease ease, bool ignoreTimescale)
		{
			return null;
		}

		public void StopAnimation(bool complete = false)
		{
		}

		private void KillAnimation(bool complete = false)
		{
		}

		private void KillTweener(bool complete = false)
		{
		}

		private static float RoundValue(float value)
		{
			return 0f;
		}

		private static Progressor AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
