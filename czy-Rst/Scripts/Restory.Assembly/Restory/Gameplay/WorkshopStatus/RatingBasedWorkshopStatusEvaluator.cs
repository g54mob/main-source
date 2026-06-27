using System;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.WorkshopRatings;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkshopStatus
{
	public sealed class RatingBasedWorkshopStatusEvaluator : WorkshopStatusEvaluatorBase
	{
		[Serializable]
		public struct ReviewsThresholdRow
		{
			[SerializeField]
			[Min(0f)]
			private int requiredReviewsCount;

			[SerializeField]
			private RatingThreshold[] thresholds;

			public readonly int RequiredReviewsCount => requiredReviewsCount;

			public readonly RatingThreshold[] Thresholds => thresholds;
		}

		[Serializable]
		public struct RatingThreshold
		{
			[SerializeField]
			[Min(0f)]
			private float requiredRating;

			[SerializeField]
			private StatusInfo status;

			public readonly float RequiredRating => requiredRating;

			public readonly StatusInfo Status => status;
		}

		[SerializeField]
		private ReviewsThresholdRow[] rows = Array.Empty<ReviewsThresholdRow>();

		private WorkshopStatusService statusService;

		private WorkshopRatingsService workshopRatingsService;

		private WorkshopRatingsAppOpenStateComponent workshopRatingsAppOpenStateComponent;

		[Inject]
		private void Construct(WorkshopStatusService statusService, WorkshopRatingsService workshopRatingsService, WorkshopRatingsAppOpenStateComponent workshopRatingsAppOpenStateComponent)
		{
			this.statusService = statusService;
			this.workshopRatingsService = workshopRatingsService;
			this.workshopRatingsAppOpenStateComponent = workshopRatingsAppOpenStateComponent;
		}

		public override void Initialize()
		{
			workshopRatingsService.OnRatingChanged += ResolveOnRatingChanged;
			workshopRatingsAppOpenStateComponent.OnOpened += ResolveOnRatingsAppOpened;
			if (workshopRatingsAppOpenStateComponent.HasBeenOpened)
			{
				Recalculate();
			}
			else
			{
				RemoveAllStatuses();
			}
		}

		public override void Dispose()
		{
			workshopRatingsService.OnRatingChanged -= ResolveOnRatingChanged;
			workshopRatingsAppOpenStateComponent.OnOpened -= ResolveOnRatingsAppOpened;
			RemoveAllStatuses();
		}

		private void RemoveAllStatuses()
		{
			for (int i = 0; i < rows.Length; i++)
			{
				RatingThreshold[] thresholds = rows[i].Thresholds;
				for (int j = 0; j < thresholds.Length; j++)
				{
					statusService.RemoveStatus(thresholds[j].Status);
				}
			}
		}

		private void ResolveOnRatingChanged(WorkshopRatingsService service)
		{
			if (workshopRatingsAppOpenStateComponent.HasBeenOpened)
			{
				Recalculate();
			}
		}

		private void ResolveOnRatingsAppOpened(WorkshopRatingsAppOpenStateComponent component)
		{
			Recalculate();
		}

		private void Recalculate()
		{
			if (rows.Length == 0)
			{
				return;
			}
			GetIndexes(out var rowIndex, out var columnIndex);
			StatusInfo statusInfo = ((rowIndex >= 0 && columnIndex >= 0) ? rows[rowIndex].Thresholds[columnIndex].Status : null);
			if (statusInfo != null)
			{
				statusService.AddStatus(statusInfo);
			}
			for (int i = 0; i < rows.Length; i++)
			{
				RatingThreshold[] thresholds = rows[i].Thresholds;
				for (int j = 0; j < thresholds.Length; j++)
				{
					StatusInfo status = thresholds[j].Status;
					if (status != statusInfo)
					{
						statusService.RemoveStatus(status);
					}
				}
			}
		}

		private void GetIndexes(out int rowIndex, out int columnIndex)
		{
			rowIndex = -1;
			columnIndex = -1;
			float overallRating = workshopRatingsService.OverallRating;
			int reviewsCount = workshopRatingsService.ReviewsCount;
			if (overallRating <= 0f || reviewsCount <= 0)
			{
				return;
			}
			int num = int.MinValue;
			for (int i = 0; i < rows.Length; i++)
			{
				ReviewsThresholdRow reviewsThresholdRow = rows[i];
				if (reviewsThresholdRow.RequiredReviewsCount <= reviewsCount && reviewsThresholdRow.RequiredReviewsCount >= num)
				{
					rowIndex = i;
					num = reviewsThresholdRow.RequiredReviewsCount;
				}
			}
			if (rowIndex == -1)
			{
				return;
			}
			RatingThreshold[] thresholds = rows[rowIndex].Thresholds;
			float num2 = -2.1474836E+09f;
			for (int j = 0; j < thresholds.Length; j++)
			{
				RatingThreshold ratingThreshold = thresholds[j];
				if (ratingThreshold.RequiredRating <= overallRating && ratingThreshold.RequiredRating >= num2)
				{
					columnIndex = j;
					num2 = ratingThreshold.RequiredRating;
				}
			}
		}
	}
}
