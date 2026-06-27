using System;
using Restory.Data.Email;
using Restory.Data.NPCs;
using UnityEngine;

namespace Restory.Gameplay.WorkshopRatings
{
	[Serializable]
	public struct Review
	{
		[SerializeField]
		private StoryNpcInfo npcInfo;

		[SerializeField]
		private EmailContact emailContact;

		[SerializeField]
		private ReviewComment comment;

		[SerializeField]
		private int rating;

		[SerializeField]
		private DateTime reviewDate;

		public readonly StoryNpcInfo NpcInfo => npcInfo;

		public readonly EmailContact EmailContact => emailContact;

		public readonly ReviewComment Comment => comment;

		public readonly int Rating => rating;

		public readonly DateTime ReviewDate => reviewDate;

		public Review(StoryNpcInfo npcInfo, ReviewComment comment, int rating, DateTime reviewDate)
		{
			this.npcInfo = npcInfo;
			emailContact = null;
			this.comment = comment;
			this.rating = Mathf.Clamp(rating, 1, 5);
			this.reviewDate = reviewDate;
		}

		public Review(EmailContact emailContact, ReviewComment comment, int rating, DateTime reviewDate)
		{
			npcInfo = null;
			this.emailContact = emailContact;
			this.comment = comment;
			this.rating = Mathf.Clamp(rating, 1, 5);
			this.reviewDate = reviewDate;
		}

		public readonly Review Copy()
		{
			return new Review
			{
				npcInfo = npcInfo,
				emailContact = emailContact,
				comment = new ReviewComment(comment.Sentences.Clone() as string[]),
				rating = rating,
				reviewDate = reviewDate
			};
		}
	}
}
