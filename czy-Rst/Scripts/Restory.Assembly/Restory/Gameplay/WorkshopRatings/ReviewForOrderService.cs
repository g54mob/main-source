using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Email;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.EmailSystems;
using Restory.Gameplay.Metrics;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkshopRatings
{
	public class ReviewForOrderService : MonoBehaviour, IInitializable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		public enum ComfortLevel
		{
			Uncomfortable = 0,
			Neutral = 1,
			Comfortable = 2
		}

		[SerializeField]
		private ReviewForOrderServiceSettings settings;

		private const int BASE_RATING = 3;

		private readonly Dictionary<ReviewSentenceType, SortedDictionary<int, List<string>>> availableSentences = new Dictionary<ReviewSentenceType, SortedDictionary<int, List<string>>>();

		private MetricsService metricsService;

		private EmailOrdersService emailOrdersService;

		private WorkshopRatingsService workshopRatingsService;

		private int reviewBagRemainingDraws;

		private int reviewBagRemainingSuccesses;

		[Inject]
		private void Construct(MetricsService metricsService, EmailOrdersService emailOrdersService, WorkshopRatingsService workshopRatingsService)
		{
			this.metricsService = metricsService;
			this.emailOrdersService = emailOrdersService;
			this.workshopRatingsService = workshopRatingsService;
		}

		public void Initialize()
		{
			emailOrdersService.OnOrderShipped += ResolveOnOrderShipped;
			RefreshAllQueues();
		}

		public void Dispose()
		{
			emailOrdersService.OnOrderShipped -= ResolveOnOrderShipped;
		}

		private void RefreshAllQueues()
		{
			availableSentences.Clear();
			FillReviews(settings.Sentences);
		}

		private void RefreshWithoutUnique(ReviewSentenceType type)
		{
			if (availableSentences.ContainsKey(type))
			{
				availableSentences[type].Clear();
			}
			IEnumerable<ReviewSentence> source = settings.Sentences.Where((ReviewSentence r) => r.Type == type && !r.IsUnique);
			FillReviews(source);
		}

		private void FillReviews(IEnumerable<ReviewSentence> source)
		{
			foreach (ReviewSentence item in source)
			{
				if (!availableSentences.ContainsKey(item.Type))
				{
					availableSentences[item.Type] = new SortedDictionary<int, List<string>>();
				}
				SortedDictionary<int, List<string>> sortedDictionary = availableSentences[item.Type];
				if (!sortedDictionary.ContainsKey(item.Order))
				{
					sortedDictionary[item.Order] = new List<string>();
				}
				sortedDictionary[item.Order].Add(item.SentenceLocalizationId);
			}
		}

		private void ResolveOnOrderShipped(EmailLetterOrderRecord orderRecord)
		{
			if (ShouldGenerateReview())
			{
				EmailContact senderContactInfo = orderRecord.SenderContactInfo;
				ComfortLevel comfortLevel = GetComfortLevel();
				bool isOverdueOrder = emailOrdersService.IsOverdueOrder(orderRecord);
				AddGeneratedReview(senderContactInfo, comfortLevel, isOverdueOrder);
			}
		}

		public void AddGeneratedReview(EmailContact emailContact, ComfortLevel comfortLevel, bool isOverdueOrder)
		{
			int rating = CalculateRatingForOrder(isOverdueOrder, comfortLevel);
			ReviewComment comment = GetComment(isOverdueOrder, comfortLevel);
			workshopRatingsService.AddReview(emailContact, comment, rating);
		}

		private bool ShouldGenerateReview()
		{
			float reviewChance = settings.ReviewChance;
			EnsureReviewBag(reviewChance);
			if (reviewBagRemainingDraws <= 0)
			{
				return false;
			}
			bool num = UnityEngine.Random.Range(0, reviewBagRemainingDraws) < reviewBagRemainingSuccesses;
			reviewBagRemainingDraws--;
			if (num)
			{
				reviewBagRemainingSuccesses--;
			}
			return num;
		}

		private void EnsureReviewBag(float baseChance)
		{
			if (reviewBagRemainingDraws <= 0)
			{
				int num = Mathf.Max(1, settings.ReviewBagSize);
				int value = Mathf.RoundToInt(baseChance * (float)num);
				reviewBagRemainingDraws = num;
				reviewBagRemainingSuccesses = Mathf.Clamp(value, 0, num);
			}
		}

		private ComfortLevel GetComfortLevel()
		{
			if (workshopRatingsService.HasForcedRating && workshopRatingsService.ForcedRating <= 3f)
			{
				return ComfortLevel.Uncomfortable;
			}
			int points = metricsService.GetPoints(settings.ComfortMetricInfo);
			if (points >= settings.Comfort)
			{
				return ComfortLevel.Comfortable;
			}
			if (points <= 0)
			{
				return ComfortLevel.Uncomfortable;
			}
			return ComfortLevel.Neutral;
		}

		private int CalculateRatingForOrder(bool isOverdueOrder, ComfortLevel comfortLevel)
		{
			if (workshopRatingsService.HasForcedRating)
			{
				return Mathf.RoundToInt(workshopRatingsService.ForcedRating);
			}
			int num = ((!isOverdueOrder) ? 1 : (-1));
			return Mathf.Clamp(3 + num + comfortLevel switch
			{
				ComfortLevel.Uncomfortable => -1, 
				ComfortLevel.Comfortable => 1, 
				_ => 0, 
			}, 1, 5);
		}

		private ReviewComment GetComment(bool isOverdueOrder, ComfortLevel comfortLevel)
		{
			ReviewSentenceType type = (isOverdueOrder ? ReviewSentenceType.WorkNegative : ReviewSentenceType.WorkPositive);
			ReviewSentenceType type2 = ((comfortLevel == ComfortLevel.Comfortable) ? ReviewSentenceType.ZenPositive : ReviewSentenceType.ZenNegative);
			string sentence = GetSentence(type);
			string sentence2 = GetSentence(type2);
			return new ReviewComment(sentence, sentence2);
		}

		private string GetSentence(ReviewSentenceType type)
		{
			if (!availableSentences.ContainsKey(type) || availableSentences[type].Count == 0)
			{
				RefreshWithoutUnique(type);
			}
			if (!availableSentences.ContainsKey(type) || availableSentences[type].Count == 0)
			{
				return string.Empty;
			}
			SortedDictionary<int, List<string>> sortedDictionary = availableSentences[type];
			int key = sortedDictionary.Keys.First();
			List<string> list = sortedDictionary[key];
			int index = UnityEngine.Random.Range(0, list.Count);
			string result = list[index];
			list.RemoveAt(index);
			if (list.Count == 0)
			{
				sortedDictionary.Remove(key);
			}
			return result;
		}

		public object CaptureState()
		{
			try
			{
				List<ReviewForOrderServiceSaveData.AvailableSentenceData> list = new List<ReviewForOrderServiceSaveData.AvailableSentenceData>();
				foreach (var (type, sortedDictionary2) in availableSentences)
				{
					foreach (var (order, list3) in sortedDictionary2)
					{
						foreach (string item in list3)
						{
							list.Add(new ReviewForOrderServiceSaveData.AvailableSentenceData
							{
								Type = type,
								Order = order,
								SentenceLocalizationId = item
							});
						}
					}
				}
				return new ReviewForOrderServiceSaveData
				{
					AvailableSentences = list.ToArray(),
					ReviewBagRemainingDraws = reviewBagRemainingDraws,
					ReviewBagRemainingSuccesses = reviewBagRemainingSuccesses
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
				ReviewForOrderServiceSaveData reviewForOrderServiceSaveData = DataMigrationWizard.Migrate<ReviewForOrderServiceSaveData>(state, base.gameObject);
				availableSentences.Clear();
				int max = Mathf.Max(1, settings.ReviewBagSize);
				reviewBagRemainingDraws = Mathf.Clamp(reviewForOrderServiceSaveData.ReviewBagRemainingDraws, 0, max);
				reviewBagRemainingSuccesses = Mathf.Clamp(reviewForOrderServiceSaveData.ReviewBagRemainingSuccesses, 0, reviewBagRemainingDraws);
				ReviewForOrderServiceSaveData.AvailableSentenceData[] array = reviewForOrderServiceSaveData.AvailableSentences;
				for (int i = 0; i < array.Length; i++)
				{
					ReviewForOrderServiceSaveData.AvailableSentenceData availableSentenceData = array[i];
					if (!availableSentences.ContainsKey(availableSentenceData.Type))
					{
						availableSentences[availableSentenceData.Type] = new SortedDictionary<int, List<string>>();
					}
					SortedDictionary<int, List<string>> sortedDictionary = availableSentences[availableSentenceData.Type];
					if (!sortedDictionary.ContainsKey(availableSentenceData.Order))
					{
						sortedDictionary[availableSentenceData.Order] = new List<string>();
					}
					sortedDictionary[availableSentenceData.Order].Add(availableSentenceData.SentenceLocalizationId);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}
	}
}
