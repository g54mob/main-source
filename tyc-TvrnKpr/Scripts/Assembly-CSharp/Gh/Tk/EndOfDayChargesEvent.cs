using System.Collections.Generic;
using System.Text;
using LitJson;

namespace Gh.Tk
{
	public class EndOfDayChargesEvent : GameEvent
	{
		[JsonIgnore]
		private TooltipData _nestedTooltip;

		[PersistenceOptIn]
		private Dictionary<string, float> _taxesToPay;

		public override bool ShowOnTimeline => false;

		public override string TimelineTitleKey => null;

		public static void Init()
		{
		}

		private static EndOfDayChargesEvent SetupNextPaymentEvent()
		{
			return null;
		}

		protected override string GetHeaderWithLinkedTextblockKey()
		{
			return null;
		}

		public override void Trigger()
		{
		}

		private int PayFees(bool onlySimulate, StringBuilder sb = null)
		{
			return 0;
		}

		public void RegisterTaxRelevantTransaction(string category, int amount)
		{
		}
	}
}
