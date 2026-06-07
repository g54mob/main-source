using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/personnaFeedbacks/Vladimir", fileName = "SituationPersonna")]
	public class FeedbackVladimir : SituationnalFeedbackPersonna
	{
		[SerializeField]
		private float _moneyHigh;

		[SerializeField]
		private float _moneyLow;

		[field: SerializeField]
		public SituationalfeedbackSO DeadBody { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO MoneyHigh1To3 { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO MoneyLow1To3 { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO Vigilance0 { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO Vigilance50 { get; private set; }

		[field: SerializeField]
		public List<MapInfoSO> LevelForMoney { get; private set; }

		public SituationalfeedbackSO CheckLevel(int Money)
		{
			if ((float)Money < _moneyLow && Money > 0)
			{
				return MoneyLow1To3;
			}
			if ((float)Money > _moneyHigh)
			{
				return MoneyHigh1To3;
			}
			return null;
		}

		public SituationalfeedbackSO CheckVigilance(int vigilance)
		{
			if (vigilance <= 0)
			{
				return Vigilance0;
			}
			if (vigilance >= VigilanceHandlers.MaxVigilance / 2 && (float)vigilance < (float)VigilanceHandlers.MaxVigilance * 0.75f)
			{
				return Vigilance50;
			}
			return null;
		}
	}
}
