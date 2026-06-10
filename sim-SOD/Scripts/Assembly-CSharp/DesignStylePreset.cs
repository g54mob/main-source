using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "designstyle_data", menuName = "Database/Decor/Design Style Preset")]
public class DesignStylePreset : SoCustomComparison
{
	[Tooltip("Include this when using citizen stats to pick a style")]
	[Header("Suited Personality")]
	public bool includeInPersonalityMatching;

	[ReorderableList]
	[Tooltip("Compatible Units")]
	public List<LayoutConfiguration> compatibleAddressTypes;

	[Tooltip("The citizen/company must have at least this much wealth to use this decor")]
	[Range(0f, 1f)]
	public float minimumWealth;

	[Tooltip("Honesty-Humility (H): sincere, honest, faithful, loyal, modest/unassuming versus sly, deceitful, greedy, pretentious, hypocritical, boastful, pompous")]
	[Space(5f)]
	[Range(0f, 10f)]
	public int humility;

	[Tooltip("Emotionality (E): emotional, oversensitive, sentimental, fearful, anxious, vulnerable versus brave, tough, independent, self-assured, stable")]
	[Range(0f, 10f)]
	public int emotionality;

	[Tooltip("Extraversion (X): outgoing, lively, extraverted, sociable, talkative, cheerful, active versus shy, passive, withdrawn, introverted, quiet, reserved")]
	[Range(0f, 10f)]
	public int extraversion;

	[Tooltip("Agreeableness (A): patient, tolerant, peaceful, mild, agreeable, lenient, gentle versus ill-tempered, quarrelsome, stubborn, choleric")]
	[Range(0f, 10f)]
	public int agreeableness;

	[Range(0f, 10f)]
	[Tooltip("Conscientiousness (C): organized, disciplined, diligent, careful, thorough, precise versus sloppy, negligent, reckless, lazy, irresponsible, absent-minded")]
	public int conscientiousness;

	[Tooltip("Openness to Experience (O): intellectual, creative, unconventional, innovative, ironic versus shallow, unimaginative, conventional")]
	[Range(0f, 10f)]
	public int creativity;

	[Header("Suited Colour Schemes")]
	[Range(0f, 10f)]
	public int modernity;

	[Header("Ceilings")]
	public bool allowCoving;

	[Header("Misc.")]
	[Tooltip("Force this style if below ground")]
	public bool isBasement;
}
