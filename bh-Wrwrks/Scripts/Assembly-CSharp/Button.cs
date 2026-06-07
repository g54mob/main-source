using UnityEngine;

public class Button : MonoBehaviour
{
	public Module owner;

	public SpriteRenderer spriteRenderer;

	public Sprite upSprite;

	public Sprite downSprite;

	private void OnMouseDown()
	{
		owner.ActivateButton();
		spriteRenderer.sprite = downSprite;
	}

	private void OnMouseUp()
	{
		spriteRenderer.sprite = upSprite;
	}

	private void OnMouseEnter()
	{
		owner.dungeon.tooltip.Set(owner);
	}

	private void OnMouseExit()
	{
		owner.dungeon.tooltip.Hide();
		spriteRenderer.sprite = upSprite;
	}
}
