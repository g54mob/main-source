using UnityEngine;

[CreateAssetMenu(fileName = "New Aerodynamic Surface Config", menuName = "Aerodynamic Surface Config")]
public class AeroSurfaceConfig : ScriptableObject
{
	public float liftSlope = 6.28f;

	public float skinFriction = 0.02f;

	public float zeroLiftAoA;

	public float stallAngleHigh = 15f;

	public float stallAngleLow = -15f;

	public float chord = 1f;

	public float flapFraction;

	public float span = 1f;

	public bool autoAspectRatio = true;

	public float aspectRatio = 2f;

	private void OnValidate()
	{
		if (flapFraction > 0.4f)
		{
			flapFraction = 0.4f;
		}
		if (flapFraction < 0f)
		{
			flapFraction = 0f;
		}
		if (stallAngleHigh < 0f)
		{
			stallAngleHigh = 0f;
		}
		if (stallAngleLow > 0f)
		{
			stallAngleLow = 0f;
		}
		if (chord < 0.001f)
		{
			chord = 0.001f;
		}
		if (autoAspectRatio)
		{
			aspectRatio = span / chord;
		}
	}
}
