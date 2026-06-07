using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class IngredientOption3DUIView : BaseInteractable3DUIView
	{
		[SerializeField]
		private TextMeshProI18n _nameText;

		[SerializeField]
		private Transform _modelSlot;

		[SerializeField]
		private Stars3DUIView _stars;

		[SerializeField]
		private TraitsContainer3DUIView _traitsContainer;

		[SerializeField]
		private FlavourProfile3DUIView _flavourProfile;

		[SerializeField]
		private Transform _outOfStockVisual;

		public Color outOfStockNameColor;

		public Color defaultNameColor;

		private Ingredient _data;

		public void SetIngredient(IngredientTemplate template, int amount)
		{
		}

		private void CleanUpVisuals()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
