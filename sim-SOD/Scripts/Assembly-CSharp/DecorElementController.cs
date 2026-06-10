using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecorElementController : MonoBehaviour
{
	[Header("Components")]
	public MaterialGroupPreset preset;

	public FurniturePreset furniture;

	public TextMeshProUGUI nameText;

	public TextMeshProUGUI priceText;

	public TextMeshProUGUI sellText;

	public InfoWindow thisWindow;

	public DecorController decorController;

	public FurnishingsController furnishingsController;

	public Image mainImage;

	public FurnitureLocation worldFurnitureReference;

	public ButtonController placeButton;

	public ButtonController storageButton;

	public ButtonController sellButton;

	public Image icon;

	[Space(7f)]
	public Sprite chairIcon;

	public Sprite tableIcon;

	public Sprite unitIcon;

	public Sprite electronicsIcon;

	public Sprite structuralIcon;

	public Sprite decorationIcon;

	public Sprite miscIcon;

	[Header("State")]
	public int price;

	public void Setup(MaterialGroupPreset newPreset, DecorController newDecorController, InfoWindow newThisWindow)
	{
	}

	private Texture2D GenerateDecorIcon(int size = 128)
	{
		return null;
	}

	public void SetupFurniture(FurniturePreset newFurniture, FurnishingsController newDecorController, InfoWindow newThisWindow, FurnitureLocation newWorldFurnReference)
	{
	}

	public void VisualUpdate()
	{
	}

	public void UpdateButtonText()
	{
	}

	public void OnPlaceButton()
	{
	}

	public void OnStorageButton()
	{
	}

	public void OnSellButton()
	{
	}

	public void UpdatePurchaseAbility()
	{
	}
}
