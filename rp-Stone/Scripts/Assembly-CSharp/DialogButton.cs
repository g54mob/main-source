using System;
using UnityEngine;

public class DialogButton : DialogNineSlice, ICellInteractable, INavigatable
{
	public AsciiString label;

	public int touchDownDelay;

	public int clickPaddingTop;

	public int clickPaddingBottom;

	public int clickPaddingLeft;

	public int clickPaddingRight;

	public bool highlightPadding = true;

	public Color highlightColor = ColorConstants.white;

	public string pressedSfxId = "click";

	public bool rightClickSupported;

	private bool hasFocus = true;

	public AsciiBadge badge;

	public int clickPriorityBonus;

	private int _lastDrawnX;

	private int _lastDrawnY;

	private bool _isDisabled;

	private Color defaultEdgeColor;

	protected AsciiSprite mySprite;

	private int isUpdating;

	private int _touchDownDelayRemaining = -1;

	public bool HasFocus
	{
		get
		{
			return hasFocus;
		}
		set
		{
			hasFocus = value;
		}
	}

	public int lastDrawnX => _lastDrawnX;

	public int lastDrawnY => _lastDrawnY;

	public bool activated { get; set; }

	public bool activatedSecondary { get; set; }

	public bool isDisabledState
	{
		get
		{
			return _isDisabled;
		}
		set
		{
			if (_isDisabled != value)
			{
				_isDisabled = value;
				if (_isDisabled)
				{
					defaultEdgeColor = edgeSymbols.color;
					edgeSymbols.color *= 0.5f;
				}
				else
				{
					edgeSymbols.color = defaultEdgeColor;
				}
			}
		}
	}

	public KeyCode keyCode { get; set; }

	public Binding.Action action { get; set; }

	public event Action<DialogButton> OnDown;

	public event Action<DialogButton> OnOver;

	public event Action<DialogButton> OnUp;

	public event Action<DialogButton> OnPressed;

	public event Action<DialogButton> OnSecondaryPressed;

	protected override void Start()
	{
		base.Start();
		InitSprite();
		if (Features.IS_TOUCH_MACRO && touchDownDelay < 4)
		{
			touchDownDelay = 4;
		}
		ScrollContainer.OnScrollContainerHasBeenDragged += HandleScrollContainerHasBeenDragged;
	}

	protected virtual void OnDestroy()
	{
		ScrollContainer.OnScrollContainerHasBeenDragged -= HandleScrollContainerHasBeenDragged;
	}

	private void Update()
	{
		if (isUpdating > 0 && hasFocus)
		{
			if (Input.GetKeyDown(keyCode) || Binding.singleton.IsDown(action))
			{
				FireOnPressed();
			}
			isUpdating--;
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (isDisabledState)
		{
			activated = false;
			activatedSecondary = false;
			_touchDownDelayRemaining = -1;
			return;
		}
		isUpdating = 4;
		bool flag = IsMouseInside();
		if (flag)
		{
			if (AsciiMouse.singleton.up0)
			{
				FireOnUp();
			}
			else if (AsciiMouse.singleton.isDragging0 && (AsciiMouse.singleton.dragX != 0 || AsciiMouse.singleton.dragY != 0))
			{
				FireOnOver();
			}
		}
		if (activated || activatedSecondary || _touchDownDelayRemaining > 0)
		{
			int num = Mathf.Min(Screen.width, Screen.height) / 1;
			if (!hasFocus || AsciiMouse.singleton.mouseDragAccumulatedX >= num || AsciiMouse.singleton.mouseDragAccumulatedX <= -num || AsciiMouse.singleton.mouseDragAccumulatedY >= num || AsciiMouse.singleton.mouseDragAccumulatedY <= -num)
			{
				activated = false;
				activatedSecondary = false;
				_touchDownDelayRemaining = -1;
			}
			else if (activated && !AsciiMouse.singleton.isDown0)
			{
				activated = false;
				activatedSecondary = false;
				_touchDownDelayRemaining = -1;
				if (flag)
				{
					FireOnPressed();
				}
			}
			else if (activatedSecondary && !AsciiMouse.singleton.isDown1)
			{
				activated = false;
				activatedSecondary = false;
				_touchDownDelayRemaining = -1;
				if (flag)
				{
					FireOnSecondaryPressed();
				}
			}
		}
		else if (hasFocus && flag)
		{
			if (AsciiMouse.singleton.down0)
			{
				_touchDownDelayRemaining = touchDownDelay;
			}
			else if (rightClickSupported && AsciiMouse.singleton.down1)
			{
				activatedSecondary = true;
			}
		}
		if (_touchDownDelayRemaining >= 0 && _touchDownDelayRemaining-- <= 0)
		{
			activated = true;
			FireOnDown();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		_lastDrawnX = offsetX;
		_lastDrawnY = offsetY;
		if (mySprite != null)
		{
			if (isDisabledState)
			{
				mySprite.Draw(r, offsetX + Width / 2, offsetY + Height / 2, 0.5f);
			}
			else
			{
				mySprite.Draw(r, offsetX + Width / 2, offsetY + Height / 2);
			}
		}
		if (isDisabledState)
		{
			label.Draw(r, offsetX, offsetY, edgeSymbols.color);
		}
		else
		{
			label.Draw(r, offsetX, offsetY);
		}
		badge.Draw(r, offsetX + Width - 1, offsetY);
		int num = -clickPaddingLeft;
		int num2 = Width + clickPaddingRight - 1;
		int num3 = -clickPaddingTop;
		int num4 = Height + clickPaddingBottom - 1;
		int num5 = 0;
		int num6 = num2 - num;
		for (int i = num; i <= num2; i++)
		{
			int num7 = 0;
			int num8 = num4 - num3;
			for (int j = num3; j <= num4; j++)
			{
				int x = i + offsetX;
				int y = j + offsetY;
				if (!r.IsClipped(x, y))
				{
					AsciiCellProcedural cell = r.GetCell(x, y);
					if (cell != null)
					{
						int num9 = Mathf.Min(num5, Mathf.Min(num6, Mathf.Min(num7, num8)));
						num9 += clickPriorityBonus;
						cell.SetInteractionLayer(this, num9);
					}
					num7++;
					num8--;
				}
			}
			num5++;
			num6--;
		}
		if ((activated || activatedSecondary) && IsMouseInside())
		{
			DrawHighlight(r, offsetX, offsetY);
		}
	}

	public void DrawHighlight(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int num = 0;
		int num2 = Width;
		int num3 = 0;
		int num4 = Height;
		if (highlightPadding)
		{
			num = -clickPaddingLeft;
			num2 += clickPaddingRight;
			num3 = -clickPaddingTop;
			num4 += clickPaddingBottom;
		}
		for (int i = num; i < num2; i++)
		{
			for (int j = num3; j < num4; j++)
			{
				int x = i + offsetX;
				int y = j + offsetY;
				if (!r.IsClipped(x, y))
				{
					AsciiCellProcedural cell = r.GetCell(x, y);
					if (cell != null)
					{
						cell.SetForeground(cell.GetBackground());
						cell.SetBackground(highlightColor);
					}
				}
			}
		}
	}

	public bool IsMouseInside()
	{
		AsciiCellProcedural cell = GameStates.Singleton.asciiRenderer.GetCell(AsciiMouse.singleton.x, AsciiMouse.singleton.y);
		if (cell != null)
		{
			return (DialogButton)cell.GetInteractionLayer() == this;
		}
		return false;
	}

	private void HandleScrollContainerHasBeenDragged(ScrollContainer container)
	{
		activated = false;
		_touchDownDelayRemaining = -1;
	}

	protected virtual void FireOnDown()
	{
		if (this.OnDown != null)
		{
			this.OnDown(this);
		}
	}

	protected virtual void FireOnOver()
	{
		if (this.OnOver != null)
		{
			this.OnOver(this);
		}
	}

	protected virtual void FireOnUp()
	{
		if (this.OnUp != null)
		{
			this.OnUp(this);
		}
	}

	protected virtual void FireOnPressed()
	{
		if (SfxController.singleton != null)
		{
			SfxController.singleton.Play(pressedSfxId);
		}
		if (this.OnPressed != null)
		{
			this.OnPressed(this);
		}
	}

	protected virtual void FireOnSecondaryPressed()
	{
		if (SfxController.singleton != null)
		{
			SfxController.singleton.Play(pressedSfxId);
		}
		if (this.OnSecondaryPressed != null)
		{
			this.OnSecondaryPressed(this);
		}
	}

	public int GetCenterX()
	{
		return base.lastDrawX + (Width >> 1);
	}

	public int GetCenterY()
	{
		return base.lastDrawY + (Height >> 1);
	}

	private void OnDisable()
	{
		activated = false;
		activatedSecondary = false;
		_touchDownDelayRemaining = -1;
	}

	public void ClearOnPressed()
	{
		if (this.OnPressed != null)
		{
			Delegate[] invocationList = this.OnPressed.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				Action<DialogButton> value = (Action<DialogButton>)invocationList[i];
				OnPressed -= value;
			}
		}
	}

	public void ResetButton()
	{
		PositionX = 0;
		PositionY = 0;
		Width = 18;
		Height = 5;
		label.SetValue("Label");
		label.color = ColorConstants.white;
		edgeSymbols.color = ColorConstants.grey;
		highlightColor = ColorConstants.white;
		pressedSfxId = "confirm";
		base.customBorderStyle = int.MinValue;
	}

	protected void InitSprite()
	{
		mySprite = GetComponent<AsciiSprite>();
		if (mySprite != null)
		{
			mySprite.Load();
		}
	}
}
