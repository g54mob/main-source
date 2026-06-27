using Helpers.Ranges;
using Restory.Data.Tables.Balances;
using UnityEngine;

namespace Restory.Data.Email
{
	[CreateAssetMenu(menuName = "Restory/Email/EmailSettings", fileName = "EmailSettings")]
	public class EmailSettings : ScriptableObject, IGameBalanceEntity
	{
		[SerializeField]
		private IntRange dailyOrdersRange;

		[SerializeField]
		private int mailCheckingIntervalInGameMinutes = 5;

		[SerializeField]
		private string orderSubjectLocalizationKey;

		[SerializeField]
		private string subjectNameLocalizationKey;

		[SerializeField]
		private int initialEmailOrdersCount = 1;

		[SerializeField]
		[Min(0f)]
		private int numberDaysToComplete = 3;

		public IntRange DailyOrdersRange => dailyOrdersRange;

		public int MailCheckingIntervalInGameMinutes => mailCheckingIntervalInGameMinutes;

		public string SubjectNameLocalizationKey => subjectNameLocalizationKey;

		public string OrderSubjectLocalizationKey => orderSubjectLocalizationKey;

		public int InitialEmailOrdersCount => initialEmailOrdersCount;

		public int NumberDaysToComplete => numberDaysToComplete;
	}
}
