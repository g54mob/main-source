using UnityEngine;

public class ColorManager : MonoBehaviour
{
	public static ColorManager Instance;

	public static Color progressBarInputSlowed = new Color(0.858f, 0.674f, 0.3f, 1f);

	public static Color progressBarDefault = new Color(0.2f, 0.62f, 0.85f, 1f);

	public static Color progressBarSatisfied = new Color(0.14f, 0.53f, 0.7f, 1f);

	public static Color outputFull = new Color(0.25f, 0.7f, 0.9f, 1f);

	public static Color outputSlowed = new Color(0.35f, 0.85f, 0.85f, 1f);

	public static Color rateSlowed = new Color(0.15f, 0.65f, 0.65f, 1f);

	public static Color outputNormal = new Color(0.75f, 0.95f, 0.95f, 1f);

	public static Color inputStarved = new Color(0.95f, 0.05f, 0.05f, 1f);

	public static Color inputSlowed = new Color(0.95f, 0.05f, 0.05f, 1f);

	public static Color blueFlash1 = new Color(0.14f, 0.53f, 0.7f, 1f);

	public static Color blueFlash2 = new Color(0.05f, 0.84f, 0.95f, 1f);

	public static Color recipeNotActive = new Color(0.85f, 0.85f, 0.85f, 0.85f);

	public static Color processingNormal = Color.green;

	public static Color highlightHoverColor = new Color(0.05f, 0.84f, 0.95f, 0.9f);

	public static Color highlightPressedColor = new Color(0.15f, 0.94f, 0.95f, 0.9f);

	public static Color disabledHighlightColor = new Color(0.8f, 0.8f, 0.8f, 0.8f);

	public static Color highlightSelectedColor = new Color(0.05f, 0.84f, 0.95f, 0.9f);

	public static Color clearWhite = new Color(1f, 1f, 1f, 0f);

	public static Color progressBarNormal = new Color(0.15f, 0.52f, 0.64f, 1f);

	public static Color progresBarImport = new Color(0.45f, 0.72f, 0.84f, 1f);

	public static Color progressBarExport = new Color(0.45f, 0.72f, 0.84f, 1f);

	public static Color progressBarTradeInactive = new Color(0.45f, 0.72f, 0.84f, 0.5f);

	public static Color backgroundSelection = new Color(0.7f, 0.7f, 0.7f, 1f);

	public static Color defaultSelection = new Color(0.22f, 0.82f, 0.82f, 0.5f);

	public static Color backgroundNormal = new Color(0f, 0f, 0f, 0.4f);

	public static Color fulfillment = new Color(0.21f, 0.75f, 0.9f, 1f);

	public static Color listItemBackground = new Color(0.15f, 0.27f, 0.27f, 0.58f);

	public static Color negativeRate = Color.red;

	public static Color inventoryDecrease = new Color(0.95f, 0.95f, 0.05f, 1f);

	public static Color negativeRateFill = new Color(0.73f, 0.15f, 0.08f, 1f);

	public static Color positiveRate = Color.green;

	public static Color positiveRateFill = new Color(0.1f, 0.6f, 0.13f, 1f);

	public static Color neutralRate = Color.white;

	public static Color neutralRateFill = new Color(0.58f, 0.66f, 0.65f, 1f);

	public static Color inheritedStateColor = new Color(1f, 1f, 1f, 0.4f);

	public static Color greyscaleColor = new Color(1f, 1f, 1f, 0.01f);

	public static Color headerButton = new Color(0.16f, 0.27f, 0.27f, 0.59f);

	public static Color productionTooltipHeader = new Color(0.15f, 0.34f, 0.41f, 1f);

	public static Color menuBackgroundColorOpaque = new Color(0.156f, 0.275f, 0.275f, 1f);

	public static Color menuBackgroundColorTransparent = new Color(0.156f, 0.275f, 0.275f, 0.59f);

	public static Color activeBiomeColor;

	public static string backgroundDesertSky = "#00F8FF";

	public static string backgroundDesertGround = "#A8A640";

	public Color biomeBackgroundDesert;

	public Color biomeBackgroundForest;

	public Color biomeBackgroundJungle;

	public Color biomeBackgroundMagic;

	public Color biomeBackgroundMountains;

	public Color biomeBackgroundPlains;

	public Color biomeBackgroundRiver;

	public Color biomeBackgroundSnow;

	public static Color biomePlainsBackgroundDark;

	public static Color biomePlainsBackgroundMed;

	private static ColorManager instance => Instance;

	public void Awake()
	{
		Instance = this;
		ColorUtility.TryParseHtmlString("#39543F", out biomePlainsBackgroundDark);
		ColorUtility.TryParseHtmlString("#456C50", out biomePlainsBackgroundMed);
	}

	public static Color ColorForBiome(BiomeType t)
	{
		return t switch
		{
			BiomeType.Desert => instance.biomeBackgroundDesert, 
			BiomeType.Forest => instance.biomeBackgroundForest, 
			BiomeType.Jungle => instance.biomeBackgroundJungle, 
			BiomeType.Magic => instance.biomeBackgroundMagic, 
			BiomeType.Mountains => instance.biomeBackgroundMountains, 
			BiomeType.Plains => instance.biomeBackgroundPlains, 
			BiomeType.River => instance.biomeBackgroundRiver, 
			BiomeType.Snow => instance.biomeBackgroundSnow, 
			_ => new Color(0.2f, 0.2f, 0.2f, 0.5f), 
		};
	}

	public static Color ColorForHappinessQuintile(int quintile)
	{
		return quintile switch
		{
			0 => new Color(1f, 0.15f, 0f, 1f), 
			1 => new Color(1f, 0.55f, 0f, 1f), 
			2 => new Color(0.9f, 1f, 0f, 1f), 
			3 => new Color(0f, 1f, 0.44f, 1f), 
			4 => new Color(0f, 0.56f, 1f, 1f), 
			_ => Color.white, 
		};
	}

	public static Color ColorForButtonState(CustomButtonState s)
	{
		return s switch
		{
			CustomButtonState.Default => new Color(0.27f, 0.55f, 0.65f, 1f), 
			CustomButtonState.Invalid => new Color(0.92f, 0.1f, 0.1f, 1f), 
			CustomButtonState.Disabled => new Color(0.16f, 0.36f, 0.36f, 0.94f), 
			CustomButtonState.HighlightFlashing => new Color(1f, 1f, 0f, 1f), 
			CustomButtonState.Translucent => new Color(1f, 1f, 1f, 0.2f), 
			CustomButtonState.Background => new Color(0.25f, 0.25f, 0.25f, 0.5f), 
			CustomButtonState.Hidden => new Color(0f, 0f, 0f, 0f), 
			_ => Color.white, 
		};
	}
}
