using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/personnaFeedbacks/VonKopek", fileName = "VonKopekFeedbackSO")]
	public class FeedbackVonKopek : SituationnalFeedbackPersonna
	{
		[field: SerializeField]
		[field: Foldout("Money")]
		public int MoneyLowValue { get; private set; }

		[field: SerializeField]
		[field: Foldout("Money")]
		public int MoneyHighValue { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO BankMenu { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO MoneyHigh { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO MoneyLow { get; private set; }

		public SituationalfeedbackSO MoneyFeedBack(int obj)
		{
			if (obj < MoneyLowValue && obj > 0)
			{
				return MoneyLow;
			}
			if (obj > MoneyHighValue)
			{
				return MoneyHigh;
			}
			return null;
		}
	}
}
