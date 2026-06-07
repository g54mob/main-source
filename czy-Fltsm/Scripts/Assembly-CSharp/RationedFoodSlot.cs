using UnityEngine;
using UnityEngine.UI;

public class RationedFoodSlot : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Slider component for this food slot.")]
	private Slider _rationSlider;

	[SerializeField]
	private Tooltip _tooltip;

	[SerializeField]
	private Image _image;

	public void Initialize(ItemProperties foodProperties)
	{
		_image.sprite = foodProperties.InventorySprite;
		_tooltip.LocalizedText = foodProperties.LocalizedName;
		UpdatePortion(0);
	}

	public void UpdatePortion(int rations)
	{
		_rationSlider.value = rations;
	}
}
