using Restory.Data.Base;
using Restory.Data.NPCs;
using UnityEngine;

namespace Restory.Gameplay.WorkshopRatings
{
	[CreateAssetMenu(menuName = "Restory/WorkshopRatings/ReviewInfo", fileName = "ReviewInfo - ")]
	public class ReviewInfo : RestoryEntityInfoBase
	{
		[SerializeField]
		private StoryNpcInfo npcInfo;

		[SerializeField]
		private ReviewComment comment;

		[SerializeField]
		private int rating;

		public StoryNpcInfo NpcInfo => npcInfo;

		public ReviewComment Comment => comment;

		public int Rating => rating;
	}
}
