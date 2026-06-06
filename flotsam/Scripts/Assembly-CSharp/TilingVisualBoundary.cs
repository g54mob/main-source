using UnityEngine;

public class TilingVisualBoundary : VisualBoundary
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	public override void SetSize(float width, float height)
	{
		base.SetSize(width, height);
		_spriteRenderer.size = new Vector2(width * 2f, height * 2f);
	}
}
