using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.day.booth
{
	public class Carousel : Ent
	{
		public static int kPeekThresh0;

		public static int kPeekThresh1;

		public static int kPeekThresh2;

		public Array slots;

		public int focusSlotIndex;

		public bool stampRingVisible;

		public double stampRingWorldX;

		public PointData scrollOffset;

		public CarouselBoothElems boothElems;

		public PointData focusDrag;

		public CarouselSlot draggingSlot;

		public CarouselNudge nudge;

		public double scroll;

		public double slideTime0;

		public double slideTime1;

		public double slideScroll0;

		public int slideIndex1;

		public DeskItem hitDeskItem;

		public Fill swipeDebugFill;

		public PointData visaCenter;

		public double peekScrollOffset;

		public bool holdingTouch;

		public Pincher pincher;

		public Rack rack;

		public CarouselUnfloater unfloater;

		public HoverButton giveHoverButton;

		public HoverButton hangHoverButton;

		public HoverButton confiscateHoverButton;

		public PointData unnudgedSwipeStartPos;

		public CarouselState appliedState;

		public double stampRingHideUntilTime;

		public double swishSoundLastPlayTime;

		public bool busyWithBorderObservactionOnly;

		public double swipeApplyTime;

		public double peekingRecentTime0;

		public double peekingRecentTime1;

		static Carousel()
		{
		}

		public Carousel(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Carousel(Ent parent)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_Carousel(Carousel __hx_this, Ent parent)
		{
		}

		public bool get_isNudging()
		{
			return false;
		}

		public bool get_isInspecting()
		{
			return false;
		}

		public virtual void setRackPincherUnfloater(Rack rack_, Pincher pincher_, CarouselUnfloater unfloater_)
		{
		}

		public virtual void setBoothElems(CarouselBoothElems boothElems_)
		{
		}

		public virtual void whenRackDraw(Function drawListener)
		{
		}

		public virtual void add(DeskItem deskItem, object forceAnimateReveal)
		{
		}

		public virtual void compact()
		{
		}

		public virtual void endStamping(DeskItem stampingDeskItem, PointData stampingDeskItemStartPos)
		{
		}

		public virtual DeskItem getStampableDeskItem()
		{
			return null;
		}

		public virtual bool isInTightStack(DeskItem deskItem)
		{
			return false;
		}

		public virtual bool canStamp()
		{
			return false;
		}

		public virtual bool canPinch()
		{
			return false;
		}

		public virtual DeskItem pinch()
		{
			return null;
		}

		public virtual void unpinch()
		{
		}

		public virtual bool hasSlotAnimatingAppearance()
		{
			return false;
		}

		public virtual double calcScroll(int slotIndex, object recurseCount)
		{
			return 0.0;
		}

		public virtual void slideToSlotIndex(int targetFocusSlotIndex)
		{
		}

		public virtual CarouselState get_state()
		{
			return null;
		}

		public virtual CarouselState set_state(CarouselState s)
		{
			return null;
		}

		public virtual void hideHoverButtons()
		{
		}

		public override void update()
		{
		}

		public virtual void goBusyWithBorder(bool observationOnly)
		{
		}

		public virtual int getScrollFallbackSlotIndex(int slotIndex)
		{
			return 0;
		}

		public virtual double getSlotTopY(double slotHeight)
		{
			return 0.0;
		}

		public bool isFocusingOnDeskItem(DeskItem deskItem)
		{
			return false;
		}

		public virtual Pointer reactWhileInspecting(Input input)
		{
			return null;
		}

		public virtual void playSoundSwish(object multiple)
		{
		}

		public override void react(Input input)
		{
		}

		public virtual bool applyPointerJustUp()
		{
			return false;
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual int getPeekDeltaCommit()
		{
			return 0;
		}

		public virtual double getPeekDeltaF()
		{
			return 0.0;
		}

		public virtual double getPeekExtraReach()
		{
			return 0.0;
		}

		public virtual Pointer getPointerOver(Input input)
		{
			return null;
		}

		public virtual Swipe getSwipe(Input input)
		{
			return null;
		}

		public virtual void applySwipe(Input input, bool allowVerticalSwipes)
		{
		}

		public virtual int fixPeekDeltaCommit(int delta)
		{
			return 0;
		}

		public virtual void onClickHoverButton(Button button)
		{
		}

		public virtual DeskItem getHitDeskItem(PointData atWorldPos)
		{
			return null;
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public virtual bool autoIsAnimating()
		{
			return false;
		}

		public virtual SwipeDir autoSwipeDirToFocusOnDeskItem(DeskItem deskItem)
		{
			return null;
		}

		public virtual int autoGetDeskItemFocusSlotIndex(DeskItem deskItem)
		{
			return 0;
		}

		public virtual bool autoIsExplorable(DeskItem deskItem)
		{
			return false;
		}

		public virtual string autoGetSentryError()
		{
			return null;
		}

		public virtual StampDesk tutorGetStampDesk()
		{
			return null;
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
