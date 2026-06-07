using System;
using UnityEngine;

public class TOD_Animation : MonoBehaviour
{
	[Tooltip("Wind direction in degrees.")]
	public float WindDegrees;

	[Tooltip("Speed of the wind that is acting on the clouds.")]
	public float WindSpeed = 1f;

	private TOD_Sky sky;

	public Vector3 CloudUV { get; set; }

	public Vector3 OffsetUV
	{
		get
		{
			Vector3 vector = (PositionProvider?.Invoke(this) ?? base.transform.position) * 0.0001f;
			return Quaternion.Euler(0f, 0f - base.transform.rotation.eulerAngles.y, 0f) * vector;
		}
	}

	public Func<TOD_Animation, Vector3> PositionProvider { get; set; } = (TOD_Animation script) => script.transform.position;

	protected void Start()
	{
		sky = GetComponent<TOD_Sky>();
		CloudUV = new Vector3(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
	}

	protected void Update()
	{
		float num = Mathf.Sin(MathF.PI / 180f * WindDegrees);
		float num2 = Mathf.Cos(MathF.PI / 180f * WindDegrees);
		float num3 = 0.001f * Time.deltaTime;
		float num4 = WindSpeed * num3;
		float x = CloudUV.x;
		float y = CloudUV.y;
		float z = CloudUV.z;
		y += num3 * 0.1f;
		x -= num4 * num;
		z -= num4 * num2;
		x -= Mathf.Floor(x);
		y -= Mathf.Floor(y);
		z -= Mathf.Floor(z);
		CloudUV = new Vector3(x, y, z);
		sky.Components.BillboardTransform.localRotation = Quaternion.Euler(0f, y * 360f, 0f);
	}
}
