using UnityEngine;

[CreateAssetMenu(fileName = "effect_data", menuName = "Database/Effect Preset")]
public class EffectPreset : SoCustomComparison
{
	public bool firstValueIsPercentageIncrease;

	public bool runActivationOnUpdate;
}
