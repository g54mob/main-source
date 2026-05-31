using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/personnaFeedbacks/Andrea", fileName = "SituationPersonna")]
	public class FeedbackAndrea : SituationnalFeedbackPersonna
	{
		[field: SerializeField]
		[field: Foldout("Money")]
		public MapInfoSO SceneForAlertMoney { get; private set; }

		[field: SerializeField]
		[field: Foldout("Money")]
		public int MoneyLowValue { get; private set; }

		[field: SerializeField]
		[field: Foldout("Money")]
		public int MoneyHighValue { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO HunterRaid { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO Incident { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO MoneyHighLevel5 { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO MoneyLowLevel5 { get; private set; }

		public SituationalfeedbackSO MoneyFeedBack(int obj)
		{
			if (obj < MoneyLowValue && obj > 0)
			{
				return MoneyLowLevel5;
			}
			if (obj > MoneyHighValue)
			{
				return MoneyHighLevel5;
			}
			return null;
		}
	}
}
