using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "spatter_data", menuName = "Database/Spatter Pattern")]
public class SpatterPatternPreset : SoCustomComparison
{
	[Header("Configuration")]
	public int spatterCount;

	public float maxAngleX;

	public float maxAngleY;

	[MinMaxSlider(0f, 10f)]
	public Vector2 rayLength;

	public AnimationCurve spreadCurve;

	public Material heavyMaterial;

	public Material mediumMaterial;

	public Material lightMaterial;
}
