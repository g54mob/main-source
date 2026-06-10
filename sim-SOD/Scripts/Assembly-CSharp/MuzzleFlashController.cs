using UnityEngine;

public class MuzzleFlashController : MonoBehaviour
{
	[Header("Settings")]
	public Color startColour;

	public Color endColour;

	public float maxIntensity;

	public float maxRange;

	public float duration;

	public AnimationCurve curve;

	[Header("Components")]
	public Light light;

	[Header("State")]
	public float timer;

	public float progress;

	private void Update()
	{
	}
}
