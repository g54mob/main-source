using System.Collections.Generic;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class PatronGameItemRatingContainer3DUIView : Container3DUIView
	{
		public enum RatingMode
		{
			AllRatings = 0,
			InvalidOnly = 1,
			ValidOnly = 2
		}

		public PatronGameItemRating3DUIView ratingPrefab;

		public MorePatronGameItemRatings3DUIView morePrefab;

		public int maxItemCount;

		public bool splitByTier;

		public void UpdateForCategory(string category)
		{
		}

		public void UpdateForGameItem(IPatronRatable template, bool isPrototypeIngredient = false, RatingMode ratingMode = RatingMode.ValidOnly)
		{
		}

		private void AddItems(IEnumerable<PatronGameItemRating3DUIView> items)
		{
		}

		private void AddIconForOverflow(PatronGameItemRating3DUIView[] items)
		{
		}
	}
}
