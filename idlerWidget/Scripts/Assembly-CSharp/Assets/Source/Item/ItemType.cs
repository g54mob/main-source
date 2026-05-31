using System.Collections.Generic;
using Assets.Source.Item.Types;
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

		public static ItemType OmegaWidget;

		public readonly string Identifier;

		public string DisplayName;

		public string IconName;

		public string Description;

		private int _value = -1;

		private CraftingFrame _recipe;

		public int Ordinal { get; private set; }

		public Sprite Icon => SpriteLibrary.Get(IconName);

		public CraftingFrame Recipe => _findRecipe();

		public int Value => _calculateValue();

		public int Tier
		{
			get
			{
				CraftingFrame recipe = Recipe;
				if (recipe == null)
				{
					if (!(Identifier == "rocket_segment") && !(Identifier == "demo_turtle"))
					{
						return 1;
					}
					return 999;
				}
				return recipe.Tier;
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
			OmegaWidget = "omega_widget";
		}

		public ItemType(string id)
		{
			Identifier = id;
		}

		private CraftingFrame _findRecipe()
		{
			if (_recipe == null)
			{
				foreach (FramePrefabSet orderedFramePrefab in WorldManager.Instance.OrderedFramePrefabs)
				{
					if (orderedFramePrefab.GetPreview() is CraftingFrame craftingFrame && craftingFrame.GetRecipeResultCount(this) > 0)
					{
						_recipe = craftingFrame;
						break;
					}
				}
			}
			return _recipe;
		}

		private int _calculateValue()
		{
			if (_value < 0)
			{
				_value = 1;
				CraftingFrame recipe = Recipe;
				if (recipe != null)
				{
					int recipeResultCount = recipe.GetRecipeResultCount(this);
					int num = 0;
					foreach (KeyValuePair<ItemType, int> recipeReagent in recipe.GetRecipeReagents())
					{
						num += recipeReagent.Key.Value * recipeReagent.Value;
					}
					_value += num / recipeResultCount;
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
