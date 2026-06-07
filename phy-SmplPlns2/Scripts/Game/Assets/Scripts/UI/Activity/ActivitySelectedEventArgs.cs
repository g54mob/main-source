using System;

namespace Assets.Scripts.UI.Activity
{
	public class ActivitySelectedEventArgs : EventArgs
	{
		public string ActivityId { get; }

		public ActivitySelectedEventArgs(string activityId)
		{
			ActivityId = activityId;
		}
	}
}
