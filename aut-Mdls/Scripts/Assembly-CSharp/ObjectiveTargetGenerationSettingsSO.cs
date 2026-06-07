using UnityEngine;

[CreateAssetMenu(menuName = "Objectives/Target Generation Settings")]
public class ObjectiveTargetGenerationSettingsSO : ScriptableObject
{
	public int TierIncrement = 25;

	[Header("Desired 'hardcoded' amounts")]
	public uint BotTier1Amount = 1u;

	public uint BotTier2Amount = 20u;

	[Header("Rounding to Nearest Multiple")]
	[Tooltip("Target amounts will be rounded to the nearest multiple of this value.")]
	public uint RoundToNearestMultiple = 50u;

	public uint[] ModuleChallengeAmounts = new uint[3] { 1u, 50u, 500u };
}
