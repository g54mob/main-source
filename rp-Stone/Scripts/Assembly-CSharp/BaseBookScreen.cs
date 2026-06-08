using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBookScreen : MonoBehaviour
{
	public enum State
	{
		Disabled = 0,
		In = 1,
		Opening = 2,
		Out = 3,
		Idle = 4
	}

	protected abstract class APage
	{
		protected BaseBookScreen screen;

		protected int elapsedTics;

		protected bool backwards;

		protected bool initialized;

		public int pageIndex { get; set; }

		public bool needsRefresh { get; set; }

		public APage(BaseBookScreen screenRef)
		{
			screen = screenRef;
			needsRefresh = true;
		}

		public virtual void UpdateTic()
		{
			elapsedTics++;
		}

		public virtual bool IsInitialized()
		{
			return initialized;
		}

		public virtual void Show(bool backwards = false)
		{
			elapsedTics = 0;
			this.backwards = backwards;
			initialized = true;
		}

		public bool IsBackwards()
		{
			return backwards;
		}

		public abstract bool IsDone();

		public abstract bool IsPastHalfWayAnimation();

		public abstract void Draw(AsciiRenderProcedural r, int offsetX, int offsetY);

		protected void FillArea(AsciiRenderProcedural r, int x, int y, int w, int h, char value = ' ')
		{
			for (int i = x; i < x + w; i++)
			{
				for (int j = y; j < y + h; j++)
				{
					AsciiCellProcedural cell = r.GetCell(i, j);
					if (cell != null)
					{
						cell.SetValue(value);
						cell.SetUnicodeValue('\0');
						cell.SetBackground(ColorConstants.black);
					}
				}
			}
		}
	}

	private class Cover : APage
	{
		public Cover(BaseBookScreen screenRef)
			: base(screenRef)
		{
		}

		public override bool IsInitialized()
		{
			return true;
		}

		public override bool IsDone()
		{
			return elapsedTics >= screen.bookOpen.FrameCount;
		}

		public override bool IsPastHalfWayAnimation()
		{
			return elapsedTics >= screen.bookOpen.FrameCount / 2;
		}

		public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			if (elapsedTics >= 7)
			{
				FillArea(r, offsetX - 31, offsetY - 9, 30, 23);
			}
			FillArea(r, offsetX + 1, offsetY - 10, 30, 23);
			int num = offsetX + 15;
			if (screen.currentState == State.Opening)
			{
				if (screen.elapsedStateTics <= 7)
				{
					num += 2;
				}
				else if (screen.elapsedStateTics <= 8)
				{
					num++;
				}
			}
			screen.DrawIntroText(r, num, offsetY);
			int num2 = Mathf.Clamp(elapsedTics, 0, screen.bookOpen.FrameCount - 1);
			if (backwards)
			{
				num2 = screen.bookOpen.FrameCount - 1 - num2;
			}
			screen.bookOpen.SetFrameIndex(num2);
			screen.bookOpen.Draw(r, offsetX, offsetY);
		}
	}

	protected class Page1 : APage
	{
		protected AsciiSprite mySprite;

		private AsciiString pageNumberLeft = new AsciiString();

		private AsciiString pageNumberRight = new AsciiString();

		protected int[] clipValues = new int[15]
		{
			32, 30, 29, 28, 26, 22, 18, 0, -18, -22,
			-25, -27, -28, -29, -31
		};

		public Page1(BaseBookScreen screenRef)
			: base(screenRef)
		{
			mySprite = screenRef.bookPage1;
			pageNumberLeft.PositionX = -28 - screen.pageNumberOffsetX;
			pageNumberLeft.PositionY = 11 + screen.pageNumberOffsetY;
			pageNumberLeft.color = mySprite.colorOverride;
			pageNumberRight.alignment = AsciiString.Alignment.Right;
			pageNumberRight.PositionX = 28 + screen.pageNumberOffsetX;
			pageNumberRight.PositionY = 11 + screen.pageNumberOffsetY;
			pageNumberRight.color = mySprite.colorOverride;
		}

		public override void Show(bool backwards = false)
		{
			base.Show(backwards);
			if (base.needsRefresh)
			{
				base.needsRefresh = false;
				pageNumberLeft.SetValue((base.pageIndex * 2).ToString());
				pageNumberRight.SetValue((base.pageIndex * 2 + 1).ToString());
			}
		}

		public override bool IsDone()
		{
			return elapsedTics >= mySprite.FrameCount;
		}

		public override bool IsPastHalfWayAnimation()
		{
			return elapsedTics >= mySprite.FrameCount / 2;
		}

		protected void FillWithClip(AsciiRenderProcedural r, int x, int y, int w, int h, char value)
		{
			if (x < r.clip.left)
			{
				int num = r.clip.left - x;
				x += num;
				w -= num;
			}
			if (x + w > r.width - r.clip.right)
			{
				w = r.width - r.clip.right - x;
			}
			FillArea(r, x, y, w, h, value);
		}

		public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			int num = Mathf.Clamp(elapsedTics, 0, mySprite.FrameCount - 1);
			if (backwards)
			{
				num = mySprite.FrameCount - 1 - num;
			}
			r.PushClip(new AsciiRenderProcedural.Clip
			{
				left = r.width / 2 + clipValues[num]
			});
			FillWithClip(r, offsetX - 31, offsetY - 10, 30, 23, ' ');
			FillWithClip(r, offsetX + 1, offsetY - 10, 30, 23, ' ');
			pageNumberLeft.Draw(r, offsetX, offsetY);
			pageNumberRight.Draw(r, offsetX, offsetY);
			screen.DrawPageContents(r, offsetX, offsetY, base.pageIndex);
			r.PopClip();
			mySprite.SetFrameIndex(num);
			mySprite.Draw(r, offsetX, offsetY);
		}
	}

	private class Page2 : Page1
	{
		public Page2(BaseBookScreen screenRef)
			: base(screenRef)
		{
			mySprite = screenRef.bookPage2;
		}
	}

	private class PageLast : Page1
	{
		public PageLast(BaseBookScreen screenRef)
			: base(screenRef)
		{
			mySprite = screenRef.bookPageLast;
		}
	}

	private class PageBackCover : Page1
	{
		public PageBackCover(BaseBookScreen screenRef)
			: base(screenRef)
		{
			mySprite = screenRef.bookPageBackCover;
		}
	}

	public int offsetPosY;

	public int pageNumberOffsetX;

	public int pageNumberOffsetY;

	public DialogButton closeButton;

	public AsciiSprite bookOpen;

	public AsciiSprite bookPage1;

	public AsciiSprite bookPage2;

	public AsciiSprite bookPageLast;

	public AsciiSprite bookPageBackCover;

	public AsciiTextBox titleBox;

	public AsciiTextBox subtitleBox;

	public AsciiString authorIntro;

	public AsciiString authorName;

	public AsciiTextBox amountFoundBox;

	public AsciiString leftArrow;

	public AsciiString rightArrow;

	public bool includeBackCover = true;

	private ModalFade modalFade;

	private float inVel = -5f;

	private float breakVel = -0.7f;

	private float deceleration = 0.3f;

	private int inTics = 13;

	private float outAcc = 1.25f;

	private float posY;

	private float velY;

	private int clickMargin = 6;

	private int top;

	private int bottom;

	private int left;

	private int right;

	protected int pageIndex;

	private List<APage> allPages = new List<APage>();

	protected APage currentPage;

	private bool backwards;

	public State currentState { get; private set; }

	public int elapsedStateTics { get; private set; }

	protected abstract int GetContentDiscovered();

	protected abstract int GetTotalContentAmount();

	protected abstract int GetPageCount();

	protected abstract void UpdateContentForPage(int index);

	protected abstract void DrawPageContents(AsciiRenderProcedural r, int offsetX, int offsetY, int index);

	public virtual void Show()
	{
		InitPages();
		MarkPagesForRefresh();
		pageIndex = -1;
		currentPage = null;
		string text = Te.xt("tid_booklet_by");
		if (string.IsNullOrEmpty(text) || text == " ")
		{
			text = Te.xt("tid_booklet_by_after");
			authorIntro.PositionY = authorName.PositionY + 1;
		}
		else
		{
			authorIntro.PositionY = authorName.PositionY - 1;
		}
		authorIntro.SetValue(text);
		if (HeroSettings.isNameSet)
		{
			authorName.SetValue(HeroSettings.name);
		}
		else
		{
			authorName.SetValue(Te.xt("A Hasty Stone"));
		}
		string format = Te.xt("tid_booklet_discovered");
		amountFoundBox.Text = string.Format(format, GetContentDiscovered(), GetTotalContentAmount());
		NextPage();
		SetState(State.In);
	}

	public virtual void Hide()
	{
		SetState(State.Out);
	}

	protected virtual void SetState(State newState)
	{
		if (modalFade != null)
		{
			modalFade.active = newState != State.Out && newState != State.Disabled;
		}
		switch (newState)
		{
		case State.In:
			velY = inVel;
			posY = 24f;
			SfxController.singleton.Play("booklet_open");
			break;
		case State.Out:
			velY = 0f;
			posY = 0f;
			SfxController.singleton.Play("booklet_close");
			break;
		}
		currentState = newState;
		elapsedStateTics = 0;
	}

	protected virtual void Update()
	{
		if (currentState == State.Idle)
		{
			if (CanPrevious() && Input.GetKeyDown(KeyCode.LeftArrow))
			{
				PreviousPage();
				SfxController.singleton.Play("booklet_turn_page");
			}
			else if (CanNext() && Input.GetKeyDown(KeyCode.RightArrow))
			{
				NextPage();
				SfxController.singleton.Play("booklet_turn_page");
			}
			else if (Input.GetKeyDown(KeyCode.Escape))
			{
				Hide();
			}
		}
	}

	public virtual void UpdateTic()
	{
		elapsedStateTics++;
		if (currentState == State.In)
		{
			if (posY <= 0f && velY < breakVel)
			{
				velY = breakVel;
			}
			else if (posY < 0f)
			{
				velY += deceleration;
			}
			posY += velY;
			if (elapsedStateTics >= inTics)
			{
				SetState(State.Opening);
			}
		}
		else if (currentState == State.Opening)
		{
			UpdatePages();
			if (currentPage.IsDone())
			{
				SetState(State.Idle);
			}
		}
		else if (currentState == State.Out)
		{
			velY += outAcc;
			posY += velY;
			if (elapsedStateTics >= 10)
			{
				SetState(State.Disabled);
			}
		}
		else if (currentState == State.Idle)
		{
			closeButton.UpdateTic();
			CheckForClickOutside();
			UpdatePages();
			if (AsciiMouse.singleton.down0)
			{
				if (IsMouseInLeftMargin())
				{
					PreviousPage();
					SfxController.singleton.Play("booklet_turn_page");
				}
				else if (IsMouseInRightMargin())
				{
					NextPage();
					SfxController.singleton.Play("booklet_turn_page");
				}
			}
		}
		if (currentState == State.Idle && (IsMouseInLeftMargin() || IsMouseInRightMargin()))
		{
			GameStates.Singleton.HideMouse();
		}
		else
		{
			GameStates.Singleton.ShowMouse();
		}
	}

	private void CheckForClickOutside()
	{
		if (currentState != State.Idle)
		{
			return;
		}
		if (AsciiMouse.singleton.down1)
		{
			Hide();
		}
		else if (AsciiMouse.singleton.up0 && AsciiMouse.singleton.dragAccumulatedX == 0 && AsciiMouse.singleton.dragAccumulatedY == 0)
		{
			int x = AsciiMouse.singleton.x;
			if (x < left || x > right)
			{
				Hide();
			}
		}
	}

	private bool IsMouseInLeftMargin()
	{
		if (!CanPrevious())
		{
			return false;
		}
		int x = AsciiMouse.singleton.x;
		int y = AsciiMouse.singleton.y;
		if (y > top && y < bottom && x >= left)
		{
			return x < left + clickMargin;
		}
		return false;
	}

	private bool IsMouseInRightMargin()
	{
		if (!CanNext())
		{
			return false;
		}
		int x = AsciiMouse.singleton.x;
		int y = AsciiMouse.singleton.y;
		if (y > top && y < bottom && x <= right)
		{
			return x > right - clickMargin;
		}
		return false;
	}

	private bool CanPrevious()
	{
		return pageIndex > 0;
	}

	private bool CanNext()
	{
		return pageIndex < GetPageCount() - 1;
	}

	private void InitPages()
	{
		if (allPages.Count == 0)
		{
			allPages.Add(new Cover(this));
			APage item = new Page1(this);
			allPages.Add(item);
		}
	}

	private void MarkPagesForRefresh()
	{
		for (int i = 0; i < allPages.Count; i++)
		{
			allPages[i].needsRefresh = true;
		}
	}

	protected void PreviousPage()
	{
		if (pageIndex > 0)
		{
			pageIndex--;
			backwards = true;
			currentPage.Show(backwards: true);
			currentPage = allPages[pageIndex];
		}
	}

	protected void NextPage()
	{
		pageIndex++;
		backwards = false;
		if (pageIndex >= allPages.Count)
		{
			APage item = (includeBackCover ? ((!CanNext()) ? new PageBackCover(this) : ((pageIndex >= GetPageCount() - 2) ? ((Page1)new PageLast(this)) : ((Page1)new Page2(this)))) : ((!CanNext()) ? ((Page1)new PageLast(this)) : ((Page1)new Page2(this))));
			allPages.Add(item);
		}
		currentPage = allPages[pageIndex];
		currentPage.pageIndex = pageIndex;
		currentPage.Show();
		UpdateContentForPage(pageIndex);
	}

	private void UpdatePages()
	{
		for (int i = 0; i < allPages.Count; i++)
		{
			if (!allPages[i].IsDone())
			{
				allPages[i].UpdateTic();
			}
		}
	}

	private void DrawPages(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < allPages.Count; i++)
		{
			APage aPage = allPages[i];
			if (aPage.IsInitialized())
			{
				APage aPage2 = ((!backwards && i < allPages.Count - 1) ? allPages[i + 1] : null);
				if (!aPage.IsDone() || aPage == currentPage || (!backwards && aPage2 != null && !aPage2.IsDone()))
				{
					aPage.Draw(r, offsetX, offsetY);
				}
			}
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetY += offsetPosY;
		if (currentState == State.Disabled)
		{
			return;
		}
		if (modalFade != null)
		{
			modalFade.Draw(r);
		}
		if (currentState == State.In)
		{
			DrawPages(r, offsetX, offsetY + Mathf.RoundToInt(posY));
		}
		else if (currentState == State.Opening)
		{
			DrawPages(r, offsetX, offsetY);
		}
		else if (currentState == State.Idle)
		{
			DrawPages(r, offsetX, offsetY);
			closeButton.Draw(r, offsetX, offsetY);
			top = offsetY - 10;
			bottom = offsetY + 13;
			left = offsetX - 32 - pageNumberOffsetX;
			right = offsetX + 32 + pageNumberOffsetX;
			if (AsciiMouse.singleton.isDrawingOnCurrentPlatform)
			{
				if (IsMouseInLeftMargin())
				{
					leftArrow.Draw(r, AsciiMouse.singleton.x, AsciiMouse.singleton.y);
				}
				else if (IsMouseInRightMargin())
				{
					rightArrow.Draw(r, AsciiMouse.singleton.x, AsciiMouse.singleton.y);
				}
			}
		}
		else if (currentState == State.Out)
		{
			DrawPages(r, offsetX, offsetY + Mathf.RoundToInt(posY));
		}
	}

	protected virtual void DrawIntroText(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		int num = 0;
		if (subtitleBox.lineCount > 2)
		{
			num = subtitleBox.lineCount - 2;
		}
		titleBox.Draw(r, offsetX, offsetY - titleBox.lineCount + 1);
		subtitleBox.Draw(r, offsetX, offsetY);
		authorIntro.Draw(r, offsetX, offsetY + num);
		authorName.Draw(r, offsetX, offsetY + num);
		amountFoundBox.Draw(r, offsetX, offsetY);
	}

	private void HandleCloseButtonPressed(DialogButton btn)
	{
		Hide();
	}

	private void HandleSwipeLeft(float swipeDuration)
	{
		if (currentState == State.Idle && CanNext())
		{
			NextPage();
			SfxController.singleton.Play("booklet_turn_page");
		}
	}

	private void HandleSwipeRight(float swipeDuration)
	{
		if (currentState == State.Idle)
		{
			PreviousPage();
			SfxController.singleton.Play("booklet_turn_page");
		}
	}

	protected virtual void Awake()
	{
		modalFade = GetComponent<ModalFade>();
	}

	protected virtual void Start()
	{
		bookOpen.Load();
		bookPage1.Load();
		bookPage2.Load();
		bookPageLast.Load();
		bookPageBackCover.Load();
		closeButton.OnPressed += HandleCloseButtonPressed;
		SwipeDetection.OnSwipeLeft += HandleSwipeLeft;
		SwipeDetection.OnSwipeRight += HandleSwipeRight;
	}

	protected virtual void OnDestroy()
	{
		closeButton.OnPressed -= HandleCloseButtonPressed;
		SwipeDetection.OnSwipeLeft -= HandleSwipeLeft;
		SwipeDetection.OnSwipeRight -= HandleSwipeRight;
	}
}
