using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/personnaFeedbacks/Sophie", fileName = "SophieFeedbackSO")]
	public class FeedbackSophie : SituationnalFeedbackPersonna
	{
		[field: SerializeField]
		public int DayBeforeAlertPrestige1 { get; private set; }

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
		[field: Foldout("SO")]
		public SituationalfeedbackSO PrestigeDown { get; private set; }

		[field: SerializeField]
		[field: Foldout("SO")]
		public SituationalfeedbackSO PrestigeStagnant { get; private set; }

		[field: SerializeField]
		[field: Foldout("SO")]
		public SituationalfeedbackSO PrestigeUp { get; private set; }

		[field: SerializeField]
		[field: Foldout("SO")]
		public SituationalfeedbackSO Table { get; private set; }

		[field: SerializeField]
		[field: Foldout("SO")]
		public SituationalfeedbackSO MoneyHighLevel5 { get; private set; }

		[field: SerializeField]
		[field: Foldout("SO")]
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

		public SituationalfeedbackSO CalendarHandlers_NewDay(int DayPrestigeOne)
		{
			if (MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel.Level > 1)
			{
				return null;
			}
			if (DayPrestigeOne < DayBeforeAlertPrestige1)
			{
				return null;
			}
			return PrestigeStagnant;
		}
	}
}
