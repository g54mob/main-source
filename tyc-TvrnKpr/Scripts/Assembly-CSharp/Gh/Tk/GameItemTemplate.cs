using System.Collections.Generic;
using System.Text;
using LitJson;

namespace Gh.Tk
{
	public class GameItemTemplate : IPersistable, IPriceConfigurable
	{
		public string type;

		public string name;

		public string description;

		public List<string> zonesRequired;

		public bool ignoreInShops;

		public int stars;

		public List<string> traits;

		[JsonIgnore]
		public string id;

		public Flammability Flammability;

		public string visualKey;

		public string containerVisualKeyOverride;

		public int MaxAmount;

		private static Dictionary<string, GameItemTemplate> _templates;

		[JsonIgnore]
		public int wholesalePrice;

		public bool needsUnlock;

		[JsonIgnore]
		private GameItemTrait[] _tmpTraits;

		public string Id
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Weight { get; internal set; }

		[JsonIgnore]
		public string VisualKey => null;

		[JsonIgnore]
		public string VisualKeyBase => null;

		[JsonIgnore]
		public virtual int Stars => 0;

		[JsonIgnore]
		public bool IgnoreInLarder => false;

		[JsonIgnore]
		public virtual int AveragePrice => 0;

		public bool IsCustomPriceSet { get; protected set; }

		public int CustomPrice { get; protected set; }

		[JsonIgnore]
		public int CurrentPrice
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[JsonIgnore]
		public int MinWholesalePrice => 0;

		[JsonIgnore]
		public int MaxWholesalePrice => 0;

		[JsonIgnore]
		public virtual string FullNameKey => null;

		[JsonIgnore]
		public string FullName => null;

		[JsonIgnore]
		public string Name => null;

		public static IEnumerable<GameItemTemplate> GetTemplates()
		{
			return null;
		}

		public static GameItemTemplate GetTemplateById(string id)
		{
			return null;
		}

		public static IngredientTemplate GetIngredientTemplateById(string id)
		{
			return null;
		}

		public static void ClearTemplates()
		{
		}

		public static void AddTemplate(GameItemTemplate template)
		{
		}

		public static void RemoveTemplate(GameItemTemplate template)
		{
		}

		public static void CheckIfPrefabsForAllTemplatesExist()
		{
		}

		public virtual (int, int) GetAllowedPriceRange()
		{
			return default((int, int));
		}

		public virtual int GetPrice()
		{
			return 0;
		}

		public void SetCustomPrice(int value)
		{
		}

		public virtual int GetWholesalePrice()
		{
			return 0;
		}

		public static string GetDisplayNameKey(string templateId)
		{
			return null;
		}

		internal void OnCraftProcess(CraftProcess process, RecipeInput[] inputs, Ingredient output)
		{
		}

		public static string CalculateId(string type, string name)
		{
			return null;
		}

		public bool HasTrait<T>() where T : GameItemTrait
		{
			return false;
		}

		public IEnumerable<GameItemTrait> GetTraits()
		{
			return null;
		}

		public bool CanPlayerBuyThisFromShops(StringBuilder details = null)
		{
			return false;
		}

		public virtual bool ShouldBeSealed()
		{
			return false;
		}
	}
}
