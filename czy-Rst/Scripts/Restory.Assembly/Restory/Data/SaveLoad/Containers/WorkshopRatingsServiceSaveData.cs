using System;
using Restory.Data.Email;
using Restory.Data.NPCs;

namespace Restory.Data.SaveLoad.Containers
{
	[Serializable]
	public class WorkshopRatingsServiceSaveData
	{
		[Serializable]
		public class ReviewSaveData
		{
			public StoryNpcInfo NpcInfo { get; set; }

			public EmailContact EmailContact { get; set; }

			public string[] Sentences { get; set; }

			public int Rating { get; set; }

			public DateTime ReviewDate { get; set; }
		}

		public ReviewSaveData[] Reviews { get; set; }

		public bool HasForcedRating { get; set; }

		public float ForcedRating { get; set; }
	}
}
