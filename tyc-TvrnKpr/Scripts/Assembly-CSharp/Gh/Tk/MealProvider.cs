using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(CreateMealProcess))]
	[RequireComponent(typeof(Inventory))]
	[RequireComponent(typeof(Prop))]
	public class MealProvider : AttachedBehaviour
	{
		private List<string> _outputTypes;

		private List<IngredientTemplate> _possibleMeals;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		private IngredientTemplate _chosenMeal;

		[SerializeField]
		public bool ShowMealOutputVisual;

		private List<ContextMenuItem> _currentMenuItems;

		private ContextMenuItem _selectItemToServeMenu;

		public IngredientTemplate ChosenMeal
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs<IngredientTemplate>> ChosenMealChanged
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

		public override void Start()
		{
		}

		private void OnPostBuilt(object sender, EventArgs e)
		{
		}

		private void OnBeforeDemolishing(object sender, EventArgs e)
		{
		}

		protected override void LateRestoreStateInternal(IDataStore data)
		{
		}

		private void OnMenuItemEnabledChanged(object sender, EventArgs e)
		{
		}

		private void RefreshMeals()
		{
		}

		private void UpdatePossibleMeals()
		{
		}

		private void UpdateContextMenu()
		{
		}

		private void OnInventoryChanged(object sender, EventArgs e)
		{
		}

		private void CheckMealProcess()
		{
		}

		public override void OnDestroy()
		{
		}

		private void UpdateVisual()
		{
		}

		public IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}
	}
}
