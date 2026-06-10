using UnityEngine;

[CreateAssetMenu(fileName = "colourscheme_data", menuName = "Database/Colour Scheme")]
public class ColourSchemePreset : SoCustomComparison
{
	[Header("Colours")]
	public Color primary1;

	public Color secondary1;

	public Color neutral;

	public Color secondary2;

	public Color primary2;

	[Range(0f, 10f)]
	[Tooltip("0 = old fashioned/conservative, 1 = modern/liberal: Driven by the design style")]
	[Header("Settings")]
	public int modernity;

	[Range(0f, 10f)]
	[Tooltip("0 = informal/cosy, 1 = clean/souless: Driven by the room type.")]
	public int cleanness;

	[Range(0f, 10f)]
	[Tooltip("0 = understated/quiet, 1 = loud/bold: Driven by the owner's personality")]
	public int loudness;

	[Tooltip("0 = cold/hard, 1 = warm/sensitive: Driven by the owner's personality")]
	[Range(0f, 10f)]
	public int emotive;
}
