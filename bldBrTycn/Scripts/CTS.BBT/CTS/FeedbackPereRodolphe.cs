using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/personnaFeedbacks/PereRodolphe", fileName = "SituationPersonna")]
	public class FeedbackPereRodolphe : SituationnalFeedbackPersonna
	{
		[field: SerializeField]
		public SituationalfeedbackSO Vigilance100 { get; private set; }

		public SituationalfeedbackSO CheckVigilance(int vigilance)
		{
			if (vigilance == VigilanceHandlers.MaxVigilance)
			{
				return Vigilance100;
			}
			return null;
		}
	}
}
