using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class MealDesignerDialog3DUIView : BaseDialog3DUIView
	{
		private RecipeTemplatePicker3DUIView _recipeTemplatePicker;

		private MealOutput3DUIView _mealOutput;

		[SerializeField]
		private Container3DUIView _ingredientSlotsParent;

		private List<IngredientSlot3DUIView> _ingredientSlots;

		[SerializeField]
		private List<Button3DUIView> _closeButtons;

		[SerializeField]
		private Button3DUIView _templatesButton;

		[SerializeField]
		private Button3DUIView _createButton;

		[SerializeField]
		private Button3DUIView _resetButton;

		private CraftProcess _selectedProcess;

		[SerializeField]
		private Button3DUIView _categoryMains;

		[SerializeField]
		private Button3DUIView _categorySides;

		[SerializeField]
		private Button3DUIView _categoryDesserts;

		[SerializeField]
		private Button3DUIView _categoryIngredients;

		[SerializeField]
		private Transform _designerParent;

		[SerializeField]
		private IngredientList3DUIView _ingredientList;

		[SerializeField]
		private GameObject[] _priceAndRatingVisuals;

		private string _currentCategory;

		private Animator[] _animatorsWithSpeedParam;

		private int _currentSpeed;

		private bool _isTemplatesShown;

		private static readonly int AnimKey_Stage;

		private static readonly int AnimKey_Ready;

		private static readonly int AnimKey_Reset;

		private static readonly int AnimKey_ResetStage;

		[SerializeField]
		private List<GameObject> mealAnimations;

		private Animator _currentMealAnimator;

		private Transform[][] _animationIngredients;

		public static Ingredient EditingRatable { get; private set; }

		public bool OpenedFromTavernMenu { get; set; }

		protected override void Awake()
		{
		}

		private void SetCategory(string category)
		{
		}

		private void CheckCategoryButtonStates()
		{
		}

		private bool ShouldReplaceExistingRecipe(out IngredientTemplate ingredient)
		{
			ingredient = null;
			return false;
		}

		protected void Start()
		{
		}

		private void IngredientSlot3DUIViewOnPreviewIngredientChanged(object sender, EventArgs e)
		{
		}

		private void IngredientSlot3DUIView_SlotChanged(object sender, EventArgs e)
		{
		}

		private void CheckIngredientEnabledAndSelectedStates()
		{
		}

		protected void OnDestroy()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Opened()
		{
		}

		public override bool IsBackable()
		{
			return false;
		}

		public override void Back()
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Closed()
		{
		}

		private void ShowTemplates()
		{
		}

		public void ResetDialog()
		{
		}

		private void UpdateOutput()
		{
		}

		private void UpdatePreview()
		{
		}

		private void ClearMealAnimation()
		{
		}

		private void SetupMealAnimation()
		{
		}

		private void UpdateMealAnimation()
		{
		}

		public void SetRecipeTemplate(CraftProcess craftProcess)
		{
		}

		private static IEnumerable<CraftProcess> GetAvailableRecipeTemplates(string category)
		{
			return null;
		}
	}
}
