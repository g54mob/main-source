using System;
using UnityEngine;

[Serializable]
public class MSWaterClass
{
	[Tooltip("The name of the object that contains the collider(trigger), responsible for defining the water area")]
	public string waterName = "Water";

	[Tooltip("The tag of the object that contains the collider(trigger), responsible for defining the water area")]
	public string waterTag = "Respawn";

	[Header("Auto ID")]
	[Tooltip("This variable is set automatically, and represents the ID of this water setting.")]
	public int automaticWaterID;

	[Space(10f)]
	[Tooltip("The color of the water below the surface")]
	public Color waterColor = new Color32(15, 150, 125, 0);

	[Range(0.01f, 0.7f)]
	[Tooltip("How much the vortex effect will distort the screen image.")]
	public float vortexDistortion = 0.45f;

	[Range(0.01f, 0.7f)]
	[Tooltip("The size of the distortion that the image will receive under the water because of the 'fisheye' effect.")]
	public float fisheyeDistortion = 0.3f;

	[Range(0.01f, 0.3f)]
	[Tooltip("The speed of the distortion that the image will receive under the water")]
	public float distortionSpeed = 0.2f;

	[Range(0.1f, 0.9f)]
	[Tooltip("The intensity of the color of the water below the surface")]
	public float colorIntensity = 0.3f;

	[Range(0.1f, 10f)]
	[Tooltip("The visibility underwater")]
	public float visibility = 10f;
}
