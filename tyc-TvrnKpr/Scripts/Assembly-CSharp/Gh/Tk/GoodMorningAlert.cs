using System.Collections.Generic;

namespace Gh.Tk
{
	public class GoodMorningAlert : AdvisorAlertBase
	{
		[PersistenceOptIn]
		private List<string> _previousMessageKeys;

		public override AdvisorState GetAdvisorState()
		{
			return default(AdvisorState);
		}

		protected override bool TryTriggerInternal()
		{
			return false;
		}
	}
}
