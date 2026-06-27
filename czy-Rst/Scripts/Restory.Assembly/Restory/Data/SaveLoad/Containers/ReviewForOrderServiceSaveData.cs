using System;
using Restory.Gameplay.WorkshopRatings;

namespace Restory.Data.SaveLoad.Containers
{
	public class ReviewForOrderServiceSaveData
	{
		[Serializable]
		public struct AvailableSentenceData
		{
			public ReviewSentenceType Type;

			public int Order;

			public string SentenceLocalizationId;
		}

		public AvailableSentenceData[] AvailableSentences;

		public int ReviewBagRemainingDraws;

		public int ReviewBagRemainingSuccesses;
	}
}
