using System.Collections.Generic;
using System.Numerics;
using Assets.Source.Item.Types;
using Assets.Source.Util;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Source.Item
{
	public class ItemType
	{
		private static Dictionary<string, ItemType> _allTypes;

		private static List<ItemType> _orderedTypes;

		public static ItemType Power;

		public static ItemType WidgetParticle;

		public static ItemType RocketFuel;

		public static ItemType BasicWidget;

		public static ItemType GlitchedWidget;

		public static ItemType HumanRemains;

		public readonly string Identifier;

		public string DisplayName;

		public string IconName;

		public int OverrideTier;

		public string Description;

		private BigInteger _value = -1;

		private CraftingFrame _recipe;

		public int Ordinal { get; private set; }

		public string DisplayNameTL => Translation.Translate(DisplayName);

		public string DisplayNameLowercase => DisplayNameTL.ToLower();

		public string DisplayNamePlural => DisplayName + ((this == Power) ? "" : "s");

		public string DisplayNamePluralLowercase => DisplayNamePlural.ToLower();

		public Sprite Icon => SpriteLibrary.Get(IconName);

		public CraftingFrame Recipe => _findRecipe();

		public BigInteger Value => _calculateValue();

		public int Tier
		{
			get
			{
				if (OverrideTier != 0)
				{
					return OverrideTier;
				}
				if (Recipe != null)
				{
					return Recipe.Tier;
				}
				if (!(Identifier == "rocket_segment") && !(Identifier == "demo_turtle"))
				{
					return 1;
				}
				return 999;
			}
		}

		public static int Count => _orderedTypes.Count;

		public static IEnumerable<ItemType> All => _orderedTypes;

		static ItemType()
		{
			_allTypes = new Dictionary<string, ItemType>();
			_orderedTypes = new List<ItemType>();
			new Assets.Source.Item.Types.Materials();
			new Products();
			new Processors();
			new Cores();
			new Widgets();
			Power = "power";
			WidgetParticle = "widget_particle";
			BasicWidget = "widget";
			RocketFuel = "rocket_fuel";
			GlitchedWidget = "glitched_widget";
			HumanRemains = "human_remains";
		}

		public ItemType(string id)
		{
			Identifier = id;
			DisplayName = "@" + id + "_name";
			Description = "@" + id + "_desc";
		}

		private CraftingFrame _findRecipe()
		{
			if (_recipe == null)
			{
				foreach (FramePrefabSet orderedFramePrefab in WorldManager.Instance.OrderedFramePrefabs)
				{
					if (orderedFramePrefab.GetPreview() is CraftingFrame craftingFrame && craftingFrame.GetRecipeResultCount(this) > 0L)
					{
						_recipe = craftingFrame;
						break;
					}
				}
			}
			return _recipe;
		}

		private BigInteger _calculateValue()
		{
			if (_value < 0L)
			{
				_value = 1;
				CraftingFrame recipe = Recipe;
				if (recipe != null)
				{
					BigInteger recipeResultCount = recipe.GetRecipeResultCount(this);
					BigInteger bigInteger = 0;
					foreach (KeyValuePair<ItemType, BigInteger> reagent in recipe.GetReagents())
					{
						bigInteger += reagent.Key.Value * reagent.Value;
					}
					_value += bigInteger / recipeResultCount;
				}
			}
			return _value;
		}

		public override int GetHashCode()
		{
			return Identifier.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is ItemType itemType)
			{
				return Identifier == itemType.Identifier;
			}
			return false;
		}

		public static void Add(ItemType it)
		{
			_allTypes[it.Identifier] = it;
			it.Ordinal = _orderedTypes.Count;
			_orderedTypes.Add(it);
		}

		public static ItemType Get(string id)
		{
			return _allTypes[id];
		}

		public static ItemType Get(int ordinal)
		{
			return _orderedTypes[ordinal];
		}

		public static implicit operator ItemType(string id)
		{
			return Get(id);
		}

		public static implicit operator string(ItemType it)
		{
			return it.Identifier;
		}
	}
}
