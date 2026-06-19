using TMPro;
using UnityEngine;

public class NewPenConstructionPanel : MonoBehaviour
{
	public TextMeshPro smallPenText;

	public TextMeshPro mediumPenText;

	public TextMeshPro largePenText;

	public SpriteRenderer smallSpriteTop;

	public SpriteRenderer mediumSpriteTop;

	public SpriteRenderer largeSpriteTop;

	public CoreButton smallButton;

	public CoreButton mediumButton;

	public CoreButton largeButton;

	public Color activeTextColor;

	public Color inactiveTextColor;

	public Color activeButtonColor;

	public Color inactiveButtonColor;

	private InventoryManager inventoryRef;

	private ConstructionManager constructionRef;

	private void Awake()
	{
		inventoryRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		constructionRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER);
	}

	private void OnEnable()
	{
		RefreshButtonStatus();
	}

	public void OnBuyPenButtonClicked(BuildableObject penType)
	{
		constructionRef.BuildSpecificRoom(penType);
	}

	private void RefreshButtonStatus()
	{
		RefreshSpecificButton(smallPenText, smallSpriteTop, smallButton);
		RefreshSpecificButton(mediumPenText, mediumSpriteTop, mediumButton);
		RefreshSpecificButton(largePenText, largeSpriteTop, largeButton);
	}

	private void RefreshSpecificButton(TextMeshPro buttonText, SpriteRenderer buttonSprite, CoreButton button)
	{
		button.UnlockScale();
		buttonText.color = activeTextColor;
		buttonSprite.color = activeButtonColor;
	}
}
