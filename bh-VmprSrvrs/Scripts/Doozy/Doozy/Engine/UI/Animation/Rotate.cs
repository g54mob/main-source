using System;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.UI.Animation
{
	[Serializable]
	public class Rotate
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

		public RotateMode RotateMode;

		public EaseType EaseType;

		public Ease Ease;

		public AnimationCurve AnimationCurve;

		public float StartDelay;

		public float Duration;

		public float TotalDuration => 0f;

		public Rotate(AnimationType animationType)
		{
		}

		public Rotate(AnimationType animationType, bool enabled, Vector3 from, Vector3 to, Vector3 by, bool useCustomFromAndTo, int vibrato, float elasticity, int numberOfLoops, LoopType loopType, RotateMode rotateMode, EaseType easeType, Ease ease, AnimationCurve animationCurve, float startDelay, float duration)
		{
		}

		public void Reset(AnimationType animationType)
		{
		}

		public Rotate Copy()
		{
			return null;
		}
	}
}
