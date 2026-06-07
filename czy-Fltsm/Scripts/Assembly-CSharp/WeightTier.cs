using I2.Loc;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Weight Tier", menuName = "Flotsam/Buildable/Weight Tier")]
public class WeightTier : ScriptableObject
{
	public LocalizedString Name = null;

	[MinMaxRangeFloat(0f, 1f)]
	public RangedFloat Limits;

	[FormerlySerializedAs("EnergyModifier")]
	[Tooltip("The amount of eels needed to move a single unit")]
	public float EelsPerUnit = 1f;

	public Color Color = Color.white;

	public Color LabelColor = Color.white;

	public float ReturnNormalizedWeightProgress(float weight)
	{
		float num = Limits.Maximum - Limits.Minimum;
		return (weight - Limits.Minimum) / num;
	}

	public bool IsInRange(float value)
	{
		return Limits.ReturnContainsValue(value);
	}
}
