using PajamaLlama.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductionPanelRecipeToggle : PLToggle
{
	[Header("Recipe Toggle")]
	[SerializeField]
	private Image _itemImage;

	[SerializeField]
	private Image _malfunctionImage;

	[SerializeField]
	private Image _continuousImage;

	[SerializeField]
	private TextMeshProUGUI _amountField;

	[Header("Animator")]
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _animatorSelectedParameter = "Selected";

	[SerializeField]
	private string _animatorContinuousParameter = "Continuous";

	private ItemTooltip _tooltip;

	private bool _isToProduce;

	private int _amount = int.MinValue;

	public Producer Producer { get; private set; }

	public Producer.Recipe Recipe { get; private set; }

	public ItemProperties ItemProperties { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		if ((bool)base.animator)
		{
			base.animator.keepAnimatorStateOnDisable = true;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (Producer != null)
		{
			UpdateState();
		}
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		UpdateToProduce();
	}

	public void Initialize(Producer producer, Producer.Recipe recipe)
	{
		Producer = producer;
		Recipe = recipe;
		if (recipe.IsUnlocked())
		{
			ItemProperties = recipe.GetFirstProducedItemProperties();
			_itemImage.overrideSprite = recipe.GetIcon(ItemProperties);
			if (_tooltip == null)
			{
				_tooltip = this.GetOrAddComponent<ItemTooltip>();
			}
			_tooltip.IsEnabled = true;
			_tooltip.Initialize(ItemProperties);
		}
		else
		{
			base.isOn = false;
			base.gameObject.SetActive(value: false);
		}
	}

	public void UpdateState()
	{
		if (base.isActiveAndEnabled && Recipe != null)
		{
			base.isOn = Producer.SelectedRecipe == Recipe;
			_malfunctionImage.overrideSprite = null;
			if (0 < Recipe.Malfunctions.Count)
			{
				_malfunctionImage.gameObject.SetActive(value: true);
				_continuousImage.gameObject.SetActive(value: false);
				_amountField.gameObject.SetActive(value: false);
				_malfunctionImage.overrideSprite = Recipe.Malfunctions[0].UIIconProperties.Sprite;
			}
			else if (Recipe.IsContinuous)
			{
				_malfunctionImage.gameObject.SetActive(value: false);
				_continuousImage.gameObject.SetActive(value: true);
				_amountField.gameObject.SetActive(value: false);
			}
			else
			{
				_malfunctionImage.gameObject.SetActive(value: false);
				_continuousImage.gameObject.SetActive(value: false);
				_amountField.gameObject.SetActive(value: true);
			}
			_animator?.SetBool(_animatorSelectedParameter, base.isOn);
			UpdateToProduce();
		}
	}

	private void UpdateToProduce()
	{
		if (base.isActiveAndEnabled && Recipe != null)
		{
			bool flag = Recipe.IsContinuous || Recipe.AmountToProduce > 0;
			if (flag != _isToProduce)
			{
				_isToProduce = flag;
				_animator?.SetBool(_animatorContinuousParameter, _isToProduce);
			}
			if (_amount != Recipe.AmountToProduce)
			{
				_amount = Recipe.AmountToProduce;
				_amountField.text = _amount.ToString();
			}
		}
	}

	public void SetSelected(bool selected)
	{
		_animator?.SetBool(_animatorSelectedParameter, selected);
	}
}
