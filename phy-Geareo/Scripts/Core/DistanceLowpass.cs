using UnityEngine;

[RequireComponent(typeof(AudioLowPassFilter))]
public class DistanceLowpass : MonoBehaviour
{
	public AnimationCurve curve;

	private AudioLowPassFilter lp;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
