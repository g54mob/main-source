using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class ColorRotator : MonoBehaviour
{
	private int targetColorIndex;

	public List<Color> possibleColors;

	public float timeBetweenColors = 0.8f;

	private float timeAcc;

	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		timeAcc += Time.deltaTime;
		if (timeAcc > timeBetweenColors)
		{
			targetColorIndex = PugRandom.GenerateUniformAndSkip(0, possibleColors.Count, targetColorIndex);
			timeAcc = 0f;
		}
		if (targetColorIndex < possibleColors.Count)
		{
			Color color = spriteRenderer.color;
			Color b = possibleColors[targetColorIndex];
			Color color2 = Color.Lerp(color, b, Time.deltaTime);
			spriteRenderer.color = color2;
		}
	}
}
