using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/personnaFeedbacks/Maeve", fileName = "SituationPersonna")]
	public class FeedbackMaeve : SituationnalFeedbackPersonna
	{
		[SerializeField]
		private int _vigilance;

		[SerializeField]
		private StringKey _stringKey;

		[field: SerializeField]
		public SituationalfeedbackSO RadicalSolution { get; private set; }

		[field: SerializeField]
		public SituationalfeedbackSO Vigilance75 { get; private set; }

		public SituationalfeedbackSO CheckVigilance(int obj)
		{
			if (obj >= _vigilance)
			{
				return Vigilance75;
			}
			return null;
		}

		public SituationalfeedbackSO UnderPanelOpen(StringKey stringKey)
		{
			Debug.Log("Passe here");
			if (stringKey == _stringKey)
			{
				return RadicalSolution;
			}
			Debug.Log("not the same");
			return null;
		}
	}
}
