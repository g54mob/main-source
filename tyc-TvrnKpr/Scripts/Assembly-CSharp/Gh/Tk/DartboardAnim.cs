using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class DartboardAnim : BaseAnimation
	{
		private Actor _actor;

		public ThrowProjectiles throwProjectilesScript;

		public Transform dartEndPoint;

		public List<string> dartPrefabIdentifier;

		private List<GameObjectX> _dartsSpawned;

		public string dartHolderTransformName;

		private Action _callback;

		private Activity _activity;

		private int _count;

		public override void Animate(Activity activity, Actor actor, Action callback)
		{
		}

		private void AnimationEventObserver_AnimEvent(object sender, AnimationEventArgs e)
		{
		}

		private void InstantiateDartVisual(int dartIndex)
		{
		}

		private void ThrowDartVisual(int dartNumber, bool ignoreDataStore = false)
		{
		}

		private void ThrowDartVisualDone()
		{
		}
	}
}
