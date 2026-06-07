using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class AirbrushSprite : SerializedMonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public Transform center;

	[HideInInspector]
	public SpriteShadow shadow;

	public Transform cable;

	public BrushSizeWheel brushSizeWheel;

	public Sprite[] sprites;

	public SpriteRenderer[] colors;

	public Dictionary<BrushGestaltEnum, SpriteRenderer> tips;

	private int spriteI;

	private BrushGestaltEnum brushEnum;

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	public void SetSprite(int spriteI)
	{
	}

	public void SetBrush(BrushGestaltEnum brushEnum)
	{
	}

	public void SetBrushSize(int brushSize)
	{
	}

	public void SetColor(int slot, int colorI)
	{
	}
}
