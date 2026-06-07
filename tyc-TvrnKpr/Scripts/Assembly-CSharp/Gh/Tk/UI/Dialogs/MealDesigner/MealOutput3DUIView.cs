using System;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class MealOutput3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private TMP_InputField _nameInput;

		[SerializeField]
		private Transform _modelSlot;

		[SerializeField]
		private StarsWithChangePreview3DuiView _stars;

		[SerializeField]
		private TraitsContainer3DUIView _traits;

		[SerializeField]
		private FlavourProfile3DUIView _flavourProfile;

		[SerializeField]
		private IngredientStarRatingsChart3DUIView _ingredientStarRatingsChart3DuiView;

		[SerializeField]
		private GameItemPriceSlider3DUIView _priceSlider;

		private bool _customNameSet;

		public Ingredient Output { get; private set; }

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void Slider_PriceChanged(object obj, EventArgs e)
		{
		}

		private void NameInputChanged(string value)
		{
		}

		private void NameInputDeselected(string value)
		{
		}

		public void SetOutputModel(Ingredient ingredient)
		{
		}

		public void SetOutputNameAndPrice(Ingredient ingredient)
		{
		}

		public void SetOutputIngredient(Ingredient ingredient)
		{
		}

		public void SetPreviewOutputIngredient(Ingredient ingredient)
		{
		}

		public void Clear(bool hardClear = true)
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
