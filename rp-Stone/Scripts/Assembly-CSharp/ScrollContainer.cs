using System;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContainer : AsciiObject
{
	public enum ScrollDirection
	{
		Vertical = 0,
		Horizontal = 1
	}

	public ScrollDirection scrollDirection;

	public ScrollBar scrollBar;

	public int noScrollBarOffsetX = 1;

	public int spaceBetweenRows;

	public int padTop;

	public int padBottom;

	public int topCutoffInteract = 3;

	public int botCutoffInteract = 3;

	public bool canDragOnButtons = true;

	private float dragDamp = 0.8f;

	private List<AsciiObject> rows = new List<AsciiObject>();

	private List<int> rowOffsets = new List<int>();

	protected int scrollY;

	protected int displayScrollY;

	protected int visibleRowBegin;

	protected int visibleRowEnd = -1;

	public Action<ScrollContainer> OnUserScrolledManually;

	private bool needsPrecompute;

	private int lastOffsetX;

	private float lastUpdateTimestamp;

	private bool drawScrollbar = true;

	private bool canDrag;

	private bool dragging;

	private int dragDelayRemaining;

	private float dragLeftover;

	private int dragLastScrollY;

	private float lastTimeUpdateScrollWheelTic;

	public bool debugFillArea;

	private int scheduledScrollY;

	public bool isScrollingLocked { get; set; }

	public int lastContainerDrawX { get; private set; }

	public int lastContainerDrawY { get; private set; }

	public int ScrollY => scrollY;

	public int DisplayScrollY => displayScrollY;

	public int totalContentLength { get; private set; }

	public float dragVelocity { get; set; }

	public static event Action<ScrollContainer> OnScrollContainerHasBeenDragged;

	public List<AsciiObject> GetRows()
	{
		return rows;
	}

	public void HideScrollbar()
	{
		drawScrollbar = false;
	}

	public void ShowScrollbar()
	{
		drawScrollbar = true;
	}

	public override void UpdateTic()
	{
		UpdatePrecompute();
		UpdateDragging();
		UpdateScrollWheelTic();
		scrollBar.UpdateTic();
		if (scrollY < displayScrollY)
		{
			int num = Mathf.Max(1, (displayScrollY - scrollY) / 4);
			displayScrollY -= num;
			UpdateBeginEndIndexes();
		}
		else if (scrollY > displayScrollY)
		{
			int num2 = Mathf.Max(1, (scrollY - displayScrollY) / 4);
			displayScrollY += num2;
			UpdateBeginEndIndexes();
		}
		UpdateScrollBarPercent();
		for (int i = visibleRowBegin; i <= visibleRowEnd; i++)
		{
			if (i < 0 || i >= rows.Count)
			{
				Utils.LogWarning("Detected out of range. i = " + i + ", but list has size = " + rows.Count);
			}
			if (displayScrollY <= rowOffsets[i] - padTop + topCutoffInteract)
			{
				rows[i].UpdateTic();
			}
		}
		scrollBar.showNewIndicatorTop = false;
		for (int j = 0; j < visibleRowBegin; j++)
		{
			if (rows[j] is INewIndicatorProvider newIndicatorProvider && newIndicatorProvider.IsNewIndicating())
			{
				scrollBar.showNewIndicatorTop = true;
				scrollBar.newIndicatorColorTop = newIndicatorProvider.GetNewIndicatorColor();
				break;
			}
		}
		scrollBar.showNewIndicatorBottom = false;
		for (int k = visibleRowEnd + 1; k < rows.Count; k++)
		{
			if (rows[k] is INewIndicatorProvider newIndicatorProvider2 && newIndicatorProvider2.IsNewIndicating())
			{
				scrollBar.showNewIndicatorBottom = true;
				scrollBar.newIndicatorColorBottom = newIndicatorProvider2.GetNewIndicatorColor();
				break;
			}
		}
		lastUpdateTimestamp = Time.realtimeSinceStartup;
	}

	public int GetContainerLength()
	{
		if (scrollDirection != ScrollDirection.Vertical)
		{
			return Width;
		}
		return Height;
	}

	private void UpdateDragging()
	{
		if (!Features.SCROLL_BY_DRAGGING)
		{
			return;
		}
		AsciiMouse singleton = AsciiMouse.singleton;
		if (isScrollingLocked)
		{
			canDrag = false;
		}
		else if (canDragOnButtons)
		{
			canDrag = true;
		}
		else if (singleton.down0 && !IsButton(singleton.x, singleton.y))
		{
			canDrag = true;
		}
		else if (singleton.up0)
		{
			canDrag = false;
		}
		if (dragging)
		{
			if (!singleton.isDown0 || totalContentLength <= GetContainerLength() || isScrollingLocked)
			{
				dragging = false;
				ConstrainScrollY();
			}
		}
		else if (canDrag && singleton.isDragging0 && totalContentLength > GetContainerLength())
		{
			int num = singleton.dragBeginY;
			int num2 = PositionY;
			if (scrollDirection == ScrollDirection.Horizontal)
			{
				num = singleton.dragBeginX;
				num2 = PositionX;
			}
			if (num >= num2 && num < num2 + GetContainerLength())
			{
				dragging = true;
				dragDelayRemaining = Features.SCROLL_BY_DRAG_DELAY;
				dragVelocity = 0f;
				if (OnUserScrolledManually != null)
				{
					OnUserScrolledManually(this);
				}
			}
		}
		if (dragDelayRemaining > 0)
		{
			dragDelayRemaining--;
		}
		else
		{
			int num3 = singleton.y;
			int num4 = singleton.dragY;
			if (scrollDirection == ScrollDirection.Horizontal)
			{
				num3 = singleton.x;
				num4 = singleton.dragX;
			}
			if (singleton.isDown0)
			{
				if (dragging)
				{
					dragVelocity = Mathf.Lerp(dragVelocity, -3f * (float)num4, 0.5f);
				}
				else
				{
					scrollY = (int)Mathf.Lerp(scrollY, displayScrollY, 0.5f);
					dragVelocity = Mathf.Lerp(dragVelocity, 0f, 0.5f);
				}
			}
			if (canDrag && singleton.isDragging0 && totalContentLength > GetContainerLength())
			{
				int num5 = totalContentLength - GetContainerLength() + padBottom;
				if ((scrollY > -3 && scrollY < num5 + 3) || num3 % 3 == 0)
				{
					scrollY -= num4;
					displayScrollY -= num4;
				}
				UpdateBeginEndIndexes();
			}
			else if (dragVelocity != 0f)
			{
				int num6 = Mathf.FloorToInt(dragVelocity);
				dragLeftover += dragVelocity - (float)num6;
				if (dragLeftover >= 1f)
				{
					num6 += Mathf.FloorToInt(dragLeftover);
					dragLeftover -= Mathf.FloorToInt(dragLeftover);
				}
				scrollY += num6;
				ConstrainScrollY();
				dragVelocity *= dragDamp;
			}
		}
		if (dragging && dragLastScrollY != scrollY && ScrollContainer.OnScrollContainerHasBeenDragged != null)
		{
			ScrollContainer.OnScrollContainerHasBeenDragged(this);
		}
		dragLastScrollY = scrollY;
	}

	private bool IsButton(int x, int y)
	{
		AsciiCellProcedural cell = GameStates.Singleton.asciiRenderer.GetCell(x, y);
		if (cell != null)
		{
			return cell.GetInteractionLayer() != null;
		}
		return false;
	}

	private void HandleSwipeUp(float swipeDuration)
	{
		if (!(Time.realtimeSinceStartup - lastUpdateTimestamp > 0.04f) && !(swipeDuration > 0.25f) && !(Mathf.Abs(dragVelocity) > 4f))
		{
			scrollY += 24;
			ConstrainScrollY();
		}
	}

	private void HandleSwipeDown(float swipeDuration)
	{
		if (!(Time.realtimeSinceStartup - lastUpdateTimestamp > 0.04f) && !(swipeDuration > 0.25f) && !(Mathf.Abs(dragVelocity) > 4f))
		{
			scrollY -= 24;
			ConstrainScrollY();
		}
	}

	protected virtual void Update()
	{
		UpdateScrollWheel();
	}

	private void UpdateScrollWheelTic()
	{
		lastTimeUpdateScrollWheelTic = Time.realtimeSinceStartup;
	}

	private void UpdateScrollWheel()
	{
		if (Time.realtimeSinceStartup - lastTimeUpdateScrollWheelTic >= 0.034f || (scrollDirection == ScrollDirection.Vertical && (AsciiMouse.singleton.x < lastContainerDrawX || AsciiMouse.singleton.x > lastContainerDrawX + Width + 1)) || (scrollDirection == ScrollDirection.Horizontal && (AsciiMouse.singleton.y < lastContainerDrawY || AsciiMouse.singleton.y > lastContainerDrawY + Height + 1)))
		{
			return;
		}
		float axis = Input.GetAxis("Mouse ScrollWheel");
		int num = 0;
		if (axis != 0f)
		{
			axis *= InputController.Instance.AdjustedScrollSpeed;
			num = (int)(-1f * axis);
			if (num == 0)
			{
				num = ((!(axis > 0f)) ? 1 : (-1));
			}
		}
		if (num != 0)
		{
			scrollY += num;
			ConstrainScrollY();
			if (OnUserScrolledManually != null)
			{
				OnUserScrolledManually(this);
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (scheduledScrollY != int.MinValue)
		{
			SetScrollY(scheduledScrollY);
		}
		UpdatePrecompute();
		int num = 0;
		if (!IsScrollBarEnabled())
		{
			num = noScrollBarOffsetX;
		}
		if (lastOffsetX < num)
		{
			lastOffsetX++;
		}
		else if (lastOffsetX > num)
		{
			lastOffsetX--;
		}
		offsetX += lastOffsetX;
		offsetX += PositionX;
		offsetY += PositionY;
		lastContainerDrawX = offsetX;
		lastContainerDrawY = offsetY;
		for (int i = 0; i < Width; i++)
		{
			if (!debugFillArea)
			{
				break;
			}
			for (int j = 0; j < Height; j++)
			{
				r.GetCell(offsetX + i, offsetY + j)?.SetBackground(ColorConstants.darkGreen);
			}
		}
		if (scrollDirection == ScrollDirection.Vertical)
		{
			r.PushClip(new AsciiRenderProcedural.Clip
			{
				top = offsetY,
				bottom = r.height - offsetY - Height
			});
			for (int k = visibleRowBegin; k <= visibleRowEnd; k++)
			{
				int offsetY2 = rowOffsets[k] + offsetY - displayScrollY;
				rows[k].Draw(r, offsetX, offsetY2);
			}
		}
		else
		{
			r.PushClip(new AsciiRenderProcedural.Clip
			{
				left = offsetX,
				right = r.width - offsetX - Width
			});
			for (int l = visibleRowBegin; l <= visibleRowEnd; l++)
			{
				int offsetX2 = rowOffsets[l] + offsetX - displayScrollY;
				rows[l].Draw(r, offsetX2, offsetY);
			}
		}
		r.PopClip();
		offsetX -= PositionX;
		offsetY -= PositionY;
		if (IsScrollBarEnabled())
		{
			scrollBar.scrollDirection = scrollDirection;
			scrollBar.Draw(r, offsetX, offsetY);
		}
	}

	public void SetScheduledScrollY(int newScrollY)
	{
		scheduledScrollY = newScrollY;
	}

	public void SetScrollY(int newScrollY, bool jumpToPosition = true)
	{
		scheduledScrollY = int.MinValue;
		newScrollY = Mathf.Min(newScrollY, totalContentLength - GetContainerLength() + padBottom);
		newScrollY = Mathf.Max(newScrollY, -padTop);
		scrollY = newScrollY;
		if (jumpToPosition)
		{
			displayScrollY = newScrollY;
			UpdateBeginEndIndexes();
		}
	}

	public void ScrollToTop(bool jumpToPosition = true)
	{
		SetScrollY(0, jumpToPosition);
	}

	public void ScrollToBottom(bool jumpToPosition = true)
	{
		SetScrollY(999999, jumpToPosition);
	}

	public bool IsScrollBarEnabled()
	{
		if (totalContentLength > GetContainerLength())
		{
			return drawScrollbar;
		}
		return false;
	}

	public void RefreshPrecompute()
	{
		needsPrecompute = true;
	}

	public bool IsRowVisible(int index)
	{
		if (index >= visibleRowBegin)
		{
			return index <= visibleRowEnd;
		}
		return false;
	}

	public void UpdateForHeightChange()
	{
		totalContentLength = 0;
		for (int i = 0; i < rows.Count; i++)
		{
			totalContentLength += ((scrollDirection == ScrollDirection.Vertical) ? rows[i].Height : rows[i].Width);
			if (i > 0)
			{
				totalContentLength += spaceBetweenRows;
			}
		}
		RefreshPrecompute();
	}

	protected void UpdatePrecompute()
	{
		if (needsPrecompute)
		{
			needsPrecompute = false;
			ComputeOffsets();
			UpdateBeginEndIndexes();
			UpdateScrollBarPercent();
		}
	}

	private void UpdateBeginEndIndexes()
	{
		visibleRowBegin = 0;
		visibleRowEnd = -1;
		for (int i = 0; i < rowOffsets.Count; i++)
		{
			if (rowOffsets[i] <= displayScrollY)
			{
				visibleRowBegin = i;
			}
			if (rowOffsets[i] < displayScrollY + GetContainerLength())
			{
				visibleRowEnd = i;
				continue;
			}
			break;
		}
	}

	private void UpdateScrollBarPercent()
	{
		int num = totalContentLength - GetContainerLength() + padTop + padBottom;
		if (num > 0)
		{
			float percent = (float)(displayScrollY + padTop) / (float)num;
			scrollBar.percent = percent;
		}
	}

	private void HandleScrollBarValueChanged(ScrollBar bar)
	{
		int num = totalContentLength - GetContainerLength() + padTop + padBottom;
		int newScrollY = Mathf.RoundToInt(bar.percent * (float)num - (float)padTop);
		SetScrollY(newScrollY, bar.isDraggingHandle);
		UpdateBeginEndIndexes();
		if (OnUserScrolledManually != null)
		{
			OnUserScrolledManually(this);
		}
	}

	public void ConstrainScrollY()
	{
		int a = totalContentLength - GetContainerLength() + padBottom;
		a = Mathf.Max(a, 0);
		scrollY = Mathf.Min(scrollY, a);
		scrollY = Mathf.Max(scrollY, -padTop);
	}

	public void ComputeOffsets()
	{
		rowOffsets.Clear();
		int num = 0;
		for (int i = 0; i < rows.Count; i++)
		{
			rowOffsets.Add(num);
			int num2 = ((scrollDirection == ScrollDirection.Vertical) ? rows[i].Height : rows[i].Width);
			num += num2 + spaceBetweenRows;
		}
	}

	public List<int> GetOffsets()
	{
		return rowOffsets;
	}

	public void AddRow(AsciiObject row, bool top = false)
	{
		if (rows.Contains(row))
		{
			Utils.LogError("Cannot add row " + row?.ToString() + " as we already have that row.");
			return;
		}
		if (top)
		{
			rows.Insert(0, row);
		}
		else
		{
			rows.Add(row);
		}
		int num = ((scrollDirection == ScrollDirection.Vertical) ? row.Height : row.Width);
		totalContentLength += num;
		if (rows.Count > 1)
		{
			totalContentLength += spaceBetweenRows;
		}
		needsPrecompute = true;
	}

	public void RemoveRow(AsciiObject row)
	{
		if (rows.Contains(row))
		{
			rows.Remove(row);
			if (rows.Count == 0)
			{
				totalContentLength = 0;
			}
			else
			{
				int num = ((scrollDirection == ScrollDirection.Vertical) ? row.Height : row.Width);
				totalContentLength -= num + spaceBetweenRows;
			}
			needsPrecompute = true;
		}
	}

	public int GetRowPositionY(AsciiObject row)
	{
		for (int i = 0; i < rows.Count && i < rowOffsets.Count; i++)
		{
			if (row == rows[i])
			{
				return rowOffsets[i];
			}
		}
		return -1;
	}

	public int GetFocusedRowIndex()
	{
		return visibleRowBegin + (visibleRowEnd - visibleRowBegin) / 2;
	}

	public void ScrollPositionToCentralizeRow(int rowIndex, bool jumpToPosition = false)
	{
		rowIndex = Mathf.Max(rowIndex, 0);
		rowIndex = Mathf.Min(rowIndex, rows.Count - 1);
		ScrollPositionToCentralizeRow(rows[rowIndex], jumpToPosition);
	}

	public void ScrollPositionToCentralizeRow(AsciiObject row, bool jumpToPosition = false)
	{
		int rowPositionY = GetRowPositionY(row);
		if (scrollDirection == ScrollDirection.Vertical)
		{
			SetScrollY(rowPositionY - (Height - row.Height) / 2, jumpToPosition);
		}
		else
		{
			SetScrollY(rowPositionY - (Width - row.Width) / 2, jumpToPosition);
		}
	}

	public virtual void Clear()
	{
		rows.Clear();
		rowOffsets.Clear();
		totalContentLength = 0;
		visibleRowBegin = 0;
		visibleRowEnd = -1;
	}

	protected virtual void Awake()
	{
		lastOffsetX = noScrollBarOffsetX;
		scrollY = -padTop;
		scrollBar.OnPercentChanged += HandleScrollBarValueChanged;
		SwipeDetection.OnSwipeUp += HandleSwipeUp;
		SwipeDetection.OnSwipeDown += HandleSwipeDown;
	}

	protected virtual void OnDestroy()
	{
		SwipeDetection.OnSwipeUp -= HandleSwipeUp;
		SwipeDetection.OnSwipeDown -= HandleSwipeDown;
	}
}
