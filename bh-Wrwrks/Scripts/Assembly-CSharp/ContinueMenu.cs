using UnityEngine;

public class ContinueMenu : Menu
{
	public SpriteRenderer items;

	public UIButton contButton;

	public UIButton abandonButton;

	private void Start()
	{
		items.sprite = Dungeon.Instance.currentLocale.continueItems;
		contButton.SetSprite(Dungeon.Instance.currentLocale.continueMenuButton);
		abandonButton.SetSprite(Dungeon.Instance.currentLocale.continueAbandon);
	}

	public override void BounceButton(UIButton b, int f = 2, bool silent = false)
	{
		if (f == 1)
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f, 0.8f);
		}
		else
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.9f, 0.5f);
		}
		base.BounceButton(b, f, silent);
	}
}
