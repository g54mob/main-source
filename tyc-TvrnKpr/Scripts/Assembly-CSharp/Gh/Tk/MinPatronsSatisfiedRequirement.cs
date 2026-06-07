using System;

namespace Gh.Tk
{
	public class MinPatronsSatisfiedRequirement : Requirement
	{
		private readonly int _minPatrons;

		private readonly int? _tier;

		private readonly string _category;

		protected MinPatronsSatisfiedRequirement()
		{
		}

		public MinPatronsSatisfiedRequirement(string titleKey, int minPatrons, int? tier = null, string category = null)
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

		private void Actor_ActorLeavingTavern(object sender, EventArgs<Actor> e)
		{
		}

		protected override void DetachListeners()
		{
		}
	}
}
