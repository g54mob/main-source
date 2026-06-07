using UnityEngine;

[CreateAssetMenu(fileName = "New Lighting Preset", menuName = "Day Cycle/Lighting Preset")]
public class LightingPresetsSO : ScriptableObject
{
	public Gradient[] AmbientColors;

	[Space]
	public AnimationCurve LightTemperatures;

	[Space]
	public AnimationCurve LightIntensities;

	[Space]
	public AnimationCurve SkyboxTransition;

	[Space]
	public Vector3 SunStartingAngles;

	public Vector3 SunSetAngles;

	public float SkyboxRotationStartingValue;
}
