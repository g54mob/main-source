using System;
using UnityEngine;

namespace Gh.Tk
{
	public class TweenPositionAnimation : BaseAnimationOld
	{
		public Transform target;

		public Vector3 targetPosition;

		public float duration;

		public bool local;

		public override void Animate(Activity activity, Actor actor, Action finishedCallback, float overrideDuration = 0f, Func<bool> endCondition = null, Action pausedCallback = null)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
