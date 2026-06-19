using System;
using Pug.UnityExtensions;
using UnityEngine;

public class RotationalFloat : MonoBehaviour
{
	[Header("Core settings:")]
	public float intensity = 0.25f;

	public float speed = 1f;

	public bool randomSeed = true;

	[Header("Flavor settings:")]
	public float clampSinMin = -1f;

	public float clampSinMax = 1f;

	private float _startZRot;

	public float seed = 31.438f;

	public void Start()
	{
		if (randomSeed)
		{
			seed = PugRandom.GenerateUniform(0f, MathF.PI * 128f);
		}
		_startZRot = base.transform.localRotation.eulerAngles.z;
	}

	private void Update()
	{
		base.transform.SetLocalRotationZ(_startZRot + intensity * Mathf.Clamp(Mathf.Sin(speed * Time.time * 1.5f + seed), clampSinMin, clampSinMax));
	}
}
