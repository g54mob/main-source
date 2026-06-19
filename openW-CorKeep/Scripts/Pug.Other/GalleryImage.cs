using UnityEngine;

public class GalleryImage : RadicalMainMenuOption
{
	public SpriteRenderer spriteRenderer;

	public SpriteRenderer border;

	public float GetHalfImageWidth()
	{
		return spriteRenderer.bounds.size.x / 2f;
	}

	private void Start()
	{
		float num = 0.375f;
		border.size = spriteRenderer.bounds.size + new Vector3(num, num, 0f);
	}

	public void MakeTransparent(bool makeTransparent)
	{
		if (makeTransparent)
		{
			spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
			border.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		}
		else
		{
			spriteRenderer.color = Color.white;
			border.color = Color.white;
		}
	}
}
