using UnityEngine;

[CreateAssetMenu(fileName = "LightDataSO", menuName = "Construction/LightDataSO")]
public class LightDataSO : ScriptableObject
{
	[field: SerializeField]
	public float HeightFromGround { get; private set; }

	[field: SerializeField]
	public Light PointLightPrefab { get; private set; }

	[field: SerializeField]
	public RangeIntensityCouple[] RangeIntensityCouples { get; private set; }

	[field: SerializeField]
	public Color[] Colors { get; private set; }
}
