using Sirenix.OdinInspector;
using UnityEngine;

public class SoldererSprite : SerializedMonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public Transform center;

	[HideInInspector]
	public SpriteShadow shadow;

	public Sprite[] sprites;

	private int spriteI;

	private void Awake()
	{
	}

	public void SetSprite(int spriteI)
	{
	}
}
