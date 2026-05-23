using System;
using UnityEngine;

public class SuperSimpleOceanAnimation : MonoBehaviour
{
	private Vector3 startPosition;

	private float time;

	[SerializeField]
	private Vector3 waveHeight;

	[SerializeField]
	private float waveFrequency = 0.5f;

	[SerializeField]
	private Vector3 waveSideways;

	[SerializeField]
	private float waveSidewaysFrequency = 0.5f;

	private void Start()
	{
		startPosition = base.transform.position;
	}

	private void Update()
	{
		time += Time.deltaTime;
		base.transform.position = startPosition;
		base.transform.position += waveHeight * Mathf.Sin(time * waveFrequency * MathF.PI);
		base.transform.position += waveSideways * Mathf.Sin(time * waveSidewaysFrequency * MathF.PI);
	}
}
