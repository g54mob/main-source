using UnityEngine;

public class WorldIcon : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	public IconProperties Properties { get; private set; }

	private void Awake()
	{
		_spriteRenderer.material.renderQueue--;
	}

	public void Initialize(IconProperties properties)
	{
		base.gameObject.SetActive(value: true);
		Properties = properties;
		_spriteRenderer.sprite = properties.Sprite;
	}
}
