using System;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class LightControlBehaviour : PlayableBehaviour
{
	public Color color;

	public float intensity;

	public float bounceIntensity;

	public float range;
}
