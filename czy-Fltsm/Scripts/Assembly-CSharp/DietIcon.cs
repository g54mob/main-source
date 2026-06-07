using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Tooltip))]
public class DietIcon : MonoBehaviour
{
	[Tooltip("Image component for the icon.")]
	[SerializeField]
	private Image _iconImage;

	public void Initialize(ItemProperties itemProperties)
	{
		_iconImage.sprite = itemProperties.InventorySprite;
		string localizedName = itemProperties.LocalizedName;
		float nutritionalValue = itemProperties.NutritionalValue;
		localizedName = localizedName.Replace("%NUTRITIONALVALUE%", (nutritionalValue == 0f) ? "none" : nutritionalValue.ToString());
		GetComponent<Tooltip>().LocalizedText = localizedName;
	}
}
