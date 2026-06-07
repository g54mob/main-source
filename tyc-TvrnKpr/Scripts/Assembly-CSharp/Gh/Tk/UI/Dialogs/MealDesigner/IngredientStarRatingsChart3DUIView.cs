using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class IngredientStarRatingsChart3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Transform[] _starRatingsContainer;

		[SerializeField]
		private Transform[] _stars;

		private PatronGameItemRating3DUIView[] _ratings;

		private void Start()
		{
		}

		public void SetIngredient(Ingredient ingredient)
		{
		}

		public void SetIngredientPreview(Ingredient ingredient)
		{
		}

		private void SetStars(int maxTier)
		{
		}
	}
}
