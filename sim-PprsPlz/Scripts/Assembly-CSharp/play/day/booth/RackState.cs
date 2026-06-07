using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class RackState : HxObject
	{
		public static int kItemIntraStepX;

		public static int kItemDropHeight;

		public static int kItemInsertBounceHeight;

		public Array entries;

		public int entryCount;

		public Array slotWidths;

		public Array slotEntryCounts;

		public int slotCount;

		public PointData drawPos;

		static RackState()
		{
		}

		public RackState(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public RackState()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_RackState(RackState __hx_this)
		{
		}

		public virtual void set(Carousel carousel, double availableWidth)
		{
		}

		public virtual bool needSync(Carousel carousel)
		{
			return false;
		}

		public virtual bool hasSlotItem(int slotIndex, CarouselSlotItem slotItem)
		{
			return false;
		}

		public virtual void draw(Drawer drawer, PointData baselineWorldPos, RackState b, double t)
		{
		}

		public virtual void clear()
		{
		}

		public virtual int getSlotIndexForX(double x)
		{
			return 0;
		}

		public virtual double getXForSlotIndex(int slotIndex)
		{
			return 0.0;
		}

		public virtual RackEntry allocEntry()
		{
			return null;
		}

		public virtual RackEntry find(CarouselSlotItem slotItem)
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
