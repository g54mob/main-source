using UnityEngine;

namespace Gh.Tk
{
	public class ActivityAlignWith : Activity
	{
		private Transform _targetTransform;

		public ActivityAlignWith(Transform transform)
		{
		}

		public override void Init()
		{
		}

		public override ActivityState Tick()
		{
			return default(ActivityState);
		}

		public override string GetLogInfo()
		{
			return null;
		}
	}
}
