using System;
using Pug.UnityExtensions;
using UnityEngine;

public class HorizontalFloat : MonoBehaviour
{
	public float intensityX = 0.25f;

	public float intensityZ = 0.25f;

	public float speedX = 1f;

	public float speedZ = 1f;

	public bool randomSeed = true;

	private float _startX;

	private float _startZ;

	public float seed = 31.438f;

	public void Start()
	{
		if (randomSeed)
		{
			seed = PugRandom.GenerateUniform(0f, MathF.PI * 128f);
		}
		_startX = base.transform.localPosition.x;
		_startZ = base.transform.localPosition.z;
	}

	private void Update()
	{
		base.transform.SetLocalPositionX(_startX + intensityX * Mathf.Sin(speedX * Time.time * 1.5f + seed));
		base.transform.SetLocalPositionZ(_startZ + intensityZ * Mathf.Sin(speedZ * Time.time * 1.5f + seed));
	}
}
