using System;

namespace Restory.Gameplay.WorkshopRatings
{
	[Serializable]
	public struct ReviewSentence
	{
		public string SentenceLocalizationId;

		public ReviewSentenceType Type;

		public bool IsUnique;

		public int Order;
	}
}
