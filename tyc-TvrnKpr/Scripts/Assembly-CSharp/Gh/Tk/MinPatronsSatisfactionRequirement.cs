using System;

namespace Gh.Tk
{
	public class MinPatronsSatisfactionRequirement : Requirement
	{
		private readonly int _minSatisfaction;

		private int _days;

		private int? _fromTier;

		private readonly string _category;

		protected MinPatronsSatisfactionRequirement()
		{
		}

		public MinPatronsSatisfactionRequirement(string titleKey, int minSatisfaction, int? fromTier = null, string category = null)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}

		protected override void AttachListeners()
		{
		}

		private void OnHourChanged(object sender, EventArgs e)
		{
		}

		private void Actor_ActorLeavingTavern(object sender, EventArgs e)
		{
		}

		protected override void DetachListeners()
		{
		}
	}
}
