using UnityEngine;

[CreateAssetMenu(fileName = "New Outline Config", menuName = "Fishing/Outline Config", order = 1)]
public class OutlineConfig : ScriptableObject
{
	[Header("Line Settings")]
	[Tooltip("The thickness of the outline per rarity. Default is 9.")]
	public float commonThickness = 9f;

	public float uncommonThickness = 9f;

	public float rareThickness = 9f;

	public float epicThickness = 9f;

	public float legendaryThickness = 9f;

	[Header("Rarity Colors")]
	[ColorUsage(true, true)]
	public Color commonColor = Color.white;

	[ColorUsage(true, true)]
	public Color uncommonColor = Color.green;

	[ColorUsage(true, true)]
	public Color rareColor = Color.blue;

	[ColorUsage(true, true)]
	public Color epicColor = Color.magenta;

	[ColorUsage(true, true)]
	public Color legendaryColor = new Color(1f, 0.5f, 0f);

	public float GetLineThickness(FishRarity rarity)
	{
		return rarity switch
		{
			FishRarity.Common => commonThickness, 
			FishRarity.Uncommon => uncommonThickness, 
			FishRarity.Rare => rareThickness, 
			FishRarity.Epic => epicThickness, 
			FishRarity.Legendary => legendaryThickness, 
			_ => 9f, 
		};
	}

	public Color GetColor(FishRarity rarity)
	{
		return rarity switch
		{
			FishRarity.Common => commonColor, 
			FishRarity.Uncommon => uncommonColor, 
			FishRarity.Rare => rareColor, 
			FishRarity.Epic => epicColor, 
			FishRarity.Legendary => legendaryColor, 
			_ => Color.white, 
		};
	}
}
