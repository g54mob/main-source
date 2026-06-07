using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RandomizeSprite : MonoBehaviour
{
	[SerializeField]
	private Sprite[] sprites;

	private SpriteRenderer sr;

	private void Start()
	{
		if (sprites.Length != 0)
		{
			sr = GetComponent<SpriteRenderer>();
			sr.sprite = sprites[Random.Range(0, sprites.Length)];
		}
	}
}
