using UnityEngine;

public class PerkDisplay : MonoBehaviour
{
	public Perks.Type type;

	public SpriteRenderer spriteRenderer;

	public bool preview;

	public Dungeon dungeon => Dungeon.Instance;

	public void Set(Perks.Type t)
	{
		type = t;
		spriteRenderer.sprite = dungeon.perks.spriteList[(int)t];
	}

	private void OnMouseEnter()
	{
		dungeon.tooltip.Set(null, showUpgrade: false, noUpgrade: false, this);
	}

	private void OnMouseExit()
	{
		dungeon.tooltip.Hide();
		dungeon.board.UnhighlightAll();
	}

	private void OnMouseOver()
	{
		dungeon.perks.Highlight(type);
	}
}
