using System;
using Pug.Sprite;
using UnityEngine;

public class PulseIndirectLight : MonoBehaviour
{
	[Min(0f)]
	public float frequency = 0.25f;

	[Range(0f, 1f)]
	public float amplitude = 0.25f;

	private SpriteRenderer sr;

	private SpriteObject so;

	private Color srColor;

	private Color soColor;

	private float offset;

	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		so = GetComponent<SpriteObject>();
		srColor = (sr ? sr.color : Color.clear);
		soColor = (so ? so.emissiveColor : Color.clear);
		offset = UnityEngine.Random.value * MathF.PI * 2f;
	}

	private void Update()
	{
		float num = 1f + Mathf.Cos(Time.time * frequency * 2f * MathF.PI + offset) * amplitude;
		if ((bool)sr)
		{
			Color color = srColor;
			color.a *= num;
			sr.color = color;
		}
		if ((bool)so)
		{
			Color emissiveColor = soColor;
			emissiveColor.a *= num;
			so.emissiveColor = emissiveColor;
		}
	}
}
