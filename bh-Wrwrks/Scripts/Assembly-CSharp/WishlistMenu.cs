using UnityEngine;

public class WishlistMenu : Menu
{
	public Animator prev0;

	public Animator prev1;

	public SpriteRenderer items;

	public UIButton wishbutton;

	public void Start()
	{
		items.sprite = Dungeon.Instance.currentLocale.wishItems;
		wishbutton.SetSprite(Dungeon.Instance.currentLocale.wishButton);
		prev0.frames = Utils.Shuffle(prev0.frames);
		prev1.frames = prev0.frames;
		Invoke("SetAnim", 1f / 60f);
	}

	private void SetAnim()
	{
		prev1.GetComponent<SpriteRenderer>().sprite = prev1.frames[6];
		prev1.currFrame = 7;
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
