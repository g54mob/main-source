using PajamaLlama.Debugs;
using TMPro;
using UnityEngine;

public class RecipeDisplay : MonoBehaviour
{
	[Header("UI Components")]
	[SerializeField]
	[Tooltip("Text component for the recipe name.")]
	private TextMeshProUGUI _recipeNameText;

	[SerializeField]
	private TextMeshProUGUI _amountToProduceText;

	[Space]
	[Tooltip("List of required ingredient displays.")]
	[SerializeField]
	private ChildBehaviourCache<RecipeItemDisplay> _ingredientDisplayCache;

	[Tooltip("List of produced ingredient displays.")]
	[SerializeField]
	private ChildBehaviourCache<RecipeItemDisplay> _producedItemDisplayCache;

	[Header("Malfunctions")]
	[SerializeField]
	private GameObject _malfunctionContainer;

	[SerializeField]
	[ConditionalHide("_malfunctionContainer", true)]
	private ChildBehaviourCache<PlaceableAlertIcon> _malfunctionIconCache;

	private bool _updateUI;

	private int _amountToProduce = int.MinValue;

	public Producer.Recipe Recipe { get; private set; }

	private void OnEnable()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(SetUIUpdateFlag);
	}

	private void LateUpdate()
	{
		UpdateAmountToProduce();
		if (_updateUI)
		{
			UpdateDisplay();
			_updateUI = false;
		}
	}

	private void OnDisable()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(SetUIUpdateFlag);
	}

	public void Initialize(Producer.Recipe recipe, bool requiresFuel)
	{
		if (recipe == null)
		{
			Debugger.Error("No recipe to display on recipe display.");
			base.gameObject.SetActive(value: false);
		}
		else
		{
			SetRecipe(recipe);
			base.gameObject.SetActive(value: true);
		}
	}

	public void SetRecipe(Producer.Recipe recipe)
	{
		if (Recipe != recipe)
		{
			if (Recipe != null)
			{
				Recipe.Producer.Buildable.MalfunctionUpdatedEvent -= OnMalfunctionsUpdated;
			}
			Recipe = recipe;
			if (Recipe != null)
			{
				_recipeNameText.text = Recipe.Properties.LocalizedName.ToString().ToUpper();
				Recipe.Producer.Buildable.MalfunctionUpdatedEvent += OnMalfunctionsUpdated;
			}
			OnMalfunctionsUpdated();
			UpdateDisplay();
		}
	}

	public void UpdateDisplay()
	{
		UpdateAmountToProduce();
		_ingredientDisplayCache.Reset();
		_producedItemDisplayCache.Reset();
		foreach (CountedItemProperty ingredient in Recipe.Ingredients)
		{
			RecipeItemDisplay recipeItemDisplay = _ingredientDisplayCache.Get(active: true);
			int num = Community.PlayerCommunity.Inventory.ReturnCount(ingredient.ItemProperties);
			recipeItemDisplay.Initialize(Recipe, ingredient.ItemProperties, num < ingredient.Amount, $"{num}/{ingredient.Amount}");
		}
		foreach (CountedItemProperty producedItem in Recipe.ProducedItems)
		{
			_producedItemDisplayCache.Get(active: true).Initialize(Recipe, producedItem.ItemProperties, itemDisabled: false, producedItem.Amount.ToString());
		}
		_ingredientDisplayCache.Trim();
		_producedItemDisplayCache.Trim();
	}

	public void UpdateAmountToProduce()
	{
		if (_amountToProduce != Recipe.AmountToProduce)
		{
			_amountToProduce = Recipe.AmountToProduce;
			if (_amountToProduce < 0)
			{
				_amountToProduceText.text = "∞";
			}
			else
			{
				_amountToProduceText.text = _amountToProduce.ToString();
			}
		}
	}

	private void SetUIUpdateFlag()
	{
		_updateUI = true;
	}

	private void OnMalfunctionsUpdated()
	{
		if (!_malfunctionContainer)
		{
			return;
		}
		_malfunctionIconCache.Reset();
		foreach (PlaceableAlertProperties malfunction in Recipe.Malfunctions)
		{
			_malfunctionIconCache.Get(active: true).Initialize(malfunction, Recipe.Properties.LocalizedName);
		}
		_malfunctionIconCache.Trim();
		_malfunctionContainer.SetActive(0 < Recipe.Malfunctions.Count);
	}
}
