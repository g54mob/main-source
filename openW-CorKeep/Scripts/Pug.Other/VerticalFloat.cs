using System;
using Pug.UnityExtensions;
using UnityEngine;

public class VerticalFloat : MonoBehaviour
{
	[Header("Core settings:")]
	public float intensity = 0.25f;

	public float speed = 1f;

	public bool randomSeed = true;

	[Header("Flavor settings:")]
	public float clampSinMin = -1f;

	public float clampSinMax = 1f;

	private float _startY;

	public float seed = 31.438f;

	public void Start()
	{
		if (randomSeed)
		{
			seed = PugRandom.GenerateUniform(0f, MathF.PI * 128f);
		}
		_startY = base.transform.localPosition.y;
	}

	private void Update()
	{
		float num = base.transform.localScale.y * intensity * Mathf.Clamp(Mathf.Sin(speed * Time.time * 1.5f + seed), clampSinMin, clampSinMax);
		base.transform.SetLocalPositionY(_startY + num);
	}
}
