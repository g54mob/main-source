using System;
using UnityEngine;

namespace Gh.Tk
{
	public abstract class BaseAnimation : MonoBehaviour
	{
		protected Actor _currentActor;

		public string key;

		public abstract void Animate(Activity activity, Actor actor, Action finishedCallback);
	}
}
