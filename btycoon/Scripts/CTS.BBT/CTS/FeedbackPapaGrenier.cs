using System;
using System.Collections.Generic;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/personnaFeedbacks/PapaGrenier", fileName = "SituationPersonna")]
	public class FeedbackPapaGrenier : SituationnalFeedbackPersonna
	{
		[Serializable]
		private struct StructStringkey
		{
			public SituationalfeedbackSO situationalfeedbackSO;

			public StringKey stringKey;
		}

		[SerializeField]
		private List<StructStringkey> _structStringkeysList = new List<StructStringkey>();

		[field: SerializeField]
		[field: Foldout("Tech")]
		public SituationalfeedbackSO Point100 { get; private set; }

		[field: SerializeField]
		[field: Foldout("Tech")]
		public SituationalfeedbackSO Point200 { get; private set; }

		[field: SerializeField]
		[field: Foldout("Tech")]
		public SituationalfeedbackSO NewTech { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO NegativeMoney { get; private set; }

		[field: SerializeField]
		[field: Foldout("Money")]
		public SituationalfeedbackSO MoneyHighLevel4 { get; private set; }

		[field: SerializeField]
		[field: Foldout("Money")]
		public SituationalfeedbackSO MoneyLowLevel4 { get; private set; }

		[field: SerializeField]
		[field: Foldout("Money")]
		public MapInfoSO SceneForAlertMoney { get; private set; }

		[field: SerializeField]
		[field: Foldout("Money")]
		public int MoneyLowValue { get; private set; }

		[field: SerializeField]
		[field: Foldout("Money")]
		public int MoneyHighValue { get; private set; }

		public SituationalfeedbackSO CheckTechnoPoints(int Point)
		{
			if (Point >= 100 && Point < 200)
			{
				return Point100;
			}
			if (Point >= 200)
			{
				return Point200;
			}
			return null;
		}

		public SituationalfeedbackSO MoneyFeedBack(int obj)
		{
			if (obj < MoneyLowValue && obj > 0)
			{
				return MoneyLowLevel4;
			}
			if (obj > MoneyHighValue)
			{
				return MoneyHighLevel4;
			}
			return null;
		}

		public SituationalfeedbackSO UnderPanelOpen(StringKey stringKey)
		{
			foreach (StructStringkey structStringkeys in _structStringkeysList)
			{
				if (structStringkeys.stringKey == stringKey)
				{
					return structStringkeys.situationalfeedbackSO;
				}
			}
			return null;
		}
	}
}
