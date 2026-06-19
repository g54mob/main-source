using I2.Loc;
using UnityEngine;

public class SmallTitleUIBackground : MonoBehaviour
{
	public bool showCraftingBuildingText = true;

	public LocalizedString defaultTitle = "crafting";

	public PugText text;

	public PugText textOutline;

	public SpriteRenderer background;

	private string previousTextString;

	private string previousLanguage;

	public float bottom;

	public Vector2 paddingPixels;

	private Vector3 bottomPos;

	private BoxCollider boxCollider;

	private UIManager.CraftingUITheme theme;

	private bool inited;

	private int windowIndex;

	private void Awake()
	{
		Init();
	}

	public void Init()
	{
		if (!inited)
		{
			inited = true;
			bottomPos = background.transform.localPosition - new Vector3(0f, bottom, 0f);
			boxCollider = background.GetComponent<BoxCollider>();
		}
	}

	private void Update()
	{
		UpdateTextAndBackground();
	}

	public void UpdateThemeTextAndBackground(UIManager.CraftingUITheme theme, int windowIndex)
	{
		this.theme = theme;
		this.windowIndex = windowIndex;
		UpdateTextAndBackground();
	}

	private void UpdateTextAndBackground()
	{
		if (showCraftingBuildingText)
		{
			string mTerm = defaultTitle.mTerm;
			PlayerController player = Manager.main.player;
			InteractableObject interactableObject = ((player != null) ? player.GetCurrentInteractableObject() : null);
			if (player != null && interactableObject != null)
			{
				if (player.activeCraftingHandler != null && player.activeCraftingHandler != player.playerCraftingHandler)
				{
					CraftingBuilding component = interactableObject.transform.parent.GetComponent<CraftingBuilding>();
					if (component != null && component.entityExist)
					{
						CraftingBuilding.CraftingUISettings craftingUISettings = component.GetCraftingUISettings();
						if (windowIndex >= 0 && windowIndex < craftingUISettings.titles.Count)
						{
							mTerm = craftingUISettings.titles[windowIndex].mTerm;
						}
						else
						{
							Debug.LogWarning($"Missing title for crafting UI window index {windowIndex} in building {component}. Using default title.", this);
							mTerm = defaultTitle.mTerm;
						}
					}
				}
				else if (player.GetActiveFilteringBuilding() != null)
				{
					mTerm = player.GetActiveFilteringBuilding().GetUITitle().mTerm;
				}
			}
			if (text.GetText() != mTerm || textOutline.GetText() != mTerm)
			{
				text.Render(mTerm);
				textOutline.Render(mTerm);
			}
		}
		if (theme != null)
		{
			background.sprite = theme.background;
			text.SetTempColor(theme.textColor);
			textOutline.SetTempColor(theme.textOutlineColor);
		}
		UpdateBackgroundSize();
	}

	private void UpdateBackgroundSize()
	{
		if (previousTextString != text.displayedTextString || previousLanguage != Manager.prefs.language)
		{
			previousLanguage = Manager.prefs.language;
			previousTextString = text.displayedTextString;
			background.size = text.dimensions.size + paddingPixels * 0.0625f;
			background.size = new Vector2(background.size.x + background.size.x % 0.125f, background.size.y + background.size.y % 0.125f);
			background.transform.localPosition = bottomPos + new Vector3(0f, background.size.y / 2f, 0f);
			boxCollider.size = background.size;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Vector3 position = background.transform.position;
		Gizmos.DrawLine(new Vector3(position.x - 1f, position.y - bottom, position.z), new Vector3(position.x + 1f, position.y - bottom, position.z));
	}
}
