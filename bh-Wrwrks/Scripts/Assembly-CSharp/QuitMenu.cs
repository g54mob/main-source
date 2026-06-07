using UnityEngine;

public class QuitMenu : Menu
{
	public UIButton button;

	public SpriteRenderer warning;

	private void Start()
	{
		button.bg.sprite = (Dungeon.Instance.paused ? Dungeon.Instance.currentLocale.quitConfirm : Dungeon.Instance.currentLocale.quitButton);
		warning.sprite = (Dungeon.Instance.paused ? Dungeon.Instance.currentLocale.quitWarn : Dungeon.Instance.currentLocale.quitDesktopWarn);
		if (!Dungeon.Instance.paused)
		{
			button.f = UIButton.func.Quit;
		}
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
