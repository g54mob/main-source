using UnityEngine;
using UnityEngine.UI;

public class HSVColorLooper : MonoBehaviour
{
	public Image targetImage;

	[Range(0f, 255f)]
	public float startingHue;

	[Range(0f, 1f)]
	public float saturation;

	[Range(0f, 1f)]
	public float value;

	public float hueSpeed;

	private float currentHue;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
