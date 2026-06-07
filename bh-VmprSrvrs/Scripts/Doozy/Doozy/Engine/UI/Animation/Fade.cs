using System;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.UI.Animation
{
	[Serializable]
	public class Fade
	{
		public AnimationType AnimationType;

		public bool Enabled;

		public float From;

		public float To;

		public float By;

		public bool UseCustomFromAndTo;

		public int NumberOfLoops;

		public LoopType LoopType;

		public EaseType EaseType;

		public Ease Ease;

		public AnimationCurve AnimationCurve;

		public float StartDelay;

		public float Duration;

		public float TotalDuration => 0f;

		public Fade(AnimationType animationType)
		{
		}

		public Fade(AnimationType animationType, bool enabled, float from, float to, float by, bool useCustomFromAndTo, int numberOfLoops, LoopType loopType, EaseType easeType, Ease ease, AnimationCurve animationCurve, float startDelay, float duration)
		{
		}

		public void Reset(AnimationType animationType)
		{
		}

		public Fade Copy()
		{
			return null;
		}
	}
}
