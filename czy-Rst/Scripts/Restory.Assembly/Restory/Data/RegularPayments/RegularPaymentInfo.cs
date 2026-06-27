using Restory.Data.InteractiveObjects;
using Restory.Data.NPCs;
using UnityEngine;

namespace Restory.Data.RegularPayments
{
	[CreateAssetMenu(fileName = "RegularPaymentInfo", menuName = "Restory/Money/RegularPaymentInfo")]
	public class RegularPaymentInfo : InteractiveObjectInfo
	{
		[SerializeField]
		private int sum;

		[SerializeField]
		[Min(1f)]
		private int daysBeforeNextPayment;

		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private int orderInGUI;

		[SerializeField]
		private StoryNpcInfo npcWhoDeliversPayment;

		[SerializeField]
		[Min(0f)]
		private int daysForPayment = 7;

		public int Sum => sum;

		public int DaysBeforeNextPayment => daysBeforeNextPayment;

		public string NameLocalizationKey => nameLocalizationKey;

		public int OrderInGUI => orderInGUI;

		public StoryNpcInfo NpcWhoDeliversPayment => npcWhoDeliversPayment;

		public int DaysForPayment => daysForPayment;
	}
}
