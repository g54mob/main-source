using System.Collections.Generic;

namespace Gh.Tk
{
	public class RandomChatterAlert : AdvisorAlertBase
	{
		[PersistenceOptIn]
		private List<string> _previousMessageKeys;

		private void FreezeForAFewDays()
		{
		}

		protected override bool TryTriggerInternal()
		{
			return false;
		}
	}
}
