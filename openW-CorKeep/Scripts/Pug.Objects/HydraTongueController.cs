using System;
using UnityEngine;

public class HydraTongueController : MonoBehaviour
{
	public Transform bone1;

	public Transform bone2;

	public float frequency = 10f;

	[Space(10f)]
	[Range(0f, 1f)]
	public float extended = 1f;

	private float Remap(float x, float a, float b)
	{
		return Mathf.Clamp01(extended - a) / (b - a);
	}

	private void LateUpdate()
	{
		float num = Remap(extended, 0.7f, 1f);
		bone1.localPosition = new Vector3(0f, -0.8f * extended, 0f);
		bone2.localEulerAngles = new Vector3(Mathf.Cos(Time.time * 2f * MathF.PI * frequency) * 50f * Mathf.Sqrt(num), 0f, 0f);
		bone2.localScale = new Vector3(Mathf.Lerp(0.1f, 1f, num), 1f, 1f);
	}
}
