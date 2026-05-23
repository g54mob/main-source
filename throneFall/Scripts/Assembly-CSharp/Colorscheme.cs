using UnityEngine;

[CreateAssetMenu(fileName = "New Color Scheme", menuName = "SimpleSiege/Colorscheme")]
public class Colorscheme : ScriptableObject
{
	public readonly Color dayLightColor = Color.white;

	public Color sunsetLightColor;

	public Color nightLightColor;

	public Color globalShadowColor;

	public Color bonfireLightColor = new Color(1f, 0.701447f, 0.1273585f);

	[Header("Enemies")]
	public Color enemyLightColor;

	public Color enemyMidColor;

	[Header("Allies")]
	public Color allyLightColor;

	public Color allyMidColor;

	public Color allyRangedLightColor;

	public Color allyRangedMidColor;

	public Color allyMeleeIndicatorColor;

	public Color allyRangedIndicatorColor;

	[Header("Player")]
	public Color playerLightColor;

	public Color playerMidColor;

	public Color playerCapeLightColor;

	public Color playerCapeMidColor;

	public Color playerCrownLightColor;

	public Color playerCrownMidColor;

	public Color horseLightColor;

	public Color horseMidColor;

	[Header("Buildings")]
	public Color buildingLightColor;

	public Color buildingMidColor;

	public Color coinLightColor;

	public Color coinMidColor;

	[Header("Environment")]
	public Color groundColor;

	public Color groundColorHigh;

	public Color groundColorLow;

	public Color earthLightColor;

	public Color earthMidColor;

	public Color sandColor;

	public Color treeLightColor;

	public Color treeMidColor;

	public Color rockLightColor;

	public Color rockMidColor;

	public Color waterLightColor;

	public Color waterSecondaryColor;

	public Color roadColor;

	[Header("UI")]
	public Color upgradeInteractorColor;

	[Header("Particles")]
	public GameObject particlesToAttachToPlayer;

	private void OnValidate()
	{
		ColorAndLightManager colorAndLightManager = Object.FindObjectOfType<ColorAndLightManager>();
		if ((bool)colorAndLightManager)
		{
			colorAndLightManager.ApplyColorScheme(this);
		}
	}
}
