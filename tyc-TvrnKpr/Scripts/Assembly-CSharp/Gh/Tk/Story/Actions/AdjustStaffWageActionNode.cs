using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh.Tk.Story.Actions
{
	public class AdjustStaffWageActionNode : ConnectedStoryNode
	{
		[Serializable]
		public enum StaffWageActionNodeTarget
		{
			StoryTarget = 0,
			AllStaff = 1,
			RandomStaff = 2
		}

		public StaffWageActionNodeTarget target;

		[FormerlySerializedAs("minChange")]
		[Range(-50f, 100f)]
		public int minChangePercentage;

		[FormerlySerializedAs("maxChange")]
		[Range(-50f, 100f)]
		public int maxChangePercentage;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private void AdjustWage(Staff staff)
		{
		}

		private IEnumerable<Staff> GetTargets(ActiveStory story)
		{
			return null;
		}
	}
}
