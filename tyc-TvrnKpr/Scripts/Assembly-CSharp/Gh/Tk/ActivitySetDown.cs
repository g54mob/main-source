using System;
using UnityEngine;

namespace Gh.Tk
{
	public static class ActivitySetDown
	{
		public static Activity CreateSetDownActivity(Actor actor, GameItem itemToSetDown, bool storeInLarder, Transform target, Transform tweenToTarget = null, int position = -1, Action callback = null, string usage = "setdown", Action finishAction = null, AccessPoint tap = null, bool logError = true)
		{
			return null;
		}

		public static bool TrySnap(GameObject visual, Transform target, GameObjectX gox)
		{
			return false;
		}

		private static void SetDown(Actor actor, GameItem item, Transform target, bool putintoStorage)
		{
		}
	}
}
