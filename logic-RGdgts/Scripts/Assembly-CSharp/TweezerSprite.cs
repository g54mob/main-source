using Sirenix.OdinInspector;
using UnityEngine;

public class TweezerSprite : SerializedMonoBehaviour
{
	public SpriteRenderer spriteRenderer;

	public Transform center;

	public Transform invalidPositionMarker;

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
