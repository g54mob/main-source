using UnityEngine;

public class XpGainedDialog : ScrollBG
{
	private enum XpDialogState
	{
		Waiting = 0,
		FillingBar = 1,
		NoLevelUpDone = 2,
		LevelUp = 3,
		LevelUpDone = 4
	}

	public AsciiString xpGainedLabel;

	public AsciiString levelUpLabel;

	public AsciiString healthGainedLabel;

	public AsciiString x3_Label;

	public int barPosX;

	public int barPosY;

	public int barPosXLevelUp;

	public int waitingDuration = 20;

	public int levelUpDuration = 20;

	public XPBar xpBarPrefab;

	private XPBar xpBar;

	public AsciiAnimation vfxAnmPrefab;

	private AsciiAnimation vfxAnm;

	private XpDialogState currentXpDialogState;

	private int xpDialogStateElapsedTics;

	private int currentBarY;

	private bool skipBuffered;

	public void Setup_Pre()
	{
		XPController singleton = XPController.singleton;
		xpBar.levelNumber = singleton.currentLevel;
		xpBar.startXP = singleton.currentXP;
		xpBar.totalXP = singleton.nextXpThreshold;
		xpBar.isMaxLevel = singleton.isMaxLevel;
	}

	public void Setup_Post(int xpGained)
	{
		xpBar.endXP = Mathf.Min(xpBar.startXP + xpGained, xpBar.totalXP);
		xpBar.PrepareToShow();
		xpGainedLabel.SetValue(string.Format(Te.xt("+{0} Experience"), xpGained));
		if (EventController.singleton.CanPlayerSeeEvents() && EventController.singleton.IsEventActive("3xXP"))
		{
			x3_Label.SetValue("x3");
		}
		else
		{
			x3_Label.Clear();
		}
		SetXpDialogState(XpDialogState.Waiting);
	}

	public void Show()
	{
		SfxController.singleton.Play("treasure_close");
		SetState(State.In);
	}

	public void Hide()
	{
		SfxController.singleton.Play("treasure_close");
		SetState(State.Out);
	}

	private void SetXpDialogState(XpDialogState newState)
	{
		if (newState != XpDialogState.LevelUp && newState != XpDialogState.LevelUpDone)
		{
			vfxAnm.gameObject.SetActive(value: false);
		}
		switch (newState)
		{
		case XpDialogState.Waiting:
			currentBarY = barPosY;
			break;
		case XpDialogState.FillingBar:
			xpBar.Play();
			break;
		case XpDialogState.LevelUp:
			xpBar.levelNumber = XPController.singleton.currentLevel;
			xpBar.ClearXPValues();
			vfxAnm.gameObject.SetActive(value: true);
			vfxAnm.Stop();
			vfxAnm.Play();
			SfxController.singleton.Play("level_up");
			break;
		case XpDialogState.LevelUpDone:
			GameStates.Singleton.hero.UpdateHitpoints();
			break;
		}
		currentXpDialogState = newState;
		xpDialogStateElapsedTics = 0;
		skipBuffered = false;
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		xpDialogStateElapsedTics++;
		if (currentXpDialogState == XpDialogState.Waiting && xpDialogStateElapsedTics >= waitingDuration)
		{
			SetXpDialogState(XpDialogState.FillingBar);
		}
		else if (currentXpDialogState == XpDialogState.FillingBar)
		{
			if (!xpBar.playing)
			{
				if (IsThereLevelUp())
				{
					SetXpDialogState(XpDialogState.LevelUp);
				}
				else
				{
					SetXpDialogState(XpDialogState.NoLevelUpDone);
				}
			}
			else if (AsciiMouse.singleton.down0)
			{
				xpBar.SkipToEnd();
			}
		}
		else if (currentXpDialogState == XpDialogState.LevelUp)
		{
			if (currentBarY > barPosXLevelUp && xpDialogStateElapsedTics % 2 == 1)
			{
				currentBarY--;
			}
			if (xpDialogStateElapsedTics >= levelUpDuration)
			{
				SetXpDialogState(XpDialogState.LevelUpDone);
			}
		}
		else if (currentXpDialogState == XpDialogState.LevelUpDone || currentXpDialogState == XpDialogState.NoLevelUpDone)
		{
			if (AsciiMouse.singleton.up0 || skipBuffered)
			{
				skipBuffered = false;
				Hide();
			}
			else if (OuroborosWeapon.IsEnabled() && ((XPController.singleton.isMaxLevel && base.ElapsedStateTics >= 900) || (!XPController.singleton.isMaxLevel && base.ElapsedStateTics >= 55)))
			{
				Hide();
			}
		}
	}

	private bool IsThereLevelUp()
	{
		if (XPController.singleton.currentLevel <= xpBar.levelNumber)
		{
			return currentXpDialogState >= XpDialogState.LevelUp;
		}
		return true;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (!(scaleX >= 0.1f))
		{
			return;
		}
		int num = (int)((float)Width * scaleX);
		int num2 = offsetX + PositionX + (Width - num) / 2;
		r.PushClip(new AsciiRenderProcedural.Clip
		{
			left = num2,
			right = num2
		});
		xpBar.Draw(r, offsetX + barPosX, offsetY + currentBarY);
		if (currentXpDialogState == XpDialogState.Waiting || currentXpDialogState == XpDialogState.FillingBar || currentXpDialogState == XpDialogState.NoLevelUpDone)
		{
			xpGainedLabel.Draw(r, offsetX, offsetY);
		}
		else if (currentXpDialogState == XpDialogState.LevelUp || currentXpDialogState == XpDialogState.LevelUpDone)
		{
			levelUpLabel.Draw(r, offsetX, offsetY);
			if (currentXpDialogState == XpDialogState.LevelUpDone)
			{
				healthGainedLabel.Draw(r, offsetX, offsetY);
			}
		}
		if (currentXpDialogState < XpDialogState.LevelUp)
		{
			x3_Label.Draw(r, offsetX, offsetY);
		}
		r.PopClip();
		if (currentXpDialogState == XpDialogState.LevelUp || currentXpDialogState == XpDialogState.LevelUpDone)
		{
			vfxAnm.Sprite.Draw(r, offsetX, offsetY);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		xpBar = Object.Instantiate(xpBarPrefab);
		xpBar.Load();
	}

	protected override void Start()
	{
		base.Start();
		vfxAnm = Object.Instantiate(vfxAnmPrefab);
		vfxAnm.Sprite.Load();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			skipBuffered = true;
		}
	}
}
