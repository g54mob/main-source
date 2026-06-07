using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public static class Activities_Animation
	{
		public static Activity Play(string animation, GameObjectX target = null, bool autoStop = true, GameItem item = null, Action finishAction = null, float maxTime = -1f)
		{
			return null;
		}

		public static Activity Play(IEnumerable<string> animations, GameObjectX target = null, bool autoStop = true, GameItem item = null, Action initAction = null, Action finishAction = null, Action<Activity> propOnFireInterruptAction = null)
		{
			return null;
		}

		public static Activity Play(IEnumerable<string> animations, float duration, GameObjectX target, GameItem item = null, Action<int> progressCallback = null, Func<bool> condition = null, Action finishAction = null, Action tickCallback = null)
		{
			return null;
		}

		public static Activity SetBoolAndWaitForFinishedEvent(string animation, bool value, GameObjectX target = null, Action initAction = null, Action finishAction = null)
		{
			return null;
		}
	}
}
