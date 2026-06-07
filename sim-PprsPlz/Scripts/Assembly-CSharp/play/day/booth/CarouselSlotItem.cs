using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class CarouselSlotItem : HxObject
	{
		public static double kPaddingLR;

		public static double kAppearFromSlotDuration;

		public static double kAppearFromSlotMidPerc;

		public static double kAppearFromSlotFullsizePerc;

		public static double kAppearFromInnerDuration;

		public static double kAppearFromInnerMidPerc;

		public static double kAppearFromInnerFullsizePerc;

		public static double kAppearFromSideDuration;

		public static double kGiveDuration;

		public static double kGiveShrinkPerc;

		public static double kDisappearDuration;

		public static double kUngrabDuration;

		public static double kRisingForHangDuration;

		public static double kFallingToWallDuration;

		public static double kFallingForConfiscateDuration;

		public static double kRisingToFilerDuration;

		public static int kFallToWallFinalY;

		public double x;

		public double y;

		public double paddingB;

		public bool visibleInRack;

		public double sizeT;

		public int scrollFallbackScore;

		public DeskItem deskItem;

		public EntEnv entEnv;

		public PointData stateStartDeskItemPos;

		public CarouselSlotItemState state;

		public double stateStartTime;

		public PointData innerSize;

		static CarouselSlotItem()
		{
		}

		public CarouselSlotItem(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CarouselSlotItem(EntEnv entEnv_, DeskItem deskItem_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_CarouselSlotItem(CarouselSlotItem __hx_this, EntEnv entEnv_, DeskItem deskItem_)
		{
		}

		public Sprite get_rackSprite()
		{
			return null;
		}

		public PointData get_visaCenter()
		{
			return null;
		}

		public bool get_empty()
		{
			return false;
		}

		public bool get_isAnimatingAppearance()
		{
			return false;
		}

		public bool get_isGrabbed()
		{
			return false;
		}

		public double get_stateTime()
		{
			return 0.0;
		}

		public virtual CarouselSlotItemState set_state(CarouselSlotItemState state_)
		{
			return null;
		}

		public virtual void update()
		{
		}

		public Pointer getPointerOver(Ent ent, Input input)
		{
			return null;
		}

		public Swipe getSwipe(Input input)
		{
			return null;
		}

		public virtual bool applySwipe(SwipeDir swipeDir, PointData swipeStartWorldPos)
		{
			return false;
		}

		public virtual double width()
		{
			return 0.0;
		}

		public virtual double height(double paddingB)
		{
			return 0.0;
		}

		public virtual double tightStepHeight(double defaultStep)
		{
			return 0.0;
		}

		public bool hasDeskItem(DeskItem di)
		{
			return false;
		}

		public DeskItem getHitDeskItem(PointData atWorldPos)
		{
			return null;
		}

		public DeskItem getVisaDeskItem()
		{
			return null;
		}

		public bool canPinch()
		{
			return false;
		}

		public virtual DeskItem pinch()
		{
			return null;
		}

		public virtual bool unpinch()
		{
			return false;
		}

		public virtual bool canGive()
		{
			return false;
		}

		public virtual bool canGiveNowOrAfterWait()
		{
			return false;
		}

		public virtual bool canHangOnWall()
		{
			return false;
		}

		public virtual bool hangOnWall()
		{
			return false;
		}

		public virtual bool canConfiscate()
		{
			return false;
		}

		public virtual bool confiscate()
		{
			return false;
		}

		public virtual DeskItem getKeyDeskItem()
		{
			return null;
		}

		public virtual int get_intraSlotSortOrder()
		{
			return 0;
		}

		public virtual bool autoIsAnimating()
		{
			return false;
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
