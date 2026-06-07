using app.ent;
using app.vis;
using data;
using haxe.lang;

namespace play.day.booth
{
	public class CarouselSlot : HxObject
	{
		public static int kPaddingB;

		public static int kTightStackStep;

		public static int kLooseStackSpacing;

		public Array items;

		public int forceSortOrder;

		public bool tightStack;

		public PointData pos;

		public PointData workPoint;

		public CarouselGroupDef group;

		public EntEnv entEnv;

		static CarouselSlot()
		{
		}

		public CarouselSlot(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CarouselSlot(EntEnv entEnv_, DeskItem firstDeskItem)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_CarouselSlot(CarouselSlot __hx_this, EntEnv entEnv_, DeskItem firstDeskItem)
		{
		}

		public static CarouselGroupDef getSlotGroupForId(EntEnv entEnv, string id)
		{
			return null;
		}

		public static int sort(CarouselSlot a, CarouselSlot b)
		{
			return 0;
		}

		public bool get_empty()
		{
			return false;
		}

		public virtual void update(double x, double y)
		{
		}

		public virtual void removeEmptyItems()
		{
		}

		public virtual bool canAdd(DeskItem deskItem)
		{
			return false;
		}

		public virtual void add(DeskItem deskItem)
		{
		}

		public virtual double sizeT()
		{
			return 0.0;
		}

		public virtual double width()
		{
			return 0.0;
		}

		public virtual double height()
		{
			return 0.0;
		}

		public virtual Pointer getPointerOver(Ent ent, Input input)
		{
			return null;
		}

		public virtual Swipe getSwipe(Input input)
		{
			return null;
		}

		public virtual DeskItem getHitDeskItem(PointData atWorldPos)
		{
			return null;
		}

		public virtual DeskItem getVisaDeskItem()
		{
			return null;
		}

		public virtual bool canPinch()
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

		public virtual void hangOnWall()
		{
		}

		public virtual bool canConfiscate()
		{
			return false;
		}

		public virtual void confiscate()
		{
		}

		public virtual bool applySwipe(SwipeDir swipeDir, PointData swipeStartWorldPos)
		{
			return false;
		}

		public virtual bool hasItemAnimatingAppearance()
		{
			return false;
		}

		public virtual bool hasKeyDeskItems()
		{
			return false;
		}

		public virtual bool hasDeskItem(DeskItem deskItem)
		{
			return false;
		}

		public virtual Array getKeyDeskItems()
		{
			return null;
		}

		public virtual int scrollFallbackScore()
		{
			return 0;
		}

		public virtual bool autoIsExplorable(DeskItem deskItem)
		{
			return false;
		}

		public virtual bool autoIsAnimating()
		{
			return false;
		}

		public virtual string autoGetSentryError()
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
