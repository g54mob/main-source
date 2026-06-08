public class SettingsToggleButton : ToggleButton
{
	public AsciiSprite background;

	public AsciiAnimation onAnm;

	public AsciiAnimation offAnm;

	private AsciiSprite currentSprite;

	private bool hasChecked;

	private bool lastState = true;

	public void JumpAnimation()
	{
		LoadSprites();
		onAnm.Sprite.SetFrameIndex(onAnm.Sprite.FrameCount - 1);
		offAnm.Sprite.SetFrameIndex(offAnm.Sprite.FrameCount - 1);
		lastState = base.isOn;
		hasChecked = true;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		background.Draw(r, offsetX, offsetY);
		if (lastState != base.isOn || !hasChecked)
		{
			lastState = base.isOn;
			hasChecked = true;
			if (base.isOn)
			{
				onAnm.Play();
			}
			else
			{
				offAnm.Play();
			}
		}
		if (base.isOn)
		{
			onAnm.Sprite.Draw(r, offsetX, offsetY);
		}
		else
		{
			offAnm.Sprite.Draw(r, offsetX, offsetY);
		}
	}

	protected override void Start()
	{
		base.Start();
		LoadSprites();
	}

	private void LoadSprites()
	{
		background.Load();
		onAnm.Sprite.Load();
		offAnm.Sprite.Load();
	}
}
