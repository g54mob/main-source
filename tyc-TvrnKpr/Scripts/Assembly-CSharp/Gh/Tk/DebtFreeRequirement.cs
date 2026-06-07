using System;

namespace Gh.Tk
{
	public class DebtFreeRequirement : Requirement
	{
		protected DebtFreeRequirement()
		{
		}

		public DebtFreeRequirement(string titleKey, string category = null)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}

		protected override void AttachListeners()
		{
		}

		private void OnLoanChanged(object sender, EventArgs e)
		{
		}

		protected override void DetachListeners()
		{
		}
	}
}
