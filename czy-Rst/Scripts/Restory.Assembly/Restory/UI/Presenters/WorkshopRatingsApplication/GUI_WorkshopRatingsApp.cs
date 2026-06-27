using System.Collections.Generic;
using System.Linq;
using Restory.Data.PC;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.WorkshopRatings;
using Restory.Gameplay.WorkshopStatus;
using Restory.UI.Pools.WorkshopRatingsApplication;
using Restory.UI.Presenters.PC.Apps;
using Restory.UI.Views.Shops;
using Restory.UserInterface;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.WorkshopRatingsApplication
{
	public sealed class GUI_WorkshopRatingsApp : GUI_PcAppBase
	{
		[SerializeField]
		private StatusCategory statusCategory;

		[SerializeField]
		private GUI_LocalisedText statusText;

		[SerializeField]
		private TextMeshProUGUI overallRatingText;

		[SerializeField]
		private GUI_SellerRatingView ratingView;

		[SerializeField]
		private RectTransform reviewsContainer;

		private readonly List<GUI_Review> reviewItems = new List<GUI_Review>();

		private GUI_WorkshopRatingsAppReviewItemsPool reviewItemsPool;

		private WorkshopStatusService workshopStatusService;

		private WorkshopRatingsService workshopRatingsService;

		private WorkshopRatingsAppOpenStateComponent workshopRatingsAppOpenStateComponent;

		[Inject]
		private void Construct(WorkshopStatusService workshopStatusService, WorkshopRatingsService workshopRatingsService, WorkshopRatingsAppOpenStateComponent workshopRatingsAppOpenStateComponent, GUI_WorkshopRatingsAppReviewItemsPool reviewItemsPool)
		{
			this.workshopStatusService = workshopStatusService;
			this.workshopRatingsService = workshopRatingsService;
			this.workshopRatingsAppOpenStateComponent = workshopRatingsAppOpenStateComponent;
			this.reviewItemsPool = reviewItemsPool;
		}

		protected override void LaunchProcess(PcAppInfo appInfo)
		{
			base.LaunchProcess(appInfo);
			workshopRatingsAppOpenStateComponent.MarkAsOpened();
			UpdateStatus();
			UpdateOverallRating();
			UpdateReviews();
		}

		protected override void StopProcess()
		{
			ClearItems();
			base.StopProcess();
		}

		private void UpdateStatus()
		{
			StatusInfo statusInfo = workshopStatusService.CurrentStatuses.FirstOrDefault((StatusInfo s) => s.Category == statusCategory);
			statusText.LocalizationID = ((statusInfo == null) ? "No status" : statusInfo.NameLocalizationKey);
		}

		private void UpdateOverallRating()
		{
			float overallRating = workshopRatingsService.OverallRating;
			overallRatingText.text = ((overallRating <= 0f) ? "-" : overallRating.ToString("0.0"));
			ratingView.SetRating(Mathf.RoundToInt(overallRating));
		}

		private void UpdateReviews()
		{
			ClearItems();
			foreach (Review item in workshopRatingsService.Reviews.Reverse())
			{
				GUI_Review component = reviewItemsPool.Get(reviewsContainer).GetComponent<GUI_Review>();
				component.Init(item);
				reviewItems.Add(component);
			}
		}

		private void ClearItems()
		{
			foreach (GUI_Review reviewItem in reviewItems)
			{
				reviewItem.Clean();
				reviewItemsPool.Release(reviewItem.gameObject);
			}
			reviewItems.Clear();
		}
	}
}
