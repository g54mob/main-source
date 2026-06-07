using System;
using DV;
using UnityEngine;

public class TOD_Animation : MonoBehaviour
{
	[Tooltip("How much to move the clouds when the camera moves.")]
	[TOD_Min(0f)]
	public float CameraMovement = 1f;

	[Tooltip("Wind direction in degrees.")]
	[TOD_Range(0f, 360f)]
	public float WindDegrees;

	[Tooltip("Speed of the wind that is acting on the clouds.")]
	[TOD_Min(0f)]
	public float startingWindSpeed = 1f;

	private TOD_Sky sky;

	private TOD_Time time;

	public Vector3 CloudUV { get; set; }

	public Vector3 OffsetUV => Vector3.zero;

	public OverridableValue<float> WindSpeed { get; } = new OverridableValue<float>();

	protected void Start()
	{
		sky = GetComponent<TOD_Sky>();
		time = GetComponent<TOD_Time>();
		WindSpeed.RealValue = startingWindSpeed;
		CloudUV = new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
	}

	protected void Update()
	{
		float num = Mathf.Sin((float)Math.PI / 180f * WindDegrees);
		float num2 = Mathf.Cos((float)Math.PI / 180f * WindDegrees);
		float num3 = (float)WindSpeed * time.TimeRate;
		float num4 = 0.001f * Time.deltaTime;
		float num5 = num3 * num4;
		float x = CloudUV.x;
		float y = CloudUV.y;
		float z = CloudUV.z;
		y += num4 * 0.1f;
		x -= num5 * num;
		z -= num5 * num2;
		x -= Mathf.Floor(x);
		y -= Mathf.Floor(y);
		z -= Mathf.Floor(z);
		CloudUV = new Vector3(x, y, z);
		sky.Components.BillboardTransform.localRotation = Quaternion.Euler(0f, y * 360f, 0f);
	}
}
