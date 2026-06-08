using System;
using UnityEngine;

public class PlusMinusButtons : AsciiObject
{
	private const int repeatTicDelay = 4;

	public AsciiAnimation inAnm;

	public AsciiAnimation outAnm;

	public DialogButton plusButton;

	public DialogButton minusButton;

	public Color labelColorEnabled = Color.white;

	public Color labelColorDisabled = Color.grey;

	public Action<PlusMinusButtons, bool> OnPlus;

	public Action<PlusMinusButtons, bool> OnMinus;

	private bool showing;

	private bool plusEngaged;

	private int plusRepeatCountdown;

	private bool minusEngaged;

	private int minusRepeatCountdown;

	private bool isPlusKeyDown;

	private bool isMinusKeyDown;

	public int repeatFrameSkip { get; set; }

	public void Show()
	{
		showing = true;
		if (inAnm != null)
		{
			inAnm.Stop();
			inAnm.Play();
		}
	}

	public void Hide()
	{
		if (showing)
		{
			showing = false;
			if (outAnm != null)
			{
				outAnm.Stop();
				outAnm.Play();
			}
		}
	}

	public override void UpdateTic()
	{
		UpdateMinus();
		UpdatePlus();
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		if (showing)
		{
			if (inAnm != null)
			{
				inAnm.Sprite.Draw(r, offsetX, offsetY);
			}
			if (inAnm == null || inAnm.Sprite.GetFrameIndex() >= 4)
			{
				int x = offsetX + plusButton.PositionX + plusButton.Width / 2;
				int y = offsetY + plusButton.PositionY + plusButton.Height / 2;
				r.SetCell(x, y, 43, plusButton.enabled ? labelColorEnabled : labelColorDisabled);
				x = offsetX + minusButton.PositionX + minusButton.Width / 2;
				y = offsetY + minusButton.PositionY + minusButton.Height / 2;
				r.SetCell(x, y, 45, minusButton.enabled ? labelColorEnabled : labelColorDisabled);
				if (minusButton.enabled)
				{
					minusButton.Draw(r, offsetX, offsetY);
				}
				if (plusButton.enabled)
				{
					plusButton.Draw(r, offsetX, offsetY);
				}
				if (minusButton.enabled && minusButton.activated)
				{
					minusButton.Draw(r, offsetX, offsetY);
				}
			}
		}
		else if (outAnm != null)
		{
			outAnm.Sprite.Draw(r, offsetX, offsetY);
		}
	}

	private void BeginPlus()
	{
		if (showing && plusButton.enabled)
		{
			FireOnPlus(isRepeating: false);
			plusEngaged = true;
			plusRepeatCountdown = 4;
		}
	}

	private void UpdatePlus()
	{
		if (showing && plusButton.enabled)
		{
			plusButton.UpdateTic();
			if (plusEngaged && plusRepeatCountdown-- <= 0)
			{
				if (repeatFrameSkip > 0)
				{
					plusRepeatCountdown = repeatFrameSkip;
				}
				if ((AsciiMouse.singleton.isDown0 && plusButton.IsMouseInside()) || isPlusKeyDown)
				{
					FireOnPlus(isRepeating: true);
				}
				else
				{
					plusEngaged = false;
				}
			}
		}
		else
		{
			plusEngaged = false;
		}
	}

	private void BeginMinus()
	{
		if (showing && minusButton.enabled)
		{
			FireOnMinus(isRepeating: false);
			minusEngaged = true;
			minusRepeatCountdown = 4;
		}
	}

	private void UpdateMinus()
	{
		if (showing && minusButton.enabled)
		{
			minusButton.UpdateTic();
			if (minusEngaged && minusRepeatCountdown-- <= 0)
			{
				if (repeatFrameSkip > 0)
				{
					minusRepeatCountdown = repeatFrameSkip;
				}
				if ((AsciiMouse.singleton.isDown0 && minusButton.IsMouseInside()) || isMinusKeyDown)
				{
					FireOnMinus(isRepeating: true);
				}
				else
				{
					minusEngaged = false;
				}
			}
		}
		else
		{
			minusEngaged = false;
		}
	}

	private void HandlePlusButtonDown(DialogButton button)
	{
		BeginPlus();
		if (SfxController.singleton != null)
		{
			SfxController.singleton.Play("click");
		}
	}

	private void HandleMinusButtonDown(DialogButton button)
	{
		BeginMinus();
		if (SfxController.singleton != null)
		{
			SfxController.singleton.Play("click");
		}
	}

	private void Update()
	{
		if (showing)
		{
			if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				BeginPlus();
			}
			else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				BeginMinus();
			}
			isPlusKeyDown = Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.Equals) || Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.UpArrow);
			isMinusKeyDown = Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus) || Input.GetKey(KeyCode.DownArrow);
		}
	}

	private void FireOnPlus(bool isRepeating)
	{
		if (OnPlus != null)
		{
			OnPlus(this, isRepeating);
		}
	}

	private void FireOnMinus(bool isRepeating)
	{
		if (OnMinus != null)
		{
			OnMinus(this, isRepeating);
		}
	}

	private void Start()
	{
		if (inAnm != null)
		{
			inAnm.Sprite.Load();
		}
		if (outAnm != null)
		{
			outAnm.Sprite.Load();
			outAnm.Sprite.SetFrameIndex(outAnm.Sprite.FrameCount - 1);
		}
		plusButton.OnDown += HandlePlusButtonDown;
		minusButton.OnDown += HandleMinusButtonDown;
	}
}
