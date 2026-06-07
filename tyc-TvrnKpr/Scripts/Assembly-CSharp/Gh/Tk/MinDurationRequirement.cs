using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class MinDurationRequirement : RequirementGroup
	{
		private bool _areSubRequirementsDone;

		private float _subRequirementsDoneSinceExactDayF;

		private readonly float _days;

		private GlobalTimeController _timeController;

		public override bool IsDone
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		protected override void CheckIfDoneInternal()
		{
		}

		private void SetIsDone(bool done)
		{
		}

		protected MinDurationRequirement()
		{
		}

		public MinDurationRequirement(string titleKey, float days, List<Requirement> subRequirements)
		{
		}

		protected override void AttachListeners()
		{
		}

		protected override void DetachListeners()
		{
		}

		private void OnMinuteChanged(object sender, EventArgs e)
		{
		}
	}
}
