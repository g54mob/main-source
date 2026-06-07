using System;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class BaseAnimationOld : MonoBehaviour
	{
		public string key;

		protected Actor _currentActor;

		public abstract void Animate(Activity activity, Actor actor, Action finishedCallback, float duration = 4f, Func<bool> endCondition = null, Action pausedCallback = null);
	}
}
