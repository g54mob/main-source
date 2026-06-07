using LitJson;

namespace Gh.Tk
{
	public class FoodOrder : GameItem
	{
		private bool _preparationStarted;

		private bool _cookingFinished;

		private bool _wasPickedUp;

		[PersistenceObjectReference]
		public IngredientTemplate MainDishTemplate { get; set; }

		[PersistenceObjectReference]
		public IngredientTemplate SideDishTemplate { get; set; }

		[PersistenceObjectReference]
		[PersistenceAllowBrokenReferenceOnLoad]
		public Patron OrderedBy { get; set; }

		[JsonIgnore]
		public bool PreparationStarted
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int CookedMainDishItemId { get; internal set; }

		public int PlateId { get; internal set; }

		public int CookedSideDishItemId { get; internal set; }

		[JsonIgnore]
		public bool CookingFinished
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int PositionInOrderWindow { get; set; }

		public FoodOrder()
		{
		}

		public FoodOrder(IngredientTemplate mainDishTemplate, IngredientTemplate sideDishTemplate, Patron orderedBy)
		{
		}

		public override TooltipData GetTooltipData(TooltipAlignment alignment = TooltipAlignment.Default)
		{
			return null;
		}
	}
}
