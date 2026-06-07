using System;

namespace Gh.Tk
{
	public class MinPatronsPerDayRequirement : Requirement
	{
		private readonly int _minPatrons;

		protected MinPatronsPerDayRequirement()
		{
		}

		public MinPatronsPerDayRequirement(string titleKey, int minPatrons)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}

		protected override void AttachListeners()
		{
		}

		private void OnDayChangedOrActorIsLeaving(object sender, EventArgs e)
		{
		}

		protected override void DetachListeners()
		{
		}
	}
}
