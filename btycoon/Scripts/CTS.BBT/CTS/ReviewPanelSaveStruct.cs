using System;

namespace CTS
{
	[Serializable]
	public struct ReviewPanelSaveStruct
	{
		public int GoodReviewService;

		public int GoodReviewDrink;

		public int GoodReviewFun;

		public int GoodReviewToilet;

		public int BadReviewService;

		public int BadReviewDrink;

		public int BadReviewFun;

		public int BadReviewToilet;

		public static ReviewPanelSaveStruct CreateStruct(UI_ReviewPanel uI_Review)
		{
			ReviewPanelSaveStruct result = new ReviewPanelSaveStruct
			{
				GoodReviewService = uI_Review.GoodReviewService.CurrentValue,
				GoodReviewDrink = uI_Review.GoodReviewDrink.CurrentValue,
				GoodReviewFun = uI_Review.GoodReviewFun.CurrentValue
			};
			if (uI_Review.IsHumanPanel)
			{
				result.GoodReviewToilet = uI_Review.GoodReviewToilet.CurrentValue;
			}
			result.BadReviewService = uI_Review.BadReviewService.CurrentValue;
			result.BadReviewDrink = uI_Review.BadReviewDrink.CurrentValue;
			result.BadReviewFun = uI_Review.BadReviewFun.CurrentValue;
			if (uI_Review.IsHumanPanel)
			{
				result.BadReviewToilet = uI_Review.BadReviewToilet.CurrentValue;
			}
			return result;
		}
	}
}
