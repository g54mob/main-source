using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/personnaFeedbacks/Yumeko", fileName = "SituationPersonna")]
	public class FeedbackYumeko : SituationnalFeedbackPersonna
	{
		[Serializable]
		private struct AgencyLevel
		{
			public SituationalfeedbackSO situationalfeedbackSO;

			public MapInfoSO level;
		}

		[SerializeField]
		[Foldout("VampireAgency")]
		private MapInfoSO Level01;

		[SerializeField]
		[Foldout("VampireAgency")]
		private MapInfoSO Level02;

		[SerializeField]
		[Foldout("VampireAgency")]
		private MapInfoSO Level03;

		[SerializeField]
		[Foldout("VampireAgency")]
		private MapInfoSO Level04;

		[SerializeField]
		[Foldout("VampireAgency")]
		private MapInfoSO Level05;

		[SerializeField]
		[Foldout("VampireAgency")]
		private MapInfoSO Level06;

		[SerializeField]
		private List<AgencyLevel> AgencyLevelList;

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

		public SituationalfeedbackSO AgencyFeedBack(MapInfoSO obj)
		{
			foreach (AgencyLevel agencyLevel in AgencyLevelList)
			{
				if (agencyLevel.level == obj)
				{
					return agencyLevel.situationalfeedbackSO;
				}
			}
			return null;
		}
	}
}
