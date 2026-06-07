using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class IngredientSlot3DUIView : Button3DUIView
	{
		[SerializeField]
		private IngredientList3DUIView _list;

		[SerializeField]
		private IngredientOption3DUIView _ingredientVisual;

		[SerializeField]
		private Transform _nothingSelectedVisual;

		[SerializeField]
		private Button3DUIView _clearSlotButton;

		[SerializeField]
		private Transform _iconSlot;

		public Ingredient PreviewIngredient;

		public CraftSlot CraftSlot { get; private set; }

		public Ingredient SelectedIngredient { get; private set; }

		public bool IngredientSwapped { get; set; }

		public static event EventHandler SlotChanged
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

		public static event EventHandler PreviewIngredientChanged
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

		public void UpdateIngredientList()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		public void SetCraftSlot(CraftSlot craftSlot)
		{
		}

		public void SetIngredient(IngredientTemplate template)
		{
		}

		public void SetPreviewIngredient(Ingredient ingredient)
		{
		}

		public void RemovePreviewIngredient(Ingredient ingredient)
		{
		}

		public IngredientTemplate[] GetValidIngredientTemplates()
		{
			return null;
		}

		public void ResetVisual()
		{
		}

		private void SetCraftSlotData()
		{
		}

		public void Clear()
		{
		}

		protected override void Awake()
		{
		}
	}
}
