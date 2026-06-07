using System.Collections.Generic;
using System.Text;
using LitJson;

namespace Gh.Tk
{
	public class IngredientTemplate : GameItemCraftableBaseTemplate
	{
		private string _recipeId;

		[JsonIgnore]
		private Recipe _recipe;

		public bool isArchived;

		public bool needsRecipe;

		public string ingredientCategory;

		public bool orderedByLarderManagement;

		public bool isVisibleInLarderOverview;

		public int flavor;

		public string customName;

		public int gross;

		public int tough;

		public int sweet;

		public int pure;

		private static int[] minTierPrices;

		private static int[] _flavorBrackets;

		[JsonIgnore]
		private string _nameForUnusable;

		private static readonly float[] _flavorWeightings;

		[JsonIgnore]
		private Dictionary<string, Dictionary<string, int>> _raceFlavorProfiles;

		public static int[] TierFlavorDifferenceMargin;

		[JsonIgnore]
		public Recipe Recipe
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float SpoilRate { get; set; }

		[JsonIgnore]
		public override int AveragePrice => 0;

		public string SpoilOutcomeId { get; set; }

		[JsonIgnore]
		public override string FullNameKey => null;

		public List<string> CraftLog { get; set; }

		[JsonIgnore]
		public override int Stars => 0;

		[JsonIgnore]
		public float StarsF => 0f;

		[JsonIgnore]
		public Dictionary<string, Dictionary<string, int>> RaceFlavorProfiles => null;

		public IngredientTemplate()
		{
		}

		public IngredientTemplate(string name, string type, int amount, string visualKey)
		{
		}

		public bool IsPlayerCrafted()
		{
			return false;
		}

		public bool IsPetFood()
		{
			return false;
		}

		public override int GetWholesalePrice()
		{
			return 0;
		}

		public int CalculatePrice(int flavor, bool forWholeSale = false)
		{
			return 0;
		}

		public static int CalculateStarsFromFlavor(int flavor)
		{
			return 0;
		}

		public static Tuple<int, int> GetFlavorBrackets(int tier)
		{
			return null;
		}

		public static float CalculateStarsFloatFromFlavor(int flavor)
		{
			return 0f;
		}

		public static float GetProgressTowardsNextStar(int flavor)
		{
			return 0f;
		}

		public IEnumerable<(string, int)> GetFlavorProfileStats()
		{
			return null;
		}

		public string GetFullNameKey()
		{
			return null;
		}

		public static float GetFlavourWeighting(int tier)
		{
			return 0f;
		}

		public static (int, int, int, TooltipData) RateFlavorAndPriceInPercent(string race, int tier, IPatronRatable ratable, bool generateTooltip = false)
		{
			return default((int, int, int, TooltipData));
		}

		public static int RateFlavorInPercent(string race, int tier, IPatronRatable ratable, StringBuilder details = null)
		{
			return 0;
		}

		public static int RatePriceInPercent(string race, int tier, IPatronRatable ratable, StringBuilder details = null)
		{
			return 0;
		}

		public override float GetEffectiveQuality(string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public (int, string) GetOkPrice(int flavor, string race, int tier, bool generateReason)
		{
			return default((int, string));
		}

		public override (int, string) GetOkPrice(string race, int tier, bool generateReason)
		{
			return default((int, string));
		}

		public float ApplyFlavorProfileFactor(float flavor, string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public void TransferValues(IngredientTemplate other)
		{
		}
	}
}
