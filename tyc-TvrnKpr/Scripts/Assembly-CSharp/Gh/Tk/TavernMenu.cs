using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using LitJson;

namespace Gh.Tk
{
	public class TavernMenu : IPersistable
	{
		private Dictionary<string, bool> _menuItems;

		[JsonIgnore]
		private FrameCachedValue<List<IngredientTemplate>> _enabledIngredients;

		[JsonIgnore]
		public List<IngredientTemplate> EnabledIngredients => null;

		public static event EventHandler TavernMenuItemEnabledChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public bool IsIngredientOnMenu(string id)
		{
			return false;
		}

		public IEnumerable<GameItemTemplate> GetAllItems()
		{
			return null;
		}

		public IEnumerable<GameItemTemplate> GetEnabledItems()
		{
			return null;
		}

		private IEnumerable<IngredientTemplate> GetEnabledIngredients()
		{
			return null;
		}

		public void SetItemEnabled(string id, bool enabled = true)
		{
		}

		public void AddItem(IngredientTemplate template)
		{
		}

		public void RemoveItem(IngredientTemplate template)
		{
		}

		public IEnumerable<IngredientTemplate> GetOrderAbleItems(string category, string itemTypeRestriction = null)
		{
			return null;
		}

		public bool CanItemBeOrdered(IngredientTemplate template)
		{
			return false;
		}
	}
}
