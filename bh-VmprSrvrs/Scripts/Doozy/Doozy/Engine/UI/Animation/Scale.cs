using System;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.UI.Animation
{
	[Serializable]
	public class Scale
	{
		public AnimationType AnimationType;

		public bool Enabled;

		public Vector3 From;

		public Vector3 To;

		public Vector3 By;

		public bool UseCustomFromAndTo;

		public int Vibrato;

		public float Elasticity;

		public int NumberOfLoops;

		public LoopType LoopType;

		public EaseType EaseType;

		public Ease Ease;

		public AnimationCurve AnimationCurve;

		public float StartDelay;

		public float Duration;

		public float TotalDuration => 0f;

		public Scale(AnimationType animationType)
		{
		}

		public Scale(AnimationType animationType, bool enabled, Vector3 from, Vector3 to, Vector3 by, bool useCustomFromAndTo, int vibrato, float elasticity, int numberOfLoops, LoopType loopType, EaseType easeType, Ease ease, AnimationCurve animationCurve, float startDelay, float duration)
		{
		}

		public void Reset(AnimationType animationType)
		{
		}

		public Scale Copy()
		{
			return null;
		}
	}
}
