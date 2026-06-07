using System;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class RotateAnimation : BaseAnimationOld
	{
		public Transform target;

		public Vector3 angles;

		public float duration;

		public RotateMode rotateMode;

		public bool UseAnimationCurve;

		public AnimationCurve animationCurve;

		public Ease Ease;

		public override void Animate(Activity activity, Actor actor, Action finishedCallback, float overrideDuration = 0f, Func<bool> endCondition = null, Action pausedCallback = null)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
