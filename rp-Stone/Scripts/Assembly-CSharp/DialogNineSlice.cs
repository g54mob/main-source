using System;
using UnityEngine;

public class DialogNineSlice : AsciiObject, IAsciiObject
{
	public enum State
	{
		Disabled = 0,
		In = 1,
		Out = 2,
		Idle = 3
	}

	[Serializable]
	public class EdgeSymbols
	{
		public int topLeft = 218;

		public int topCenter = 196;

		public int topRight = 191;

		public int centerLeft = 179;

		public int centerCenter = 32;

		public int centerRight = 179;

		public int bottomLeft = 192;

		public int bottomCenter = 196;

		public int bottomRight = 217;

		public Color color = Color.white;

		public Color bgColor = ColorConstants.invalid;

		public void CopyFrom(EdgeSymbols newValues)
		{
			topLeft = newValues.topLeft;
			topCenter = newValues.topCenter;
			topRight = newValues.topRight;
			centerLeft = newValues.centerLeft;
			centerCenter = newValues.centerCenter;
			centerRight = newValues.centerRight;
			bottomLeft = newValues.bottomLeft;
			bottomCenter = newValues.bottomCenter;
			bottomRight = newValues.bottomRight;
			color = newValues.color;
			bgColor = newValues.bgColor;
		}
	}

	public float scaleSpeed = 0.1f;

	private State currentState = State.Idle;

	private int elapsedStateTics;

	public EdgeSymbols edgeSymbols;

	public bool rightClickAnywhereToClose = true;

	private int _lastDrawX;

	private int _lastDrawY;

	protected float scaleX = 1f;

	protected float scaleY = 1f;

	protected float targetScaleX = 1f;

	protected float targetScaleY = 1f;

	private ModalFade modalFade;

	private int lastOffsetX;

	private int lastOffsetY;

	public State CurrentState
	{
		get
		{
			return currentState;
		}
		protected set
		{
			currentState = value;
		}
	}

	public int ElapsedStateTics => elapsedStateTics;

	public int customBorderStyle { get; set; } = int.MinValue;

	public int lastDrawX => _lastDrawX;

	public int lastDrawY => _lastDrawY;

	public event Action OnClickedOutside;

	protected virtual void SetState(State newState)
	{
		if (modalFade != null)
		{
			modalFade.active = newState == State.In || newState == State.Idle;
		}
		switch (newState)
		{
		case State.In:
			if (currentState != State.Out)
			{
				scaleX = 0f;
				scaleY = 0f;
			}
			targetScaleX = 1f;
			targetScaleY = 1f;
			break;
		case State.Idle:
			scaleX = 1f;
			scaleY = 1f;
			targetScaleX = 0f;
			targetScaleY = 0f;
			break;
		}
		currentState = newState;
		elapsedStateTics = 0;
	}

	public override void UpdateTic()
	{
		elapsedStateTics++;
		if (currentState == State.In || currentState == State.Out)
		{
			bool flag = true;
			if (scaleX < targetScaleX)
			{
				flag = false;
				scaleX += scaleSpeed;
				if (scaleX >= targetScaleX)
				{
					scaleX = targetScaleX;
					flag = true;
				}
			}
			else if (scaleX > targetScaleX)
			{
				flag = false;
				scaleX -= scaleSpeed;
				if (scaleX <= targetScaleX)
				{
					scaleX = targetScaleX;
					flag = true;
				}
			}
			bool flag2 = true;
			if (scaleY < targetScaleY)
			{
				flag2 = false;
				scaleY += scaleSpeed;
				if (scaleY >= targetScaleY)
				{
					scaleY = targetScaleY;
					flag2 = true;
				}
			}
			else if (scaleY > targetScaleY)
			{
				flag2 = false;
				scaleY -= scaleSpeed;
				if (scaleY <= targetScaleY)
				{
					scaleY = targetScaleY;
					flag2 = true;
				}
			}
			if (flag && flag2)
			{
				if (currentState == State.In)
				{
					SetState(State.Idle);
				}
				else
				{
					SetState(State.Disabled);
				}
			}
		}
		else
		{
			if (currentState != State.Idle || this.OnClickedOutside == null)
			{
				return;
			}
			if (rightClickAnywhereToClose && AsciiMouse.singleton.down1)
			{
				this.OnClickedOutside();
			}
			else
			{
				if (!AsciiMouse.singleton.up0 || AsciiMouse.singleton.dragAccumulatedX != 0 || AsciiMouse.singleton.dragAccumulatedY != 0)
				{
					return;
				}
				int x = AsciiMouse.singleton.x;
				int y = AsciiMouse.singleton.y;
				int num = PositionX + lastOffsetX;
				int num2 = PositionY + lastOffsetY;
				if (x < num || x >= num + Width || y < num2 || y >= num2 + Height)
				{
					AsciiCellProcedural cell = GameStates.Singleton.asciiRenderer.GetCell(x, y);
					if (cell == null || cell.GetInteractionPriority() < 100)
					{
						this.OnClickedOutside();
					}
				}
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentState == State.Disabled)
		{
			return;
		}
		if (modalFade != null)
		{
			modalFade.Draw(r);
		}
		lastOffsetX = offsetX;
		lastOffsetY = offsetY;
		int num = (int)((float)Width * scaleX);
		int num2 = (int)((float)Height * scaleY);
		if (num < 1 || num2 < 1)
		{
			return;
		}
		offsetX += PositionX + (Width - num) / 2;
		offsetY += PositionY + (Height - num2) / 2;
		_lastDrawX = offsetX;
		_lastDrawY = offsetY;
		if (customBorderStyle != int.MinValue)
		{
			BoxDrawing.Command command = new BoxDrawing.Command(offsetX, offsetY, Width, Height, edgeSymbols.color, customBorderStyle);
			BoxDrawing.Draw(r, command);
			return;
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				int num3 = edgeSymbols.centerCenter;
				if (j == 0)
				{
					num3 = ((i == 0) ? edgeSymbols.topLeft : ((i != num - 1) ? edgeSymbols.topCenter : edgeSymbols.topRight));
				}
				else if (j == num2 - 1)
				{
					num3 = ((i == 0) ? edgeSymbols.bottomLeft : ((i != num - 1) ? edgeSymbols.bottomCenter : edgeSymbols.bottomRight));
				}
				else if (i == 0)
				{
					num3 = edgeSymbols.centerLeft;
				}
				else if (i == num - 1)
				{
					num3 = edgeSymbols.centerRight;
				}
				if (num3 != -1)
				{
					Color background = r.defaultBackgroundColor;
					if (edgeSymbols.bgColor != ColorConstants.invalid)
					{
						background = edgeSymbols.bgColor;
					}
					r.SetCell(i + offsetX, j + offsetY, num3, edgeSymbols.color, background);
				}
			}
		}
	}

	protected virtual void Awake()
	{
		modalFade = GetComponent<ModalFade>();
	}

	protected virtual void Start()
	{
	}
}
