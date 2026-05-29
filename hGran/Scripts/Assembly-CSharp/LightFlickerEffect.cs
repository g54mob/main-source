using System.Collections.Generic;
using UnityEngine;

public class LightFlickerEffect : MonoBehaviour
{
	[Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
	public Light light;

	[Tooltip("Minimum random light intensity")]
	public float minIntensity;

	[Tooltip("Maximum random light intensity")]
	public float maxIntensity;

	[Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
	[Range(1f, 50f)]
	public int smoothing;

	private Queue<float> smoothQueue;

	private float lastSum;

	public void Reset()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
