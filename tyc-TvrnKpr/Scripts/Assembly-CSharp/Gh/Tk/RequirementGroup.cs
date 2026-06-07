using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class RequirementGroup : Requirement
	{
		private readonly List<Requirement> _subRequirements;

		private readonly bool _requireAll;

		public static readonly string AnyOfTheseTitle;

		public IEnumerable<Requirement> SubRequirements => null;

		protected RequirementGroup()
		{
		}

		public RequirementGroup(string titleKey, List<Requirement> subRequirements, bool requireAll = true)
		{
		}

		public void AddRequirement(Requirement requirement)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}

		public override void Init()
		{
		}

		protected override void AttachListeners()
		{
		}

		private void OnSubStatusChanged(object sender, EventArgs e)
		{
		}

		protected override void DetachListeners()
		{
		}

		public override bool IsDirty()
		{
			return false;
		}

		protected override void InvalidateInternal()
		{
		}

		public string GetTooltipForGroup(bool onlyListSubRequirements)
		{
			return null;
		}

		public override string GetToolTip()
		{
			return null;
		}
	}
}
