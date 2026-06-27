using System;
using System.Collections.Generic;
using Restory.Data.Email;
using Restory.Data.NPCs;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.TimeSystems;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkshopRatings
{
	public class WorkshopRatingsService : MonoBehaviour, ISerializationCallbackReceiver, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private List<Review> reviews = new List<Review>();

		private readonly int[] reviewsCountByStarsCache = new int[5];

		private float overallRating;

		private int totalRating;

		private bool hasForcedRating;

		private float forcedRating;

		private GameCalendar gameCalendar;

		public float OverallRating
		{
			get
			{
				if (!hasForcedRating)
				{
					return overallRating;
				}
				return forcedRating;
			}
		}

		public float ForcedRating => forcedRating;

		public int ReviewsCount => reviews.Count;

		public IReadOnlyList<Review> Reviews => reviews;

		public bool HasForcedRating => hasForcedRating;

		public event Action<WorkshopRatingsService> OnRatingChanged;

		[Inject]
		private void Construct(GameCalendar gameCalendar)
		{
			this.gameCalendar = gameCalendar;
		}

		public void AddReview(StoryNpcInfo npcInfo, ReviewComment comment, int rating)
		{
			AddReview(npcInfo, comment, rating, gameCalendar.CurrentDateTime);
		}

		public void AddReview(StoryNpcInfo npcInfo, ReviewComment comment, int rating, DateTime reviewDate)
		{
			rating = Mathf.Clamp(rating, 1, 5);
			Review item = new Review(npcInfo, comment, rating, reviewDate);
			reviews.Add(item);
			reviewsCountByStarsCache[rating - 1]++;
			totalRating += rating;
			overallRating = (float)totalRating / (float)reviews.Count;
			this.OnRatingChanged?.Invoke(this);
		}

		public void AddReview(EmailContact emailContact, ReviewComment comment, int rating)
		{
			AddReview(emailContact, comment, rating, gameCalendar.CurrentDateTime);
		}

		public void AddReview(EmailContact emailContact, ReviewComment comment, int rating, DateTime reviewDate)
		{
			rating = Mathf.Clamp(rating, 1, 5);
			Review item = new Review(emailContact, comment, rating, reviewDate);
			reviews.Add(item);
			reviewsCountByStarsCache[rating - 1]++;
			totalRating += rating;
			overallRating = (float)totalRating / (float)reviews.Count;
			this.OnRatingChanged?.Invoke(this);
		}

		public bool RemoveReviewAt(int index)
		{
			if (index < 0 || index >= reviews.Count)
			{
				return false;
			}
			int rating = reviews[index].Rating;
			reviews.RemoveAt(index);
			if (reviews.Count == 0)
			{
				Array.Clear(reviewsCountByStarsCache, 0, reviewsCountByStarsCache.Length);
				totalRating = 0;
				overallRating = 0f;
				this.OnRatingChanged?.Invoke(this);
				return true;
			}
			reviewsCountByStarsCache[rating - 1]--;
			totalRating -= rating;
			overallRating = (float)totalRating / (float)reviews.Count;
			this.OnRatingChanged?.Invoke(this);
			return true;
		}

		public void ClearReviews()
		{
			if (reviews.Count != 0)
			{
				reviews.Clear();
				Array.Clear(reviewsCountByStarsCache, 0, reviewsCountByStarsCache.Length);
				totalRating = 0;
				overallRating = 0f;
				this.OnRatingChanged?.Invoke(this);
			}
		}

		public int GetReviewsCountByStars(int stars)
		{
			if (stars < 1 || stars > 5)
			{
				return 0;
			}
			return reviewsCountByStarsCache[stars - 1];
		}

		public void SetForcedRating(float rating)
		{
			rating = Mathf.Clamp(rating, 1f, 5f);
			bool num = !hasForcedRating || !Mathf.Approximately(forcedRating, rating);
			hasForcedRating = true;
			forcedRating = rating;
			if (num)
			{
				this.OnRatingChanged?.Invoke(this);
			}
		}

		public bool RemoveForcedRating()
		{
			if (!hasForcedRating)
			{
				return false;
			}
			hasForcedRating = false;
			forcedRating = 0f;
			this.OnRatingChanged?.Invoke(this);
			return true;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			RebuildCacheFromReviews();
		}

		private void RebuildCacheFromReviews()
		{
			Array.Clear(reviewsCountByStarsCache, 0, reviewsCountByStarsCache.Length);
			totalRating = 0;
			for (int i = 0; i < reviews.Count; i++)
			{
				int rating = reviews[i].Rating;
				reviewsCountByStarsCache[rating - 1]++;
				totalRating += rating;
			}
			overallRating = ((reviews.Count > 0) ? ((float)totalRating / (float)reviews.Count) : 0f);
		}

		public object CaptureState()
		{
			try
			{
				WorkshopRatingsServiceSaveData.ReviewSaveData[] array = new WorkshopRatingsServiceSaveData.ReviewSaveData[reviews.Count];
				for (int i = 0; i < reviews.Count; i++)
				{
					Review review = reviews[i];
					array[i] = new WorkshopRatingsServiceSaveData.ReviewSaveData
					{
						NpcInfo = review.NpcInfo,
						EmailContact = review.EmailContact,
						Sentences = review.Comment.Sentences,
						Rating = review.Rating,
						ReviewDate = review.ReviewDate
					};
				}
				return new WorkshopRatingsServiceSaveData
				{
					Reviews = array,
					HasForcedRating = hasForcedRating,
					ForcedRating = forcedRating
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				WorkshopRatingsServiceSaveData workshopRatingsServiceSaveData = DataMigrationWizard.Migrate<WorkshopRatingsServiceSaveData>(state, base.gameObject);
				reviews.Clear();
				WorkshopRatingsServiceSaveData.ReviewSaveData[] array = workshopRatingsServiceSaveData.Reviews;
				foreach (WorkshopRatingsServiceSaveData.ReviewSaveData reviewSaveData in array)
				{
					if (reviewSaveData.NpcInfo != null)
					{
						reviews.Add(new Review(reviewSaveData.NpcInfo, new ReviewComment(reviewSaveData.Sentences), reviewSaveData.Rating, reviewSaveData.ReviewDate));
					}
					else if (reviewSaveData.EmailContact != null)
					{
						reviews.Add(new Review(reviewSaveData.EmailContact, new ReviewComment(reviewSaveData.Sentences), reviewSaveData.Rating, reviewSaveData.ReviewDate));
					}
				}
				RebuildCacheFromReviews();
				if (workshopRatingsServiceSaveData.HasForcedRating)
				{
					hasForcedRating = true;
					forcedRating = Mathf.Clamp(workshopRatingsServiceSaveData.ForcedRating, 1f, 5f);
				}
				else
				{
					hasForcedRating = false;
					forcedRating = 0f;
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
